Public Class frmQueryCheck
    Private checked As Boolean = False
    Public Conn As New Connections.stDBonnection
    Public QueryPath As String = ""
    Private er As New Errors
    Public isSelect As Boolean = False
    Private data As New GetDataTable

    Public Sub New(ByVal ConName As String, ByVal DBType As String, ByVal ConURL As String, ByVal ConId As String, ByVal DBName As String, ByVal QueryPath As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Conn.ConnName = ConName
        Conn.ConnType = DBType
        Conn.URl = ConURL
        Conn.ID = ConId
        Conn.DBNmae = DBName
        lblConDBName.Text = Conn.DBNmae
        lblConName.Text = Conn.ConnName
        lblConURL.Text = Conn.URl
        lblDBType.Text = Conn.ConnType
        lblQueryPath.Text = QueryPath
    End Sub

    Private Function IsValidate(ByVal dt As DataTable, ByRef result As String) As Boolean
        If dt.Columns.Count = 0 Then
            result &= "Queru must contains column Tag." & vbCrLf
            lblNotValid.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            lblValid.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
            Return False
        End If
        If Not dt.Columns.Contains("Tag") Then
            result &= "Queru must contains column Tag." & vbCrLf
            lblNotValid.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            lblValid.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
            Return False
        End If
        If Not dt.Columns.Contains("Status") Then
            result &= "Queru must contains column Status." & vbCrLf
            lblNotValid.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            lblValid.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
            Return False
        End If
        If Not dt.Columns.Contains("PatternNo") Then
            result &= "Queru must contains column PatternNo." & vbCrLf
            lblNotValid.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            lblValid.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
            Return False
        End If
        checked = True
        lblNotValid.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        lblValid.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Return True
    End Function
    Private Sub SaveFile()
        IO.File.WriteAllText(lblQueryPath.Text, txtQuery.Text, System.Text.Encoding.Default)
    End Sub
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim result As String = ""
        Dim dt As New DataTable

        If lblConName.Text = "---" Or lblConName.Text = "" Then
            MsgBox("Please select Connection first!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        If txtQuery.Text = "" Then
            MsgBox("Please select query file first!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If

        Try
            dt = data.GetDT(txtQuery.Text, Conn.ConnType, lblConURL.Text, lblConDBName.Text)

            If IsValidate(dt, result) Then
                SaveFile()
                isSelect = True
                Me.Close()
            Else
                Dim frm As New frmQueryError
                frm.lblError.Text = result
                frm.ShowDialog(Me)
            End If
        Catch ex As Exception
            er.RaiseInternalError(ex.Message)
        End Try
    End Sub

    Private Sub txtQuery_TextChanged(sender As Object, e As EventArgs) Handles txtQuery.TextChanged
        checked = False
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
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

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim result As String = ""
        Dim dt As New DataTable


        Try

            If Conn.ConnName = "" Then
                MsgBox("Please select Connection first!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            If txtQuery.Text = "" Then
                MsgBox("Please select query file first!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If

            dt = data.GetDT(txtQuery.Text, Conn.ConnType, lblConURL.Text, lblConDBName.Text)

            If IsValidate(dt, result) Then
                Dim frmResult As New frmQueryResults
                frmQueryResults.gv.Columns.Clear()
                frmQueryResults.grd.DataSource = dt
                frmQueryResults.ShowDialog(Me)
            Else
                Dim frm As New frmQueryError
                frm.lblError.Text = result
                frm.ShowDialog(Me)
            End If

        Catch ex As Exception
            er.RaiseInternalError(ex.Message)
        End Try
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        If opnFle.FileName <> "" Then
            lblQueryPath.Text = opnFle.FileName
            QueryPath = opnFle.FileName
            Dim obj As New System.IO.StreamReader(opnFle.FileName)
            txtQuery.Text = obj.ReadToEnd
            obj.Close()
        End If
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        txtQuery.Text = ""
    End Sub

End Class