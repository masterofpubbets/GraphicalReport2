Module mMain
    Public DB As New EAMS.DataBaseTools.SQLServerTools
    Public DBTemp As New EAMS.DataBaseTools.SQLServerTools
    Public DBAccess As New EAMS.DataBaseTools.SQLServerTools
    Public DBAc As New EAMS.DataBaseTools.AccessDBTools
    Public DBAcFS As New EAMS.DataBaseTools.AccessDBTools
    Public ExFileType As String = "pdf"
    Public exDPI As Integer = 600

    Public Sub LoadSettings()
        DBAc.DataBaseLocation = GetSetting("TR", "GraphicalReport", "ColorTable", Application.StartupPath & "\CT.ctb")
        ExFileType = GetSetting("TR", "GraphicalReport", "ExFileType", "png")
        exDPI = GetSetting("TR", "GraphicalReport", "exDPI", 600)
    End Sub


    Public Sub DBConnect()
        'DB.DataBaseLocation = DBPath
        'DB.DataBaseName = DBName
        Try
            LoadSettings()
            DBAc.Connect()
            DBAcFS.DataBaseLocation = Application.StartupPath & "\FleSet.ctb"
            DBAcFS.Connect()
            If DB.DataBaseName <> "" Then DB.Connect()
        Catch ex As Exception
            MsgBox("Database Connection Failed")
        End Try
    End Sub
End Module
