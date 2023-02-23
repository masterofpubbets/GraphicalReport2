Public Class frmSelectLayout
    Public isSelected As Boolean = False
    Public layoutName As String = ""

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        isSelected = True
        If rDefault.Checked Then
            layoutName = "Default"
            Me.Close()
        End If
        If rLayout2.Checked Then
            layoutName = "Layout2"
            Me.Close()
        End If
        If rLayout3.Checked Then
            layoutName = "Layout3"
            Me.Close()
        End If
        If rLayout3.Checked Then
            layoutName = "Layout3"
            Me.Close()
        End If
        If rLayout4.Checked Then
            layoutName = "Layout4"
            Me.Close()
        End If
        If rLayout5.Checked Then
            layoutName = "Layout5"
            Me.Close()
        End If
        If rLayout6.Checked Then
            layoutName = "Layout6"
            Me.Close()
        End If
        If rLayout7.Checked Then
            layoutName = "Layout7"
            Me.Close()
        End If
        If rLayout8.Checked Then
            layoutName = "Layout8"
            Me.Close()
        End If
        If rLayout9.Checked Then
            layoutName = "Layout9"
            Me.Close()
        End If
        If rLayout10.Checked Then
            layoutName = "Layout10"
            Me.Close()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub LabelControl53_Click(sender As Object, e As EventArgs) Handles LabelControl53.Click

    End Sub

    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles LabelControl1.Click

    End Sub
End Class