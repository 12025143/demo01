Imports FACC
Imports System.Threading

Public Class RobotAction

    Dim _ret As String
    Dim _di_ret As Integer

    Dim strSend As String = ""
    Dim strRcvd As String = ""

    Dim cap_OnceGrabnum As Integer '拍照计数器
    Dim now_PiChi As Integer '当前批次计数器

    Dim cap_Insert_Point_NG_Total As Boolean  '抓拍后是否有不良品
    Dim cap_Mark_Had As Boolean = False '当前批次是否已进行过拍Mark点


    Dim cap_Grab_List As New List(Of String) '抓拍列表
    Dim cap_Grab_NG_list As New List(Of Integer) '抓拍后不良品列表
    Dim Pichi_List As New List(Of Integer) '批次列表

    'Dim Robot_UP_Had_String As New List(Of Integer) ''记录夹子上有产品的编号    'Dim NG_Product_str As New List(Of String) '不良品列表
    'Dim InsertNGstring As New List(Of String) '插件不良的计数

    Dim m_tcp5 As clsTcp
    Dim m_tcp8 As clsTcp
    Dim dao_Epson As New clsEpsonCom


    Sub New(ByVal tcp5 As clsTcp, ByVal tcp8 As clsTcp)
        m_tcp5 = tcp5
        m_tcp8 = tcp8

    End Sub


    Sub robot_1_actionsub()

        Dim VisionResult As Integer = -1

        Try
10:
            GoTo 1001
1001:
            '设置机械手运行功率
            '发送：E 2 0  
            '返回：成功返回 "E " 失败返回 ""
            '参数说明：E ：置运行功率  第二个参数：1：低功率；2：高功率；第三个参数：0：正常插件，1：空打   
            strSend = "E 2 0"
            strRcvd = m_tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(strRcvd, "E")
            If _ret = "P" Then
                GoTo 11
            End If
            GoTo 1001

11:         '启动机械手去取料位置
            '发送：Q A 2 0
            '返回：成功返回 "Q " 失败返回 ""
            '参数说明： QA:启动取料命令  2:物料号  0：矩阵托盘的功能，表示当前取托盘的第几个料            '取料只会一个料一个料的发，不会多个料同时发

            strSend = "Q A 1 0"
            strRcvd = m_tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(strRcvd, "Q")
            If _ret <> "P" Then GoTo 11

            DI_ReadLine(Card7230, 0, 1, _di_ret) 'InputNum(14)  机械手提高信号
            If _di_ret <> 0 Then GoTo 11
            If robot_Ashoudongstart = True Then Exit Sub
            GoTo 1200

1200:       '等待机械手夹紧
            DI_ReadLine(Card7230, 0, 1, _di_ret) 'InputNum(14) 机械手提高信号 
            If _di_ret = 1 Then

                'GoTo 1203
1203:           '机械手取料时，输出给机械手可以离开信号
            Else
                'GoTo 1201
1201:           '输出给供料器 打开夹爪信号
            End If
            _ret = DO_WriteLine(Card7230, 0, 0, 1)   'OutputNum(18) 供料器打开完成信号
12:         '等待机械手去取料位置

            'DI_ReadLine(0, 6, 0,  di_ret) 'InputNum(13) 机械手到位信号            DI_ReadLine(Card7230, 0, 0, _di_ret)  'InputNum(13)
            If _di_ret <> 1 Then GoTo 12
            _ret = DO_WriteLine(Card7230, 0, 0, 0)   'OutputNum(18)  '供料器没打开 
            Now_grab_Num = Now_grab_Num + 1
            GoTo 13
13:
            'Now_grab_Num  当前批次的取料个数
            'QuJian_String_list 当前取件的列表
            If Now_grab_Num > QuJian_String_list.Count Then
                GoTo 1400
            Else
                GoTo 10  '返回继续取料
            End If

