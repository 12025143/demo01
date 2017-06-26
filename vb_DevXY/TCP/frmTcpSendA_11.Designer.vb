<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTcpSendA_11
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
        Me.c = New System.Windows.Forms.GroupBox()
        Me.txtTimeOut5 = New System.Windows.Forms.TextBox()
        Me.txtPort5 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnDisConnect5 = New System.Windows.Forms.Button()
        Me.btnConnect5 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTimeOut8 = New System.Windows.Forms.TextBox()
        Me.txtPort8 = New System.Windows.Forms.TextBox()
        Me.btnDisConnect8 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnConnect8 = New System.Windows.Forms.Button()
        Me.txtIpR5 = New System.Windows.Forms.ComboBox()
        Me.txtIpR8 = New System.Windows.Forms.ComboBox()
        Me.btnSend5 = New System.Windows.Forms.Button()
        Me.btnSend8 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox5i = New System.Windows.Forms.TextBox()
        Me.TextBox8i = New System.Windows.Forms.TextBox()
        Me.lbError5 = New System.Windows.Forms.Label()
        Me.lbError8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.c.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'c
        '
        Me.c.Controls.Add(Me.txtIpR5)
        Me.c.Controls.Add(Me.TextBox5i)
        Me.c.Controls.Add(Me.TextBox5)
        Me.c.Controls.Add(Me.txtTimeOut5)
        Me.c.Controls.Add(Me.txtPort5)
        Me.c.Controls.Add(Me.lbError5)
        Me.c.Controls.Add(Me.Label19)
        Me.c.Controls.Add(Me.Label15)
        Me.c.Controls.Add(Me.Label16)
        Me.c.Controls.Add(Me.btnDisConnect5)
        Me.c.Controls.Add(Me.btnSend5)
        Me.c.Controls.Add(Me.btnConnect5)
        Me.c.Location = New System.Drawing.Point(21, 32)
        Me.c.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.c.Name = "c"
        Me.c.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.c.Size = New System.Drawing.Size(285, 249)
        Me.c.TabIndex = 8
        Me.c.TabStop = False
        Me.c.Text = "远程以太网"
        '
        'txtTimeOut5
        '
        Me.txtTimeOut5.Location = New System.Drawing.Point(107, 84)
        Me.txtTimeOut5.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtTimeOut5.Name = "txtTimeOut5"
        Me.txtTimeOut5.Size = New System.Drawing.Size(168, 26)
        Me.txtTimeOut5.TabIndex = 1
        Me.txtTimeOut5.Text = "500"
        Me.txtTimeOut5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPort5
        '
        Me.txtPort5.Location = New System.Drawing.Point(107, 55)
        Me.txtPort5.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtPort5.Name = "txtPort5"
        Me.txtPort5.Size = New System.Drawing.Size(168, 26)
        Me.txtPort5.TabIndex = 1
        Me.txtPort5.Text = "5000"
        Me.txtPort5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 89)
        Me.Label19.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 16)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "time out"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 29)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 16)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "IP"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 60)
        Me.Label16.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 16)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Port"
        '
        'btnDisConnect5
        '
        Me.btnDisConnect5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnDisConnect5.Location = New System.Drawing.Point(213, 123)
        Me.btnDisConnect5.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnDisConnect5.Name = "btnDisConnect5"
        Me.btnDisConnect5.Size = New System.Drawing.Size(62, 35)
        Me.btnDisConnect5.TabIndex = 0
        Me.btnDisConnect5.Text = "断开"
        Me.btnDisConnect5.UseVisualStyleBackColor = True
        '
        'btnConnect5
        '
        Me.btnConnect5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnConnect5.Location = New System.Drawing.Point(106, 123)
        Me.btnConnect5.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnConnect5.Name = "btnConnect5"
        Me.btnConnect5.Size = New System.Drawing.Size(97, 35)
        Me.btnConnect5.TabIndex = 0
        Me.btnConnect5.Text = "连接"
        Me.btnConnect5.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtIpR8)
        Me.GroupBox2.Controls.Add(Me.TextBox8i)
        Me.GroupBox2.Controls.Add(Me.TextBox8)
        Me.GroupBox2.Controls.Add(Me.txtTimeOut8)
        Me.GroupBox2.Controls.Add(Me.txtPort8)
        Me.GroupBox2.Controls.Add(Me.lbError8)
        Me.GroupBox2.Controls.Add(Me.btnDisConnect8)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.btnSend8)
        Me.GroupBox2.Controls.Add(Me.btnConnect8)
        Me.GroupBox2.Location = New System.Drawing.Point(328, 32)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(285, 249)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TCP/IP 通讯"
        '
        'txtTimeOut8
        '
        Me.txtTimeOut8.Location = New System.Drawing.Point(104, 84)
        Me.txtTimeOut8.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtTimeOut8.Name = "txtTimeOut8"
        Me.txtTimeOut8.Size = New System.Drawing.Size(168, 26)
        Me.txtTimeOut8.TabIndex = 1
        Me.txtTimeOut8.Text = "500"
        Me.txtTimeOut8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPort8
        '
        Me.txtPort8.Location = New System.Drawing.Point(104, 53)
        Me.txtPort8.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtPort8.Name = "txtPort8"
        Me.txtPort8.Size = New System.Drawing.Size(168, 26)
        Me.txtPort8.TabIndex = 1
        Me.txtPort8.Text = "8000"
        Me.txtPort8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnDisConnect8
        '
        Me.btnDisConnect8.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnDisConnect8.Location = New System.Drawing.Point(214, 123)
        Me.btnDisConnect8.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnDisConnect8.Name = "btnDisConnect8"
        Me.btnDisConnect8.Size = New System.Drawing.Size(58, 35)
        Me.btnDisConnect8.TabIndex = 0
        Me.btnDisConnect8.Text = "断开"
        Me.btnDisConnect8.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 89)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 16)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "time out"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 29)
        Me.Label18.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(24, 16)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "IP"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 60)
        Me.Label20.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 16)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Port"
        '
        'btnConnect8
        '
        Me.btnConnect8.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnConnect8.Location = New System.Drawing.Point(104, 123)
        Me.btnConnect8.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnConnect8.Name = "btnConnect8"
        Me.btnConnect8.Size = New System.Drawing.Size(100, 35)
        Me.btnConnect8.TabIndex = 0
        Me.btnConnect8.Text = "连接"
        Me.btnConnect8.UseVisualStyleBackColor = True
        '
        'txtIpR5
        '
        Me.txtIpR5.FormattingEnabled = True
        Me.txtIpR5.Items.AddRange(New Object() {"192.168.56.1", "192.168.0.1"})
        Me.txtIpR5.Location = New System.Drawing.Point(107, 25)
        Me.txtIpR5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIpR5.Name = "txtIpR5"
        Me.txtIpR5.Size = New System.Drawing.Size(168, 24)
        Me.txtIpR5.TabIndex = 29
        Me.txtIpR5.Text = "192.168.56.1"
        '
        'txtIpR8
        '
        Me.txtIpR8.FormattingEnabled = True
        Me.txtIpR8.Items.AddRange(New Object() {"192.168.56.1", "192.168.0.1"})
        Me.txtIpR8.Location = New System.Drawing.Point(104, 25)
        Me.txtIpR8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIpR8.Name = "txtIpR8"
        Me.txtIpR8.Size = New System.Drawing.Size(168, 24)
        Me.txtIpR8.TabIndex = 28
        Me.txtIpR8.Text = "192.168.56.1"
        '
        'btnSend5
        '
        Me.btnSend5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnSend5.Location = New System.Drawing.Point(44, 168)
        Me.btnSend5.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSend5.Name = "btnSend5"
        Me.btnSend5.Size = New System.Drawing.Size(52, 35)
        Me.btnSend5.TabIndex = 0
        Me.btnSend5.Text = "发送"
        Me.btnSend5.UseVisualStyleBackColor = True
        '
        'btnSend8
        '
        Me.btnSend8.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnSend8.Location = New System.Drawing.Point(37, 168)
        Me.btnSend8.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSend8.Name = "btnSend8"
        Me.btnSend8.Size = New System.Drawing.Size(57, 35)
        Me.btnSend8.TabIndex = 0
        Me.btnSend8.Text = "发送"
        Me.btnSend8.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(106, 174)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(169, 26)
        Me.TextBox5.TabIndex = 1
        Me.TextBox5.Text = "$GetVariable,R$"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(104, 174)
        Me.TextBox8.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(168, 26)
        Me.TextBox8.TabIndex = 1
        Me.TextBox8.Text = "Q A 1 2"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox5i
        '
        Me.TextBox5i.Location = New System.Drawing.Point(106, 210)
        Me.TextBox5i.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBox5i.Name = "TextBox5i"
        Me.TextBox5i.Size = New System.Drawing.Size(169, 26)
        Me.TextBox5i.TabIndex = 1
        Me.TextBox5i.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox8i
        '
        Me.TextBox8i.Location = New System.Drawing.Point(104, 210)
        Me.TextBox8i.Margin = New System.Windows.Forms.Padding(5)
        Me.TextBox8i.Name = "TextBox8i"
        Me.TextBox8i.Size = New System.Drawing.Size(168, 26)
        Me.TextBox8i.TabIndex = 1
        Me.TextBox8i.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbError5
        '
        Me.lbError5.AutoSize = True
        Me.lbError5.Location = New System.Drawing.Point(57, 213)
        Me.lbError5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbError5.Name = "lbError5"
        Me.lbError5.Size = New System.Drawing.Size(24, 16)
        Me.lbError5.TabIndex = 1
        Me.lbError5.Text = "--"
        '
        'lbError8
        '
        Me.lbError8.AutoSize = True
        Me.lbError8.Location = New System.Drawing.Point(57, 213)
        Me.lbError8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbError8.Name = "lbError8"
        Me.lbError8.Size = New System.Drawing.Size(24, 16)
        Me.lbError8.TabIndex = 1
        Me.lbError8.Text = "--"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(79, 285)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(440, 48)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "错误码：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   0 正确  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   1：Fail-发送失败 2：Disconnect-连接断开 3：反馈超时"
        '
        'frmSendA_11
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 354)
        Me.Controls.Add(Me.c)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmSendA_11"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TCP应用测试"
        Me.c.ResumeLayout(False)
        Me.c.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents c As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeOut5 As System.Windows.Forms.TextBox
    Friend WithEvents txtPort5 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnConnect5 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeOut8 As System.Windows.Forms.TextBox
    Friend WithEvents txtPort8 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnConnect8 As System.Windows.Forms.Button
    Friend WithEvents btnDisConnect5 As System.Windows.Forms.Button
    Friend WithEvents btnDisConnect8 As System.Windows.Forms.Button
    Friend WithEvents txtIpR5 As System.Windows.Forms.ComboBox
    Friend WithEvents txtIpR8 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents btnSend5 As System.Windows.Forms.Button
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents btnSend8 As System.Windows.Forms.Button
    Friend WithEvents TextBox5i As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8i As System.Windows.Forms.TextBox
    Friend WithEvents lbError5 As System.Windows.Forms.Label
    Friend WithEvents lbError8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
