Imports System.Diagnostics
Imports System.IO
Imports Microsoft.Win32
Imports System.Text.RegularExpressions
Imports System.Text

Public Class Form1
    Public WorkingDirectory As String
    Private StanCommitMessage As String
    Private CSCommitMessage As String
    Public Const BaseRegistryKey As String = "Software\PhpChecksTool\Profiles"
    Public Const SelectedProfileKey As String = "Software\PhpChecksTool\SelectedProfile"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim selectedProfileName = LoadSelectedProfile()
        If Not String.IsNullOrEmpty(selectedProfileName) Then
            Dim profiles = LoadProfiles()
            If profiles.ContainsKey(selectedProfileName) Then
                Dim profile = profiles(selectedProfileName)
                UpdateData(profile)
            End If
        End If
        LoadProfilesIntoMenu()
    End Sub

    Public Sub RefreshProfilesMenu()
        LoadProfilesIntoMenu()
    End Sub

    Private Sub LoadProfilesIntoMenu()
        ' Clear existing items
        SettingsToolStripMenuItem.DropDownItems.Clear()

        ' Load profiles
        Dim profiles = LoadProfiles()
        Dim selectedProfile = LoadSelectedProfile()

        ' Add profiles to the menu
        For Each profile In profiles.Values
            Dim menuItem As New ToolStripMenuItem(profile.Name) With {
                .Checked = (profile.Name = selectedProfile)
            }
            AddHandler menuItem.Click, Sub(sender, e)
                                           SaveSelectedProfile(profile.Name)
                                           UpdateData(profile)
                                           RefreshMenuChecks(sender)
                                       End Sub

            ' Add "Edit" option
            Dim editMenuItem As New ToolStripMenuItem("Edit")
            AddHandler editMenuItem.Click, Sub() EditProfile(profile)
            menuItem.DropDownItems.Add(editMenuItem)

            ' Add "Delete" option
            Dim deleteMenuItem As New ToolStripMenuItem("Delete")
            AddHandler deleteMenuItem.Click, Sub() DeleteProfileWithConfirmation(profile.Name)
            menuItem.DropDownItems.Add(deleteMenuItem)

            ' Add profile main item to the settings menu
            SettingsToolStripMenuItem.DropDownItems.Add(menuItem)
        Next

        ' Add "Add New Profile" option
        Dim addNewProfileItem As New ToolStripMenuItem("Add New Profile...")
        AddHandler addNewProfileItem.Click, AddressOf ShowAddProfileForm
        SettingsToolStripMenuItem.DropDownItems.Add(New ToolStripSeparator())
        SettingsToolStripMenuItem.DropDownItems.Add(addNewProfileItem)
    End Sub

    Private Sub EditProfile(profile As Profile)
        Dim profileForm As New ProfileForm()
        profileForm.Owner = Me
        profileForm.LoadProfile(profile)
        profileForm.ShowDialog()
    End Sub

    Private Sub UpdateData(profile As Profile)
        WorkingDirectory = profile.WorkingDirectory
        StanCommitMessage = profile.PHPStanCommitMessage
        CSCommitMessage = profile.PHPCSCommitMessage
    End Sub

    Private Sub DeleteProfileWithConfirmation(profileName As String)
        Dim result = MessageBox.Show($"Are you sure you want to delete the profile '{profileName}'?",
                                  "Delete Profile",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            DeleteProfile(profileName)
            If LoadSelectedProfile() = profileName Then
                SaveSelectedProfile("") ' Clear selected profile if it was deleted
            End If
            RefreshProfilesMenu()
        End If
    End Sub

    Private Sub RefreshMenuChecks(selectedItem As ToolStripMenuItem)
        'For Each item As ToolStripMenuItem In SettingsToolStripMenuItem.DropDownItems
        'item.Checked = (item Is selectedItem)
        'Next
        For Each item As ToolStripItem In SettingsToolStripMenuItem.DropDownItems
            Dim menuItem = TryCast(item, ToolStripMenuItem)
            If menuItem IsNot Nothing Then
                menuItem.Checked = (item Is selectedItem)
            End If
        Next
    End Sub

    Private Function LoadProfiles() As Dictionary(Of String, Profile)
        Dim profiles As New Dictionary(Of String, Profile)
        Using baseKey As RegistryKey = Registry.CurrentUser.OpenSubKey(BaseRegistryKey)
            If baseKey IsNot Nothing Then
                For Each profileName In baseKey.GetSubKeyNames()
                    Using profileKey As RegistryKey = baseKey.OpenSubKey(profileName)
                        If profileKey IsNot Nothing Then
                            profiles(profileName) = New Profile With {
                            .Name = profileName,
                            .WorkingDirectory = profileKey.GetValue("WorkingDirectory", "").ToString(),
                            .PHPStanCommitMessage = profileKey.GetValue("PHPStanCommitMessage", "").ToString(),
                            .PHPCSCommitMessage = profileKey.GetValue("PHPCSCommitMessage", "").ToString()
                        }
                        End If
                    End Using
                Next
            End If
        End Using
        Return profiles
    End Function

    Private Sub DeleteProfile(profileName As String)
        Using baseKey As RegistryKey = Registry.CurrentUser.OpenSubKey(BaseRegistryKey, writable:=True)
            If baseKey IsNot Nothing Then
                baseKey.DeleteSubKey(profileName, throwOnMissingSubKey:=False)
            End If
        End Using
    End Sub

    Private Function LoadSelectedProfile() As String
        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(SelectedProfileKey)
            If key IsNot Nothing Then
                Return key.GetValue("SelectedProfile", "").ToString()
            End If
        End Using
        Return ""
    End Function

    Private Sub SaveSelectedProfile(profileName As String)
        Using key As RegistryKey = Registry.CurrentUser.CreateSubKey(SelectedProfileKey)
            key.SetValue("SelectedProfile", profileName)
        End Using
    End Sub

    Private Sub RunCommand(command As String)
        If String.IsNullOrWhiteSpace(WorkingDirectory) Then
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
            processInfo.WorkingDirectory = WorkingDirectory
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

    Private Function StripAnsiCodes(input As String) As String
        ' Regex pattern to match ANSI escape codes
        Dim ansiEscape As New Regex("\x1B\[[0-9;]*[A-Za-z]")
        Return ansiEscape.Replace(input, "")
    End Function

    Private Sub SetButtonsEnabled(enabled As Boolean)
        btnPHPStan.Invoke(Sub() btnPHPStan.Enabled = enabled)
        btnPHPCS.Invoke(Sub() btnPHPCS.Enabled = enabled)
    End Sub

    Private Sub PHPStanCheckerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PHPStanCheckerToolStripMenuItem.Click
        If String.IsNullOrWhiteSpace(WorkingDirectory) Then
            MessageBox.Show("Please select a directory first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim advancedForm As New AdvancedPHPStanForm()
        advancedForm.Show()
    End Sub

    Private Sub PHPCodeSnifferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PHPCodeSnifferToolStripMenuItem.Click
        If String.IsNullOrWhiteSpace(WorkingDirectory) Then
            MessageBox.Show("Please select a directory first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim advancedForm As New AdvancedPHPCSForm()
        advancedForm.Show()
    End Sub

    Private Sub StatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatusToolStripMenuItem.Click
        RunCommand("git status")
    End Sub

    Private Sub PHPStanCommitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PHPStanCommitToolStripMenuItem.Click
        If String.IsNullOrWhiteSpace(StanCommitMessage) Then
            MessageBox.Show("The PHPStan commit message is empty. Please set a valid commit message in the profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim command As String = $"git add . && git commit -m ""{StanCommitMessage}"""
        RunCommand(command)
    End Sub

    Private Sub PHPCSCommitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PHPCSCommitToolStripMenuItem.Click
        If String.IsNullOrWhiteSpace(CSCommitMessage) Then
            MessageBox.Show("The PHP CS commit message is empty. Please set a valid commit message in the profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim command As String = $"git add . && git commit -m ""{CSCommitMessage}"""
        RunCommand(command)
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        Dim infoForm As New InfoForm()
        infoForm.ShowDialog()
    End Sub

    Private Sub ShowAddProfileForm()
        Dim profileForm As New ProfileForm()
        profileForm.Owner = Me
        profileForm.NewProfile()
        profileForm.ShowDialog()
    End Sub
End Class

Public Class Profile
    Public Property Name As String
    Public Property WorkingDirectory As String
    Public Property PHPStanCommitMessage As String
    Public Property PHPCSCommitMessage As String
End Class
