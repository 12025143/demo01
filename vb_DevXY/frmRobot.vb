Imports System.Math
Imports FACC
Imports System.Threading
Imports FACC.Memo
Imports FACC.iceService

Public Class frmRobot
    Dim _modeA As Integer
    Dim _claw_no As Integer
    Dim _ret As String
    Dim di_ret As Integer
    Dim _handIOStatus As Boolean '控制夹子io状态标志    Dim recievedata As String

    Dim strSend As String = ""


    Dim strP As String


    Dim _tcp5 As New clsTcp
    Dim _tcp8 As New clsTcp

    Dim file As New clsFile
    Dim _enP As New clsPoint
    Dim dao_Epson As New clsEpsonCom



    Dim _index As Integer = 1 '记录序号
    Dim strOsend As String = ""  '发送的上一条指令
    Dim strORec As String = ""   '接收的上一条指令 

    Dim Robot_UP_Had_String As New List(Of Integer) ''记录夹子上有产品的编号
  

    Dim thr_Act As Threading.Thread
    Dim strVision As String = ""
    Dim thr_M As Threading.Thread
    Dim act As RobotAction




    Private Sub frmRobot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dofrm_Load()

        'btnInitialize_Click(sender, e)
        thr_Act = New Threading.Thread(AddressOf robot_1_actionsub)

        Card7230 = Register_Card(PCI_7230, 0)
        _tcp5.doConnectionR5(txtIpR5.Text, txtPort5.Text)

        act = New RobotAction(_tcp5, _tcp8)
        thr_M = New Threading.Thread(AddressOf act.robot_3_actionsub)

        m_da = New clsMemoRcv()
        AddHandler m_da.DataReceived, New clsMemoRcv.delDataReceived(AddressOf evt_R_DataReceived)

    End Sub
    Private Sub Rbtn_mdis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbtn_mdis.CheckedChanged
        txtStep.Text = "0.1"
    End Sub

    Private Sub Rbtn_sdis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbtn_sdis.CheckedChanged
        txtStep.Text = "1"
    End Sub

    Private Sub Rbtn_Ldis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbtn_Ldis.CheckedChanged
        txtStep.Text = "10"
    End Sub

    Private Sub cb_claw_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_claw.SelectedIndexChanged
        _claw_no = cb_claw.SelectedIndex + 1
    End Sub


    '一
    '1 命令指令/2 命令字/3 夹爪号/4 方向/5 速度            XA  XR  XY
    '  J         XA/R     claw     -/+    vel   F8
    Private Sub btnXA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZD.Click, btnZA.Click, btnYD.Click, btnYA.Click, btnXD.Click, btnXA.Click, btnWD.Click, btnWA.Click, btnVD.Click, btnVA.Click, btnUD.Click, btnUA.Click
        If ck_Move.Checked = False Then
            '发送：J XA 1 +1
            '接收：
            MoveF8_J(sender.text.ToString.Substring(0, sender.text.Length - 1), sender.text.ToString.Substring(sender.text.Length - 1, 1), txtStep.Text)

        End If
    End Sub
    '  J          XY      claw     -/+    vel   F8
    Private Sub btnYXA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYXA.Click

        strSend = "J XY" & " " & _claw_no.ToString & " " & txtStep.Text & " " & txtStep.Text
        _ret = _tcp8.SendF8(strSend)
        do_Show(strSend, _ret)
    End Sub


    Private Sub btnYXD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYXD.Click

        strSend = "J XY" & " " & _claw_no.ToString & " -" & txtStep.Text & " " & txtStep.Text
        _ret = _tcp8.SendF8(strSend)
        do_Show(strSend, _ret)
    End Sub



    Private Sub do_Show(ByVal strData As String, ByVal rec As String)
        'Dim lstSend As New List(Of String)  '要发送的指令

        'lstSend.Add(_index.ToString + "." + strData + Space(10) + rec + Space(10))

        If strData <> strOsend Then
            Me.txtSend.AppendText(_index.ToString + "." + strData + vbCrLf)
        End If
        strOsend = strData
        _index += 1

        If rec <> strORec Then
            Me.txtRec.AppendText(_index.ToString + "." + rec + vbCrLf)
        End If
        strORec = rec
        _index += 1
        F_Log.Debug_1("Send", _index.ToString + "." + strData + Space(10) + rec + Space(10))
        'file.SaveTxt(strP, lstSend) 

    End Sub

    Private Sub btnXYA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXYA.Click
        strSend = "J XY" & " " & _claw_no.ToString & " " & txtStep.Text & " -" & txtStep.Text
        _ret = _tcp8.SendF8(strSend)
        do_Show(strSend, _ret)
    End Sub
    Private Sub btnXYD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXYD.Click

        strSend = "J XY" & " " & _claw_no.ToString & " -" & txtStep.Text & " -" & txtStep.Text
        _ret = _tcp8.SendF8(strSend)
        do_Show(strSend, _ret)

    End Sub
    Private Sub btnXA_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZD.MouseDown, btnZA.MouseDown, btnYD.MouseDown, btnYA.MouseDown, btnXD.MouseDown, btnXA.MouseDown, btnWD.MouseDown, btnWA.MouseDown, btnVD.MouseDown, btnVA.MouseDown, btnUD.MouseDown, btnUA.MouseDown
        If ck_Move.Checked Then
            '发送：J XA 1 +1000
            '接收：
            MoveF8_J(sender.text.ToString.Substring(0, sender.text.ToString.Length - 1), sender.text.ToString.Substring(sender.text.ToString.Length - 1, 1), 1000)
        End If
    End Sub

    Private Sub MoveF8_J(ByVal ord As String, ByVal dir As String, ByVal vel As Integer)
        If _modeA = 0 Then
            strSend = "J " & ord & "A " & _claw_no.ToString & " " & dir & vel
        Else
            strSend = "J " & ord & "R " & _claw_no.ToString & " " & dir & vel
        End If
        _ret = _tcp8.SendF8(strSend)
        do_Show(strSend, _ret)
    End Sub

    '二 夹爪开合
    '1 命令指令/2 命令字/3 夹爪号/4 方向/5 速度
    '  Z          -       1        1/0                F8
    Private Sub btnClawOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClawOn.Click
        _handIOStatus = Not _handIOStatus
        If _handIOStatus = True Then
            '发送：Z 1 1
            '接收：
            strSend = "Z " & _claw_no + 10 & " " & 1
        Else
            '发送：Z 1 0
            '接收：
            strSend = "Z " & _claw_no + 10 & " " & 0
        End If
        _ret = _tcp8.SendF8(strSend)
        do_Show(strSend, _ret)
    End Sub
    '  Z  夹爪升降
    Private Sub btnClawUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClawUp.Click
        _handIOStatus = Not _handIOStatus
        If _handIOStatus = True Then
            strSend = "Z " & _claw_no & " " & 1
        Else
            strSend = "Z " & _claw_no & " " & 0
        End If
        _ret = _tcp8.SendF8(strSend)
        do_Show(strSend, _ret)
    End Sub

    '三 移动
    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click

        Dim dis_point(5) As Double
        Dim i As Integer = -1
        i += 1 : dis_point(i) = Val(txtX.Text)
        i += 1 : dis_point(i) = Val(txtY.Text)
        i += 1 : dis_point(i) = Val(txtZ.Text)
        i += 1 : dis_point(i) = Val(txtU.Text)
        i += 1 : dis_point(i) = Val(txtV.Text)
        i += 1 : dis_point(i) = Val(txtW.Text)

        Move_Btn_ClickF8(dis_point, _claw_no)
    End Sub
    ' J Point ...(15)  F8
    Private Function Move_Btn_ClickF8(ByVal Distance() As Double, Optional ByVal Move_tool As Integer = 0, Optional ByVal J4Val As Integer = 0, Optional ByVal J6Val As Integer = 0, Optional ByVal J1Val As Integer = 0, Optional ByVal J2Val As Integer = 0, Optional ByVal Hand As Integer = 1) As String
        If Not (Distance(0) = 0 And Distance(1) = 0 And Distance(2) = 0) Then

            strSend = "J Point " & _
                        Move_tool.ToString & " " & _
                        Distance(0).ToString & " " & Distance(1).ToString & " " & Distance(2).ToString & " " & _
                        Distance(3).ToString & " " & Distance(4).ToString & " " & Distance(5).ToString & " " & _
                        J1Val.ToString & " " & J2Val.ToString & " " & J4Val.ToString & " " & J6Val.ToString & " " & _
                        Hand.ToString & " 0"
            _ret = _tcp8.SendF8(strSend)
            do_Show(strSend, _ret)
            Return _ret
        Else
            Return ""
            MessageBox.Show("点参数不正确", "警告", MessageBoxButtons.OK)
        End If

    End Function

    '四 
    '连接 R5
    Private Sub btnConR5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        _tcp5.doConnectionR5(txtIpR5.Text, txtPort5.Text)
    End Sub
    '连接 F8
    Private Sub btnConF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection1.Click
        _tcp8.doConnectionF8(txtIpR8.Text, txtPort8.Text)
    End Sub


    '取坐标 GetVariable  R5
    Private Sub btnGetPos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPos.Click
        Dim recievedata As String

        '返回值： #GetVariable,X95.2349Y245.839Z-19.9945U-84.9324V0W0J1F0J2F0J4F0J6F0H1T0B10B20D0
        strSend = "$GetVariable,X$"
        recievedata = _tcp5.SendR5(strSend)
        do_Show(strSend, recievedata)

        Dim Xcounter As Integer = InStrRev(recievedata, "#GetVariable", -1)

        If Xcounter <> 0 Then

            Dim counter1 As Integer = InStrRev(recievedata, "X", -1)
            Dim counter2 As Integer = InStrRev(recievedata, "Y", -1)
            Dim counter3 As Integer = InStrRev(recievedata, "Z", -1)
            Dim counter4 As Integer = InStrRev(recievedata, "U", -1)
            Dim counter5 As Integer = InStrRev(recievedata, "V", -1)
            Dim counter6 As Integer = InStrRev(recievedata, "W", -1)

            Dim counter7 As Integer = InStrRev(recievedata, "J1F", -1)
            Dim counter8 As Integer = InStrRev(recievedata, "J2F", -1)
            Dim counter9 As Integer = InStrRev(recievedata, "J4F", -1)
            Dim counter10 As Integer = InStrRev(recievedata, "J6F", -1)
            Dim counter11 As Integer = InStrRev(recievedata, "T", -1)
            Dim counter12 As Integer = InStrRev(recievedata, "B1", -1)
            Dim counter13 As Integer = InStrRev(recievedata, "B2", -1)

            Dim counter14 As Integer = InStrRev(recievedata, "Alarm1", -1)
            Dim counter15 As Integer = InStrRev(recievedata, "H", -1)
            Dim counter17 As Integer = InStrRev(recievedata, "D", -1)

            If counter1 > 0 And counter2 > 0 And counter3 > 0 And counter4 > 0 And counter5 > 0 And counter6 > 0 And counter7 > 0 And counter8 > 0 And counter9 > 0 And counter10 > 0 And counter15 > 0 And counter11 > 0 And counter12 > 0 And counter13 > 0 And counter17 > 0 Then
                With _enP

                    .X = Mid(recievedata, counter1 + 1, counter2 - counter1 - 1)
                    .Y = Mid(recievedata, counter2 + 1, counter3 - counter2 - 1)
                    .Z = Mid(recievedata, counter3 + 1, counter4 - counter3 - 1)
                    .U = Mid(recievedata, counter4 + 1, counter5 - counter4 - 1)
                    .V = Mid(recievedata, counter5 + 1, counter6 - counter5 - 1)
                    .W = Mid(recievedata, counter6 + 1, counter7 - counter6 - 1)
                    .J1F = Mid(recievedata, counter7 + 3, counter8 - counter7 - 3)
                    .J2F = Mid(recievedata, counter8 + 3, counter9 - counter8 - 3)
                    .J4F = Mid(recievedata, counter9 + 3, counter10 - counter9 - 3)
                    .J6F = Mid(recievedata, counter10 + 3, counter15 - counter10 - 3)
                    .Hand = Mid(recievedata, counter15 + 1, counter11 - counter15 - 1)
                    .Tool = Mid(recievedata, counter11 + 1, counter12 - counter11 - 1)
                    .B1 = Mid(recievedata, counter12 + 2, counter13 - counter12 - 2)
                    .B2 = Mid(recievedata, counter13 + 2, counter17 - counter13 - 2)
                    .Done = Mid(recievedata, counter17 + 1).Trim()

                    SetValue() '将值显示到界面
                End With
            End If
        ElseIf recievedata = "Fail" Then
            MessageBox.Show("命令发送失败，请检查网络和控制器", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        ElseIf recievedata = "Disconnect" Then
            MessageBox.Show("未连接机械手控制器", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)

        End If
    End Sub

    Private Sub SetValue()
        With _enP

            If Not txtX.ReadOnly Then
                txtX.Text = .X
            End If

            If Not txtY.ReadOnly Then
                txtY.Text = .Y
            End If

            If Not txtZ.ReadOnly Then
                txtZ.Text = .Z
            End If

            If Not txtU.ReadOnly Then
                txtU.Text = .U
            End If

            If Not txtV.ReadOnly Then
                txtV.Text = .V
            End If

            If Not txtW.ReadOnly Then
                txtW.Text = .W
            End If

        End With
    End Sub

    'Home
    '$login / $Reset / $Stop / $Start / $Start .. /H . /$Stop
    'R5                                            F8   R5
    Private Sub btnRbtHoming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRbtHoming.Click
        Dim _di As Integer = -1
        Dim intN As Integer = 0
        thr_Act.Abort()
        thr_M.Abort()
        RobotAActionStart = False
        RobotAActionDone = False
        _index = 1
        strOsend = ""
        strOsend = ""
        strORec = ""
        Now_grab_Num = 1

        '$login / $Reset / $Stop / $Start / $Start .. /H . /$Stop
        Dim recievedata As String
        strSend = "$login,123"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#login,0")
        do_Show(strSend, _ret)

        strSend = "$Reset"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Reset,0")
        do_Show(strSend, _ret)

        strSend = "$Stop,0"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")
        do_Show(strSend, _ret)

        strSend = "$Start,0"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")
        do_Show(strSend, _ret)

        strSend = "$Start,1"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")
        do_Show(strSend, _ret)

        _tcp8.doConnectionF8(txtIpR8.Text, txtPort8.Text) '连接TCP

        strSend = "H Home"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "H")
        do_Show(strSend, _ret)

