Public Class frmStatus

    Private Sub GetData()
        DBAc.Fill(lstStatus, "select status_name from t_color_code order by status_name")
    End Sub

    Private Sub frmStatus_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
        cmbSStyle.SelectedIndex = 0
    End Sub
    Private Sub lstStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstStatus.SelectedIndexChanged
        If lstStatus.SelectedIndex = -1 Then Exit Sub
        Dim R As Integer = Val(DBAc.ExcutResult(String.Format("select r from t_color_code where status_name='{0}'", lstStatus.SelectedItem)))
        Dim G As Integer = Val(DBAc.ExcutResult(String.Format("select g from t_color_code where status_name='{0}'", lstStatus.SelectedItem)))
        Dim B As Integer = Val(DBAc.ExcutResult(String.Format("select b from t_color_code where status_name='{0}'", lstStatus.SelectedItem)))
        Dim SR As Integer = Val(DBAc.ExcutResult(String.Format("select Sr from t_color_code where status_name='{0}'", lstStatus.SelectedItem)))
        Dim SG As Integer = Val(DBAc.ExcutResult(String.Format("select Sg from t_color_code where status_name='{0}'", lstStatus.SelectedItem)))
        Dim SB As Integer = Val(DBAc.ExcutResult(String.Format("select Sb from t_color_code where status_name='{0}'", lstStatus.SelectedItem)))
        tt.Value = Val(Replace(DBAc.ExcutResult(String.Format("select t from t_color_code where status_name='{0}'", lstStatus.SelectedItem)), ",", ".")) * 100
        tbW.Value = Val(Replace(DBAc.ExcutResult(String.Format("select sw from t_color_code where status_name='{0}'", lstStatus.SelectedItem)), ",", ".")) * 100
        tbST.Value = Val(Replace(DBAc.ExcutResult(String.Format("select st from t_color_code where status_name='{0}'", lstStatus.SelectedItem)), ",", ".")) * 100
        cs.EditValue = Color.FromArgb(R, G, B)
        ck.EditValue = Color.FromArgb(SR, SG, SB)
        lblColor.BackColor = Color.FromArgb(R, G, B)
        lblCK.BackColor = Color.FromArgb(SR, SG, SB)
        lblTTValue.Text = tt.Value / 100
        lblSW.Text = tbW.Value / 100
        lblSTValue.Text = tbST.Value / 100
        cmbSStyle.SelectedIndex = Val(DBAc.ExcutResult(String.Format("select stroke_style from t_color_code where status_name='{0}'", lstStatus.SelectedItem))) - 1
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If lstStatus.SelectedIndex = -1 Then Exit Sub
        Dim c As Color = cs.EditValue
        Dim k As Color = ck.EditValue
        DBAc.ExcuteNoneResult(String.Format("update t_color_code set r ={0},g={1},b={2} where status_name='{3}'", c.R, c.G, c.B, lstStatus.SelectedItem))
        DBAc.ExcuteNoneResult(String.Format("update t_color_code set sr ={0},sg={1},sb={2} where status_name='{3}'", k.R, k.G, k.B, lstStatus.SelectedItem))
        DBAc.ExcuteNoneResult(String.Format("update t_color_code set t={0} where status_name='{1}'", tt.Value / 100, lstStatus.SelectedItem))
        DBAc.ExcuteNoneResult(String.Format("update t_color_code set sw={0} where status_name='{1}'", tbW.Value / 100, lstStatus.SelectedItem))
        DBAc.ExcuteNoneResult(String.Format("update t_color_code set st={0} where status_name='{1}'", tbST.Value / 100, lstStatus.SelectedItem))
        DBAc.ExcuteNoneResult(String.Format("update t_color_code set stroke_style={0} where status_name='{1}'", cmbSStyle.SelectedIndex + 1, lstStatus.SelectedItem))
        GetData()
    End Sub
    Private Sub tt_Scroll(sender As System.Object, e As System.EventArgs) Handles tt.Scroll
        lblTTValue.Text = tt.Value / 100
    End Sub

    Private Sub cs_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cs.EditValueChanged
        lblColor.BackColor = cs.EditValue
    End Sub

    Private Sub ck_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles ck.EditValueChanged
        lblCK.BackColor = ck.EditValue
    End Sub
    Private Sub tbW_Scroll(sender As System.Object, e As System.EventArgs) Handles tbW.Scroll
        lblSW.Text = tbW.Value / 100
    End Sub

    Private Sub cmbSStyle_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSStyle.SelectedIndexChanged
        picSS.Image = Image.FromFile(String.Format("{0}\Dasharrary\{1}.jpg", Application.StartupPath, cmbSStyle.SelectedItem))
    End Sub

    Private Sub tbST_Scroll(sender As System.Object, e As System.EventArgs) Handles tbST.Scroll
        lblSTValue.Text = tbST.Value / 100
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        If lstStatus.SelectedIndex = -1 Then Exit Sub
        If MsgBox("Do You Want To Delete Status: " & lstStatus.SelectedItem.ToString & "?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        DBAc.ExcuteNoneResult(String.Format("delete from t_color_code where status_name='{0}'", lstStatus.SelectedItem))
        GetData()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim frm As New frmAddStatus
        frm.ShowDialog(Me)
        If frm.isAdded Then
            GetData()
        End If
    End Sub
End Class