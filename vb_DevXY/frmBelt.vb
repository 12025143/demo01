Imports System.Threading
Imports System.IO.Ports

Public Class frmBelt
    Dim ui_bo As cls_frmBelt
    Dim _ret As Integer

    Sub New()
        InitializeComponent()
        ui_bo = New cls_frmBelt(Me)
    End Sub
    '开启测试
    Private Sub btnInitialize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitialize.Click
        ui_bo.Belt_Load()
    End Sub

    Private Sub frmBelt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ui_bo.Belt_Load()
    End Sub

    Function _MOVE(ByVal pos As ePostion, ByVal SW As eSwitch, Optional ByVal di As eDirect = eDirect.Free) As Integer
        Dim No As eIO_Idx
        Select Case pos
            Case ePostion.Pos1
                If (di = eDirect.Mes) Then
                    No = eIO_Idx.posi_01_10
                Else
                    No = eIO_Idx.posi_01_06
                End If

            Case ePostion.Pos2
                If (di = eDirect.N) Then
                    No = eIO_Idx.posi_02_08
                Else
                    No = eIO_Idx.posi_02_07
                End If
            Case ePostion.Pos3
                If (di = eDirect.Mes) Then
                    No = eIO_Idx.posi_03_11
                Else
                    No = eIO_Idx.posi_03_09
                End If
        End Select
        _ret = DO_WriteLine(0, 0, No, SW)
        Return _ret
    End Function




    Private Sub btnMotorON_Click(sender As System.Object, e As System.EventArgs) Handles btnMotorON.Click
        ui_bo.btnMotorON()
    End Sub

    Private Sub btnMotorOFF_Click(sender As System.Object, e As System.EventArgs) Handles btnMotorOFF.Click
        ui_bo.btnMotorOFF()
    End Sub

    Private Sub btnMotorHOMING_Click(sender As System.Object, e As System.EventArgs) Handles btnMotorHOMING.Click
        ui_bo.btnMotorHOMING()
    End Sub

    '最高点
    Private Sub btnHighest_Click(sender As System.Object, e As System.EventArgs) Handles btnHighest.Click
        ui_bo.btnHighest()
    End Sub

    Private Sub btnStopPoint_Click(sender As System.Object, e As System.EventArgs) Handles btnStopPoint.Click
        ui_bo.btnStopPoint()
    End Sub

    Private Sub btnLowest_Click(sender As System.Object, e As System.EventArgs) Handles btnLowest.Click
        ui_bo.btnLowest()
    End Sub

    Private Sub btnPos1Turn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPos1Turn.Click
        ui_bo.btnPos1Turn()
    End Sub

    Private Sub btnpos1Stop_Click(sender As System.Object, e As System.EventArgs) Handles btnpos1Stop.Click
        ui_bo.btnpos1Stop()
    End Sub

    Private Sub btnP1Need_Click(sender As System.Object, e As System.EventArgs) Handles btnP1Need.Click
        ui_bo.btnP1Need()
    End Sub

    Private Sub btnPos2TurnP_Click(sender As System.Object, e As System.EventArgs) Handles btnPos2TurnP.Click
        ui_bo.btnPos2TurnP()
    End Sub

    Private Sub btnPos2StopP_Click(sender As System.Object, e As System.EventArgs) Handles btnPos2StopP.Click
        ui_bo.btnPos2StopP()
    End Sub

    Private Sub btnPos2TurnN_Click(sender As System.Object, e As System.EventArgs) Handles btnPos2TurnN.Click
        ui_bo.btnPos2TurnN()
    End Sub

    Private Sub btnPos2StopN_Click(sender As System.Object, e As System.EventArgs) Handles btnPos2StopN.Click
        ui_bo.btnPos2StopN()
    End Sub

    Private Sub btnPos3Turn_Click(sender As System.Object, e As System.EventArgs) Handles btnPos3Turn.Click
        ui_bo.btnPos3Turn()
    End Sub

    Private Sub pos3Stop_Click(sender As System.Object, e As System.EventArgs) Handles pos3Stop.Click
        ui_bo.btnPos3Stop()
    End Sub

    Private Sub btnP3Have_Click(sender As System.Object, e As System.EventArgs) Handles btnP3Have.Click
        ui_bo.btnP3Have()
    End Sub



    ' 工位1 复位
    Private Sub btnP1_Homing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP1Homing.Click
        ui_bo.btnP1Homing()
    End Sub
    ' 工位2 复位
    Private Sub btnP2_Homing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP2Homing.Click
        ui_bo.btnP2Homing()
    End Sub
    ' 工位3 复位
    Private Sub btnP3_Homing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP3Homing.Click
        ui_bo.btnP3Homing()
    End Sub



    ' 工位1 动作
    Private Sub btnP1_Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP1Action.Click
        ui_bo.btnP1Action()
    End Sub
    ' 工位2 动作
    Private Sub btnP2_Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP2Action.Click
        ui_bo.btnP2Action()
       

    End Sub
    ' 工位3 动作
    Private Sub btnP3_Action_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP3Action.Click
        ui_bo.btnP3Action()
    End Sub


     
    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        ui_bo.Button7()
    End Sub
 
    Private Sub ck_AutoPassTrue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_AutoPassTrue.Click, ck_Change.Click, ck_P3NextNeed.Click, ck_RbtDone.Click
        Dim AutoPassTrue As Boolean = ck_AutoPassTrue.Checked
    End Sub
      
    Private Sub btnP3NextNeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub ck_position3_Had_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_position3_Had.Click
        Dim position3_Had As Boolean = ck_position3_Had.Checked
    End Sub

    '直通
    Private Sub ck_AutoPassTrue_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ck_AutoPassTrue.CheckedChanged
        ui_bo.Auto()
    End Sub
    '切换型号
    Private Sub ck_Change_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ck_Change.CheckedChanged
        ui_bo.btnChange()
    End Sub


    '下机要料
    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ck_P3NextNeed.CheckedChanged
        ui_bo.P3NextNeed()
    End Sub
    '插件完成
    Private Sub ck_RbtDone_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ck_RbtDone.CheckedChanged
        ui_bo.RbtDone()
    End Sub

  
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        ui_bo.btnClose()
    End Sub

    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        ui_bo.btnOpen()
    End Sub

    Private Sub btnMove_Click(sender As System.Object, e As System.EventArgs) Handles btnMove.Click
        ui_bo.btnMove()
    End Sub

    Private Sub btnTackHoming_Click(sender As System.Object, e As System.EventArgs) Handles btnTackHoming.Click
        ui_bo.btnTackHoming()
    End Sub

     
End Class



