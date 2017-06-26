
Partial Public Class cls_frmBelt

    Private Sub P1Action()


        Do
            Do While P1Actionstart
0:
                btnPos1Turn()
                di_ret = ReadStatus(frm.txt_DI_7.Text)
                _ret = ReadStatus(frm.txt_DI_6.Text)
                If di_ret Then '出口有料时，直接等待出料
                    GoTo 4
                ElseIf _ret = 1 Then '入口有料时，皮带转动进料
                    GoTo 3
                Else '两端没料时，发送要料信
                    btnpos1Stop()
                    GoTo 1
                End If

1:              '工位1发送要料信号()
                btnP1Need()
                di_ret = WaitStatus(frm.txt_DI_6.Text) '入口有料时，皮带转动进料 InputNum(4)
                'If di_ret Then  
                GoTo 2
                'End If

2:
                _ret = DO_WriteLine(0, 0, frm.txt_DO_10.Text, 0) ' 2 关闭要料信号
                GoTo 3
3:
                btnPos1Turn() '工位1电机转动进料
                di_ret = WaitStatus(frm.txt_DI_7.Text)
                'If di_ret Then '4 出口有料时，直接等待出料 
                GoTo 4
                'End If
4:
                di_ret = ReadStatus(frm.txt_DI_7.Text)
                If di_ret And P1ActionNextNeed = True Then '4 出口有料时，直接等待出料 
                    GoTo 5
                ElseIf di_ret Then
                    btnpos1Stop()
                    Application.DoEvents()
                    GoTo 4
                Else
                    GoTo 0 '等待状态被拿走
                End If
5:              '工位1电机转动出料
                btnPos1Turn()
                di_ret = WaitStatus(frm.txt_DI_7.Text, 0)
                GoTo 6
6:
                If end0 = True Then
                    end0 = False
                    btnpos1Stop()
                    end1 = True
                    P1Actionstart = False
                    GoTo 0
                ElseIf end0 = False Then
                    btnpos1Stop()
                    P1ActionNextNeed = False
                    GoTo 1
                End If

                Application.DoEvents()
            Loop
            Application.DoEvents()
        Loop

    End Sub
End Class
