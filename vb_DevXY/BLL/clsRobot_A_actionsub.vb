Imports FACC.iceService
Imports System.Threading



Partial Public Class frmRobot


    'Dim QuJian_String_list As New List(Of String)
    Dim LoopNum As Integer
    Dim Now_PiChi As Integer '当前插件批次
    Dim Total_PiChi As Integer   '插件总批次
    Dim GL_pingbi As Boolean = False
    Dim OnceGrabnum As Integer
    Dim GrabListString As New List(Of String) '需要拍照的情况
    Dim Insert_Point_NG_Total As Boolean  '拍照判断OK信号总状态
    Dim GrabNg_Retry_Qu_Now_num As Integer '拍照不良的报警次数
    Dim GrabNg_Retry_Qu_Total_num As Integer  '重拍次数  界面来源 frm_config_style 
    Dim NG_Product_str As New List(Of String) '不良品记录
    Dim robot_Aalarmstatus As Boolean = False
    Dim InsertNowNum As Integer
    Dim InsertTotalNum As Integer
    Dim Mark_Had_Grab As Boolean = False
    Dim BuChaStatus As Boolean = False '补插
    Dim InsertNGstring As New List(Of String) '插件不良的计数
    Dim Pichi_Num_List As New List(Of Integer)
    Dim RobotNGString As New List(Of String)
    Dim Re_Cycle As Boolean = False
    Dim Grab_String_list As New List(Of Integer)

    Dim Robot_hadNot_D As Boolean = False
    Dim Bucha_ok_done As Boolean = False
    Dim Robot_AOneTryInsert As Boolean = False '试插模式 界面来源  frm_try_once-->启动
    Dim simple_Feeder_Used As Boolean = False  '简易托盘    Dim OnceGrabCount As Integer = 0 '一次供料器准备好的个数
    '多件
    Sub robot_A_actionsub()
        Dim msg As DialogResult
0:
        '(m_maindata.gIODll.InputNumStatus(m_maindata.gIODll.InputNum(7))
        'If safepingbi Then
        '    GoTo 1000
        'End If
        DI_ReadLine(Card7432, 0, 5, di_ret) '安全门信号
        If di_ret = "1" Or safepingbi = True Then  '安全门是否有屏蔽
            GoTo 1000
        End If
        '-------------------------------------------------
1000:
        If RobotAStartrun = True Then   '8000 TCP 连接通信成功  心跳 看门狗
            GoTo 200
        End If
        GoTo 1

1:      '开启 8000 端口
        strSend = "$Stop,0"  ' 停止Robot模块0
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")
        do_Show(strSend, _ret)
        Thread.Sleep(300)

        strSend = "$Start,0" ' 启动Robot模块0
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")
        do_Show(strSend, _ret)
        If _ret = "P" Then
            _tcp8.doConnectionF8(txtIpR8.Text, txtPort8.Text) '800
            RobotAStartrun = True
        End If
        GoTo 200
        '-------------------------------------------------


200:
        '设置机械手运行功率
        '发送：E 2 0  
        '返回：成功返回 "E " 失败返回 ""
        '参数说明：E ：置运行功率  第二个参数：1：低功率；2：高功率；第三个参数：0：正常插件，1：空打   
        strSend = "E 2 0"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "E")
        If _ret = "P" Then
            GoTo 9
        End If
        GoTo 200

9:
        '处理供料器信号和插件列表  
        If Robot_hadNot_D = False Then    '一块新板要重新对list给值，Now_GLnum>1时说明是之前已经插过的，不重新给值
            Robot_hadNot_D = True '标志着一块新板到来
            Now_PiChi = 1
            Now_grab_Num = 1
            If Robot_AOneTryInsert = True Then
                Total_PiChi = 1
                Pichi_Num_List.Clear()
                Pichi_Num_List.Add("1")
            End If
            'Total_PiChi = Total_Set_PiChi
            Pichi_Num_List.Clear()
        End If
        GoTo 1002
1002:   '把当前批次要取料的内容放取件列表
        QuJian_String_list.Clear()
        Robot_UP_Had_String.Clear()

        If QuJian_String_list.Count > 0 Then
            If txtTestInterval.Text <= LoopNum Then
                LoopNum = 0
                GoTo 100
            End If
            GoTo 10
        End If
        Now_PiChi += 1
        If Now_PiChi > Total_PiChi Then
            Now_PiChi = 1
            GoTo 26
        End If
        GoTo 1002


10:
        GoTo 1001

1001:

        OnceGrabCount = 1
        If OnceGrabCount > 0 Then  '??? 上面赋值1，下面判断大于0？？
            GoTo 11
        End If


10000:
        '取回收料
        '发送：Q B 2
        '返回：成功返回 "Q " 失败返回 ""
        '参数说明： QB:取回收料命令  2:物料号 


        strSend = "Q B 2" '启动机械手去等待取料位置
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "Q")
        If _ret <> "P" Then GoTo 10000
        GoTo 10001