1400:       '拍照
            '发送：A 2
            '返回：成功返回 "A "  失败返回 ""
            '参数说明：A：拍照命令  2：拍第2个夹爪的料(可以连发：如多个料时发 A 2 3 4 1 )
            strSend = "A 1" '
            strRcvd = m_tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(strRcvd, "A")
            'do_Show(strSend, recievedata)

            ' DI_ReadLine(0, 6, 1, di_ret) 'InputNum(14) 机械手提高信号            DI_ReadLine(Card7230, 0, 1, _di_ret)
            If _ret <> "P" Then GoTo 1400
            If _di_ret <> 0 Then GoTo 1400
            If robot_Ashoudongstart = True Then Exit Sub
            GoTo 15

15:
            'DI_ReadLine(0, 6, 1, di_ret) 'InputNum(14) 机械手提高信号            DI_ReadLine(Card7230, 0, 1, _di_ret)
            If _di_ret <> 1 Then GoTo 15
            _ret = DO_WriteLine(Card7230, 0, 0, 0)   'OutputNum(18)  '供料器没打开
            If robot_Ashoudongstart = True Then Exit Sub
            GoTo 16
16:
            _ret = DO_WriteLine(Card7230, 0, 0, 1) '供料器打开完成信号
            GoTo 17
17:
            'DI_ReadLine(0, 6, 0, di_ret)
            DI_ReadLine(Card7230, 0, 0, _di_ret) 'InputNum(13) 机械手到位信号
            If _di_ret <> 1 Then GoTo 17
            _ret = DO_WriteLine(Card7230, 0, 0, 0) '  '供料器没打开
            GoTo 20
20:
            '发送：G 2
            '返回：成功返回 "G "    失败返回 ""
            '参数说明：'G：放NG品   2：供料器2 (可以连发：如多个料时发 G 1 2 3 4  )
            strSend = "G 1"
            strRcvd = m_tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(strRcvd, "G")
            'do_Show(strSend, recievedata)

            If _ret <> "P" Then GoTo 20

            GoTo 21

21:

            'DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13) 机械手到位信号            DI_ReadLine(Card7230, 0, 0, _di_ret)  'InputNum(13)
            If _di_ret <> 1 Then GoTo 21
            GoTo 2

2:          '  拍Mark点            '发送：M 1 2
            '返回：成功返回 "M " 失败返回 ""
            '参数说明： M：放NG品   2：供料器2 (可以连发：如多个料时发 M 1 2 3 4  )
            strSend = "M 1 2 0 0" '
            strRcvd = m_tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(strRcvd, "M")
            'do_Show(strSend, recievedata)

            If _ret <> "P" Then GoTo 2
            _ret = DO_WriteLine(Card7230, 0, 0, 0) '  '供料器没打开 
            GoTo 3

3:

            DI_ReadLine(Card7230, 0, 1, _di_ret) 'InputNum(14) 机械手提高信号 
            If _di_ret <> 1 Then GoTo 3
            GoTo 4



4:
            '等待板进料到位            DO_WriteLine(Card7230, 0, 0, 0)
            'If RobotAActionStart = False Then GoTo 4   '等待板进料到位 
            RobotAActionStart = False
            GoTo 5


5:

            _ret = DO_WriteLine(Card7230, 0, 0, 1) '供料器打开完成信号
            ''VisionResult = mvision.ExcuteTest(mark_1_visionArchivesName, 2, hwindow, 320, 240, 0) '
            'Dim str As String = "11|50.002|100.56|100"
            '_ret = F_Client_BLL.doCommand_01(1, str)
            'System.Threading.Thread.Sleep(20)
            '' 延时后读数据
            'm_da.Receive()
            'Thread.Sleep(30)
            'VisionResult = strVision

            GoTo 7
7:          '等待机械手到Mark点2位置完成


            DI_ReadLine(Card7230, 0, 0, _di_ret) 'InputNum(13) 机械手到位信号
            If _di_ret <> 1 Then GoTo 7
            _ret = DO_WriteLine(Card7230, 0, 0, 0)  '  '供料器没打开
            GoTo 8000
