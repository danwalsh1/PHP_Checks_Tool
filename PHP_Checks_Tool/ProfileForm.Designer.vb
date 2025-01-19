<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfileForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtProfileName = New System.Windows.Forms.TextBox()
        Me.lblWorkingDirectory = New System.Windows.Forms.Label()
        Me.txtWorkingDirectory = New System.Windows.Forms.TextBox()
        Me.txtPHPStanMessage = New System.Windows.Forms.TextBox()
        Me.txtPHPCSMessage = New System.Windows.Forms.TextBox()
        Me.lblStanMessage = New System.Windows.Forms.Label()
        Me.lblCsMessage = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(82, 15)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(70, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Profile Name:"
        '
        'txtProfileName
        '
        Me.txtProfileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfileName.Location = New System.Drawing.Point(158, 12)
        Me.txtProfileName.Name = "txtProfileName"
        Me.txtProfileName.Size = New System.Drawing.Size(665, 20)
        Me.txtProfileName.TabIndex = 1
        '
        'lblWorkingDirectory
        '
        Me.lblWorkingDirectory.AutoSize = True
        Me.lblWorkingDirectory.Location = New System.Drawing.Point(57, 41)
        Me.lblWorkingDirectory.Name = "lblWorkingDirectory"
        Me.lblWorkingDirectory.Size = New System.Drawing.Size(95, 13)
        Me.lblWorkingDirectory.TabIndex = 2
        Me.lblWorkingDirectory.Text = "Working Directory:"
        '
        'txtWorkingDirectory
        '
        Me.txtWorkingDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWorkingDirectory.Location = New System.Drawing.Point(158, 38)
        Me.txtWorkingDirectory.Name = "txtWorkingDirectory"
        Me.txtWorkingDirectory.Size = New System.Drawing.Size(665, 20)
        Me.txtWorkingDirectory.TabIndex = 3
        '
        'txtPHPStanMessage
        '
        Me.txtPHPStanMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPHPStanMessage.Location = New System.Drawing.Point(158, 64)
        Me.txtPHPStanMessage.Name = "txtPHPStanMessage"
        Me.txtPHPStanMessage.Size = New System.Drawing.Size(665, 20)
        Me.txtPHPStanMessage.TabIndex = 4
        '
        'txtPHPCSMessage
        '
        Me.txtPHPCSMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPHPCSMessage.Location = New System.Drawing.Point(158, 90)
        Me.txtPHPCSMessage.Name = "txtPHPCSMessage"
        Me.txtPHPCSMessage.Size = New System.Drawing.Size(665, 20)
        Me.txtPHPCSMessage.TabIndex = 5
        '
        'lblStanMessage
        '
        Me.lblStanMessage.AutoSize = True
        Me.lblStanMessage.Location = New System.Drawing.Point(12, 67)
        Me.lblStanMessage.Name = "lblStanMessage"
        Me.lblStanMessage.Size = New System.Drawing.Size(140, 13)
        Me.lblStanMessage.TabIndex = 6
        Me.lblStanMessage.Text = "PHP Stan Commit Message:"
        '
        'lblCsMessage
        '
        Me.lblCsMessage.AutoSize = True
        Me.lblCsMessage.Location = New System.Drawing.Point(20, 93)
        Me.lblCsMessage.Name = "lblCsMessage"
        Me.lblCsMessage.Size = New System.Drawing.Size(132, 13)
        Me.lblCsMessage.TabIndex = 7
        Me.lblCsMessage.Text = "PHP CS Commit Message:"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(748, 116)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 152)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblCsMessage)
        Me.Controls.Add(Me.lblStanMessage)
        Me.Controls.Add(Me.txtPHPCSMessage)
        Me.Controls.Add(Me.txtPHPStanMessage)
        Me.Controls.Add(Me.txtWorkingDirectory)
        Me.Controls.Add(Me.lblWorkingDirectory)
        Me.Controls.Add(Me.txtProfileName)
        Me.Controls.Add(Me.lblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProfileForm"
        Me.Text = "Manage Profile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblName As Label
    Friend WithEvents txtProfileName As TextBox
    Friend WithEvents lblWorkingDirectory As Label
    Friend WithEvents txtWorkingDirectory As TextBox
    Friend WithEvents txtPHPStanMessage As TextBox
    Friend WithEvents txtPHPCSMessage As TextBox
    Friend WithEvents lblStanMessage As Label
    Friend WithEvents lblCsMessage As Label
    Friend WithEvents btnSave As Button
End Class
