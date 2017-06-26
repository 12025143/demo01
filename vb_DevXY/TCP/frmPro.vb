Imports System.Threading
Imports FACC
Public Class frmPro
    Dim di_ret As Integer
    Dim safepingbi As Boolean = True
    Dim RobotAStartrun As Boolean
    Dim robot_Ashoudongstart As Boolean
    Dim _ret As String
    Dim recievedata As String
    Dim _tcp As New clsTcp
    Dim dao_Epson As New clsEpsonCom
    Dim Robot_UP_Had_String As New List(Of Integer)
    Dim Now_grab_Num As Integer
    Dim QuJian_String_list As New List(Of Integer)
    Sub robot_A_actionsub()
10:
        If Me.txtGLReady.Checked = True Then
            GoTo 1001
        Else
            'GoTo 10000
        End If
1001:
        GoTo 11
10000:  '启动机械手去等待取料位置
        recievedata = _tcp.SendF8("Q B 2")
        _ret = dao_Epson.GetStatus(recievedata, "Q")
        If _ret = "P" Then
            GoTo 10001
        Else
            GoTo 10000
        End If
10001:
        DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13)
        If di_ret = 1 Then
            GoTo 10
        Else
            GoTo 10001
        End If
11:     '启动机械手去取料位置
        recievedata = _tcp.SendF8("Q A 2 0")
        _ret = dao_Epson.GetStatus(recievedata, "Q")
        DI_ReadLine(0, 6, 1, di_ret) 'InputNum(14) 
        If _ret = "P" And di_ret = 0 Then
            If robot_Ashoudongstart = True Then
                Exit Sub
            End If
            GoTo 1200
        Else
            GoTo 11
        End If
1200:   '等待机械手夹紧供料器
        DI_ReadLine(0, 6, 1, di_ret) 'InputNum(14)
        If di_ret = 1 Then
            GoTo 1203
        Else
            GoTo 1201
        End If
1201:   '输出给供料器 打开夹爪信号
1203:   '机械手取料时，输出给机械手可以离开信号
        _ret = DO_WriteLine(0, 6, 0, 1)   'OutputNum(18)
        GoTo 12
12:     '等待机械手去取料位置
        DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13)
        If di_ret = 1 Then
            _ret = DO_WriteLine(0, 6, 0, 0)   'OutputNum(18)
            Now_grab_Num = Now_grab_Num + 1
            GoTo 13
        Else
            GoTo 12
        End If
13:
        If Now_grab_Num > QuJian_String_list.Count Then
            GoTo 1401
        Else
            GoTo 10  '返回继续取料
        End If
1401:
        GoTo 14
14:
1400:
        recievedata = _tcp.SendF8("A 2")
        _ret = dao_Epson.GetStatus(recievedata, "A")
        DI_ReadLine(0, 6, 1, di_ret) 'InputNum(14)
        If _ret = "P" And di_ret = 0 Then
            If robot_Ashoudongstart = True Then
                Exit Sub
            End If
            GoTo 15
        Else
            GoTo 1400
        End If
15:
        DI_ReadLine(0, 6, 1, di_ret) 'InputNum(14)
        If di_ret = 1 Then
            _ret = DO_WriteLine(0, 6, 0, 0)   'OutputNum(18)
            If robot_Ashoudongstart = True Then
                Exit Sub
            End If
            GoTo 16
        Else
            GoTo 15
        End If
16:
        _ret = DO_WriteLine(0, 6, 0, 1)
        GoTo 1700
1700:
        GoTo 17
17:
        DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13)
        If di_ret = 1 Then
            _ret = DO_WriteLine(0, 6, 0, 0)
            GoTo 18
        Else
            GoTo 17
        End If
18:
        GoTo 19
19:
        GoTo 20
20:
        recievedata = _tcp.SendF8("G 2")
        _ret = dao_Epson.GetStatus(recievedata, "G")
        If _ret = "P" Then
            GoTo 21
        Else
            GoTo 20
        End If
21:
        DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13)
        If di_ret = 1 Then
            GoTo 2100
        Else
            GoTo 21
        End If
2100:
        GoTo 2102
2102:
        GoTo 2000
2000:
        GoTo 2
2:
        recievedata = _tcp.SendF8("M 1 2")
        _ret = dao_Epson.GetStatus(recievedata, "M")
        If _ret = "P" Then
            _ret = DO_WriteLine(0, 6, 0, 0)
            GoTo 3
        Else
            GoTo 2
        End If
3:
        DI_ReadLine(0, 6, 1, di_ret) 'InputNum(14)
        If di_ret = 1 Then
            GoTo 4
        Else
            GoTo 3
        End If
4:
        GoTo 5
5:
        _ret = DO_WriteLine(0, 6, 0, 1)
        '_ret = DO_WriteLine(0, 0, 13, 1) 'OutputNum(12)
        '_ret = DO_WriteLine(0, 0, 13, 0) 'OutputNum(12)
        GoTo 7
7:      '等待机械手到Mark点2位置完成
        DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13)
        If di_ret = 1 Then
            _ret = DO_WriteLine(0, 6, 0, 0)
            GoTo 8
        End If
8:
        _ret = DO_WriteLine(0, 0, 13, 1) 'OutputNum(12)
        _ret = DO_WriteLine(0, 0, 13, 0) 'OutputNum(12)
        GoTo 8000
8000:
        recievedata = _tcp.SendF8("X 320 240 320 240")
        _ret = dao_Epson.GetStatus(recievedata, "X")
        If _ret = "P" Then
            GoTo 22
        Else
            GoTo 8000
        End If
22:
        GoTo 22000
22000:
        GoTo 23111