8000:

            '发送Mark点像素值(X	x1	y1	x2	y2)

            '发送：X 320 240 320 240
            '返回：成功返回 "X " 失败返回 ""
            '参数说明： X：发送Mark点像素值  320:X1  240:Y1   320:X2  240:Y2 (可以连发:如 X 320 240 320 240 320 240 )
            ' 320 240  是中心点，先固定写这个值 

            strSend = "X 320 240 320 240"
            strRcvd = m_tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(strRcvd, "X")
            'do_Show(strSend, recievedata)
            If _ret <> "P" Then GoTo 8000
            GoTo 23111

23111:
            '发送偏移量(Y	元件号	X偏移	Y偏移	角度)


            '发送：Y 2 0 0 0
            '返回：成功返回 "Y " 失败返回 ""
            '参数说明：Y：发送偏移量指令  2:物料号  0:X偏移   0:Y偏移  0:角度 (可以连发:如 Y 2 0 0 0 1 0 0 0 3 0 0 0 )

            strSend = "Y 1 0 0 0 "
            strRcvd = m_tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(strRcvd, "Y")
            'do_Show(strSend, recievedata)
            If _ret <> "P" Then GoTo 23111
            GoTo 23

23:
            '插件( P 点位号)
            '发送：P 2
            '返回：成功返回 "P " 失败返回 ""
            '参数说明：P：插件指令  2:点位号 (可以连发:如 P 2 3 1 )

            strSend = "P 1"
            strRcvd = m_tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(strRcvd, "P")
            'do_Show(strSend, recievedata)
            If _ret <> "P" Then GoTo 23
            GoTo 24
24:

            'DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13) 机械手到位信号            DI_ReadLine(Card7230, 0, 0, _di_ret)  'InputNum(13)
            If _di_ret <> 1 Then GoTo 24
            GoTo 2500
2500:
            '查询是否有插件不良(S)
            '返回：S 0 0 0 0 0 6 0 0 0 0 0 0 0 0 0 0：表示20个数据的状态，如果是不良的，则返回数值            strSend = "S"
            strRcvd = m_tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(strRcvd, "S")
            'do_Show(strSend, recievedata)

            If _ret <> "P" Then GoTo 2500
            GoTo 26

26:
            RobotAActionDone = True

            GoTo 10

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '多插件
    Sub robot_3_actionsub()
        Dim _msg As DialogResult
        Dim _bolVision As Boolean = False
        Dim fet_SimpFed_Fed_Nownum(10) As Integer

0:
        '(m_maindata.gIODll.InputNumStatus(m_maindata.gIODll.InputNum(7))
        'If safepingbi Then
        '    GoTo 1000
        'End If

        _ret = DI_ReadLine(Card7432, 0, 5, _di_ret) '安全门信号
        If _di_ret = "1" Or safepingbi = True Then GoTo 1000 '安全门是否有屏蔽
        '-------------------------------------------------
1000:
        If RobotAStartrun = True Then GoTo 200 '8000 TCP 连接通信成功  心跳 看门狗
        '用心跳处理
        '        GoTo 1
        '1:      '开启 8000 端口
        '        strSend = "$Stop,0"  ' 停止Robot模块0
        '        recievedata = m_tcp5.SendR5(strSend)
        '        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")
        '        'do_Show(strSend, _ret)
        '        Thread.Sleep(300)

        '        strSend = "$Start,0" ' 启动Robot模块0
        '        recievedata = m_tcp5.SendR5(strSend)
        '        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")
        '        'do_Show(strSend, _ret)
        '        If _ret = "P" Then
        '            m_tcp8.doConnectionF8(txtIpR8.Text, txtPort8.Text) '800
        '            RobotAStartrun = True
        '        End If
        '        GoTo 200
        '-------------------------------------------------

200:
        '设置机械手运行功率
        '发送：E 2 0  
        '返回：成功返回 "E " 失败返回 ""
        '参数说明：E ：置运行功率  第二个参数：1：低功率；2：高功率；第三个参数：0：正常插件，1：空打   
        strSend = "E 2 0"
        strRcvd = m_tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(strRcvd, "E")
        If _ret <> "P" Then GoTo 200
        GoTo 9
        '------------------------------------------------------------------------------
