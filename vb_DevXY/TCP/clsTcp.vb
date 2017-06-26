Imports System.Net.Sockets
Imports System.Text
Imports System.Net
Imports System.Threading
Imports System.IO
Public Class clsTcp
    Public Shared FAIL As String = "Fail"
    Dim _r_Tcp5 As Socket
    Dim _f_Tcp8 As Socket
    Dim _ip As String
    Dim _port As Integer
    Dim _ret As String
    Public Sub doConnectionR5(ByVal vIP As String, ByVal vPort As Integer)
        Try
            '192.168.0.1   5000
            Dim _ip As New IPEndPoint(Net.IPAddress.Parse(vIP), vPort)
            _r_Tcp5 = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            If _r_Tcp5.Connected = False Then
                _r_Tcp5.Connect(_ip)
            End If
        Catch ex As Exception
            MessageBox.Show("TCP通信失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End Try
    End Sub
    Public Sub doConnectionF8(ByVal vIP As String, ByVal vPort As Integer)
        Try
            '192.168.0.1   8000
            Dim _ip As New IPEndPoint(Net.IPAddress.Parse(vIP), vPort)
            _f_Tcp8 = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            If _f_Tcp8.Connected = False Then
                _f_Tcp8.ReceiveTimeout = 2000
                _f_Tcp8.SendTimeout = 2000
                _f_Tcp8.Connect(_ip)
                RobotAStartrun = True

            End If
        Catch ex As Exception
            MessageBox.Show("TCP通信失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End Try
    End Sub
    Public Function SendR5(ByVal vStr As String) As String
        Dim _res As String = ""
        Try
            If _r_Tcp5.Connected = True Then
                _r_Tcp5.SendTimeout = 2000
                _r_Tcp5.ReceiveTimeout = 2000
                _r_Tcp5.Send(Encoding.ASCII.GetBytes(vStr + vbCr + vbLf))
                Dim _bytes() As Byte = New Byte(2096) {}
                Dim _len As Integer
                _len = _r_Tcp5.Receive(_bytes)
                _res = Encoding.ASCII.GetString(_bytes)
            Else
                _res = FAIL
            End If
        Catch ex As Exception
            _res = FAIL
        End Try
        Return _res
    End Function
    Public Function SendF8(ByVal vStr As String) As String
        Dim _res As String = ""
        Try
            If _f_Tcp8.Connected = True Then
                _f_Tcp8.SendTimeout = 2000
                _f_Tcp8.ReceiveTimeout = 2000
                _f_Tcp8.Send(Encoding.ASCII.GetBytes(vStr + vbCr + vbLf))
                Dim _bytes() As Byte = New Byte(2096) {}
                Dim _len As Integer
                _len = _f_Tcp8.Receive(_bytes)
                _res = Encoding.ASCII.GetString(_bytes)
            Else
                _res = FAIL
            End If
        Catch ex As SocketException
            _res = FAIL
            Console.WriteLine(ex.Message)
        Catch ex As Exception
            _res = FAIL
            Console.WriteLine(ex.Message)
        End Try
        Return _res
    End Function
End Class
