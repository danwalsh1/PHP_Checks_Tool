<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfoForm))
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.lblSource = New System.Windows.Forms.Label()
        Me.lblVersionValue = New System.Windows.Forms.Label()
        Me.lblAuthorValue = New System.Windows.Forms.Label()
        Me.lblContactValue = New System.Windows.Forms.LinkLabel()
        Me.lblSourceValue = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescription.Location = New System.Drawing.Point(12, 9)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(454, 155)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = resources.GetString("lblDescription.Text")
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(12, 164)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(45, 13)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Version:"
        '
        'lblAuthor
        '
        Me.lblAuthor.AutoSize = True
        Me.lblAuthor.Location = New System.Drawing.Point(12, 177)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(41, 13)
        Me.lblAuthor.TabIndex = 2
        Me.lblAuthor.Text = "Author:"
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Location = New System.Drawing.Point(12, 190)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(47, 13)
        Me.lblContact.TabIndex = 3
        Me.lblContact.Text = "Contact:"
        '
        'lblSource
        '
        Me.lblSource.AutoSize = True
        Me.lblSource.Location = New System.Drawing.Point(12, 203)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(44, 13)
        Me.lblSource.TabIndex = 4
        Me.lblSource.Text = "Source:"
        '
        'lblVersionValue
        '
        Me.lblVersionValue.AutoSize = True
        Me.lblVersionValue.Location = New System.Drawing.Point(63, 164)
        Me.lblVersionValue.Name = "lblVersionValue"
        Me.lblVersionValue.Size = New System.Drawing.Size(31, 13)
        Me.lblVersionValue.TabIndex = 5
        Me.lblVersionValue.Text = "1.3.0"
        '
        'lblAuthorValue
        '
        Me.lblAuthorValue.AutoSize = True
        Me.lblAuthorValue.Location = New System.Drawing.Point(63, 177)
        Me.lblAuthorValue.Name = "lblAuthorValue"
        Me.lblAuthorValue.Size = New System.Drawing.Size(70, 13)
        Me.lblAuthorValue.TabIndex = 6
        Me.lblAuthorValue.Text = "Daniel Walsh"
        '
        'lblContactValue
        '
        Me.lblContactValue.AutoSize = True
        Me.lblContactValue.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblContactValue.Location = New System.Drawing.Point(63, 190)
        Me.lblContactValue.Name = "lblContactValue"
        Me.lblContactValue.Size = New System.Drawing.Size(134, 13)
        Me.lblContactValue.TabIndex = 7
        Me.lblContactValue.TabStop = True
        Me.lblContactValue.Text = "php.checker@devzone.uk"
        '
        'lblSourceValue
        '
        Me.lblSourceValue.AutoSize = True
        Me.lblSourceValue.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lblSourceValue.Location = New System.Drawing.Point(63, 203)
        Me.lblSourceValue.Name = "lblSourceValue"
        Me.lblSourceValue.Size = New System.Drawing.Size(211, 13)
        Me.lblSourceValue.TabIndex = 8
        Me.lblSourceValue.TabStop = True
        Me.lblSourceValue.Text = "github.com/danwalsh1/PHP_Checks_Tool"
        '
        'InfoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 231)
        Me.Controls.Add(Me.lblSourceValue)
        Me.Controls.Add(Me.lblContactValue)
        Me.Controls.Add(Me.lblAuthorValue)
        Me.Controls.Add(Me.lblVersionValue)
        Me.Controls.Add(Me.lblSource)
        Me.Controls.Add(Me.lblContact)
        Me.Controls.Add(Me.lblAuthor)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblDescription)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InfoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About PHP Checks Tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDescription As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblAuthor As Label
    Friend WithEvents lblContact As Label
    Friend WithEvents lblSource As Label
    Friend WithEvents lblVersionValue As Label
    Friend WithEvents lblAuthorValue As Label
    Friend WithEvents lblContactValue As LinkLabel
    Friend WithEvents lblSourceValue As LinkLabel
End Class
