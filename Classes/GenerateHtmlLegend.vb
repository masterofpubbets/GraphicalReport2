Public Class GenerateHtmlLegend

    Structure st_colors
        Dim Status As String
        Dim FillColorR As Byte
        Dim FillColorG As Byte
        Dim FillColorB As Byte
        Dim FillColorT As Double
        Dim StrokeColorR As Byte
        Dim StrokeColorG As Byte
        Dim StrokeColorB As Byte
        Dim StrokeColorT As Double
    End Structure
    Private Function GetStatusColor(ByRef Status As String) As st_colors
        Dim dt As DataTable = DBAc.ReturnDataTable(String.Format("select * from t_color_code where status_name ='{0}'", Status))
        If dt.Rows.Count <> 0 Then
            Dim temp As New st_colors With {
                .Status = Status,
                .FillColorR = dt.Rows(0).Item("r"),    'fill color
                .FillColorG = dt.Rows(0).Item("g"),    'fill color
                .FillColorB = dt.Rows(0).Item("b"),   'fill color
                .FillColorT = dt.Rows(0).Item("t"),    'fill color
                .StrokeColorR = dt.Rows(0).Item("sr"),
                .StrokeColorG = dt.Rows(0).Item("sg"),
                .StrokeColorB = dt.Rows(0).Item("sb"),
                .StrokeColorT = dt.Rows(0).Item("st")
            }
            Return temp
        End If
        Return Nothing
    End Function
    Public Function GetLegend(ByVal queryPath As String, ByVal DBName As String, ByVal DBServer As String, ByVal DBType As String) As String
        Try
            Dim tempList As New Collection


            Dim data As New GetDataTable
            Dim obj As New System.IO.StreamReader(queryPath), q As String = ""
            q = obj.ReadToEnd
            obj.Close()
            Dim dt As New DataTable
            dt = data.GetDT(q, DBType, DBServer, DBName)
            Dim statusColors As New List(Of st_colors)

            For inx As Integer = 0 To dt.Rows.Count - 1
                If Not IsDBNull(dt.Rows(inx).Item("Status")) And dt.Rows(inx).Item("Status") <> "" Then
                    If Not tempList.Contains(dt.Rows(inx).Item("Status")) Then
                        tempList.Add(dt.Rows(inx).Item("Status"), dt.Rows(inx).Item("Status"))
                        statusColors.Add(GetStatusColor(dt.Rows(inx).Item("Status")))
                    End If
                End If
            Next
            Dim tempHtmlCode As String = ""
            For inx As Integer = 0 To statusColors.Count - 1
                tempHtmlCode &= "<div class=""legend-item"">" & vbCrLf
                tempHtmlCode &= "<div style=""border: 3px solid rgb(" & statusColors.Item(inx).StrokeColorR & "," & statusColors.Item(inx).StrokeColorG & "," & statusColors.Item(inx).StrokeColorB & "); width: 40%; background-color: rgb(" & statusColors.Item(inx).FillColorR & "," & statusColors.Item(inx).FillColorG & "," & statusColors.Item(inx).FillColorB & ");""></div>"
                tempHtmlCode &= "<h6>" & statusColors.Item(inx).Status & "</h6>"
                tempHtmlCode &= "</div>"
            Next
            Return (tempHtmlCode)
        Catch ex As Exception

        End Try
        Return ""
    End Function
End Class
