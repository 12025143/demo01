<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlug
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTimeOut8 = New System.Windows.Forms.TextBox()
        Me.txtPort8 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnConnection1 = New System.Windows.Forms.Button()
        Me.c = New System.Windows.Forms.GroupBox()
        Me.txtTimeOut5 = New System.Windows.Forms.TextBox()
        Me.txtPort5 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRec = New System.Windows.Forms.TextBox()
        Me.txtSend = New System.Windows.Forms.TextBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnRbtHoming = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnInitialize = New System.Windows.Forms.Button()
        Me.btnIni = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPro = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtIpR5 = New System.Windows.Forms.ComboBox()
        Me.txtIpR8 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        Me.c.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtIpR8)
        Me.GroupBox2.Controls.Add(Me.txtTimeOut8)
        Me.GroupBox2.Controls.Add(Me.txtPort8)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.btnConnection1)
        Me.GroupBox2.Location = New System.Drawing.Point(309, 16)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(285, 160)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TCP/IP 通讯"
        '
        'txtTimeOut8
        '
        Me.txtTimeOut8.Location = New System.Drawing.Point(82, 80)
        Me.txtTimeOut8.Margin = New System.Windows.Forms.Padding(5)
        Me.txtTimeOut8.Name = "txtTimeOut8"
        Me.txtTimeOut8.Size = New System.Drawing.Size(168, 26)
        Me.txtTimeOut8.TabIndex = 1
        Me.txtTimeOut8.Text = "2000"
        Me.txtTimeOut8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPort8
        '
        Me.txtPort8.Location = New System.Drawing.Point(82, 52)
        Me.txtPort8.Margin = New System.Windows.Forms.Padding(5)
        Me.txtPort8.Name = "txtPort8"
        Me.txtPort8.Size = New System.Drawing.Size(168, 26)
        Me.txtPort8.TabIndex = 1
        Me.txtPort8.Text = "8000"
        Me.txtPort8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 84)
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
        Me.Label20.Location = New System.Drawing.Point(9, 56)
        Me.Label20.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 16)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Port"
        '
        'btnConnection1
        '
        Me.btnConnection1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnConnection1.Location = New System.Drawing.Point(82, 108)
        Me.btnConnection1.Margin = New System.Windows.Forms.Padding(5)
        Me.btnConnection1.Name = "btnConnection1"
        Me.btnConnection1.Size = New System.Drawing.Size(169, 35)
        Me.btnConnection1.TabIndex = 0
        Me.btnConnection1.Text = "连接"
        Me.btnConnection1.UseVisualStyleBackColor = True
        '
        'c
        '
        Me.c.Controls.Add(Me.txtIpR5)
        Me.c.Controls.Add(Me.txtTimeOut5)
        Me.c.Controls.Add(Me.txtPort5)
        Me.c.Controls.Add(Me.Label19)
        Me.c.Controls.Add(Me.Label15)
        Me.c.Controls.Add(Me.Label16)
        Me.c.Controls.Add(Me.btnConnection)
        Me.c.Location = New System.Drawing.Point(16, 16)
        Me.c.Margin = New System.Windows.Forms.Padding(4)
        Me.c.Name = "c"
        Me.c.Padding = New System.Windows.Forms.Padding(4)
        Me.c.Size = New System.Drawing.Size(285, 160)
        Me.c.TabIndex = 5
        Me.c.TabStop = False
        Me.c.Text = "远程以太网"
        '
        'txtTimeOut5
        '
        Me.txtTimeOut5.Location = New System.Drawing.Point(89, 81)
        Me.txtTimeOut5.Margin = New System.Windows.Forms.Padding(5)
        Me.txtTimeOut5.Name = "txtTimeOut5"
        Me.txtTimeOut5.Size = New System.Drawing.Size(168, 26)
        Me.txtTimeOut5.TabIndex = 1
        Me.txtTimeOut5.Text = "0"
        Me.txtTimeOut5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPort5
        '
        Me.txtPort5.Location = New System.Drawing.Point(89, 53)
        Me.txtPort5.Margin = New System.Windows.Forms.Padding(5)
        Me.txtPort5.Name = "txtPort5"
        Me.txtPort5.Size = New System.Drawing.Size(168, 26)
        Me.txtPort5.TabIndex = 1
        Me.txtPort5.Text = "5000"
        Me.txtPort5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 90)
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
        Me.Label16.Location = New System.Drawing.Point(9, 63)
        Me.Label16.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 16)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Port"
        '
        'btnConnection
        '
        Me.btnConnection.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnConnection.Location = New System.Drawing.Point(88, 109)
        Me.btnConnection.Margin = New System.Windows.Forms.Padding(5)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(169, 35)
        Me.btnConnection.TabIndex = 0
        Me.btnConnection.Text = "连接"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(319, 318)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "收"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 318)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "发"
        '
        'txtRec
        '
        Me.txtRec.Location = New System.Drawing.Point(322, 339)
        Me.txtRec.Margin = New System.Windows.Forms.Padding(5)
        Me.txtRec.Multiline = True
        Me.txtRec.Name = "txtRec"
        Me.txtRec.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRec.Size = New System.Drawing.Size(289, 269)
        Me.txtRec.TabIndex = 7
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(17, 339)
        Me.txtSend.Margin = New System.Windows.Forms.Padding(5)
        Me.txtSend.Multiline = True
        Me.txtSend.Name = "txtSend"
        Me.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSend.Size = New System.Drawing.Size(284, 269)
        Me.txtSend.TabIndex = 8
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(319, 273)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(5)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(141, 40)
        Me.btnStop.TabIndex = 21
        Me.btnStop.Text = "停止"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnRbtHoming
        '
        Me.btnRbtHoming.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnRbtHoming.ForeColor = System.Drawing.Color.Red
        Me.btnRbtHoming.Location = New System.Drawing.Point(470, 273)
        Me.btnRbtHoming.Margin = New System.Windows.Forms.Padding(5)
        Me.btnRbtHoming.Name = "btnRbtHoming"
        Me.btnRbtHoming.Size = New System.Drawing.Size(141, 40)
        Me.btnRbtHoming.TabIndex = 18
        Me.btnRbtHoming.Text = "复位"
        Me.btnRbtHoming.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(168, 273)
        Me.Button1.Margin = New System.Windows.Forms.Padding(5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(141, 40)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "单插件"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(19, 273)
        Me.Button3.Margin = New System.Windows.Forms.Padding(5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(141, 40)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "多插件"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(19, 224)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(141, 40)
        Me.Button4.TabIndex = 23
        Me.Button4.Text = "开启测试"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btnInitialize
        '
        Me.btnInitialize.Location = New System.Drawing.Point(168, 224)
        Me.btnInitialize.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInitialize.Name = "btnInitialize"
        Me.btnInitialize.Size = New System.Drawing.Size(141, 40)
        Me.btnInitialize.TabIndex = 22
        Me.btnInitialize.Text = "启动Robot"
        Me.btnInitialize.UseVisualStyleBackColor = True
        '
        'btnIni
        '
        Me.btnIni.Location = New System.Drawing.Point(321, 224)
        Me.btnIni.Margin = New System.Windows.Forms.Padding(4)
        Me.btnIni.Name = "btnIni"
        Me.btnIni.Size = New System.Drawing.Size(141, 40)
        Me.btnIni.TabIndex = 23
        Me.btnIni.Text = "写入机械手数据"
        Me.btnIni.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "产品编号"
        '
        'txtPro
        '
        Me.txtPro.Location = New System.Drawing.Point(122, 183)
        Me.txtPro.Name = "txtPro"
        Me.txtPro.Size = New System.Drawing.Size(100, 26)
        Me.txtPro.TabIndex = 25
        Me.txtPro.Text = "GRJW842-A43"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(602, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(33, 30)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "11"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtIpR5
        '
        Me.txtIpR5.FormattingEnabled = True
        Me.txtIpR5.Items.AddRange(New Object() {"192.168.56.1", "192.168.0.1"})
        Me.txtIpR5.Location = New System.Drawing.Point(89, 25)
        Me.txtIpR5.Name = "txtIpR5"
        Me.txtIpR5.Size = New System.Drawing.Size(168, 24)
        Me.txtIpR5.TabIndex = 27
        Me.txtIpR5.Text = "192.168.56.1"
        '
        'txtIpR8
        '
        Me.txtIpR8.FormattingEnabled = True
        Me.txtIpR8.Items.AddRange(New Object() {"192.168.56.1", "192.168.0.1"})
        Me.txtIpR8.Location = New System.Drawing.Point(82, 25)
        Me.txtIpR8.Name = "txtIpR8"
        Me.txtIpR8.Size = New System.Drawing.Size(168, 24)
        Me.txtIpR8.TabIndex = 27
        Me.txtIpR8.Text = "192.168.56.1"
        '
        'frmPlug
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(637, 620)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtPro)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnIni)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.btnInitialize)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnRbtHoming)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRec)
        Me.Controls.Add(Me.txtSend)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.c)
        Me.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlug"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPlug"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.c.ResumeLayout(False)
        Me.c.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeOut8 As System.Windows.Forms.TextBox
    Friend WithEvents txtPort8 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnConnection1 As System.Windows.Forms.Button
    Friend WithEvents c As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeOut5 As System.Windows.Forms.TextBox
    Friend WithEvents txtPort5 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRec As System.Windows.Forms.TextBox
    Friend WithEvents txtSend As System.Windows.Forms.TextBox
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnRbtHoming As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btnInitialize As System.Windows.Forms.Button
    Friend WithEvents btnIni As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPro As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtIpR8 As System.Windows.Forms.ComboBox
    Friend WithEvents txtIpR5 As System.Windows.Forms.ComboBox
End Class