10001:
        DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13) 机械手到位信号
        If di_ret = 1 Then
            GoTo 10
        End If
        GoTo 10001
11:
        '启动机械手去取料位置
        '发送：Q A 2 0
        '返回：成功返回 "Q " 失败返回 ""
        '参数说明： QA:启动取料命令  2:物料号  0：矩阵托盘的功能，表示当前取托盘的第几个料        '取料只会一个料一个料的发，不会多个料同时发
        strSend = "Q A 2 0" '...
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "Q")
        If _ret <> "P" Then GoTo 11
        'do_Show(strSend, recievedata)           '0 ：第几张卡 1：机 械手提高信号
        DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14)  

        If di_ret <> 0 Then GoTo 11
        If robot_Ashoudongstart = True Then Exit Sub
        GoTo 1200

1200:
        DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14) 机械手到达取料位置
        If di_ret = 1 Then
            If simple_Feeder_Used = True Then '简易托盘
                GoTo 1203
            End If
            GoTo 1201
        End If
        GoTo 1200

1201:   '输出给供料器打开夹爪信号"
        If GL_pingbi = False Then ' 屏蔽供料器
            GoTo 1202
        End If
        GoTo 1203

1202:   '等待供料器打开完成信号"
        GoTo 1203
1203:   '机械手取料时，输出给机械手可以离开信号

        _ret = DO_WriteLine(Card7230, 0, 0, 1) 'OutputNum(18) 机械手继续移动
        GoTo 12

12:
        DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13) 机械手到位信号
        If di_ret <> 1 Then GoTo 12
        _ret = DO_WriteLine(Card7230, 0, 0, 0)   'OutputNum(18) 
        Now_grab_Num = Now_grab_Num + 1
        GoTo 13
13:
        Now_grab_Num = Now_grab_Num + OnceGrabCount '取料累加计数
        If Now_grab_Num > QuJian_String_list.Count Then
            Now_grab_Num = 1 '取完一批后清零当前计数
            GoTo 1400
        End If
        GoTo 10  '返回继续取料

1401:   '对拍照元件重新排序
        If Grab_String_list.Count > 0 Then

            GoTo 14
        End If
        GoTo 0
        Exit Sub


14:
        Dim bolVision As Boolean = False
        If bolVision = True Then  '当前批次中，有使用视觉的
            GoTo 1400
        End If
        '都没有使用视觉
        GoTo 18


1400:
        '拍照
        '发送：A 2
        '返回：成功返回 "A "  失败返回 ""
        '参数说明：A：拍照命令  2：拍第2个夹爪的料(可以连发：如多个料时发 A 2 3 4 1 )
        strSend = "A 2 1 4 " '
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "A")
        If _ret <> "P" Then GoTo 1400
        'do_Show(strSend, recievedata)

        DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14) 机械手提高信号
        If di_ret <> 0 Then GoTo 1400
        If robot_Ashoudongstart = True Then Exit Sub
        GoTo 15
15:
        DI_ReadLine(Card7230, 0, 1, di_ret)  '机械手到达拍照位置
        If di_ret <> 1 Then GoTo 15
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

            msg = MessageBox.Show("请确认当前插件的视觉是否正确！", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            If msg = DialogResult.Yes Then
                _ret = DO_WriteLine(Card7230, 0, 0, 1) 'OutputNum(18) 机械手继续移动
                OnceGrabnum += 1 '拍照次数
                GoTo 17
            End If
            GoTo 1701

        End If
        OnceGrabnum += 1 '拍照次数
        GoTo 17

1701:   '视觉程序设置好后，启动时，重新移动到拍照位置
        _ret = DO_WriteLine(Card7230, 0, 0, 1) 'OutputNum(18)
        GoTo 14
17:
        If OnceGrabnum >= GrabListString.Count Then  '拍照次数大于拍照列表，表示拍照完成
            DI_ReadLine(Card7230, 0, 0, di_ret) 'InputNum(13) 机械手到位信号
            If di_ret = 1 Then
                _ret = DO_WriteLine(Card7230, 0, 0, 0) ' 
                GoTo 18
            End If
            GoTo 17

        End If
        DI_ReadLine(Card7230, 0, 1, di_ret)  'InputNum(14)
        If di_ret = 0 Then
            _ret = DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
            GoTo 15 '返回继续拍照
        End If
        GoTo 17


18:     '判断有无不良品" 
        For i As Integer = 0 To Grab_String_list.Count - 1
            'If Insert_PointOK(Robot_Data.Grab_String_list(i)) = False Then
            Insert_Point_NG_Total = True
            Exit For
            'End If
        Next

        NG_Product_str.Clear() '清除不良品计数
        GoTo 19
19:
        If Insert_Point_NG_Total = True Then '拍照全部OK，没有不良品，执行下一步
            Insert_Point_NG_Total = False

            GoTo 20
        End If
        GoTo 2000

20:
        '发送：G 2
        '返回：成功返回 "G "    失败返回 ""
        '参数说明：'G：放NG品   2：供料器2 (可以连发：如多个料时发 G 1 2 3 4  )

        strSend = "G 2 1 4 "
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "G")
        'do_Show(strSend, recievedata)

        If _ret <> "P" Then GoTo 20

        GoTo 21
