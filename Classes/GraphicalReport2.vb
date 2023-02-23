Public Class GraphicalReport2
    Private Groups As New svgGroups
    Const _StartGroup = "<g"
    Const _EndGroup = "</g>"
    Const _TextName = "</text>"
    Const _TextName1 = "</tspan>"
    Const _TextName2 = "</flowPara>"
    Const coma = Chr(34)
    Public TagContainsDash As Boolean = True
    Private st As New EAMS.StringFunctions.StringsFunction
    Private _GroupID As String = ""
    Private _ShapeType As e_ShapeType
    Private _haspattern As Boolean = False

    Private dr() As DataRow, IsUpdate As Boolean = False
    Private stColor As String = ""
    Private sKColor As String = ""
    Private Trans As Double = 1
    Private STrans As Double = 1
    Private SkWidth As Double = 0.4
    Private DashA As String = "none"
    Private PatternNo As String = ""
    Private _WorkingFile As String = ""
    Private _svgPath As String = ""
    Private dtPat As New DataTable
    Public DPI As Integer = 600
    Public InkScapePath As String = String.Format("{0}{1}\Bin\Libs\App\Inkscape\inkscape.exe{2}", Chr(34), Application.StartupPath, Chr(34))

    Public Event ExportFinished()
    Public Event EditFinished()
    Public Event Err(ByVal msg As String)

#Region "Proprties"
    Public WriteOnly Property PatternStatus As DataTable
        Set(value As DataTable)
            dtPat = value
        End Set
    End Property
#End Region

#Region "Enum"
    Public Enum e_exportfiletype
        pdf = 1
        png = 2
    End Enum
    Private Enum e_ShapeType
        Text = 1
        Line = 2
        ClosedShape = 3
    End Enum
#End Region

#Region "Replace Tag"
    Private Function ReplaceTag(ByRef text As String, ByRef dt As DataTable) As String
        For inx As Integer = 0 To dt.Rows.Count - 1
            '            If InStr(text, dt.Rows(inx).Item("Tag"), CompareMethod.Text) > 0 Then
            text = Replace(text, dt.Rows(inx).Item("Tag"), dt.Rows(inx).Item("NewTag"),,, CompareMethod.Text)
            'End If
        Next
        Return text
    End Function
#End Region
#Region "Pattern"
    Private Function GeneratePatern() As String
        Try
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
        Catch ex As Exception
            '    Return vbNullString
        End Try
        Return ""
    End Function
