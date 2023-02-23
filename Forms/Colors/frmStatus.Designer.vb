<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatus
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatus))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lstStatus = New System.Windows.Forms.ListBox()
        Me.lblTTValue = New System.Windows.Forms.Label()
        Me.lblSTValue = New System.Windows.Forms.Label()
        Me.lblSW = New System.Windows.Forms.Label()
        Me.tbST = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCK = New System.Windows.Forms.Label()
        Me.picSS = New System.Windows.Forms.PictureBox()
        Me.cmbSStyle = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbW = New System.Windows.Forms.TrackBar()
        Me.ck = New DevExpress.XtraEditors.ColorPickEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tt = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.cs = New DevExpress.XtraEditors.ColorPickEdit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.tbST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarButtonItem4, Me.BarButtonItem5})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 6
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.Size = New System.Drawing.Size(1198, 196)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Refresh"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "New"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.ImageOptions.Image = CType(resources.GetObject("BarButtonItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Delete"
        Me.BarButtonItem3.Id = 3
        Me.BarButtonItem3.ImageOptions.Image = CType(resources.GetObject("BarButtonItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem3.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        Me.BarButtonItem3.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Copy To"
        Me.BarButtonItem4.Id = 4
        Me.BarButtonItem4.ImageOptions.Image = CType(resources.GetObject("BarButtonItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem4.Name = "BarButtonItem4"
        Me.BarButtonItem4.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "Save"
        Me.BarButtonItem5.Id = 5
        Me.BarButtonItem5.ImageOptions.Image = CType(resources.GetObject("BarButtonItem5.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem5.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem5.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem5.Name = "BarButtonItem5"
        Me.BarButtonItem5.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.ImageOptions.Image = CType(resources.GetObject("RibbonPage1.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Status"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem5)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem3)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem4)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Data Options"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 196)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstStatus)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblTTValue)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSTValue)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblSW)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbST)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblCK)
        Me.SplitContainer1.Panel2.Controls.Add(Me.picSS)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbSStyle)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbW)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ck)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.tt)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblColor)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cs)
        Me.SplitContainer1.Size = New System.Drawing.Size(1198, 503)
        Me.SplitContainer1.SplitterDistance = 467
        Me.SplitContainer1.TabIndex = 1
        '
        'lstStatus
        '
        Me.lstStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstStatus.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lstStatus.FormattingEnabled = True
        Me.lstStatus.ItemHeight = 18
        Me.lstStatus.Location = New System.Drawing.Point(0, 0)
        Me.lstStatus.Name = "lstStatus"
        Me.lstStatus.Size = New System.Drawing.Size(465, 501)
        Me.lstStatus.TabIndex = 0
        '
        'lblTTValue
        '
        Me.lblTTValue.ForeColor = System.Drawing.Color.Black
        Me.lblTTValue.Location = New System.Drawing.Point(168, 118)
        Me.lblTTValue.Name = "lblTTValue"
        Me.lblTTValue.Size = New System.Drawing.Size(523, 22)
        Me.lblTTValue.TabIndex = 38
        Me.lblTTValue.Text = "0"
        Me.lblTTValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSTValue
        '
        Me.lblSTValue.ForeColor = System.Drawing.Color.Black
        Me.lblSTValue.Location = New System.Drawing.Point(168, 346)
        Me.lblSTValue.Name = "lblSTValue"
        Me.lblSTValue.Size = New System.Drawing.Size(523, 22)
        Me.lblSTValue.TabIndex = 6
        Me.lblSTValue.Text = "1"
        Me.lblSTValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSW
        '
        Me.lblSW.ForeColor = System.Drawing.Color.Black
        Me.lblSW.Location = New System.Drawing.Point(168, 255)
        Me.lblSW.Name = "lblSW"
        Me.lblSW.Size = New System.Drawing.Size(523, 22)
        Me.lblSW.TabIndex = 4
        Me.lblSW.Text = "0.4"
        Me.lblSW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbST
        '
        Me.tbST.Location = New System.Drawing.Point(235, 302)
        Me.tbST.Maximum = 100
        Me.tbST.Name = "tbST"
        Me.tbST.Size = New System.Drawing.Size(456, 56)
        Me.tbST.TabIndex = 5
        Me.tbST.Value = 100
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(644, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 17)
        Me.Label4.TabIndex = 34
        '
        'lblCK
        '
        Me.lblCK.BackColor = System.Drawing.Color.Black
        Me.lblCK.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCK.Location = New System.Drawing.Point(633, 151)
        Me.lblCK.Name = "lblCK"
        Me.lblCK.Size = New System.Drawing.Size(72, 49)
        Me.lblCK.TabIndex = 33
        Me.lblCK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picSS
        '
        Me.picSS.Location = New System.Drawing.Point(290, 403)
        Me.picSS.Name = "picSS"
        Me.picSS.Size = New System.Drawing.Size(221, 85)
        Me.picSS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSS.TabIndex = 32
        Me.picSS.TabStop = False
        '
        'cmbSStyle
        '
        Me.cmbSStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSStyle.FormattingEnabled = True
        Me.cmbSStyle.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19"})
        Me.cmbSStyle.Location = New System.Drawing.Point(171, 403)
        Me.cmbSStyle.Name = "cmbSStyle"
        Me.cmbSStyle.Size = New System.Drawing.Size(97, 24)
        Me.cmbSStyle.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(14, 405)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 22)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Stroke Style:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(14, 312)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(215, 22)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Stroke Transparent:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(14, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(215, 22)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Stroke Width:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbW
        '
        Me.tbW.Location = New System.Drawing.Point(235, 212)
        Me.tbW.Maximum = 400
        Me.tbW.Minimum = 10
        Me.tbW.Name = "tbW"
        Me.tbW.Size = New System.Drawing.Size(470, 56)
        Me.tbW.TabIndex = 3
        Me.tbW.Value = 40
        '
        'ck
        '
        Me.ck.EditValue = System.Drawing.Color.Empty
        Me.ck.Location = New System.Drawing.Point(171, 164)
        Me.ck.MenuManager = Me.RibbonControl1
        Me.ck.Name = "ck"
        Me.ck.Properties.AutomaticColor = System.Drawing.Color.Black
        Me.ck.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ck.Size = New System.Drawing.Size(444, 22)
        Me.ck.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 20)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Stroke Color:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(14, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(215, 22)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Fill Color Transparency:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tt
        '
        Me.tt.Location = New System.Drawing.Point(235, 84)
        Me.tt.Maximum = 100
        Me.tt.Name = "tt"
        Me.tt.Size = New System.Drawing.Size(456, 56)
        Me.tt.TabIndex = 1
        Me.tt.Value = 100
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Fill Color:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblColor
        '
        Me.lblColor.BackColor = System.Drawing.Color.Black
        Me.lblColor.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblColor.Location = New System.Drawing.Point(643, 24)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(48, 48)
        Me.lblColor.TabIndex = 16
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cs
        '
        Me.cs.EditValue = System.Drawing.Color.Empty
        Me.cs.Location = New System.Drawing.Point(171, 37)
        Me.cs.MenuManager = Me.RibbonControl1
        Me.cs.Name = "cs"
        Me.cs.Properties.AutomaticColor = System.Drawing.Color.Black
        Me.cs.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cs.Size = New System.Drawing.Size(444, 22)
        Me.cs.TabIndex = 0
        '
        'frmStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 699)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmStatus.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmStatus"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Status"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.tbST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lstStatus As ListBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tt As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents lblColor As Label
    Friend WithEvents cs As DevExpress.XtraEditors.ColorPickEdit
    Friend WithEvents tbST As TrackBar
    Friend WithEvents Label4 As Label
    Friend WithEvents lblCK As Label
    Friend WithEvents picSS As PictureBox
    Friend WithEvents cmbSStyle As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tbW As TrackBar
    Friend WithEvents ck As DevExpress.XtraEditors.ColorPickEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents lblSTValue As Label
    Friend WithEvents lblSW As Label
    Friend WithEvents lblTTValue As Label
End Class