21:
        DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13) 机械手到位信号
        If di_ret = 1 Then
            GoTo 2100
        End If
        GoTo 21

2100:
        GrabNg_Retry_Qu_Now_num += 1 '拍照不良的报警次数
        If GrabNg_Retry_Qu_Now_num >= GrabNg_Retry_Qu_Total_num Then  '当重拍次数大于界面设定的次数执行下一步  （二代机界面：frm_config_style  ）
            GrabNg_Retry_Qu_Now_num = 0
            GoTo 2101
        End If
        GoTo 2102

2101:
        '??? 1.直接补插，2.最后补插，3跳过
2103:
        GoTo 2000
2102:
        If NG_Product_str.Count > 0 Then '有需要优先处理的不良品
            GoTo 10
        End If
        GoTo 2000


2000:
        If Robot_UP_Had_String.Count > 0 Then  '当前夹子上有产品
            If Mark_Had_Grab = False Then
                GoTo 2 '第一次进入，需要拍Mark点
            End If
            GoTo 22 '去放良品

        End If
        GoTo 2500

2:
        strSend = "M 1 2" '
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "M")
        'do_Show(strSend, recievedata)

        If _ret <> "P" Then GoTo 2
        '_ret = DO_WriteLine(Card7230, 0, 0, 0) '  '供料器没打开

        GoTo 3
3:
        DI_ReadLine(Card7230, 0, 1, di_ret) '机械手到达Mark1位置
        If di_ret <> 1 Then GoTo 3
        GoTo 4
4:
        '等待板进料到位
        If RobotAActionStart = False Then GoTo 4
        RobotAActionStart = False
        GoTo 5

5:
        '_ret = DO_WriteLine(Card7230, 0, 0, 1) '供料器打开完成信号
        'VisionResult = mvision.ExcuteTest(mark_1_visionArchivesName, 2, hwindow, 320, 240, 0) '
        GoTo 7
6:
        strSend = "M 2" '
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "M")
        If _ret = "P" Then
            GoTo 7
        End If
        GoTo 6


7:
        DI_ReadLine(Card7230, 0, 0, di_ret) 'InputNum(13)  机械手到位信号

        If di_ret = 1 Then
            _ret = DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
            GoTo 8
        End If
        GoTo 7

8:
        _ret = DO_WriteLine(Card7432, 0, 11, 1) '机械手继续移动mark2位置
        'VisionResult = mvision.ExcuteTest(m_maindata.gallpoints.mark_2_visionArchivesName, 2, hwindow, Xpos, Ypos, Anglem) '
        'visionArchivesName = m_maindata.gallpoints.mark_2_visionArchivesName
        _ret = DO_WriteLine(Card7432, 0, 11, 0)
        GoTo 8000
8000:
        strSend = "X 320 240 320 240"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "X")
        'do_Show(strSend, recievedata)
        If _ret <> "P" Then GoTo 8000
        GoTo 22

8001:
        strSend = "V"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "V")
        If _ret = "P" Then GoTo 22

        GoTo 8001


22:
        GoTo 22000
22000:


        If robot_Ashoudongstart = True Then
            GoTo 23001
        End If

        If Robot_ATryInsert = True Then
            GoTo 23111
        End If
23001:
        strSend = "Y 2 0 0 0 "
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "Y")
        'do_Show(strSend, recievedata)
        If _ret = "P" Then
            If Mark_Had_Grab = False Then  '未拍过Mark点
                Mark_Had_Grab = True '已经进入了一次拍Mark点动作
            End If
            GoTo 2300
        End If
2300:
        strSend = "B 2 "
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "B")
        If _ret = "P" Then
            GoTo 2301
        End If
        GoTo 2300

2301:
        DI_ReadLine(Card7230, 0, 0, di_ret) 'InputNum(13)  机械手到位信号
        If di_ret = 1 Then
            GoTo 230201
        End If
        GoTo 2301

230201:
        If Robot_ATryInsert = True Then

            msg = MessageBox.Show("请确认当前插件位置是否正确！", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            If msg = DialogResult.Yes Then
                GoTo 2302  '插件位置正确
            End If
            GoTo 230202  '插件位置不正确，进入插件位置补偿调试

        End If
        GoTo 2302

230202:
        GoTo 2300
2302:
        strSend = "D 2 "
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "D")
        If _ret = "P" Then
            GoTo 2303
        End If
        GoTo 2302


