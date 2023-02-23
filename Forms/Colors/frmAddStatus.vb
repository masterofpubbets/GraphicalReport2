Public Class frmAddStatus
    Public isAdded As Boolean = False
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If Trim(txtName.Text) = "" Then
            MsgBox("There is No Status Name", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If DBAc.ExcutResult(String.Format("select status_name from t_color_code where status_name='{0}'", txtName.Text)) <> "" Then
            MsgBox("Status Name Already Exists", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim c As Color = cs.EditValue
        Dim k As Color = ck.EditValue
        DBAc.ExcuteNoneResult(String.Format("insert into t_color_code (status_name,r,g,b,t,sr,sg,sb,sw,stroke_style,st) values ('{0}',{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})", txtName.Text, c.R, c.G, c.B, Val(lblTTValue.Text), k.R, k.G, k.B, Val(lblSW.Text), cmbSStyle.SelectedIndex + 1, Val(lblSTValue.Text)))
        isAdded = True
        If MsgBox("New Status Color Has Been Saved." & vbCrLf & "Do You Want To Add A New One?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
            Me.Close()
        Else
            txtName.Text = ""
            cs.EditValue = Color.Black
            ck.EditValue = Color.Black
            tt.Value = 100
            lblTTValue.Text = 1
            txtName.Focus()
        End If
    End Sub
    Private Sub cs_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cs.EditValueChanged
        ck.EditValue = cs.EditValue
        lblColor.BackColor = cs.EditValue
        lblCK.BackColor = cs.EditValue
    End Sub

    Private Sub tt_Scroll(sender As System.Object, e As System.EventArgs) Handles tt.Scroll
        lblTTValue.Text = tt.Value / 100
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

    Private Sub frmAddColorStatus_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cmbSStyle.SelectedIndex = 0
    End Sub

    Private Sub frmAddStatus_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class