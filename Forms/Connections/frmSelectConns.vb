Public Class frmSelectConns
    Public isSelect As Boolean = False
    Public connId As Integer = 0
    Private conns As New Connections

    Private Sub GetData()
        grd.DataSource = conns.GetConnections
        gv.BestFitColumns(True)
    End Sub
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim frm As New frmCreateConnection
        frm.ShowDialog(Me)
        If frm.isAdded Then
            GetData()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmSelectConns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If gv.GetSelectedRows.Length = 0 Then Exit Sub
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        connId = gv.GetDataRow(row_handle).Item("ID")
        isSelect = True
        Me.Close()
    End Sub
End Class