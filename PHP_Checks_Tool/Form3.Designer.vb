<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvancedPHPCSForm
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
        Me.btnRunCS = New System.Windows.Forms.Button()
        Me.dgvCSResults = New System.Windows.Forms.DataGridView()
        Me.FilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Message = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fixable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblSummary = New System.Windows.Forms.Label()
        CType(Me.dgvCSResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRunCS
        '
        Me.btnRunCS.Location = New System.Drawing.Point(12, 12)
        Me.btnRunCS.Name = "btnRunCS"
        Me.btnRunCS.Size = New System.Drawing.Size(79, 23)
        Me.btnRunCS.TabIndex = 0
        Me.btnRunCS.Text = "Run PHP CS"
        Me.btnRunCS.UseVisualStyleBackColor = True
        '
        'dgvCSResults
        '
        Me.dgvCSResults.AllowUserToAddRows = False
        Me.dgvCSResults.AllowUserToDeleteRows = False
        Me.dgvCSResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCSResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCSResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FilePath, Me.Line, Me.Column, Me.Type, Me.Message, Me.Fixable})
        Me.dgvCSResults.Location = New System.Drawing.Point(12, 41)
        Me.dgvCSResults.Name = "dgvCSResults"
        Me.dgvCSResults.ReadOnly = True
        Me.dgvCSResults.Size = New System.Drawing.Size(776, 397)
        Me.dgvCSResults.TabIndex = 1
        '
        'FilePath
        '
        Me.FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FilePath.FillWeight = 80.0!
        Me.FilePath.HeaderText = "File Path"
        Me.FilePath.Name = "FilePath"
        Me.FilePath.ReadOnly = True
        '
        'Line
        '
        Me.Line.HeaderText = "Line"
        Me.Line.Name = "Line"
        Me.Line.ReadOnly = True
        '
        'Column
        '
        Me.Column.HeaderText = "Column"
        Me.Column.Name = "Column"
        Me.Column.ReadOnly = True
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        '
        'Message
        '
        Me.Message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Message.HeaderText = "Message"
        Me.Message.Name = "Message"
        Me.Message.ReadOnly = True
        '
        'Fixable
        '
        Me.Fixable.HeaderText = "Fixable"
        Me.Fixable.Name = "Fixable"
        Me.Fixable.ReadOnly = True
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Location = New System.Drawing.Point(97, 17)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(160, 13)
        Me.lblSummary.TabIndex = 2
        Me.lblSummary.Text = "Errors: 0, Warnings: 0, Fixable: 0"
        '
        'AdvancedPHPCSForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblSummary)
        Me.Controls.Add(Me.dgvCSResults)
        Me.Controls.Add(Me.btnRunCS)
        Me.Name = "AdvancedPHPCSForm"
        Me.Text = "Advanced PHP Code Sniffer Checker"
        CType(Me.dgvCSResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRunCS As Button
    Friend WithEvents dgvCSResults As DataGridView
    Friend WithEvents FilePath As DataGridViewTextBoxColumn
    Friend WithEvents Line As DataGridViewTextBoxColumn
    Friend WithEvents Column As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents Message As DataGridViewTextBoxColumn
    Friend WithEvents Fixable As DataGridViewCheckBoxColumn
    Friend WithEvents lblSummary As Label
End Class
