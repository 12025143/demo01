<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPro
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtGLReady = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTimeOut8 = New System.Windows.Forms.TextBox()
        Me.txtPort8 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtIpR8 = New System.Windows.Forms.TextBox()
        Me.btnConnection1 = New System.Windows.Forms.Button()
        Me.c = New System.Windows.Forms.GroupBox()
        Me.txtTimeOut5 = New System.Windows.Forms.TextBox()
        Me.txtPort5 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtIpR5 = New System.Windows.Forms.TextBox()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.c.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(46, 92)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 45)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "插件"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtGLReady
        '
        Me.txtGLReady.AutoSize = True
        Me.txtGLReady.Checked = True
        Me.txtGLReady.CheckState = System.Windows.Forms.CheckState.Checked
        Me.txtGLReady.Location = New System.Drawing.Point(46, 40)
        Me.txtGLReady.Name = "txtGLReady"
        Me.txtGLReady.Size = New System.Drawing.Size(66, 16)
        Me.txtGLReady.TabIndex = 1
        Me.txtGLReady.Text = "GLReady"
        Me.txtGLReady.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTimeOut8)
        Me.GroupBox2.Controls.Add(Me.txtPort8)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtIpR8)
        Me.GroupBox2.Controls.Add(Me.btnConnection1)
        Me.GroupBox2.Location = New System.Drawing.Point(442, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(214, 154)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TCP/IP 通讯"
        '
        'txtTimeOut8
        '
        Me.txtTimeOut8.Location = New System.Drawing.Point(78, 84)
        Me.txtTimeOut8.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTimeOut8.Name = "txtTimeOut8"
        Me.txtTimeOut8.Size = New System.Drawing.Size(127, 21)
        Me.txtTimeOut8.TabIndex = 1
        Me.txtTimeOut8.Text = "2000"
        Me.txtTimeOut8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPort8
        '
        Me.txtPort8.Location = New System.Drawing.Point(78, 53)
        Me.txtPort8.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPort8.Name = "txtPort8"
        Me.txtPort8.Size = New System.Drawing.Size(127, 21)
        Me.txtPort8.TabIndex = 1
        Me.txtPort8.Text = "8000"
        Me.txtPort8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 90)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 12)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "time out"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 22)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(17, 12)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "IP"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 56)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(29, 12)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Port"
        '
        'txtIpR8
        '
        Me.txtIpR8.Location = New System.Drawing.Point(78, 19)
        Me.txtIpR8.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIpR8.Name = "txtIpR8"
        Me.txtIpR8.Size = New System.Drawing.Size(127, 21)
        Me.txtIpR8.TabIndex = 1
        Me.txtIpR8.Text = "192.168.0.1"
        Me.txtIpR8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnConnection1
        '
        Me.btnConnection1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnConnection1.Location = New System.Drawing.Point(78, 121)
        Me.btnConnection1.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConnection1.Name = "btnConnection1"
        Me.btnConnection1.Size = New System.Drawing.Size(127, 26)
        Me.btnConnection1.TabIndex = 0
        Me.btnConnection1.Text = "连接"
        Me.btnConnection1.UseVisualStyleBackColor = True
        '
        'c
        '
        Me.c.Controls.Add(Me.txtTimeOut5)
        Me.c.Controls.Add(Me.txtPort5)
        Me.c.Controls.Add(Me.Label19)
        Me.c.Controls.Add(Me.Label15)
        Me.c.Controls.Add(Me.Label16)
        Me.c.Controls.Add(Me.txtIpR5)
        Me.c.Controls.Add(Me.btnConnection)
        Me.c.Location = New System.Drawing.Point(212, 15)
        Me.c.Name = "c"
        Me.c.Size = New System.Drawing.Size(214, 157)
        Me.c.TabIndex = 6
        Me.c.TabStop = False
        Me.c.Text = "远程以太网"
        '
        'txtTimeOut5
        '
        Me.txtTimeOut5.Location = New System.Drawing.Point(80, 87)
        Me.txtTimeOut5.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTimeOut5.Name = "txtTimeOut5"
        Me.txtTimeOut5.Size = New System.Drawing.Size(127, 21)
        Me.txtTimeOut5.TabIndex = 1
        Me.txtTimeOut5.Text = "0"
        Me.txtTimeOut5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPort5
        '
        Me.txtPort5.Location = New System.Drawing.Point(80, 53)
        Me.txtPort5.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPort5.Name = "txtPort5"
        Me.txtPort5.Size = New System.Drawing.Size(127, 21)
        Me.txtPort5.TabIndex = 1
        Me.txtPort5.Text = "5000"
        Me.txtPort5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(7, 90)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 12)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "time out"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 22)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(17, 12)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "IP"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 56)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 12)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Port"
        '
        'txtIpR5
        '
        Me.txtIpR5.Location = New System.Drawing.Point(80, 19)
        Me.txtIpR5.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIpR5.Name = "txtIpR5"
        Me.txtIpR5.Size = New System.Drawing.Size(127, 21)
        Me.txtIpR5.TabIndex = 1
        Me.txtIpR5.Text = "192.168.0.1"
        Me.txtIpR5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnConnection
        '
        Me.btnConnection.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnConnection.Location = New System.Drawing.Point(80, 121)
        Me.btnConnection.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConnection.Name = "btnConnection"
        Me.btnConnection.Size = New System.Drawing.Size(127, 26)
        Me.btnConnection.TabIndex = 0
        Me.btnConnection.Text = "连接"
        Me.btnConnection.UseVisualStyleBackColor = True
        '
        'frmPro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 200)
        Me.Controls.Add(Me.c)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtGLReady)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmPro"
        Me.Text = "frmPro"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.c.ResumeLayout(False)
        Me.c.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtGLReady As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeOut8 As System.Windows.Forms.TextBox
    Friend WithEvents txtPort8 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtIpR8 As System.Windows.Forms.TextBox
    Friend WithEvents btnConnection1 As System.Windows.Forms.Button
    Friend WithEvents c As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeOut5 As System.Windows.Forms.TextBox
    Friend WithEvents txtPort5 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtIpR5 As System.Windows.Forms.TextBox
    Friend WithEvents btnConnection As System.Windows.Forms.Button
End Class
