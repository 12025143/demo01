Imports System.Threading
Imports System.IO.Ports
Public Class frm485_01
    Dim _ret As Integer
    Dim sndBuffer As String = ""
    Dim AxisNum As Integer = "05"
    Dim p1_status As ePosStatus = ePosStatus.Ready
    Dim p3_status As ePosStatus = ePosStatus.Ready
    Dim p1_motor As eSwitch = eSwitch.Off
    Dim p3_motor As eSwitch = eSwitch.Off
    Dim _DI_ret As Integer = 0
    '皮带1动作
    Private Sub doit1()
        Select Case p1_status
            Case ePosStatus.Ready ' 准备状态
                If p1_motor <> eSwitch.Off Then '电机未关
                    DO_WriteLine(0, 0, 9, 0) 'OFF 停转
                    p1_motor = eSwitch.Off '停转中
                End If
                DO_WriteLine(0, 0, 5, 1) '要板
                p1_status = ePosStatus.Request
                Thread.Sleep(200)
            Case ePosStatus.Request ' 要板状态
                DI_ReadLine(0, 0, 6, _DI_ret) '到板
                If _DI_ret <> 0 Then 'ReadLine 读到板状态
                    DO_WriteLine(0, 0, 9, 1) '转
                    p1_motor = eSwitch.Run '转动中
                    p1_status = ePosStatus.Busy '在送板中
                End If
                Thread.Sleep(200)
                'Case ePosStatus.Action ' 侦听外部使能, 如工位2处理完成，则 p3_status = ePosStatus.Action  '送板计数有效
                '    p3_motor = eSwitch.Run '转动中
                '    p3_status = ePosStatus.Busy '在送板中
                '    DO_WriteLine(0, 0, 9, 1) 'ON 转
            Case ePosStatus.Busy '在送板中, 延时， 可在此断言报警
                DI_ReadLine(0, 0, 7, _DI_ret)
                If _DI_ret <> 0 Then 'ReadLine 读送板状态
                    p1_status = ePosStatus.Counting  '送板计数有效
                End If
                Thread.Sleep(200)
            Case ePosStatus.Counting '送板有效计数
                DI_ReadLine(0, 0, 7, _DI_ret)
                If _DI_ret = 0 Then 'DI_ReadLine 送板完毕计时
                    p1_status = ePosStatus.Ok  '送板完毕确认
                    Thread.Sleep(200)
                End If
            Case ePosStatus.Ok
                p1_status = ePosStatus.Counting  '送板计数有效
                If _DI_ret = 0 Then 'DI_ReadLine 送板完毕确认
                    DO_WriteLine(0, 0, 7, 0) 'OFF 停转
                    p1_status = ePosStatus.Ready  '送板完成
                    p1_motor = eSwitch.Off '停转中
                End If
        End Select
    End Sub
    '皮带3动作
    Private Sub doit3()
        Select Case p3_status
            Case ePosStatus.Ready ' 准备状态
                If p3_motor <> eSwitch.Off Then '电机未关
                    DO_WriteLine(0, 0, 9, 0) 'OFF 停转
                    p3_motor = eSwitch.Off '停转中
                End If
                Thread.Sleep(200)
            Case ePosStatus.Action ' 侦听外部使能, 如工位2处理完成，则 p3_status = ePosStatus.Action  '送板计数有效
                p3_motor = eSwitch.Run '转动中
                p3_status = ePosStatus.Busy '在送板中
                DO_WriteLine(0, 0, 9, 1) 'ON 转
            Case ePosStatus.Busy '在送板中, 延时， 可在此断言报警
                DI_ReadLine(0, 0, 9, _DI_ret)
                If _DI_ret <> 0 Then 'ReadLine 读送板状态
                    p3_status = ePosStatus.Counting  '送板计数有效
                End If
                Thread.Sleep(200)
            Case ePosStatus.Counting '送板有效计数
                DI_ReadLine(0, 0, 9, _DI_ret)
                If _DI_ret = 0 Then 'DI_ReadLine 送板完毕计时
                    p3_status = ePosStatus.Ok  '送板完毕确认
                    Thread.Sleep(200)
                End If
            Case ePosStatus.Ok
                p3_status = ePosStatus.Counting  '送板计数有效
                If _DI_ret = 0 Then 'DI_ReadLine 送板完毕确认
                    DO_WriteLine(0, 0, 9, 0) 'OFF 停转
                    p3_status = ePosStatus.Ready  '送板完成
                    p3_motor = eSwitch.Off '停转中
                End If
        End Select
    End Sub
    Private Sub frm485_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _ret = Register_Card(PCI_7432, 0)
        AxisNum = Me.txtAxisNum.Text
        If Not _client.IsOpen Then
            _client.BaudRate = Convert.ToInt32(Me.txtBaudRate.Text)
            _client.PortName = Me.txtPortName.Text
            _client.DataBits = 8
            _client.StopBits = 1
            _client.Handshake = Handshake.None
            _client.Open()
        End If
    End Sub
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        do_Comm_Send(Me.txtSndBuffer.Text)
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'home_Set_Pos
        sndBuffer = AxisNum & " 10 00 1B 00 05 0A 02 58 02 58 09 60 FF FF FF FF BB 32"
        do_Comm_Send(sndBuffer)
        sndBuffer = AxisNum & " 10 00 7C 00 03 06 00 6E 00 31 00 4C 93 E3"
        do_Comm_Send(sndBuffer)
        'Dim Pos As String = "00 03 7c e4"
        'sndBuffer = AxisNum & " 10 00 1b 00 05 0a 0e 10 " & Acc & " " & Dec & " " & Vel & " " & Pos & " 74 aa"
        sndBuffer = AxisNum & " 10 00 1B 00 05 0A 0E 10 0E 10 06 90 00 03 7C E4 74 AA"
        do_Comm_Send(sndBuffer)
        sndBuffer = AxisNum & " 06 00 7C 00 67 08 7C"
        do_Comm_Send(sndBuffer)
        _whileMotionDone()
        _MOVE(ePostion.Pos1, eSwitch.Run)    '工位1转动   
        _MOVE(ePostion.Pos2, eSwitch.Run, eDirect.P) '工位2转
        _MOVE(ePostion.Pos1, eSwitch.Off)    '工位1停止
        _MOVE(ePostion.Pos2, eSwitch.Off)    '工位2停止
        'Dim Pos As String = "00 04 02 d3"
        'sndBuffer = AxisNum & " 10 00 1b 00 05 0a 0e 10 " & Acc & " " & Dec & " " & Vel & " " & Pos & " 74 aa"
        sndBuffer = AxisNum & " 10 00 1B 00 05 0A 0E 10 0E 10 06 90 00 04 02 D3 A5 1D"
        do_Comm_Send(sndBuffer)
        sndBuffer = AxisNum & " 06 00 7c 00 67 08 7c"
        do_Comm_Send(sndBuffer)
        _whileMotionDone()
        'Dim Pos As String = "00 01 0b de"
        'sndBuffer = AxisNum & " 10 00 1b 00 05 0a 0e 10 " & Acc & " " & Dec & " " & Vel & " " & Pos & " 74 aa"
        sndBuffer = AxisNum & " 10 00 1B 00 05 0A 0E 10 0E 10 06 90 00 01 0B DE 72 89"
        do_Comm_Send(sndBuffer)
        sndBuffer = AxisNum & " 06 00 7c 00 67 08 7c"
        do_Comm_Send(sndBuffer)
        _whileMotionDone()
        _MOVE(ePostion.Pos2, eSwitch.Run, eDirect.P) '工位2转
        _MOVE(ePostion.Pos3, eSwitch.Run, eDirect.P) '工位3转
        _MOVE(ePostion.Pos2, eSwitch.Off, eDirect.P) '工位2停
        _MOVE(ePostion.Pos3, eSwitch.Off, eDirect.P) '工位3停
    End Sub
    Dim _client As New System.IO.Ports.SerialPort
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
        Dim _rec As String = "" '0300010001D44E
        For i As Integer = 0 To _len - 1
            _rec = _rec & Convert.ToString(_rcvStr(i), 16).PadLeft(2, "0")
        Next
        Return _rec
    End Function
    'Declare Function DO_WriteLine Lib "Pci-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal LLine As Short, ByVal Value As Short) As Short
    Function _MOVE(ByVal pos As ePostion, ByVal SW As eSwitch, Optional ByVal di As eDirect = eDirect.Free) As Integer
        Dim No As eIO_Idx
        Select Case pos
            Case ePostion.Pos1
                If (di = eDirect.Mes) Then
                    No = eIO_Idx.posi_01_10
                Else
                    No = eIO_Idx.posi_01_06
                End If
            Case ePostion.Pos2
                If (di = eDirect.N) Then
                    No = eIO_Idx.posi_02_08
                Else
                    No = eIO_Idx.posi_02_07
                End If
            Case ePostion.Pos3
                If (di = eDirect.Mes) Then
                    No = eIO_Idx.posi_03_11
                Else
                    No = eIO_Idx.posi_03_09
                End If
        End Select
        _ret = DO_WriteLine(0, 0, No, SW)
        Return _ret
    End Function
    Private Sub _whileMotionDone()
        Dim AxisMotionDone As Boolean = False
        Dim _ReadStatus As String = AxisNum & " 03 00 01 00 01 D4 4E"
        Do
            Dim AxisReadstatus As String = do_Comm_Send(_ReadStatus) ' AxisReadstatus = ?
            Dim count As Integer = InStr(AxisReadstatus, "0302", CompareMethod.Binary)
            If count > 0 Then
                Dim ReadStatus As Integer = Convert.ToInt32(Mid(AxisReadstatus, count + 4, 4), 16)
                If ReadStatus And 2 ^ 3 Then
                    AxisMotionDone = True '运行到位信号
                Else
                    AxisMotionDone = False
                End If
            Else
                count = InStr(AxisReadstatus, "03 02", CompareMethod.Binary)
                '//
            End If
        Loop Until AxisMotionDone = True
    End Sub
End Class