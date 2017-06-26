Imports System.Threading
Public Class frm204c
    Dim ret As Long
    Dim picArr As New ArrayList
    Dim K4 As Integer = 10000
    Dim Speed As Integer = 50 * K4
    Dim sT As DateTime
    Dim eT As DateTime
    Dim T_IOstatus As New Thread(AddressOf GetIOStatus)
    Dim T_Status As New Thread(AddressOf GetStatus)
    'Dim T_Loop As New Thread(AddressOf TLoop)
    'Initial
    Private Sub cmdIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIni.Click
        Ini()
        Servo_on()
    End Sub
    'Home
    Private Sub cmdHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHome.Click
        APS_set_axis_param(cmbAxis.Text, PRA_HOME_VM, 8.5 * K4) '//
        APS_set_axis_param(cmbAxis.Text, PRA_HOME_VO, K4)
        ret = APS_home_move(cmbAxis.Text)
        Me.labStatus.Text = ret
        'GetIOStatus()
    End Sub
    'Loop
    Private Sub btnLoop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoop.Click
        sT = Now
        Do
            Homing()
            cmdSquare_Click(sender, e)
            cmdCircle_Click(sender, e)
            cmdTriangle_Click(sender, e)
            Thread.Sleep(2000)
            Application.DoEvents()
            'Exit Do
        Loop
    End Sub
    Private Sub TLoop()
        Homing()
        Square()
        Circle()
        Triangle()
        Thread.Sleep(1000)
    End Sub
    Private Sub cmdSquare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSquare.Click
        Square()
    End Sub
    Private Sub Square()
        Dim ioStatus As Integer
        ioStatus = APS_motion_io_status(0)
        If ioStatus And 2 ^ 3 Then
            If rd_A.Checked Then
                ret = APS_absolute_move(0, 16 * K4, Speed)
            ElseIf rd_R.Checked Then
                ret = APS_relative_move(0, 16 * K4, Speed)
            End If
            Me.labStatus.Text = ret
        End If
        MStatus(0)
        ioStatus = APS_motion_io_status(1)
        If ioStatus And 2 ^ 3 Then
            If rd_A.Checked Then
                ret = APS_absolute_move(1, 12 * K4, Speed)
            ElseIf rd_R.Checked Then
                ret = APS_relative_move(1, 12 * K4, Speed)
            End If
            Me.labStatus.Text = ret
        End If
        MStatus(1)
        If rd_A.Checked Then
            ret = APS_absolute_move(0, 0, Speed)
        ElseIf rd_R.Checked Then
            ret = APS_relative_move(0, 0, Speed)
        End If
        Me.labStatus.Text = ret
        MStatus(0)
        If rd_A.Checked Then
            ret = APS_absolute_move(1, 0, Speed)
        ElseIf rd_R.Checked Then
            ret = APS_relative_move(1, 0, Speed)
        End If
        Me.labStatus.Text = ret
        MStatus(1)
    End Sub
    Private Sub cmdCircle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCircle.Click
        Circle()
    End Sub
    Private Sub Circle()
        Dim Axis_ID_Array() As Integer = New Integer(1) {0, 1}
        Dim CenterArray() As Integer = New Integer(1) {8 * K4, 2 * K4}
        If rd_A.Checked Then
            ret = APS_absolute_arc_move(2, Axis_ID_Array, CenterArray, Speed, 360)
        ElseIf rd_R.Checked Then
            ret = APS_relative_arc_move(2, Axis_ID_Array, CenterArray, Speed, 360)
        End If
        Me.labStatus.Text = ret
        MStatus(0)
    End Sub
    Private Sub cmdTriangle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTriangle.Click
        Triangle()
    End Sub
    Private Sub Triangle()
        Dim axis As Integer() = New Integer(1) {0, 1}
        Dim pos1() As Integer
        For i As Integer = 1 To 3
            Select Case i
                Case 1
                    pos1 = {10 * K4, 10 * K4}
                Case 2
                    pos1 = {20 * K4, 0}
                Case 3
                    pos1 = {0, 0}
            End Select
            If rd_A.Checked Then
                ret = APS_absolute_linear_move(2, axis, pos1, Speed)
            ElseIf rd_R.Checked Then
                ret = APS_relative_linear_move(2, axis, pos1, Speed)
            End If
            Me.labStatus.Text = ret
            MStatus(0)
        Next
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        ret = APS_close()
        Me.labStatus.Text = ret
    End Sub
    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Dim dlg As New OpenFileDialog
        dlg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
        dlg.FilterIndex = 1
        dlg.ShowDialog()
        ret = APS_load_param_from_file(dlg.FileName)
        Me.labStatus.Text = ret
    End Sub
    Private Sub cmdServo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServo.Click
        ret = APS_set_servo_on(cmbAxis.Text, 1)
        Me.labStatus.Text = ret
    End Sub
    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        ret = APS_stop_move(cmbAxis.Text)
        Me.labStatus.Text = ret
        'GetIOStatus()
    End Sub
    Private Sub cmdEmg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmg.Click
        ret = APS_emg_stop(cmbAxis.Text)
        Me.labStatus.Text = ret
    End Sub
    Private Sub cmdLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLine.Click
        ret = APS_ptp(cmbAxis.Text, 0, -120000, Nothing)
        Me.labStatus.Text = ret
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        picArr.Add(PictureBox1)
        picArr.Add(PictureBox2)
        picArr.Add(PictureBox3)
        picArr.Add(PictureBox4)
        picArr.Add(PictureBox5)
        picArr.Add(PictureBox6)
        picArr.Add(PictureBox7)
        picArr.Add(PictureBox8)
        picArr.Add(PictureBox9)
        picArr.Add(PictureBox10)
        picArr.Add(PictureBox11)
        picArr.Add(PictureBox12)
        picArr.Add(PictureBox13)
        picArr.Add(PictureBox14)
        picArr.Add(PictureBox15)
        picArr.Add(PictureBox16)
        picArr.Add(PictureBox17)
        picArr.Add(PictureBox18)
        picArr.Add(PictureBox19)
        picArr.Add(PictureBox20)
        picArr.Add(PictureBox21)
        picArr.Add(PictureBox22)
        picArr.Add(PictureBox23)
        picArr.Add(PictureBox24)
        picArr.Add(PictureBox25)
        'For Each contrl In Me.Controls
        '    If TypeName(contrl) = "PictureBox" Then
        '        Debug.Print(contrl.name)
        '    End If
        'Next
        Ini()
        Servo_on()
        T_IOstatus.Start()
        T_Status.Start()
        'T_Loop.Start()
        'Timer1.Enabled = True
        'sT = Now
    End Sub
    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        cmdClose_Click(sender, e)
        Servo_off()
    End Sub
    Private Sub Ini()
        ret = APS_initial(0, 0)
        Me.labStatus.Text = ret
    End Sub
    Private Sub Servo_on()
        For i As Integer = 0 To cmbAxis.Items.Count
            ret = APS_set_servo_on(i, 1)
            Me.labStatus.Text = ret
        Next
    End Sub
    Private Sub Servo_off()
        For i As Integer = 0 To cmbAxis.Items.Count
            ret = APS_set_servo_on(i, 0)
            Me.labStatus.Text = ret
        Next
    End Sub
    Private Sub Homing()
        For i As Integer = 0 To cmbAxis.Items.Count - 1
            ret = APS_home_move(i)
            Me.labStatus.Text = ret
        Next
        For i As Integer = 0 To cmbAxis.Items.Count
            MStatus(i)
        Next
    End Sub
    Private Sub MStatus(ByVal Axis As Integer)
        Do
            ret = APS_motion_status(Axis)
        Loop Until ret And 2 ^ 5
    End Sub
    Private Sub GetIOStatus()
        Do
            ret = APS_motion_io_status(0)
            For i = 0 To 10
                If ret And 2 ^ i Then
                    picArr(i).Image = My.Resources.Resources.LedRed
                Else
                    picArr(i).Image = My.Resources.Resources.LedOff
                End If
            Next
            Thread.Sleep(1000)
        Loop
    End Sub
    Private Sub GetStatus()
        Do
            ret = APS_motion_status(0)
            For i = 11 To 24
                If ret And 2 ^ i Then
                    picArr(i).Image = My.Resources.Resources.LedRed
                Else
                    picArr(i).Image = My.Resources.Resources.LedOff
                End If
            Next
            Thread.Sleep(1000)
        Loop
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim intdif As Integer
        eT = Now
        intdif = DateDiff("n", sT, eT)
        If intdif = 5 Then
            cmdClose_Click(sender, e)
        End If
    End Sub
    Private Sub btnUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUP.Click, btnRight.Click, btnLeft.Click, btnForward.Click, btnDown.Click, btnBackward.Click
        Dim Axis As Integer
        Dim intDis As Integer
        Select Case sender.name
            Case "btnRight"
                Axis = 0
                intDis = CInt(Me.txtDis.Text)
            Case "btnLeft"
                Axis = 0
                intDis = Val(Me.txtDistance.Text.Trim)
            Case "btnForward"
                Axis = 1
                intDis = Val(Me.txtDistance.Text.Trim)
            Case "btnBackward"
                Axis = 1
                intDis = Val(Me.txtDis.Text.Trim)
            Case "btnUP"
                Axis = 2
                intDis = Val(Me.txtDistance.Text.Trim)
            Case "btnDown"
                Axis = 2
                intDis = Val(Me.txtDis.Text.Trim)
        End Select
        If rdb_A.Checked Then
            ret = APS_absolute_move(Axis, intDis, 20 * K4)
        ElseIf rdb_R.Checked Then
            ret = APS_relative_move(Axis, intDis, 20 * K4)
        ElseIf rdb_V.Checked Then
            ret = APS_velocity_move(Axis, 20 * K4)
        End If
        Me.labStatus.Text = ret
        'GetIOStatus()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Homing()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Do
            Homing()
            PointZ()
            ret = APS_absolute_move(0, 16 * K4, Speed)
            Me.labStatus.Text = ret
            MStatus(0)
            PointZ()
            ret = APS_absolute_move(1, 12 * K4, Speed)
            Me.labStatus.Text = ret
            MStatus(1)
            PointZ()
            ret = APS_absolute_move(0, 0, Speed)
            Me.labStatus.Text = ret
            MStatus(0)
            PointZ()
            ret = APS_absolute_move(1, 0, Speed)
            Me.labStatus.Text = ret
            MStatus(1)
            PointZ()
            Thread.Sleep(1000)
        Loop
    End Sub
    Private Sub PointZ()
        ret = APS_absolute_move(2, -15 * K4, Speed)  'Z轴画点
        Me.labStatus.Text = ret
        MStatus(2)
        ret = APS_absolute_move(2, 0, Speed)
        MStatus(2)
    End Sub
End Class