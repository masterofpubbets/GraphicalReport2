Public Class DrawingSets
    Private err As New Errors

    Public Structure st_Drawings
        Dim SetName As String
        Dim FolderPath As String
        Dim QueryPath As String
        Dim OutputFolderPath As String
        Dim HasPattern As Byte
        Dim TagHasDash As Byte
        Dim ConId As Integer
        Dim ReplaceTag As Byte
        Dim QuerySummaryFolderPath As String
        Dim Layout As String
        Dim PhotoFolderPath As String
        Dim Header As String
        Dim Header2 As String
        Dim Header3 As String
        Dim Subheader As String
        Dim CutoffDate As String
        Dim CutoffConId As String
        Dim ClientLogoPath As String
    End Structure

    Public Overloads Function GetData() As DataTable
        Dim dt As New DataTable
        Try
            dt = DBAcFS.ReturnDataTable("SELECT * FROM DrawingSets")
        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
        End Try
        Return dt
    End Function
    Public Function CheckExists(ByVal Name As String) As Boolean
        Try
            If DBAcFS.ExcutResult("SELECT Set_Name FROM T_DrawingTable WHERE Set_Name ='" & Name & "'") = "" Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
            Return True
        End Try
        Return True
    End Function

    Public Function Add(ByVal drawings As st_Drawings) As Boolean
        Try
            drawings.Header = Replace(drawings.Header, "'", "''",,, CompareMethod.Text)
            drawings.Header2 = Replace(drawings.Header2, "'", "''",,, CompareMethod.Text)
            drawings.Header3 = Replace(drawings.Header3, "'", "''",,, CompareMethod.Text)
            drawings.Subheader = Replace(drawings.Subheader, "'", "''",,, CompareMethod.Text)
            drawings.CutoffDate = Replace(drawings.CutoffDate, "'", "''",,, CompareMethod.Text)
            drawings.SetName = Replace(drawings.SetName, "'", "''",,, CompareMethod.Text)

            DBAcFS.ExcuteNoneResult("INSERT INTO T_DrawingTable (conId, Set_Name, Drawings_Path, Query_Path, Output_Path, Has_Pattern, Tag_Contains_Dash, ReplaceTag, Query_Summary_path, Layout_Template, Photo_Path, Header, Subheader, Cutoff_Date, cutoff_Date_ConId,Header2,Header3,ClientLogo) VALUES (" & drawings.ConId & ",'" & drawings.SetName & "','" & drawings.FolderPath & "','" & drawings.QueryPath & "','" & drawings.OutputFolderPath & "'," & drawings.HasPattern & "," & drawings.TagHasDash & "," & drawings.ReplaceTag & ",'" & drawings.QuerySummaryFolderPath & "','" & drawings.Layout & "','" & drawings.PhotoFolderPath & "','" & drawings.Header & "','" & drawings.Subheader & "','" & drawings.CutoffDate & "'," & drawings.CutoffConId & ",'" & drawings.Header2 & "','" & drawings.Header3 & "','" & drawings.ClientLogoPath & "')")
            Return True
        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
            Return False
        End Try
        Return False
    End Function

    Public Function Edit(ByVal drawings As st_Drawings, ByVal drawingSetId As Integer) As Boolean
        Try
            drawings.Header = Replace(drawings.Header, "'", "''",,, CompareMethod.Text)
            drawings.Header2 = Replace(drawings.Header2, "'", "''",,, CompareMethod.Text)
            drawings.Header3 = Replace(drawings.Header3, "'", "''",,, CompareMethod.Text)
            drawings.Subheader = Replace(drawings.Subheader, "'", "''",,, CompareMethod.Text)
            drawings.CutoffDate = Replace(drawings.CutoffDate, "'", "''",,, CompareMethod.Text)
            drawings.SetName = Replace(drawings.SetName, "'", "''",,, CompareMethod.Text)

            Dim sql As String = "UPDATE T_DrawingTable SET conId = " & drawings.ConId & ",Set_Name = '" & drawings.SetName & "', Drawings_Path = '" & drawings.FolderPath & "', Query_Path = '" & drawings.QueryPath & "', Output_Path ='" & drawings.OutputFolderPath & "', Has_Pattern = " & drawings.HasPattern & ", Tag_Contains_Dash = " & drawings.TagHasDash & ", ReplaceTag = " & drawings.ReplaceTag & ", Query_Summary_path ='" & drawings.QuerySummaryFolderPath & "', Layout_Template = '" & drawings.Layout & "', Photo_Path ='" & drawings.PhotoFolderPath & "', Header ='" & drawings.Header & "', Subheader ='" & drawings.Subheader & "', Cutoff_Date='" & drawings.CutoffDate & "', cutoff_Date_ConId =" & drawings.CutoffConId & ", Header2 = '" & drawings.Header2 & "', Header3 = '" & drawings.Header3 & "', ClientLogo='" & drawings.ClientLogoPath & "' WHERE ID =" & drawingSetId

            DBAcFS.ExcuteNoneResult(sql)

            Return True
        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
            Return False
        End Try
        Return False
    End Function

    Public Function Delete(ByVal drawingSetId As Integer) As Boolean
        Try
            DBAcFS.ExcuteNoneResult("DELETE FROM T_DrawingTable WHERE ID =" & drawingSetId)
        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
            Return False
        End Try
        Return False
    End Function

    Public Function GetFileName(ByVal filePath As String) As String
        Dim temp() As String = Split(filePath, "\")
        If temp.Length > 0 Then
            Return (temp(temp.Length - 1))
        End If
        Return ""
    End Function

End Class
