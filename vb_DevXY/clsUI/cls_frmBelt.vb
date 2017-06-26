Imports System.Threading
Imports System.IO.Ports
Imports System.IO

Partial Public Class cls_frmBelt
    Dim frm As frmBelt

    Dim HadChangProduct As Boolean = False   '切换生产型号
    Dim ord As New Order
    Dim AxisMotionDone As Boolean = False  '到位信号
    Dim P1ActionNextNeed As Boolean = False   '下工位要料信号    Dim P2ActionNextNeed As Boolean = False   '下工位要料信号    Dim P3ActionNextNeed As Boolean = False   '下工位要料信号    Dim ActionhadNotmove As Boolean = False
    Dim end1, end2, end0 As Boolean

    Dim P1Actionstart As Boolean = False
    Dim P2Actionstart As Boolean = False
    Dim P3Actionstart As Boolean = False

    Dim position3_Had As Boolean = False '工位3有板

    Dim _ret As Integer '接收返回字符串    Dim strRet As String '接收返回字符串

    Dim _client As New System.IO.Ports.SerialPort
    Dim sndBuffer As String = ""  '发送字符串
    Dim di_ret As Integer  'IO状态
    Dim AutoPassTrue As Boolean = False  '直通模式     
    Dim thr_P1, thr_P2, thr_P3 As Threading.Thread

    Sub New(ByVal vfrm As frmBelt)
        frm = vfrm
    End Sub

    Public Sub btnPos1Turn()

        _ret = DO_WriteLine(Card7432, 0, frm.txt_DO_6.Text, 1)   '工位1转动
    End Sub

    Public Sub btnpos1Stop()

        _ret = DO_WriteLine(Card7432, 0, frm.txt_DO_6.Text, 0)  '工位1停止转动
    End Sub

    Public Sub btnPos2TurnP()

        DO_WriteLine(Card7432, 0, frm.txt_DO_7.Text, 1)  '工位2正转

    End Sub

    Public Sub btnPos2TurnN()

        DO_WriteLine(Card7432, 0, frm.txt_DO_8.Text, 1)  '工位2反转 
    End Sub

    Public Sub btnPos2StopP()
        DO_WriteLine(Card7432, 0, frm.txt_DO_7.Text, 0)  '工位2正转停止
    End Sub
    Public Sub btnPos2StopN()
        DO_WriteLine(Card7432, 0, frm.txt_DO_8.Text, 0)  '工位2反转 停止
    End Sub


    Public Sub btnP1Need()
        _ret = DO_WriteLine(Card7432, 0, frm.txt_DO_10.Text, 1)  '工位1输出要料信号

    End Sub

    Public Sub btnPos3Turn()
        _ret = DO_WriteLine(Card7432, 0, frm.txt_DO_9.Text, 1)   '工位3正转


    End Sub

    Public Sub btnPos3Stop()
        _ret = DO_WriteLine(Card7432, 0, frm.txt_DO_9.Text, 0)   '工位3正转停止

    End Sub

    Public Sub btnP3Have()
        _ret = DO_WriteLine(Card7432, 0, frm.txt_DO_11.Text, 1) '工位3输出有板信号

    End Sub

    Public Sub Belt_Load()

        Card7432 = Register_Card(PCI_7432, 0)
        _client.BaudRate = 9600
        _client.PortName = "COM1"
        _client.DataBits = 8
        _client.StopBits = 1
        _client.Handshake = Handshake.None
        If _client.IsOpen = False Then
            _client.Open()
        End If


    End Sub

    Public Sub Button7()

        btnMotorHOMING()

        Do

            btnStopPoint()   '挡料点            GetStatus(5)

            btnPos1Turn()    '工位1转动   

            btnPos2StopP() '工位2转

            btnpos1Stop()    '工位1停止

            btnPos2StopP()    '工位2停止

            btnHighest()  '最高点
            GetStatus(5)

            btnLowest()  '放料点            GetStatus(5)


            btnPos2TurnP() '工位2转

            btnPos3Turn()  '工位3转

            btnPos2StopP()  '工位2停

            btnPos3Stop()  '工位3停

        Loop

    End Sub

    Public Sub GetStatus(ByVal AxisNum As Integer)
        Dim AxisReadstatus As String
        Dim _ReadStatus As String


        '_ReadStatus = ord.ReadStatus("ReadStatus", AxisNum) '读取状态
        ''_ReadStatus = ord.ReadPOS("ReadPOS", AxisNum)  '读位置
        'AxisReadstatus = do_Comm_Send(_ReadStatus)


        Do
            If AxisNum = 4 Then
                _ReadStatus = "04 03 00 01 00 01 d5 9f" '
            Else
                _ReadStatus = "05 03 00 01 00 01 d4 4e" '"04 03 00 01 00 01 d5 9f" ' " ReadStatus  05 03 00 01 00 01 d4 4e" 
            End If
            AxisReadstatus = do_Comm_Send(_ReadStatus) ' AxisReadstatus =0403020009b442 

            Dim count As Integer = InStr(AxisReadstatus, "0302", CompareMethod.Binary)
            If count > 0 Then
                Dim ReadStatus As Integer = Convert.ToInt32(Mid(AxisReadstatus, count + 4, 4), 16)
                If ReadStatus And 2 ^ 3 Then
                    AxisMotionDone = True '运行到位信号
                Else
                    AxisMotionDone = False
                End If
            End If
            Application.DoEvents()
        Loop Until AxisMotionDone = True

    End Sub


    Public Sub btnMotorHOMING()

        'sndBuffer = "05 10 00 1B 00 05 0A 02 58 02 58 09 60 FF FF FF FF BB 32"  'Home_Dir5
        'do_Comm_Send(sndBuffer)

        'sndBuffer = "05 10 00 7C 00 03 06 00 6E 00 31 00 4C 93 E3"  'SeekHome
        'do_Comm_Send(sndBuffer)


        strRet = ord.Home_Dir("Home_Dir", 5, 2400, -1, frm.txtAcc.Text, frm.txtDec.Text)
        do_Comm_loop(strRet)

        strRet = ord.SeekHome("SeekHome", 5, 1, 0)
        do_Comm_loop(strRet)

    End Sub

    Public Sub btnMotorON()

        'MotorOn5
        sndBuffer = "05 06 00 7C 00 9F 09 FE"

        do_Comm_Send(sndBuffer)
    End Sub

    Public Sub btnMotorOFF()
        'MotorOff
        sndBuffer = "05 06 00 7C 00 9E C8 3E"

        do_Comm_Send(sndBuffer)
    End Sub

    Public Sub btnHighest()

        sndBuffer = "05 10 00 1B 00 05 0A 0E 10 0E 10 06 90 00 04 02 D3 A5 1D"
        do_Comm_Send(sndBuffer)

        sndBuffer = "05 06 00 7C 00 67 08 7C"
        do_Comm_Send(sndBuffer)


    End Sub

    Public Sub btnStopPoint()

        sndBuffer = "05 10 00 1B 00 05 0A 0E 10 0E 10 06 90 00 03 7C E4 74 AA"
        do_Comm_Send(sndBuffer)

        sndBuffer = "05 06 00 7C 00 67 08 7C"
        do_Comm_Send(sndBuffer)



    End Sub

    Public Sub btnLowest()

        sndBuffer = "05 10 00 1B 00 05 0A 0E 10 0E 10 06 90 00 01 0B DE 72 89"
        do_Comm_Send(sndBuffer)

        sndBuffer = "05 06 00 7C 00 67 08 7C"
        do_Comm_Send(sndBuffer)
    End Sub

    Public Sub btnOpen()


        '04 10 00 1b 00 05 0a 0e 10 0e 10 04 b0 ff ff ec 78 39 52 |04 06 00 7c 00 66 c8 6d 
        strRet = ord.Position_R_Move("Position_R_Move", 4, frm.txtSpeed.Text * 240, -frm.txtPos.Text * frm.txtRatio.Text, frm.txtAcc.Text * 6, frm.txtDec.Text * 6)
        do_Comm_loop(strRet)

    End Sub
    Public Sub btnClose()

        '04 10 00 1b 00 05 0a 0e 10 0e 10 04 b0 00 00 13 88 78 c2 |04 06 00 7c 00 66 c8 6d 
        strRet = ord.Position_R_Move("Position_R_Move", 4, frm.txtSpeed.Text * 240, frm.txtPos.Text * frm.txtRatio.Text, frm.txtAcc.Text * 6, frm.txtDec.Text * 6)
        do_Comm_loop(strRet)

    End Sub

    Public Sub btnMove()
        Dim pos As Integer = frm.txtTw.Text - frm.txtBw.Text
        '04 10 00 1b 00 05 0a 0e 10 0e 10 04 b0 00 03 5b 60 be 8c |04 06 00 7c 00 67 09 ad 
        strRet = ord.Position_A_Move("Position_A_Move", 4, frm.txtSpeed.Text * 240, pos * frm.txtRatio.Text, frm.txtAcc.Text * 6, frm.txtDec.Text * 6) '绝对移动
        do_Comm_loop(strRet)
    End Sub

    Public Sub btnTackHoming()
        'If Axistype(num).HomeDir = 1 Then
        '    Home_Dir("Home_Dir", Axistype(num).AxisNum, Axistype(num).HomeVel, 1, Axistype(num).AxisAcc, Axistype(num).AxisDec)
        'Else
        '04 10 00 1b 00 05 0a 02 58 02 58 09 60 ff ff ff ff ea a2 
        strRet = ord.Home_Dir("Home_Dir", 4, 2400, -1, frm.txtAcc.Text, frm.txtDec.Text)
        do_Comm_loop(strRet)
        'End If
        '04 10 00 7c 00 03 06 00 6e 00 31 00 4c 91 62 
        strRet = ord.SeekHome("SeekHome", 4, 1, 0)
        do_Comm_loop(strRet)


    End Sub
    Public Sub btnP1Homing()
        end0 = False
        P1Actionstart = False
        P1ActionNextNeed = False

        btnpos1Stop() '_ret = DO_WriteLine(Card7432, 0, frm.txt_DO6.Text, 0)    '工位1停止

        If HadChangProduct = True Then
            HadChangProduct = False
            sndBuffer = "04 10 00 1B 00 05 0A 02 58 02 58 09 60 FF FF FF FF EA A2" ' Home_Dir
            do_Comm_Send(sndBuffer)

            sndBuffer = "04 10 00 7C 00 03 06 00 6E 00 31 00 4C 91 62"  'SeekHome
            do_Comm_Send(sndBuffer)
            GetStatus(4)

            'home_Set_Pos1|01 10 00 7c 00 02 04 00 a5 00 00 e4 fd 
            'home_Set_Pos2|02 10 00 7c 00 02 04 00 a5 00 00 eb b9 
            'home_Set_Pos3|03 10 00 7c 00 02 04 00 a5 00 00 ef 45 
            'home_Set_Pos4|04 10 00 7c 00 02 04 00 a5 00 00 f5 31 
            'home_Set_Pos5|05 10 00 7c 00 02 04 00 a5 00 00 f1 cd 
            sndBuffer = "04 10 00 7C 00 02 04 00 A5 00 00 F5 31" 'home_Set_Pos4
            do_Comm_Send(sndBuffer)


            btnMove() '间距皮带移动到设定间距
            GetStatus(4)
        End If



    End Sub


    Public Sub btnP2Homing()
        end1 = False
        P2ActionNextNeed = False
        ActionhadNotmove = False
        P2Actionstart = False
        RobotAActionDone = False


        btnPos2StopP() '工位2正转停止
        btnPos2StopN() '工位2反转停止

        sndBuffer = "05 10 00 1B 00 05 0A 02 58 02 58 09 60 FF FF FF FF BB 32"   'Home_Dir
        do_Comm_Send(sndBuffer)

        sndBuffer = "05 10 00 7C 00 03 06 00 6E 00 31 00 4C 93 E3"    ' SeekHome  定位电机回原点
        do_Comm_Send(sndBuffer)
        GetStatus(5)
        If AxisMotionDone = True Then
            'home_Set_Pos1|01 10 00 7c 00 02 04 00 a5 00 00 e4 fd 
            'home_Set_Pos2|02 10 00 7c 00 02 04 00 a5 00 00 eb b9 
            'home_Set_Pos3|03 10 00 7c 00 02 04 00 a5 00 00 ef 45 
            'home_Set_Pos4|04 10 00 7c 00 02 04 00 a5 00 00 f5 31 
            'home_Set_Pos5|05 10 00 7c 00 02 04 00 a5 00 00 f1 cd 
            sndBuffer = "05 10 00 7c 00 02 04 00 a5 00 00 f1 cd" 'home_Set_Pos
            do_Comm_Send(sndBuffer)



            DI_ReadLine(Card7432, 0, frm.txt_DI_8.Text, di_ret) '检测工位2定位机构处是否有板
            If di_ret = 1 Then
                '判断插件是否已完成，完成走下一步
            End If
            AxisMotionDone = False
        End If

    End Sub


    Public Sub btnP3Homing()
        end2 = False
        P3ActionNextNeed = False
        P3Actionstart = False

        DO_WriteLine(Card7432, 0, 9, 0)   '工位3正转停止
    End Sub



    Public Sub do_Comm_loop(ByVal _Sendlist As String)


        Dim _val_rcv As String = ""  '串口 接收到的数据
        Dim _send As String = _Sendlist.Trim()  '取值

        Dim _arr As String() = _send.Split("|")  '分解多值 02 25 58 CC FF|25 65 58 DD FF
        For j = 0 To _arr.Length - 1 '轮询 分解后的每一个
            _send = _arr(j).Trim()  'send     // 串口发信息
            _val_rcv = do_Comm_Send(_send) 'rcv        串口 同步接收
        Next

    End Sub


    Function do_Comm_Send(ByVal outStr As String) As String
        Dim _arr() As String
        Dim _arrBuf(4096) As Byte
        Dim _rcvStr(4096) As Byte
        _arr = outStr.Split(" ")
        For i = 0 To _arr.Length - 1
            _arrBuf(i) = Val("&H" + _arr(i))
        Next
        If _client.IsOpen = False Then
            _client.Open()
        End If
        _client.Write(_arrBuf, 0, _arr.Length)
        Thread.Sleep(30)
        Dim _len As Integer = _client.BytesToRead
        _client.Read(_rcvStr, 0, _len)
        Dim _rec As String = ""
        For i As Integer = 0 To _len - 1
            _rec = _rec & Convert.ToString(_rcvStr(i), 16).PadLeft(2, "0")
        Next
        Dim ls As New List(Of String)

        ls.Add(outStr & Space(10) & _len & Space(10) & Now)
        File.AppendAllLines(Environment.CurrentDirectory & "\temp\log.txt", ls)

        Thread.Sleep(5)
        Return _rec
    End Function

    ' 工位1 动作
    Public Sub btnP1Action()
        P1Actionstart = True
        thr_P1 = New Thread(AddressOf P1Action)
        thr_P1.Start()

    End Sub
    ' 工位2 动作
    Public Sub btnP2Action()
        P2Actionstart = True
        thr_P2 = New Thread(AddressOf P2Action)
        thr_P2.Start()

    End Sub
    ' 工位3 动作
    Public Sub btnP3Action()
        P3Actionstart = True
        thr_P3 = New Thread(AddressOf P3Action)
        thr_P3.Start()

    End Sub


    Private Sub P1_4()
        di_ret = WaitStatus(frm.txt_DI_7.Text) 'DI_ReadLine(Card7432, 0, frm.txt_DI_7.Text, di_ret)
        If di_ret Then '4 出口有料时，直接等待出料  inputNum(5)
