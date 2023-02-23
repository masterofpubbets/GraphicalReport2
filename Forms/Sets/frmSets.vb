Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Public Class frmSets
    Private dra As New DrawingSets
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1


    Private Sub formatColumnsWidth()
        Try
            If IsNothing(colWidth) Then
                For inx As Integer = 1 To gv.Columns.Count
                    gv.Columns.Item(inx - 1).Width = 100
                Next
            Else
                gv.FocusedRowHandle = focusedRowHandler
                For inx As Integer = 1 To gv.Columns.Count
                    gv.Columns.Item(inx - 1).Width = colWidth.Item(inx)
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub saveColumnsWidth()
        Try
            If gv.RowCount <> 0 Then
                focusedRowHandler = gv.FocusedRowHandle

                If IsNothing(colWidth) Then
                    colWidth = New Collection
                    For inx As Integer = 0 To gv.Columns.Count - 1
                        colWidth.Add(gv.Columns.Item(inx).Width)
                    Next
                Else
                    colWidth.Clear()
                    For inx As Integer = 0 To gv.Columns.Count - 1
                        colWidth.Add(gv.Columns.Item(inx).Width)
                    Next
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub GetData()
        saveColumnsWidth()
        grd.DataSource = dra.GetData
        formatColumnsWidth()
        gv.Columns("ID").Visible = False
        gv.Columns("ConnID").Visible = False
        gv.Columns("CutoffDateConnID").Visible = False

        gv.BestFitColumns(True)

        gv.Columns("Drawings Folder").Width = 50
        gv.Columns("Main Query").Width = 50
        gv.Columns("Output Folder").Width = 50
        gv.Columns("Set Name").Width = 120
        gv.Columns("Conn Name").Width = 75
    End Sub


    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim frm As New frmAddSet
        frm.ShowDialog(Me)
        If frm.isAdded Then
            GetData()
        End If
    End Sub

    Private Sub frmSets_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick

    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Edit This Set?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        If gv.GetSelectedRows.Count = 0 Then Exit Sub
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        Dim connSet As New Connections.stDBonnection
        Dim cutOffConnSet As New Connections.stDBonnection

        Dim frm As New frmAddSet(True)
        frm.Text = "Edit Set: " & gv.GetDataRow(row_handle).Item("Set Name")

        frm.txtSetName.Text = gv.GetDataRow(row_handle).Item("Set Name")
        frm.lblQueryPath.Text = gv.GetDataRow(row_handle).Item("Main Query")
        frm.lblDBSet.Text = gv.GetDataRow(row_handle).Item("Conn Name")
        frm.lblDrawingFolder.Text = gv.GetDataRow(row_handle).Item("Drawings Folder")
        frm.lblSummaryFolder.Text = gv.GetDataRow(row_handle).Item("Summaries Folder")
        frm.lblOutputFolder.Text = gv.GetDataRow(row_handle).Item("Output Folder")
        frm.ckTagDash.Checked = gv.GetDataRow(row_handle).Item("Tag Contains Dash")
        frm.ckPattern.Checked = gv.GetDataRow(row_handle).Item("Pattern")
        frm.lblPhotoFolderPath.Text = gv.GetDataRow(row_handle).Item("Photos Folder")

        frm.lblLayoutName.Text = gv.GetDataRow(row_handle).Item("Layout")
        frm.picLayout.Image = Image.FromFile(Application.StartupPath & "\templates\layouts\images\" & gv.GetDataRow(row_handle).Item("Layout") & ".jpg")
        Select Case gv.GetDataRow(row_handle).Item("Layout")
            Case "Default", "Layout2", "Layout4"
                frm.lblPhotoFolderPath.Visible = False
                frm.btnSelectPhotoPath.Enabled = False
            Case Else
                frm.lblPhotoFolderPath.Visible = True
                frm.btnSelectPhotoPath.Enabled = True
                frm.lblPhotoFolderPath.Text = gv.GetDataRow(row_handle).Item("Photos Folder")
        End Select
        Select Case gv.GetDataRow(row_handle).Item("Layout")
            Case "Layout9", "Layout10"
                frm.picClient.Visible = True
                frm.SimpleButton13.Enabled = True
            Case Else
                frm.picClient.Visible = False
                frm.SimpleButton13.Enabled = False
        End Select

        frm.lblDrawingHeader.Text = gv.GetDataRow(row_handle).Item("Header")
        If Not IsDBNull(gv.GetDataRow(row_handle).Item("Header2")) Then frm.lblDrawingHeader2.Text = gv.GetDataRow(row_handle).Item("Header2")
        If Not IsDBNull(gv.GetDataRow(row_handle).Item("Header3")) Then frm.lblDrawingHeader3.Text = gv.GetDataRow(row_handle).Item("Header3")
        frm.lblDrawingSubheader.Text = gv.GetDataRow(row_handle).Item("Sub Header")
        frm.lblCutoffDate.Text = gv.GetDataRow(row_handle).Item("Cutoff Date")
        If Not IsDBNull(gv.GetDataRow(row_handle).Item("ClientLogo")) Then frm.clientLogoPath = gv.GetDataRow(row_handle).Item("ClientLogo")

        Dim conn As New Connections
        frm.SetMainConn(conn.GetConnections(gv.GetDataRow(row_handle).Item("ConnID")))

        If Not IsDBNull(gv.GetDataRow(row_handle).Item("CutoffDateConnID")) Then
            frm.SetCutoffDateConn(conn.GetConnections(gv.GetDataRow(row_handle).Item("CutoffDateConnID")))
        End If

        frm.DrawingSetId = gv.GetDataRow(row_handle).Item("ID")

        frm.SimpleButton2.Text = "Save"

        frm.ShowDialog(Me)

        If frm.isAdded Then
            GetData()
        End If

    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If MsgBox("Are You Sure you Want To Delete Selected Set(s)?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        For Each row_handle As Integer In gv.GetSelectedRows
            dra.Delete(gv.GetDataRow(row_handle).Item("ID"))
        Next
        GetData()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        If MsgBox("Do You Want To Generate Layout For Selected Set(s)?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim dt As New DataTable

        dt.Columns.Add("Set Name")
        dt.Columns.Add("ConnID")
        dt.Columns.Add("Conn Name")
        dt.Columns.Add("Drawing Name")
        dt.Columns.Add("Drawing Path")
        dt.Columns.Add("Main Query")
        dt.Columns.Add("Summaries Folder")
        dt.Columns.Add("Output Folder")
        dt.Columns.Add("Layout")
        dt.Columns.Add("Photos Folder")
        dt.Columns.Add("Pattern")
        dt.Columns.Add("Tag Contains Dash")
        dt.Columns.Add("Header")
        dt.Columns.Add("Header2")
        dt.Columns.Add("Header3")
        dt.Columns.Add("Sub Header")
        dt.Columns.Add("CutoffDateConnID")
        dt.Columns.Add("Cutoff Date Conn Name")
        dt.Columns.Add("Cutoff Date")
        dt.Columns.Add("CLientLogo")


        For Each row_handle As Integer In gv.GetSelectedRows
            Dim Fi As String() = IO.Directory.GetFileSystemEntries(gv.GetDataRow(row_handle).Item("Drawings Folder"), "*.svg")
            For Each el As String In Fi
                dt.Rows.Add(gv.GetDataRow(row_handle).Item("Set Name"), gv.GetDataRow(row_handle).Item("ConnID"), gv.GetDataRow(row_handle).Item("Conn Name"), dra.GetFileName(el), el, gv.GetDataRow(row_handle).Item("Main Query"), gv.GetDataRow(row_handle).Item("Summaries Folder"), gv.GetDataRow(row_handle).Item("Output Folder"), gv.GetDataRow(row_handle).Item("Layout"), gv.GetDataRow(row_handle).Item("Photos Folder"), gv.GetDataRow(row_handle).Item("Pattern"), gv.GetDataRow(row_handle).Item("Tag Contains Dash"), gv.GetDataRow(row_handle).Item("Header"), gv.GetDataRow(row_handle).Item("Header2"), gv.GetDataRow(row_handle).Item("Header3"), gv.GetDataRow(row_handle).Item("Sub Header"), gv.GetDataRow(row_handle).Item("CutoffDateConnID"), gv.GetDataRow(row_handle).Item("Cutoff Date Conn Name"), gv.GetDataRow(row_handle).Item("Cutoff Date"), gv.GetDataRow(row_handle).Item("ClientLogo"))
            Next
        Next

        Dim frm As New frmGenerateLayout
        frm.grd.DataSource = dt
        frm.gv.Columns.Item("ConnID").Visible = False
        frm.gv.Columns.Item("CutoffDateConnID").Visible = False
        If frm.gv.Columns.Count > 0 Then
            frm.gv.Columns.Item("Set Name").GroupIndex = 1
            frm.gv.ExpandAllGroups()
        End If
        frm.MdiParent = frmMain
        frm.Show()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        If gv.GetSelectedRows.Count = 0 Then Exit Sub
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        Dim frm As New frmNewSetName
        frm.ShowDialog(Me)
        If frm.isAdded Then
            Dim newDraw As New DrawingSets.st_Drawings
            newDraw.ConId = gv.GetDataRow(row_handle).Item("ConnID")
            newDraw.CutoffConId = gv.GetDataRow(row_handle).Item("CutoffDateConnID")
            newDraw.CutoffDate = gv.GetDataRow(row_handle).Item("Cutoff Date")
            newDraw.FolderPath = gv.GetDataRow(row_handle).Item("Drawings Folder")
            newDraw.HasPattern = gv.GetDataRow(row_handle).Item("Pattern")
            newDraw.Header = gv.GetDataRow(row_handle).Item("Header")
            newDraw.Layout = gv.GetDataRow(row_handle).Item("Layout")
            newDraw.OutputFolderPath = gv.GetDataRow(row_handle).Item("Output Folder")
            newDraw.PhotoFolderPath = gv.GetDataRow(row_handle).Item("Photos Folder")
            newDraw.QueryPath = gv.GetDataRow(row_handle).Item("Main Query")
            newDraw.QuerySummaryFolderPath = gv.GetDataRow(row_handle).Item("Summaries Folder")
            newDraw.ReplaceTag = 0
            newDraw.SetName = frm.newName
            newDraw.Subheader = gv.GetDataRow(row_handle).Item("Sub Header")
            newDraw.TagHasDash = gv.GetDataRow(row_handle).Item("Tag Contains Dash")

            If dra.Add(newDraw) Then
                GetData()
            End If
        End If
    End Sub
End Class