<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRobot
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
        Me.btnXA = New System.Windows.Forms.Button()
        Me.btnXD = New System.Windows.Forms.Button()
        Me.btnYA = New System.Windows.Forms.Button()
        Me.btnYD = New System.Windows.Forms.Button()
        Me.btnZA = New System.Windows.Forms.Button()
        Me.btnZD = New System.Windows.Forms.Button()
        Me.btnUD = New System.Windows.Forms.Button()
        Me.btnVA = New System.Windows.Forms.Button()
        Me.btnVD = New System.Windows.Forms.Button()
        Me.btnWA = New System.Windows.Forms.Button()
        Me.btnWD = New System.Windows.Forms.Button()
        Me.labX = New System.Windows.Forms.Label()
        Me.labY = New System.Windows.Forms.Label()
        Me.labZ = New System.Windows.Forms.Label()
        Me.labU = New System.Windows.Forms.Label()
        Me.labV = New System.Windows.Forms.Label()
        Me.labW = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtStep = New System.Windows.Forms.TextBox()
        Me.Rbtn_Ldis = New System.Windows.Forms.RadioButton()
        Me.Rbtn_sdis = New System.Windows.Forms.RadioButton()
        Me.Rbtn_mdis = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtX = New System.Windows.Forms.TextBox()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.btnClawOn = New System.Windows.Forms.Button()
        Me.txtY = New System.Windows.Forms.TextBox()
        Me.txtZ = New System.Windows.Forms.TextBox()
        Me.txtU = New System.Windows.Forms.TextBox()
        Me.txtV = New System.Windows.Forms.TextBox()
        Me.txtW = New System.Windows.Forms.TextBox()
        Me.cb_Mode = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cb_claw = New System.Windows.Forms.ComboBox()
        Me.btnConnection = New System.Windows.Forms.Button()
        Me.txtIpR5 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPort5 = New System.Windows.Forms.TextBox()
        Me.c = New System.Windows.Forms.GroupBox()
        Me.txtTimeOut5 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTimeOut8 = New System.Windows.Forms.TextBox()
        Me.txtPort8 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtIpR8 = New System.Windows.Forms.TextBox()
        Me.btnConnection1 = New System.Windows.Forms.Button()
        Me.ck_Move = New System.Windows.Forms.CheckBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnXYA = New System.Windows.Forms.Button()
        Me.btnYXA = New System.Windows.Forms.Button()
        Me.btnXYD = New System.Windows.Forms.Button()
        Me.btnYXD = New System.Windows.Forms.Button()
        Me.btnUA = New System.Windows.Forms.Button()
        Me.btnClawUp = New System.Windows.Forms.Button()
        Me.btnGetPos = New System.Windows.Forms.Button()
        Me.btnfrmBelt = New System.Windows.Forms.Button()
        Me.btnRbtHoming = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSend = New System.Windows.Forms.TextBox()
        Me.txtRec = New System.Windows.Forms.TextBox()
        Me.btnInitialize = New System.Windows.Forms.Button()
        Me.btnMark = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.ck_safe = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTestInterval = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.c.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnXA
        '
        Me.btnXA.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnXA.ForeColor = System.Drawing.Color.Red
        Me.btnXA.Location = New System.Drawing.Point(73, 152)
        Me.btnXA.Margin = New System.Windows.Forms.Padding(4)
        Me.btnXA.Name = "btnXA"
        Me.btnXA.Size = New System.Drawing.Size(55, 55)
        Me.btnXA.TabIndex = 0
        Me.btnXA.Text = "X+"
        Me.btnXA.UseVisualStyleBackColor = True
        '
        'btnXD
        '
        Me.btnXD.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnXD.ForeColor = System.Drawing.Color.Red
        Me.btnXD.Location = New System.Drawing.Point(73, 26)
        Me.btnXD.Margin = New System.Windows.Forms.Padding(4)
        Me.btnXD.Name = "btnXD"
        Me.btnXD.Size = New System.Drawing.Size(55, 55)
        Me.btnXD.TabIndex = 0
        Me.btnXD.Text = "X-"
        Me.btnXD.UseVisualStyleBackColor = True
        '
        'btnYA
        '
        Me.btnYA.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnYA.ForeColor = System.Drawing.Color.Red
        Me.btnYA.Location = New System.Drawing.Point(136, 89)
        Me.btnYA.Margin = New System.Windows.Forms.Padding(4)
        Me.btnYA.Name = "btnYA"
        Me.btnYA.Size = New System.Drawing.Size(55, 55)
        Me.btnYA.TabIndex = 0
        Me.btnYA.Text = "Y+"
        Me.btnYA.UseVisualStyleBackColor = True
        '
        'btnYD
        '
        Me.btnYD.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnYD.ForeColor = System.Drawing.Color.Red
        Me.btnYD.Location = New System.Drawing.Point(10, 89)
        Me.btnYD.Margin = New System.Windows.Forms.Padding(4)
        Me.btnYD.Name = "btnYD"
        Me.btnYD.Size = New System.Drawing.Size(55, 55)
        Me.btnYD.TabIndex = 0
        Me.btnYD.Text = "Y-"
        Me.btnYD.UseVisualStyleBackColor = True
        '
        'btnZA
        '
        Me.btnZA.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnZA.ForeColor = System.Drawing.Color.Red
        Me.btnZA.Location = New System.Drawing.Point(212, 26)
        Me.btnZA.Margin = New System.Windows.Forms.Padding(4)
        Me.btnZA.Name = "btnZA"
        Me.btnZA.Size = New System.Drawing.Size(55, 55)
        Me.btnZA.TabIndex = 0
        Me.btnZA.Text = "Z+"
        Me.btnZA.UseVisualStyleBackColor = True
        '
        'btnZD
        '
        Me.btnZD.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnZD.ForeColor = System.Drawing.Color.Red
        Me.btnZD.Location = New System.Drawing.Point(212, 152)
        Me.btnZD.Margin = New System.Windows.Forms.Padding(4)
        Me.btnZD.Name = "btnZD"
        Me.btnZD.Size = New System.Drawing.Size(55, 55)
        Me.btnZD.TabIndex = 0
        Me.btnZD.Text = "Z-"
        Me.btnZD.UseVisualStyleBackColor = True
        '
        'btnUD
        '
        Me.btnUD.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnUD.ForeColor = System.Drawing.Color.Red
        Me.btnUD.Location = New System.Drawing.Point(275, 152)
        Me.btnUD.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUD.Name = "btnUD"
        Me.btnUD.Size = New System.Drawing.Size(55, 55)
        Me.btnUD.TabIndex = 0
        Me.btnUD.Text = "U-"
        Me.btnUD.UseVisualStyleBackColor = True
        '
        'btnVA
        '
        Me.btnVA.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnVA.Location = New System.Drawing.Point(338, 26)
        Me.btnVA.Margin = New System.Windows.Forms.Padding(4)
        Me.btnVA.Name = "btnVA"
        Me.btnVA.Size = New System.Drawing.Size(55, 55)
        Me.btnVA.TabIndex = 0
        Me.btnVA.Text = "V+"
        Me.btnVA.UseVisualStyleBackColor = True
        '
        'btnVD
        '
        Me.btnVD.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnVD.Location = New System.Drawing.Point(338, 152)
        Me.btnVD.Margin = New System.Windows.Forms.Padding(4)
        Me.btnVD.Name = "btnVD"
        Me.btnVD.Size = New System.Drawing.Size(55, 55)
        Me.btnVD.TabIndex = 0
        Me.btnVD.Text = "V-"
        Me.btnVD.UseVisualStyleBackColor = True
        '
        'btnWA
        '
        Me.btnWA.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnWA.Location = New System.Drawing.Point(401, 26)
        Me.btnWA.Margin = New System.Windows.Forms.Padding(4)
        Me.btnWA.Name = "btnWA"
        Me.btnWA.Size = New System.Drawing.Size(55, 55)
        Me.btnWA.TabIndex = 0
        Me.btnWA.Text = "W+"
        Me.btnWA.UseVisualStyleBackColor = True
        '
        'btnWD
        '
        Me.btnWD.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnWD.Location = New System.Drawing.Point(401, 152)
        Me.btnWD.Margin = New System.Windows.Forms.Padding(4)
        Me.btnWD.Name = "btnWD"
        Me.btnWD.Size = New System.Drawing.Size(55, 55)
        Me.btnWD.TabIndex = 0
        Me.btnWD.Text = "W-"
        Me.btnWD.UseVisualStyleBackColor = True
        '
        'labX
        '
        Me.labX.AutoSize = True
        Me.labX.Location = New System.Drawing.Point(27, 498)
        Me.labX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labX.Name = "labX"
        Me.labX.Size = New System.Drawing.Size(64, 16)
        Me.labX.TabIndex = 1
        Me.labX.Text = "000.000"
        '
        'labY
        '
        Me.labY.AutoSize = True
        Me.labY.Location = New System.Drawing.Point(126, 498)
        Me.labY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labY.Name = "labY"
        Me.labY.Size = New System.Drawing.Size(64, 16)
        Me.labY.TabIndex = 1
        Me.labY.Text = "000.000"
        '
        'labZ
        '
        Me.labZ.AutoSize = True
        Me.labZ.Location = New System.Drawing.Point(231, 498)
        Me.labZ.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labZ.Name = "labZ"
        Me.labZ.Size = New System.Drawing.Size(64, 16)
        Me.labZ.TabIndex = 1
        Me.labZ.Text = "000.000"
        '
        'labU
        '
        Me.labU.AutoSize = True
        Me.labU.Location = New System.Drawing.Point(330, 498)
        Me.labU.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labU.Name = "labU"
        Me.labU.Size = New System.Drawing.Size(64, 16)
        Me.labU.TabIndex = 1
        Me.labU.Text = "000.000"
        '
        'labV
        '
        Me.labV.AutoSize = True
        Me.labV.Location = New System.Drawing.Point(431, 498)
        Me.labV.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labV.Name = "labV"
        Me.labV.Size = New System.Drawing.Size(64, 16)
        Me.labV.TabIndex = 1
        Me.labV.Text = "000.000"
        '
        'labW
        '
        Me.labW.AutoSize = True
        Me.labW.Location = New System.Drawing.Point(538, 498)
        Me.labW.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labW.Name = "labW"
        Me.labW.Size = New System.Drawing.Size(64, 16)
        Me.labW.TabIndex = 1
        Me.labW.Text = "000.000"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtStep)
        Me.GroupBox1.Controls.Add(Me.Rbtn_Ldis)
        Me.GroupBox1.Controls.Add(Me.Rbtn_sdis)
        Me.GroupBox1.Controls.Add(Me.Rbtn_mdis)
        Me.GroupBox1.Location = New System.Drawing.Point(500, 206)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(130, 230)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "步进距离"
        '
        'txtStep
        '
        Me.txtStep.Location = New System.Drawing.Point(17, 181)
        Me.txtStep.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStep.Name = "txtStep"
        Me.txtStep.Size = New System.Drawing.Size(96, 26)
        Me.txtStep.TabIndex = 1
        Me.txtStep.Text = "0.1"
        Me.txtStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Rbtn_Ldis
        '
        Me.Rbtn_Ldis.AutoSize = True
        Me.Rbtn_Ldis.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Rbtn_Ldis.Location = New System.Drawing.Point(23, 137)
        Me.Rbtn_Ldis.Margin = New System.Windows.Forms.Padding(4)
        Me.Rbtn_Ldis.Name = "Rbtn_Ldis"
        Me.Rbtn_Ldis.Size = New System.Drawing.Size(77, 20)
        Me.Rbtn_Ldis.TabIndex = 0
        Me.Rbtn_Ldis.Text = "长距离"
        Me.Rbtn_Ldis.UseVisualStyleBackColor = True
        '
        'Rbtn_sdis
        '
        Me.Rbtn_sdis.AutoSize = True
        Me.Rbtn_sdis.Checked = True
        Me.Rbtn_sdis.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Rbtn_sdis.Location = New System.Drawing.Point(23, 89)
        Me.Rbtn_sdis.Margin = New System.Windows.Forms.Padding(4)
        Me.Rbtn_sdis.Name = "Rbtn_sdis"
        Me.Rbtn_sdis.Size = New System.Drawing.Size(77, 20)
        Me.Rbtn_sdis.TabIndex = 0
        Me.Rbtn_sdis.TabStop = True
        Me.Rbtn_sdis.Text = "短距离"
        Me.Rbtn_sdis.UseVisualStyleBackColor = True
        '
        'Rbtn_mdis
        '
        Me.Rbtn_mdis.AutoSize = True
        Me.Rbtn_mdis.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Rbtn_mdis.Location = New System.Drawing.Point(23, 43)
        Me.Rbtn_mdis.Margin = New System.Windows.Forms.Padding(4)
        Me.Rbtn_mdis.Name = "Rbtn_mdis"
        Me.Rbtn_mdis.Size = New System.Drawing.Size(77, 20)
        Me.Rbtn_mdis.TabIndex = 0
        Me.Rbtn_mdis.Text = "微距离"
        Me.Rbtn_mdis.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 448)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "X(mm)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(133, 448)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Y(mm)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(231, 448)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Z(mm)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(439, 448)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "V(deg)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(330, 448)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "U(deg)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(546, 448)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 16)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "W(deg)"
        '
        'txtX
        '
        Me.txtX.Location = New System.Drawing.Point(12, 468)
        Me.txtX.Margin = New System.Windows.Forms.Padding(4)
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(79, 26)
        Me.txtX.TabIndex = 1
        Me.txtX.Text = "85.358"
        Me.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMove
        '
        Me.btnMove.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnMove.ForeColor = System.Drawing.Color.Red
        Me.btnMove.Location = New System.Drawing.Point(517, 534)
        Me.btnMove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(96, 32)
        Me.btnMove.TabIndex = 0
        Me.btnMove.Text = "移动"
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'btnClawOn
        '
        Me.btnClawOn.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnClawOn.ForeColor = System.Drawing.Color.Red
        Me.btnClawOn.Location = New System.Drawing.Point(12, 534)
        Me.btnClawOn.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClawOn.Name = "btnClawOn"
        Me.btnClawOn.Size = New System.Drawing.Size(96, 32)
        Me.btnClawOn.TabIndex = 0
        Me.btnClawOn.Text = "夹爪开合"
        Me.btnClawOn.UseVisualStyleBackColor = True
        '
        'txtY
        '
        Me.txtY.Location = New System.Drawing.Point(113, 468)
        Me.txtY.Margin = New System.Windows.Forms.Padding(4)
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(79, 26)
        Me.txtY.TabIndex = 1
        Me.txtY.Text = "289.394"
        Me.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtZ
        '
        Me.txtZ.Location = New System.Drawing.Point(215, 468)
        Me.txtZ.Margin = New System.Windows.Forms.Padding(4)
        Me.txtZ.Name = "txtZ"
        Me.txtZ.Size = New System.Drawing.Size(79, 26)
        Me.txtZ.TabIndex = 1
        Me.txtZ.Text = "0"
        Me.txtZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtU
        '
        Me.txtU.Location = New System.Drawing.Point(318, 468)
        Me.txtU.Margin = New System.Windows.Forms.Padding(4)
        Me.txtU.Name = "txtU"
        Me.txtU.Size = New System.Drawing.Size(79, 26)
        Me.txtU.TabIndex = 1
        Me.txtU.Text = "-74.753"
        Me.txtU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtV
        '
        Me.txtV.Location = New System.Drawing.Point(423, 468)
        Me.txtV.Margin = New System.Windows.Forms.Padding(4)
        Me.txtV.Name = "txtV"
        Me.txtV.Size = New System.Drawing.Size(79, 26)
        Me.txtV.TabIndex = 1
        Me.txtV.Text = "0"
        Me.txtV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtW
        '
        Me.txtW.Location = New System.Drawing.Point(526, 468)
        Me.txtW.Margin = New System.Windows.Forms.Padding(4)
        Me.txtW.Name = "txtW"
        Me.txtW.Size = New System.Drawing.Size(79, 26)
        Me.txtW.TabIndex = 1
        Me.txtW.Text = "0"
        Me.txtW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cb_Mode
        '
        Me.cb_Mode.Enabled = False
        Me.cb_Mode.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cb_Mode.FormattingEnabled = True
        Me.cb_Mode.Items.AddRange(New Object() {"默认", "关节"})
        Me.cb_Mode.Location = New System.Drawing.Point(570, 62)
        Me.cb_Mode.Name = "cb_Mode"
        Me.cb_Mode.Size = New System.Drawing.Size(71, 24)
        Me.cb_Mode.TabIndex = 3
        Me.cb_Mode.Text = "默认"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(596, 56)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(0, 16)
        Me.Label13.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(453, 65)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 16)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "夹爪"
        '
        'cb_claw
        '
        Me.cb_claw.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cb_claw.ForeColor = System.Drawing.Color.Black
        Me.cb_claw.FormattingEnabled = True
        Me.cb_claw.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.cb_claw.Location = New System.Drawing.Point(500, 62)
        Me.cb_claw.Name = "cb_claw"
        Me.cb_claw.Size = New System.Drawing.Size(52, 24)
        Me.cb_claw.TabIndex = 3
        Me.cb_claw.Text = "1"
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
        'txtIpR5
        '
        Me.txtIpR5.Location = New System.Drawing.Point(80, 19)
        Me.txtIpR5.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIpR5.Name = "txtIpR5"
        Me.txtIpR5.Size = New System.Drawing.Size(127, 26)
        Me.txtIpR5.TabIndex = 1
        Me.txtIpR5.Text = "192.168.0.1"
        Me.txtIpR5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 56)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 16)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Port"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 22)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 16)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "IP"
        '
        'txtPort5
        '
        Me.txtPort5.Location = New System.Drawing.Point(80, 53)
        Me.txtPort5.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPort5.Name = "txtPort5"
        Me.txtPort5.Size = New System.Drawing.Size(127, 26)
        Me.txtPort5.TabIndex = 1
        Me.txtPort5.Text = "5000"
        Me.txtPort5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.c.Location = New System.Drawing.Point(12, 46)
        Me.c.Name = "c"
        Me.c.Size = New System.Drawing.Size(214, 154)
        Me.c.TabIndex = 4
        Me.c.TabStop = False
        Me.c.Text = "远程以太网"
        '
        'txtTimeOut5
        '
        Me.txtTimeOut5.Location = New System.Drawing.Point(80, 87)
        Me.txtTimeOut5.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTimeOut5.Name = "txtTimeOut5"
        Me.txtTimeOut5.Size = New System.Drawing.Size(127, 26)
        Me.txtTimeOut5.TabIndex = 1
        Me.txtTimeOut5.Text = "0"
        Me.txtTimeOut5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(7, 90)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 16)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "time out"
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
        Me.GroupBox2.Location = New System.Drawing.Point(232, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(214, 154)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TCP/IP 通讯"
        '
        'txtTimeOut8
        '
        Me.txtTimeOut8.Location = New System.Drawing.Point(78, 87)
        Me.txtTimeOut8.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTimeOut8.Name = "txtTimeOut8"
        Me.txtTimeOut8.Size = New System.Drawing.Size(127, 26)
        Me.txtTimeOut8.TabIndex = 1
        Me.txtTimeOut8.Text = "2000"
        Me.txtTimeOut8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPort8
        '
        Me.txtPort8.Location = New System.Drawing.Point(78, 53)
        Me.txtPort8.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPort8.Name = "txtPort8"
        Me.txtPort8.Size = New System.Drawing.Size(127, 26)
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
        Me.Label17.Size = New System.Drawing.Size(72, 16)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "time out"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 22)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(24, 16)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "IP"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 56)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 16)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Port"
        '
        'txtIpR8
        '
        Me.txtIpR8.Location = New System.Drawing.Point(78, 19)
        Me.txtIpR8.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIpR8.Name = "txtIpR8"
        Me.txtIpR8.Size = New System.Drawing.Size(127, 26)
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
        'ck_Move
        '
        Me.ck_Move.AutoSize = True
        Me.ck_Move.Location = New System.Drawing.Point(275, 107)
        Me.ck_Move.Name = "ck_Move"
        Me.ck_Move.Size = New System.Drawing.Size(91, 20)
        Me.ck_Move.TabIndex = 5
        Me.ck_Move.Text = "连续移动"
        Me.ck_Move.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(20, 35)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(74, 20)
        Me.RadioButton1.TabIndex = 6
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "XYZUVW"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(20, 61)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(162, 20)
        Me.RadioButton2.TabIndex = 6
        Me.RadioButton2.Text = "J1/J2/J3/J4/J5/J6"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Location = New System.Drawing.Point(450, 95)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(191, 103)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "模式"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnVD)
        Me.GroupBox4.Controls.Add(Me.btnXYA)
        Me.GroupBox4.Controls.Add(Me.btnYXA)
        Me.GroupBox4.Controls.Add(Me.btnXA)
        Me.GroupBox4.Controls.Add(Me.ck_Move)
        Me.GroupBox4.Controls.Add(Me.btnXYD)
        Me.GroupBox4.Controls.Add(Me.btnYXD)
        Me.GroupBox4.Controls.Add(Me.btnXD)
        Me.GroupBox4.Controls.Add(Me.btnYA)
        Me.GroupBox4.Controls.Add(Me.btnYD)
        Me.GroupBox4.Controls.Add(Me.btnZA)
        Me.GroupBox4.Controls.Add(Me.btnZD)
        Me.GroupBox4.Controls.Add(Me.btnUA)
        Me.GroupBox4.Controls.Add(Me.btnUD)
        Me.GroupBox4.Controls.Add(Me.btnVA)
        Me.GroupBox4.Controls.Add(Me.btnWA)
        Me.GroupBox4.Controls.Add(Me.btnWD)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 206)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(460, 230)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "点动"
        '
        'btnXYA
        '
        Me.btnXYA.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnXYA.ForeColor = System.Drawing.Color.Red
        Me.btnXYA.Location = New System.Drawing.Point(10, 152)
        Me.btnXYA.Margin = New System.Windows.Forms.Padding(4)
        Me.btnXYA.Name = "btnXYA"
        Me.btnXYA.Size = New System.Drawing.Size(55, 55)
        Me.btnXYA.TabIndex = 0
        Me.btnXYA.Text = "X+Y-"
        Me.btnXYA.UseVisualStyleBackColor = True
        '
        'btnYXA
        '
        Me.btnYXA.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnYXA.ForeColor = System.Drawing.Color.Red
        Me.btnYXA.Location = New System.Drawing.Point(136, 152)
        Me.btnYXA.Margin = New System.Windows.Forms.Padding(4)
        Me.btnYXA.Name = "btnYXA"
        Me.btnYXA.Size = New System.Drawing.Size(55, 55)
        Me.btnYXA.TabIndex = 0
        Me.btnYXA.Text = "X+Y+"
        Me.btnYXA.UseVisualStyleBackColor = True
        '
        'btnXYD
        '
        Me.btnXYD.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnXYD.ForeColor = System.Drawing.Color.Red
        Me.btnXYD.Location = New System.Drawing.Point(10, 26)
        Me.btnXYD.Margin = New System.Windows.Forms.Padding(4)
        Me.btnXYD.Name = "btnXYD"
        Me.btnXYD.Size = New System.Drawing.Size(55, 55)
        Me.btnXYD.TabIndex = 0
        Me.btnXYD.Text = "X-Y-"
        Me.btnXYD.UseVisualStyleBackColor = True
        '
        'btnYXD
        '
        Me.btnYXD.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnYXD.ForeColor = System.Drawing.Color.Red
        Me.btnYXD.Location = New System.Drawing.Point(136, 26)
        Me.btnYXD.Margin = New System.Windows.Forms.Padding(4)
        Me.btnYXD.Name = "btnYXD"
        Me.btnYXD.Size = New System.Drawing.Size(55, 55)
        Me.btnYXD.TabIndex = 0
        Me.btnYXD.Text = "X-Y+"
        Me.btnYXD.UseVisualStyleBackColor = True
        '
        'btnUA
        '
        Me.btnUA.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnUA.ForeColor = System.Drawing.Color.Red
        Me.btnUA.Location = New System.Drawing.Point(275, 26)
        Me.btnUA.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUA.Name = "btnUA"
        Me.btnUA.Size = New System.Drawing.Size(55, 55)
        Me.btnUA.TabIndex = 0
        Me.btnUA.Text = "U+"
        Me.btnUA.UseVisualStyleBackColor = True
        '
        'btnClawUp
        '
        Me.btnClawUp.Enabled = False
        Me.btnClawUp.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnClawUp.Location = New System.Drawing.Point(113, 534)
        Me.btnClawUp.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClawUp.Name = "btnClawUp"
        Me.btnClawUp.Size = New System.Drawing.Size(96, 32)
        Me.btnClawUp.TabIndex = 0
        Me.btnClawUp.Text = "夹爪升降"
        Me.btnClawUp.UseVisualStyleBackColor = True
        '
        'btnGetPos
        '
        Me.btnGetPos.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnGetPos.ForeColor = System.Drawing.Color.Red
        Me.btnGetPos.Location = New System.Drawing.Point(413, 534)
        Me.btnGetPos.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGetPos.Name = "btnGetPos"
        Me.btnGetPos.Size = New System.Drawing.Size(96, 32)
        Me.btnGetPos.TabIndex = 0
        Me.btnGetPos.Text = "取坐标"
        Me.btnGetPos.UseVisualStyleBackColor = True
        '
        'btnfrmBelt
        '
        Me.btnfrmBelt.Location = New System.Drawing.Point(688, 5)
        Me.btnfrmBelt.Name = "btnfrmBelt"
        Me.btnfrmBelt.Size = New System.Drawing.Size(134, 30)
        Me.btnfrmBelt.TabIndex = 9
        Me.btnfrmBelt.Text = "皮带测试窗口"
        Me.btnfrmBelt.UseVisualStyleBackColor = True
        '
        'btnRbtHoming
        '
        Me.btnRbtHoming.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnRbtHoming.ForeColor = System.Drawing.Color.Red
        Me.btnRbtHoming.Location = New System.Drawing.Point(309, 534)
        Me.btnRbtHoming.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRbtHoming.Name = "btnRbtHoming"
        Me.btnRbtHoming.Size = New System.Drawing.Size(96, 32)
        Me.btnRbtHoming.TabIndex = 0
        Me.btnRbtHoming.Text = "复位"
        Me.btnRbtHoming.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(91, 473)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 10
        Me.CheckBox1.Tag = "X"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(193, 473)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox2.TabIndex = 11
        Me.CheckBox2.Tag = "Y"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(296, 473)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox3.TabIndex = 12
        Me.CheckBox3.Tag = "Z"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(401, 473)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox4.TabIndex = 13
        Me.CheckBox4.Tag = "U"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(504, 473)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox5.TabIndex = 14
        Me.CheckBox5.Tag = "V"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(612, 473)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox6.TabIndex = 15
        Me.CheckBox6.Tag = "W"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(663, 62)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "发"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(645, 397)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "收"
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(648, 82)
        Me.txtSend.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSend.Multiline = True
        Me.txtSend.Name = "txtSend"
        Me.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSend.Size = New System.Drawing.Size(173, 311)
        Me.txtSend.TabIndex = 1
        '
        'txtRec
        '
        Me.txtRec.Location = New System.Drawing.Point(648, 417)
        Me.txtRec.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRec.Multiline = True
        Me.txtRec.Name = "txtRec"
        Me.txtRec.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRec.Size = New System.Drawing.Size(173, 288)
        Me.txtRec.TabIndex = 1
        '
        'btnInitialize
        '
        Me.btnInitialize.Location = New System.Drawing.Point(112, 6)
        Me.btnInitialize.Name = "btnInitialize"
        Me.btnInitialize.Size = New System.Drawing.Size(106, 30)
        Me.btnInitialize.TabIndex = 16
        Me.btnInitialize.Text = "启动Robot"
        Me.btnInitialize.UseVisualStyleBackColor = True
        '
        'btnMark
        '
        Me.btnMark.Location = New System.Drawing.Point(289, 19)
        Me.btnMark.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMark.Name = "btnMark"
        Me.btnMark.Size = New System.Drawing.Size(101, 35)
        Me.btnMark.TabIndex = 17
        Me.btnMark.Text = "计算Mark点"
        Me.btnMark.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(396, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 35)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "测试视觉"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(324, 6)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 30)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "单插件"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(218, 6)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(106, 30)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "多插件"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(430, 6)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(4)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(106, 30)
        Me.btnStop.TabIndex = 17
        Me.btnStop.Text = "停止"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'ck_safe
        '
        Me.ck_safe.AutoSize = True
        Me.ck_safe.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ck_safe.Location = New System.Drawing.Point(21, 89)
        Me.ck_safe.Name = "ck_safe"
        Me.ck_safe.Size = New System.Drawing.Size(107, 20)
        Me.ck_safe.TabIndex = 19
        Me.ck_safe.Text = "屏蔽安全门"
        Me.ck_safe.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.TextBox1)
        Me.GroupBox5.Controls.Add(Me.txtTestInterval)
        Me.GroupBox5.Controls.Add(Me.btnMark)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.ck_safe)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 573)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(620, 136)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "插件"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "测试间隔"
        '
        'txtTestInterval
        '
        Me.txtTestInterval.Location = New System.Drawing.Point(115, 57)
        Me.txtTestInterval.Name = "txtTestInterval"
        Me.txtTestInterval.Size = New System.Drawing.Size(91, 26)
        Me.txtTestInterval.TabIndex = 20
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(6, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(106, 30)
        Me.Button4.TabIndex = 21
        Me.Button4.Text = "开启测试"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(115, 25)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(91, 26)
        Me.TextBox1.TabIndex = 20
        Me.TextBox1.Text = "1000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "计划产量"
        '
        'frmRobot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 721)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnInitialize)
        Me.Controls.Add(Me.CheckBox6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox5)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.btnfrmBelt)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.c)
        Me.Controls.Add(Me.cb_claw)
        Me.Controls.Add(Me.cb_Mode)
        Me.Controls.Add(Me.txtRec)
        Me.Controls.Add(Me.txtSend)
        Me.Controls.Add(Me.txtW)
        Me.Controls.Add(Me.txtV)
        Me.Controls.Add(Me.txtU)
        Me.Controls.Add(Me.txtZ)
        Me.Controls.Add(Me.labY)
        Me.Controls.Add(Me.labZ)
        Me.Controls.Add(Me.labX)
        Me.Controls.Add(Me.txtY)
        Me.Controls.Add(Me.labV)
        Me.Controls.Add(Me.labW)
        Me.Controls.Add(Me.txtX)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.labU)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnRbtHoming)
        Me.Controls.Add(Me.btnClawUp)
        Me.Controls.Add(Me.btnClawOn)
        Me.Controls.Add(Me.btnGetPos)
        Me.Controls.Add(Me.btnMove)
        Me.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRobot"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "原型 0424"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.c.ResumeLayout(False)
        Me.c.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnXA As System.Windows.Forms.Button
    Friend WithEvents btnXD As System.Windows.Forms.Button
    Friend WithEvents btnYA As System.Windows.Forms.Button
    Friend WithEvents btnYD As System.Windows.Forms.Button
    Friend WithEvents btnZA As System.Windows.Forms.Button
    Friend WithEvents btnZD As System.Windows.Forms.Button
    Friend WithEvents btnUA As System.Windows.Forms.Button
    Friend WithEvents btnUD As System.Windows.Forms.Button
    Friend WithEvents btnVA As System.Windows.Forms.Button
    Friend WithEvents btnVD As System.Windows.Forms.Button
    Friend WithEvents btnWA As System.Windows.Forms.Button
    Friend WithEvents btnWD As System.Windows.Forms.Button
    Friend WithEvents labX As System.Windows.Forms.Label
    Friend WithEvents labY As System.Windows.Forms.Label
    Friend WithEvents labZ As System.Windows.Forms.Label
    Friend WithEvents labU As System.Windows.Forms.Label
    Friend WithEvents labV As System.Windows.Forms.Label
    Friend WithEvents labW As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStep As System.Windows.Forms.TextBox
    Friend WithEvents Rbtn_Ldis As System.Windows.Forms.RadioButton
    Friend WithEvents Rbtn_sdis As System.Windows.Forms.RadioButton
    Friend WithEvents Rbtn_mdis As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtX As System.Windows.Forms.TextBox
    Friend WithEvents btnMove As System.Windows.Forms.Button
    Friend WithEvents btnClawOn As System.Windows.Forms.Button
    Friend WithEvents txtY As System.Windows.Forms.TextBox
    Friend WithEvents txtZ As System.Windows.Forms.TextBox
    Friend WithEvents txtU As System.Windows.Forms.TextBox
    Friend WithEvents txtV As System.Windows.Forms.TextBox
    Friend WithEvents txtW As System.Windows.Forms.TextBox
    Friend WithEvents cb_Mode As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cb_claw As System.Windows.Forms.ComboBox
    Friend WithEvents btnConnection As System.Windows.Forms.Button
    Friend WithEvents txtIpR5 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPort5 As System.Windows.Forms.TextBox
    Friend WithEvents c As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeOut5 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTimeOut8 As System.Windows.Forms.TextBox
    Friend WithEvents txtPort8 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtIpR8 As System.Windows.Forms.TextBox
    Friend WithEvents btnConnection1 As System.Windows.Forms.Button
    Friend WithEvents ck_Move As System.Windows.Forms.CheckBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnYXA As System.Windows.Forms.Button
    Friend WithEvents btnYXD As System.Windows.Forms.Button
    Friend WithEvents btnClawUp As System.Windows.Forms.Button
    Friend WithEvents btnGetPos As System.Windows.Forms.Button
    Friend WithEvents btnfrmBelt As System.Windows.Forms.Button
    Friend WithEvents btnRbtHoming As System.Windows.Forms.Button
    Friend WithEvents btnXYA As System.Windows.Forms.Button
    Friend WithEvents btnXYD As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSend As System.Windows.Forms.TextBox
    Friend WithEvents txtRec As System.Windows.Forms.TextBox
    Friend WithEvents btnInitialize As System.Windows.Forms.Button
    Friend WithEvents btnMark As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents ck_safe As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTestInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