9:
        Now_grab_Num = 0
        cap_OnceGrabnum = 0

        'Robot_UP_Had_String.Clear() '夹头上有原件

        QuJian_String_list.Clear()
        cap_Grab_List.Clear()

        fet_SimpFed_Fed_Nownum(0) = 1
        fet_SimpFed_Fed_Nownum(1) = 1

        QuJian_String_list.Add("1")
        QuJian_String_list.Add("3")

        cap_Grab_List.Add("1")
        cap_Grab_List.Add("3")

        GoTo 1002
1002:   '把当前批次要取料的内容放取件列表
        If QuJian_String_list.Count > 0 Then
            GoTo 10
        End If
10:
        GoTo 1001
1001:
        'If OnceGrabCount > 0 Then  '??? 上面赋值1，下面判断大于0？？
        GoTo 11
        'End If
11:
        '1 取件 ------------------------------------------------------------------------------
        '启动机械手去取料位置
        '发送：Q A 2 0
        '返回：成功返回 "Q " 失败返回 ""
        '参数说明： QA:启动取料命令  2:物料号  0：矩阵托盘的功能，表示当前取托盘的第几个料        '取料只会一个料一个料的发，不会多个料同时发
        strSend = "Q A " & QuJian_String_list(Now_grab_Num) & " " & fet_SimpFed_Fed_Nownum(Now_grab_Num)  '...
        strRcvd = m_tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(strRcvd, "Q")
        If _ret <> "P" Then GoTo 11
        'do_Show(strSend, recievedata)           '0 ：第几张卡 1：机 械手提高信号
        _ret = DI_ReadLine(Card7230, 0, 1, _di_ret) 'InputNum(14)  
        If _di_ret <> 0 Then GoTo 11

        If robot_Ashoudongstart = True Then Exit Sub
        GoTo 1200

1200:
        _ret = DI_ReadLine(Card7230, 0, 1, _di_ret) 'InputNum(14) 机械手到达取料位置
        If _di_ret <> 1 Then GoTo 1200

        GoTo 1203
1203:   '机械手取料时，输出给机械手可以离开信号
        DO_WriteLine(Card7230, 0, 0, 1) 'OutputNum(18) 机械手继续移动
        GoTo 12
12:
        _ret = DI_ReadLine(Card7230, 0, 0, _di_ret)  'InputNum(13) 机械手到位信号
        If _di_ret <> 1 Then GoTo 12

        DO_WriteLine(Card7230, 0, 0, 0)   'OutputNum(18) 
        Now_grab_Num += 1
        GoTo 13
13:
        ' Now_grab_Num += 1  '取料累加计数
        If Now_grab_Num >= QuJian_String_list.Count Then
            Now_grab_Num = 1 '取完一批后清零当前计数
            GoTo 1400
        End If
        GoTo 10  '返回继续取料


1401:   '对拍照元件重新排序
        If cap_Grab_NG_list.Count > 0 Then
            GoTo 14
        End If
        GoTo 0
        Exit Sub

14:
        If _bolVision = True Then  '当前批次中，有使用视觉的
            GoTo 1400
        End If
        '都没有使用视觉
        GoTo 18


1400:
        '拍照 ------------------------------------------------------------------------------
        '发送：A 2
        '返回：成功返回 "A "  失败返回 ""
        '参数说明：A：拍照命令  2：拍第2个夹爪的料(可以连发：如多个料时发 A 2 3 4 1 )
        strSend = "A 1 2"
        strRcvd = m_tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(strRcvd, "A")
        If _ret <> "P" Then GoTo 1400
        'do_Show(strSend, recievedata)

        _ret = DI_ReadLine(Card7230, 0, 1, _di_ret) 'InputNum(14) 机械手提高信号
        If _di_ret <> 0 Then GoTo 1400

        If robot_Ashoudongstart = True Then Exit Sub
        GoTo 15