2303:
        DI_ReadLine(Card7230, 0, 0, di_ret) 'InputNum(13)  机械手到位信号
        If di_ret = 1 Then
            InsertNowNum += 1
            GoTo 2304
        End If
        GoTo 2303

2304:
        If InsertNowNum > InsertTotalNum Then
            GoTo 2500
        End If
        GoTo 2300

23111:
        strSend = "Y 2 0 0 0 "
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "Y")
        'do_Show(strSend, recievedata)
        If _ret <> "P" Then GoTo 23111
        GoTo 23
23:

        strSend = "P 2"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "P")
        'do_Show(strSend, recievedata)
        If _ret <> "P" Then GoTo 23
        GoTo 24
24:
        'DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13) 机械手到位信号        DI_ReadLine(Card7230, 0, 0, di_ret)
        If di_ret = 1 Then
            GoTo 2500
        End If
        DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14) 插件NG信号
        If di_ret = 1 Then
            GoTo 2400
        End If
        GoTo 24


2400:
        strSend = "F" '查询已插元件的编号和不良品元件编号
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "F|")
        If _ret = "P" Then
            GoTo 2401
        End If
2401:
        '处理补插
2402:
        '处理补插
2403:
        '处理补插
2404:   '把不良编号要取料的内容放取件列表
        QuJian_String_list.Clear()
        'QuJian_String_list.Add(Robot_Data.Robot_InsertNG_num)
        GoTo 2405

2405:   '启动机械手去放不良品位置
        strSend = "G 2"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "G")
        If _ret = "P" Then
            GoTo 2406
        End If
        GoTo 2405


2406:
        DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13) 机械手到位信号
        If di_ret = 1 Then
            GoTo 10
        End If
        GoTo 2406


2407:
        If Robot_UP_Had_String.Count > 0 Then
            GoTo 23 '返回继续插件
        End If
        GoTo 2500 '已经没有产品在机械手上


2500:
        '查询是否有插件不良(S)
        '返回：S 0 0 0 0 0 6 0 0 0 0 0 0 0 0 0 0：表示20个数据的状态，如果是不良的，则返回数值        strSend = "S"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "S")
        'do_Show(strSend, recievedata)

        If _ret <> "P" Then GoTo 2500
        GoTo 2501
2501:
        If InsertNGstring.Count > 0 Then '插件不良的计数列表
            GoTo 2502
        End If
        GoTo 25


2502:
        strSend = "G 2"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "G")
        If _ret = "P" Then
            GoTo 2503
        End If
        GoTo 2502


2503:
        DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13) 机械手到位信号
        If di_ret = 1 Then
            GoTo 25
        End If
        GoTo 2503

25:
        Now_PiChi += 1
        If Now_PiChi > Pichi_Num_List.Count Then  '当前批次完成返回继续下一批次   'Pichi_Num_List 每个批次的个数 
            Now_PiChi = 1
            GoTo 26
        End If
        GoTo 1002

26:
        If BuChaStatus = True Then   '有补插状态执行2601
            GoTo 2601
            If RobotNGString.Count > 0 Then '先判断是否还有不良，没有先放板
                Bucha_ok_done = False
            Else
                Bucha_ok_done = True
                RobotAActionDone = True '机械手动作完成信号
                Robot_hadNot_D = False  '当前定位的板已经完成
            End If

        Else
            GoTo 2600
        End If
        RobotAActionDone = True '机械手插件动作动作完成

        GoTo 10

2601:
        GoTo 2602
2602:
        GoTo 2600
2600:
        ' '处理补插
        If RobotNGString.Count > 0 Then
            GoTo 27
        End If
        GoTo 28 '已经没有不良


27:
        If Total_PiChi >= 1 Then
            GoTo 1002 '返回继续补插
        End If
        MessageBox.Show("插件批次设置小于1，请重新设置!", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        GoTo 0

28:
        LoopNum = LoopNum + 1

        If Bucha_ok_done = True Then '已经放过板
            Bucha_ok_done = False
        ElseIf Bucha_ok_done = False Then
            Robot_hadNot_D = False  '当前定位的板已经完成
        End If


        If Robot_ATryInsert = True Then '试插模式
            GoTo 200
        End If
        If Re_Cycle = False Then   '不是周期模式，二代机界面来源frmConfig1-->演示按钮
            GoTo 9
        End If
        GoTo 29


29:
        GoTo 30
30:
        If QuJian_String_list.Count > 0 Then  '当前取 件的内容

            GoTo 31
        End If
        Now_PiChi += 1  '当前插件批次
        If Now_PiChi > Total_PiChi Then   '当前插件批次大于插件总批次执行下一步
            Now_PiChi = 1
            GoTo 9
        End If

31:
        strSend = "Q C 2"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "Q")
        DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13)
        If _ret = "P" And di_ret = 0 Then
            GoTo 32
        End If
        GoTo 31

32:
        DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13) 机械手到位信号
        If di_ret = 1 Then
            GoTo 33
        End If
        GoTo 32