#End Region
#Region "Read Group internal"
    Private Sub AddGroupName(ByVal gName As String)
        If TagContainsDash Then
            If InStr(gName, "-") < 1 Then Exit Sub
        End If
        If Groups.Count = 0 Then
            Exit Sub
        Else
            If Groups.GroupName(Groups.Count - 1) = "" Then
                Groups.GroupName(Groups.Count - 1) = gName
            Else
                If (Groups.GroupName(Groups.Count - 2) = "") Then
                    Groups.GroupName(Groups.Count - 2) = gName
                End If
            End If
        End If

    End Sub
    Private Function GroupID(ByVal Line As String) As String
        Line = Replace(Line, coma, "")
        Line = Replace(Line, ">", "")
        Line = Replace(Line, "id=g", "")
        Return Trim(Line)
        Return ""
    End Function
    Private Function GroupText(ByVal Line As String, ByVal TextIden As String) As String
        Dim temp As String() = Split(Line, TextIden)
        temp = Split(temp(0), ">")
        If UBound(temp) > 0 Then Return Trim(temp(1))
        Return ""
    End Function

    Private Sub DivideGroups(ByVal SVGPath As String)
        Dim obj As New System.IO.StreamReader(SVGPath)
        Dim t As String = ""
        Dim _IsGroup As Boolean = False
        Try
            Groups.Clear()
            Do While obj.Peek() <> -1
                t = obj.ReadLine()

                If InStr(t, "inkscape:groupmode=" & coma & "layer", CompareMethod.Text) > 0 Then   'Layer started
                    _IsGroup = False
                End If

                If InStr(t, _StartGroup, CompareMethod.Text) > 0 Then   'group started
                    _IsGroup = True
                End If



                If InStr(t, "id=" & coma & "g", CompareMethod.Text) > 0 Then   'IDs
                    If _IsGroup Then
                        Groups.Add(GroupID(t), "")
                    End If
                End If

                If _IsGroup Then

                    'Text ==================================================
                    If InStr(t, _TextName1 & _TextName2 & _TextName, CompareMethod.Text) > 0 Then   'Group Text1
                        AddGroupName(GroupText(t, _TextName1 & _TextName2 & _TextName))
                    ElseIf InStr(t, _TextName2 & _TextName1 & _TextName, CompareMethod.Text) > 0 Then   'Group Text1
                        AddGroupName(GroupText(t, _TextName2 & _TextName1 & _TextName))
                    ElseIf InStr(t, _TextName2 & _TextName, CompareMethod.Text) > 0 Then
                        AddGroupName(GroupText(t, _TextName2 & _TextName))
                    ElseIf InStr(t, _TextName1 & _TextName, CompareMethod.Text) > 0 Then
                        AddGroupName(GroupText(t, _TextName1 & _TextName))
                    ElseIf InStr(t, _TextName1, CompareMethod.Text) > 0 Then
                        AddGroupName(GroupText(t, _TextName1))
                    ElseIf InStr(t, _TextName2, CompareMethod.Text) > 0 Then
                        AddGroupName(GroupText(t, _TextName2))
                    ElseIf InStr(t, _TextName, CompareMethod.Text) > 0 Then
                        AddGroupName(GroupText(t, _TextName))

                    End If
                    '==================================================
                End If

                If InStr(t, _EndGroup, CompareMethod.Text) > 0 Then   'group ended
                    _IsGroup = False
                End If


            Loop

            obj.Close()
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "File Operations"
    Private Sub Export(ByVal FileName As String, ByVal OutputFile As String)
        Dim cmd2 As String = ""
        cmd2 = String.Format(" -f {0}{1}{2} -e {3}{4}{5} -d {6} -b 00000000", Chr(34), FileName, Chr(34), Chr(34), OutputFile, Chr(34), DPI)
        Shell(InkScapePath & cmd2, AppWinStyle.Hide, True)
        RaiseEvent ExportFinished()
    End Sub
    Public Sub ExportResults(ByVal OutPath As String, ByVal filetype As e_exportfiletype)
        Select Case filetype
            Case e_exportfiletype.pdf
                ExportPDF(_WorkingFile, String.Format("{0}\{1}.pdf", OutPath, st.GetFileName(_WorkingFile)))
            Case e_exportfiletype.png
                Export(_WorkingFile, String.Format("{0}\{1}.png", OutPath, st.GetFileName(_WorkingFile)))
        End Select
    End Sub
    Private Sub ExportPDF(ByVal FileName As String, ByVal OutputFile As String)
        Dim cmd2 As String = ""
        cmd2 = String.Format(" -f {0}{1}{2} -A {3}{4}{5} -d {6} -b 00000000", Chr(34), FileName, Chr(34), Chr(34), OutputFile, Chr(34), DPI)
        Shell(InkScapePath & cmd2, AppWinStyle.Hide, True)
        RaiseEvent ExportFinished()
    End Sub

    Private Sub CopyToTemp(ByRef SVGPath As String)
        Dim tmp() As String = Split(SVGPath, "\")
        FileIO.FileSystem.CopyFile(SVGPath, String.Format("{0}\tmp\{1}", Application.StartupPath, tmp(tmp.Count - 1)), True)
    End Sub
#End Region
#Region "Coloring"
    Private Sub ClearColor()
        stColor = "000000"   'Color
        sKColor = "000000"   'Stroke Color
        Trans = 0  'Trans
        SkWidth = 0.6  'Trans
        DashA = "none"  'Dash Array
        STrans = 1
        PatternNo = ""
    End Sub
    Private Sub CopyImageLink(ByRef Line As String)
        Dim StartLine As String = ""
        Dim EndLine As String = ""
        Dim temp() As String = Split(Line, "sodipodi:absref=" & coma)
        StartLine = String.Format("{0}sodipodi:absref={1}", temp(0), coma)
        temp = Split(temp(1), coma)
        If temp.Count > 1 Then
            EndLine = coma & temp(1)
        End If
        Line = st.GetFileNameWithExtention(temp(0))
        If Not FileIO.FileSystem.FileExists(String.Format("{0}\tmpupdated\{1}", Application.StartupPath, Line)) Then
            FileIO.FileSystem.CopyFile(String.Format("{0}\{1}", _svgPath, Line), String.Format("{0}\tmpupdated\{1}", Application.StartupPath, Line), True)
        End If
        Line = StartLine & Line & EndLine
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
    Private Function GetStrokeColor(ByRef Status As String) As Color
        Dim dt As DataTable = DBAc.ReturnDataTable(String.Format("select * from t_color_code where status_name ='{0}'", Status))
        If dt.Rows.Count = 0 Then
            Return Color.FromArgb(192, 192, 192)
        Else
            Return Color.FromArgb(dt.Rows(0).Item("sr"), dt.Rows(0).Item("sg"), dt.Rows(0).Item("sb"))
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
    Private Sub UpdateColor(ByVal HasPattern As Boolean, ByRef dtTag As DataTable, ByVal SeqName As String, ByRef FileName As String, ByVal CanReplaceTag As Boolean)
        Dim objR As System.IO.StreamReader = New System.IO.StreamReader(String.Format("{0}\tmp\{1}.svg", Application.StartupPath, FileName))
        Dim objW As System.IO.StringWriter = New System.IO.StringWriter
        Dim t As String = ""
        _GroupID = ""
        Do While objR.Peek() <> -1
            t = objR.ReadLine()
            ParseSvg(t, dtTag)
            objW.WriteLine(t)
        Loop
        objR.Close()

        If HasPattern Then
            If CanReplaceTag Then
                IO.File.WriteAllText(String.Format("{0}\tmpUpdated\{1}.svg", Application.StartupPath, FileName, SeqName), Replace(ReplaceTag(objW.ToString, dtTag), "</svg>", GeneratePatern() & vbCrLf & "</svg>"), System.Text.Encoding.Default)
            Else
                IO.File.WriteAllText(String.Format("{0}\tmpUpdated\{1}.svg", Application.StartupPath, FileName, SeqName), Replace(objW.ToString, "</svg>", GeneratePatern() & vbCrLf & "</svg>"), System.Text.Encoding.Default)
            End If

        Else
            If CanReplaceTag Then
                IO.File.WriteAllText(String.Format("{0}\tmpUpdated\{1}.svg", Application.StartupPath, FileName, SeqName), ReplaceTag(objW.ToString, dtTag), System.Text.Encoding.Default)
            Else
                IO.File.WriteAllText(String.Format("{0}\tmpUpdated\{1}.svg", Application.StartupPath, FileName, SeqName), objW.ToString, System.Text.Encoding.Default)
            End If
        End If
        objW.Close()
        _WorkingFile = String.Format("{0}\tmpUpdated\{1}.svg", Application.StartupPath, FileName, SeqName)
        'Next

    End Sub

#End Region
#Region "Parsing"
    Private Sub GenerateStyle(ByRef Line As String)
        Dim EndLine As String = ""
        Dim StartLine As String = ""
        Dim FSize As String = "8px"
        Dim temp As String() = Split(Line, "style")
        If temp.Count > 1 Then StartLine = temp(0)

        If ((InStr(Line, ">", CompareMethod.Text) > 0) And (InStr(Line, "/>", CompareMethod.Text) < 1)) Then
            temp = Split(Line, ">")
            If temp.Count > 1 Then
                For inx As Integer = 1 To temp.Count - 2
                    EndLine = ">" & EndLine & temp(inx)
                Next
                If Line.Chars(Len(Line) - 1) = ">" Then EndLine &= ">"
            Else
                EndLine = ">"
            End If
        ElseIf InStr(Line, "/>", CompareMethod.Text) > 0 Then
            temp = Split(Line, "/>")
            EndLine = "/>"
            If temp.Count > 1 Then
                EndLine &= temp(1)
            End If
        End If

        Select Case _ShapeType
            Case e_ShapeType.Text
                If InStr(Line, "font-size", CompareMethod.Text) > 0 Then
                    temp = Split(Line, "font-size:")
                    If InStr(temp(1), ";") > 0 Then
                        temp = Split(temp(1), ";")
                    Else
                        temp = Split(temp(1), ">")
                    End If
                    FSize = Replace(Trim(temp(0)), coma, "")
                End If
                    Line = "style=" & coma & "font-style:normal;font-weight:normal;font-size:" & FSize & ";line-height:100%;font-family:sans-serif;letter-spacing:0px;word-spacing:0px;fill:#" & stColor & ";fill-opacity:1;stroke:none;stroke-width:0px;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1" & coma

            Case e_ShapeType.Line
                    Line = "style=" & coma & "fill:" & "none" & ";stroke:#" & sKColor & ";stroke-width:" & SkWidth & ";stroke-dasharray:" & DashA & ";stroke-opacity:" & STrans & ";fill-opacity:" & Trans & coma
            Case e_ShapeType.ClosedShape
                    If _haspattern Then
                        'style="fill:url(#Pat_1PendingMarian);fill-opacity:1.0"
                        Line = "style=" & coma & "fill:url(" & PatternNo & ");fill-opacity:1.0" & coma
                    Else
                        Line = "style=" & coma & "fill:#" & stColor & ";stroke:#" & sKColor & ";stroke-width:" & SkWidth & ";stroke-dasharray:" & DashA & ";stroke-opacity:" & STrans & ";fill-opacity:" & Trans & coma
                    End If
        End Select

        Line = StartLine & Line & EndLine
        If InStr(Line, "</text>", CompareMethod.Text) > 0 Then
            _ShapeType = e_ShapeType.ClosedShape
        End If
    End Sub
    Private Sub GenerateFill(ByRef Line As String)
        Dim EndLine As String = ""
        Dim StartLine As String = ""
        Dim temp As String() = Split(Line, "fill")
        If temp.Count > 1 Then StartLine = temp(0)
        If ((InStr(Line, ">", CompareMethod.Text) > 0) And (InStr(Line, "/>", CompareMethod.Text) < 1)) Then
            temp = Split(Line, ">")
            If temp.Count > 1 Then
                For inx As Integer = 1 To temp.Count - 2
                    EndLine = ">" & EndLine & temp(inx)
                Next
                If Line.Chars(Len(Line) - 1) = ">" Then EndLine &= ">"
            Else
                EndLine = ">"
            End If
        ElseIf InStr(Line, "/>", CompareMethod.Text) > 0 Then
            temp = Split(Line, "/>")
            EndLine = "/>"
            If temp.Count > 1 Then
                EndLine &= temp(1)
            End If
        End If
        If _ShapeType = e_ShapeType.Line Then
            Line = "fill=" & coma & "none" & coma
        Else
            If ((_haspattern) And (_ShapeType = e_ShapeType.ClosedShape)) Then
                If PatternNo <> "" Then
                    Line = "style=" & coma & "fill:url(" & PatternNo & ");fill-opacity:1.0" & coma
                Else
                    Line = String.Format("fill={0}#{1}{0}", coma, stColor)
                End If
            Else
                Line = String.Format("fill={0}#{1}{0}", coma, stColor)
            End If
            End If
        Line = StartLine & Line & EndLine
    End Sub
    Private Sub GenerateStroke(ByRef Line As String)
        Dim EndLine As String = ""
        Dim StartLine As String = ""
        Dim temp As String() = Split(Line, "stroke=")
        If temp.Count > 1 Then StartLine = temp(0)
        If ((InStr(Line, ">", CompareMethod.Text) > 0) And (InStr(Line, "/>", CompareMethod.Text) < 1)) Then
            temp = Split(Line, ">")
            If temp.Count > 1 Then
                For inx As Integer = 1 To temp.Count - 2
                    EndLine = ">" & EndLine & temp(inx)
                Next
                If Line.Chars(Len(Line) - 1) = ">" Then EndLine &= ">"
            Else
                EndLine = ">"
            End If
        ElseIf InStr(Line, "/>", CompareMethod.Text) > 0 Then
            temp = Split(Line, "/>")
            EndLine = "/>"
            If temp.Count > 1 Then
                EndLine &= temp(1)
            End If
        End If
        Line = String.Format("stroke={0}#{1}{0}", coma, sKColor)
        Line = StartLine & Line & EndLine
    End Sub
    Private Sub GenerateStrokeWidth(ByRef Line As String)
        Dim EndLine As String = ""
        Dim StartLine As String = ""
        Dim temp As String() = Split(Line, "stroke-width=")
        If temp.Count > 1 Then StartLine = temp(0)
        If ((InStr(Line, ">", CompareMethod.Text) > 0) And (InStr(Line, "/>", CompareMethod.Text) < 1)) Then
            temp = Split(Line, ">")
            If temp.Count > 1 Then
                For inx As Integer = 1 To temp.Count - 2
                    EndLine = ">" & EndLine & temp(inx)
                Next
                If Line.Chars(Len(Line) - 1) = ">" Then EndLine &= ">"
            Else
                EndLine = ">"
            End If
        ElseIf InStr(Line, "/>", CompareMethod.Text) > 0 Then
            temp = Split(Line, "/>")
            EndLine = "/>"
            If temp.Count > 1 Then
                EndLine &= temp(1)
            End If
        End If

        Select Case _ShapeType
            Case e_ShapeType.Text
                Line = "stroke-width=" & coma & "0" & coma
            Case e_ShapeType.Line
            Case e_ShapeType.ClosedShape
                Line = String.Format("stroke-width={0}{1}{0}", coma, SkWidth)
        End Select
        Line = StartLine & Line & EndLine
    End Sub
    Private Sub ParseSvg(ByRef Line As String, ByRef dtTag As DataTable)
        Try

            If ((InStr(Line, "<", CompareMethod.Text) > 0) And (InStr(Line, "text", CompareMethod.Text) < 1) And (InStr(Line, "tspan", CompareMethod.Text) < 1) And (InStr(Line, "flowPara", CompareMethod.Text) < 1) And (InStr(Line, "flowRoot", CompareMethod.Text) < 1)) Then
                _ShapeType = e_ShapeType.ClosedShape
            End If


            If InStr(Line, "sodipodi:absref=", CompareMethod.Text) > 0 Then
                CopyImageLink(Line)
                Exit Sub
            End If

            If InStr(Line, _StartGroup, CompareMethod.Text) > 0 Then
                IsUpdate = True
                Exit Sub
            End If
            If InStr(Line, _EndGroup, CompareMethod.Text) > 0 Then
                IsUpdate = False
            End If

            If Not IsUpdate Then Exit Sub

            If InStr(Line, "id=" & coma & "g", CompareMethod.Text) > 0 Then   'IDs
                ' GroupID ================================
                'Get Color 
                ClearColor()
                dr = dtTag.Select(String.Format("tag = '{0}'", Groups.GetGroupName(GroupID(Line)))) 'Color
                If UBound(dr) >= 0 Then
                    stColor = HexaValue_Color(GetFileColor(dr(0).Item("status")))   'Color
                    sKColor = HexaValue_Color(GetStrokeColor(dr(0).Item("status")))   'Stroke Color
                    Trans = GetTrans(dr(0).Item("status"))  'Trans
                    SkWidth = GetStrokeWidth(dr(0).Item("status"))  'Trans
                    DashA = GetDashArrary(dr(0).Item("status"))  'Dash Array
                    STrans = GetStrokeTrans(dr(0).Item("status"))
                    If _haspattern Then PatternNo = String.Format("#Pat_{0}{1}", dr(0).Item("PatternNo"), dr(0).Item("status"))
                End If
                Exit Sub
            End If
            '=============================================

            'Text ==================================================

            If InStr(Line, "<text", CompareMethod.Text) > 0 Then
                _ShapeType = e_ShapeType.Text
                Exit Sub
            End If
            If InStr(Line, "<flowRoot", CompareMethod.Text) > 0 Then
                _ShapeType = e_ShapeType.Text
                Exit Sub
            End If
            If InStr(Line, "<tspan", CompareMethod.Text) > 0 Then
                _ShapeType = e_ShapeType.Text
                Exit Sub
            End If

            If ((InStr(Line, "<", CompareMethod.Text) > 0) And (InStr(Line, "</text>", CompareMethod.Text) < 1) And ((InStr(Line, "</tspan>", CompareMethod.Text) < 1)) And ((InStr(Line, "</flowPara>", CompareMethod.Text) < 1)) And ((InStr(Line, "</flowRoot>", CompareMethod.Text) < 1))) Then
                _ShapeType = e_ShapeType.ClosedShape
                If InStr(Line, "<text", CompareMethod.Text) > 0 Then _ShapeType = e_ShapeType.Text
                If InStr(Line, "<tspan", CompareMethod.Text) > 0 Then _ShapeType = e_ShapeType.Text
                If InStr(Line, "<flowPara", CompareMethod.Text) > 0 Then _ShapeType = e_ShapeType.Text
            End If

            ' =========================================
            'Polylines ==================================================
            If InStr(Line, "<line", CompareMethod.Text) > 0 Then
                _ShapeType = e_ShapeType.Line
                Exit Sub
            End If
            If InStr(Line, "<polyline", CompareMethod.Text) > 0 Then
                _ShapeType = e_ShapeType.Line
                Exit Sub
            End If
            ' =========================================

            'Style ================================
            If InStr(Line, "style", CompareMethod.Text) > 0 Then
                If InStr(Line, "style=" & coma & "display:inline", CompareMethod.Text) > 0 Then
                Else
                    GenerateStyle(Line)
                End If
                Exit Sub
            End If
            '======================================

            'Fill ================================
            If InStr(Line, "fill=", CompareMethod.Text) > 0 Then
                GenerateFill(Line)
                Exit Sub
            End If
            '=====================================

            'Stroke ================================
            If InStr(Line, "stroke=", CompareMethod.Text) > 0 Then
                GenerateStroke(Line)
                Exit Sub
            End If
            '=====================================

            'Stroke-Width ================================
            If InStr(Line, "stroke-width=", CompareMethod.Text) > 0 Then
                GenerateStrokeWidth(Line)
                Exit Sub
            End If
            '=====================================

        Catch ex As Exception

        End Try


    End Sub
#End Region
#Region "Methods"
    Public Sub Generate(ByRef SVGPath As String, ByVal HasPattern As Boolean, ByRef DT As DataTable, ByVal SeqName As String, CanReplaceTag As Boolean)
        _haspattern = HasPattern
        _svgPath = st.GetFileDirectory(SVGPath)
        DivideGroups(SVGPath)
        CopyToTemp(SVGPath)
        UpdateColor(HasPattern, DT, SeqName, st.GetFileName(SVGPath), CanReplaceTag)
        RaiseEvent EditFinished()
    End Sub
#End Region


End Class
