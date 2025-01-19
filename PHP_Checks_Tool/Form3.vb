Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Diagnostics
Imports System.Text
Imports System.Text.RegularExpressions

Public Class AdvancedPHPCSForm
    Private WorkingDirectory As String

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Assign the working directory.
        WorkingDirectory = Form1.WorkingDirectory
    End Sub

    Private Sub btnRunCS_Click(sender As Object, e As EventArgs) Handles btnRunCS.Click
        Dim command As String = ".\vendor\bin\phpcs --standard=phpcs.xml src --report=json"
        RunPHCSCommand(command, WorkingDirectory)
    End Sub

    Private Sub RunPHCSCommand(command As String, workingDir As String)
        Try
            Dim processInfo As New ProcessStartInfo()
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

            ' Parse JSON output.
            Dim jsonOutput As String = outputBuilder.ToString()
            If Not String.IsNullOrWhiteSpace(jsonOutput) Then
                ParseAndDisplayResults(jsonOutput)
            End If

        Catch ex As Exception
            MessageBox.Show("Error running PHPCS: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ParseAndDisplayResults(rawOutput As String)
        Try
            ' Use a regular expression to extract the JSON part.
            Dim jsonRegex As New Regex("{.*}", RegexOptions.Singleline)
            Dim match As Match = jsonRegex.Match(rawOutput)

            If match.Success Then
                ' Extract the JSON string.
                Dim jsonOutput As String = match.Value

                ' Parse the JSON output.
                Dim results = JsonConvert.DeserializeObject(Of JObject)(jsonOutput)
                Dim totals = results("totals")
                Dim files = CType(results("files"), JObject) ' Cast to JObject for iteration

                ' Display totals in a label.
                lblSummary.Text = $"Errors: {totals("errors")}, Warnings: {totals("warnings")}, Fixable: {totals("fixable")}"

                ' Populate the DataGridView.
                dgvCSResults.Rows.Clear()

                For Each fileProperty As KeyValuePair(Of String, JToken) In files
                    Dim filePath As String = fileProperty.Key
                    Dim fileDetails As JObject = CType(fileProperty.Value, JObject)

                    Dim errors As Integer = fileDetails("errors").Value(Of Integer)
                    Dim warnings As Integer = fileDetails("warnings").Value(Of Integer)

                    ' Skip files with no errors or warnings
                    If errors = 0 AndAlso warnings = 0 Then Continue For

                    Dim messages = CType(fileDetails("messages"), JArray)

                    For Each message As JObject In messages
                        Dim line As String = If(message("line") IsNot Nothing, message("line").ToString(), "N/A")
                        Dim column As String = If(message("column") IsNot Nothing, message("column").ToString(), "N/A")
                        Dim type As String = If(message("type") IsNot Nothing, message("type").ToString(), "N/A")
                        Dim messageText As String = If(message("message") IsNot Nothing, message("message").ToString(), "No message")
                        Dim fixable As Boolean = If(message("fixable") IsNot Nothing, message("fixable").Value(Of Boolean), False)

                        ' Add a row to the DataGridView.
                        dgvCSResults.Rows.Add(filePath, line, column, type, messageText, fixable)
                    Next
                Next
            Else
                MessageBox.Show("No valid JSON found in the output.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error parsing JSON: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub dgvCSResults_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvCSResults.CellMouseDown
        If e.Button = MouseButtons.Right AndAlso e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            dgvCSResults.CurrentCell = dgvCSResults(e.ColumnIndex, e.RowIndex)

            Dim contextMenu As New ContextMenuStrip()

            Dim copyItem As New ToolStripMenuItem("Copy")
            AddHandler copyItem.Click, Sub()
                                           Clipboard.SetText(dgvCSResults.CurrentCell.Value.ToString())
                                       End Sub
            contextMenu.Items.Add(copyItem)

            If dgvCSResults.Columns(e.ColumnIndex).Name = "FilePath" Then
                Dim copyFilenameItem As New ToolStripMenuItem("Copy Filename")
                AddHandler copyFilenameItem.Click, Sub()
                                                       Dim fullPath = dgvCSResults.CurrentCell.Value.ToString()
                                                       Dim fileName = System.IO.Path.GetFileName(fullPath)
                                                       Clipboard.SetText(fileName)
                                                   End Sub
                contextMenu.Items.Add(copyFilenameItem)
            End If

            contextMenu.Show(Cursor.Position)
        End If
    End Sub
End Class