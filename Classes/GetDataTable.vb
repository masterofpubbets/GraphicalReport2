Public Class GetDataTable
    Private er As New Errors

    Public Function GetDT(ByVal query As String, ByVal conType As String, ByVal url As String, ByVal dbName As String) As DataTable
        Dim dt As New DataTable
        Try

            Select Case conType
                Case "SQLSERVER"
                    DBTemp.DataBaseLocation = url
                    DBTemp.DataBaseName = dbName

                    DBTemp.Connect()
                    dt = DBTemp.ReturnDataTable(query)
                Case "EXCEL"
                    Dim ex As New EAMS.MSOffice.Excel
                    dt = ex.GetSheetData(url, query)
            End Select
            Return dt
        Catch ex As Exception
            er.RaiseInternalError(ex.Message)
            Return Nothing
        End Try
        Return Nothing
    End Function

End Class
