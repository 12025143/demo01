Imports FACC
Imports System.Threading

Public Class frmPlug

    Dim _ret As String
    Dim strSend As String = ""


    Dim _index As Integer = 1 '记录序号
    Dim strOsend As String = ""  '发送的上一条指令
    Dim strORec As String = ""   '接收的上一条指令 


    Dim _tcp5 As New clsTcp
    Dim _tcp8 As New clsTcp
    Dim dao_Epson As New clsEpsonCom
    Dim thr_Act As Threading.Thread
    Dim thr_M As Threading.Thread
    Dim act As RobotAction

    Private Sub dofrm_Load()
        Card7230 = Register_Card(PCI_7230, 0)
        _tcp5.doConnectionR5(txtIpR5.Text, txtPort5.Text)
    End Sub

    '连接 R5
    Private Sub btnConR5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection.Click
        _tcp5.doConnectionR5(txtIpR5.Text, txtPort5.Text)
    End Sub
    '连接 F8
    Private Sub btnConF8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection1.Click
        _tcp8.doConnectionF8(txtIpR8.Text, txtPort8.Text)
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

    Private Sub do_Show(ByVal strData As String, ByVal rec As String)

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

    End Sub
    'Home
    '$login / $Reset / $Stop / $Start / $Start .. /H . /$Stop
    'R5                                            F8   R5
    Private Sub btnRbtHoming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRbtHoming.Click
        Dim _di As Integer = -1
        Dim intN As Integer = 0
        RobotAActionStart = False
        RobotAActionDone = False
        _index = 1
        strOsend = ""
        strOsend = ""
        strORec = ""

        '$login / $Reset / $Stop / $Start / $Start .. /H . /$Stop
        Dim recievedata As String
        strSend = "$login,123"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#login,0")
        do_Show(strSend, _ret)
        Thread.Sleep(300)

        strSend = "$Stop,0"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")
        do_Show(strSend, _ret)
        Thread.Sleep(300)


        strSend = "$Start,0"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")
        do_Show(strSend, _ret)
        Thread.Sleep(300)

        _tcp8.doConnectionF8(txtIpR8.Text, txtPort8.Text) '连接TCP



        strSend = "H Home"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "H")
        do_Show(strSend, _ret)
        Thread.Sleep(300)
4:


        DI_ReadLine(Card7230, 0, 0, _di)  'Input(13)  
        If _di = 0 Then
            GoTo 4
        End If
         
        strSend = "$Stop,0"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")
        do_Show(strSend, _ret)


        strSend = "$Reset"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Reset,0")
        do_Show(strSend, _ret)
        Thread.Sleep(300) 

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Card7230 = Register_Card(PCI_7230, 0)
        _tcp5.doConnectionR5(txtIpR5.Text, txtPort5.Text)
    End Sub

    Private Sub btnInitialize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitialize.Click
        _do_Login()
        _tcp8.doConnectionF8(txtIpR8.Text, txtPort8.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        act = New RobotAction(_tcp5, _tcp8)
        thr_M = New Threading.Thread(AddressOf act.robot_3_actionsub)
        thr_M.Start()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        act = New RobotAction(_tcp5, _tcp8)
        thr_Act = New Threading.Thread(AddressOf act.robot_1_actionsub)
        thr_Act.Start()
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Dim recievedata As String
        strSend = "$Stop,0"
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")
        do_Show(strSend, _ret)
    End Sub
    '写入机械手数据
    Private Sub btnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIni.Click
        Dim _IniP As New IniPoint(_tcp5, _tcp8)
        Dim _Send_Str(553) As String
        Dim _bol As Boolean = False
        If Me.txtPro.Text.Trim = "" Then MessageBox.Show("请填写产品编号") : Exit Sub

        _IniP.ReadData(Me.txtPro.Text) '从文件读取数据
        _Send_Str = _IniP.Robot_PointData_T1()  '将文件数据组合成协议数据
        _bol = _IniP.Send_Point_Sub(_Send_Str)  '将协议数据发送到机械手
        If _bol = True Then
            MessageBox.Show("写入完毕")
        Else
            MessageBox.Show("写入失败")
        End If

    End Sub

    Private Sub txtTimeOut8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTimeOut8.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim _frm As New frmTcpSendA_11
        _frm.Show()
    End Sub
End Class