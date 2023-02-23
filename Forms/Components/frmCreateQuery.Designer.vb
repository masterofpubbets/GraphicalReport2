<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateQuery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreateQuery))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.btnSqlServer = New DevExpress.XtraBars.BarCheckItem()
        Me.btnExcel = New DevExpress.XtraBars.BarCheckItem()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem2 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem3 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem4 = New DevExpress.XtraBars.BarStaticItem()
        Me.BarStaticItem5 = New DevExpress.XtraBars.BarStaticItem()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.btnSqlServer, Me.btnExcel, Me.BarButtonItem1, Me.BarStaticItem1, Me.BarStaticItem2, Me.BarStaticItem3, Me.BarStaticItem4, Me.BarStaticItem5})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 14
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2})
        Me.RibbonControl1.Size = New System.Drawing.Size(1198, 196)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.ImageOptions.Image = CType(resources.GetObject("RibbonPage1.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Query"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1, True)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Query Option"
        '
        'txtQuery
        '
        Me.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQuery.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtQuery.Location = New System.Drawing.Point(0, 196)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(1198, 503)
        Me.txtQuery.TabIndex = 0
        '
        'btnSqlServer
        '
        Me.btnSqlServer.Caption = "Sql Server"
        Me.btnSqlServer.Id = 3
        Me.btnSqlServer.ImageOptions.Image = CType(resources.GetObject("BarCheckItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSqlServer.Name = "btnSqlServer"
        '
        'btnExcel
        '
        Me.btnExcel.Caption = "Excel"
        Me.btnExcel.Id = 4
        Me.btnExcel.ImageOptions.Image = CType(resources.GetObject("BarCheckItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExcel.Name = "btnExcel"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "New Connection"
        Me.BarButtonItem1.Id = 8
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.ItemLinks.Add(Me.BarStaticItem1)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.BarStaticItem2)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.BarStaticItem3)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.BarStaticItem4)
        Me.RibbonStatusBar1.ItemLinks.Add(Me.BarStaticItem5)
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 670)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(1198, 29)
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Caption = "Server:"
        Me.BarStaticItem1.Id = 9
        Me.BarStaticItem1.ImageOptions.Image = CType(resources.GetObject("BarStaticItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarStaticItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarStaticItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarStaticItem1.Name = "BarStaticItem1"
        Me.BarStaticItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarStaticItem2
        '
        Me.BarStaticItem2.Caption = "Database:"
        Me.BarStaticItem2.Id = 10
        Me.BarStaticItem2.ImageOptions.Image = CType(resources.GetObject("BarStaticItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarStaticItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarStaticItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarStaticItem2.Name = "BarStaticItem2"
        Me.BarStaticItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarStaticItem3
        '
        Me.BarStaticItem3.Caption = "Excel File:"
        Me.BarStaticItem3.Id = 11
        Me.BarStaticItem3.ImageOptions.Image = CType(resources.GetObject("BarStaticItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarStaticItem3.ImageOptions.LargeImage = CType(resources.GetObject("BarStaticItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarStaticItem3.Name = "BarStaticItem3"
        Me.BarStaticItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarStaticItem4
        '
        Me.BarStaticItem4.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.BarStaticItem4.Caption = "Connected"
        Me.BarStaticItem4.Id = 12
        Me.BarStaticItem4.ImageOptions.Image = CType(resources.GetObject("BarStaticItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarStaticItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarStaticItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarStaticItem4.Name = "BarStaticItem4"
        Me.BarStaticItem4.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarStaticItem5
        '
        Me.BarStaticItem5.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.BarStaticItem5.Caption = "Disconnected"
        Me.BarStaticItem5.Id = 13
        Me.BarStaticItem5.ImageOptions.Image = CType(resources.GetObject("BarStaticItem5.ImageOptions.Image"), System.Drawing.Image)
        Me.BarStaticItem5.ImageOptions.LargeImage = CType(resources.GetObject("BarStaticItem5.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarStaticItem5.Name = "BarStaticItem5"
        Me.BarStaticItem5.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'frmCreateQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 699)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmCreateQuery.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmCreateQuery"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "Create Query"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents txtQuery As TextBox
    Friend WithEvents btnSqlServer As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnExcel As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem2 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents BarStaticItem3 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem4 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem5 As DevExpress.XtraBars.BarStaticItem
End Class
