Public Class frmGenerateLayout
    Private gr As New GenerateGraphicalReport
    Private html As New GenerateHtml
    Private conn As New Connections

    Private Sub UpdateSelectedDrawing(ByRef DrawingPath As String, ByRef QueryPath As String, ByVal DBName As String, ByVal DBServer As String, ByVal DBType As String, ByVal OutputPath As String, ExportFileType As GraphicalReport.e_exportfiletype, ByVal HasPattern As Boolean, ByVal ReplaceTag As Boolean)

        gr.Generate(DrawingPath, QueryPath, DBName, DBServer, DBType, OutputPath, ExportFileType, HasPattern, ReplaceTag)
    End Sub
    Private Sub RecursiveDele()
        Try
            Dim Fi As String() = IO.Directory.GetFileSystemEntries(Application.StartupPath & "\tmp")
            For Each el As String In Fi
                IO.File.Delete(el)
            Next

            For row_handle As Integer = 0 To gv.RowCount - 1 - gv.GroupCount
                Dim Fi2 As String() = IO.Directory.GetFileSystemEntries(gv.GetDataRow(row_handle).Item("Output Folder"), "*.pdf", IO.SearchOption.TopDirectoryOnly)
                For Each el As String In Fi2
                    IO.File.Delete(el)
                Next
                Dim Fi22 As String() = IO.Directory.GetFileSystemEntries(gv.GetDataRow(row_handle).Item("Output Folder"), "*.png", IO.SearchOption.TopDirectoryOnly)
                For Each el As String In Fi22
                    IO.File.Delete(el)
                Next
                Dim Fi33 As String() = IO.Directory.GetFileSystemEntries(gv.GetDataRow(row_handle).Item("Output Folder"), "*.html", IO.SearchOption.TopDirectoryOnly)
                For Each el As String In Fi33
                    IO.File.Delete(el)
                Next
            Next

            Dim Fi3 As String() = IO.Directory.GetFileSystemEntries(Application.StartupPath & "\tmpUpdated")
            For Each el As String In Fi3
                IO.File.Delete(el)
            Next
        Catch ex As Exception
            If MsgBox("Some File Already Open!", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then RecursiveDele()
        End Try
    End Sub
    Private Sub GenerateReports()
        RecursiveDele()

        Dim ReplaceTag As Boolean
        Dim HasPattern As Boolean
        Dim dbCol As New Connections.stDBonnection
        Dim dbCutoffDateCol As New Connections.stDBonnection
        Dim summaryFolderPath As String = ""
        Dim photoFolderPath As String = ""

        For inx As Integer = 0 To gv.RowCount - 1 - gv.GroupCount

            If gv.GetDataRow(inx).Item("Tag Contains Dash") Then
                gr.TagContainsDash = True
            Else
                gr.TagContainsDash = False
            End If
            ReplaceTag = False
            HasPattern = gv.GetDataRow(inx).Item("Pattern")

            dbCol = conn.GetConnections(gv.GetDataRow(inx).Item("ConnID"))
            dbCutoffDateCol = conn.GetConnections(gv.GetDataRow(inx).Item("CutoffDateConnID"))


            UpdateSelectedDrawing(gv.GetDataRow(inx).Item("Drawing Path"), gv.GetDataRow(inx).Item("Main Query"), dbCol.DBNmae, dbCol.URl, dbCol.ConnType, gv.GetDataRow(inx).Item("Output Folder"), GraphicalReport.e_exportfiletype.png, HasPattern, ReplaceTag)

            'generate html
            If Not IsDBNull(gv.GetDataRow(inx).Item("Summaries Folder")) Then summaryFolderPath = gv.GetDataRow(inx).Item("Summaries Folder")
            If Not IsDBNull(gv.GetDataRow(inx).Item("Photos Folder")) Then photoFolderPath = gv.GetDataRow(inx).Item("Photos Folder")

            html.GenerateHTMLReport(gv.GetDataRow(inx).Item("Main Query"), summaryFolderPath, dbCol.ConnType, dbCol.DBNmae, dbCol.URl, gv.GetDataRow(inx).Item("Drawing Path"), gv.GetDataRow(inx).Item("Layout"), photoFolderPath, gv.GetDataRow(inx).Item("Header"), gv.GetDataRow(inx).Item("Sub Header"), dbCutoffDateCol.ConnType, dbCutoffDateCol.DBNmae, dbCutoffDateCol.URl, gv.GetDataRow(inx).Item("Cutoff Date"), gv.GetDataRow(inx).Item("Output Folder"), gv.GetDataRow(inx).Item("ClientLogo"), gv.GetDataRow(inx).Item("Header2"), gv.GetDataRow(inx).Item("Header3"))
            '------------------------------------

        Next


    End Sub

    Private Sub GeneratePdfs()
        Dim export As New GeneratePdf
        Dim col As New Collection

        For inx As Integer = 0 To gv.RowCount - 1 - gv.GroupCount
            If Not col.Contains(gv.GetDataRow(inx).Item("Output Folder")) Then
                col.Add(gv.GetDataRow(inx).Item("Output Folder"), gv.GetDataRow(inx).Item("Output Folder"))
            End If
        Next
        For inx As Integer = 1 To col.Count
            export.GeneratePdf(col.Item(inx))
        Next
        MsgBox("pdf(s) have been generated.", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        gv.DeleteSelectedRows()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        lblWorking.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        BarButtonItem2.Enabled = False
        Application.DoEvents()
        If MsgBox("Do You Want To Generate Layout?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub

        Try
            GenerateReports()
            MsgBox("html Layout(s) have been generated.", MsgBoxStyle.Information, Me.Text)
            If MsgBox("Do You Want To Generate pdf?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                GeneratePdfs()
            End If
            lblWorking.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
            BarButtonItem2.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            lblWorking.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
            BarButtonItem2.Enabled = True
        End Try

    End Sub
End Class