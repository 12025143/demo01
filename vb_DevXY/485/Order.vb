Public Class Order
    Function ReadStatus(ByVal M_ID As String, ByVal Axisnum As Integer) As String
        Dim _buf(18) As Byte
        M_ID = M_ID & Axisnum
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H3
        _buf(2) = &H0
        _buf(3) = &H1
        _buf(4) = &H0
        _buf(5) = &H1
        Dim CRCstring As String = ""
        For i As Integer = 0 To 5
            CRCstring = CRCstring & Convert.ToString(_buf(i), 16).PadLeft(2, "0")
        Next
        Return do_PutBuffer_Dict(M_ID, _buf, 6)
    End Function
    Function home_Set_Pos(ByVal M_ID As String, ByVal Axisnum As Integer) As String
        Dim _buf(18) As Byte
        M_ID = M_ID & Axisnum
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H10
        _buf(2) = &H0
        _buf(3) = &H7C
        _buf(4) = &H0
        _buf(5) = &H2
        _buf(6) = &H4
        _buf(7) = &H0
        _buf(8) = &HA5 'SP
        _buf(9) = &H0
        _buf(10) = &H0
        Return do_PutBuffer_Dict(M_ID, _buf, 11)
    End Function
    Function home_Set_PosA(ByVal M_ID As String, ByVal Axisnum As Integer) As String
        Dim _buf(18) As Byte
        M_ID = M_ID & Axisnum
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H10
        _buf(2) = &H0
        _buf(3) = &H7C
        _buf(4) = &H0
        _buf(5) = &H2
        _buf(6) = &H4
        _buf(7) = &H0
        _buf(8) = &H98 'SP
        _buf(9) = &H0
        _buf(10) = &H0
        Return do_PutBuffer_Dict(M_ID, _buf, 11)
    End Function
    Function ReadPOS(ByVal M_ID As String, ByVal Axisnum As Integer) As String
        Dim _buf(18) As Byte
        M_ID = M_ID & Axisnum
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H3
        _buf(2) = &H0
        _buf(3) = &H8
        _buf(4) = &H0
        _buf(5) = &H2
        Return do_PutBuffer_Dict(M_ID, _buf, 6)
    End Function
    Function StopMove(ByVal M_ID As String, ByVal Axisnum As Integer) As String
        Dim _buf(18) As Byte
        M_ID = M_ID & Axisnum
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H6
        _buf(2) = &H0
        _buf(3) = &H7C
        _buf(4) = &H0
        _buf(5) = &HE1
        Return do_PutBuffer_Dict(M_ID, _buf, 6)
    End Function
    Function OutputLine(ByVal M_ID As String, ByVal Axisnum As Integer, ByVal outputnum As Integer, ByVal Condition As Integer) As String
        Dim _buf(18) As Byte
        M_ID = M_ID & Axisnum
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H10
        _buf(2) = &H0
        _buf(3) = &H7C
        _buf(4) = &H0
        _buf(5) = &H3
        _buf(6) = &H6
        _buf(7) = &H0
        _buf(8) = &H8B '输出的功能码
        _buf(9) = &H0
        Select Case outputnum
            Case 1
                _buf(10) = &H31
            Case 2
                _buf(10) = &H32
            Case 3
                _buf(10) = &H33
            Case 4
                _buf(10) = &H34
        End Select
        _buf(11) = &H0
        If Condition = 0 Then
            _buf(12) = &H4C
        ElseIf Condition = 1 Then
            _buf(12) = &H48
        End If
        Return do_PutBuffer_Dict(M_ID, _buf, 13)
    End Function
    Function SeekHome(ByVal M_ID As String, ByVal Axisnum As Integer, ByVal inputnum As Integer, ByVal Condition As Integer) As String
        Dim _buf(18) As Byte
        M_ID = M_ID & Axisnum
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H10
        _buf(2) = &H0
        _buf(3) = &H7C
        _buf(4) = &H0
        _buf(5) = &H3
        _buf(6) = &H6
        _buf(7) = &H0
        _buf(8) = &H6E
        _buf(9) = &H0
        Select Case inputnum
            Case 1
                _buf(10) = &H31
            Case 2
                _buf(10) = &H32
            Case 3
                _buf(10) = &H33
            Case 4
                _buf(10) = &H34
        End Select
        _buf(11) = &H0
        If Condition = 0 Then
            _buf(12) = &H4C
        ElseIf Condition = 1 Then
            _buf(12) = &H48
        End If
        Return do_PutBuffer_Dict(M_ID, _buf, 13)
    End Function
    Function MotorOn(ByVal M_ID As String, ByVal Axisnum As Integer) As String
        M_ID = M_ID & Axisnum
        Dim _buf(18) As Byte
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H6
        _buf(2) = &H0
        _buf(3) = &H7C
        _buf(4) = &H0
        _buf(5) = &H9F
        Return do_PutBuffer_Dict(M_ID, _buf, 6)
    End Function
    Function MotorOff(ByVal M_ID As String, ByVal Axisnum As Integer) As String
        M_ID = M_ID & Axisnum
        Dim _buf(18) As Byte
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H6
        _buf(2) = &H0
        _buf(3) = &H7C
        _buf(4) = &H0
        _buf(5) = &H9E
        Return do_PutBuffer_Dict(M_ID, _buf, 6)
    End Function
    Function MotorAlarmReset(ByVal M_ID As String, ByVal Axisnum As Integer) As String
        M_ID = M_ID & Axisnum
        Dim _buf(18) As Byte
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H6
        _buf(2) = &H0
        _buf(3) = &H7C
        _buf(4) = &H0
        _buf(5) = &HBA
        Return do_PutBuffer_Dict(M_ID, _buf, 6)  '10 15 45|XX XX XX
    End Function
    Function SetRegisterSub(ByVal M_ID As String, ByVal Axisnum As Integer, ByVal addr As Integer, ByVal valuea As Integer) As String
        M_ID = M_ID & Axisnum
        Dim _buf(18) As Byte
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H10
        _buf(2) = &H0
        Dim _aa As Integer
        _aa = (addr - 1) * 2 + 60
        _buf(3) = Val("&H" + DecToHex(_aa, 2))
        _buf(4) = &H0
        _buf(5) = &H2
        _buf(6) = &H4
        Dim changstring As String = DecToHex(valuea, 8) '设置速度
        _buf(7) = Val("&H" + Mid(changstring, 1, 2))
        _buf(8) = Val("&H" + Mid(changstring, 3, 2))
        _buf(9) = Val("&H" + Mid(changstring, 5, 2))
        _buf(10) = Val("&H" + Mid(changstring, 7, 2))
        Return do_PutBuffer_Dict(M_ID, _buf, 11)
    End Function
    Function Home_Dir(ByVal M_ID As String, ByVal Axisnum As Integer, ByVal Vel As Double, ByVal Pos As Double, ByVal Acc As Long, ByVal Dec As Long) As String
        M_ID = M_ID & Axisnum
        Dim _buf(18) As Byte
        Dim changstring As String
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H10
        _buf(2) = &H0
        _buf(3) = &H1B
        _buf(4) = &H0
        _buf(5) = &H5
        _buf(6) = &HA
        changstring = DecToHex(Acc, 4) '设置加速度
        _buf(7) = Val("&H" + Mid(changstring, 1, 2))
        _buf(8) = Val("&H" + Mid(changstring, 3, 2))
        changstring = DecToHex(Dec, 4) '设置减速度
        _buf(9) = Val("&H" + Mid(changstring, 1, 2))
        _buf(10) = Val("&H" + Mid(changstring, 3, 2))
        changstring = DecToHex(Vel, 4) '设置速度
        _buf(11) = Val("&H" + Mid(changstring, 1, 2))
        _buf(12) = Val("&H" + Mid(changstring, 3, 2))
        changstring = DecToHex(Pos, 8) '设置位置
        _buf(13) = Val("&H" + Mid(changstring, 1, 2))
        _buf(14) = Val("&H" + Mid(changstring, 3, 2))
        _buf(15) = Val("&H" + Mid(changstring, 5, 2))
        _buf(16) = Val("&H" + Mid(changstring, 7, 2))
        Return do_PutBuffer_Dict(M_ID, _buf, 17)
    End Function
    Function Position_Set_Pos(ByVal M_ID As String, ByVal Axisnum As Integer, ByVal Vel As Double, ByVal Pos As Double, ByVal Acc As Long, ByVal Dec As Long) As String
        M_ID = M_ID & Axisnum
        Dim _buf(18) As Byte
        Dim changstring As String
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H10
        _buf(2) = &H0
        _buf(3) = &H1B
        _buf(4) = &H0
        _buf(5) = &H5
        _buf(6) = &HA
        changstring = DecToHex(Acc, 4) '设置加速度
        _buf(7) = Val("&H" + Mid(changstring, 1, 2))
        _buf(8) = Val("&H" + Mid(changstring, 3, 2))
        changstring = DecToHex(Dec, 4) '设置减速度
        _buf(9) = Val("&H" + Mid(changstring, 1, 2))
        _buf(10) = Val("&H" + Mid(changstring, 3, 2))
        changstring = DecToHex(Vel, 4) '设置速度
        _buf(11) = Val("&H" + Mid(changstring, 1, 2))
        _buf(12) = Val("&H" + Mid(changstring, 3, 2))
        changstring = DecToHex(Pos, 8) '设置位置
        _buf(13) = Val("&H" + Mid(changstring, 1, 2))
        _buf(14) = Val("&H" + Mid(changstring, 3, 2))
        _buf(15) = Val("&H" + Mid(changstring, 5, 2))
        _buf(16) = Val("&H" + Mid(changstring, 7, 2))
        Dim CRCstring As String = ""
        For i As Integer = 0 To 16
            CRCstring = CRCstring & Convert.ToString(_buf(i), 16).PadLeft(2, "0")
        Next
        Dim Countstring As String = do_CRC(CRCstring)
        _buf(17) = Val("&H" + Mid(Countstring, 1, 2))
        _buf(18) = Val("&H" + Mid(Countstring, 3, 2))
        Dim Sendstringa As String = ""
        For i As Integer = 0 To 18
            Sendstringa = Sendstringa & Convert.ToString(_buf(i), 16).PadLeft(2, "0") & " "
        Next
        Position_Set_Pos = Sendstringa
    End Function
    Function Position_A_Move(ByVal M_ID As String, ByVal Axisnum As Integer, ByVal Vel As Double, ByVal Pos As Double, ByVal Acc As Long, ByVal Dec As Long) As String
        M_ID = "M_ID" & Axisnum
        Dim _buf(18) As Byte
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H6
        _buf(2) = &H0
        _buf(3) = &H7C
        _buf(4) = &H0
        _buf(5) = &H67
        Return do_PutBuffer_Dict(M_ID, _buf, 6, Position_Set_Pos("Position_Set_Pos", Axisnum, Vel, Pos, Acc, Dec))  '
    End Function
    Function Position_R_Move(ByVal M_ID As String, ByVal Axisnum As Integer, ByVal Vel As Double, ByVal Pos As Double, ByVal Acc As Long, ByVal Dec As Long) As String
        M_ID = M_ID & Axisnum
        Dim _buf(18) As Byte
        _buf(0) = Val("&H" + DecToHex(Axisnum, 2))
        _buf(1) = &H6
        _buf(2) = &H0
        _buf(3) = &H7C
        _buf(4) = &H0
        _buf(5) = &H66
        Return do_PutBuffer_Dict(M_ID, _buf, 6, Position_Set_Pos("Position_Set_Pos", Axisnum, Vel, Pos, Acc, Dec))  '
    End Function '-----------------
    Function do_PutBuffer_Dict(ByVal id As String, ByRef buf As Byte(), ByVal crc_loc As Integer, Optional ByVal pre_send As String = "") As String
        Dim _totol As String = ""
        For i As Integer = 0 To crc_loc - 1
            _totol = _totol & Convert.ToString(buf(i), 16).PadLeft(2, "0")
        Next
        Dim _crc As String = do_CRC(_totol)
        buf(crc_loc) = Val("&H" + Mid(_crc, 1, 2))
        crc_loc = crc_loc + 1
        buf(crc_loc) = Val("&H" + Mid(_crc, 3, 2))
        Dim _bufstr As String = ""
        For i As Integer = 0 To crc_loc
            _bufstr = _bufstr & Convert.ToString(buf(i), 16).PadLeft(2, "0") & " "
        Next
        If (Not String.IsNullOrEmpty(pre_send)) Then
            _bufstr = pre_send + "|" + _bufstr
        End If
        Return _bufstr
    End Function
    Function do_CRC(ByVal STR1 As String) As String
        Dim CRCREG As Long
        Dim MVAL As Long
        Dim R As Integer
        CRCREG = 65535
        For R = 1 To Len(STR1) Step 2
            MVAL = Val("&H" + Mid(STR1, R, 2))
            CRCREG = CRCREG Xor MVAL
            CRCREG = CRCREG And 65535
            For T = 1 To 8 Step 1
                If (CRCREG And &H1) Then
                    CRCREG = (CRCREG \ 2) Xor &HA001
                    CRCREG = CRCREG And 65535
                Else
                    CRCREG = CRCREG \ 2
                    CRCREG = CRCREG And 65535
                End If
            Next
        Next
        Dim A As Long
        Dim B As Long
        A = CRCREG And 255
        B = CRCREG And 65280
        A = A * 256
        B = B / 256
        If (A + B) < 16 Then
            do_CRC = "000" + Hex(A + B)
        ElseIf (A + B) < 256 Then
            do_CRC = "00" + Hex(A + B)
        ElseIf (A + B) < 4096 Then
            do_CRC = "0" + Hex(A + B)
        Else
            do_CRC = Hex(A + B)
        End If
    End Function
    Function DecToHex(ByVal num As Long, ByVal Bitnum As Integer) As String
        Dim bb As String
        bb = Convert.ToString(num, 16)
        DecToHex = bb.PadLeft(Bitnum, "0")
        DecToHex = Mid(DecToHex, Len(DecToHex) - Bitnum + 1)
    End Function
End Class
