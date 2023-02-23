Public Class svgGroups
    Private _GroupID As New ListBox
    Private _GroupName As New ListBox


#Region "Properties"
    Public Property GroupID(ByVal Index As Integer) As String
        Get
            Return _GroupID.Items.Item(Index)
        End Get
        Set(value As String)
            _GroupID.Items.Item(Index) = value
        End Set
    End Property
    Public Property GroupName(ByVal Index As Integer) As String
        Get
            Return _GroupName.Items.Item(Index)
        End Get
        Set(value As String)
            _GroupName.Items.Item(Index) = value
        End Set
    End Property
    Public ReadOnly Property Count As Integer
        Get
            Return _GroupID.Items.Count
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub Add(ByVal GroupID As String, ByVal GroupName As String)
        Try
            _GroupID.Items.Add(GroupID)
            _GroupName.Items.Add(GroupName)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Clear()
        _GroupID.Items.Clear()
        _GroupName.Items.Clear()
    End Sub
    Public Function GetGroupName(ByVal GroupID As String) As String
        Dim inx As Integer = -1
        inx = _GroupID.FindStringExact(GroupID)
        If inx <> -1 Then
            Return _GroupName.Items.Item(inx)
        End If
        Return ""
    End Function
#End Region

   
End Class
