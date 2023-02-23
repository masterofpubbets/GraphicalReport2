<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQueryCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQueryCheck))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.lblValid = New DevExpress.XtraBars.BarStaticItem()
        Me.lblNotValid = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.lblQueryPath = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblConName = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblConDBName = New System.Windows.Forms.Label()
        Me.lblConURL = New System.Windows.Forms.Label()
        Me.lblDBType = New System.Windows.Forms.Label()
        Me.lblConDBNameHeader = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.opnFle = New System.Windows.Forms.OpenFileDialog()
        Me.sveFle = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarButtonItem4, Me.BarButtonItem5, Me.lblValid, Me.lblNotValid})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 9
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.Size = New System.Drawing.Size(1198, 196)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Select Database"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Save and Close"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.ImageOptions.Image = CType(resources.GetObject("BarButtonItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Clear"
        Me.BarButtonItem3.Id = 3
        Me.BarButtonItem3.ImageOptions.Image = CType(resources.GetObject("BarButtonItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem3.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        Me.BarButtonItem3.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Execute"
        Me.BarButtonItem4.Id = 4
        Me.BarButtonItem4.ImageOptions.Image = CType(resources.GetObject("BarButtonItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem4.Name = "BarButtonItem4"
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "Select Query File"
        Me.BarButtonItem5.Id = 5
        Me.BarButtonItem5.ImageOptions.Image = CType(resources.GetObject("BarButtonItem5.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem5.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem5.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem5.Name = "BarButtonItem5"
        Me.BarButtonItem5.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'lblValid
        '
        Me.lblValid.Caption = "Valid"
        Me.lblValid.Id = 6
        Me.lblValid.ImageOptions.Image = CType(resources.GetObject("lblValid.ImageOptions.Image"), System.Drawing.Image)
        Me.lblValid.ImageOptions.LargeImage = CType(resources.GetObject("lblValid.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.lblValid.Name = "lblValid"
        Me.lblValid.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.lblValid.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        Me.lblValid.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        '
        'lblNotValid
        '
        Me.lblNotValid.Caption = "Not Valid"
        Me.lblNotValid.Id = 8
        Me.lblNotValid.ImageOptions.Image = CType(resources.GetObject("lblNotValid.ImageOptions.Image"), System.Drawing.Image)
        Me.lblNotValid.ImageOptions.LargeImage = CType(resources.GetObject("lblNotValid.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.lblNotValid.Name = "lblNotValid"
        Me.lblNotValid.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2, Me.RibbonPageGroup1})
        Me.RibbonPage1.ImageOptions.Image = CType(resources.GetObject("RibbonPage1.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Query Editor"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem3)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem5)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Editor Options"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem4)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.lblValid)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.lblNotValid)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Query Options"
        '
        'txtQuery
        '
        Me.txtQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuery.Location = New System.Drawing.Point(0, 414)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtQuery.Size = New System.Drawing.Size(1198, 285)
        Me.txtQuery.TabIndex = 1
        '
        'lblQueryPath
        '
        Me.lblQueryPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQueryPath.Location = New System.Drawing.Point(123, 218)
        Me.lblQueryPath.Name = "lblQueryPath"
        Me.lblQueryPath.Size = New System.Drawing.Size(980, 23)
        Me.lblQueryPath.TabIndex = 22
        Me.lblQueryPath.Text = "---"
        Me.lblQueryPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 17)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Main Query:"
        '
        'lblConName
        '
        Me.lblConName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblConName.Location = New System.Drawing.Point(123, 248)
        Me.lblConName.Name = "lblConName"
        Me.lblConName.Size = New System.Drawing.Size(980, 26)
        Me.lblConName.TabIndex = 39
        Me.lblConName.Text = "---"
        Me.lblConName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 254)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 17)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Name:"
        '
        'lblConDBName
        '
        Me.lblConDBName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblConDBName.Location = New System.Drawing.Point(123, 349)
        Me.lblConDBName.Name = "lblConDBName"
        Me.lblConDBName.Size = New System.Drawing.Size(980, 26)
        Me.lblConDBName.TabIndex = 37
        Me.lblConDBName.Text = "---"
        Me.lblConDBName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConURL
        '
        Me.lblConURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblConURL.Location = New System.Drawing.Point(123, 315)
        Me.lblConURL.Name = "lblConURL"
        Me.lblConURL.Size = New System.Drawing.Size(980, 26)
        Me.lblConURL.TabIndex = 36
        Me.lblConURL.Text = "---"
        Me.lblConURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDBType
        '
        Me.lblDBType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDBType.Location = New System.Drawing.Point(123, 281)
        Me.lblDBType.Name = "lblDBType"
        Me.lblDBType.Size = New System.Drawing.Size(980, 26)
        Me.lblDBType.TabIndex = 35
        Me.lblDBType.Text = "---"
        Me.lblDBType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConDBNameHeader
        '
        Me.lblConDBNameHeader.AutoSize = True
        Me.lblConDBNameHeader.Location = New System.Drawing.Point(12, 353)
        Me.lblConDBNameHeader.Name = "lblConDBNameHeader"
        Me.lblConDBNameHeader.Size = New System.Drawing.Size(70, 17)
        Me.lblConDBNameHeader.TabIndex = 34
        Me.lblConDBNameHeader.Text = "DB Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 319)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Location:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 287)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 17)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Type:"
        '
        'sveFle
        '
        Me.sveFle.Filter = "Excel File|*.xlsx"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Excel File|*.xlsx"
        '
        'frmQueryCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 699)
        Me.Controls.Add(Me.lblConName)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblConDBName)
        Me.Controls.Add(Me.lblConURL)
        Me.Controls.Add(Me.lblDBType)
        Me.Controls.Add(Me.lblConDBNameHeader)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblQueryPath)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmQueryCheck.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmQueryCheck"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Query Editor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents txtQuery As TextBox
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents lblQueryPath As Label
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Label2 As Label
    Friend WithEvents lblConName As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblConDBName As Label
    Friend WithEvents lblConURL As Label
    Friend WithEvents lblDBType As Label
    Friend WithEvents lblConDBNameHeader As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents opnFle As OpenFileDialog
    Friend WithEvents lblValid As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents lblNotValid As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents sveFle As SaveFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
