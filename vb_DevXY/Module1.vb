Imports FACC.Memo
Imports FACC.iceService

Module Module1
    Public RobotAActionStart As Boolean = False '板进料到位,可以插件
    Public RobotAActionDone As Boolean = False  '机械手插件完成    Public Card7432, Card7230 As Integer
    Public m_da As clsMemoRcv = Nothing
    Public RobotAStartrun As Boolean = False
    Public Robot_ATryInsert As Boolean = False '试插模式
    Public robot_Ashoudongstart As Boolean = False
    Public Now_grab_Num As Integer '当前批次的取料个数
    Public QuJian_String_list As New List(Of Integer)
    Public safepingbi As Boolean = False
End Module
