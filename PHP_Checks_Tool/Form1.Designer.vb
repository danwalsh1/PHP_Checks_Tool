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
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.rtbConsole = New System.Windows.Forms.RichTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PHPStanCommitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PHPCSCommitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvancedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PHPStanCheckerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PHPCodeSnifferToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPHPStan
        '
        Me.btnPHPStan.Location = New System.Drawing.Point(12, 27)
        Me.btnPHPStan.Name = "btnPHPStan"
        Me.btnPHPStan.Size = New System.Drawing.Size(75, 23)
        Me.btnPHPStan.TabIndex = 0
        Me.btnPHPStan.Text = "PHPStan"
        Me.btnPHPStan.UseVisualStyleBackColor = True
        '
        'btnPHPCS
        '
        Me.btnPHPCS.Location = New System.Drawing.Point(93, 27)
        Me.btnPHPCS.Name = "btnPHPCS"
        Me.btnPHPCS.Size = New System.Drawing.Size(75, 23)
        Me.btnPHPCS.TabIndex = 1
        Me.btnPHPCS.Text = "PHP CS"
        Me.btnPHPCS.UseVisualStyleBackColor = True
        '
        'rtbConsole
        '
        Me.rtbConsole.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbConsole.BackColor = System.Drawing.Color.Black
        Me.rtbConsole.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbConsole.ForeColor = System.Drawing.Color.White
        Me.rtbConsole.Location = New System.Drawing.Point(12, 56)
        Me.rtbConsole.Name = "rtbConsole"
        Me.rtbConsole.Size = New System.Drawing.Size(1353, 609)
        Me.rtbConsole.TabIndex = 8
        Me.rtbConsole.Text = ""
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GitToolStripMenuItem, Me.AdvancedToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1377, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GitToolStripMenuItem
        '
        Me.GitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusToolStripMenuItem, Me.PHPStanCommitToolStripMenuItem, Me.PHPCSCommitToolStripMenuItem})
        Me.GitToolStripMenuItem.Name = "GitToolStripMenuItem"
        Me.GitToolStripMenuItem.Size = New System.Drawing.Size(34, 20)
        Me.GitToolStripMenuItem.Text = "Git"
        '
        'StatusToolStripMenuItem
        '
        Me.StatusToolStripMenuItem.Name = "StatusToolStripMenuItem"
        Me.StatusToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.StatusToolStripMenuItem.Text = "Status"
        '
        'PHPStanCommitToolStripMenuItem
        '
        Me.PHPStanCommitToolStripMenuItem.Name = "PHPStanCommitToolStripMenuItem"
        Me.PHPStanCommitToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.PHPStanCommitToolStripMenuItem.Text = "PHP Stan Commit"
        '
        'PHPCSCommitToolStripMenuItem
        '
        Me.PHPCSCommitToolStripMenuItem.Name = "PHPCSCommitToolStripMenuItem"
        Me.PHPCSCommitToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.PHPCSCommitToolStripMenuItem.Text = "PHP CS Commit"
        '
        'AdvancedToolStripMenuItem
        '
        Me.AdvancedToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PHPStanCheckerToolStripMenuItem, Me.PHPCodeSnifferToolStripMenuItem})
        Me.AdvancedToolStripMenuItem.Name = "AdvancedToolStripMenuItem"
        Me.AdvancedToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.AdvancedToolStripMenuItem.Text = "Advanced"
        '
        'PHPStanCheckerToolStripMenuItem
        '
        Me.PHPStanCheckerToolStripMenuItem.Name = "PHPStanCheckerToolStripMenuItem"
        Me.PHPStanCheckerToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.PHPStanCheckerToolStripMenuItem.Text = "PHP Stan Checker"
        '
        'PHPCodeSnifferToolStripMenuItem
        '
        Me.PHPCodeSnifferToolStripMenuItem.Name = "PHPCodeSnifferToolStripMenuItem"
        Me.PHPCodeSnifferToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.PHPCodeSnifferToolStripMenuItem.Text = "PHP Code Sniffer"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.InfoToolStripMenuItem.Text = "About PHP Checks Tool"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1377, 677)
        Me.Controls.Add(Me.rtbConsole)
        Me.Controls.Add(Me.btnPHPCS)
        Me.Controls.Add(Me.btnPHPStan)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "PHP Checks Tool"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPHPStan As Button
    Friend WithEvents btnPHPCS As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents rtbConsole As RichTextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents GitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PHPStanCommitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PHPCSCommitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdvancedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PHPStanCheckerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PHPCodeSnifferToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
End Class