4:

        'DI_ReadLine(0, 6, 0, _di)  'Input(13) WTON ...
        DI_ReadLine(Card7230, 0, 0, _di)
        If _di = 0 Then
            GoTo 4
        End If

        strSend = "$Stop,0"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")
        do_Show(strSend, _ret)


        strSend = "$SetMotorsOff,1"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#SetMotorsOff,0")
        do_Show(strSend, _ret)


    End Sub

    'J Stop 0 0 0   R8
    Private Sub btnXA_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZD.MouseUp, btnZA.MouseUp, btnYD.MouseUp, btnYA.MouseUp, btnXD.MouseUp, btnXA.MouseUp, btnWD.MouseUp, btnWA.MouseUp, btnVD.MouseUp, btnVA.MouseUp, btnUD.MouseUp, btnUA.MouseUp
        If ck_Move.Checked Then
            '发送：J Stop 0 0 0
            '接收： 
            strSend = "J Stop 0 0 0"
            _ret = _tcp8.SendF8(strSend)
            do_Show(strSend, _ret)
        End If
    End Sub

    'L _claw     R8 
    Private Sub btnPlugIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Pos() As Double
        Dim i As Integer = -1
        'L X Y Z U V W X1 Y1 Z1 U1...
        Pos = dao_Epson.Read_PlugPoint_R8_L(_claw_no.ToString) 'InsertTool
        i += 1 : txtX.Text = Round(Pos(i), 3)
        i += 1 : txtY.Text = Round(Pos(i), 3)
        i += 1 : txtZ.Text = Round(Pos(i), 3)
        i += 1 : txtU.Text = Round(Pos(i), 3)
        i += 1 : txtV.Text = Round(Pos(i), 3)
        i += 1 : txtW.Text = Round(Pos(i), 3)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged, CheckBox6.CheckedChanged, CheckBox5.CheckedChanged, CheckBox4.CheckedChanged, CheckBox3.CheckedChanged, CheckBox2.CheckedChanged
        Dim cb As CheckBox = CType(sender, CheckBox)
        Select Case cb.Tag.ToString
            Case "X"
                txtX.ReadOnly = Not txtX.ReadOnly
            Case "Y"
                txtY.ReadOnly = Not txtY.ReadOnly
            Case "Z"
                txtZ.ReadOnly = Not txtZ.ReadOnly
            Case "U"
                txtU.ReadOnly = Not txtU.ReadOnly
            Case "V"
                txtV.ReadOnly = Not txtV.ReadOnly
            Case "W"
                txtW.ReadOnly = Not txtW.ReadOnly
        End Select

    End Sub

    '模式
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            btnXA.Text = "X+"
            btnXD.Text = "X-"
            btnYA.Text = "Y+"
            btnYD.Text = "Y-"
            btnZA.Text = "Z+"
            btnZD.Text = "Z-"
            btnUA.Text = "U+"
            btnUD.Text = "U-"
            btnVA.Text = "V+"
            btnVD.Text = "V-"
            btnWA.Text = "W+"
            btnWD.Text = "W-"
            _modeA = 0
        Else
            btnXA.Text = "J1+"
            btnXD.Text = "J1-"
            btnYA.Text = "J2+"
            btnYD.Text = "J2-"
            btnZA.Text = "J3+"
            btnZD.Text = "J3-"
            btnUA.Text = "J4+"
            btnUD.Text = "J4-"
            btnVA.Text = "J5+"
            btnVD.Text = "J5-"
            btnWA.Text = "J6+"
            btnWD.Text = "J6-"
            _modeA = 1
        End If

    End Sub

    '计算MARK点
    Private Sub btnMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMark.Click

        'mepson_com.Move_Mark_Click(dis_point, mrobotSetPoint.Mark_StartPoint.toolflag, mrobotSetPoint.Mark_StartPoint.J4, mrobotSetPoint.Mark_StartPoint.J6, mrobotSetPoint.Mark_StartPoint.J1, mrobotSetPoint.Mark_StartPoint.J2, mrobotSetPoint.Mark_StartPoint.hand)
        strSend = "J Mark 0 -79.99 80.5 0 -0.412 0 0 0 0 0 0 1 0"
        recievedata = _tcp8.SendF8(strSend)
        do_Show(strSend, recievedata)

    End Sub

    '启动Robot
    Private Sub btnInitialize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitialize.Click

        _do_Login()
        _tcp8.doConnectionF8(txtIpR8.Text, txtPort8.Text)
    End Sub

    '皮带测试窗口
    Private Sub btnfrmBelt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfrmBelt.Click
        Dim _frm As New frmBelt
        _frm.Show()
    End Sub

    '开启测试
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        dofrm_Load()
    End Sub

    '单插件
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'robot_A_actionsub()
        thr_Act.Start()

    End Sub

    ' 多插件
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        thr_M.Start()
    End Sub

    '停止
    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        strSend = "$Stop,0"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")
        do_Show(strSend, _ret)
    End Sub

    ' 测试视觉
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim VisionResult As String
        Dim str As String = "11|50.002|100.56|100"
        _ret = F_Client_BLL.doCommand_01(1, str)
        System.Threading.Thread.Sleep(20)
        ' 延时后读数据
        m_da.Receive()
        Thread.Sleep(30)
        VisionResult = strVision
    End Sub


    Private Sub _do_Login()
        Dim recievedata As String
        'login

        strSend = "$login,123"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#login,0")
        do_Show(strSend, recievedata)


        strSend = "$SetMotorsOn,1"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#SetMotorsOn,0")
        do_Show(strSend, _ret)


        'Reset
        strSend = "$Reset"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Reset,0")
        do_Show(strSend, recievedata)
        'Stop
        strSend = "$Stop,0"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")
        do_Show(strSend, recievedata)
        'Start
        strSend = "$Start,0"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")
        do_Show(strSend, recievedata)
        'Start
        strSend = "$Start,1"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")
        do_Show(strSend, recievedata)

    End Sub

    ' 事件 取得相机结果
    Private Sub evt_R_DataReceived(ByVal sender As String, ByVal str As String)
        strVision = m_da.Para.Result
    End Sub

    Private Sub ck_safe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_safe.CheckedChanged
        safepingbi = Me.CheckBox1.Checked
    End Sub
     
End Class