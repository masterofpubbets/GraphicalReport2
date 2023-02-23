Imports DevExpress.XtraBars

Public Class frmAddSet
    Public isAdded As Boolean = False
    Public conn As New Connections.stDBonnection
    Public cutoffDateConn As New Connections.stDBonnection
    Private drawingSetCol As New DrawingSets.st_Drawings
    Private drawingSet As New DrawingSets
    Public isForEdit As Boolean = False
    Public DrawingSetId As Integer = -1
    Public clientLogoPath As String = ""

    Public Sub New(Optional ByVal forEdit As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        isForEdit = forEdit


    End Sub

    Public Sub SetMainConn(ByVal Mainconn As Connections.stDBonnection)
        conn.ConnName = Mainconn.ConnName
        conn.ConnType = Mainconn.ConnType
        conn.DBNmae = Mainconn.DBNmae
        conn.ID = Mainconn.ID
        conn.URl = Mainconn.URl
    End Sub
    Public Sub SetCutoffDateConn(ByVal Cutoffconn As Connections.stDBonnection)
        cutoffDateConn.ConnName = Cutoffconn.ConnName
        cutoffDateConn.ConnType = Cutoffconn.ConnType
        cutoffDateConn.DBNmae = Cutoffconn.DBNmae
        cutoffDateConn.ID = Cutoffconn.ID
        cutoffDateConn.URl = Cutoffconn.URl
    End Sub

    Private Function IsValidate() As Boolean
        If Trim(txtSetName.Text) = "" Then
            MsgBox("Please type Set Name!", MsgBoxStyle.Exclamation, Me.Text)
            txtSetName.Focus()
            Return False
        End If

        If Not isForEdit Then
            If drawingSet.CheckExists(txtSetName.Text) Then
                MsgBox("Set Name already exists!", MsgBoxStyle.Exclamation, Me.Text)
                txtSetName.Focus()
                Return False
            End If
        End If

        If lblQueryPath.Text = "---" Then
            MsgBox("Please create a query!", MsgBoxStyle.Exclamation, Me.Text)
            SimpleButton3.Focus()
            Return False
        End If
        If lblDrawingFolder.Text = "---" Then
            MsgBox("Please select the Drawing folder!", MsgBoxStyle.Exclamation, Me.Text)
            SimpleButton6.Focus()
            Return False
        End If
        If lblOutputFolder.Text = "---" Then
            MsgBox("Please select the Output Folder!", MsgBoxStyle.Exclamation, Me.Text)
            SimpleButton3.Focus()
            Return False
        End If
        If lblDrawingHeader.Text = "---" Then
            MsgBox("Please select the Drawing Header!", MsgBoxStyle.Exclamation, Me.Text)
            SimpleButton8.Focus()
            Return False
        End If
        If lblDrawingSubheader.Text = "---" Then
            MsgBox("Please select the Drawing Subheader!", MsgBoxStyle.Exclamation, Me.Text)
            SimpleButton9.Focus()
            Return False
        End If
        If lblCutoffDate.Text = "---" Then
            MsgBox("Please select the Drawing Cutoff Date!", MsgBoxStyle.Exclamation, Me.Text)
            SimpleButton9.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Try
            Dim frm As New frmSelectLayout
            frm.ShowDialog(Me)
            If frm.isSelected Then
                lblLayoutName.Text = frm.layoutName
                picLayout.Image = Image.FromFile(Application.StartupPath & "\templates\layouts\images\" & frm.layoutName & ".jpg")
                Select Case frm.layoutName
                    Case "Default", "Layout2", "Layout4"
                        lblPhotoFolderPath.Visible = False
                        btnSelectPhotoPath.Enabled = False
                    Case Else
                        lblPhotoFolderPath.Visible = True
                        btnSelectPhotoPath.Enabled = True

                End Select
                Select Case frm.layoutName
                    Case "Layout9", "Layout10"
                        picClient.Visible = True
                        SimpleButton13.Enabled = True
                    Case Else
                        picClient.Visible = False
                        SimpleButton13.Enabled = False
                End Select
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmAddSet_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Normal
    End Sub


    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim frm As New frmQueryCheck(conn.ConnName, conn.ConnType, conn.URl, conn.ID, conn.DBNmae, lblQueryPath.Text)
        If lblQueryPath.Text <> "---" Then

            Dim obj As New System.IO.StreamReader(lblQueryPath.Text)
            frm.txtQuery.Text = obj.ReadToEnd
            obj.Close()
            If conn.ConnType = "EXCEL" Then
                frm.lblConDBName.Visible = False
            Else
                frm.lblConDBName.Visible = True
            End If
        End If
        frm.ShowDialog(Me)
        If frm.isSelect Then
            lblQueryPath.Text = frm.QueryPath
            conn.ConnName = frm.Conn.ConnName
            conn.ConnType = frm.Conn.ConnType
            conn.DBNmae = frm.Conn.DBNmae
            conn.ID = frm.Conn.ID
            conn.URl = frm.Conn.URl
            lblDBSet.Text = frm.Conn.ConnName
        End If
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        fld.SelectedPath = ""
        fld.ShowDialog()
        If fld.SelectedPath <> "" Then
            lblDrawingFolder.Text = fld.SelectedPath
        End If
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        fld.SelectedPath = ""
        fld.ShowDialog()
        If fld.SelectedPath <> "" Then
            lblSummaryFolder.Text = fld.SelectedPath
        End If
    End Sub

    Private Sub btnSelectPhotoPath_Click(sender As Object, e As EventArgs) Handles btnSelectPhotoPath.Click
        fld.SelectedPath = ""
        fld.ShowDialog()
        If fld.SelectedPath <> "" Then
            lblPhotoFolderPath.Text = fld.SelectedPath
        End If
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        Dim frm As New frmSelectDrawingHeader

        If Len(lblDrawingHeader.Text) > 6 Then
            If lblDrawingHeader.Text = "$(NAME)" Then
                frm.rDrawingName.Checked = True
            ElseIf InStr(Len(lblDrawingHeader.Text) - 6, lblDrawingHeader.Text, "$(NAME)", CompareMethod.Text) Then
                frm.rgpNameCustom.Checked = True
                frm.rStart.Checked = True
                frm.txtCustomHeader.Text = Replace(lblDrawingHeader.Text, "$(NAME)", "",,, CompareMethod.Text)
                frm.txtCustomHeader.Focus()
            ElseIf InStr(1, lblDrawingHeader.Text, "$(NAME)", CompareMethod.Text) And lblDrawingHeader.Text.Chars(0) = "$" Then
                frm.rgpNameCustom.Checked = True
                frm.rEnd.Checked = True
                frm.txtCustomHeader.Text = Replace(lblDrawingHeader.Text, "$(NAME)", "",,, CompareMethod.Text)
                frm.txtCustomHeader.Focus()
            Else
                frm.rCustom.Checked = True
                If lblDrawingHeader.Text <> "---" Then frm.txtHeader.Text = lblDrawingHeader.Text
                frm.txtHeader.Focus()
            End If
        Else
            frm.rCustom.Checked = True
            If lblDrawingHeader.Text <> "---" Then frm.txtHeader.Text = lblDrawingHeader.Text
            frm.txtHeader.Focus()
        End If

        frm.ShowDialog(Me)
        If frm.isSelected Then
            lblDrawingHeader.Text = frm.header
        End If
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        Dim frm As New frmSelectDrawingHeader
        frm.Text = "Select Drawing Subheader"
        If Len(lblDrawingHeader2.Text) > 6 Then
            If lblDrawingHeader2.Text = "$(NAME)" Then
                frm.rDrawingName.Checked = True
            ElseIf InStr(Len(lblDrawingHeader2.Text) - 6, lblDrawingHeader2.Text, "$(NAME)", CompareMethod.Text) Then
                frm.rgpNameCustom.Checked = True
                frm.rStart.Checked = True
                frm.txtCustomHeader.Text = Replace(lblDrawingHeader2.Text, "$(NAME)", "",,, CompareMethod.Text)
                frm.txtCustomHeader.Focus()
            ElseIf InStr(1, lblDrawingHeader2.Text, "$(NAME)", CompareMethod.Text) And lblDrawingHeader2.Text.Chars(0) = "$" Then
                frm.rgpNameCustom.Checked = True
                frm.rEnd.Checked = True
                frm.txtCustomHeader.Text = Replace(lblDrawingHeader2.Text, "$(NAME)", "",,, CompareMethod.Text)
                frm.txtCustomHeader.Focus()
            Else
                frm.rCustom.Checked = True
                If lblDrawingHeader2.Text <> "---" Then frm.txtHeader.Text = lblDrawingHeader2.Text
                frm.txtHeader.Focus()
            End If
        Else
            frm.rCustom.Checked = True
            If lblDrawingHeader2.Text <> "---" Then frm.txtHeader.Text = lblDrawingHeader2.Text
            frm.txtHeader.Focus()
        End If

        frm.ShowDialog(Me)
        If frm.isSelected Then
            lblDrawingHeader2.Text = frm.header
        End If
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        Dim frm As New frmSelectCutoffDate(cutoffDateConn.ConnName, cutoffDateConn.ConnType, cutoffDateConn.DBNmae, cutoffDateConn.ID, cutoffDateConn.URl)
        Select Case lblCutoffDate.Text
            Case "$(PRINTDATE)"
                frm.rPrintDate.Checked = True
            Case "$(NONE)"
                frm.rNoDate.Checked = True
            Case Else
                frm.rQuery.Checked = True
                frm.txtSQL.Text = lblCutoffDate.Text
        End Select


        frm.ShowDialog(Me)
        If frm.isSelect Then
            lblCutoffDate.Text = frm.Query
            If frm.Query <> "$(PRINTDATE)" Or frm.Query <> "$(NONE)" Then
                cutoffDateConn.ConnName = frm.Conn.ConnName
                cutoffDateConn.ConnType = frm.Conn.ConnType
                cutoffDateConn.DBNmae = frm.Conn.DBNmae
                cutoffDateConn.ID = frm.Conn.ID
                cutoffDateConn.URl = frm.Conn.URl
            End If
        End If
    End Sub

    Private Sub frmAddSet_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not isForEdit Then
            picLayout.Image = Image.FromFile(Application.StartupPath & "\templates\layouts\images\" & "Default" & ".jpg")
            btnSelectPhotoPath.Enabled = False
        End If
        If clientLogoPath <> "" Then
            Try
                picClient.Image = Image.FromFile(clientLogoPath)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If IsValidate() Then

            drawingSetCol.SetName = txtSetName.Text
            drawingSetCol.ConId = conn.ID
            drawingSetCol.CutoffConId = cutoffDateConn.ID
            drawingSetCol.FolderPath = lblDrawingFolder.Text
            If ckPattern.Checked Then
                drawingSetCol.HasPattern = 1
            Else
                drawingSetCol.HasPattern = 0
            End If
            If ckTagDash.Checked Then
                drawingSetCol.TagHasDash = 1
            Else
                drawingSetCol.TagHasDash = 0
            End If
            drawingSetCol.Layout = lblLayoutName.Text
            drawingSetCol.Header = lblDrawingHeader.Text
            drawingSetCol.Header2 = lblDrawingHeader2.Text
            drawingSetCol.Header3 = lblDrawingHeader3.Text
            drawingSetCol.OutputFolderPath = lblOutputFolder.Text
            drawingSetCol.PhotoFolderPath = lblPhotoFolderPath.Text
            drawingSetCol.QueryPath = lblQueryPath.Text
            drawingSetCol.QuerySummaryFolderPath = lblSummaryFolder.Text
            drawingSetCol.ReplaceTag = 0
            drawingSetCol.Subheader = lblDrawingSubheader.Text
            drawingSetCol.CutoffDate = lblCutoffDate.Text
            drawingSetCol.ClientLogoPath = clientLogoPath

            If Not isForEdit Then
                If drawingSet.Add(drawingSetCol) Then
                    MsgBox("Drawing Set Has Been Added.", MsgBoxStyle.Information, Me.Text)
                    isAdded = True
                    Me.Close()
                End If
            Else
                If drawingSet.Edit(drawingSetCol, DrawingSetId) Then
                    MsgBox("Drawing Set Has Been Saved.", MsgBoxStyle.Information, Me.Text)
                    isAdded = True
                    Me.Close()
                End If
            End If

        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        fld.SelectedPath = ""
        fld.Title = "Select Output Folder"
        fld.ShowDialog()
        If fld.SelectedPath = "" Then Exit Sub
        lblOutputFolder.Text = fld.SelectedPath
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        Dim frm As New frmSelectDrawingHeader
        frm.Text = "Select Drawing Subheader"
        If Len(lblDrawingSubheader.Text) > 6 Then
            If lblDrawingSubheader.Text = "$(NAME)" Then
                frm.rDrawingName.Checked = True
            ElseIf InStr(Len(lblDrawingSubheader.Text) - 6, lblDrawingSubheader.Text, "$(NAME)", CompareMethod.Text) Then
                frm.rgpNameCustom.Checked = True
                frm.rStart.Checked = True
                frm.txtCustomHeader.Text = Replace(lblDrawingSubheader.Text, "$(NAME)", "",,, CompareMethod.Text)
                frm.txtCustomHeader.Focus()
            ElseIf InStr(1, lblDrawingSubheader.Text, "$(NAME)", CompareMethod.Text) And lblDrawingSubheader.Text.Chars(0) = "$" Then
                frm.rgpNameCustom.Checked = True
                frm.rEnd.Checked = True
                frm.txtCustomHeader.Text = Replace(lblDrawingSubheader.Text, "$(NAME)", "",,, CompareMethod.Text)
                frm.txtCustomHeader.Focus()
            Else
                frm.rCustom.Checked = True
                If lblDrawingSubheader.Text <> "---" Then frm.txtHeader.Text = lblDrawingSubheader.Text
                frm.txtHeader.Focus()
            End If
        Else
            frm.rCustom.Checked = True
            If lblDrawingSubheader.Text <> "---" Then frm.txtHeader.Text = lblDrawingSubheader.Text
            frm.txtHeader.Focus()
        End If

        frm.ShowDialog(Me)
        If frm.isSelected Then
            lblDrawingSubheader.Text = frm.header
        End If
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        Dim frm As New frmSelectDrawingHeader
        frm.Text = "Select Drawing Subheader"
        If Len(lblDrawingHeader3.Text) > 6 Then
            If lblDrawingHeader3.Text = "$(NAME)" Then
                frm.rDrawingName.Checked = True
            ElseIf InStr(Len(lblDrawingHeader3.Text) - 6, lblDrawingHeader3.Text, "$(NAME)", CompareMethod.Text) Then
                frm.rgpNameCustom.Checked = True
                frm.rStart.Checked = True
                frm.txtCustomHeader.Text = Replace(lblDrawingHeader3.Text, "$(NAME)", "",,, CompareMethod.Text)
                frm.txtCustomHeader.Focus()
            ElseIf InStr(1, lblDrawingHeader3.Text, "$(NAME)", CompareMethod.Text) And lblDrawingHeader3.Text.Chars(0) = "$" Then
                frm.rgpNameCustom.Checked = True
                frm.rEnd.Checked = True
                frm.txtCustomHeader.Text = Replace(lblDrawingHeader3.Text, "$(NAME)", "",,, CompareMethod.Text)
                frm.txtCustomHeader.Focus()
            Else
                frm.rCustom.Checked = True
                If lblDrawingHeader3.Text <> "---" Then frm.txtHeader.Text = lblDrawingHeader3.Text
                frm.txtHeader.Focus()
            End If
        Else
            frm.rCustom.Checked = True
            If lblDrawingHeader3.Text <> "---" Then frm.txtHeader.Text = lblDrawingHeader3.Text
            frm.txtHeader.Focus()
        End If

        frm.ShowDialog(Me)
        If frm.isSelected Then
            lblDrawingHeader3.Text = frm.header
        End If
    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButton13.Click
        opnFle.FileName = ""
        opnFle.ShowDialog()
        If opnFle.FileName = "" Then Exit Sub
        Try
            picClient.Image = Image.FromFile(opnFle.FileName)
            clientLogoPath = opnFle.FileName
        Catch ex As Exception
            picClient.Image = Nothing
            MsgBox("There is an error while loading the image!", MsgBoxStyle.Critical, Me.Text)
            clientLogoPath = ""
        End Try

    End Sub
End Class