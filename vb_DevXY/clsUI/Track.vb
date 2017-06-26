Imports System.Threading
Public Class Track
    Dim HadChangProduct As Boolean = False
    Dim ord As New Order
    Dim AxisMotionDone As Boolean = False
    Dim _ret As Integer
    Dim _client As New System.IO.Ports.SerialPort
    Dim sndBuffer As String = ""
    Private Sub btnP1Homing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP1Homing.Click
        _ret = DO_WriteLine(0, 0, 6, 0)    '工位1  皮带 电机停止
        If HadChangProduct Then '断言：有切换型号   ProductNo.length > 0 ==> HadChangProduct
            HadChangProduct = Not HadChangProduct ' HadChangProduct = !HadChangProduct 
            '轨道变到"最大宽度"
            sndBuffer = "04 10 00 1B 00 05 0A 02 58 02 58 09 60 FF FF FF FF EA A2" ' Home_Dir： paras <==  vel acc del dic
            do_Comm_Send(sndBuffer)
            sndBuffer = "04 10 00 7C 00 03 06 00 6E 00 31 00 4C 91 62"  'SeekHome:  Action(paras)
            do_Comm_Send(sndBuffer)
            GetStatus() '断言："最大宽度" ==> AxisMotionDone= GetStatus() 
            'home_Set_Pos1|01 10 00 7c 00 02 04 00 a5 00 00 e4 fd 
            'home_Set_Pos2|02 10 00 7c 00 02 04 00 a5 00 00 eb b9 
            'home_Set_Pos3|03 10 00 7c 00 02 04 00 a5 00 00 ef 45 
            'home_Set_Pos4|04 10 00 7c 00 02 04 00 a5 00 00 f5 31 
            'home_Set_Pos5|05 10 00 7c 00 02 04 00 a5 00 00 f1 cd 
            sndBuffer = "04 10 00 7C 00 02 04 00 A5 00 00 F5 31" 'home_Set_Pos
            do_Comm_Send(sndBuffer)
            sndBuffer = "04 10 00 1B 00 05 0A 0E 10 0E 10 04 B0 00 03 5B 60 BE 8C" 'Position_A_Move 间距皮带移动到"设定间距"
            do_Comm_Send(sndBuffer)
            sndBuffer = "04 06 00 7C 00 67 09 AD"
            do_Comm_Send(sndBuffer)
            GetStatus()
        End If
    End Sub
    Private Sub btnP2Homing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP2Homing.Click
        _ret = DO_WriteLine(0, 0, 6, 0)   '工位1停止
        _ret = DO_WriteLine(0, 0, 7, 0)  '工位2正转停止
        sndBuffer = "05 10 00 1B 00 05 0A 02 58 02 58 09 60 FF FF FF FF BB 32"   'Home_Dir
        do_Comm_Send(sndBuffer)
        sndBuffer = "05 10 00 7C 00 03 06 00 6E 00 31 00 4C 93 E3"    ' SeekHome  定位电机回原点
        do_Comm_Send(sndBuffer)
        GetStatus()
        If AxisMotionDone = True Then
            'home_Set_Pos1|01 10 00 7c 00 02 04 00 a5 00 00 e4 fd 
            'home_Set_Pos2|02 10 00 7c 00 02 04 00 a5 00 00 eb b9 
            'home_Set_Pos3|03 10 00 7c 00 02 04 00 a5 00 00 ef 45 
            'home_Set_Pos4|04 10 00 7c 00 02 04 00 a5 00 00 f5 31 
            'home_Set_Pos5|05 10 00 7c 00 02 04 00 a5 00 00 f1 cd 
            sndBuffer = "05 10 00 7C 00 02 04 00 A5 00 00 F1 CD" 'home_Set_Pos
            do_Comm_Send(sndBuffer)
            Dim di_6 As Integer
            DI_ReadLine(0, 0, 8, di_6) '检测工位2定位机构处是否有板
            If di_6 = 1 Then
                '判断插件是否已完成，完成走下一步
            End If
            AxisMotionDone = False
        End If
    End Sub
    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        If HadChangProduct = False Then
            HadChangProduct = True
        End If
    End Sub
    Private Sub btnP3Homing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP3Homing.Click
        DO_WriteLine(0, 0, 9, 0)   '工位3  皮带 电机停止
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
        Thread.Sleep(5)
        Return _rec
    End Function
    Private Sub GetStatus()
        Dim _AxisReadstatus As String
        Dim _ReadStatus As String
        '_ReadStatus = ord.ReadStatus("ReadStatus", AxisNum) '读取状态
        ''_ReadStatus = ord.ReadPOS("ReadPOS", AxisNum)  '读位置  
        'AxisReadstatus = do_Comm_Send(_ReadStatus)
        Do
            ' Axis/工位1=04  Axis/工位2=05  
            _ReadStatus = "04 03 00 01 00 01 D5 9F" ' " ReadStatus  05 03 00 01 00 01 D4 4E"  
            _AxisReadstatus = do_Comm_Send(_ReadStatus) ' AxisReadstatus =0403020009B442    0503020009XXXX
            Dim count As Integer = InStr(_AxisReadstatus, "0302", CompareMethod.Binary)
            If count > 0 Then
                Dim ReadStatus As Integer = Convert.ToInt32(Mid(_AxisReadstatus, count + 4, 4), 16) 'B442
                AxisMotionDone = ReadStatus And 2 ^ 3 '运行到位信号
            End If
        Loop Until AxisMotionDone
    End Sub
    Private Sub btnP1Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP1Action.Click
    End Sub
    Private Sub btnP2Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP2Action.Click
    End Sub
    Private Sub btnP3Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP3Action.Click
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        AxisMotionDone = CheckBox1.Checked
    End Sub
End Class