33:
        strSend = "Q D 2" '启动机械手去放回收元件
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "Q")
        DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13)
        If _ret = "P" And di_ret = 0 Then
            GoTo 34
        End If
        GoTo 33

34:
        DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13) 机械手到位信号
        If di_ret = 1 Then
            GoTo 35
        End If
        GoTo 34

35:
        Now_PiChi += 1 '当前批次完成返回继续下一批次   'Pichi_Num_List 每个批次的个数 
        If Now_PiChi > Pichi_Num_List.Count Then
            GoTo 9
        End If
        GoTo 30

100:
        '当前批次拍照重新排列后的内容
        If Grab_String_list.Count > 0 Then

            GoTo 101
        End If
        GoTo 0

101:
        Dim _aa As Boolean = False
        If _aa = True Then '当前批次中，有使用视觉的
            GrabListString.Clear()
            OnceGrabnum = 0
            GoTo 102
        End If
        '都没有使用视觉
        GoTo 1002


102:
        strSend = "A 2" '
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "A")
        DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14)
        If _ret = "P" And di_ret = 0 Then
            GoTo 103
        End If
        GoTo 102

103:

        DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14) 
        If di_ret = 1 Then
            _ret = DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
            GoTo 104
        End If
104:
        If Robot_ATryInsert = False Then  '不是试插模式
            _ret = DO_WriteLine(Card7230, 0, 0, 1) 'OutputNum(18)
        End If
        'VisionResult = mvision.ExcuteTest("夹爪" & Now_Grab_No, 1, hwindow, Xpos, Ypos, Anglem)
        'visionArchivesName = "夹爪" & Now_Grab_No '   
        GoTo 105
        OnceGrabnum = OnceGrabnum + 1 '拍照次数
105:
        If OnceGrabnum >= GrabListString.Count Then   '拍照次数大于拍照列表，表示拍照完成
            DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13)
            If di_ret = 1 Then
                OnceGrabnum = 0
                _ret = DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
                GoTo 1002
            End If
        End If
        DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14)
        If di_ret = 0 Then
            _ret = DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
            GoTo 102
        End If


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
            recievedata = _tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(recievedata, "E")
            If _ret = "P" Then
                GoTo 11
            End If
            GoTo 1001

11:         '启动机械手去取料位置
            '发送：Q A 2 0
            '返回：成功返回 "Q " 失败返回 ""
            '参数说明： QA:启动取料命令  2:物料号  0：矩阵托盘的功能，表示当前取托盘的第几个料            '取料只会一个料一个料的发，不会多个料同时发

            strSend = "Q A 2 0"
            recievedata = _tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(recievedata, "Q")
            If _ret <> "P" Then GoTo 11

            DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14)  机械手提高信号
            If di_ret <> 0 Then GoTo 11
            If robot_Ashoudongstart = True Then Exit Sub
            GoTo 1200

1200:       '等待机械手夹紧
            DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14) 机械手提高信号 
            If di_ret = 1 Then

                'GoTo 1203
1203:           '机械手取料时，输出给机械手可以离开信号
            Else
                'GoTo 1201
1201:           '输出给供料器 打开夹爪信号
            End If
            '_ret = DO_WriteLine(Card7230, 0, 0, 1)   'OutputNum(18) 供料器打开完成信号
12:         '等待机械手去取料位置

            'DI_ReadLine(0, 6, 0,  di_ret) 'InputNum(13) 机械手到位信号            DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13)
            If di_ret <> 1 Then GoTo 12
            '_ret = DO_WriteLine(Card7230, 0, 0, 0)   'OutputNum(18)  '供料器没打开 
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
            strSend = "A 2" '
            recievedata = _tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(recievedata, "A")
            'do_Show(strSend, recievedata)

            ' DI_ReadLine(0, 6, 1, di_ret) 'InputNum(14) 机械手提高信号            DI_ReadLine(Card7230, 0, 1, di_ret)
            If _ret <> "P" Then GoTo 1400
            If di_ret <> 0 Then GoTo 1400
            If robot_Ashoudongstart = True Then Exit Sub
            GoTo 15

15:
            'DI_ReadLine(0, 6, 1, di_ret) 'InputNum(14) 机械手提高信号            DI_ReadLine(Card7230, 0, 1, di_ret)
            If di_ret <> 1 Then GoTo 15
            '_ret = DO_WriteLine(Card7230, 0, 0, 0)   'OutputNum(18)  '供料器没打开
            If robot_Ashoudongstart = True Then Exit Sub
            GoTo 16
16:
            '_ret = DO_WriteLine(Card7230, 0, 0, 1) '供料器打开完成信号
            GoTo 17
17:
            'DI_ReadLine(0, 6, 0, di_ret)
            DI_ReadLine(Card7230, 0, 0, di_ret) 'InputNum(13) 机械手到位信号
            If di_ret <> 1 Then GoTo 17
            '_ret = DO_WriteLine(Card7230, 0, 0, 0) '  '供料器没打开
            GoTo 20
