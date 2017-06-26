Public Class frm204c_01
    Dim _ret As Integer
    Dim K4 As Integer = 10000
    Dim _Speed As Integer = 50 * K4
    Private Sub frm204c_01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Protected _Axis_ID As Integer = 0
        _ret = APS_initial(0, 0)
        For _Axis_ID = 0 To 2
            _ret = APS_set_servo_on(_Axis_ID, 1)
        Next
    End Sub
    Private Sub btnLoop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoop.Click
        For _Axis_ID = 0 To 2
            _ret = APS_home_move(_Axis_ID)
        Next
        For _Axis_ID = 0 To 2
            _ret = _motion_status_5(_Axis_ID)
        Next
        do_Square_4()
        do_Circle_1()
        do_Triangle_3()
    End Sub
    Private Function _motion_status_5(ByVal Axis_ID As Integer) As Integer
        Do
            _ret = APS_motion_status(Axis_ID)
        Loop Until _ret And 2 ^ 5
        Return _ret
    End Function
    Private Sub do_Square_4()
        _ret = APS_motion_io_status(0)
        If _ret And 2 ^ 3 Then
            _ret = APS_absolute_move(0, 16 * K4, _Speed)
            _motion_status_5(0)
        End If
        _ret = APS_motion_io_status(1)
        If _ret And 2 ^ 3 Then
            _ret = APS_absolute_move(1, 12 * K4, _Speed)
            _motion_status_5(1)
        End If
        _ret = APS_motion_io_status(1)
        If _ret And 2 ^ 3 Then
            _ret = APS_absolute_move(0, 0, _Speed)
            _motion_status_5(0)
        End If
        _ret = APS_motion_io_status(1)
        If _ret And 2 ^ 3 Then
            _ret = APS_absolute_move(1, 0, _Speed)
            _motion_status_5(1)
        End If
    End Sub
    Private Sub do_Circle_1()
        Dim Axis_ID_Array() As Integer = New Integer(1) {0, 1}
        Dim CenterArray() As Integer = New Integer(1) {8 * K4, 2 * K4}
        _ret = APS_absolute_arc_move(2, Axis_ID_Array, CenterArray, _Speed, 360)
        _motion_status_5(0)
    End Sub
    Private Sub do_Triangle_3()
        Dim _Axis_ID_Array As Integer() = New Integer(1) {0, 1}
        Dim _Position_Array() As Integer = Nothing
        For i As Integer = 1 To 3
            Select Case i
                Case 1
                    _Position_Array = {10 * K4, 10 * K4}
                Case 2
                    _Position_Array = {20 * K4, 0}
                Case 3
                    _Position_Array = {0, 0}
            End Select
            _ret = APS_absolute_linear_move(2, _Axis_ID_Array, _Position_Array, _Speed)
            _motion_status_5(0)
        Next
    End Sub
End Class