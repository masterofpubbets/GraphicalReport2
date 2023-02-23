Imports System.IO
Imports Syncfusion.HtmlConverter
Imports Syncfusion.Pdf

Public Class GeneratePdf
    Private convert As New HtmlToPdfConverter
    Private doc As New PdfDocument
    Public Shared Event Saved(ByVal fName As String)
    Private fildeName As String = ""

    Public Sub New()
        AddHandler doc.SaveProgress, AddressOf handleSaved
    End Sub

    Private Sub handleSaved()
        RaiseEvent Saved(fildeName)
    End Sub
    Public Sub GeneratePdf(ByVal folder As String)

        ' Load a DOCX document.
        Dim Ficss As String() = IO.Directory.GetFileSystemEntries(folder, "*.html", IO.SearchOption.TopDirectoryOnly)
        For Each el As String In Ficss
            Export(el, folder)
        Next

    End Sub
    Private Function GetDrawingName(ByVal drawingPath As String) As String
        Dim temp() As String = Split(drawingPath, "\")
        Dim drawingName As String = Replace(temp(temp.Length - 1), ".html", "",,, CompareMethod.Text)
        Return drawingName
    End Function

    Private Sub Export(ByVal filename As String, ByVal folder As String)
        Try
            fildeName = GetDrawingName(filename)
            doc = Convert.Convert(filename)
            doc.PageSettings.Size = PdfPageSize.A3
            doc.PageSettings.Orientation = PdfPageOrientation.Landscape
            Dim fs As IO.FileStream = New IO.FileStream(folder & "\" & fildeName & ".pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite)
            doc.Save(fs)
            doc.Close()
        Catch ex As Exception

        End Try

    End Sub
End Class