23111:
        recievedata = _tcp.SendF8("Y 2 0 0 0 ")
        _ret = dao_Epson.GetStatus(recievedata, "Y")
        If _ret = "P" Then
            GoTo 23
        Else
            GoTo 23111
        End If
23:
        recievedata = _tcp.SendF8("P 2")
        _ret = dao_Epson.GetStatus(recievedata, "P")
        If _ret = "P" Then
            GoTo 24
        Else
            GoTo 23
        End If
24:
        DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13)
        If di_ret = 1 Then
            GoTo 2500
        Else
            GoTo 24
        End If
2500:   '查询是否有插件不良
        recievedata = _tcp.SendF8("S")
        _ret = dao_Epson.GetStatus(recievedata, "S")
        If _ret = "P" Then
            GoTo 25
        End If
25:
        GoTo 2600
2600:
        GoTo 9
9:
        GoTo 1002
1002:
        GoTo 10
    End Sub
    Private Sub do_Show(ByVal strData As String, ByVal rec As String)
        'F_Log.Debug_1("Send", +strData.ToString + Space(10) + rec + Space(10))
        'file.SaveTxt(strP, lstSend) 
    End Sub
    Private Function WaitStatus(ByVal CarNo As Integer, ByVal LLine As Integer, Optional ByVal WaitNo As Integer = 1)
        Dim _di As Integer
        Do
            DI_ReadLine(CarNo, 0, LLine, _di)
            Thread.Sleep(5)
            Application.DoEvents()
        Loop Until _di = WaitNo
        Return _di
    End Function
    'Dim _ret As Integer
    Dim strSend As String
    'Dim _tcp As New clsTcp
    'Sub robot_A_actionsub()
    '    '取料点1()
    '    'portdataAreturestring = mepson_com.portdataA("Q A " & Robot_send_string.Trim)
    '    '发送成功()
    '    strSend = "" '"Q A " & Robot_send_string.Trim
    '    _ret = _tcp.SendF8(strSend)
    '    do_Show(strSend, _ret)
    '    Dim di_0 As Integer
    '    'DI_ReadLine(0, 6, 0, di_0) '等待机械手去取料位置" & Robot_send_string & "完成
    '    WaitStatus(6, 0, 1)
    '    If di_0 = 1 Then
    '        '完成走下一步	
    '    End If
    '    '拍照点1()
    '    'portdataAreturestring = mepson_com.portdataA("A " & SendpaiZhaoString.Trim)
    '    '发送成功()
    '    strSend = "" '"A " & SendpaiZhaoString.Trim
    '    _ret = _tcp.SendF8(strSend)
    '    do_Show(strSend, _ret)
    '    'Dim di_0 As Integer
    '    'DI_ReadLine(0, 6, 0, di_0) '等待机械手去取料位置" & Robot_send_string & "完成
    '    WaitStatus(6, 0, 1)
    '    'If di_0 = 1 Then
    '    '    '完成走下一步	
    '    'End If
    '    'Mark点()
    '    'portdataAreturestring = mepson_com.portdataA("M 1 2")
    '    strSend = "M 1 2"
    '    _ret = _tcp.SendF8(strSend)
    '    do_Show(strSend, _ret)
    '    '发送成功()
    '    'Dim di_1 As Integer
    '    'DI_ReadLine(0, 6, 1, di_1) '等待机械手到Mark点1位置完成
    '    WaitStatus(6, 1, 1)
    '    'If di_1 = 1 Then
    '    '    '完成走下一步	
    '    'End If
    '    'If RobotAActionStart = True Then '等待板进料到位
    '    '    '板定位完成信号，完成走下一步	
    '    'End If
    '    'Thread.Sleep(200) '延时模拟拍照
    '    'Dim do_0 As Integer
    '    DO_WriteLine(0, 6, 1, 1)
    '    'Dim di_1 As Integer
    '    'DI_ReadLine(0, 6, 1, di_1) '等待机械手到Mark点2位置完成
    '    WaitStatus(6, 1, 1)
    '    'If di_1 = 1 Then
    '    '    '完成走下一步	
    '    'End If
    '    Thread.Sleep(200) '延时模拟拍照
    '    '发送Mark点的像素值
    '    strSend = "" ' "X " & MarkX(1).ToString & " " & MarkY(1).ToString & " " & MarkX(2).ToString & " " & MarkY(2).ToString
    '    _ret = _tcp.SendF8(strSend)
    '    do_Show(strSend, _ret)
    '    strSend = "V" ' "X " & MarkX(1).ToString & " " & MarkY(1).ToString & " " & MarkX(2).ToString & " " & MarkY(2).ToString
    '    _ret = _tcp.SendF8(strSend)
    '    do_Show(strSend, _ret)
    'End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        robot_A_actionsub()
    End Sub
    Private Sub frmPro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _ret = Register_Card(PCI_7230, 0)
        _tcp = New clsTcp
        _tcp.doConnectionR5(txtIpR5.Text, txtPort5.Text)
        Dim recievedata As String
        strSend = "$login,123"
        recievedata = _tcp.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#login,0")
        do_Show(strSend, recievedata)
        strSend = "$Reset"
        recievedata = _tcp.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Reset,0")
        do_Show(strSend, recievedata)
        strSend = "$Stop,0"
        recievedata = _tcp.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")
        do_Show(strSend, recievedata)
        strSend = "$Start,0"
        recievedata = _tcp.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")
        do_Show(strSend, recievedata)
        strSend = "$Start,1"
        recievedata = _tcp.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")
        do_Show(strSend, recievedata)
        _tcp.doConnectionF8(txtIpR8.Text, txtPort8.Text)
    End Sub
    Private Sub btnConnection1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnection1.Click
        _tcp.doConnectionF8(txtIpR8.Text, txtPort8.Text)
    End Sub
End Class
