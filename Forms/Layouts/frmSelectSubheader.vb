Public Class frmSelectSubheader
    Public isSelected As Boolean = False
    Public Subheader As String = ""

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If Trim(txtSubheader.Text) = "" Then
            MsgBox("Please type Drawing Subheader", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Subheader = txtSubheader.Text
        isSelected = True
        Me.Close()
    End Sub
End Class