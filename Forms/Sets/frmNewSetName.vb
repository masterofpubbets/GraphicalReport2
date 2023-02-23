Public Class frmNewSetName
    Public isAdded As Boolean = False
    Public newName As String = ""
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim sets As New DrawingSets
        txtName.Text = Trim(txtName.Text)

        If txtName.Text = "" Then
            MsgBox("Please Type Set Name!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If sets.CheckExists(txtName.Text) Then
            MsgBox("Set Name Already Exists!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        isAdded = True
        newName = txtName.Text
        Me.Close()
    End Sub
End Class