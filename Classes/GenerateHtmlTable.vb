Public Class GenerateHtmlTable
    Private data As New GetDataTable

    Public Function GenerateSummariesHtmlTable(ByVal layoutTemplate As String, ByVal summaryQuryPath As String, ByVal drawingPath As String, ByVal conType As String, ByVal dbName As String, ByVal url As String) As String()
        Dim temp() As String = Split(drawingPath, "\")
        Dim drawingName As String = temp(temp.Length - 1)
        Dim querySummaryPath As String = summaryQuryPath & "\" & Replace(drawingName, ".svg", "",,, CompareMethod.Text) & ".txt"
        Dim dt As New DataTable
        Dim table(3) As String
        Dim q As String = ""
        Dim summariesText() As String = GetSummaryTableQueryPath(layoutTemplate, summaryQuryPath, drawingPath)
        Dim summaries(3) As String

        Select Case layoutTemplate
            Case "Default", "Layout6", "Layout3", "Layout7"
                If IO.File.Exists(summariesText(0)) Then
                    Dim obj As New System.IO.StreamReader(summariesText(0))
                    q = obj.ReadToEnd
                    obj.Close()
                    dt = New DataTable
                    dt = data.GetDT(q, conType, url, dbName)
                    summaries(0) = GenerateTable(dt, layoutTemplate)
                End If
            Case "Layout2", "Layout5", "Layout8"
                For inx As Integer = 0 To 1
                    If IO.File.Exists(summariesText(inx)) Then
                        Dim obj As New System.IO.StreamReader(summariesText(inx))
                        q = obj.ReadToEnd
                        obj.Close()
                        dt = New DataTable
                        dt = data.GetDT(q, conType, url, dbName)
                        summaries(inx) = GenerateTable(dt, layoutTemplate)
                    End If
                Next
            Case "Layout4"
                For inx As Integer = 0 To 3
                    If IO.File.Exists(summariesText(inx)) Then
                        Dim obj As New System.IO.StreamReader(summariesText(inx))
                        q = obj.ReadToEnd
                        obj.Close()
                        dt = New DataTable
                        dt = data.GetDT(q, conType, url, dbName)
                        summaries(inx) = GenerateTable(dt, layoutTemplate)
                    End If
                Next
        End Select

        Return (summaries)
    End Function
    Private Function GetSummaryTableQueryPath(ByVal layoutTemplate As String, ByVal summaryQuryPath As String, ByVal drawingPath As String) As String()
        Dim temp() As String = Split(drawingPath, "\",, CompareMethod.Text)
        Dim summaries(3) As String

        If temp.Length > 0 Then
            Select Case layoutTemplate
                Case "Default", "Layout3", "Layout6", "Layout7"
                    summaries(0) = summaryQuryPath & "\" & Replace(temp(temp.Length - 1), ".svg", "1",,, CompareMethod.Text) & ".txt"
                    Return (summaries)
                Case "Layout2", "Layout5", "Layout8"
                    summaries(0) = summaryQuryPath & "\" & Replace(temp(temp.Length - 1), ".svg", "1",,, CompareMethod.Text) & ".txt"
                    summaries(1) = summaryQuryPath & "\" & Replace(temp(temp.Length - 1), ".svg", "2",,, CompareMethod.Text) & ".txt"
                    Return (summaries)
                Case "Layout4"
                    summaries(0) = summaryQuryPath & "\" & Replace(temp(temp.Length - 1), ".svg", "1",,, CompareMethod.Text) & ".txt"
                    summaries(1) = summaryQuryPath & "\" & Replace(temp(temp.Length - 1), ".svg", "2",,, CompareMethod.Text) & ".txt"
                    summaries(2) = summaryQuryPath & "\" & Replace(temp(temp.Length - 1), ".svg", "3",,, CompareMethod.Text) & ".txt"
                    summaries(3) = summaryQuryPath & "\" & Replace(temp(temp.Length - 1), ".svg", "4",,, CompareMethod.Text) & ".txt"
                    Return (summaries)

            End Select
        End If
        Return Nothing
    End Function
    Private Function getTD(ByVal scope As Double, ByVal done As Double) As String
        If scope = done Then Return "<td class=""done"">"
        Return "<td>"
    End Function
    Public Overloads Function formatNumber(ByVal data As String) As String
        If IsNumeric(data) Then
            If data = 0 Then Return "0"
            Return (Format(Val(data), "##,##"))
        End If
        Return data
    End Function
    Public Overloads Function formatNumber(ByVal data As Integer) As String
        If data = 0 Then Return "0"
        Return (Format(data, "##,##"))
    End Function
    Public Overloads Function formatNumber(ByVal data As Double) As String
        If data = 0 Then Return "0"
        Dim nm As String = Format(data, "##,##.##")
        If nm <> "" Then
            If nm.Chars(0) = "." Then nm = "0" & nm
        End If
        Return (nm)
    End Function
    Public Overloads Function formatNumber(ByVal data As DBNull) As String
        Return ("0")
    End Function
    Private Sub addRowTotal(ByVal index As Integer, ByVal value As String, ByRef rowTotal As String())
        If IsNumeric(value) Then
            rowTotal(index) = Val(rowTotal(index)) + value
        Else
            rowTotal(index) = "TOTAL"
        End If
    End Sub
    Private Function getTableColumns(ByRef mainData As DataTable, ByVal startIndex As Integer) As String
        Dim dataColumn As String = ""
        dataColumn = "<tr>"
        For inx As Integer = startIndex To mainData.Columns.Count - 1
            dataColumn &= "<th>" & mainData.Columns.Item(inx).ColumnName & "</th>"
        Next
        dataColumn &= "</tr>"
        Return dataColumn
    End Function
    Private Function addTotalToTable(ByRef rowTotal As String()) As String
        Dim row As String = "<tr>"
        For inx As Integer = 0 To rowTotal.Length - 1
            row &= "<td class=""rowTotal"">" & formatNumber(rowTotal(inx)) & "</td>"
        Next
        row &= "</tr>"
        Return row
    End Function
    Private Function GenerateTable(ByRef mainData As DataTable, ByVal className As String) As String
        Try
            Dim rows() As DataRow
            Dim startIndex As Integer = 0
            Dim tableColumns As String = getTableColumns(mainData, startIndex)
            Dim tableRows As String = ""
            Dim td As String = ""
            Dim tempTable As String = ""

            'For inz As Integer = 0 To mainData.Rows.Count - 1

            'main data
            rows = mainData.Select("")
            tableRows = ""
            If rows.Length > 0 Then
                Dim rowTotal(mainData.Columns.Count - startIndex - 1) As String
                For inr As Integer = 0 To rows.Length - 1

                    td = getTD(1, 0)

                    tableRows &= "<tr>"
                    For inc As Integer = startIndex To mainData.Columns.Count - 1
                        tableRows &= td & formatNumber(rows(inr).Item(mainData.Columns(inc).ColumnName)) & "</td>"

                        If Not IsDBNull(rows(inr).Item(mainData.Columns(inc).ColumnName)) Then
                            addRowTotal(inc - startIndex, rows(inr).Item(mainData.Columns(inc).ColumnName).ToString, rowTotal)
                        Else
                            addRowTotal(inc - startIndex, "0", rowTotal)
                        End If

                    Next
                    tableRows &= "</tr>"
                Next

                tableRows &= addTotalToTable(rowTotal)

                'generate tables
                tempTable &= "<div class=""" & className & """><table id=""table"">"
                tempTable &= tableColumns & vbCrLf
                tempTable &= tableRows
                tempTable &= "</table></div>" & vbCrLf
            End If

            'Next

            Return tempTable
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function
End Class
