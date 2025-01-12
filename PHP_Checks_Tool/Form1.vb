Imports System.Diagnostics
Imports System.IO
Imports Microsoft.Win32
Imports System.Text.RegularExpressions
Imports System.Text

Public Class Form1
    Private Const RegistryKey As String = "Software\MyPHPTool"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDirectory.Text = LoadSavedDirectory()
    End Sub

    Private Function LoadSavedDirectory() As String
        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(RegistryKey)
            If key IsNot Nothing Then
                Return key.GetValue("DirectoryPath", "").ToString()
            End If
        End Using
        Return ""
    End Function

    Private Sub SaveDirectory(path As String)
        Using key As RegistryKey = Registry.CurrentUser.CreateSubKey(RegistryKey)
            key.SetValue("DirectoryPath", path)
        End Using
    End Sub

    Private Sub btnSelectDir_Click(sender As Object, e As EventArgs) Handles btnSelectDir.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtDirectory.Text = FolderBrowserDialog1.SelectedPath
            SaveDirectory(FolderBrowserDialog1.SelectedPath)
        End If
    End Sub

    Private Sub RunCommand(command As String)
        If String.IsNullOrWhiteSpace(txtDirectory.Text) Then
            MessageBox.Show("Please select a directory first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' Disable buttons before running the command
            SetButtonsEnabled(False)

            Dim processInfo As New ProcessStartInfo()
            processInfo.FileName = "cmd.exe"
            processInfo.Arguments = "/c " & command
            processInfo.RedirectStandardOutput = True
            processInfo.RedirectStandardError = True
            processInfo.UseShellExecute = False
            processInfo.CreateNoWindow = True
            processInfo.WorkingDirectory = txtDirectory.Text
            processInfo.StandardOutputEncoding = System.Text.Encoding.UTF8

            Dim process As New Process()
            process.StartInfo = processInfo

            ' Clear the console at the start
            rtbConsole.Invoke(Sub() rtbConsole.Clear())

            ' Store all output lines
            Dim outputLines As New List(Of String)()

            ' Handle output data as it's received
            AddHandler process.OutputDataReceived, Sub(sender, e)
                                                       If e.Data IsNot Nothing Then
                                                           Dim output As String = StripAnsiCodes(e.Data)
                                                           My.Application.Log.WriteEntry("OutputDataReceived:")
                                                           My.Application.Log.WriteEntry(output)

                                                           ' Check if the line contains a progress pattern (e.g., [>])
                                                           If output.Contains("[>") OrElse output.Contains("[=]") Then
                                                               ' This is a progress line, update the last line in the console
                                                               rtbConsole.Invoke(Sub()
                                                                                     ' Overwrite the last line (if any) with the progress update
                                                                                     If outputLines.Count > 0 Then
                                                                                         outputLines(outputLines.Count - 1) = output
                                                                                     Else
                                                                                         outputLines.Add(output)
                                                                                     End If
                                                                                     ' Clear and re-add all lines (to update the progress)
                                                                                     rtbConsole.Clear()
                                                                                     rtbConsole.AppendText(String.Join(Environment.NewLine, outputLines))

                                                                                     ' Ensure the RichTextBox scrolls to the bottom
                                                                                     rtbConsole.SelectionStart = rtbConsole.Text.Length
                                                                                     rtbConsole.ScrollToCaret()
                                                                                 End Sub)
                                                           Else
                                                               ' Regular output, append it to the list
                                                               rtbConsole.Invoke(Sub()
                                                                                     outputLines.Add(output)
                                                                                     ' Append the new output normally
                                                                                     rtbConsole.AppendText(output & Environment.NewLine)
                                                                                 End Sub)
                                                           End If
                                                       End If
                                                   End Sub

            ' Handle error data
            AddHandler process.ErrorDataReceived, Sub(sender, e)
                                                      If e.Data IsNot Nothing Then
                                                          Dim errorOutput As String = StripAnsiCodes(e.Data)
                                                          rtbConsole.Invoke(Sub() rtbConsole.AppendText(errorOutput & Environment.NewLine))
                                                      End If
                                                  End Sub

            process.Start()
            process.BeginOutputReadLine()
            process.BeginErrorReadLine()

            ' Wait for the process to exit and re-enable buttons afterward
            Task.Run(Sub()
                         process.WaitForExit()
                         process.Dispose()

                         ' Re-enable buttons after the process finishes
                         rtbConsole.Invoke(Sub() SetButtonsEnabled(True))
                     End Sub)

        Catch ex As Exception
            MessageBox.Show("Error running command: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub









    Private Sub OutputHandler(sender As Object, e As DataReceivedEventArgs)
        If e.Data IsNot Nothing Then
            rtbConsole.Invoke(Sub() rtbConsole.AppendText(e.Data & Environment.NewLine))
        End If
    End Sub

    Private Sub btnPHPStan_Click(sender As Object, e As EventArgs) Handles btnPHPStan.Click
        RunCommand(".\vendor\bin\phpstan analyse --configuration=phpstan.neon --memory-limit=1G -v")
    End Sub

    Private Sub btnPHPCS_Click(sender As Object, e As EventArgs) Handles btnPHPCS.Click
        RunCommand(".\vendor\bin\phpcs --standard=phpcs.xml src")
    End Sub

    Private Sub btnStatus_Click(sender As Object, e As EventArgs) Handles btnStatus.Click
        RunCommand("git status")
    End Sub

    Private Sub btnPHPStanCommit_Click(sender As Object, e As EventArgs) Handles btnPHPStanCommit.Click
        RunCommand("git add . && git commit -m ""Altered code to ensure PHPStan level 8 compliance""")
    End Sub

    Private Sub btnPHPCSCommit_Click(sender As Object, e As EventArgs) Handles btnPHPCSCommit.Click
        RunCommand("git add . && git commit -m ""Altered code to ensure PSR-12 compliance""")
    End Sub

    Private Function StripAnsiCodes(input As String) As String
        ' Regex pattern to match ANSI escape codes
        Dim ansiEscape As New Regex("\x1B\[[0-9;]*[A-Za-z]")
        Return ansiEscape.Replace(input, "")
    End Function

    Private Sub SetButtonsEnabled(enabled As Boolean)
        btnPHPStan.Invoke(Sub() btnPHPStan.Enabled = enabled)
        btnPHPCS.Invoke(Sub() btnPHPCS.Enabled = enabled)
        btnStatus.Invoke(Sub() btnStatus.Enabled = enabled)
        btnPHPStanCommit.Invoke(Sub() btnPHPStanCommit.Enabled = enabled)
        btnPHPCSCommit.Invoke(Sub() btnPHPCSCommit.Enabled = enabled)
    End Sub
End Class
