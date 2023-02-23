Imports DevExpress.XtraBars

Public Class frmCreateConnection
    Public isAdded As Boolean = False
    Private con As New Connections

    Private Function IsValidate() As Boolean
        If Trim(txtConName.Text) = "" Then
            MsgBox("Please type Set Name", MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If
        If Trim(txtPath.Text) = "" Then
            If chkTypeExcel.Checked Then
                MsgBox("Please select Excel file!", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            Else
                MsgBox("Please type server URL!", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If
        End If
        If chkTypeSQL.Checked Then
            If Trim(txtDBName.Text) = "" Then
                MsgBox("Please type DB name!", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If
        End If

        Return True
    End Function
    Private Sub ClearTexts()
        txtConName.Text = ""
        txtPath.Text = ""
        txtDBName.Text = ""
        txtConName.Focus()
    End Sub
    Private Sub chkTypeExcel_ItemClick(sender As Object, e As ItemClickEventArgs) Handles chkTypeExcel.ItemClick
        chkTypeSQL.Checked = Not chkTypeExcel.Checked
        btnSelectPath.Visible = chkTypeExcel.Checked
        txtPath.Enabled = False
        popDBType.Text = "Excel"
        lblDBTitle.Visible = False
        txtDBName.Visible = False
        lblServerPathTitle.Text = "File URL:"
    End Sub

    Private Sub chkTypeSql_ItemClick(sender As Object, e As ItemClickEventArgs) Handles chkTypeSQL.ItemClick
        chkTypeExcel.Checked = Not chkTypeSQL.Checked
        btnSelectPath.Visible = chkTypeExcel.Checked
        txtPath.Enabled = True
        popDBType.Text = "SQL Server"
        lblDBTitle.Visible = True
        txtDBName.Visible = True
        lblServerPathTitle.Text = "Server URL:"
        txtPath.Text = ""
    End Sub

    Private Sub frmCreateConnection_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmCreateConnection_Load(sender As Object, e As EventArgs) Handles Me.Load
        popDBType.Text = "SQL Server"
        chkTypeSQL.Checked = True
    End Sub

    Private Sub btnSelectPath_Click(sender As Object, e As EventArgs) Handles btnSelectPath.Click
        opnFle.FileName = ""
        opnFle.ShowDialog()
        If opnFle.FileName <> "" Then
            txtPath.Text = opnFle.FileName
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If IsValidate() Then
            If chkTypeSQL.Checked Then
                isAdded = True
                If con.AddConnection(txtConName.Text, Connections.enConnectionType.SQLSERVER, txtPath.Text, txtDBName.Text) Then
                    If MsgBox("New connection has been saved." & vbCrLf & "Do you want to add a new one?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                        Me.Close()
                    Else
                        ClearTexts()
                    End If
                End If
            Else
                If con.AddConnection(txtConName.Text, Connections.enConnectionType.EXCEL, txtPath.Text, txtDBName.Text) Then
                    If MsgBox("New connection has been saved." & vbCrLf & "Do you want to add a new one?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                        Me.Close()
                    Else
                        ClearTexts()
                    End If
                End If
            End If

        End If
    End Sub
End Class