1:
            If P1ActionNextNeed Then
                btnPos1Turn()  '5
                di_ret = WaitStatus(frm.txt_DI_7.Text, 0)
                'If di_ret = 0 Then  '出口没料  inputNum(5)
                btnpos1Stop()
                'End If
            Else
                Application.DoEvents()
                btnpos1Stop()
                GoTo 1
            End If
        End If
    End Sub

    Private Function ReadStatus(ByVal bit As Integer) As Integer
        Dim _di As Integer
        DI_ReadLine(Card7432, 0, bit, _di)
        Return _di

    End Function

    Private Function WaitStatus(ByVal bit As Integer, Optional ByVal WaitNo As Integer = 1)
        Dim _di As Integer
        Do
            DI_ReadLine(Card7432, 0, bit, _di)
            Thread.Sleep(5)
            Application.DoEvents()
        Loop Until _di = WaitNo

        Return _di

    End Function


    '直通
    Public Sub Auto()
        AutoPassTrue = frm.ck_AutoPassTrue.Checked
    End Sub


    '切换型号
    Public Sub btnChange()
        HadChangProduct = frm.ck_Change.Checked
    End Sub
    '下机要料
    Public Sub P3NextNeed()
        P3ActionNextNeed = frm.ck_P3NextNeed.Checked
    End Sub
    '插件完成
    Public Sub RbtDone()
        RobotAActionDone = frm.ck_RbtDone.Checked
    End Sub
End Class
