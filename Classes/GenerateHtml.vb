Public Class GenerateHtml
    Private htmlTable As New GenerateHtmlTable
    Private htmlHeader As New GenerateHtmlHeader
    Private htmlCutoff As New GenerateCutoffDate
    Private err As New Errors
    Private exports As New GeneratePdf

    Private Function GetDrawingName(ByVal drawingPath As String) As String
        Dim temp() As String = Split(drawingPath, "\")
        Dim drawingName As String = Replace(temp(temp.Length - 1), ".svg", "",,, CompareMethod.Text)
        Return drawingName
    End Function
    Private Function CreateCssFolder(ByVal outputFolder As String) As Boolean
        Try
            If Not IO.Directory.Exists(outputFolder & "\css") Then
                IO.Directory.CreateDirectory(outputFolder & "\css")
            Else
                Dim Ficss As String() = IO.Directory.GetFileSystemEntries(outputFolder & "\css", "*.css", IO.SearchOption.TopDirectoryOnly)
                For Each el As String In Ficss
                    IO.File.Delete(el)
                Next
            End If

            Dim Fi As String() = IO.Directory.GetFileSystemEntries(Application.StartupPath & "\WebTemplate\css", "*.css", IO.SearchOption.TopDirectoryOnly)
            For Each el As String In Fi
                IO.File.Copy(el, outputFolder & "\css\" & GetDrawingName(el))
            Next
            Return True
        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Private Function CreateImgFolder(ByVal outputFolder As String, ByVal photosPath As String, ByVal clientLogoPath As String) As Boolean
        Try
            If Not IO.Directory.Exists(outputFolder & "\img") Then
                IO.Directory.CreateDirectory(outputFolder & "\css")
            Else
                Dim Ficss As String() = IO.Directory.GetFileSystemEntries(outputFolder & "\img", "*.jpg", IO.SearchOption.TopDirectoryOnly)
                For Each el As String In Ficss
                    IO.File.Delete(el)
                Next
                Dim FicsIcon As String() = IO.Directory.GetFileSystemEntries(outputFolder & "\img", "*.ico", IO.SearchOption.TopDirectoryOnly)
                For Each el As String In FicsIcon
                    IO.File.Delete(el)
                Next
                Dim FicssPNG As String() = IO.Directory.GetFileSystemEntries(outputFolder & "\img", "*.png", IO.SearchOption.TopDirectoryOnly)
                For Each el As String In FicssPNG
                    IO.File.Delete(el)
                Next
            End If

            IO.File.Copy(Application.StartupPath & "\templates\icon.ico", outputFolder & "\img\icon.ico")
            IO.File.Copy(Application.StartupPath & "\templates\tr.jpg", outputFolder & "\img\tr.jpg")
            If clientLogoPath <> "" Then
                IO.File.Copy(clientLogoPath, outputFolder & "\img\" & GetDrawingName(clientLogoPath))
            End If

            Dim Fi As String() = IO.Directory.GetFileSystemEntries(photosPath, "*.jpg", IO.SearchOption.TopDirectoryOnly)
            For Each el As String In Fi
                IO.File.Copy(el, outputFolder & "\img\" & GetDrawingName(el))
            Next
            Return True
        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Sub GenerateHTMLReport(ByVal mainQueryPath As String, ByVal summaryQuryPath As String, ByVal conType As String, ByVal dbName As String, ByVal url As String, ByVal drawingPath As String, ByVal layoutTemplate As String, ByVal photosPath As String, ByVal header As String, ByVal subheader As String, ByVal cutoffConType As String, ByVal cutoffConDBName As String, ByVal cutoffConURL As String, ByVal cutoffDate As String, ByVal outputFolder As String, ByVal clientLogoPath As String, ByVal header2 As String, ByVal header3 As String)

        Dim summariesTable(3) As String
        Dim hdr As String = htmlHeader.GenerateHeader(header, drawingPath)
        Dim subHdr As String = htmlHeader.GenerateHeader(subheader, drawingPath)
        Dim cutoff As String = htmlCutoff.GenerateCutoffDate(cutoffConType, cutoffConDBName, cutoffConURL, cutoffDate)
        summariesTable = htmlTable.GenerateSummariesHtmlTable(layoutTemplate, summaryQuryPath, drawingPath, conType, dbName, url)

        If CreateCssFolder(outputFolder) Then
            If CreateImgFolder(outputFolder, photosPath, clientLogoPath) Then
                Select Case layoutTemplate
                    Case "Default"
                        MakeLayoutDefault(GetDrawingName(drawingPath), hdr, subHdr, cutoff, summariesTable, outputFolder, header2, header3)
                    Case "Layout2"
                        MakeLayout2(GetDrawingName(drawingPath), hdr, subHdr, cutoff, summariesTable, outputFolder, header2, header3)
                    Case "Layout3"
                        MakeLayout3(GetDrawingName(drawingPath), hdr, subHdr, cutoff, summariesTable, outputFolder, header2, header3)
                    Case "Layout4"
                        MakeLayout4(GetDrawingName(drawingPath), hdr, subHdr, cutoff, summariesTable, outputFolder, header2, header3)
                    Case "Layout5"
                        MakeLayout5(GetDrawingName(drawingPath), hdr, subHdr, cutoff, summariesTable, outputFolder, header2, header3)
                    Case "Layout6"
                        MakeLayout6(GetDrawingName(drawingPath), hdr, subHdr, cutoff, summariesTable, outputFolder, header2, header3)
                    Case "Layout7"
                        MakeLayout7(GetDrawingName(drawingPath), hdr, subHdr, cutoff, summariesTable, outputFolder, header2, header3)
                    Case "Layout8"
                        MakeLayout8(GetDrawingName(drawingPath), hdr, subHdr, cutoff, summariesTable, outputFolder, header2, header3)
                    Case "Layout9"
                        MakeLayout9(GetDrawingName(drawingPath), hdr, subHdr, cutoff, summariesTable, outputFolder, header2, header3, "tr.jpg", GetDrawingName(clientLogoPath))
                    Case "Layout10"
                        Dim htmlLegend As New GenerateHtmlLegend
                        Dim legend As String = htmlLegend.GetLegend(mainQueryPath, dbName, url, conType)
                        MakeLayout10(GetDrawingName(drawingPath), hdr, subHdr, cutoff, summariesTable, outputFolder, header2, header3, "tr.jpg", GetDrawingName(clientLogoPath), legend)
                End Select
            End If
        End If



    End Sub


    Private Function MakeLayoutDefault(ByVal drawingName As String, ByVal header As String, ByVal subheader As String, ByVal cutoffDate As String, ByVal summaryTable() As String, ByVal outputFolder As String, ByVal header2 As String, ByVal header3 As String) As Boolean
        Dim html As String = "<html lang=""en"">" & vbCrLf
        Try

            html &= "<head>" & vbCrLf
            html &= "<meta charset=""UTF-8"">" & vbCrLf
            html &= "<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">" & vbCrLf
            html &= "<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">" & vbCrLf
            html &= "<title>Graphical Report</title>" & vbCrLf
            html &= "<link rel=""icon"" href=""./img/icon.ico"" />" & vbCrLf
            html &= "<link rel=""preconnect"" href=""https//fonts.gstatic.com"">" & vbCrLf
            html &= "<link rel=""stylesheet"" href=""./css/Default.css"">" & vbCrLf
            html &= "<link rel = ""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"">" & vbCrLf
            html &= "<script src = ""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"" ></script>" & vbCrLf
            html &= "</head>" & vbCrLf

            html &= "<body>" & vbCrLf

            html &= "<div Class=""mainPage"">" & vbCrLf

            html &= "<div Class=""header"">" & vbCrLf
            html &= "<h6>" & header & "</h6>" & vbCrLf
            html &= "<h6>" & header2 & "</h6>" & vbCrLf
            html &= "<h6>" & header3 & "</h6>" & vbCrLf
            html &= "<h6>" & cutoffDate & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""header-footer"">" & vbCrLf
            html &= "<h6>" & subheader & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""content"">" & vbCrLf
            html &= "<img src = ""./" & drawingName & ".png"" alt=""content"">" & vbCrLf
            html &= "</div>" & vbCrLf
            html &= "<div Class=""summary"">" & vbCrLf
            html &= summaryTable(0) & vbCrLf
            html &= "</div>" & vbCrLf
            html &= "</div>" & vbCrLf
            html &= "</body>" & vbCrLf
            html &= "</html>" & vbCrLf

            IO.File.WriteAllText(outputFolder & "\" & drawingName & ".html", html, System.Text.Encoding.UTF8)

            Return True

        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
        End Try
        Return False
    End Function

    Private Function MakeLayout2(ByVal drawingName As String, ByVal header As String, ByVal subheader As String, ByVal cutoffDate As String, ByVal summaryTable() As String, ByVal outputFolder As String, ByVal header2 As String, ByVal header3 As String) As Boolean
        Dim html As String = "<html lang=""en"">" & vbCrLf

        Try

            html &= "<head>" & vbCrLf
            html &= "<meta charset=""UTF-8"">" & vbCrLf
            html &= "<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">" & vbCrLf
            html &= "<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">" & vbCrLf
            html &= "<title>Graphical Report</title>" & vbCrLf
            html &= "<link rel=""icon"" href=""./img/icon.ico"" />" & vbCrLf
            html &= "<link rel=""preconnect"" href=""https//fonts.gstatic.com"">" & vbCrLf
            html &= "<link rel=""stylesheet"" href=""./css/Layout2.css"">" & vbCrLf
            html &= "<link rel = ""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"">" & vbCrLf
            html &= "<script src = ""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"" ></script>" & vbCrLf
            html &= "</head>" & vbCrLf

            html &= "<body>" & vbCrLf

            html &= "<div Class=""mainPage"">" & vbCrLf

            html &= "<div Class=""header"">" & vbCrLf
            html &= "<h6>" & header & "</h6>" & vbCrLf
            html &= "<h6>" & header2 & "</h6>" & vbCrLf
            html &= "<h6>" & header3 & "</h6>" & vbCrLf
            html &= "<h6>" & cutoffDate & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""header-footer"">" & vbCrLf
            html &= "<h6>" & subheader & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""content"">" & vbCrLf
            html &= "<img src = ""./" & drawingName & ".png"" alt=""content"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary1"">" & vbCrLf
            html &= summaryTable(0) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary2"">" & vbCrLf
            html &= summaryTable(1) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "</div>" & vbCrLf
            html &= "</body>" & vbCrLf
            html &= "</html>" & vbCrLf

            IO.File.WriteAllText(outputFolder & "\" & drawingName & ".html", html, System.Text.Encoding.UTF8)

            Return True

        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
        End Try
        Return False
    End Function

    Private Function MakeLayout3(ByVal drawingName As String, ByVal header As String, ByVal subheader As String, ByVal cutoffDate As String, ByVal summaryTable() As String, ByVal outputFolder As String, ByVal header2 As String, ByVal header3 As String) As Boolean
        Dim html As String = "<html lang=""en"">" & vbCrLf

        Try
            html &= "<head>" & vbCrLf
            html &= "<meta charset=""UTF-8"">" & vbCrLf
            html &= "<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">" & vbCrLf
            html &= "<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">" & vbCrLf
            html &= "<title>Graphical Report</title>" & vbCrLf
            html &= "<link rel=""icon"" href=""./img/icon.ico"" />" & vbCrLf
            html &= "<link rel=""preconnect"" href=""https//fonts.gstatic.com"">" & vbCrLf
            html &= "<link rel=""stylesheet"" href=""./css/Layout3.css"">" & vbCrLf
            html &= "<link rel = ""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"">" & vbCrLf
            html &= "<script src = ""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"" ></script>" & vbCrLf
            html &= "</head>" & vbCrLf

            html &= "<body>" & vbCrLf


            html &= "<div Class=""mainPage"">" & vbCrLf

            html &= "<div Class=""header"">" & vbCrLf
            html &= "<h6>" & header & "</h6>" & vbCrLf
            html &= "<h6>" & header2 & "</h6>" & vbCrLf
            html &= "<h6>" & header3 & "</h6>" & vbCrLf
            html &= "<h6>" & cutoffDate & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""header-footer"">" & vbCrLf
            html &= "<h6>" & subheader & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""content"">" & vbCrLf
            html &= "<img src = ""./" & drawingName & ".png"" alt=""content"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""photo1"">" & vbCrLf
            html &= "<img src=""./img/" & drawingName & "1.jpg"" alt=""photo1"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary"">" & vbCrLf
            html &= summaryTable(0) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "</div>" & vbCrLf
            html &= "</body>" & vbCrLf
            html &= "</html>" & vbCrLf

            IO.File.WriteAllText(outputFolder & "\" & drawingName & ".html", html, System.Text.Encoding.UTF8)

            Return True

        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
        End Try
        Return False
    End Function

    Private Function MakeLayout4(ByVal drawingName As String, ByVal header As String, ByVal subheader As String, ByVal cutoffDate As String, ByVal summaryTable() As String, ByVal outputFolder As String, ByVal header2 As String, ByVal header3 As String) As Boolean
        Dim html As String = "<html lang=""en"">" & vbCrLf

        Try

            html &= "<head>" & vbCrLf
            html &= "<meta charset=""UTF-8"">" & vbCrLf
            html &= "<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">" & vbCrLf
            html &= "<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">" & vbCrLf
            html &= "<title>Graphical Report</title>" & vbCrLf
            html &= "<link rel=""icon"" href=""./img/icon.ico"" />" & vbCrLf
            html &= "<link rel=""preconnect"" href=""https//fonts.gstatic.com"">" & vbCrLf
            html &= "<link rel=""stylesheet"" href=""./css/Layout4.css"">" & vbCrLf
            html &= "<link rel = ""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"">" & vbCrLf
            html &= "<script src = ""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"" ></script>" & vbCrLf
            html &= "</head>" & vbCrLf

            html &= "<body>" & vbCrLf

            html &= "<div Class=""mainPage"">" & vbCrLf

            html &= "<div Class=""header"">" & vbCrLf
            html &= "<h6>" & header & "</h6>" & vbCrLf
            html &= "<h6>" & header2 & "</h6>" & vbCrLf
            html &= "<h6>" & header3 & "</h6>" & vbCrLf
            html &= "<h6>" & cutoffDate & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""header-footer"">" & vbCrLf
            html &= "<h6>" & subheader & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf


            html &= "<div Class=""content"">" & vbCrLf
            html &= "<img src = ""./" & drawingName & ".png"" alt=""content"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary1"">" & vbCrLf
            html &= summaryTable(0) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary2"">" & vbCrLf
            html &= summaryTable(1) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary3"">" & vbCrLf
            html &= summaryTable(2) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary4"">" & vbCrLf
            html &= summaryTable(3) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "</div>" & vbCrLf
            html &= "</body>" & vbCrLf
            html &= "</html>" & vbCrLf

            IO.File.WriteAllText(outputFolder & "\" & drawingName & ".html", html, System.Text.Encoding.UTF8)

            Return True

        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
        End Try
        Return False
    End Function

    Private Function MakeLayout5(ByVal drawingName As String, ByVal header As String, ByVal subheader As String, ByVal cutoffDate As String, ByVal summaryTable() As String, ByVal outputFolder As String, ByVal header2 As String, ByVal header3 As String) As Boolean
        Dim html As String = "<html lang=""en"">" & vbCrLf

        Try
            html &= "<head>" & vbCrLf
            html &= "<meta charset=""UTF-8"">" & vbCrLf
            html &= "<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">" & vbCrLf
            html &= "<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">" & vbCrLf
            html &= "<title>Graphical Report</title>" & vbCrLf
            html &= "<link rel=""icon"" href=""./img/icon.ico"" />" & vbCrLf
            html &= "<link rel=""preconnect"" href=""https//fonts.gstatic.com"">" & vbCrLf
            html &= "<link rel=""stylesheet"" href=""./css/Layout5.css"">" & vbCrLf
            html &= "<link rel = ""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"">" & vbCrLf
            html &= "<script src = ""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"" ></script>" & vbCrLf
            html &= "</head>" & vbCrLf

            html &= "<body>" & vbCrLf

            html &= "<div Class=""mainPage"">" & vbCrLf

            html &= "<div Class=""header"">" & vbCrLf
            html &= "<h6>" & header & "</h6>" & vbCrLf
            html &= "<h6>" & header2 & "</h6>" & vbCrLf
            html &= "<h6>" & header3 & "</h6>" & vbCrLf
            html &= "<h6>" & cutoffDate & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""header-footer"">" & vbCrLf
            html &= "<h6>" & subheader & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""content"">" & vbCrLf
            html &= "<img src = ""./" & drawingName & ".png"" alt=""content"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""photo1"">" & vbCrLf
            html &= "<img src=""./img/" & drawingName & "1.jpg"" alt=""photo1"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary1"">" & vbCrLf
            html &= summaryTable(0) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""photo2"">" & vbCrLf
            html &= "<img src=""./img/" & drawingName & "2.jpg"" alt=""photo2"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary2"">" & vbCrLf
            html &= summaryTable(1) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "</div>" & vbCrLf
            html &= "</body>" & vbCrLf
            html &= "</html>" & vbCrLf

            IO.File.WriteAllText(outputFolder & "\" & drawingName & ".html", html, System.Text.Encoding.UTF8)

            Return True

        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
        End Try
        Return False
    End Function

    Private Function MakeLayout6(ByVal drawingName As String, ByVal header As String, ByVal subheader As String, ByVal cutoffDate As String, ByVal summaryTable() As String, ByVal outputFolder As String, ByVal header2 As String, ByVal header3 As String) As Boolean
        Dim html As String = "<html lang=""en"">" & vbCrLf

        Try
            html &= "<head>" & vbCrLf
            html &= "<meta charset=""UTF-8"">" & vbCrLf
            html &= "<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">" & vbCrLf
            html &= "<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">" & vbCrLf
            html &= "<title>Graphical Report</title>" & vbCrLf
            html &= "<link rel=""icon"" href=""./img/icon.ico"" />" & vbCrLf
            html &= "<link rel=""preconnect"" href=""https//fonts.gstatic.com"">" & vbCrLf
            html &= "<link rel=""stylesheet"" href=""./css/Layout6.css"">" & vbCrLf
            html &= "<link rel = ""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"">" & vbCrLf
            html &= "<script src = ""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"" ></script>" & vbCrLf
            html &= "</head>" & vbCrLf

            html &= "<body>" & vbCrLf

            html &= "<div Class=""mainPage"">" & vbCrLf

            html &= "<div Class=""header"">" & vbCrLf
            html &= "<h6>" & header & "</h6>" & vbCrLf
            html &= "<h6>" & header2 & "</h6>" & vbCrLf
            html &= "<h6>" & header3 & "</h6>" & vbCrLf
            html &= "<h6>" & cutoffDate & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""header-footer"">" & vbCrLf
            html &= "<h6>" & subheader & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""content"">" & vbCrLf
            html &= "<img src = ""./" & drawingName & ".png"" alt=""content"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""photo1"">" & vbCrLf
            html &= "<img src=""./img/" & drawingName & "1.jpg"" alt=""photo1"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""photo2"">" & vbCrLf
            html &= "<img src=""./img/" & drawingName & "2.jpg"" alt=""photo2"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary1"">" & vbCrLf
            html &= summaryTable(0) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "</div>" & vbCrLf
            html &= "</body>" & vbCrLf
            html &= "</html>" & vbCrLf

            IO.File.WriteAllText(outputFolder & "\" & drawingName & ".html", html, System.Text.Encoding.UTF8)

            Return True

        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
        End Try
        Return False
    End Function

    Private Function MakeLayout7(ByVal drawingName As String, ByVal header As String, ByVal subheader As String, ByVal cutoffDate As String, ByVal summaryTable() As String, ByVal outputFolder As String, ByVal header2 As String, ByVal header3 As String) As Boolean
        Dim html As String = "<html lang=""en"">" & vbCrLf
        Try

            html &= "<head>" & vbCrLf
            html &= "<meta charset=""UTF-8"">" & vbCrLf
            html &= "<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">" & vbCrLf
            html &= "<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">" & vbCrLf
            html &= "<title>Graphical Report</title>" & vbCrLf
            html &= "<link rel=""icon"" href=""./img/icon.ico"" />" & vbCrLf
            html &= "<link rel=""preconnect"" href=""https//fonts.gstatic.com"">" & vbCrLf
            html &= "<link rel=""stylesheet"" href=""./css/Layout7.css"">" & vbCrLf
            html &= "<link rel = ""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"">" & vbCrLf
            html &= "<script src = ""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"" ></script>" & vbCrLf
            html &= "</head>" & vbCrLf
            html &= "<body>" & vbCrLf

            html &= "<div Class=""mainPage"">" & vbCrLf


            html &= "<div Class=""header"">" & vbCrLf
            html &= "<h6>" & header & "</h6>" & vbCrLf
            html &= "<h6>" & header2 & "</h6>" & vbCrLf
            html &= "<h6>" & header3 & "</h6>" & vbCrLf
            html &= "<h6>" & cutoffDate & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""header-footer"">" & vbCrLf
            html &= "<h6>" & subheader & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""content"">" & vbCrLf
            html &= "<img src = ""./" & drawingName & ".png"" alt=""content"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary"">" & vbCrLf
            html &= summaryTable(0) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "</div>" & vbCrLf
            html &= "</body>" & vbCrLf
            html &= "</html>" & vbCrLf

            IO.File.WriteAllText(outputFolder & "\" & drawingName & ".html", html, System.Text.Encoding.UTF8)

            Return True

        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
        End Try
        Return False
    End Function

    Private Function MakeLayout8(ByVal drawingName As String, ByVal header As String, ByVal subheader As String, ByVal cutoffDate As String, ByVal summaryTable() As String, ByVal outputFolder As String, ByVal header2 As String, ByVal header3 As String) As Boolean
        Dim html As String = "<html lang=""en"">" & vbCrLf

        Try

            html &= "<head>" & vbCrLf
            html &= "<meta charset=""UTF-8"">" & vbCrLf
            html &= "<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">" & vbCrLf
            html &= "<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">" & vbCrLf
            html &= "<title>Graphical Report</title>" & vbCrLf
            html &= "<link rel=""icon"" href=""./img/icon.ico"" />" & vbCrLf
            html &= "<link rel=""preconnect"" href=""https//fonts.gstatic.com"">" & vbCrLf
            html &= "<link rel=""stylesheet"" href=""./css/Layout8.css"">" & vbCrLf
            html &= "<link rel = ""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"">" & vbCrLf
            html &= "<script src = ""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"" ></script>" & vbCrLf
            html &= "</head>" & vbCrLf
            html &= "<body>" & vbCrLf

            html &= "<div Class=""mainPage"">" & vbCrLf

            html &= "<div Class=""header"">" & vbCrLf
            html &= "<h6>" & header & "</h6>" & vbCrLf
            html &= "<h6>" & header2 & "</h6>" & vbCrLf
            html &= "<h6>" & header3 & "</h6>" & vbCrLf
            html &= "<h6>" & cutoffDate & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""header-footer"">" & vbCrLf
            html &= "<h6>" & subheader & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""content"">" & vbCrLf
            html &= "<img src = ""./" & drawingName & ".png"" alt=""content"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary1"">" & vbCrLf
            html &= summaryTable(0) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""summary2"">" & vbCrLf
            html &= summaryTable(1) & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "</div>" & vbCrLf

            html &= "</body>" & vbCrLf
            html &= "</html>" & vbCrLf

            IO.File.WriteAllText(outputFolder & "\" & drawingName & ".html", html, System.Text.Encoding.UTF8)

            Return True

        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
        End Try
        Return False
    End Function
    Private Function MakeLayout9(ByVal drawingName As String, ByVal header As String, ByVal subheader As String, ByVal cutoffDate As String, ByVal summaryTable() As String, ByVal outputFolder As String, ByVal header2 As String, ByVal header3 As String, ByVal trLogoPath As String, ByVal clientLogoPath As String) As Boolean
        Dim html As String = "<html lang=""en"">" & vbCrLf

        Try

            html &= "<head>" & vbCrLf
            html &= "<meta charset=""UTF-8"">" & vbCrLf
            html &= "<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">" & vbCrLf
            html &= "<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">" & vbCrLf
            html &= "<title>Graphical Report</title>" & vbCrLf
            html &= "<link rel=""icon"" href=""./img/icon.ico"" />" & vbCrLf
            html &= "<link rel=""preconnect"" href=""https//fonts.gstatic.com"">" & vbCrLf
            html &= "<link rel=""stylesheet"" href=""./css/Layout9.css"">" & vbCrLf
            html &= "<link rel = ""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"">" & vbCrLf
            html &= "<script src = ""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"" ></script>" & vbCrLf
            html &= "</head>" & vbCrLf
            html &= "<body>" & vbCrLf

            html &= "<div Class=""mainPage"">" & vbCrLf

            html &= "<div Class=""tr-logo"">" & vbCrLf
            html &= "<img src = ""./img/" & trLogoPath & """ alt=""TR Logo"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""header"">" & vbCrLf
            html &= "<h6>" & header & "</h6>" & vbCrLf
            html &= "<h6>" & header2 & "</h6>" & vbCrLf
            html &= "<h6>" & header3 & "</h6>" & vbCrLf
            html &= "<h6>" & cutoffDate & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""client-logo"">" & vbCrLf
            html &= "<img src = ""./img/" & clientLogoPath & """ alt=""Client Logo"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""header-footer"">" & vbCrLf
            html &= "<h6>" & subheader & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""content"">" & vbCrLf
            html &= "<img src = ""./" & drawingName & ".png"" alt=""content"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "</div>" & vbCrLf

            html &= "</body>" & vbCrLf
            html &= "</html>" & vbCrLf

            IO.File.WriteAllText(outputFolder & "\" & drawingName & ".html", html, System.Text.Encoding.UTF8)

            Return True

        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
        End Try
        Return False
    End Function
    Private Function MakeLayout10(ByVal drawingName As String, ByVal header As String, ByVal subheader As String, ByVal cutoffDate As String, ByVal summaryTable() As String, ByVal outputFolder As String, ByVal header2 As String, ByVal header3 As String, ByVal trLogoPath As String, ByVal clientLogoPath As String, ByVal legend As String) As Boolean
        Dim html As String = "<html lang=""en"">" & vbCrLf

        Try

            html &= "<head>" & vbCrLf
            html &= "<meta charset=""UTF-8"">" & vbCrLf
            html &= "<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">" & vbCrLf
            html &= "<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">" & vbCrLf
            html &= "<title>Graphical Report</title>" & vbCrLf
            html &= "<link rel=""icon"" href=""./img/icon.ico"" />" & vbCrLf
            html &= "<link rel=""preconnect"" href=""https//fonts.gstatic.com"">" & vbCrLf
            html &= "<link rel=""stylesheet"" href=""./css/Layout10.css"">" & vbCrLf
            html &= "<link rel = ""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"">" & vbCrLf
            html &= "<script src = ""https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"" ></script>" & vbCrLf
            html &= "</head>" & vbCrLf
            html &= "<body>" & vbCrLf

            html &= "<div Class=""mainPage"">" & vbCrLf

            html &= "<div Class=""header"">" & vbCrLf

            html &= "<div Class=""tr-logo"">" & vbCrLf
            html &= "<img src = ""./img/" & trLogoPath & """ alt=""TR Logo"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""titles"">" & vbCrLf
            html &= "<h6>" & header & "</h6>" & vbCrLf
            html &= "<h6>" & header2 & "</h6>" & vbCrLf
            html &= "<h6>" & header3 & "</h6>" & vbCrLf
            html &= "<h6>" & cutoffDate & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""client-logo"">" & vbCrLf
            html &= "<img src = ""./img/" & clientLogoPath & """ alt=""Client Logo"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "</div>" & vbCrLf

            html &= "<div Class=""header-footer"">" & vbCrLf
            html &= "<h6>" & subheader & "</h6>" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""content"">" & vbCrLf

            html &= "<div Class=""summary-img"">" & vbCrLf
            html &= "<img src=""./img/" & drawingName & "1.jpg"" alt=""photo1"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""main-img"">" & vbCrLf
            html &= "<img src=""./" & drawingName & ".png"" alt=""main"">" & vbCrLf
            html &= "</div>" & vbCrLf

            html &= "<div Class=""legend"">" & vbCrLf
            html &= legend
            html &= "</div>" & vbCrLf

            html &= "</div>" & vbCrLf

            html &= "</div>" & vbCrLf

            html &= "</body>" & vbCrLf
            html &= "</html>" & vbCrLf

            IO.File.WriteAllText(outputFolder & "\" & drawingName & ".html", html, System.Text.Encoding.UTF8)

            Return True

        Catch ex As Exception
            err.RaiseInternalError(ex.Message)
        End Try
        Return False
    End Function
End Class
