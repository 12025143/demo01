Public Enum ePosStatus '工位的状态    Request = 0
    Ready = 0
    Action
    Busy
    Counting
    Ok
End Enum
Public Enum ePostion
    Free = -1
    Pos1
    Pos2
    Pos3
End Enum
Public Enum eIO_Idx
    Free = -1
    posi_01_06 = 6
    posi_01_10 = 10
    posi_02_07 = 7
    posi_02_08 = 8
    posi_03_09 = 9
    posi_03_11 = 11
End Enum
Public Enum eDirect
    Free = -1
    N = 0
    P = 1
    Mes = 2
End Enum
Public Enum eSwitch
    Free = -1
    Close = 0
    Off = 0
    Open = 1
    Run = 1
End Enum