20:
            '发送：G 2
            '返回：成功返回 "G "    失败返回 ""
            '参数说明：'G：放NG品   2：供料器2 (可以连发：如多个料时发 G 1 2 3 4  )
            strSend = "G 2"
            recievedata = _tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(recievedata, "G")
            'do_Show(strSend, recievedata)

            If _ret <> "P" Then GoTo 20

            GoTo 21

21:

            'DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13) 机械手到位信号            DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13)
            If di_ret <> 1 Then GoTo 21
            GoTo 2

2:          '  拍Mark点            '发送：M 1 2
            '返回：成功返回 "M " 失败返回 ""
            '参数说明： M：放NG品   2：供料器2 (可以连发：如多个料时发 M 1 2 3 4  )
            strSend = "M 1 2" '
            recievedata = _tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(recievedata, "M")
            'do_Show(strSend, recievedata)

            If _ret <> "P" Then GoTo 2
            '_ret = DO_WriteLine(Card7230, 0, 0, 0) '  '供料器没打开 
            GoTo 3

3:

            DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14) 机械手提高信号
            If di_ret <> 1 Then GoTo 3
            GoTo 4



4:
            '等待板进料到位
            If RobotAActionStart = False Then GoTo 4
            RobotAActionStart = False
            GoTo 5


5:

            '_ret = DO_WriteLine(Card7230, 0, 0, 1) '供料器打开完成信号
            'VisionResult = mvision.ExcuteTest(mark_1_visionArchivesName, 2, hwindow, 320, 240, 0) '
            Dim str As String = "11|50.002|100.56|100"
            _ret = F_Client_BLL.doCommand_01(1, str)
            System.Threading.Thread.Sleep(20)
            ' 延时后读数据
            m_da.Receive()
            Thread.Sleep(30)
            VisionResult = strVision

            GoTo 7
7:          '等待机械手到Mark点2位置完成


            DI_ReadLine(Card7230, 0, 0, di_ret) 'InputNum(13) 机械手到位信号
            If di_ret <> 1 Then GoTo 7
            '_ret = DO_WriteLine(Card7230, 0, 0, 0)  '  '供料器没打开
            GoTo 8000
8000:

            '发送Mark点像素值(X	x1	y1	x2	y2)

            '发送：X 320 240 320 240
            '返回：成功返回 "X " 失败返回 ""
            '参数说明： X：发送Mark点像素值  320:X1  240:Y1   320:X2  240:Y2 (可以连发:如 X 320 240 320 240 320 240 )
            ' 320 240  是中心点，先固定写这个值 

            strSend = "X 320 240 320 240"
            recievedata = _tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(recievedata, "X")
            'do_Show(strSend, recievedata)
            If _ret <> "P" Then GoTo 8000
            GoTo 23111

23111:
            '发送偏移量(Y	元件号	X偏移	Y偏移	角度)


            '发送：Y 2 0 0 0
            '返回：成功返回 "Y " 失败返回 ""
            '参数说明：Y：发送偏移量指令  2:物料号  0:X偏移   0:Y偏移  0:角度 (可以连发:如 Y 2 0 0 0 1 0 0 0 3 0 0 0 )

            strSend = "Y 2 0 0 0 "
            recievedata = _tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(recievedata, "Y")
            'do_Show(strSend, recievedata)
            If _ret <> "P" Then GoTo 23111
            GoTo 23

23:
            '插件( P 点位号)
            '发送：P 2
            '返回：成功返回 "P " 失败返回 ""
            '参数说明：P：插件指令  2:点位号 (可以连发:如 P 2 3 1 )

            strSend = "P 2"
            recievedata = _tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(recievedata, "P")
            'do_Show(strSend, recievedata)
            If _ret <> "P" Then GoTo 23
            GoTo 24
24:

            'DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13) 机械手到位信号            DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13)
            If di_ret <> 1 Then GoTo 24
            GoTo 2500
2500:
            '查询是否有插件不良(S)
            '返回：S 0 0 0 0 0 6 0 0 0 0 0 0 0 0 0 0：表示20个数据的状态，如果是不良的，则返回数值            strSend = "S"
            recievedata = _tcp8.SendF8(strSend)
            _ret = dao_Epson.GetStatus(recievedata, "S")
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
    Sub robot_3_actionsubEx()
        Dim msg As DialogResult
        Dim fet_SimpFed_Fed_Nownum(10) As Integer

0:
        '(m_maindata.gIODll.InputNumStatus(m_maindata.gIODll.InputNum(7))
        'If safepingbi Then
        '    GoTo 1000
        'End If
        DI_ReadLine(Card7432, 0, 5, di_ret) '安全门信号
        If di_ret = "1" Or safepingbi = True Then  '安全门是否有屏蔽
            GoTo 1000
        End If
        '-------------------------------------------------
