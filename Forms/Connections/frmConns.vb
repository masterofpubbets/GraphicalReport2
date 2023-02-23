Public Class frmConns
    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim frm As New frmCreateConnection
        frm.ShowDialog(Me)
        If frm.isAdded Then

        End If
    End Sub
End Class