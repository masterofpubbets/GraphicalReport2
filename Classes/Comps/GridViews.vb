Public Class GridViews

    Public Function setView(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal gridName As String) As Boolean
        If IO.Directory.Exists(Application.StartupPath & "\views") Then
            If IO.File.Exists(Application.StartupPath & "\views\" & gridName & ".vws") Then
                Dim dt As New DataTable
                Try
                    dt.ReadXmlSchema(Application.StartupPath & "\views\" & gridName & ".vws")
                    dt.ReadXml(Application.StartupPath & "\views\" & gridName & ".vws")
                    If grdView.Columns.Count <> 0 Then
                        For inx As Integer = 0 To dt.Rows.Count - 1
                            If dt.Rows(inx).Item("Visible") = "0" Then
                                grdView.Columns(dt.Rows(inx).Item("Field Name")).Visible = False
                            Else
                                grdView.Columns(dt.Rows(inx).Item("Field Name")).Visible = True
                            End If
                        Next
                        setViewIndex(grdView, dt)
                    End If
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End If
        End If
        Return False
    End Function
    Public Function setViewFromFile(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal fileName As String) As Boolean
        If IO.File.Exists(fileName) Then
            Dim dt As New DataTable
            Try
                dt.ReadXmlSchema(fileName)
                dt.ReadXml(fileName)
                If grdView.Columns.Count <> 0 Then
                    For inx As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows(inx).Item("Visible") = "0" Then
                            grdView.Columns(dt.Rows(inx).Item("Field Name")).Visible = False
                        Else
                            grdView.Columns(dt.Rows(inx).Item("Field Name")).Visible = True
                        End If
                    Next
                    setViewIndex(grdView, dt)
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If

        Return False
    End Function
    Private Function setViewIndex(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByRef dt As DataTable) As Boolean
        Try
            For inx As Integer = 0 To dt.Rows.Count - 1
                grdView.Columns(dt.Rows(inx).Item("Field Name")).Width = Val(dt.Rows(inx).Item("Width"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).AbsoluteIndex = Val(dt.Rows(inx).Item("AbsoluteIndex"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).GroupIndex = Val(dt.Rows(inx).Item("GroupIndex"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).SortIndex = Val(dt.Rows(inx).Item("SortIndex"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).VisibleIndex = Val(dt.Rows(inx).Item("VisibleIndex"))
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function setDefaultView(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal gridName As String) As Boolean
        If IO.Directory.Exists(Application.StartupPath & "\views\defaults") Then
            If IO.File.Exists(Application.StartupPath & "\views\defaults\" & gridName & ".vws") Then
                Dim dt As New DataTable
                Try
                    dt.ReadXmlSchema(Application.StartupPath & "\views\defaults\" & gridName & ".vws")
                    dt.ReadXml(Application.StartupPath & "\views\defaults\" & gridName & ".vws")
                    For inx As Integer = 0 To dt.Rows.Count - 1
                        If dt.Rows(inx).Item("Visible") = "0" Then
                            grdView.Columns(dt.Rows(inx).Item("Field Name")).Visible = False
                        Else
                            grdView.Columns(dt.Rows(inx).Item("Field Name")).Visible = True
                        End If
                    Next
                    setDefaultViewIndex(grdView, dt)
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End If
        End If
        Return False
    End Function
    Private Function setDefaultViewIndex(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByRef dt As DataTable) As Boolean
        Try
            For inx As Integer = 0 To dt.Rows.Count - 1
                grdView.Columns(dt.Rows(inx).Item("Field Name")).Width = Val(dt.Rows(inx).Item("Width"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).AbsoluteIndex = Val(dt.Rows(inx).Item("AbsoluteIndex"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).GroupIndex = Val(dt.Rows(inx).Item("GroupIndex"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).SortIndex = Val(dt.Rows(inx).Item("SortIndex"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).VisibleIndex = Val(dt.Rows(inx).Item("VisibleIndex"))
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function saveView(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal gridName As String) As Boolean
        Try
            Dim dt As New DataTable
            dt.TableName = gridName
            dt.Columns.Add("Field Name")
            dt.Columns.Add("Visible")
            dt.Columns.Add("Width")
            dt.Columns.Add("AbsoluteIndex")
            dt.Columns.Add("GroupIndex")
            dt.Columns.Add("SortIndex")
            dt.Columns.Add("VisibleIndex")

            For inx As Integer = 0 To grdView.Columns.Count - 1
                If grdView.Columns(inx).Visible Then
                    dt.Rows.Add(grdView.Columns(inx).FieldName, 1, grdView.Columns(inx).Width, grdView.Columns(inx).AbsoluteIndex, grdView.Columns(inx).GroupIndex, grdView.Columns(inx).SortIndex, grdView.Columns(inx).VisibleIndex)
                Else
                    dt.Rows.Add(grdView.Columns(inx).FieldName, 0, grdView.Columns(inx).Width, grdView.Columns(inx).AbsoluteIndex, grdView.Columns(inx).GroupIndex, grdView.Columns(inx).SortIndex, grdView.Columns(inx).VisibleIndex)
                End If
            Next

            dt.WriteXmlSchema(Application.StartupPath & "\views\" & gridName & ".vws", True)
            dt.WriteXml(Application.StartupPath & "\views\" & gridName & ".vws", XmlWriteMode.WriteSchema)

            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function saveViewCustomPath(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal gridName As String, ByVal fileName As String) As Boolean
        Try
            Dim dt As New DataTable
            dt.TableName = gridName
            dt.Columns.Add("Field Name")
            dt.Columns.Add("Visible")
            dt.Columns.Add("Width")
            dt.Columns.Add("AbsoluteIndex")
            dt.Columns.Add("GroupIndex")
            dt.Columns.Add("SortIndex")
            dt.Columns.Add("VisibleIndex")

            For inx As Integer = 0 To grdView.Columns.Count - 1
                If grdView.Columns(inx).Visible Then
                    dt.Rows.Add(grdView.Columns(inx).FieldName, 1, grdView.Columns(inx).Width, grdView.Columns(inx).AbsoluteIndex, grdView.Columns(inx).GroupIndex, grdView.Columns(inx).SortIndex, grdView.Columns(inx).VisibleIndex)
                Else
                    dt.Rows.Add(grdView.Columns(inx).FieldName, 0, grdView.Columns(inx).Width, grdView.Columns(inx).AbsoluteIndex, grdView.Columns(inx).GroupIndex, grdView.Columns(inx).SortIndex, grdView.Columns(inx).VisibleIndex)
                End If
            Next

            Dim fName As String = ""
            If InStr(fileName, ".vws", CompareMethod.Text) > 0 Then
                fName = fileName
            Else
                fName = fileName & ".vws"
            End If

            dt.WriteXmlSchema(fName, True)
            dt.WriteXml(fName, XmlWriteMode.WriteSchema)

            dt.WriteXmlSchema(Application.StartupPath & "\views\" & gridName & ".vws", True)
            dt.WriteXml(Application.StartupPath & "\views\" & gridName & ".vws", XmlWriteMode.WriteSchema)

            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Function CopySelectedItems(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal columnName As String) As Boolean
        Try
            Dim copied As String = ""
            For Each row_handle As Integer In grdView.GetSelectedRows
                copied &= grdView.GetDataRow(row_handle).Item(columnName) & vbCrLf
            Next
            Clipboard.Clear()
            Clipboard.SetText(copied)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
End Class
