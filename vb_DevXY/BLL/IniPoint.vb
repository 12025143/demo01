
Imports System.IO
Imports FAIM_Entitys

Public Class IniPoint

    'Dim gRobotset As New clsRobotSet
    'Dim gRobotHead As New List(Of RobotHead)
    'Dim grobotSetPoint As New clsRobotSetPoint
    'Dim gxiantiPra As New track_Data
    'Dim gRobotset As clsRobotSet
    'Dim gallpoints As clsAllPoints
    Dim gRobotActionData As New clsrobotAction_Data '机器人动作线程的数据部分


    Dim SendCADPinX(40) As Double  '取顶针CAD数据'EEE
    Dim SendCADPinY(40) As Double
    Dim SendCADMark2_x As Double
    Dim SendCADMark2_y As Double
    Dim SendCADInsertX(40) As Double
    Dim SendCADInsertY(40) As Double
    Dim Robot_Send_String(553) As String '机械手动作时，要发送的字符
    'Dim gallpoints As New clsAllPoints
    'Dim gclsOrderList As New clsOrderList
    'Dim mproductName As String
    Dim m_tcp8 As clsTcp
    Dim m_tcp5 As clsTcp
    Dim dao_Epson As New clsEpsonCom

    Dim m_data As New clsSetUpFileObj
    Dim m_Load As New clsSetUpFile_DAL


    Sub New(ByVal tcp5 As clsTcp, ByVal tcp8 As clsTcp)
        m_tcp5 = tcp5
        m_tcp8 = tcp8
    End Sub

    Sub ReadData(ByVal proName As String)
        m_data = m_Load.LoadRobotFiles(proName)
        RefreshData()
    End Sub


    Sub RefreshData()
        gRobotActionData.ZhaozhiUseNum.Clear()
        For index = 1 To 40
            gRobotActionData.ZhaozhiUseNum.Add(m_data.obj1.insertObject(index).handNum)
        Next
    End Sub





    Private Sub Cal_CAD_XY1()
        SendCADMark2_x = Math.Round(Math.Sqrt((m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X) ^ 2 + (m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y) ^ 2), 3) '两Mark点的距离
        If Math.Round(Math.Atan2((m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y), (m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X)) * 180 / 3.14, 3) < 0 Then
            SendCADMark2_y = Math.Round(Math.Atan2((m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y), (m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X)) * 180 / 3.14, 3) '角度
        Else
            SendCADMark2_y = Math.Round(Math.Atan2((m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y), (m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X)) * 180 / 3.14, 3) '角度
        End If

        For i As Integer = 1 To 40 'EEE
            SendCADInsertX(i) = Math.Round(Math.Sqrt((m_data.obj1.insertObject(i).insertCAD.CenterX - (m_data.obj1.Mark_1_X + (m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X) / 2)) ^ 2 + (m_data.obj1.insertObject(i).insertCAD.CenterY - (m_data.obj1.Mark_1_Y + (m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y) / 2)) ^ 2), 3) '插件点相对Mark1的距离'改：2个Mark中点距离

            If Math.Round(Math.Atan2((m_data.obj1.insertObject(i).insertCAD.CenterY - (m_data.obj1.Mark_1_Y + (m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y) / 2)), (m_data.obj1.insertObject(i).insertCAD.CenterX - (m_data.obj1.Mark_1_X + (m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X) / 2))) * 180 / 3.14, 3) < 0 Then
                SendCADInsertY(i) = 360 + Math.Round(Math.Atan2((m_data.obj1.insertObject(i).insertCAD.CenterY - (m_data.obj1.Mark_1_Y + (m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y) / 2)), (m_data.obj1.insertObject(i).insertCAD.CenterX - (m_data.obj1.Mark_1_X + (m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X) / 2))) * 180 / 3.14, 3)
            Else
                SendCADInsertY(i) = Math.Round(Math.Atan2((m_data.obj1.insertObject(i).insertCAD.CenterY - (m_data.obj1.Mark_1_Y + (m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y) / 2)), (m_data.obj1.insertObject(i).insertCAD.CenterX - (m_data.obj1.Mark_1_X + (m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X) / 2))) * 180 / 3.14, 3)
            End If
        Next

        For i As Integer = 1 To 40 'EEE
            SendCADPinX(i) = Math.Round(Math.Sqrt((m_data.obj1.putPinCAD(i - 1).CenterX - (m_data.obj1.Mark_1_X + (m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X) / 2)) ^ 2 + (m_data.obj1.putPinCAD(i - 1).CenterY - (m_data.obj1.Mark_1_Y + (m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y) / 2)) ^ 2), 3) '插件点相对Mark1的距离'改：2个Mark中点距离

            If Math.Round(Math.Atan2((m_data.obj1.putPinCAD(i - 1).CenterY - (m_data.obj1.Mark_1_Y + (m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y) / 2)), (m_data.obj1.putPinCAD(i - 1).CenterX - (m_data.obj1.Mark_1_X + (m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X) / 2))) * 180 / 3.14, 3) < 0 Then
                SendCADPinY(i) = 360 + Math.Round(Math.Atan2((m_data.obj1.putPinCAD(i - 1).CenterY - (m_data.obj1.Mark_1_Y + (m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y) / 2)), (m_data.obj1.putPinCAD(i - 1).CenterX - (m_data.obj1.Mark_1_X + (m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X) / 2))) * 180 / 3.14, 3)
            Else
                SendCADPinY(i) = Math.Round(Math.Atan2((m_data.obj1.putPinCAD(i - 1).CenterY - (m_data.obj1.Mark_1_Y + (m_data.obj1.Mark_2_Y - m_data.obj1.Mark_1_Y) / 2)), (m_data.obj1.putPinCAD(i - 1).CenterX - (m_data.obj1.Mark_1_X + (m_data.obj1.Mark_2_X - m_data.obj1.Mark_1_X) / 2))) * 180 / 3.14, 3)
            End If
        Next
    End Sub



    'Private Sub Cal_CAD_XY()
    '    SendCADMark2_x = Math.Round(Math.Sqrt((gallpoints.Mark_2_X - gallpoints.Mark_1_X) ^ 2 + (gallpoints.Mark_2_Y - gallpoints.Mark_1_Y) ^ 2), 3) '两Mark点的距离
    '    If Math.Round(Math.Atan2((gallpoints.Mark_2_Y - gallpoints.Mark_1_Y), (gallpoints.Mark_2_X - gallpoints.Mark_1_X)) * 180 / 3.14, 3) < 0 Then
    '        SendCADMark2_y = Math.Round(Math.Atan2((gallpoints.Mark_2_Y - gallpoints.Mark_1_Y), (gallpoints.Mark_2_X - gallpoints.Mark_1_X)) * 180 / 3.14, 3) '角度
    '    Else
    '        SendCADMark2_y = Math.Round(Math.Atan2((gallpoints.Mark_2_Y - gallpoints.Mark_1_Y), (gallpoints.Mark_2_X - gallpoints.Mark_1_X)) * 180 / 3.14, 3) '角度
    '    End If

    '    For i As Integer = 1 To 40 'EEE
    '        SendCADInsertX(i) = Math.Round(Math.Sqrt((gallpoints.insertObject(i).insertCAD.CenterX - (gallpoints.Mark_1_X + (gallpoints.Mark_2_X - gallpoints.Mark_1_X) / 2)) ^ 2 + (gallpoints.insertObject(i).insertCAD.CenterY - (gallpoints.Mark_1_Y + (gallpoints.Mark_2_Y - gallpoints.Mark_1_Y) / 2)) ^ 2), 3) '插件点相对Mark1的距离'改：2个Mark中点距离

    '        If Math.Round(Math.Atan2((gallpoints.insertObject(i).insertCAD.CenterY - (gallpoints.Mark_1_Y + (gallpoints.Mark_2_Y - gallpoints.Mark_1_Y) / 2)), (gallpoints.insertObject(i).insertCAD.CenterX - (gallpoints.Mark_1_X + (gallpoints.Mark_2_X - gallpoints.Mark_1_X) / 2))) * 180 / 3.14, 3) < 0 Then
    '            SendCADInsertY(i) = 360 + Math.Round(Math.Atan2((gallpoints.insertObject(i).insertCAD.CenterY - (gallpoints.Mark_1_Y + (gallpoints.Mark_2_Y - gallpoints.Mark_1_Y) / 2)), (gallpoints.insertObject(i).insertCAD.CenterX - (gallpoints.Mark_1_X + (gallpoints.Mark_2_X - gallpoints.Mark_1_X) / 2))) * 180 / 3.14, 3)
    '        Else
    '            SendCADInsertY(i) = Math.Round(Math.Atan2((gallpoints.insertObject(i).insertCAD.CenterY - (gallpoints.Mark_1_Y + (gallpoints.Mark_2_Y - gallpoints.Mark_1_Y) / 2)), (gallpoints.insertObject(i).insertCAD.CenterX - (gallpoints.Mark_1_X + (gallpoints.Mark_2_X - gallpoints.Mark_1_X) / 2))) * 180 / 3.14, 3)
    '        End If
    '    Next

    '    For i As Integer = 1 To 40 'EEE
    '        SendCADPinX(i) = Math.Round(Math.Sqrt((gallpoints.putPinCAD(i - 1).CenterX - (gallpoints.Mark_1_X + (gallpoints.Mark_2_X - gallpoints.Mark_1_X) / 2)) ^ 2 + (gallpoints.putPinCAD(i - 1).CenterY - (gallpoints.Mark_1_Y + (gallpoints.Mark_2_Y - gallpoints.Mark_1_Y) / 2)) ^ 2), 3) '插件点相对Mark1的距离'改：2个Mark中点距离

    '        If Math.Round(Math.Atan2((gallpoints.putPinCAD(i - 1).CenterY - (gallpoints.Mark_1_Y + (gallpoints.Mark_2_Y - gallpoints.Mark_1_Y) / 2)), (gallpoints.putPinCAD(i - 1).CenterX - (gallpoints.Mark_1_X + (gallpoints.Mark_2_X - gallpoints.Mark_1_X) / 2))) * 180 / 3.14, 3) < 0 Then
    '            SendCADPinY(i) = 360 + Math.Round(Math.Atan2((gallpoints.putPinCAD(i - 1).CenterY - (gallpoints.Mark_1_Y + (gallpoints.Mark_2_Y - gallpoints.Mark_1_Y) / 2)), (gallpoints.putPinCAD(i - 1).CenterX - (gallpoints.Mark_1_X + (gallpoints.Mark_2_X - gallpoints.Mark_1_X) / 2))) * 180 / 3.14, 3)
    '        Else
    '            SendCADPinY(i) = Math.Round(Math.Atan2((gallpoints.putPinCAD(i - 1).CenterY - (gallpoints.Mark_1_Y + (gallpoints.Mark_2_Y - gallpoints.Mark_1_Y) / 2)), (gallpoints.putPinCAD(i - 1).CenterX - (gallpoints.Mark_1_X + (gallpoints.Mark_2_X - gallpoints.Mark_1_X) / 2))) * 180 / 3.14, 3)
    '        End If
    '    Next
    'End Sub


    Function Robot_PointData_T1() As String()
        Cal_CAD_XY1()

        'speed
        '   Dim obj1_RobotSet As clsRobotSet = obj1_RobotSet
        Robot_Send_String(0) = "OtherData|0," & m_data.obj1_RobotSet.speedHigh.speedRate.ToString & "," & m_data.obj1_RobotSet.speedLow.speedRate.ToString & "," & m_data.obj1_RobotSet.speedHigh.accRate.ToString & "," & m_data.obj1_RobotSet.speedLow.accRate.ToString & "," & m_data.obj1_RobotSet.speedHigh.speedReal.ToString & "," & m_data.obj1_RobotSet.speedLow.speedReal.ToString & "," & m_data.obj1_RobotSet.speedHigh.accReal.ToString & "," & m_data.obj1_RobotSet.speedLow.accReal.ToString & "," & "0,0," & "0" & "," & SendCADMark2_x & "," & "0" & "," & SendCADMark2_y

        '合成为取料点 Robot_Send_String(1)--Robot_Send_String(40)

        For i As Integer = 1 To 40
            Robot_Send_String(i) = "QL_|" & i.ToString & "," & m_data.obj1.insertObject(i).fetchPoint.X & "," & m_data.obj1.insertObject(i).fetchPoint.Y & "," & m_data.obj1.insertObject(i).fetchPoint.Z & "," & m_data.obj1.insertObject(i).fetchPoint.U & "," & m_data.obj1.insertObject(i).fetchPoint.V & "," & m_data.obj1.insertObject(i).fetchPoint.W & "," & m_data.obj1.insertObject(i).fetchPoint.J1 & "," & m_data.obj1.insertObject(i).fetchPoint.J2 & "," & m_data.obj1.insertObject(i).fetchPoint.J4 & "," & m_data.obj1.insertObject(i).fetchPoint.J6 & "," & m_data.obj1.insertObject(i).fetchPoint.hand & "," & m_data.obj1.insertObject(i).fetchPoint.toolflag & "," & m_data.obj1.insertObject(i).fetchHeight & ",0"
        Next
        '合成为拍照点Robot_Send_String(41)--Robot_Send_String(80)
        For i As Integer = 1 To 40
            Robot_Send_String(i + 40) = "PZ_|" & i.ToString & "," & m_data.obj1.insertObject(i).takePicPoint.X & "," & m_data.obj1.insertObject(i).takePicPoint.Y & "," & m_data.obj1.insertObject(i).takePicPoint.Z & "," & m_data.obj1.insertObject(i).takePicPoint.U & "," & m_data.obj1.insertObject(i).takePicPoint.V & "," & m_data.obj1.insertObject(i).takePicPoint.W & "," & m_data.obj1.insertObject(i).takePicPoint.J1 & "," & m_data.obj1.insertObject(i).takePicPoint.J2 & "," & m_data.obj1.insertObject(i).takePicPoint.J4 & "," & m_data.obj1.insertObject(i).takePicPoint.J6 & "," & m_data.obj1.insertObject(i).takePicPoint.hand & "," & m_data.obj1.insertObject(i).takePicPoint.toolflag & "," & m_data.obj1.insertObject(i).takePicHeight & ",0"
        Next
        '合成为插件点Robot_Send_String(81)--Robot_Send_String(120)
        For i As Integer = 1 To 40
            Robot_Send_String(i + 80) = ""
            Robot_Send_String(i + 80) = "CJ_|" & i.ToString & "," & m_data.obj1.insertObject(i).insertPoint.X & "," & m_data.obj1.insertObject(i).insertPoint.Y & "," & m_data.obj1.insertObject(i).insertPoint.Z & "," & m_data.obj1.insertObject(i).insertPoint.U & "," & m_data.obj1.insertObject(i).insertPoint.V & "," & m_data.obj1.insertObject(i).insertPoint.W & "," & m_data.obj1.insertObject(i).insertPoint.J1 & "," & m_data.obj1.insertObject(i).insertPoint.J2 & "," & m_data.obj1.insertObject(i).insertPoint.J4 & "," & m_data.obj1.insertObject(i).insertPoint.J6 & "," & m_data.obj1.insertObject(i).insertPoint.hand & "," & m_data.obj1.insertObject(i).insertPoint.toolflag & "," & m_data.obj1.insertObject(i).insertHeight & "," & m_data.obj1.insertObject(i).Insert_Angle.ToString
        Next
        '合成为NG点Robot_Send_String(121)--Robot_Send_String(140)
        For i As Integer = 1 To 20
            Robot_Send_String(i + 120) = "NG_|" & i.ToString & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).X & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).Y & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).Z & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).U & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).V & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).W & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).J1 & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).J2 & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).J4 & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).J6 & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).hand & "," & m_data.obj3_RobotSetPoint.abandonPoint(i).toolflag & "," & m_data.obj3_RobotSetPoint.abandonHeight(i) & ",0"
        Next
        '合成为取料过渡点Robot_Send_String(141)--Robot_Send_String(180)
        For i As Integer = 1 To 40
            Dim _aa As String
            If m_data.obj1.insertObject(i).fetchTransUsed = True Then
                _aa = "1"
            Else
                _aa = "0"
            End If
            Robot_Send_String(i + 140) = "GD_Q|" & i.ToString & "," & m_data.obj1.insertObject(i).fetchTransPoint.X & "," & m_data.obj1.insertObject(i).fetchTransPoint.Y & "," & m_data.obj1.insertObject(i).fetchTransPoint.Z & "," & m_data.obj1.insertObject(i).fetchTransPoint.U & "," & m_data.obj1.insertObject(i).fetchTransPoint.V & "," & m_data.obj1.insertObject(i).fetchTransPoint.W & "," & m_data.obj1.insertObject(i).fetchTransPoint.J1 & "," & m_data.obj1.insertObject(i).fetchTransPoint.J2 & "," & m_data.obj1.insertObject(i).fetchTransPoint.J4 & "," & m_data.obj1.insertObject(i).fetchTransPoint.J6 & "," & m_data.obj1.insertObject(i).fetchTransPoint.hand & "," & m_data.obj1.insertObject(i).fetchTransPoint.toolflag & "," & "0" & "," & _aa
        Next
        '合成为插件过渡点Robot_Send_String(181)--Robot_Send_String(220)
        For i As Integer = 1 To 40
            Dim _aa As String
            If m_data.obj1.insertObject(i).insertTransUsed = True Then
                _aa = "1"
            Else
                _aa = "0"
            End If
            Robot_Send_String(i + 180) = "GD_C|" & i.ToString & "," & m_data.obj1.insertObject(i).insertTransPoint.X & "," & m_data.obj1.insertObject(i).insertTransPoint.Y & "," & m_data.obj1.insertObject(i).insertTransPoint.Z & "," & m_data.obj1.insertObject(i).insertTransPoint.U & "," & m_data.obj1.insertObject(i).insertTransPoint.V & "," & m_data.obj1.insertObject(i).insertTransPoint.W & "," & m_data.obj1.insertObject(i).insertTransPoint.J1 & "," & m_data.obj1.insertObject(i).insertTransPoint.J2 & "," & m_data.obj1.insertObject(i).insertTransPoint.J4 & "," & m_data.obj1.insertObject(i).insertTransPoint.J6 & "," & m_data.obj1.insertObject(i).insertTransPoint.hand & "," & m_data.obj1.insertObject(i).insertTransPoint.toolflag & "," & "0" & "," & _aa
        Next

        '合成为NG过渡点Robot_Send_String(221)--Robot_Send_String(260)
        For i As Integer = 1 To 40
            Dim _aa As String
            If m_data.obj1.insertObject(i).abandonTransUsed = True Then
                _aa = "1"
            Else
                _aa = "0"
            End If
            Robot_Send_String(i + 220) = "GD_NG|" & i.ToString & "," & m_data.obj1.insertObject(i).abandonTransPoint.X & "," & m_data.obj1.insertObject(i).abandonTransPoint.Y & "," & m_data.obj1.insertObject(i).abandonTransPoint.Z & "," & m_data.obj1.insertObject(i).abandonTransPoint.U & "," & m_data.obj1.insertObject(i).abandonTransPoint.V & "," & m_data.obj1.insertObject(i).abandonTransPoint.W & "," & m_data.obj1.insertObject(i).abandonTransPoint.J1 & "," & m_data.obj1.insertObject(i).abandonTransPoint.J2 & "," & m_data.obj1.insertObject(i).abandonTransPoint.J4 & "," & m_data.obj1.insertObject(i).abandonTransPoint.J6 & "," & m_data.obj1.insertObject(i).abandonTransPoint.hand & "," & m_data.obj1.insertObject(i).abandonTransPoint.toolflag & "," & "0" & "," & _aa
        Next
        '合成为Mark1过渡点Robot_Send_String(261)
        Dim _bb As String
        If m_data.obj1.usedmark1Trans = True Then
            _bb = "1"
        Else
            _bb = "0"
        End If
        Robot_Send_String(261) = "GD_M|1" & "," & m_data.obj1.mark_1_TransPoint.X & "," & m_data.obj1.mark_1_TransPoint.Y & "," & m_data.obj1.mark_1_TransPoint.Z & "," & m_data.obj1.mark_1_TransPoint.U & "," & m_data.obj1.mark_1_TransPoint.V & "," & m_data.obj1.mark_1_TransPoint.W & "," & m_data.obj1.mark_1_TransPoint.J1 & "," & m_data.obj1.mark_1_TransPoint.J2 & "," & m_data.obj1.mark_1_TransPoint.J4 & "," & m_data.obj1.mark_1_TransPoint.J6 & "," & m_data.obj1.mark_1_TransPoint.hand & "," & m_data.obj1.mark_1_TransPoint.toolflag & "," & "0" & "," & _bb
        '合成为Mark1过渡点Robot_Send_String(262)
        If m_data.obj1.usedmark2Trans = True Then
            _bb = "1"
        Else
            _bb = "0"
        End If
        Robot_Send_String(262) = "GD_M|2" & "," & m_data.obj1.mark_2_TransPoint.X & "," & m_data.obj1.mark_2_TransPoint.Y & "," & m_data.obj1.mark_2_TransPoint.Z & "," & m_data.obj1.mark_2_TransPoint.U & "," & m_data.obj1.mark_2_TransPoint.V & "," & m_data.obj1.mark_2_TransPoint.W & "," & m_data.obj1.mark_2_TransPoint.J1 & "," & m_data.obj1.mark_2_TransPoint.J2 & "," & m_data.obj1.mark_2_TransPoint.J4 & "," & m_data.obj1.mark_2_TransPoint.J6 & "," & m_data.obj1.mark_2_TransPoint.hand & "," & m_data.obj1.mark_2_TransPoint.toolflag & "," & "0" & "," & _bb

        '合成为Mark1过渡点Robot_Send_String(263)

        Robot_Send_String(263) = "Mark_|1" & "," & m_data.obj1.mark_1_Point.X & "," & m_data.obj1.mark_1_Point.Y & "," & m_data.obj1.mark_1_Point.Z & "," & m_data.obj1.mark_1_Point.U & "," & m_data.obj1.mark_1_Point.V & "," & m_data.obj1.mark_1_Point.W & "," & m_data.obj1.mark_1_Point.J1 & "," & m_data.obj1.mark_1_Point.J2 & "," & m_data.obj1.mark_1_Point.J4 & "," & m_data.obj1.mark_1_Point.J6 & "," & m_data.obj1.mark_1_Point.hand & "," & m_data.obj1.mark_1_Point.toolflag & "," & "0" & "," & "0"
        '合成为Mark1过渡点Robot_Send_String(264)

        Robot_Send_String(264) = "Mark_|2" & "," & m_data.obj1.mark_2_Point.X & "," & m_data.obj1.mark_2_Point.Y & "," & m_data.obj1.mark_2_Point.Z & "," & m_data.obj1.mark_2_Point.U & "," & m_data.obj1.mark_2_Point.V & "," & m_data.obj1.mark_2_Point.W & "," & m_data.obj1.mark_2_Point.J1 & "," & m_data.obj1.mark_2_Point.J2 & "," & m_data.obj1.mark_2_Point.J4 & "," & m_data.obj1.mark_2_Point.J6 & "," & m_data.obj1.mark_2_Point.hand & "," & m_data.obj1.mark_2_Point.toolflag & "," & "0" & "," & "0"


        '合成为其它数据1Robot_Send_String(265)--Robot_Send_String(304)
        For i As Integer = 1 To 40
            Robot_Send_String(i + 264) = "Data_|" & i.ToString & "," & SendCADInsertX(i) & "," & SendCADInsertY(i) & "," & m_data.obj1.insertObject(i).insertOffSets.X & "," & m_data.obj1.insertObject(i).insertOffSets.Y & "," & m_data.obj1.insertObject(i).insertOffSets.Z & "," & m_data.obj1.insertObject(i).insertOffSets.U & "," & m_data.obj1.insertObject(i).insertOffSets.V & "," & m_data.obj1.insertObject(i).insertOffSets.W & "," & m_data.obj1.insertObject(i).insertAvoid_X & "," & m_data.obj1.insertObject(i).insertAvoid_Y & "," & m_data.obj1.insertObject(i).insertAvoid_Z & "," & m_data.obj1.insertObject(i).fetchPAvoid_X & "," & m_data.obj1.insertObject(i).fetchPAvoid_Y & "," & m_data.obj1.insertObject(i).handNum
        Next

        '合成为其它数据2Robot_Send_String(305)--Robot_Send_String(344)
        For i As Integer = 1 To 40
            If m_data.obj1.PawNo(i).ZhaoType = "夹爪常闭" Then
                m_data.obj1.insertObject(i).handNormallyStatus = 1
            Else
                m_data.obj1.insertObject(i).handNormallyStatus = 2
            End If
            Dim _Qufast As String = "0"
            Dim _Insertfast As String = "0"
            Dim _InsertTesting As String = "0"
            If m_data.obj1.PawNo(i).QuFast = "快速" Then
                _Qufast = "1"
            Else
                _Qufast = "0"
            End If
            If m_data.obj1.PawNo(i).InsertFast = "快速" Then
                _Insertfast = "1"
            Else
                _Insertfast = "0"
            End If
            If m_data.obj1.PawNo(i).InsertTesting = "开" Then
                _InsertTesting = "0"
            Else
                _InsertTesting = "1"
            End If

            Robot_Send_String(i + 304) = "Data1_|" & i.ToString & "," & m_data.obj1.insertObject(i).handNormallyStatus & "," & m_data.obj1.PawNo(i).LoosenTime & "," & m_data.obj1.PawNo(i).InsertSleepTime & "," & m_data.obj1.PawNo(i).CloseTime & "," & m_data.obj1.PawNo(i).GrabLengh.ToString & "," & (m_data.obj3_RobotSetPoint.Stand_Pin_Len - Val(m_data.obj1.PawNo(i).mLengh)).ToString & "," & gRobotActionData.ZhaozhiUseNum(i - 1).ToString & "," & _Qufast & "," & _Insertfast & "," & _InsertTesting & "," & SendCADPinX(i) & "," & SendCADPinY(i) & "," & m_data.obj1.PawNo(i).AdvanceLoosenTime & "," & m_data.obj1.PawNo(i).AdvanceCloseTime & "," & "0" & "," & "0"
        Next
        '合成为9点标定时，拍照的参考点Robot_Send_String(345)
        Robot_Send_String(345) = "BiaoDi_M|0" & "," & m_data.obj3_RobotSetPoint.cap_cankaoP.X & "," & m_data.obj3_RobotSetPoint.cap_cankaoP.Y & "," & m_data.obj3_RobotSetPoint.cap_cankaoP.Z & "," & m_data.obj3_RobotSetPoint.cap_cankaoP.U & "," & m_data.obj3_RobotSetPoint.cap_cankaoP.V & "," & m_data.obj3_RobotSetPoint.cap_cankaoP.W & "," & m_data.obj3_RobotSetPoint.cap_cankaoP.J1 & "," & m_data.obj3_RobotSetPoint.cap_cankaoP.J2 & "," & m_data.obj3_RobotSetPoint.cap_cankaoP.J4 & "," & m_data.obj3_RobotSetPoint.cap_cankaoP.J6 & "," & m_data.obj3_RobotSetPoint.cap_cankaoP.hand & "," & "0" & "," & "0" & "," & "0"

        '合成为其它数据2Robot_Send_String(345)--Robot_Send_String(349)
        For i As Integer = 1 To 4
            Robot_Send_String(i + 345) = "FetPin_|" & i.ToString & "," & m_data.obj3_RobotSetPoint.fetchPin(i).X & "," & m_data.obj3_RobotSetPoint.fetchPin(i).Y & "," & m_data.obj3_RobotSetPoint.fetchPin(i).Z & "," & m_data.obj3_RobotSetPoint.fetchPin(i).U & "," & m_data.obj3_RobotSetPoint.fetchPin(i).V & "," & m_data.obj3_RobotSetPoint.fetchPin(i).W & "," & m_data.obj3_RobotSetPoint.fetchPin(i).J1 & "," & m_data.obj3_RobotSetPoint.fetchPin(i).J2 & "," & m_data.obj3_RobotSetPoint.fetchPin(i).J4 & "," & m_data.obj3_RobotSetPoint.fetchPin(i).J6 & "," & m_data.obj3_RobotSetPoint.fetchPin(i).hand & "," & m_data.obj3_RobotSetPoint.fetchPin(i).toolflag & "," & m_data.obj3_RobotSetPoint.fetchpinHeight & "," & "0"
        Next




        Dim _Qufast1 As String = "0"
        Dim _Insertfast1 As String = "0"
        Dim _handNormallyStatus As String
        If m_data.obj1.PinPawNo.ZhaoType = "夹爪常闭" Then
            _handNormallyStatus = 1
        Else
            _handNormallyStatus = 2
        End If
        If m_data.obj1.PinPawNo.QuFast = "快速" Then
            _Qufast1 = "1"
        Else
            _Qufast1 = "0"
        End If
        If m_data.obj1.PinPawNo.InsertFast = "快速" Then
            _Insertfast1 = "1"
        Else
            _Insertfast1 = "0"
        End If
        Robot_Send_String(350) = "PinPaw_|1" & "," & m_data.obj3_RobotSetPoint.fetpinrownum & "," & m_data.obj3_RobotSetPoint.fetpincolumnnum & "," & _handNormallyStatus & "," & m_data.obj1.PinPawNo.CloseTime & "," & m_data.obj1.PinPawNo.LoosenTime & "," & m_data.obj1.PinPawNo.GrabLengh.ToString & "," & (m_data.obj3_RobotSetPoint.Stand_Pin_Len - Val(m_data.obj1.PinPawNo.mLengh)).ToString & "," & _Qufast1 & "," & _Insertfast1 & "," & m_data.obj1.PutPinTool & "," & "0" & "," & "0" & "," & "0" & "," & "0"
        Robot_Send_String(351) = "PinNG_|1" & "," & m_data.obj3_RobotSetPoint.fetpin_NG.X & "," & m_data.obj3_RobotSetPoint.fetpin_NG.Y & "," & m_data.obj3_RobotSetPoint.fetpin_NG.Z & "," & m_data.obj3_RobotSetPoint.fetpin_NG.U & "," & m_data.obj3_RobotSetPoint.fetpin_NG.V & "," & m_data.obj3_RobotSetPoint.fetpin_NG.W & "," & m_data.obj3_RobotSetPoint.fetpin_NG.J1 & "," & m_data.obj3_RobotSetPoint.fetpin_NG.J2 & "," & m_data.obj3_RobotSetPoint.fetpin_NG.J4 & "," & m_data.obj3_RobotSetPoint.fetpin_NG.J6 & "," & m_data.obj3_RobotSetPoint.fetpin_NG.hand & "," & m_data.obj3_RobotSetPoint.fetpin_NG.toolflag & "," & m_data.obj3_RobotSetPoint.fetpin_NGHeight & "," & "0"

        Robot_Send_String(352) = "DetPin_|1" & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.X & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.Y & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.Z & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.U & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.V & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.W & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.J1 & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.J2 & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.J4 & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.J6 & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.hand & "," & m_data.obj3_RobotSetPoint.fetpin_Detect.toolflag & "," & m_data.obj3_RobotSetPoint.fetpin_DetectHeight & "," & "0"
        For i As Integer = 1 To 40
            Robot_Send_String(352 + i) = "Re_|" & i.ToString & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.X & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.Y & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.Z & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.U & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.V & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.W & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.J1 & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.J2 & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.J4 & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.J6 & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.hand & "," & m_data.obj1.insertObject(i).Re_Cycle_Point.toolflag & "," & "0" & ",0"
        Next
        '合成为取料过渡点Robot_Send_String(393)--Robot_Send_String(432)
        For i As Integer = 1 To 40
            Dim _aa As String
            If m_data.obj1.insertObject(i).takePicTransUsed = True Then
                _aa = "1"
            Else
                _aa = "0"
            End If
            Robot_Send_String(i + 392) = "GD_P|" & i.ToString & "," & m_data.obj1.insertObject(i).takePicTransPoint.X & "," & m_data.obj1.insertObject(i).takePicTransPoint.Y & "," & m_data.obj1.insertObject(i).takePicTransPoint.Z & "," & m_data.obj1.insertObject(i).takePicTransPoint.U & "," & m_data.obj1.insertObject(i).takePicTransPoint.V & "," & m_data.obj1.insertObject(i).takePicTransPoint.W & "," & m_data.obj1.insertObject(i).takePicTransPoint.J1 & "," & m_data.obj1.insertObject(i).takePicTransPoint.J2 & "," & m_data.obj1.insertObject(i).takePicTransPoint.J4 & "," & m_data.obj1.insertObject(i).takePicTransPoint.J6 & "," & m_data.obj1.insertObject(i).takePicTransPoint.hand & "," & m_data.obj1.insertObject(i).takePicTransPoint.toolflag & "," & "0" & "," & _aa
        Next
        Robot_Send_String(433) = "Mark_Start_|" & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.X & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.Y & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.Z & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.U & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.V & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.W & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.J1 & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.J2 & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.J4 & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.J6 & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.hand & "," & m_data.obj3_RobotSetPoint.Mark_StartPoint.toolflag & "," & "0" & "," & "0"

        '合成为简易盘料参数Robot_Send_String(434)--Robot_Send_String(554)
        For j As Integer = 2 To 3
            For i As Integer = 1 To 40
                Robot_Send_String((i + 433) + ((j - 2) * 40)) = "QSimpFd_" & j & "|" & i.ToString & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).X & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).Y & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).Z & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).U & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).V & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).W & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).J1 & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).J2 & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).J4 & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).J6 & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).hand & "," & m_data.obj1.insertObject(i).fet_SimpFed_points(j).toolflag & "," & m_data.obj1.insertObject(i).fet_SimpFedHeight & ",0"
            Next
        Next

        '合成为简易盘料参数Robot_Send_String(554)--Robot_Send_String(594)
        For i As Integer = 1 To 40
            Dim _aa As String
            If m_data.obj1.insertObject(i).simple_Feeder_Used = True Then
                _aa = "1"
            Else
                _aa = "0"
            End If
            Robot_Send_String(i + 513) = "SimpFd_A|" & i.ToString & "," & m_data.obj1.insertObject(i).simple_Feeder_row & "," & m_data.obj1.insertObject(i).simple_Feeder_column & "," & _aa & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0"
        Next
        'gepson_com.RobotPointString = Robot_Send_String
        Return Robot_Send_String
    End Function







    'Function Robot_PointData_T() As String()
    '    Cal_CAD_XY()

    '    'speed
    '    '   Dim gRobotset As clsRobotSet = gRobotset
    '    Robot_Send_String(0) = "OtherData|0," & gRobotset.speedHigh.speedRate.ToString & "," & gRobotset.speedLow.speedRate.ToString & "," & gRobotset.speedHigh.accRate.ToString & "," & gRobotset.speedLow.accRate.ToString & "," & gRobotset.speedHigh.speedReal.ToString & "," & gRobotset.speedLow.speedReal.ToString & "," & gRobotset.speedHigh.accReal.ToString & "," & gRobotset.speedLow.accReal.ToString & "," & "0,0," & "0" & "," & SendCADMark2_x & "," & "0" & "," & SendCADMark2_y

    '    '合成为取料点 Robot_Send_String(1)--Robot_Send_String(40)

    '    For i As Integer = 1 To 40
    '        Robot_Send_String(i) = "QL_|" & i.ToString & "," & gallpoints.insertObject(i).fetchPoint.X & "," & gallpoints.insertObject(i).fetchPoint.Y & "," & gallpoints.insertObject(i).fetchPoint.Z & "," & gallpoints.insertObject(i).fetchPoint.U & "," & gallpoints.insertObject(i).fetchPoint.V & "," & gallpoints.insertObject(i).fetchPoint.W & "," & gallpoints.insertObject(i).fetchPoint.J1 & "," & gallpoints.insertObject(i).fetchPoint.J2 & "," & gallpoints.insertObject(i).fetchPoint.J4 & "," & gallpoints.insertObject(i).fetchPoint.J6 & "," & gallpoints.insertObject(i).fetchPoint.hand & "," & gallpoints.insertObject(i).fetchPoint.toolflag & "," & gallpoints.insertObject(i).fetchHeight & ",0"
    '    Next
    '    '合成为拍照点Robot_Send_String(41)--Robot_Send_String(80)
    '    For i As Integer = 1 To 40
    '        Robot_Send_String(i + 40) = "PZ_|" & i.ToString & "," & gallpoints.insertObject(i).takePicPoint.X & "," & gallpoints.insertObject(i).takePicPoint.Y & "," & gallpoints.insertObject(i).takePicPoint.Z & "," & gallpoints.insertObject(i).takePicPoint.U & "," & gallpoints.insertObject(i).takePicPoint.V & "," & gallpoints.insertObject(i).takePicPoint.W & "," & gallpoints.insertObject(i).takePicPoint.J1 & "," & gallpoints.insertObject(i).takePicPoint.J2 & "," & gallpoints.insertObject(i).takePicPoint.J4 & "," & gallpoints.insertObject(i).takePicPoint.J6 & "," & gallpoints.insertObject(i).takePicPoint.hand & "," & gallpoints.insertObject(i).takePicPoint.toolflag & "," & gallpoints.insertObject(i).takePicHeight & ",0"
    '    Next
    '    '合成为插件点Robot_Send_String(81)--Robot_Send_String(120)
    '    For i As Integer = 1 To 40
    '        Robot_Send_String(i + 80) = ""
    '        Robot_Send_String(i + 80) = "CJ_|" & i.ToString & "," & gallpoints.insertObject(i).insertPoint.X & "," & gallpoints.insertObject(i).insertPoint.Y & "," & gallpoints.insertObject(i).insertPoint.Z & "," & gallpoints.insertObject(i).insertPoint.U & "," & gallpoints.insertObject(i).insertPoint.V & "," & gallpoints.insertObject(i).insertPoint.W & "," & gallpoints.insertObject(i).insertPoint.J1 & "," & gallpoints.insertObject(i).insertPoint.J2 & "," & gallpoints.insertObject(i).insertPoint.J4 & "," & gallpoints.insertObject(i).insertPoint.J6 & "," & gallpoints.insertObject(i).insertPoint.hand & "," & gallpoints.insertObject(i).insertPoint.toolflag & "," & gallpoints.insertObject(i).insertHeight & "," & gallpoints.insertObject(i).Insert_Angle.ToString
    '    Next
    '    '合成为NG点Robot_Send_String(121)--Robot_Send_String(140)
    '    For i As Integer = 1 To 20
    '        Robot_Send_String(i + 120) = "NG_|" & i.ToString & "," & grobotSetPoint.abandonPoint(i).X & "," & grobotSetPoint.abandonPoint(i).Y & "," & grobotSetPoint.abandonPoint(i).Z & "," & grobotSetPoint.abandonPoint(i).U & "," & grobotSetPoint.abandonPoint(i).V & "," & grobotSetPoint.abandonPoint(i).W & "," & grobotSetPoint.abandonPoint(i).J1 & "," & grobotSetPoint.abandonPoint(i).J2 & "," & grobotSetPoint.abandonPoint(i).J4 & "," & grobotSetPoint.abandonPoint(i).J6 & "," & grobotSetPoint.abandonPoint(i).hand & "," & grobotSetPoint.abandonPoint(i).toolflag & "," & grobotSetPoint.abandonHeight(i) & ",0"
    '    Next
    '    '合成为取料过渡点Robot_Send_String(141)--Robot_Send_String(180)
    '    For i As Integer = 1 To 40
    '        Dim _aa As String
    '        If gallpoints.insertObject(i).fetchTransUsed = True Then
    '            _aa = "1"
    '        Else
    '            _aa = "0"
    '        End If
    '        Robot_Send_String(i + 140) = "GD_Q|" & i.ToString & "," & gallpoints.insertObject(i).fetchTransPoint.X & "," & gallpoints.insertObject(i).fetchTransPoint.Y & "," & gallpoints.insertObject(i).fetchTransPoint.Z & "," & gallpoints.insertObject(i).fetchTransPoint.U & "," & gallpoints.insertObject(i).fetchTransPoint.V & "," & gallpoints.insertObject(i).fetchTransPoint.W & "," & gallpoints.insertObject(i).fetchTransPoint.J1 & "," & gallpoints.insertObject(i).fetchTransPoint.J2 & "," & gallpoints.insertObject(i).fetchTransPoint.J4 & "," & gallpoints.insertObject(i).fetchTransPoint.J6 & "," & gallpoints.insertObject(i).fetchTransPoint.hand & "," & gallpoints.insertObject(i).fetchTransPoint.toolflag & "," & "0" & "," & _aa
    '    Next
    '    '合成为插件过渡点Robot_Send_String(181)--Robot_Send_String(220)
    '    For i As Integer = 1 To 40
    '        Dim _aa As String
    '        If gallpoints.insertObject(i).insertTransUsed = True Then
    '            _aa = "1"
    '        Else
    '            _aa = "0"
    '        End If
    '        Robot_Send_String(i + 180) = "GD_C|" & i.ToString & "," & gallpoints.insertObject(i).insertTransPoint.X & "," & gallpoints.insertObject(i).insertTransPoint.Y & "," & gallpoints.insertObject(i).insertTransPoint.Z & "," & gallpoints.insertObject(i).insertTransPoint.U & "," & gallpoints.insertObject(i).insertTransPoint.V & "," & gallpoints.insertObject(i).insertTransPoint.W & "," & gallpoints.insertObject(i).insertTransPoint.J1 & "," & gallpoints.insertObject(i).insertTransPoint.J2 & "," & gallpoints.insertObject(i).insertTransPoint.J4 & "," & gallpoints.insertObject(i).insertTransPoint.J6 & "," & gallpoints.insertObject(i).insertTransPoint.hand & "," & gallpoints.insertObject(i).insertTransPoint.toolflag & "," & "0" & "," & _aa
    '    Next

    '    '合成为NG过渡点Robot_Send_String(221)--Robot_Send_String(260)
    '    For i As Integer = 1 To 40
    '        Dim _aa As String
    '        If gallpoints.insertObject(i).abandonTransUsed = True Then
    '            _aa = "1"
    '        Else
    '            _aa = "0"
    '        End If
    '        Robot_Send_String(i + 220) = "GD_NG|" & i.ToString & "," & gallpoints.insertObject(i).abandonTransPoint.X & "," & gallpoints.insertObject(i).abandonTransPoint.Y & "," & gallpoints.insertObject(i).abandonTransPoint.Z & "," & gallpoints.insertObject(i).abandonTransPoint.U & "," & gallpoints.insertObject(i).abandonTransPoint.V & "," & gallpoints.insertObject(i).abandonTransPoint.W & "," & gallpoints.insertObject(i).abandonTransPoint.J1 & "," & gallpoints.insertObject(i).abandonTransPoint.J2 & "," & gallpoints.insertObject(i).abandonTransPoint.J4 & "," & gallpoints.insertObject(i).abandonTransPoint.J6 & "," & gallpoints.insertObject(i).abandonTransPoint.hand & "," & gallpoints.insertObject(i).abandonTransPoint.toolflag & "," & "0" & "," & _aa
    '    Next
    '    '合成为Mark1过渡点Robot_Send_String(261)
    '    Dim _bb As String
    '    If gallpoints.usedmark1Trans = True Then
    '        _bb = "1"
    '    Else
    '        _bb = "0"
    '    End If
    '    Robot_Send_String(261) = "GD_M|1" & "," & gallpoints.mark_1_TransPoint.X & "," & gallpoints.mark_1_TransPoint.Y & "," & gallpoints.mark_1_TransPoint.Z & "," & gallpoints.mark_1_TransPoint.U & "," & gallpoints.mark_1_TransPoint.V & "," & gallpoints.mark_1_TransPoint.W & "," & gallpoints.mark_1_TransPoint.J1 & "," & gallpoints.mark_1_TransPoint.J2 & "," & gallpoints.mark_1_TransPoint.J4 & "," & gallpoints.mark_1_TransPoint.J6 & "," & gallpoints.mark_1_TransPoint.hand & "," & gallpoints.mark_1_TransPoint.toolflag & "," & "0" & "," & _bb
    '    '合成为Mark1过渡点Robot_Send_String(262)
    '    If gallpoints.usedmark2Trans = True Then
    '        _bb = "1"
    '    Else
    '        _bb = "0"
    '    End If
    '    Robot_Send_String(262) = "GD_M|2" & "," & gallpoints.mark_2_TransPoint.X & "," & gallpoints.mark_2_TransPoint.Y & "," & gallpoints.mark_2_TransPoint.Z & "," & gallpoints.mark_2_TransPoint.U & "," & gallpoints.mark_2_TransPoint.V & "," & gallpoints.mark_2_TransPoint.W & "," & gallpoints.mark_2_TransPoint.J1 & "," & gallpoints.mark_2_TransPoint.J2 & "," & gallpoints.mark_2_TransPoint.J4 & "," & gallpoints.mark_2_TransPoint.J6 & "," & gallpoints.mark_2_TransPoint.hand & "," & gallpoints.mark_2_TransPoint.toolflag & "," & "0" & "," & _bb

    '    '合成为Mark1过渡点Robot_Send_String(263)

    '    Robot_Send_String(263) = "Mark_|1" & "," & gallpoints.mark_1_Point.X & "," & gallpoints.mark_1_Point.Y & "," & gallpoints.mark_1_Point.Z & "," & gallpoints.mark_1_Point.U & "," & gallpoints.mark_1_Point.V & "," & gallpoints.mark_1_Point.W & "," & gallpoints.mark_1_Point.J1 & "," & gallpoints.mark_1_Point.J2 & "," & gallpoints.mark_1_Point.J4 & "," & gallpoints.mark_1_Point.J6 & "," & gallpoints.mark_1_Point.hand & "," & gallpoints.mark_1_Point.toolflag & "," & "0" & "," & "0"
    '    '合成为Mark1过渡点Robot_Send_String(264)

    '    Robot_Send_String(264) = "Mark_|2" & "," & gallpoints.mark_2_Point.X & "," & gallpoints.mark_2_Point.Y & "," & gallpoints.mark_2_Point.Z & "," & gallpoints.mark_2_Point.U & "," & gallpoints.mark_2_Point.V & "," & gallpoints.mark_2_Point.W & "," & gallpoints.mark_2_Point.J1 & "," & gallpoints.mark_2_Point.J2 & "," & gallpoints.mark_2_Point.J4 & "," & gallpoints.mark_2_Point.J6 & "," & gallpoints.mark_2_Point.hand & "," & gallpoints.mark_2_Point.toolflag & "," & "0" & "," & "0"


    '    '合成为其它数据1Robot_Send_String(265)--Robot_Send_String(304)
    '    For i As Integer = 1 To 40
    '        Robot_Send_String(i + 264) = "Data_|" & i.ToString & "," & SendCADInsertX(i) & "," & SendCADInsertY(i) & "," & gallpoints.insertObject(i).insertOffSets.X & "," & gallpoints.insertObject(i).insertOffSets.Y & "," & gallpoints.insertObject(i).insertOffSets.Z & "," & gallpoints.insertObject(i).insertOffSets.U & "," & gallpoints.insertObject(i).insertOffSets.V & "," & gallpoints.insertObject(i).insertOffSets.W & "," & gallpoints.insertObject(i).insertAvoid_X & "," & gallpoints.insertObject(i).insertAvoid_Y & "," & gallpoints.insertObject(i).insertAvoid_Z & "," & gallpoints.insertObject(i).fetchPAvoid_X & "," & gallpoints.insertObject(i).fetchPAvoid_Y & "," & gallpoints.insertObject(i).handNum
    '    Next

    '    '合成为其它数据2Robot_Send_String(305)--Robot_Send_String(344)
    '    For i As Integer = 1 To 40
    '        If gallpoints.PawNo(i).ZhaoType = "夹爪常闭" Then
    '            gallpoints.insertObject(i).handNormallyStatus = 1
    '        Else
    '            gallpoints.insertObject(i).handNormallyStatus = 2
    '        End If
    '        Dim _Qufast As String = "0"
    '        Dim _Insertfast As String = "0"
    '        Dim _InsertTesting As String = "0"
    '        If gallpoints.PawNo(i).QuFast = "快速" Then
    '            _Qufast = "1"
    '        Else
    '            _Qufast = "0"
    '        End If
    '        If gallpoints.PawNo(i).InsertFast = "快速" Then
    '            _Insertfast = "1"
    '        Else
    '            _Insertfast = "0"
    '        End If
    '        If gallpoints.PawNo(i).InsertTesting = "开" Then
    '            _InsertTesting = "0"
    '        Else
    '            _InsertTesting = "1"
    '        End If

    '        Robot_Send_String(i + 304) = "Data1_|" & i.ToString & "," & gallpoints.insertObject(i).handNormallyStatus & "," & gallpoints.PawNo(i).LoosenTime & "," & gallpoints.PawNo(i).InsertSleepTime & "," & gallpoints.PawNo(i).CloseTime & "," & gallpoints.PawNo(i).GrabLengh.ToString & "," & (grobotSetPoint.Stand_Pin_Len - Val(gallpoints.PawNo(i).mLengh)).ToString & "," & gRobotActionData.ZhaozhiUseNum(i - 1).ToString & "," & _Qufast & "," & _Insertfast & "," & _InsertTesting & "," & SendCADPinX(i) & "," & SendCADPinY(i) & "," & gallpoints.PawNo(i).AdvanceLoosenTime & "," & gallpoints.PawNo(i).AdvanceCloseTime & "," & "0" & "," & "0"
    '    Next
    '    '合成为9点标定时，拍照的参考点Robot_Send_String(345)
    '    Robot_Send_String(345) = "BiaoDi_M|0" & "," & grobotSetPoint.cap_cankaoP.X & "," & grobotSetPoint.cap_cankaoP.Y & "," & grobotSetPoint.cap_cankaoP.Z & "," & grobotSetPoint.cap_cankaoP.U & "," & grobotSetPoint.cap_cankaoP.V & "," & grobotSetPoint.cap_cankaoP.W & "," & grobotSetPoint.cap_cankaoP.J1 & "," & grobotSetPoint.cap_cankaoP.J2 & "," & grobotSetPoint.cap_cankaoP.J4 & "," & grobotSetPoint.cap_cankaoP.J6 & "," & grobotSetPoint.cap_cankaoP.hand & "," & "0" & "," & "0" & "," & "0"

    '    '合成为其它数据2Robot_Send_String(345)--Robot_Send_String(349)
    '    For i As Integer = 1 To 4
    '        Robot_Send_String(i + 345) = "FetPin_|" & i.ToString & "," & grobotSetPoint.fetchPin(i).X & "," & grobotSetPoint.fetchPin(i).Y & "," & grobotSetPoint.fetchPin(i).Z & "," & grobotSetPoint.fetchPin(i).U & "," & grobotSetPoint.fetchPin(i).V & "," & grobotSetPoint.fetchPin(i).W & "," & grobotSetPoint.fetchPin(i).J1 & "," & grobotSetPoint.fetchPin(i).J2 & "," & grobotSetPoint.fetchPin(i).J4 & "," & grobotSetPoint.fetchPin(i).J6 & "," & grobotSetPoint.fetchPin(i).hand & "," & grobotSetPoint.fetchPin(i).toolflag & "," & grobotSetPoint.fetchpinHeight & "," & "0"
    '    Next




    '    Dim _Qufast1 As String = "0"
    '    Dim _Insertfast1 As String = "0"
    '    Dim _handNormallyStatus As String
    '    If gallpoints.PinPawNo.ZhaoType = "夹爪常闭" Then
    '        _handNormallyStatus = 1
    '    Else
    '        _handNormallyStatus = 2
    '    End If
    '    If gallpoints.PinPawNo.QuFast = "快速" Then
    '        _Qufast1 = "1"
    '    Else
    '        _Qufast1 = "0"
    '    End If
    '    If gallpoints.PinPawNo.InsertFast = "快速" Then
    '        _Insertfast1 = "1"
    '    Else
    '        _Insertfast1 = "0"
    '    End If
    '    Robot_Send_String(350) = "PinPaw_|1" & "," & grobotSetPoint.fetpinrownum & "," & grobotSetPoint.fetpincolumnnum & "," & _handNormallyStatus & "," & gallpoints.PinPawNo.CloseTime & "," & gallpoints.PinPawNo.LoosenTime & "," & gallpoints.PinPawNo.GrabLengh.ToString & "," & (grobotSetPoint.Stand_Pin_Len - Val(gallpoints.PinPawNo.mLengh)).ToString & "," & _Qufast1 & "," & _Insertfast1 & "," & gallpoints.PutPinTool & "," & "0" & "," & "0" & "," & "0" & "," & "0"
    '    Robot_Send_String(351) = "PinNG_|1" & "," & grobotSetPoint.fetpin_NG.X & "," & grobotSetPoint.fetpin_NG.Y & "," & grobotSetPoint.fetpin_NG.Z & "," & grobotSetPoint.fetpin_NG.U & "," & grobotSetPoint.fetpin_NG.V & "," & grobotSetPoint.fetpin_NG.W & "," & grobotSetPoint.fetpin_NG.J1 & "," & grobotSetPoint.fetpin_NG.J2 & "," & grobotSetPoint.fetpin_NG.J4 & "," & grobotSetPoint.fetpin_NG.J6 & "," & grobotSetPoint.fetpin_NG.hand & "," & grobotSetPoint.fetpin_NG.toolflag & "," & grobotSetPoint.fetpin_NGHeight & "," & "0"

    '    Robot_Send_String(352) = "DetPin_|1" & "," & grobotSetPoint.fetpin_Detect.X & "," & grobotSetPoint.fetpin_Detect.Y & "," & grobotSetPoint.fetpin_Detect.Z & "," & grobotSetPoint.fetpin_Detect.U & "," & grobotSetPoint.fetpin_Detect.V & "," & grobotSetPoint.fetpin_Detect.W & "," & grobotSetPoint.fetpin_Detect.J1 & "," & grobotSetPoint.fetpin_Detect.J2 & "," & grobotSetPoint.fetpin_Detect.J4 & "," & grobotSetPoint.fetpin_Detect.J6 & "," & grobotSetPoint.fetpin_Detect.hand & "," & grobotSetPoint.fetpin_Detect.toolflag & "," & grobotSetPoint.fetpin_DetectHeight & "," & "0"
    '    For i As Integer = 1 To 40
    '        Robot_Send_String(352 + i) = "Re_|" & i.ToString & "," & gallpoints.insertObject(i).Re_Cycle_Point.X & "," & gallpoints.insertObject(i).Re_Cycle_Point.Y & "," & gallpoints.insertObject(i).Re_Cycle_Point.Z & "," & gallpoints.insertObject(i).Re_Cycle_Point.U & "," & gallpoints.insertObject(i).Re_Cycle_Point.V & "," & gallpoints.insertObject(i).Re_Cycle_Point.W & "," & gallpoints.insertObject(i).Re_Cycle_Point.J1 & "," & gallpoints.insertObject(i).Re_Cycle_Point.J2 & "," & gallpoints.insertObject(i).Re_Cycle_Point.J4 & "," & gallpoints.insertObject(i).Re_Cycle_Point.J6 & "," & gallpoints.insertObject(i).Re_Cycle_Point.hand & "," & gallpoints.insertObject(i).Re_Cycle_Point.toolflag & "," & "0" & ",0"
    '    Next
    '    '合成为取料过渡点Robot_Send_String(393)--Robot_Send_String(432)
    '    For i As Integer = 1 To 40
    '        Dim _aa As String
    '        If gallpoints.insertObject(i).takePicTransUsed = True Then
    '            _aa = "1"
    '        Else
    '            _aa = "0"
    '        End If
    '        Robot_Send_String(i + 392) = "GD_P|" & i.ToString & "," & gallpoints.insertObject(i).takePicTransPoint.X & "," & gallpoints.insertObject(i).takePicTransPoint.Y & "," & gallpoints.insertObject(i).takePicTransPoint.Z & "," & gallpoints.insertObject(i).takePicTransPoint.U & "," & gallpoints.insertObject(i).takePicTransPoint.V & "," & gallpoints.insertObject(i).takePicTransPoint.W & "," & gallpoints.insertObject(i).takePicTransPoint.J1 & "," & gallpoints.insertObject(i).takePicTransPoint.J2 & "," & gallpoints.insertObject(i).takePicTransPoint.J4 & "," & gallpoints.insertObject(i).takePicTransPoint.J6 & "," & gallpoints.insertObject(i).takePicTransPoint.hand & "," & gallpoints.insertObject(i).takePicTransPoint.toolflag & "," & "0" & "," & _aa
    '    Next
    '    Robot_Send_String(433) = "Mark_Start_|" & "," & grobotSetPoint.Mark_StartPoint.X & "," & grobotSetPoint.Mark_StartPoint.Y & "," & grobotSetPoint.Mark_StartPoint.Z & "," & grobotSetPoint.Mark_StartPoint.U & "," & grobotSetPoint.Mark_StartPoint.V & "," & grobotSetPoint.Mark_StartPoint.W & "," & grobotSetPoint.Mark_StartPoint.J1 & "," & grobotSetPoint.Mark_StartPoint.J2 & "," & grobotSetPoint.Mark_StartPoint.J4 & "," & grobotSetPoint.Mark_StartPoint.J6 & "," & grobotSetPoint.Mark_StartPoint.hand & "," & grobotSetPoint.Mark_StartPoint.toolflag & "," & "0" & "," & "0"

    '    '合成为简易盘料参数Robot_Send_String(434)--Robot_Send_String(554)
    '    For j As Integer = 2 To 3
    '        For i As Integer = 1 To 40
    '            Robot_Send_String((i + 433) + ((j - 2) * 40)) = "QSimpFd_" & j & "|" & i.ToString & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).X & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).Y & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).Z & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).U & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).V & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).W & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).J1 & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).J2 & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).J4 & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).J6 & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).hand & "," & gallpoints.insertObject(i).fet_SimpFed_points(j).toolflag & "," & gallpoints.insertObject(i).fet_SimpFedHeight & ",0"
    '        Next
    '    Next

    '    '合成为简易盘料参数Robot_Send_String(554)--Robot_Send_String(594)
    '    For i As Integer = 1 To 40
    '        Dim _aa As String
    '        If gallpoints.insertObject(i).simple_Feeder_Used = True Then
    '            _aa = "1"
    '        Else
    '            _aa = "0"
    '        End If
    '        Robot_Send_String(i + 513) = "SimpFd_A|" & i.ToString & "," & gallpoints.insertObject(i).simple_Feeder_row & "," & gallpoints.insertObject(i).simple_Feeder_column & "," & _aa & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0" & "," & "0"
    '    Next
    '    'gepson_com.RobotPointString = Robot_Send_String
    '    Return Robot_Send_String
    'End Function



    Sub do_Get_1(ByRef vObj1 As clsAllPoints, ByRef vObj2 As clsOrderList, ByVal vProdName As String)
        Dim _FileObj As New clsSetUpFileObj
 

        Dim _fn As String
        _fn = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Products\" & vProdName & "\" & vProdName & ".json")
        Call do_ReadData_1(_fn, _FileObj)
        'vObj1 = _FileObj.gallpoints
        'vObj2 = _FileObj.gclsOrderList
        vObj1 = _FileObj.obj1
        vObj2 = _FileObj.obj2

    End Sub


    Public Sub do_ReadData_1(ByVal vPath As String, ByRef vClassType As clsSetUpFileObj)
        Try
            Dim _jsConvert As New System.Web.Script.Serialization.JavaScriptSerializer
            Dim _str As String = File.ReadAllText(vPath)
            vClassType = _jsConvert.Deserialize(Of clsSetUpFileObj)(_str) '
        Catch ex As Exception
            MsgBox("数据读取异常" + ex.ToString)
        End Try

    End Sub

    Sub do_Get_2(ByRef vObj1 As clsRobotSet, ByRef vObj2 As List(Of RobotHead), ByRef vObj3 As clsRobotSetPoint, ByRef vobj4 As track_Data)
        Dim _FileObj As New clsSetUpFileObj

        Dim _fn As String
        _fn = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SetUps\SetUp.json")

        Call do_ReadData_2(_fn, _FileObj)
        'vObj1 = _FileObj.gRobotset
        'vObj2 = _FileObj.gRobotHead
        'vObj3 = _FileObj.grobotSetPoint
        'vobj4 = _FileObj.gxiantiPra

        vObj1 = _FileObj.obj1_RobotSet
        vObj2 = _FileObj.obj2_RobotHead
        vObj3 = _FileObj.obj3_RobotSetPoint
        vobj4 = _FileObj.obj4_track_Data

    End Sub






    Public Sub do_ReadData_2(ByVal vPath As String, ByRef vClassType As clsSetUpFileObj)
        Try
            Dim _jsConvert As New System.Web.Script.Serialization.JavaScriptSerializer
            Dim _str As String = File.ReadAllText(vPath)
            vClassType = New clsSetUpFileObj
            vClassType = _jsConvert.Deserialize(Of clsSetUpFileObj)(_str) '
        Catch ex As Exception
            MsgBox("读取的数据格式有误")
        End Try

    End Sub


    Public Function Send_Point_Sub(ByVal SendString() As String) As Boolean
        Dim _rcv As String
        Dim _ret As String
        _rcv = m_tcp8.SendF8("N " & SendString.Length.ToString)
        _ret = dao_Epson.GetStatus(_rcv, "N")
        If _ret <> "P" Then
            Return False
            Exit Function
        End If



        '发送点位 
        For i As Integer = 0 To SendString.Length - 1

            _rcv = m_tcp8.SendF8(SendString(i))
            _ret = dao_Epson.GetStatus(_rcv, "N")


            If _ret = "P" Then
                _rcv = ""
                _ret = ""
            Else
                'm_tcp5.doConnectionR5("192.168.0.1", "5000")
                '_do_Login()
                'm_tcp8.doConnectionF8("192.168.0.1", "8000")
                'recievedata = m_tcp8.SendF8(SendString(i))
                '_ret = dao_Epson.GetStatus(recievedata, "N")
                If _ret <> "P" Then
                    Return False
                    Exit Function
                End If
            End If
        Next
        Return True
    End Function


    Private Sub _do_Login()
        Dim recievedata As String
        Dim strSend As String
        Dim _ret As String

        'login
        strSend = "$login,123"
        recievedata = m_tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#login,0")


        strSend = "$SetMotorsOn,1"
        recievedata = m_tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#SetMotorsOn,0")


        'Reset
        strSend = "$Reset"
        recievedata = m_tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Reset,0")

        'Stop
        strSend = "$Stop,0"
        recievedata = m_tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")

        'Start
        strSend = "$Start,0"
        recievedata = m_tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")

        'Start
        strSend = "$Start,1"
        recievedata = m_tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")
    End Sub

End Class
