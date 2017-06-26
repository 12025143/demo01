Imports System.Threading
Public Class clsEpsonCom
    Dim _strRet As String
    Dim _dao_Tcp As New clsTcp
    'L ..  R8 
    Public Function Read_PlugPoint_R8_L(ByVal T As String) As Double()
        Dim _P() As Double = Nothing
        Dim i As Integer = -1
        _strRet = _dao_Tcp.SendF8("L " & T)
        Dim Point_Str_Counter1 As Integer = InStrRev(_strRet, "L", -1)
        If Point_Str_Counter1 > 0 Then
            Dim _arr() As String = Split(_strRet, " ")
            If _arr.Length > 0 Then
                i += 1 : _P(i) = Val(_arr(1)) 'Cal_InsertX    插件点X
                i += 1 : _P(i) = Val(_arr(2)) ' Cal_InsertY   插件点Y
                i += 1 : _P(i) = Val(_arr(3)) 'Cal_InsertZ    插件点Z
                i += 1 : _P(i) = Val(_arr(4)) ' Cal_InsertU   插件点U
                i += 1 : _P(i) = Val(_arr(5)) 'Cal_InsertV    插件点V
                i += 1 : _P(i) = Val(_arr(6)) 'Cal_InsertW    插件点W
                i += 1 : _P(i) = Val(_arr(7)) 'ComName.RobotA_toolX    当前点X
                i += 1 : _P(i) = Val(_arr(8)) 'ComName.RobotA_toolY    当前点Y 
                i += 1 : _P(i) = Val(_arr(9)) 'ComName.RobotA_toolZ    当前点Z
                i += 1 : _P(i) = Val(_arr(10)) 'ComName.RobotA_toolU   当前点U
                i += 1 : _P(i) = Val(_arr(11)) 'ComName.RobotA_toolV   当前点V
                i += 1 : _P(i) = Val(_arr(12)) 'ComName.RobotA_toolW    当前点W
            End If
        Else
            Dim _result_dia As DialogResult = Windows.Forms.DialogResult.None
            _result_dia = MessageBox.Show("读取插件点失败，是否重试？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End If
        Return _P
    End Function
    'J Point .. (15)    R8
    Public Function Move_Btn_Click(ByVal Distance() As Double, Optional ByVal Move_tool As Integer = 0, Optional ByVal J4Val As Integer = 0, Optional ByVal J6Val As Integer = 0, Optional ByVal J1Val As Integer = 0, Optional ByVal J2Val As Integer = 0, Optional ByVal Hand As Integer = 0) As String
        Dim _aa As String = ""
        If Not (Distance(0) = 0 And Distance(1) = 0 And Distance(2) = 0) Then
            Dim sendstring As String = ""
            sendstring = "J Point " & _
                            Move_tool.ToString & " " & _
                            Distance(0).ToString & " " & Distance(1).ToString & " " & Distance(2).ToString & " " & _
                            Distance(3).ToString & " " & Distance(4).ToString & " " & Distance(5).ToString & " " & _
                            J1Val.ToString & " " & J2Val.ToString & " " & J4Val.ToString & " " & J6Val.ToString & " " & _
                            Hand.ToString
            _aa = _dao_Tcp.SendF8(sendstring)
            Return _aa
        Else
            Return ""
            MessageBox.Show("点参数不正确", "警告", MessageBoxButtons.OK)
        End If
    End Function
    '$login   $Reset   $Stop    $Start   $Start  R5
    Public Sub Robot_Start_TCP_R5()
        Dim _ret As String
        Dim recievedata As String
        recievedata = _dao_Tcp.SendR5("$login,123")
        _ret = GetStatus(recievedata, "#login,0")
        recievedata = _dao_Tcp.SendR5("$Reset")
        _ret = GetStatus(recievedata, "#Reset,0")
        recievedata = _dao_Tcp.SendR5("$Stop,0")
        _ret = GetStatus(recievedata, "#Stop,0")
        recievedata = _dao_Tcp.SendR5("$Start,0")
        _ret = GetStatus(recievedata, "#Start,0")
        recievedata = _dao_Tcp.SendR5("$Start,1")
        _ret = GetStatus(recievedata, "#Start,0")
    End Sub
    'return: P F D
    Public Function GetStatus(ByVal vRet As String, ByVal vVal As String) As String
        Dim counter15 As Integer = InStrRev(vRet, vVal, -1)
        If counter15 > 0 Then
            Return "P"
        ElseIf vRet = "Fail" Then
            Return "F"
            MessageBox.Show(vVal.Substring(2, InStr(vVal, ",") - 1) & "命令发送失败，请检查网络和控制器", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        ElseIf vRet = "Disconnect" Then
            Return "D"
            MessageBox.Show("未连接机械手控制器", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End If
        Return ""
    End Function
    '检查返回值， 非负则接收正确，-1：TCP收发数据不正确  -2:TCP未连接
    Public Function checkResult(ByVal vRet As String, ByVal vVal As String) As Integer
        Dim _res As Integer = InStrRev(vRet, vVal, -1)
        If vRet = "Fail" Then
            Return -1
            MessageBox.Show(vVal.Substring(2, InStr(vVal, ",") - 1) & "命令发送失败，请检查网络和控制器", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        ElseIf vRet = "Disconnect" Then
            Return -2
            MessageBox.Show("未连接机械手控制器", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        Else
            Return _res
        End If
    End Function
End Class
