Imports Microsoft.Win32

Public Class ProfileForm
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate input
        If String.IsNullOrWhiteSpace(txtProfileName.Text) OrElse String.IsNullOrWhiteSpace(txtWorkingDirectory.Text) Then
            MessageBox.Show("Profile Name and Working Directory are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim profile As New Profile With {
            .Name = txtProfileName.Text,
            .WorkingDirectory = txtWorkingDirectory.Text,
            .PHPStanCommitMessage = txtPHPStanMessage.Text,
            .PHPCSCommitMessage = txtPHPCSMessage.Text
        }

        SaveProfile(profile)
        ' Notify the main form to refresh profiles
        Dim mainForm = TryCast(Me.Owner, Form1)
        If mainForm IsNot Nothing Then
            mainForm.RefreshProfilesMenu()
        End If

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub SaveProfile(profile As Profile)
        Using profileKey As RegistryKey = Registry.CurrentUser.CreateSubKey($"{Form1.BaseRegistryKey}\{profile.Name}")
            profileKey.SetValue("WorkingDirectory", profile.WorkingDirectory)
            profileKey.SetValue("PHPStanCommitMessage", profile.PHPStanCommitMessage)
            profileKey.SetValue("PHPCSCommitMessage", profile.PHPCSCommitMessage)
        End Using
    End Sub

    Public Sub NewProfile()
        txtProfileName.ReadOnly = False
        txtProfileName.Text = ""
        txtWorkingDirectory.Text = ""
        txtPHPStanMessage.Text = ""
        txtPHPCSMessage.Text = ""
    End Sub

    Public Sub LoadProfile(profile As Profile)
        txtProfileName.Text = profile.Name
        txtProfileName.ReadOnly = True
        txtWorkingDirectory.Text = profile.WorkingDirectory
        txtPHPStanMessage.Text = profile.PHPStanCommitMessage
        txtPHPCSMessage.Text = profile.PHPCSCommitMessage
    End Sub
End Class