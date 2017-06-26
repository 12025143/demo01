Imports System.Threading

Partial Public Class cls_frmBelt

    Private Sub P2Action()

        Dim homeCount As Integer = 0
        Do

            Do While P2Actionstart
0:
                If HadChangProduct = False Then '0 工位2等待轨道调整完成
                    GoTo 1
                Else
                    Application.DoEvents()
                    GoTo 0
                End If
1:
                di_ret = ReadStatus(frm.txt_DI_8.Text) '
                If di_ret Then
                    GoTo 202
                ElseIf AutoPassTrue = True Then '直通模式                    ActionhadNotmove = False
                    GoTo 201

                ElseIf AutoPassTrue = False Then
                    ActionhadNotmove = False
                    GoTo 200

                Else
                    ActionhadNotmove = False
                    Application.DoEvents()
                    GoTo 1
                End If
202:
                If ActionhadNotmove Or AutoPassTrue Then
                    GoTo 8
                Else
                    GoTo 2
                End If
200:
                btnStopPoint() '工位2定位电机移动到挡料位置
                GetStatus(5)
                GoTo 301
301:
                btnPos2TurnP() '工位2正转
                di_ret = ReadStatus(frm.txt_DI_8.Text)
                If di_ret And AutoPassTrue Then
                    btnPos2StopP()
                    GoTo 8
                ElseIf di_ret And AutoPassTrue = False Then
                    btnPos2StopP()
                    GoTo 5
                Else
                    GoTo 201
                End If
201:
                P1ActionNextNeed = True '工位2向上工位要料
                GoTo 4
2:
                btnPos2TurnN() '检测到定位处有板，电机反转
                Thread.Sleep(500)
                btnPos2StopN() '反转停止
3:
                btnStopPoint() '工位2定位电机移动到挡料位置
                GetStatus(5)
                GoTo 4
4:
                btnPos2TurnP()
                di_ret = WaitStatus(frm.txt_DI_8.Text)
                btnPos2StopP()
                If AutoPassTrue Then
                    GoTo 8
                ElseIf AutoPassTrue = False Then
                    GoTo 5
                End If

5:
                btnHighest() '工位2定位电机移动到定位位置
                GetStatus(5)
                GoTo 6
6:              '工位2定位完成，允许机械手插件
                P1ActionNextNeed = False
                RobotAActionDone = False
                RobotAActionStart = True

                GoTo 7
7:              '等待机械手插件完成
                If RobotAActionDone = True Then
                    RobotAActionDone = False
                    ActionhadNotmove = True

                    GoTo 8
                Else
                    Application.DoEvents()
                    GoTo 7
                    'P2Actionstart = False 'STOP THREAD

                End If
8:
                If P2ActionNextNeed And AutoPassTrue Then
                    P2ActionNextNeed = False
                    GoTo 12
                ElseIf P2ActionNextNeed And AutoPassTrue = False Then
                    GoTo 11
                ElseIf P2ActionNextNeed = False And AutoPassTrue = False Then
                    GoTo 9
                Else
                    Application.DoEvents()
                    GoTo 8
                End If
9:
                btnStopPoint() '工位2定位电机移动到挡料位置
                GetStatus(5)
                GoTo 10
10:
                If P2ActionNextNeed Then
                    GoTo 11
                Else
                    GoTo 10
                End If
11:
                btnLowest() '工位2定位电机移动到放料位置 
                GetStatus(5)
                P2ActionNextNeed = False
                GoTo 12
12:             '工位2正转出板
                btnPos2TurnP()
                di_ret = WaitStatus(frm.txt_DI_8.Text, 0)
                ActionhadNotmove = False
                If AutoPassTrue = True Then
                    GoTo 15
                Else
                    GoTo 13
                End If

13:
                homeCount += 1
                If homeCount > frm.txtCount.Text Then  '回原点次数大与界面设置的回原点次数 
                    GoTo 14
                Else
                    GoTo 1300
                End If

1300:
                P1ActionNextNeed = True
                di_ret = ReadStatus(frm.txt_DI_8.Text)
                If di_ret = 1 Then
                    btnPos2StopP()
                End If
                GoTo 4
14:
                btnMotorHOMING() '工位2定位电机复位
                GetStatus(5)
                btnStopPoint() '工位2定位电机移动到挡料位置
                GetStatus(5)

                GoTo 15
15:
                If end1 = True Then
                    end1 = False
                    end2 = True
                    P2Actionstart = False
                    GoTo 0
                ElseIf end1 = False And AutoPassTrue Then
                    GoTo 201
                ElseIf end1 = False And AutoPassTrue = False Then
                    GoTo 200
                End If

                Application.DoEvents()
            Loop

            Application.DoEvents()
        Loop
    End Sub
End Class
