Imports System.Threading

Partial Public Class cls_frmBelt

    Private Sub P3Action()
        'Dim AStep As Integer = 0

        position3_Had = frm.ck_position3_Had.Checked
        Do
            Do While P3Actionstart = True
0:
                If position3_Had = False Then
                    GoTo 401
                ElseIf HadChangProduct = True Then '等待轨道调整完成  '''
                    GoTo 0
                End If
                di_ret = ReadStatus(frm.txt_DI_9.Text)   'DI_ReadLine(0, 0, frm.txt_DI_9.Text, di_ret)
                If di_ret = 0 Then '工位3出口没有板
                    btnPos3Turn()  '工位3转动
                    P2ActionNextNeed = True
                    GoTo 1
                Else
                    GoTo 401
                End If
1:
                Thread.Sleep(30)
                di_ret = ReadStatus(frm.txt_DI_9.Text)
                If di_ret Then   '1 工位3出口有板
                    GoTo 4
                Else
                    P2ActionNextNeed = True
                    GoTo 2

                End If
2:
                If P2ActionNextNeed = False Then ''''
                    btnPos3Turn()
                    GoTo 3
                Else
                    Application.DoEvents()
                    btnPos3Stop()
                    GoTo 2
                End If
3:

                di_ret = WaitStatus(frm.txt_DI_9.Text)
                'If di_ret Then
                P2ActionNextNeed = False
                GoTo 4
                'End If
4:
                di_ret = ReadStatus(frm.txt_DI_11.Text)
                If di_ret Or P3ActionNextNeed = True Then
                    P3ActionNextNeed = False
                    GoTo 5
                Else
                    Application.DoEvents()
                    btnPos3Stop()

                    'di_ret = ReadStatus(frm.txt_DI_9.Text)  '???? 
                    'If di_ret = 0 Then  '等待过程中，板被人取走                    '    GoTo 1
                    'Else
                    GoTo 4
                    'End If
                End If
401:
                di_ret = ReadStatus(frm.txt_DI_11.Text)
                If di_ret Or P3ActionNextNeed = True Then
                    P3ActionNextNeed = False
                    P2ActionNextNeed = True
                    GoTo 402
                Else
                    btnPos3Stop()
                    ' DI_ReadLine(0, 0, frm.txt_DI_9.Text, di_ret)
                    di_ret = WaitStatus(frm.txt_DI_9.Text, 0)
                    If di_ret = 0 Then  '等待过程中，板被人取走 
                        GoTo 1
                    End If
                    GoTo 401
                End If
402:

                    btnPos3Turn()
                    GoTo 403
403:
                    di_ret = WaitStatus(frm.txt_DI_9.Text)
                    'If di_ret Then
                    P2ActionNextNeed = False
                    GoTo 404
                    'End If
404:
                    btnPos3Turn()
                    di_ret = WaitStatus(frm.txt_DI_9.Text, 0) '工位3出口没有板
                    'If di_ret = 0 Then
                    btnPos3Stop()
                    GoTo 0
                    'End If
5:
                    btnPos3Turn()
                    Thread.Sleep(5)
                    di_ret = WaitStatus(frm.txt_DI_9.Text, 0)  '工位3出口没有板
                    'If di_ret = 0 Then
                    btnPos3Stop()
                    '停止生产
                    di_ret = ReadStatus(frm.txt_DI_8.Text)

                    If end2 = True And di_ret = 0 Then
                        end2 = False
                        P3Actionstart = False
                        GoTo 0
                    Else
                        GoTo 1
                    End If
                    'End If
                    Application.DoEvents()
            Loop

            Application.DoEvents()
        Loop
    End Sub
End Class
