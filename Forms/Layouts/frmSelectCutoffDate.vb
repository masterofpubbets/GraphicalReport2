Public Class frmSelectCutoffDate
    Public isSelect As Boolean = False
    Public Conn As New Connections.stDBonnection
    Public Query As String = ""
    Private er As New Errors


    Public Sub New(ByVal ConnName As String, ByVal ConnType As String, ByVal DBNmae As String, ByVal ID As Integer, ByVal URl As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Conn.ConnName = ConnName
        Conn.ConnType = ConnType
        Conn.DBNmae = DBNmae
        Conn.ID = ID
        Conn.URl = URl

        If Conn.DBNmae <> "" Then
            lblConName.Text = Conn.ConnName
            lblDBType.Text = Conn.ConnType
            lblConURL.Text = Conn.URl
            lblConDBName.Text = Conn.DBNmae
        End If

    End Sub
    Private Function isValidate() As Boolean
        Try
            If Trim(txtSQL.Text) = "" Then
                MsgBox("Please type a valid sql command!", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If
            If Trim(lblConName.Text) = "---" Then
                MsgBox("Please select a connection set!", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If
            If InStr(txtSQL.Text, "AS CUTOFFDATE", CompareMethod.Text) = 0 Then
                MsgBox("The qyery has to contain CUTOFFDATE as a column please use (AS CUTOFFDATE) for the cuttoff returned column!", MsgBoxStyle.Exclamation, Me.Text)
                Return False
            End If
        Catch ex As Exception
            er.RaiseInternalError(ex.Message)
            Return False
        End Try
        Return True
    End Function
    Private Function IsQueryValid() As Boolean
        Try
            Dim dt As New DataTable
            If isValidate() Then
                If DBTemp.DBStatus = ConnectionState.Connecting Or DBTemp.DBStatus = ConnectionState.Executing Or DB.DBStatus = ConnectionState.Open Then
                    DBTemp.Close()
                End If
                DBTemp.DataBaseLocation = lblConURL.Text
                DBTemp.DataBaseName = lblConDBName.Text

                DBTemp.Connect()
                If DBTemp.DBStatus = ConnectionState.Open Then
                    dt = DBTemp.ReturnDataTable(txtSQL.Text)
                End If
                Return True
            End If
            Return False

        Catch ex As Exception
            er.RaiseInternalError(ex.Message)
        End Try
        Return True
    End Function
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rQuery.CheckedChanged
        gpQuery.Visible = rQuery.Checked
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim frm As New frmSelectConns
        frm.ShowDialog(Me)
        If frm.isSelect Then
            Dim connection As New Connections.stDBonnection
            Dim conns As New Connections
            connection = conns.GetConnections(frm.connId)
            Conn.ConnName = connection.ConnName
            Conn.ConnType = connection.ConnType
            Conn.URl = connection.URl
            Conn.ID = connection.ID
            Conn.DBNmae = connection.DBNmae
            lblConName.Text = connection.ConnName
            lblDBType.Text = connection.ConnType
            lblConURL.Text = connection.URl
            If connection.ConnType = "SQLSERVER" Then
                lblConDBName.Text = connection.DBNmae
                lblConDBNameHeader.Visible = True
                lblConDBName.Visible = True
            Else
                lblConDBNameHeader.Visible = False
                lblConDBName.Visible = False
            End If
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim dt As New DataTable

        Try
            If isValidate() Then
                If DBTemp.DBStatus = ConnectionState.Connecting Or DBTemp.DBStatus = ConnectionState.Executing Or DB.DBStatus = ConnectionState.Open Then
                    DBTemp.Close()
                End If
                DBTemp.DataBaseLocation = lblConURL.Text
                DBTemp.DataBaseName = lblConDBName.Text

                DBTemp.Connect()
                If DBTemp.DBStatus = ConnectionState.Open Then
                    dt = DBTemp.ReturnDataTable(txtSQL.Text)


                    Dim frmResult As New frmQueryResults
                    frmQueryResults.gv.Columns.Clear()
                    frmQueryResults.grd.DataSource = dt
                    frmQueryResults.ShowDialog(Me)
                End If

            End If


        Catch ex As Exception
            er.RaiseInternalError(ex.Message)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If rPrintDate.Checked Then
            isSelect = True
            Query = "$(PRINTDATE)"
            Me.Close()
        End If

        If rNoDate.Checked Then
            isSelect = True
            Query = "$(NONE)"
            Me.Close()
        End If

        If rQuery.Checked Then
            If IsQueryValid() Then
                isSelect = True
                Query = txtSQL.Text
                Me.Close()
            End If
        End If
    End Sub
End Class