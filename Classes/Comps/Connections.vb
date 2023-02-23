Public Class Connections
    Private er As New Errors

    Public Enum enConnectionType
        SQLSERVER = 1
        EXCEL = 2
    End Enum
    Structure stDBonnection
        Dim ID As Integer
        Dim ConnName As String
        Dim ConnType As String
        Dim URl As String
        Dim DBNmae As String
    End Structure

    Public Overloads Function GetConnections() As DataTable
        Try
            Return DBAcFS.ReturnDataTable("SELECT ID, conName AS [Connection Name],conType AS [Connection Type], server AS Server, dbName AS DBName FROM T_Conns")
        Catch ex As Exception
            er.RaiseInternalError(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Overloads Function GetConnections(ByVal id As Integer) As stDBonnection
        Try
            Dim dt As New DataTable
            dt = DBAcFS.ReturnDataTable("SELECT ID, conName AS [Connection Name],conType AS [Connection Type], server AS Server, dbName AS DBName FROM T_Conns WHERE ID =" & id)
            If dt.Rows.Count > 0 Then
                Dim tempConn As New stDBonnection
                tempConn.ID = id
                tempConn.ConnName = dt.Rows(0).Item("Connection Name")
                tempConn.ConnType = dt.Rows(0).Item("Connection Type")
                tempConn.URl = dt.Rows(0).Item("Server")
                tempConn.DBNmae = dt.Rows(0).Item("DBName")
                Return tempConn
            End If
            Return Nothing
        Catch ex As Exception
            er.RaiseInternalError(ex.Message)
        End Try
        Return Nothing
    End Function

    Public Function AddConnection(ByVal conName As String, ByVal conTypeName As enConnectionType, ByVal server As String, ByVal dbName As String) As Boolean
        Dim conType As String = ""
        Select Case conTypeName
            Case enConnectionType.EXCEL
                conType = "EXCEL"
            Case enConnectionType.SQLSERVER
                conType = "SQLSERVER"
        End Select
        Try
            If DBAcFS.ExcutResult("Select conName FROM T_Conns WHERE conName ='" & conName & "'") <> "" Then
                er.RaiseSetNameExists()
            Else
                DBAcFS.ExcuteNoneResult("INSERT INTO T_Conns (conName, conType, server, dbName) VALUES ('" & conName & "','" & conType & "','" & server & "','" & dbName & "')")
                Return True
            End If
        Catch ex As Exception
            er.RaiseInternalError(ex.Message)
            Return False
        End Try

        Return False
    End Function

End Class
