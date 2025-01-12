<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnPHPStan = New System.Windows.Forms.Button()
        Me.btnPHPCS = New System.Windows.Forms.Button()
        Me.btnStatus = New System.Windows.Forms.Button()
        Me.btnPHPStanCommit = New System.Windows.Forms.Button()
        Me.btnPHPCSCommit = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSelectDir = New System.Windows.Forms.Button()
        Me.txtDirectory = New System.Windows.Forms.TextBox()
        Me.rtbConsole = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'btnPHPStan
        '
        Me.btnPHPStan.Location = New System.Drawing.Point(12, 12)
        Me.btnPHPStan.Name = "btnPHPStan"
        Me.btnPHPStan.Size = New System.Drawing.Size(75, 23)
        Me.btnPHPStan.TabIndex = 0
        Me.btnPHPStan.Text = "PHPStan"
        Me.btnPHPStan.UseVisualStyleBackColor = True
        '
        'btnPHPCS
        '
        Me.btnPHPCS.Location = New System.Drawing.Point(93, 12)
        Me.btnPHPCS.Name = "btnPHPCS"
        Me.btnPHPCS.Size = New System.Drawing.Size(75, 23)
        Me.btnPHPCS.TabIndex = 1
        Me.btnPHPCS.Text = "PHP CS"
        Me.btnPHPCS.UseVisualStyleBackColor = True
        '
        'btnStatus
        '
        Me.btnStatus.Location = New System.Drawing.Point(174, 12)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(75, 23)
        Me.btnStatus.TabIndex = 2
        Me.btnStatus.Text = "Status"
        Me.btnStatus.UseVisualStyleBackColor = True
        '
        'btnPHPStanCommit
        '
        Me.btnPHPStanCommit.Location = New System.Drawing.Point(255, 12)
        Me.btnPHPStanCommit.Name = "btnPHPStanCommit"
        Me.btnPHPStanCommit.Size = New System.Drawing.Size(98, 23)
        Me.btnPHPStanCommit.TabIndex = 3
        Me.btnPHPStanCommit.Text = "PHPStan Commit"
        Me.btnPHPStanCommit.UseVisualStyleBackColor = True
        '
        'btnPHPCSCommit
        '
        Me.btnPHPCSCommit.Location = New System.Drawing.Point(359, 12)
        Me.btnPHPCSCommit.Name = "btnPHPCSCommit"
        Me.btnPHPCSCommit.Size = New System.Drawing.Size(97, 23)
        Me.btnPHPCSCommit.TabIndex = 4
        Me.btnPHPCSCommit.Text = "PHP CS Commit"
        Me.btnPHPCSCommit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(461, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(2, 23)
        Me.Label1.TabIndex = 5
        '
        'btnSelectDir
        '
        Me.btnSelectDir.Location = New System.Drawing.Point(469, 12)
        Me.btnSelectDir.Name = "btnSelectDir"
        Me.btnSelectDir.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectDir.TabIndex = 6
        Me.btnSelectDir.Text = "Select..."
        Me.btnSelectDir.UseVisualStyleBackColor = True
        '
        'txtDirectory
        '
        Me.txtDirectory.Location = New System.Drawing.Point(550, 15)
        Me.txtDirectory.Name = "txtDirectory"
        Me.txtDirectory.Size = New System.Drawing.Size(463, 20)
        Me.txtDirectory.TabIndex = 7
        '
        'rtbConsole
        '
        Me.rtbConsole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbConsole.BackColor = System.Drawing.Color.Black
        Me.rtbConsole.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbConsole.ForeColor = System.Drawing.Color.White
        Me.rtbConsole.Location = New System.Drawing.Point(12, 41)
        Me.rtbConsole.Name = "rtbConsole"
        Me.rtbConsole.Size = New System.Drawing.Size(1178, 624)
        Me.rtbConsole.TabIndex = 8
        Me.rtbConsole.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1202, 677)
        Me.Controls.Add(Me.rtbConsole)
        Me.Controls.Add(Me.txtDirectory)
        Me.Controls.Add(Me.btnSelectDir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPHPCSCommit)
        Me.Controls.Add(Me.btnPHPStanCommit)
        Me.Controls.Add(Me.btnStatus)
        Me.Controls.Add(Me.btnPHPCS)
        Me.Controls.Add(Me.btnPHPStan)
        Me.Name = "Form1"
        Me.Text = "PHP Checks Tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPHPStan As Button
    Friend WithEvents btnPHPCS As Button
    Friend WithEvents btnStatus As Button
    Friend WithEvents btnPHPStanCommit As Button
    Friend WithEvents btnPHPCSCommit As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSelectDir As Button
    Friend WithEvents txtDirectory As TextBox
    Friend WithEvents rtbConsole As RichTextBox
End Class