1000:
        If RobotAStartrun = True Then   '8000 TCP 连接通信成功  心跳 看门狗
            GoTo 200
        End If
        GoTo 1

1:      '开启 8000 端口
        strSend = "$Stop,0"  ' 停止Robot模块0
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Stop,0")
        do_Show(strSend, _ret)
        Thread.Sleep(300)

        strSend = "$Start,0" ' 启动Robot模块0
        recievedata = _tcp5.SendR5(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "#Start,0")
        do_Show(strSend, _ret)
        If _ret = "P" Then
            _tcp8.doConnectionF8(txtIpR8.Text, txtPort8.Text) '800
            RobotAStartrun = True
        End If
        GoTo 200
        '-------------------------------------------------


200:
        '设置机械手运行功率
        '发送：E 2 0  
        '返回：成功返回 "E " 失败返回 ""
        '参数说明：E ：置运行功率  第二个参数：1：低功率；2：高功率；第三个参数：0：正常插件，1：空打   
        strSend = "E 2 0"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "E")
        If _ret = "P" Then
            GoTo 9
        End If
        GoTo 200

9:
        fet_SimpFed_Fed_Nownum(0) = 1
        fet_SimpFed_Fed_Nownum(1) = 1
        'fet_SimpFed_Fed_Nownum(2) = 1

        QuJian_String_list.Clear()
        Robot_UP_Had_String.Clear()
        GrabListString.Clear()
        'QuJian_String_list.Add("7")
        QuJian_String_list.Add("1")
        QuJian_String_list.Add("2")

        GrabListString.Add("1")
        GrabListString.Add("2")

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
        '启动机械手去取料位置
        '发送：Q A 2 0
        '返回：成功返回 "Q " 失败返回 ""
        '参数说明： QA:启动取料命令  2:物料号  0：矩阵托盘的功能，表示当前取托盘的第几个料        '取料只会一个料一个料的发，不会多个料同时发
        strSend = "Q A " & QuJian_String_list(Now_grab_Num) & " " & fet_SimpFed_Fed_Nownum(Now_grab_Num)  '...
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "Q")
        If _ret <> "P" Then GoTo 11

        'do_Show(strSend, recievedata)           '0 ：第几张卡 1：机 械手提高信号
        DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14)  
        If di_ret <> 0 Then GoTo 11

        If robot_Ashoudongstart = True Then Exit Sub
        GoTo 1200

1200:
        DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14) 机械手到达取料位置        If di_ret <> 1 Then GoTo 1200

        GoTo 1203
1203:   '机械手取料时，输出给机械手可以离开信号
        _ret = DO_WriteLine(Card7230, 0, 0, 1) 'OutputNum(18) 机械手继续移动
        GoTo 12

12:
        DI_ReadLine(Card7230, 0, 0, di_ret)  'InputNum(13) 机械手到位信号
        If di_ret <> 1 Then GoTo 12

        _ret = DO_WriteLine(Card7230, 0, 0, 0)   'OutputNum(18) 
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
        If Grab_String_list.Count > 0 Then
            GoTo 14
        End If
        GoTo 0
        Exit Sub

14:
        Dim bolVision As Boolean = False
        If bolVision = True Then GoTo 1400 '当前批次中，有使用视觉的

        GoTo 18


1400:
        '拍照
        '发送：A 2
        '返回：成功返回 "A "  失败返回 ""
        '参数说明：A：拍照命令  2：拍第2个夹爪的料(可以连发：如多个料时发 A 2 3 4 1 )
        strSend = "A 1 2"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "A")
        If _ret <> "P" Then GoTo 1400
        'do_Show(strSend, recievedata)

        DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14) 机械手提高信号        If di_ret <> 0 Then GoTo 1400

        If robot_Ashoudongstart = True Then Exit Sub
        GoTo 15

