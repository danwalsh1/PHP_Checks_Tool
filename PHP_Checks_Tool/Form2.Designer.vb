<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvancedPHPStanForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnRunPHPStan = New System.Windows.Forms.Button()
        Me.dgvPHPStanResults = New System.Windows.Forms.DataGridView()
        Me.FilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Message = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ignorable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Identifier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvPHPStanResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRunPHPStan
        '
        Me.btnRunPHPStan.Location = New System.Drawing.Point(12, 12)
        Me.btnRunPHPStan.Name = "btnRunPHPStan"
        Me.btnRunPHPStan.Size = New System.Drawing.Size(89, 23)
        Me.btnRunPHPStan.TabIndex = 0
        Me.btnRunPHPStan.Text = "Run PHP Stan"
        Me.btnRunPHPStan.UseVisualStyleBackColor = True
        '
        'dgvPHPStanResults
        '
        Me.dgvPHPStanResults.AllowUserToAddRows = False
        Me.dgvPHPStanResults.AllowUserToDeleteRows = False
        Me.dgvPHPStanResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPHPStanResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPHPStanResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FilePath, Me.Line, Me.Message, Me.Ignorable, Me.Identifier})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPHPStanResults.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPHPStanResults.Location = New System.Drawing.Point(12, 41)
        Me.dgvPHPStanResults.Name = "dgvPHPStanResults"
        Me.dgvPHPStanResults.ReadOnly = True
        Me.dgvPHPStanResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPHPStanResults.Size = New System.Drawing.Size(1382, 397)
        Me.dgvPHPStanResults.TabIndex = 1
        '
        'FilePath
        '
        Me.FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FilePath.HeaderText = "File Path"
        Me.FilePath.Name = "FilePath"
        Me.FilePath.ReadOnly = True
        '
        'Line
        '
        Me.Line.FillWeight = 10.0!
        Me.Line.HeaderText = "Line Number"
        Me.Line.MinimumWidth = 100
        Me.Line.Name = "Line"
        Me.Line.ReadOnly = True
        '
        'Message
        '
        Me.Message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Message.HeaderText = "Message"
        Me.Message.Name = "Message"
        Me.Message.ReadOnly = True
        '
        'Ignorable
        '
        Me.Ignorable.HeaderText = "Ignorable?"
        Me.Ignorable.Name = "Ignorable"
        Me.Ignorable.ReadOnly = True
        '
        'Identifier
        '
        Me.Identifier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Identifier.FillWeight = 40.0!
        Me.Identifier.HeaderText = "Identifier"
        Me.Identifier.Name = "Identifier"
        Me.Identifier.ReadOnly = True
        '
        'AdvancedPHPStanForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1406, 450)
        Me.Controls.Add(Me.dgvPHPStanResults)
        Me.Controls.Add(Me.btnRunPHPStan)
        Me.Name = "AdvancedPHPStanForm"
        Me.Text = "Advanced PHP Stan Checker"
        CType(Me.dgvPHPStanResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnRunPHPStan As Button
    Friend WithEvents dgvPHPStanResults As DataGridView
    Friend WithEvents FilePath As DataGridViewTextBoxColumn
    Friend WithEvents Line As DataGridViewTextBoxColumn
    Friend WithEvents Message As DataGridViewTextBoxColumn
    Friend WithEvents Ignorable As DataGridViewCheckBoxColumn
    Friend WithEvents Identifier As DataGridViewTextBoxColumn
End Class
