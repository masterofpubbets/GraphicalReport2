Public Class frmSelectDrawingHeader
    Public isSelected As Boolean = False
    Public header As String = ""

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub rCustom_CheckedChanged(sender As Object, e As EventArgs) Handles rCustom.CheckedChanged
        txtHeader.Visible = rCustom.Checked
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If rCustom.Checked Then
            If Trim(txtHeader.Text) = "" Then
                MsgBox("Please type Drawing Header", MsgBoxStyle.Exclamation, Me.Text)
                txtHeader.Focus()
                Exit Sub
            End If
            header = txtHeader.Text
            isSelected = True
            Me.Close()
        End If

        If rDrawingName.Checked Then
            header = "$(NAME)"
            isSelected = True
            Me.Close()
        End If

        If rgpNameCustom.Checked Then
            If Trim(txtCustomHeader.Text) = "" Then
                MsgBox("Please type Drawing Header", MsgBoxStyle.Exclamation, Me.Text)
                txtCustomHeader.Focus()
                Exit Sub
            End If
            If rStart.Checked Then
                header = txtCustomHeader.Text & "$(NAME)"
            Else
                header = "$(NAME)" & txtCustomHeader.Text
            End If
            isSelected = True
            Me.Close()
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rgpNameCustom.CheckedChanged
        gpNameCustom.Visible = rgpNameCustom.Checked
    End Sub

End Class