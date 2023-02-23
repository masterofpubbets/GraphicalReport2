Public Class GenerateCutoffDate
    Private tempSQLDB As New EAMS.DataBaseTools.SQLServerTools

    Public Function GenerateCutoffDate(ByVal cutoffConType As String, ByVal cutoffConDBName As String, ByVal cutoffConURL As String, ByVal cutoffDate As String) As String
        Select Case cutoffDate
            Case "$(PRINTDATE)"
                Return (Format(Now, "dddd dd-MMMM-yyyy"))
            Case "$(NONE)"
                Return ""
            Case Else
                Select Case cutoffConType
                    Case "SQLSERVER"
                        tempSQLDB.DataBaseName = cutoffConDBName
                        tempSQLDB.DataBaseLocation = cutoffConURL
                        tempSQLDB.Connect()
                        If tempSQLDB.DBStatus = ConnectionState.Open Then
                            Return (tempSQLDB.ExcutResult(cutoffDate))
                        End If
                    Case "EXCEL"
                End Select
        End Select



        Return ""
    End Function
End Class
