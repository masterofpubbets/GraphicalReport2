Public Class Errors

    Public Shared Event InternalError(ByVal err As String)
    Public Shared Event SetNameExists()

    Public Sub RaiseInternalError(ByVal err As String)
        RaiseEvent InternalError(err)
    End Sub
    Public Sub RaiseSetNameExists()
        RaiseEvent SetNameExists()
    End Sub

End Class
