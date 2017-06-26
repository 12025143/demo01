<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm485_01
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
        Me.Button7 = New System.Windows.Forms.Button()
        Me.txtPortName = New System.Windows.Forms.ComboBox()
        Me.txtBaudRate = New System.Windows.Forms.ComboBox()
        Me.txtAxisNum = New System.Windows.Forms.ComboBox()
        Me.txtSndBuffer = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(24, 53)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(104, 38)
        Me.Button7.TabIndex = 4
        Me.Button7.Text = "工位1循环"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'txtPortName
        '
        Me.txtPortName.FormattingEnabled = True
        Me.txtPortName.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6"})
        Me.txtPortName.Location = New System.Drawing.Point(24, 12)
        Me.txtPortName.Name = "txtPortName"
        Me.txtPortName.Size = New System.Drawing.Size(61, 22)
        Me.txtPortName.TabIndex = 5
        Me.txtPortName.Text = "COM2"
        '
        'txtBaudRate
        '
        Me.txtBaudRate.FormattingEnabled = True
        Me.txtBaudRate.Items.AddRange(New Object() {"19200", "38400"})
        Me.txtBaudRate.Location = New System.Drawing.Point(106, 12)
        Me.txtBaudRate.Name = "txtBaudRate"
        Me.txtBaudRate.Size = New System.Drawing.Size(61, 22)
        Me.txtBaudRate.TabIndex = 5
        Me.txtBaudRate.Text = "38400"
        '
        'txtAxisNum
        '
        Me.txtAxisNum.FormattingEnabled = True
        Me.txtAxisNum.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", ""})
        Me.txtAxisNum.Location = New System.Drawing.Point(199, 12)
        Me.txtAxisNum.Name = "txtAxisNum"
        Me.txtAxisNum.Size = New System.Drawing.Size(61, 22)
        Me.txtAxisNum.TabIndex = 5
        Me.txtAxisNum.Text = "05"
        '
        'txtSndBuffer
        '
        Me.txtSndBuffer.Location = New System.Drawing.Point(24, 111)
        Me.txtSndBuffer.Multiline = True
        Me.txtSndBuffer.Name = "txtSndBuffer"
        Me.txtSndBuffer.Size = New System.Drawing.Size(442, 54)
        Me.txtSndBuffer.TabIndex = 6
        Me.txtSndBuffer.Text = "05 10 00 1B 00 05 0A 02 58 02 58 09 60 FF FF FF FF BB 32"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(472, 111)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(92, 38)
        Me.btnSend.TabIndex = 7
        Me.btnSend.Text = "发送"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'frm485_01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 177)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtSndBuffer)
        Me.Controls.Add(Me.txtAxisNum)
        Me.Controls.Add(Me.txtBaudRate)
        Me.Controls.Add(Me.txtPortName)
        Me.Controls.Add(Me.Button7)
        Me.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Name = "frm485_01"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm485_01"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents txtPortName As System.Windows.Forms.ComboBox
    Friend WithEvents txtBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents txtAxisNum As System.Windows.Forms.ComboBox
    Friend WithEvents txtSndBuffer As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
End Class
