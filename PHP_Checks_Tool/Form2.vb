Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Diagnostics
Imports System.Text
Imports System.Text.RegularExpressions

Public Class AdvancedPHPStanForm
    Private WorkingDirectory As String

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Assign the working directory
        WorkingDirectory = Form1.WorkingDirectory
    End Sub

    Private Sub btnRunPHPStan_Click(sender As Object, e As EventArgs) Handles btnRunPHPStan.Click
        ' Run the PHPStan command with JSON output
        Dim command As String = ".\vendor\bin\phpstan analyse --configuration=phpstan.neon --memory-limit=1G -v --error-format=json"
        RunPHPStanCommand(command, WorkingDirectory)
    End Sub

    Private Sub RunPHPStanCommand(command As String, workingDir As String)
        Try
            btnRunPHPStan.Enabled = False
            Dim processInfo As New ProcessStartInfo()

            Debug.WriteLine("Working Directory: " & processInfo.WorkingDirectory)

            processInfo.FileName = "cmd.exe"
            processInfo.Arguments = "/c " & command
            processInfo.RedirectStandardOutput = True
            processInfo.RedirectStandardError = True
            processInfo.UseShellExecute = False
            processInfo.CreateNoWindow = True
            processInfo.WorkingDirectory = workingDir

            Dim process As New Process()
            process.StartInfo = processInfo

            Dim outputBuilder As New StringBuilder()

            AddHandler process.OutputDataReceived, Sub(sender, e)
                                                       If e.Data IsNot Nothing Then
                                                           outputBuilder.AppendLine(e.Data)
                                                       End If
                                                   End Sub

            AddHandler process.ErrorDataReceived, Sub(sender, e)
                                                      If e.Data IsNot Nothing Then
                                                          outputBuilder.AppendLine(e.Data)
                                                      End If
                                                  End Sub

            process.Start()
            process.BeginOutputReadLine()
            process.BeginErrorReadLine()
            process.WaitForExit()

            ' Parse JSON output
            Dim jsonOutput As String = outputBuilder.ToString()
            If Not String.IsNullOrWhiteSpace(jsonOutput) Then
                ParseAndDisplayResults(jsonOutput)
            End If
            btnRunPHPStan.Enabled = True
        Catch ex As Exception
            btnRunPHPStan.Enabled = True
            MessageBox.Show("Error running PHPStan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ParseAndDisplayResults(rawOutput As String)
        Try
            ' Use a regular expression to extract the JSON part from the output
            Dim jsonRegex As New Regex("{.*}", RegexOptions.Singleline)
            Dim match As Match = jsonRegex.Match(rawOutput)

            If match.Success Then
                ' Extract the JSON string
                Dim jsonOutput As String = match.Value

                ' Parse the JSON output
                Dim results = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonOutput)

                If results.ContainsKey("files") Then
                    ' Get the "files" value as a JToken to check its type
                    Dim files As JToken = DirectCast(results("files"), JToken)

                    ' Populate the DataGridView
                    dgvPHPStanResults.Rows.Clear()

                    ' Check the type of "files" and handle accordingly
                    If files.Type = JTokenType.Object Then
                        ' If "files" is an object (with file paths as keys)
                        Dim filesObject As JObject = CType(files, JObject)

                        For Each fileEntry As KeyValuePair(Of String, JToken) In filesObject
                            ' The file path is the key in the JObject
                            Dim filePath As String = fileEntry.Key

                            ' The file details (errors and messages) are in the value
                            Dim fileDetails As JObject = DirectCast(fileEntry.Value, JObject)

                            ' Check if the file has "messages"
                            If fileDetails.ContainsKey("messages") Then
                                Dim messages As JArray = DirectCast(fileDetails("messages"), JArray)

                                For Each message As JObject In messages
                                    Dim line As String = If(message("line") IsNot Nothing, message("line").ToString(), "N/A")
                                    Dim messageText As String = If(message("message") IsNot Nothing, message("message").ToString(), "No message")
                                    Dim ignorable As Boolean = If(message("ignorable") IsNot Nothing, Convert.ToBoolean(message("ignorable")), False)
                                    Dim identifier As String = If(message("identifier") IsNot Nothing, message("identifier").ToString(), "N/A")

                                    ' Add a row to the DataGridView
                                    dgvPHPStanResults.Rows.Add(filePath, line, messageText, ignorable, identifier)
                                Next
                            End If
                        Next

                    ElseIf files.Type = JTokenType.Array Then
                        ' If "files" is an empty array (no file errors)
                        Dim filesArray As JArray = CType(files, JArray)

                        If filesArray.Count = 0 Then
                            ' If it's an empty array, show a message
                            MessageBox.Show("No errors found.", "No Errors", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Else
                MessageBox.Show("No valid JSON found in the output.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error parsing JSON: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeContextMenu()
        ' Create context menu
        Dim contextMenu As New ContextMenuStrip()

        ' Copy Cell Content option
        Dim copyMenuItem As New ToolStripMenuItem("Copy")
        AddHandler copyMenuItem.Click, AddressOf CopyCellContent
        contextMenu.Items.Add(copyMenuItem)

        ' Assign the context menu to the DataGridView
        dgvPHPStanResults.ContextMenuStrip = contextMenu

        ' Handle right-click to select the cell and update context menu
        AddHandler dgvPHPStanResults.MouseDown, AddressOf dgvPHPStanResults_MouseDown
    End Sub

    Private Sub dgvPHPStanResults_MouseDown(sender As Object, e As MouseEventArgs)
        ' Handle right-click to select the cell and customize the context menu
        If e.Button = MouseButtons.Right Then
            Dim hitTestInfo = dgvPHPStanResults.HitTest(e.X, e.Y)
            If hitTestInfo.RowIndex >= 0 AndAlso hitTestInfo.ColumnIndex >= 0 Then
                dgvPHPStanResults.ClearSelection()
                dgvPHPStanResults.Rows(hitTestInfo.RowIndex).Cells(hitTestInfo.ColumnIndex).Selected = True

                ' Get the context menu and clear previous items
                Dim contextMenu = dgvPHPStanResults.ContextMenuStrip
                contextMenu.Items.Clear()

                ' Add the "Copy" option
                Dim copyMenuItem As New ToolStripMenuItem("Copy")
                AddHandler copyMenuItem.Click, AddressOf CopyCellContent
                contextMenu.Items.Add(copyMenuItem)

                ' Add "Copy Filename" only if the column is the "File Path" column
                If hitTestInfo.ColumnIndex = dgvPHPStanResults.Columns("FilePath").Index Then
                    Dim copyFilenameMenuItem As New ToolStripMenuItem("Copy Filename")
                    AddHandler copyFilenameMenuItem.Click, AddressOf CopyFilenameContent
                    contextMenu.Items.Add(copyFilenameMenuItem)
                End If
            End If
        End If
    End Sub

    Private Sub CopyCellContent(sender As Object, e As EventArgs)
        ' Copy the content of the selected cell
        If dgvPHPStanResults.SelectedCells.Count > 0 Then
            Dim selectedCell = dgvPHPStanResults.SelectedCells(0)
            If selectedCell.Value IsNot Nothing Then
                Clipboard.SetText(selectedCell.Value.ToString())
            End If
        End If
    End Sub

    Private Sub CopyFilenameContent(sender As Object, e As EventArgs)
        ' Copy the filename only from the selected cell
        If dgvPHPStanResults.SelectedCells.Count > 0 Then
            Dim selectedCell = dgvPHPStanResults.SelectedCells(0)
            If selectedCell.Value IsNot Nothing Then
                Dim fullPath As String = selectedCell.Value.ToString()
                Dim fileName As String = IO.Path.GetFileName(fullPath) ' Extract the filename
                Clipboard.SetText(fileName)
            End If
        End If
    End Sub

    Private Sub AdvancedPHPStanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeContextMenu()
    End Sub
End Class