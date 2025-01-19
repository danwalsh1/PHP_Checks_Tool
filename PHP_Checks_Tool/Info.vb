Public Class InfoForm
    Private Sub InfoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblContactValue.Links.Clear()
        lblContactValue.Links.Add(0, lblContactValue.Text.Length, "mailto:php.checker@devzone.uk")

        lblSourceValue.Links.Clear()
        lblSourceValue.Links.Add(0, lblSourceValue.Text.Length, "https://github.com/danwalsh1/PHP_Checks_Tool")
    End Sub

    Private Sub lblContactValue_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblContactValue.LinkClicked
        Process.Start(e.Link.LinkData.ToString())
    End Sub

    Private Sub lblSourceValue_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblSourceValue.LinkClicked
        Process.Start(e.Link.LinkData.ToString())
    End Sub
End Class