Public Class GenerateHtmlHeader

    Public Function GenerateHeader(ByVal header As String, ByVal drawingPath As String) As String
        Dim temp() As String = Split(drawingPath, "\")
        Dim drawingName As String = Replace(temp(temp.Length - 1), ".svg", "",,, CompareMethod.Text)

        If Len(header) > 6 Then
            If header = "$(NAME)" Then
                Return (drawingName)
            ElseIf InStr(Len(header) - 6, header, "$(NAME)", CompareMethod.Text) Then
                Return (Trim(header) & " " & Trim(drawingName))
            ElseIf InStr(1, header, "$(NAME)", CompareMethod.Text) And header.Chars(0) = "$" Then
                Return (Trim(drawingName) & " " & Trim(header))
            Else
                Return (Trim(header))
            End If
        Else
            Return (Trim(header))
        End If


        Return ""
    End Function

End Class
