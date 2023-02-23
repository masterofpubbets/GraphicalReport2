Public Class GraphicalReport
    Const _StartGroup = "<g"
    Const _EndGroup = "</g>"
    Const _TextName = "</text>"
    Const _TextName2 = "</tspan>"
    Const _TextName3 = "<tspan"
    Const _TextName4 = "</flowPara>"
    Public Event Finished()
    Public Event EditFinished()
    Public Event Err(ByVal msg As String)
    Private st As New EAMS.StringFunctions.StringsFunction
    Public DPI As Integer = 600
    Public InkScapePath As String = String.Format("{0}{1}\Bin\Libs\App\Inkscape\inkscape.exe{2}", Chr(34), Application.StartupPath, Chr(34))
    Const coma = Chr(34)
    Private lstIDs As New ListBox
    Private lstTag As New ListBox
    Private lstLayersID As New ListBox
    Private lstLayersTag As New ListBox
    Public TagContainsDash As Boolean = True


    Public Enum e_exportfiletype
        pdf = 1
        png = 2
    End Enum

    Private Function CountCharacter(ByVal value As String, ByVal ch As Char) As Integer
        Return value.Count(Function(c As Char) c = ch)
    End Function

    Private Function HexaValue_Color(ByVal TempColor As Color) As String
        Dim r As String = Hex(TempColor.R)
        Dim G As String = Hex(TempColor.G)
        Dim B As String = Hex(TempColor.B)
        If r.Length = 1 Then
            r = 0 & r
        End If
        If G.Length = 1 Then
            G = 0 & G
        End If
        If B.Length = 1 Then
            B = 0 & B
        End If
        Return String.Format("{0}{1}{2}", r, G, B)
    End Function
    Private Function RGB_Color(ByVal TempColor As Color) As String
        Dim r As String = TempColor.R
        Dim G As String = TempColor.G
        Dim B As String = TempColor.B
        Return String.Format("RGB({0},{1},{2})", r, G, B)
    End Function
    Private Sub Export(ByVal FileName As String, ByVal OutputFile As String)
        Dim cmd2 As String = ""
        cmd2 = String.Format(" -f {0}{1}{2} -e {3}{4}{5} -d {6} -b 00000000", Chr(34), FileName, Chr(34), Chr(34), OutputFile, Chr(34), DPI)
        Shell(InkScapePath & cmd2, AppWinStyle.Hide, True)
        RaiseEvent Finished()
    End Sub
    Private Sub ExportPDF(ByVal FileName As String, ByVal OutputFile As String)
        Dim cmd2 As String = ""
        cmd2 = String.Format(" -f {0}{1}{2} -A {3}{4}{5} -d {6} -b 00000000", Chr(34), FileName, Chr(34), Chr(34), OutputFile, Chr(34), DPI)
        Shell(InkScapePath & cmd2, AppWinStyle.Hide, True)
        RaiseEvent Finished()
    End Sub

    Private Function GetFileColor(ByRef Status As String) As Color
        Dim dt As DataTable = DBAc.ReturnDataTable(String.Format("select * from t_color_code where status_name ='{0}'", Status))
        If dt.Rows.Count = 0 Then
            Return Color.FromArgb(192, 192, 192)
        Else
            Return Color.FromArgb(dt.Rows(0).Item("r"), dt.Rows(0).Item("g"), dt.Rows(0).Item("b"))
        End If
        Return Color.FromArgb(192, 192, 192)
    End Function
    Private Function GetTrans(ByRef Status As String) As Double
        Dim dt As DataTable = DBAc.ReturnDataTable(String.Format("select * from t_color_code where status_name ='{0}'", Status))
        If dt.Rows.Count = 0 Then
            Return 1
        End If
        Return dt.Rows(0).Item("t")
    End Function
    Private Function GetStrokeWidth(ByRef Status As String) As Double
        Dim dt As DataTable = DBAc.ReturnDataTable(String.Format("select * from t_color_code where status_name ='{0}'", Status))
        If dt.Rows.Count = 0 Then
            Return 1
        End If
        Return dt.Rows(0).Item("sw")
    End Function
    Private Function GetStrokeTrans(ByRef Status As String) As Double
        Dim dt As DataTable = DBAc.ReturnDataTable(String.Format("select * from t_color_code where status_name ='{0}'", Status))
        If dt.Rows.Count = 0 Then
            Return 1
        End If
        Return dt.Rows(0).Item("st")
    End Function
    Private Function GetDashArrary(ByRef Status As String) As String
        Dim dt As DataTable = DBAc.ReturnDataTable(String.Format("select array from t_dasharray where id ={0}", Val(DBAc.ExcutResult(String.Format("select stroke_style from t_color_code where status_name ='{0}'", Status)))))
        If dt.Rows.Count = 0 Then
            Return 1
        End If
        Return dt.Rows(0).Item("array")
    End Function
    Private Function GetStrokeColor(ByRef Status As String) As Color
        Dim dt As DataTable = DBAc.ReturnDataTable(String.Format("select * from t_color_code where status_name ='{0}'", Status))
        If dt.Rows.Count = 0 Then
            Return Color.FromArgb(192, 192, 192)
        Else
            Return Color.FromArgb(dt.Rows(0).Item("sr"), dt.Rows(0).Item("sg"), dt.Rows(0).Item("sb"))
        End If
        Return Color.FromArgb(192, 192, 192)
    End Function
    Private Sub CopyRefFile(ByVal svg As String, RefName As String)
        RefName = Replace(RefName, "xlink:href=" & Chr(34), "", , , CompareMethod.Text)
        RefName = Replace(RefName, Chr(34), "", , , CompareMethod.Text)
        Dim tmp() As String = Split(svg, "\"), path As String = ""
        For inx As Integer = 0 To UBound(tmp) - 1
            path &= tmp(inx) & "\"
        Next
        path &= Trim(RefName)
        Try
            FileCopy(path, String.Format("{0}\tmpUPDATED\{1}", Application.StartupPath, Trim(RefName)))
        Catch ex As Exception

        End Try
    End Sub
    Private Overloads Sub CorrectDrawingData(ByVal SVG As String, ByVal Info1 As String, ByVal Info2 As String)
        Dim objR As System.IO.StreamReader = New System.IO.StreamReader(SVG)
        Dim objW As New System.IO.StringWriter
        Dim Fi As String() = IO.Directory.GetFileSystemEntries(Application.StartupPath & "\tmp")
        Dim t As String = ""
        Dim temp() As String
        Dim inx As Integer = 0
        Dim b As String

        objW = New System.IO.StringWriter
        t = ""
        Do While objR.Peek() <> -1
            t = objR.ReadLine()
            If InStr(t, "&amp;") >= 1 Then

            Else
                If InStr(t, "Info1") > 0 Then
                    t = Replace(t, "Info1", Info1)
                End If
                If InStr(t, "Info2") > 0 Then
                    t = Replace(t, "Info2", Info2)
                End If

                If InStr(t, "xlink:href") > 0 Then
                    CopyRefFile(SVG, t)
                End If
                If CountCharacter(t, ";") >= 1 Then
                    b = ""
                    temp = Split(t, ";")
                    For inx = 0 To UBound(temp)
                        If inx = UBound(temp) Then
                            b = String.Format("{0}{1}", b, temp(inx))
                        Else
                            b = String.Format("{0}{1};{2}", b, temp(inx), vbCrLf)
                        End If

                    Next
                    t = b
                End If

                If InStr(t, "style=" & coma & coma, CompareMethod.Text) > 0 Then
                    t = Replace(t, "style=" & coma & coma, "" & vbCrLf)
                End If
                If InStr(t, "style=", CompareMethod.Text) > 0 Then
                    If Len(Trim(t)) > 6 Then
                        t = Replace(t, "style=", "style=" & vbCrLf)
                    End If
                End If
                If InStr(t, "/>", CompareMethod.Text) > 0 Then
                    If Len(Trim(t)) > 2 Then
                        t = Replace(t, "/>", "       " & vbCrLf & "/>")
                    End If
                End If
                If ((InStr(t, ">", CompareMethod.Text) > 0) And (InStr(t, "/", CompareMethod.Text) <= 0)) Then
                    If Len(Trim(t)) > 2 Then
                        t = Replace(t, ">", "       " & vbCrLf & ">")
                    End If
                End If

            End If
            objW.WriteLine(t)
        Loop
        '--------------------
        objR.Close()
        IO.File.WriteAllText(String.Format("{0}\tmp\{1}.svg", Application.StartupPath, st.GetFileName(SVG)), objW.ToString, System.Text.Encoding.Default)
        objW.Close()
    End Sub
    Private Overloads Sub CorrectDrawingData(ByVal SVG As String)
        Dim objR As System.IO.StreamReader = New System.IO.StreamReader(SVG)
        Dim objW As New System.IO.StringWriter
        Dim Fi As String() = IO.Directory.GetFileSystemEntries(Application.StartupPath & "\tmp")
        Dim t As String = ""
        Dim temp() As String
        Dim inx As Integer = 0
        Dim b As String

        objW = New System.IO.StringWriter
        t = ""
        Do While objR.Peek() <> -1
            t = objR.ReadLine()
            If InStr(t, "&amp;") >= 1 Then

            Else

                If InStr(t, "xlink:href") > 0 Then
                    CopyRefFile(SVG, t)
                End If
                If CountCharacter(t, ";") >= 1 Then
                    b = ""
                    temp = Split(t, ";")
                    For inx = 0 To UBound(temp)
                        If inx = UBound(temp) Then
                            b = String.Format("{0}{1}", b, temp(inx))
                        Else
                            b = String.Format("{0}{1};{2}", b, temp(inx), vbCrLf)
                        End If

                    Next
                    t = b
                End If

                If InStr(t, "style=" & coma & coma, CompareMethod.Text) > 0 Then
                    t = Replace(t, "style=" & coma & coma, "" & vbCrLf)
                End If
                If InStr(t, "style=", CompareMethod.Text) > 0 Then
                    If Len(Trim(t)) > 6 Then
                        t = Replace(t, "style=", "style=" & vbCrLf)
                    End If
                End If
                If InStr(t, "/>", CompareMethod.Text) > 0 Then
                    If Len(Trim(t)) > 2 Then
                        t = Replace(t, "/>", "       " & vbCrLf & "/>")
                    End If
                End If
                If ((InStr(t, ">", CompareMethod.Text) > 0) And (InStr(t, "/", CompareMethod.Text) <= 0)) Then
                    If Len(Trim(t)) > 2 Then
                        t = Replace(t, ">", "       " & vbCrLf & ">")
                    End If
                End If

            End If
            objW.WriteLine(t)
        Loop
        '--------------------
        objR.Close()
        IO.File.WriteAllText(String.Format("{0}\tmp\{1}.svg", Application.StartupPath, st.GetFileName(SVG)), objW.ToString, System.Text.Encoding.Default)
        objW.Close()
    End Sub
    Private Function ChangeColorText(ByVal OldLine As String, ByVal HColor As String) As String
        Dim EnCh As String = ""
        Dim BeCh As String = ""
        Dim MiCh As String = ""
        OldLine = Trim(OldLine)
        If Len(OldLine) <= 1 Then
            Return OldLine
        End If
        If OldLine.Chars(Len(OldLine) - 2) & OldLine.Chars(Len(OldLine) - 1) = ";" & coma Then
            EnCh = ";" & coma
        ElseIf OldLine.Chars(Len(OldLine) - 1) = ";" Then
            EnCh = ";"
        ElseIf ((OldLine.Chars(Len(OldLine) - 2) <> ";") And (OldLine.Chars(Len(OldLine) - 1) = coma)) Then
            EnCh = coma
        Else
            EnCh = ""
        End If
        If OldLine.Chars(0) = coma Then
            BeCh = coma
        Else
            BeCh = ""
        End If
        Dim miInx As Integer = InStr(OldLine, coma)
        If ((miInx > 1) And (miInx < Len(OldLine) - 1)) Then
            MiCh = coma
        Else
            MiCh = ""
        End If
        'Start Change Color
        If InStr(OldLine, "stroke=", CompareMethod.Text) > 0 Then
            Return String.Format("     {0}stroke={1}#{2}{3}", BeCh, MiCh, HColor, EnCh)
        End If
        If InStr(OldLine, "stroke:", CompareMethod.Text) > 0 Then
            Return String.Format("     {0}stroke:{1}#{2}{3}", BeCh, MiCh, HColor, EnCh)
        End If
        '----------------
        Return OldLine
    End Function
    Private Function ChangeColorFill(ByVal OldLine As String, ByVal HColor As String) As String
        Dim EnCh As String = ""
        Dim BeCh As String = ""
        Dim MiCh As String = ""
        If InStr(OldLine, "none") > 0 Then
            Return OldLine
        End If
        OldLine = Trim(OldLine)
        If Len(OldLine) <= 1 Then
            Return OldLine
        End If
        If OldLine.Chars(Len(OldLine) - 2) & OldLine.Chars(Len(OldLine) - 1) = ";" & coma Then
            EnCh = ";" & coma
        ElseIf OldLine.Chars(Len(OldLine) - 1) = ";" Then
            EnCh = ";"
        ElseIf ((OldLine.Chars(Len(OldLine) - 2) <> ";") And (OldLine.Chars(Len(OldLine) - 1) = coma)) Then
            EnCh = coma
        Else
            EnCh = ""
        End If
        If OldLine.Chars(0) = coma Then
            BeCh = coma
        Else
            BeCh = ""
        End If
        Dim miInx As Integer = InStr(OldLine, coma)
        If ((miInx > 1) And (miInx < Len(OldLine) - 1)) Then
            MiCh = coma
        Else
            MiCh = ""
        End If
        'Start Change Color
        If InStr(OldLine, "fill=", CompareMethod.Text) > 0 Then
            Return String.Format("     {0}fill={1}#{2}{3}", BeCh, MiCh, HColor, EnCh)
        End If
        If InStr(OldLine, "fill:", CompareMethod.Text) > 0 Then
            Return String.Format("     {0}fill:{1}#{2}{3}", BeCh, MiCh, HColor, EnCh)
        End If
        '----------------
        Return OldLine
    End Function
    Private Sub UpdateColor(ByVal QueryPath As String, ByVal HasPattern As Boolean)
        Dim objR As System.IO.StreamReader
        Dim objW As System.IO.StringWriter
        Dim Fi As String() = IO.Directory.GetFileSystemEntries(Application.StartupPath & "\tmp")
        Dim t As String = ""
        Dim Temp() As String
        Dim ID As String = ""
        Dim groupName As String = ""
        Dim i As Integer = 0
        Dim IsUpdate As Boolean = False
        Dim writePattern As Boolean = False
        Dim writePattern2 As Boolean = False
        '----------------------
        Dim obj As New System.IO.StreamReader(QueryPath)
        Dim q As String = obj.ReadToEnd
        Dim dtTag As DataTable = DB.ReturnDataTable(q)
        Dim dr() As DataRow
        obj.Close()
        '-------------------------
        Dim stColor As String = ""
        Dim sKColor As String = ""
        Dim Trans As Double = 1
        Dim STrans As Double = 1
        Dim SkWidth As Double = 0.4
        Dim DashA As String = "none"
        For Each el As String In Fi
            objW = New System.IO.StringWriter
            IsUpdate = False
            objR = New System.IO.StreamReader(el)   'F(i)
            Do While objR.Peek() <> -1   'F(i)
                t = objR.ReadLine()

                If InStr(t, "</g") Then
                    IsUpdate = False
                End If

                'Get Color By ID  ===================
                If InStr(t, "id=" & coma & "g", CompareMethod.Text) > 0 Then 'ID
                    Temp = Split(Trim(t), "id=" & coma)
                    Temp = Split(Trim(Temp(1)), coma)
                    If UBound(Temp) > 0 Then
                        ID = Temp(0)
                    End If
                    i = lstIDs.FindStringExact(ID)
                    If i = -1 Then
                        groupName = ""
                        IsUpdate = False
                    Else
                        groupName = lstTag.Items.Item(i)
                        groupName = Replace(groupName, "</tspan", "")
                        'Get Color ================================
                        dr = dtTag.Select(String.Format("tag = '{0}'", groupName)) 'Color
                        If UBound(dr) >= 0 Then
                            stColor = HexaValue_Color(GetFileColor(dr(0).Item("status")))   'Color
                            sKColor = HexaValue_Color(GetStrokeColor(dr(0).Item("status")))   'Stroke Color
                            Trans = GetTrans(dr(0).Item("status"))  'Trans
                            SkWidth = GetStrokeWidth(dr(0).Item("status"))  'Trans
                            DashA = GetDashArrary(dr(0).Item("status"))  'Dash Array
                            STrans = GetStrokeTrans(dr(0).Item("status"))
                            IsUpdate = True
                        Else
                            IsUpdate = False
                        End If
                        '=============================================
                    End If

                End If
                '=====================================
                If IsUpdate Then
                    If InStr(t, "stroke") > 0 Then
                        t = ChangeColorText(t, stColor)
                    ElseIf InStr(t, "fill") > 0 Then
                        t = ChangeColorFill(t, stColor)
                    End If

                    'Pat--------------------
                    ' If HasPattern Then
                    If InStr(t, "<arcs") > 0 Then
                        writePattern = True
                    End If
                    If InStr(t, "<circle") > 0 Then
                        writePattern = True
                    End If
                    If InStr(t, "<ellipse") > 0 Then
                        writePattern = True
                    End If
                    If InStr(t, "<polygon") > 0 Then
                        writePattern = True
                    End If
                    '<path
                    If InStr(t, "<path") > 0 Then
                        writePattern = True
                    End If
                    '<rect
                    If InStr(t, "<rect") > 0 Then
                        writePattern = True
                    End If
                    '<text
                    If InStr(t, "<text") > 0 Then
                        writePattern = True
                    End If
                    '<g
                    If InStr(t, "<g") > 0 Then
                        writePattern2 = True
                    End If
                    'End If
                    '--------------------------
                End If

                If HasPattern Then
                    If writePattern Then
                        If InStr(t, "/>") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:url(#Pat_{2}{3});fill-rule:nonzero;stroke:#" & stColor & ";stroke-width:0.4;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1;fill-opacity:1.0{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status")) & vbCrLf & t
                                writePattern = False
                            End If
                        End If
                    End If
                    If writePattern2 Then
                        If InStr(t, ">") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:url(#Pat_{2}{3});fill-rule:nonzero;stroke:#" & stColor & ";stroke-width:0.4;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1;fill-opacity:1.0{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status")) & vbCrLf & t
                                writePattern2 = False
                            End If
                        ElseIf InStr(t, "xml:space=") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:url(#Pat_{2}{3});fill-rule:nonzero;stroke:#" & stColor & ";stroke-width:0.4;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1;fill-opacity:1.0{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status")) & vbCrLf & t
                                writePattern2 = False
                            End If
                        End If
                    End If
                Else
                    If writePattern Then
                        If InStr(t, "/>") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:#" & stColor & ";stroke:#" & sKColor & ";stroke-width:" & SkWidth & ";stroke-dasharray:" & DashA & ";stroke-opacity:" & STrans & ";fill-opacity:{4}{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status"), Trans) & vbCrLf & t
                                writePattern = False
                            End If
                        End If
                    End If
                    If writePattern2 Then
                        If InStr(t, ">") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:#" & stColor & ";stroke:#" & sKColor & ";stroke-width:" & SkWidth & ";stroke-dasharray:" & DashA & ";stroke-opacity:" & STrans & ";fill-opacity:{4}{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status"), Trans) & vbCrLf & t
                                writePattern2 = False
                            End If
                        ElseIf InStr(t, "xml:space=") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:#" & stColor & ";stroke:#" & sKColor & ";stroke-width:" & SkWidth & ";stroke-dasharray:" & DashA & ";stroke-opacity:" & STrans & ";fill-opacity:{4}{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status"), Trans) & vbCrLf & t
                                writePattern2 = False
                            End If
                        End If
                    End If
                End If

                objW.WriteLine(t)


            Loop
            objR.Close()

            If HasPattern Then
                IO.File.WriteAllText(String.Format("{0}\tmpUpdated\{1}_{2}.svg", Application.StartupPath, st.GetFileName(el), st.GetFileName(QueryPath)), Replace(objW.ToString, "</svg>", GeneratePatern(q) & vbCrLf & "</svg>"), System.Text.Encoding.Default)
            Else
                IO.File.WriteAllText(String.Format("{0}\tmpUpdated\{1}_{2}.svg", Application.StartupPath, st.GetFileName(el), st.GetFileName(QueryPath)), objW.ToString, System.Text.Encoding.Default)
            End If
            objW.Close()
        Next

        '======================================================================
    End Sub

    Private Sub UpdateSequenceColor(ByVal HasPattern As Boolean, ByRef dtTag As DataTable, ByVal SeqName As String)
        Dim objR As System.IO.StreamReader
        Dim objW As System.IO.StringWriter
        Dim Fi As String() = IO.Directory.GetFileSystemEntries(Application.StartupPath & "\tmp")
        Dim t As String = ""
        Dim Temp() As String
        Dim ID As String = ""
        Dim groupName As String = ""
        Dim i As Integer = 0
        Dim IsUpdate As Boolean = False
        Dim writePattern As Boolean = False
        Dim writePattern2 As Boolean = False
        Dim dr() As DataRow
        Dim stColor As String = ""
        Dim sKColor As String = ""
        Dim Trans As Double = 1
        Dim STrans As Double = 1
        Dim SkWidth As Double = 0.4
        Dim DashA As String = "none"
        For Each el As String In Fi
            objW = New System.IO.StringWriter
            IsUpdate = False
            objR = New System.IO.StreamReader(el)   'F(i)
            Do While objR.Peek() <> -1   'F(i)
                t = objR.ReadLine()

             

                If InStr(t, "</g") Then
                    IsUpdate = False
                End If

                'Get Color By ID  ===================
                If InStr(t, "id=" & coma & "g", CompareMethod.Text) > 0 Then 'ID
                    Temp = Split(Trim(t), "id=" & coma)
                    Temp = Split(Trim(Temp(1)), coma)
                    If UBound(Temp) > 0 Then
                        ID = Temp(0)
                    End If
                    i = lstIDs.FindStringExact(ID)
                    If i = -1 Then
                        groupName = ""
                        IsUpdate = False
                    Else
                        groupName = lstTag.Items.Item(i)
                        groupName = Replace(groupName, "</tspan", "")
                        'Get Color ================================
                        dr = dtTag.Select(String.Format("tag = '{0}'", groupName)) 'Color
                        If UBound(dr) >= 0 Then
                            stColor = HexaValue_Color(GetFileColor(dr(0).Item("status")))   'Color
                            sKColor = HexaValue_Color(GetStrokeColor(dr(0).Item("status")))   'Stroke Color
                            Trans = GetTrans(dr(0).Item("status"))  'Trans
                            SkWidth = GetStrokeWidth(dr(0).Item("status"))  'Trans
                            DashA = GetDashArrary(dr(0).Item("status"))  'Dash Array
                            STrans = GetStrokeTrans(dr(0).Item("status"))
                            IsUpdate = True
                        Else
                            IsUpdate = False
                        End If
                        '=============================================
                    End If

                End If
                '=====================================
                If IsUpdate Then
                    If InStr(t, "stroke") > 0 Then
                        t = ChangeColorText(t, stColor)
                    ElseIf InStr(t, "fill") > 0 Then
                        t = ChangeColorFill(t, stColor)
                    End If

                    'Pat--------------------
                    ' If HasPattern Then
                    If InStr(t, "<arcs") > 0 Then
                        writePattern = True
                    End If
                    If InStr(t, "<circle") > 0 Then
                        writePattern = True
                    End If
                    If InStr(t, "<ellipse") > 0 Then
                        writePattern = True
                    End If
                    If InStr(t, "<polygon") > 0 Then
                        writePattern = True
                    End If
                    '<path
                    If InStr(t, "<path") > 0 Then
                        writePattern = True
                    End If
                    '<rect
                    If InStr(t, "<rect") > 0 Then
                        writePattern = True
                    End If
                    '<text
                    If InStr(t, "<text") > 0 Then
                        writePattern = True
                    End If
                    '<g
                    If InStr(t, "<g") > 0 Then
                        writePattern2 = True
                    End If
                  
                    'End If
                    '--------------------------
                End If

                If HasPattern Then
                    If writePattern Then
                        If InStr(t, "/>") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:url(#Pat_{2}{3});fill-rule:nonzero;stroke:#" & stColor & ";stroke-width:0.4;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1;fill-opacity:1.0{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status")) & vbCrLf & t
                                writePattern = False
                            End If
                        End If
                    End If
                    If writePattern2 Then
                        If InStr(t, ">") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:url(#Pat_{2}{3});fill-rule:nonzero;stroke:#" & stColor & ";stroke-width:0.4;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1;fill-opacity:1.0{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status")) & vbCrLf & t
                                writePattern2 = False
                            End If
                        ElseIf InStr(t, "xml:space=") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:url(#Pat_{2}{3});fill-rule:nonzero;stroke:#" & stColor & ";stroke-width:0.4;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1;fill-opacity:1.0{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status")) & vbCrLf & t
                                writePattern2 = False
                            End If
                        End If
                    End If
                Else
                    If writePattern Then
                        If InStr(t, "/>") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:#" & stColor & ";stroke:#" & sKColor & ";stroke-width:" & SkWidth & ";stroke-dasharray:" & DashA & ";stroke-opacity:" & STrans & ";fill-opacity:{4}{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status"), Trans) & vbCrLf & t
                                writePattern = False
                            End If
                        End If
                    End If
                    If writePattern2 Then
                        If InStr(t, ">") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:#" & stColor & ";stroke:#" & sKColor & ";stroke-width:" & SkWidth & ";stroke-dasharray:" & DashA & ";stroke-opacity:" & STrans & ";fill-opacity:{4}{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status"), Trans) & vbCrLf & t
                                writePattern2 = False
                            End If
                        ElseIf InStr(t, "xml:space=") > 0 Then
                            If dr.Length > 0 Then
                                t = String.Format("{0}style={1}fill:#" & stColor & ";stroke:#" & sKColor & ";stroke-width:" & SkWidth & ";stroke-dasharray:" & DashA & ";stroke-opacity:" & STrans & ";fill-opacity:{4}{1}", vbCrLf, coma, dr(0).Item("PatternNo"), dr(0).Item("status"), Trans) & vbCrLf & t
                                writePattern2 = False
                            End If
                        End If
                    End If
                End If

                objW.WriteLine(t)


            Loop
            objR.Close()

            If HasPattern Then
                IO.File.WriteAllText(String.Format("{0}\tmpUpdated\{1}_{2}.svg", Application.StartupPath, st.GetFileName(el), SeqName), Replace(objW.ToString, "</svg>", GeneratePatern(SeqName) & vbCrLf & "</svg>"), System.Text.Encoding.Default)
            Else
                IO.File.WriteAllText(String.Format("{0}\tmpUpdated\{1}_{2}.svg", Application.StartupPath, st.GetFileName(el), SeqName), objW.ToString, System.Text.Encoding.Default)
            End If
            objW.Close()
        Next

        '======================================================================
    End Sub
    Private Sub CombineData(ByVal FileName As String, ByVal QueryName As String)
        Try
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\tmp\header.svg")
            Dim g As New System.IO.StringWriter
            g.Write(obj.ReadToEnd)
            obj.Close()
            Dim Fi As String() = IO.Directory.GetFileSystemEntries(Application.StartupPath & "\tmp")
            For Each el As String In Fi
                If el <> Application.StartupPath & "\tmp\header.svg" Then
                    obj = New System.IO.StreamReader(el)
                    g.WriteLine(obj.ReadToEnd)
                    obj.Close()
                End If
            Next
            SaveBody(g, String.Format("{0}_{1}_Updated", FileName, QueryName))

        Catch ex As Exception
            ' RaiseEvent Err(ex.Message)
        End Try

    End Sub
    Private Sub RecursiveDele(ByVal OutPath As String)
        Try
            Dim Fi As String() = IO.Directory.GetFileSystemEntries(Application.StartupPath & "\tmp")
            For Each el As String In Fi
                IO.File.Delete(el)
            Next
            Dim Fi2 As String() = IO.Directory.GetFileSystemEntries(OutPath)
            For Each el As String In Fi2
                IO.File.Delete(el)
            Next
            Dim Fi3 As String() = IO.Directory.GetFileSystemEntries(Application.StartupPath & "\tmpUpdated")
            For Each el As String In Fi3
                IO.File.Delete(el)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Ini_Proc(ByVal OutPath As String)
        RecursiveDele(OutPath)
    End Sub

    Private Sub SaveHader(ByRef h As System.IO.StringWriter)
        IO.File.WriteAllText(Application.StartupPath & "\tmp\header.svg", h.ToString, System.Text.Encoding.Unicode)
    End Sub
    Private Sub SaveGroup(ByRef h As System.IO.StringWriter, GName As String)
        GName = Replace(GName, "\", "")
        GName = Replace(GName, "/", "")
        IO.File.WriteAllText(String.Format("{0}\tmp\{1}.svg", Application.StartupPath, Replace(GName, "</tspan>", "")), h.ToString)
    End Sub
    Private Sub SaveBody(ByRef h As System.IO.StringWriter, FName As String)
        h.WriteLine("</svg>")
        IO.File.WriteAllText(String.Format("{0}\tmpupdated\{1}.svg", Application.StartupPath, FName), h.ToString, System.Text.Encoding.Unicode)
    End Sub

    Private Sub DivideGroups(ByVal SVGPath As String)
        Dim obj As New System.IO.StreamReader(SVGPath)
        Dim t As String = ""
        Dim groupCount As Integer = 0
        Dim LayerCount As Integer = 0
        'Dim LayerEndCount As Integer = 0
        'Dim endCount As Integer = 0
        Dim header As Boolean = True
        Dim h As New System.IO.StringWriter
        Dim g As New System.IO.StringWriter
        Dim GroupName As String = ""
        Dim temp() As String
        Dim ID As String = ""

        lstIDs.Items.Clear()
        lstTag.Items.Clear()
        lstLayersID.Items.Clear()
        lstLayersTag.Items.Clear()

        Do While obj.Peek() <> -1
            t = obj.ReadLine()

            'Layers Start Handle
            If InStr(t, "inkscape:groupmode=" & coma & "layer", CompareMethod.Text) > 0 Then   'Layer started
                groupCount -= 1
                LayerCount += 1
                lstLayersID.Items.Add(Trim(Replace(Replace(t, coma, ""), "id=", "")))
            End If
            '-----------------------

            '-------------------
            If InStr(t, _StartGroup, CompareMethod.Text) > 0 Then   'group started
                groupCount += 1
                header = False
            End If
            '-------------------------------
            If InStr(t, _EndGroup, CompareMethod.Text) > 0 Then   'group ended
                If Trim(GroupName) <> "" Then
                    lstIDs.Items.Add(ID)
                    lstTag.Items.Add(GroupName)
                    'Else
                    '    If LayerCount > LayerEndCount Then
                    '        If lstLayersID.Items.Count > 0 Then
                    '            LayerEndCount = LayerCount

                    '        End If
                    '    End If
                End If
                GroupName = ""
                ID = ""
                'endCount = 0
                groupCount = 0
            End If
            '----------------------------------------
            If InStr(t, _TextName, CompareMethod.Text) > 0 Then 'End Text
                temp = Split(t, _TextName)
                temp = Split(temp(0), ">")
                If UBound(temp) > 0 Then
                    If TagContainsDash Then
                        If InStr(temp(1), "-") > 0 Then
                            GroupName = Trim(temp(1))
                        End If
                    Else
                        GroupName = Trim(temp(1))
                    End If
                End If
            ElseIf InStr(t, _TextName2, CompareMethod.Text) > 0 Then    'End Text
                temp = Split(t, _TextName2)
                temp = Split(temp(0), ">")
                If UBound(temp) > 0 Then
                    If TagContainsDash Then
                        If InStr(temp(1), "-") > 0 Then
                            GroupName = Trim(temp(1))
                        End If
                    Else
                        GroupName = Trim(temp(1))
                    End If
                End If
            ElseIf InStr(t, _TextName3, CompareMethod.Text) > 0 Then    'End Text
                temp = Split(t, _TextName3)
                temp = Split(temp(0), ">")
                If UBound(temp) > 0 Then
                    If TagContainsDash Then
                        If InStr(temp(1), "-") > 0 Then
                            GroupName = Trim(temp(1))
                        End If
                    Else
                        GroupName = Trim(temp(1))
                    End If
                End If
            ElseIf InStr(t, _TextName4, CompareMethod.Text) > 0 Then    'End Text
                temp = Split(t, _TextName4)
                temp = Split(temp(0), ">")
                If UBound(temp) > 0 Then
                    If TagContainsDash Then
                        If InStr(temp(1), "-") > 0 Then
                            GroupName = Trim(temp(1))
                        End If
                    Else
                        GroupName = Trim(temp(1))
                    End If
                End If
            End If
            '-------------------------------------------------------    ID
            If InStr(t, "id=" & coma & "g", CompareMethod.Text) > 0 Then 'ID
                temp = Split(Trim(t), "id=" & coma)
                temp = Split(Trim(temp(1)), coma)
                If UBound(temp) > 0 Then
                    ID = temp(0)
                End If
            End If
        Loop
        obj.Close()
    End Sub

    
    Public Sub GenerateSequence(ByRef SVGPath As String, ByVal OUTPath As String, ByVal filetype As e_exportfiletype, ByVal HasPattern As Boolean, ByRef DT As DataTable, ByVal SeqName As String, ByVal StartDate As String)
        DivideGroups(SVGPath)
        CorrectDrawingData(SVGPath, "Week: " & SeqName, "Start Date: " & StartDate)
        UpdateSequenceColor(HasPattern, DT, SeqName)
        ExportResults(OUTPath, filetype, SVGPath, SeqName)
    End Sub
    Public Sub Generate(ByRef SVGPath As String, ByVal QueryPath As String, ByVal OUTPath As String, ByVal filetype As e_exportfiletype, ByVal HasPattern As Boolean, ByVal conType As Connections.enConnectionType, ByVal url As String, ByVal dbName As String)
        DivideGroups(SVGPath)
        CorrectDrawingData(SVGPath)
        UpdateColor(QueryPath, HasPattern)
        ExportResults(OUTPath, filetype, SVGPath, st.GetFileName(QueryPath))
    End Sub
    Public Sub ExportResults(ByVal OutPath As String, ByVal filetype As e_exportfiletype, ByVal FilePath As String, ByVal QueryName As String)
        Dim Fi2 As String() = IO.Directory.GetFileSystemEntries(Application.StartupPath & "\tmpUpdated", String.Format("{0}_{1}.svg", st.GetFileName(FilePath), QueryName))
        Select Case filetype
            Case e_exportfiletype.pdf
                For Each el As String In Fi2
                    ExportPDF(el, String.Format("{0}\{1}.pdf", OutPath, st.GetFileName(el)))
                Next
            Case e_exportfiletype.png
                For Each el As String In Fi2
                    Export(el, String.Format("{0}\{1}.png", OutPath, st.GetFileName(el)))
                Next
        End Select

    End Sub

#Region "Pattern"
    Private Function StyleExists(ByVal lne As String) As Boolean
        Try
            If InStr(lne, "style") > 0 Then
                Return True
            End If
            If InStr(lne, "fill") > 0 Then
                Return True
            End If
            If InStr(lne, "stroke") > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function
    Private Function GeneratePatern(ByVal Query As String) As String
        'Try
        Dim dtPat As DataTable = DB.ReturnDataTable(String.Format("select distinct Status,PatternNo from ( {0} ) as v000000000 where PatternNo is not null", Query))
        Dim buffer As String = ""
        For inx As Integer = 0 To dtPat.Rows.Count - 1
            Dim obj As New System.IO.StreamReader(String.Format("{0}\pattern\{1}.pat", Application.StartupPath, dtPat.Rows(inx).Item("PatternNo")))
            Dim tinb As String = obj.ReadToEnd
            obj.Close()
            '-----
            buffer &= Replace(tinb, "stroke:#000000", "stroke:#" & HexaValue_Color(GetFileColor(dtPat(inx).Item("status")))) & vbCrLf
            buffer = Replace(buffer, "pattern00000", String.Format("Pat_{0}{1}", dtPat.Rows(inx).Item("PatternNo"), dtPat(inx).Item("status")))
        Next

        Return buffer
        'Catch ex As Exception
        '    Return vbNullString
        'End Try
    End Function
#End Region


#Region "Edit Drawing"
    Private Function ReplaceTag(ByVal Line As String, ByRef DT As DataTable) As String
        Try
            If ((Trim(Line).Chars(0) = "u") Or (Trim(Line).Chars(0) = "U")) Then
                Line = Replace(Line, "&quot;", "")
                Dim temp As String() = Split(Trim(Line), "-")
                Dim dr() As DataRow
                Select Case UBound(temp)
                    Case 5
                        dr = DT.Select(String.Format("tag like '%{0}-{1}-{2}'", temp(1), temp(2), temp(5)))
                        If UBound(dr) >= 0 Then
                            Return dr(0).Item("tag")
                        End If
                    Case 4
                        dr = DT.Select(String.Format("tag like '%{0}-{1}-{2}'", temp(1), temp(2), temp(4)))
                        If UBound(dr) >= 0 Then
                            Return dr(0).Item("tag")
                        End If
                    Case Else
                        Return Line

                End Select

            End If

            Return Line
        Catch ex As Exception
            Return Line
        End Try

    End Function

    Public Sub MatchTagsLists(ByVal DrawingPath As String, ByVal SaveLocation As String, ByVal TagListsPath As String)
        Dim obj As New System.IO.StreamReader(DrawingPath)
        Dim objw As New System.IO.StringWriter
        Dim t As String = ""
        Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
        dt = ex.GetSheetData(TagListsPath, "sheet1")

        Do While obj.Peek() <> -1
            t = obj.ReadLine()
            If InStr(t, "</text>", CompareMethod.Text) > 0 Then
                Dim temp As String() = Split(t, "</text>")
                temp = Split(temp(0), ">")
                If UBound(temp) > 0 Then
                    t = Replace(t, temp(1), ReplaceTag(temp(1), dt))
                End If
            ElseIf InStr(t, "</tspan>", CompareMethod.Text) > 0 Then
                Dim temp As String() = Split(t, "</tspan>")
                temp = Split(temp(0), ">")
                If UBound(temp) > 0 Then
                    t = Replace(t, temp(1), ReplaceTag(temp(1), dt))
                End If
            End If


            objw.WriteLine(t)
        Loop
        IO.File.WriteAllText(SaveLocation, objw.ToString)
        obj.Close()
        objw.Close()
        RaiseEvent EditFinished()
    End Sub

    Public Sub ChangeFont(ByVal DrawingPath As String, ByVal SaveLocation As String, ByVal Fontsize As Double)
        Dim obj As New System.IO.StreamReader(DrawingPath)
        Dim objw As New System.IO.StringWriter
        Dim t As String = ""

        Do While obj.Peek() <> -1
            t = obj.ReadLine()
            If InStr(t, "font-size=", CompareMethod.Text) > 0 Then
                Dim temp As String() = Split(t, "font-size=" & Chr(34))
                temp = Split(temp(UBound(temp)), Chr(34))
                If UBound(temp) > 0 Then
                    t = Replace(t, "font-size=" & Chr(34) & temp(0), "font-size=" & Chr(34) & Fontsize)
                End If
            End If
            If InStr(t, "font-size:", CompareMethod.Text) > 0 Then
                Dim temp As String() = Split(t, "font-size:")
                temp = Split(temp(UBound(temp)), ";")
                If UBound(temp) > 0 Then
                    If InStr(temp(0), "px") > 0 Then
                        t = Replace(t, "font-size:" & temp(0), "font-size:" & Fontsize & "px")
                    Else
                        t = Replace(t, "font-size:" & temp(0), "font-size:" & Fontsize)
                    End If

                End If
            End If
            objw.WriteLine(t)
        Loop
        IO.File.WriteAllText(SaveLocation, objw.ToString)
        obj.Close()
        objw.Close()
        RaiseEvent EditFinished()
    End Sub

    Public Sub ChangeStrokeWidthLine(ByVal DrawingPath As String, ByVal SaveLocation As String, ByVal Width As Double)
        Dim obj As New System.IO.StreamReader(DrawingPath)
        Dim objw As New System.IO.StringWriter
        Dim t As String = ""

        Do While obj.Peek() <> -1
            t = obj.ReadLine()
            If InStr(t, "px", CompareMethod.Text) > 0 Then
                If InStr(t, "stroke-width=", CompareMethod.Text) > 0 Then
                    Dim temp As String() = Split(t, "stroke-width=" & Chr(34))
                    temp = Split(temp(UBound(temp)), Chr(34))
                    If UBound(temp) > 0 Then
                        t = Replace(t, String.Format("stroke-width={0}{1}", Chr(34), temp(0)), String.Format("stroke-width={0}{1}", Chr(34), Width))
                    End If
                End If
                If InStr(t, "stroke-width:", CompareMethod.Text) > 0 Then
                    Dim temp As String() = Split(t, "stroke-width:")
                    temp = Split(temp(UBound(temp)), ";")
                    If UBound(temp) > 0 Then
                        If InStr(temp(0), "px") > 0 Then
                            t = Replace(t, "stroke-width:" & temp(0), String.Format("stroke-width:{0}px", Width))
                        Else
                            t = Replace(t, "stroke-width:" & temp(0), "stroke-width:" & Width)
                        End If

                    End If
                End If
                objw.WriteLine(t)
            End If
        Loop
        IO.File.WriteAllText(SaveLocation, objw.ToString)
        obj.Close()
        objw.Close()
        RaiseEvent EditFinished()
    End Sub

    Public Sub RemoveTextStroke(ByVal DrawingPath As String, ByVal SaveLocation As String)
        Dim obj As New System.IO.StreamReader(DrawingPath)
        Dim objw As New System.IO.StringWriter
        Dim t As String = ""

        Do While obj.Peek() <> -1
            t = obj.ReadLine()
            If InStr(t, "font-size", CompareMethod.Text) > 0 Then
                If InStr(t, "stroke-width=", CompareMethod.Text) > 0 Then
                    Dim temp As String() = Split(t, "stroke-width=" & Chr(34))
                    temp = Split(temp(UBound(temp)), Chr(34))
                    If UBound(temp) > 0 Then
                        t = Replace(t, String.Format("stroke-width={0}{1}", Chr(34), temp(0)), String.Format("stroke-width={0}{1}", Chr(34), 0))
                    End If
                End If
                If InStr(t, "stroke-width:", CompareMethod.Text) > 0 Then
                    Dim temp As String() = Split(t, "stroke-width:")
                    temp = Split(temp(UBound(temp)), ";")
                    If UBound(temp) > 0 Then
                        t = Replace(t, "stroke-width:" & temp(0), "stroke-width:" & 0)
                    End If
                End If
            End If
            objw.WriteLine(t)
        Loop
        IO.File.WriteAllText(SaveLocation, objw.ToString)
        obj.Close()
        objw.Close()
        RaiseEvent EditFinished()
    End Sub
#End Region

   
End Class
