Public Class frmMain
    Public Disconnected As Boolean = False


    Private Sub HandleInternalError(Optional ByVal er As String = "")
        toast.ShowNotification("9041175f-9be8-48df-a7be-2b13669089c7")
    End Sub
    Private Sub HandleConnNameExists(Optional ByVal er As String = "")
        toast.ShowNotification("496d9272-6864-4da7-afea-7579313a6389")
    End Sub
    Private Sub FolderCheck()
        If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\tmp") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\tmp")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\tmpUpdated") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\tmpUpdated")
        End If
    End Sub

    Private Sub ErrorHandler(ByVal msg As String)
        If (DB.DBStatus = ConnectionState.Broken) Or (DB.DBStatus = ConnectionState.Closed) Then
            Disconnected = True
        End If
        MsgBox(msg, MsgBoxStyle.Critical, Me.Text)
    End Sub
    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Shell(Application.StartupPath & "\bin\libs\InkscapePortable.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Shell(Application.StartupPath & "\bin\libs\\npdf\Nitro Pro.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Shell(Application.StartupPath & "\bin\libs\Caesium\CaesiumPortable.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler DB.err, AddressOf ErrorHandler
        AddHandler Errors.InternalError, AddressOf HandleInternalError
        AddHandler DBAcFS.err, AddressOf HandleInternalError
        AddHandler Errors.SetNameExists, AddressOf HandleConnNameExists
        FolderCheck()
        DBConnect()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Try
            opnFle2.FileName = ""
            opnFle2.ShowDialog()
            If opnFle2.FileName = "" Then Exit Sub
            DBAc.Close()
            SaveSetting("TR", "GraphicalReport", "ColorTable", opnFle2.FileName)
            DBAc.DataBaseLocation = GetSetting("TR", "GraphicalReport", "ColorTable", Application.StartupPath & "\CT.ctb")
            DBAc.Connect()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim frm As New frmStatus
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim frm As New frmSets
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick

    End Sub
End Class
