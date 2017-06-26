<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm204c_01
    Inherits System.Windows.Forms.Form
    'Form 重写 Dispose，以清理组件列表。
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
    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer
    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnLoop = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnLoop
        '
        Me.btnLoop.Location = New System.Drawing.Point(39, 32)
        Me.btnLoop.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoop.Name = "btnLoop"
        Me.btnLoop.Size = New System.Drawing.Size(100, 31)
        Me.btnLoop.TabIndex = 55
        Me.btnLoop.Text = "循环测试一"
        Me.btnLoop.UseVisualStyleBackColor = True
        '
        'frm204c_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(217, 117)
        Me.Controls.Add(Me.btnLoop)
        Me.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frm204c_01"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm204c_01"
        Me.ResumeLayout(False)
    End Sub
    Friend WithEvents btnLoop As System.Windows.Forms.Button
End Class