15:
        DI_ReadLine(Card7230, 0, 1, di_ret)  '机械手到达拍照位置
        If di_ret <> 1 Then GoTo 15

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

            msg = MessageBox.Show("请确认当前插件的视觉是否正确！", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            If msg = DialogResult.Yes Then
                _ret = DO_WriteLine(Card7230, 0, 0, 1) 'OutputNum(18) 机械手继续移动
                OnceGrabnum += 1 '拍照次数
                GoTo 17
            End If

        End If
        OnceGrabnum += 1 '拍照次数
        GoTo 17
17:
        If OnceGrabnum >= GrabListString.Count Then  '拍照次数大于拍照列表，表示拍照完成
            DI_ReadLine(Card7230, 0, 0, di_ret) 'InputNum(13) 机械手到位信号            If di_ret <> 1 Then GoTo 17

            _ret = DO_WriteLine(Card7230, 0, 0, 0) ' 
            GoTo 18
        End If

        DI_ReadLine(Card7230, 0, 1, di_ret)  'InputNum(14)
        If di_ret <> 0 Then GoTo 17

        _ret = DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
        GoTo 15 '返回继续拍照

18:     '判断有无不良品" 
        For i As Integer = 0 To Grab_String_list.Count - 1
            'If Insert_PointOK(Robot_Data.Grab_String_list(i)) = False Then
            Insert_Point_NG_Total = True
            Exit For
            'End If
        Next

        NG_Product_str.Clear() '清除不良品计数
        GoTo 19
19:
        If Insert_Point_NG_Total = True Then '拍照全部OK，没有不良品，执行下一步
            Insert_Point_NG_Total = False
            'GoTo 20
        End If
        GoTo 2000



2000:
        'If Robot_UP_Had_String.Count > 0 Then  '当前夹子上有产品
        If Mark_Had_Grab = False Then
            Mark_Had_Grab = True
            GoTo 2 '第一次进入，需要拍Mark点
        End If
        GoTo 22 '去放良品

        'End If
        GoTo 2500

2:
        strSend = "M 1 2 0 0" '
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "M")
        'do_Show(strSend, recievedata)
        If _ret <> "P" Then GoTo 2

        DI_ReadLine(Card7230, 0, 0, di_ret) 'InputNum(13) 
        If di_ret <> 0 Then GoTo 2

        _ret = DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
        GoTo 3

3:
        DI_ReadLine(Card7230, 0, 1, di_ret) '机械手到达Mark1位置
        If di_ret <> 1 Then GoTo 3

        GoTo 4
4:
        '等待板进料到位
        'If RobotAActionStart = False Then GoTo 4
        _ret = DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
        RobotAActionStart = False
        GoTo 5

5:
        '_ret = DO_WriteLine(Card7230, 0, 0, 1) '供料器打开完成信号
        'VisionResult = mvision.ExcuteTest(mark_1_visionArchivesName, 2, hwindow, 320, 240, 0) '
        _ret = DO_WriteLine(Card7230, 0, 0, 1) 'OutputNum(18) 
        GoTo 7


7:
        DI_ReadLine(Card7230, 0, 0, di_ret) 'InputNum(13)  机械手到位信号
        If di_ret <> 1 Then GoTo 7

        _ret = DO_WriteLine(Card7230, 0, 0, 0) 'OutputNum(18)
        GoTo 8
8:
        '_ret = DO_WriteLine(Card7432, 0, 11, 1) '机械手继续移动mark2位置
        'VisionResult = mvision.ExcuteTest(m_maindata.gallpoints.mark_2_visionArchivesName, 2, hwindow, Xpos, Ypos, Anglem) '
        'visionArchivesName = m_maindata.gallpoints.mark_2_visionArchivesName
        '_ret = DO_WriteLine(Card7432, 0, 11, 0)
        GoTo 8000
8000:
        strSend = "X 320 240 320 240"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "X")
        'do_Show(strSend, recievedata)
        If _ret <> "P" Then GoTo 8000
        GoTo 22

22:
        GoTo 22000
22000:
        If Robot_ATryInsert = True Then
            GoTo 23111
        End If
23111:
        strSend = "Y 1 0 0 0 0 0 0 0 2 0 0 0 0 0 0 0"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "Y")
        'do_Show(strSend, recievedata)
        If _ret <> "P" Then GoTo 23111
        GoTo 23
23:

        strSend = "P 1 2"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "P")
        'do_Show(strSend, recievedata)
        If _ret <> "P" Then GoTo 23
        GoTo 24

24:
        'DI_ReadLine(0, 6, 0, di_ret) 'InputNum(13) 机械手到位信号        DI_ReadLine(Card7230, 0, 0, di_ret)
        If di_ret = 1 Then
            GoTo 2500
        End If

        DI_ReadLine(Card7230, 0, 1, di_ret) 'InputNum(14) 插件NG信号
        If di_ret = 1 Then
            'GoTo 2400
        End If
        GoTo 24


2500:
        '查询是否有插件不良(S)
        '返回：S 0 0 0 0 0 6 0 0 0 0 0 0 0 0 0 0：表示20个数据的状态，如果是不良的，则返回数值        strSend = "S"
        recievedata = _tcp8.SendF8(strSend)
        _ret = dao_Epson.GetStatus(recievedata, "S")
        'do_Show(strSend, recievedata)

        If _ret <> "P" Then GoTo 2500
        GoTo 2501
2501:
        If InsertNGstring.Count > 0 Then '插件不良的计数列表
            'GoTo 2502
        End If
        GoTo 25

25:
        Now_PiChi += 1
        If Now_PiChi > Pichi_Num_List.Count Then  '当前批次完成返回继续下一批次   'Pichi_Num_List 每个批次的个数 
            Now_PiChi = 1
            'GoTo 26
        End If
        Now_grab_Num = 0
        OnceGrabnum = 0
        GoTo 9

    End Sub

End Class