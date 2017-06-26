Imports BeetleEx


Public Class frmTcpSendA_11

    Dim _bo_tcp5 As New clsBLL_TCP2
    Dim _bo_tcp8 As New clsBLL_TCP2
    Dim _ErrorCode As Integer

    Private Sub btnConnect5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect5.Click
        _bo_tcp5.do_Connect(Me.txtIpR5.Text, Me.txtPort5.Text)
    End Sub

    Private Sub btnDisConnect5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisConnect5.Click
        _bo_tcp5.do_Disconnect()
    End Sub

    Private Sub btnSend5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend5.Click
        TextBox5i.Text = _bo_tcp5.do_SendData(TextBox5.Text, "#", Val(txtTimeOut5.Text), _ErrorCode)
        lbError5.Text = _ErrorCode.ToString

    End Sub
    Private Sub btnConnect8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect8.Click
        _bo_tcp8.do_Connect(Me.txtIpR8.Text, Me.txtPort8.Text)
    End Sub

    Private Sub btnDisConnect8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisConnect8.Click
        _bo_tcp8.do_Disconnect()
    End Sub

    Private Sub btnSend8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend8.Click
        TextBox8i.Text = _bo_tcp8.do_SendData(TextBox8.Text, "Q", Val(txtTimeOut8.Text), _ErrorCode)
        lbError8.Text = _ErrorCode.ToString
    End Sub

End Class