15:
        _ret = DI_ReadLine(Card7230, 0, 1, _di_ret)  '机械手到达拍照位置
        If _di_ret <> 1 Then GoTo 15

        _ret = DO_WriteLine(Card7230, 0, 0, 0)   'OutputNum(18)  '供料器没打开
        If robot_Ashoudongstart = True Then Exit Sub
        GoTo 16
16:
        '光源是IO控制还是通讯控制
        'VisionResult = mvision.ExcuteTest(m_maindata.gallpoints.insertObject(Now_Grab_No).visionParam.PVision_Name, 1, hwindow, Xpos, Ypos, Anglem) '                  
        'visionArchivesName = m_maindata.gallpoints.insertObject(Now_Grab_No).visionParam.PVision_Name
        '备注to H：VisonResult 视觉结果，0是正常，1是无结果
        If Robot_ATryInsert = False Then  '不是试插模式，执行下一步 
            _ret = DO_WriteLine(Card7230, 0, 0, 1) 'OutputNum(18) 机械手继续移动 
        End If

        GoTo 1700

1700:   '判断是否是单个试插模式
        If Robot_ATryInsert = True Then
            _msg = MessageBox.Show("请确认当前插件的视觉是否正确！", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            If _msg = DialogResult.Yes Then
                _ret = DO_WriteLine(Card7230, 0, 0, 1) 'OutputNum(18) 机械手继续移动
                cap_OnceGrabnum += 1 '拍照次数
                GoTo 17 '视觉正确
            Else
                GoTo 1701 '视觉不正确，进入调试视觉
            End If
        End If

        cap_OnceGrabnum += 1 '拍照次数
        GoTo 17

1701:   '重新移动到拍照位置
        _ret = DI_ReadLine(Card7230, 0, 0, _di_ret) 'InputNum(13) 机械手到位信号
        If _di_ret <> 1 Then GoTo 1701 '原为 17

        DO_WriteLine(Card7230, 0, 0, 0) ' 
        GoTo 18

17:
        If cap_OnceGrabnum < cap_Grab_List.Count Then  '拍照次数大于拍照列表，表示拍照完成
            _ret = DI_ReadLine(Card7230, 0, 1, _di_ret)  'InputNum(14)
            If _di_ret <> 0 Then GoTo 17

            DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
            GoTo 15 '返回继续拍照
        End If


18:     '判断有无不良品" 
        For i As Integer = 0 To cap_Grab_NG_list.Count - 1
            'If Insert_PointOK(Robot_Data.Grab_String_list(i)) = False Then
            cap_Insert_Point_NG_Total = True
            Exit For ' wy: ??
            'End If
        Next

        'NG_Product_str.Clear() '清除不良品计数
        GoTo 19
19:
        If cap_Insert_Point_NG_Total Then '拍照全部OK，没有不良品，执行下一步
            cap_Insert_Point_NG_Total = False
            'GoTo 20
        End If
        GoTo 2000
2000:
        'If Robot_UP_Had_String.Count > 0 Then  '当前夹子上有产品
        If cap_Mark_Had = False Then
            cap_Mark_Had = True
            GoTo 2 '第一次进入，需要拍Mark点
        End If
        GoTo 22 '去放良品

        'End If
        GoTo 2500

2:
        '拍Mark点 ------------------------------------------------------------------------------
        '发送：M 1 2
        '返回：成功返回 "M " 失败返回 ""
        '参数说明： M：放NG品   2：供料器2 (可以连发：如多个料时发 M 1 2 3 4  )
        strSend = "M 1 2 0 0" '
        strRcvd = m_tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(strRcvd, "M")
        'do_Show(strSend, recievedata)
        If _ret <> "P" Then GoTo 2

        _ret = DI_ReadLine(Card7230, 0, 0, _di_ret) 'InputNum(13) 
        If _di_ret <> 0 Then GoTo 2

        DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
        GoTo 3
3:
        _ret = DI_ReadLine(Card7230, 0, 1, _di_ret) '机械手到达Mark1位置
        If _di_ret <> 1 Then GoTo 3

        GoTo 4
4:
        '等待板进料到位
        'If RobotAActionStart = False Then GoTo 4
        DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
        RobotAActionStart = False
        GoTo 5

5:
        '_ret = DO_WriteLine(Card7230, 0, 0, 1) '供料器打开完成信号
        'VisionResult = mvision.ExcuteTest(mark_1_visionArchivesName, 2, hwindow, 320, 240, 0) '
        DO_WriteLine(Card7230, 0, 0, 1) 'OutputNum(18) 
        GoTo 7
7:
        _ret = DI_ReadLine(Card7230, 0, 0, _di_ret) 'InputNum(13)  机械手到位信号
        If _di_ret <> 1 Then GoTo 7

        DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
        GoTo 8

8:
        'DO_WriteLine(Card7432, 0, 11, 1) '机械手继续移动mark2位置
        'VisionResult = mvision.ExcuteTest(m_maindata.gallpoints.mark_2_visionArchivesName, 2, hwindow, Xpos, Ypos, Anglem) '
        'visionArchivesName = m_maindata.gallpoints.mark_2_visionArchivesName
        'DO_WriteLine(Card7432, 0, 11, 0)
        GoTo 8000
8000:
        '发送Mark点像素值(X	x1	y1	x2	y2)
        '发送：X 320 240 320 240
        '返回：成功返回 "X " 失败返回 ""
        '参数说明： X：发送Mark点像素值  320:X1  240:Y1   320:X2  240:Y2 (可以连发:如 X 320 240 320 240 320 240 )
        ' 320 240  是中心点，先固定写这个值
        strRcvd = m_tcp8.SendF8("X 320 240 320 240")
        _ret = dao_Epson.GetStatus(strRcvd, "X")
        'do_Show(strSend, recievedata)
        If _ret <> "P" Then GoTo 8000

        GoTo 22
22:
        GoTo 22000
22000:

        If Robot_ATryInsert Then GoTo 23111
23111:
        '发送偏移量(Y	元件号	X偏移	Y偏移	角度)
        '发送：Y 2 0 0 0
        '返回：成功返回 "Y " 失败返回 ""
        '参数说明：Y：发送偏移量指令  2:物料号  0:X偏移   0:Y偏移  0:角度 (可以连发:如 Y 2 0 0 0 1 0 0 0 3 0 0 0 )
        strRcvd = m_tcp8.SendF8("Y 1 0 0 0 0 0 0 0 2 0 0 0 0 0 0 0")
        _ret = dao_Epson.GetStatus(strRcvd, "Y")
        'do_Show(strSend, recievedata)
        If _ret <> "P" Then GoTo 23111

        GoTo 23
23:
        '插件 ------------------------------------------------------------------------------
        strRcvd = m_tcp8.SendF8("P 1 2")
        _ret = dao_Epson.GetStatus(strRcvd, "P")
        If _ret <> "P" Then GoTo 23
        'do_Show(strSend, recievedata)

        GoTo 24
24:
        'DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13) 机械手到位信号        _ret = DI_ReadLine(Card7230, 0, 0, _di_ret)
        If _di_ret <> 1 Then GoTo 24

        '_ret = DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14) 插件NG信号
        'If di_ret = 1 Then
        'GoTo 2400
        'End If
        GoTo 2500


2500:
        '查询是否有插件不良(S)
        '返回：S 0 0 0 0 0 6 0 0 0 0 0 0 0 0 0 0：表示20个数据的状态，如果是不良的，则返回数值
        strRcvd = m_tcp8.SendF8("S")
        _ret = dao_Epson.GetStatus(strRcvd, "S")
        If _ret <> "P" Then GoTo 2500
        'do_Show(strSend, recievedata)

        GoTo 2501
2501:
        'If InsertNGstring.Count > 0 Then '插件不良的计数列表
        'GoTo 2502
        'End If
        GoTo 25

25:
        now_PiChi += 1
        If now_PiChi > Pichi_List.Count Then  '当前批次完成返回继续下一批次   'Pichi_Num_List 每个批次的个数 
            now_PiChi = 1
            'GoTo 26
        End If
        Now_grab_Num = 0
        cap_OnceGrabnum = 0

        GoTo 9

    End Sub

End Class
