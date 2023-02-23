Public Class GenerateGraphicalReport
    Private DT As DataTable
    Public Event err(ByVal mes As String)
    Private gr As New GraphicalReport2
    Private _OutputPath As String, _ExportFileType As GraphicalReport2.e_exportfiletype
    Public Event Finished()
    Private st As New EAMS.StringFunctions.Common

    Public WriteOnly Property DPI() As Double
        Set(value As Double)
            gr.DPI = value
        End Set
    End Property
    Public WriteOnly Property TagContainsDash() As Boolean
        Set(value As Boolean)
            gr.TagContainsDash = value
        End Set
    End Property

    Private Sub Export()
        gr.ExportResults(_OutputPath, _ExportFileType)
    End Sub
    Private Sub CorrectTags(ByRef DtTable As DataTable)
        For Each r As DataRow In DtTable.Select("[tag] is null or [status] is null")
            DtTable.Rows.Remove(r)
        Next
        For inx As Integer = 0 To DtTable.Rows.Count - 1
            If InStr(DtTable.Rows(inx).Item("Tag"), "&", CompareMethod.Text) Then
                DtTable.Rows(inx).Item("Tag") = Replace(DtTable.Rows(inx).Item("Tag"), "&", "&amp;")
            End If
        Next
    End Sub

    Public Sub Generate(ByRef DrawingPath As String, ByRef QueryPath As String, ByVal DBName As String, ByVal DBServer As String, ByVal DBType As String, ByVal OutputPath As String, ExportFileType As GraphicalReport2.e_exportfiletype, ByVal HasPattern As Boolean, ByVal ReplaceTag As Boolean)
        Try
            _ExportFileType = ExportFileType
            _OutputPath = OutputPath
            DT = Nothing
            DT = New DataTable
            Dim data As New GetDataTable


            Dim obj As New System.IO.StreamReader(QueryPath)
            Dim q As String = obj.ReadToEnd
            obj.Close()
            DT = data.GetDT(q, DBType, DBServer, DBName)


            If HasPattern Then
                DT.TableName = "gr"
                Dim dv As New DataView() With {.Table = DT}
                gr.PatternStatus = dv.ToTable(DT.TableName, True, {"Status", "PatternNo"})
            End If
            If DT.Rows.Count = 0 Then
                RaiseEvent err("No Data")
                Exit Sub
            End If
            If DT.Columns.Count < 2 Then
                RaiseEvent err("Incomplete Data")
                Exit Sub
            End If
            CorrectTags(DT)
            gr.Generate(DrawingPath, HasPattern, DT, Replace(st.GetFileName(QueryPath), ".txt", ""), ReplaceTag)
            RaiseEvent Finished()
        Catch ex As Exception
            RaiseEvent err(ex.Message)
        End Try
    End Sub

    Public Sub New()
        AddHandler gr.EditFinished, AddressOf Export
    End Sub

End Class
