<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCreateConnection
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreateConnection))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.chkTypeExcel = New DevExpress.XtraBars.BarCheckItem()
        Me.chkTypeSQL = New DevExpress.XtraBars.BarCheckItem()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtConName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.popMenuDBType = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.popDBType = New DevExpress.XtraEditors.DropDownButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblServerPathTitle = New System.Windows.Forms.Label()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.lblDBTitle = New System.Windows.Forms.Label()
        Me.txtDBName = New System.Windows.Forms.TextBox()
        Me.btnSelectPath = New DevExpress.XtraEditors.SimpleButton()
        Me.opnFle = New System.Windows.Forms.OpenFileDialog()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.popMenuDBType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.chkTypeExcel, Me.chkTypeSQL})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 3
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Size = New System.Drawing.Size(856, 66)
        '
        'chkTypeExcel
        '
        Me.chkTypeExcel.Caption = "Excel"
        Me.chkTypeExcel.Id = 1
        Me.chkTypeExcel.ImageOptions.Image = CType(resources.GetObject("chkTypeExcel.ImageOptions.Image"), System.Drawing.Image)
        Me.chkTypeExcel.Name = "chkTypeExcel"
        '
        'chkTypeSQL
        '
        Me.chkTypeSQL.Caption = "SQL Server"
        Me.chkTypeSQL.Id = 2
        Me.chkTypeSQL.ImageOptions.Image = CType(resources.GetObject("chkTypeSQL.ImageOptions.Image"), System.Drawing.Image)
        Me.chkTypeSQL.Name = "chkTypeSQL"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(486, 436)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(176, 53)
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "Add"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(668, 436)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(176, 53)
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "Cancel"
        '
        'txtConName
        '
        Me.txtConName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConName.Location = New System.Drawing.Point(186, 104)
        Me.txtConName.Name = "txtConName"
        Me.txtConName.Size = New System.Drawing.Size(553, 23)
        Me.txtConName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 17)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Connection Name:"
        '
        'popMenuDBType
        '
        Me.popMenuDBType.ItemLinks.Add(Me.chkTypeExcel)
        Me.popMenuDBType.ItemLinks.Add(Me.chkTypeSQL)
        Me.popMenuDBType.Name = "popMenuDBType"
        Me.popMenuDBType.Ribbon = Me.RibbonControl1
        '
        'popDBType
        '
        Me.popDBType.Appearance.Options.UseImage = True
        Me.popDBType.DropDownControl = Me.popMenuDBType
        Me.popDBType.Location = New System.Drawing.Point(186, 142)
        Me.popDBType.MenuManager = Me.RibbonControl1
        Me.popDBType.Name = "popDBType"
        Me.popDBType.Size = New System.Drawing.Size(290, 63)
        Me.popDBType.TabIndex = 1
        Me.popDBType.Text = "Select Database Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 17)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Type:"
        '
        'lblServerPathTitle
        '
        Me.lblServerPathTitle.AutoSize = True
        Me.lblServerPathTitle.Location = New System.Drawing.Point(22, 231)
        Me.lblServerPathTitle.Name = "lblServerPathTitle"
        Me.lblServerPathTitle.Size = New System.Drawing.Size(85, 17)
        Me.lblServerPathTitle.TabIndex = 24
        Me.lblServerPathTitle.Text = "Server Path:"
        '
        'txtPath
        '
        Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPath.Location = New System.Drawing.Point(186, 225)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(553, 23)
        Me.txtPath.TabIndex = 2
        '
        'lblDBTitle
        '
        Me.lblDBTitle.AutoSize = True
        Me.lblDBTitle.Location = New System.Drawing.Point(22, 273)
        Me.lblDBTitle.Name = "lblDBTitle"
        Me.lblDBTitle.Size = New System.Drawing.Size(70, 17)
        Me.lblDBTitle.TabIndex = 26
        Me.lblDBTitle.Text = "DB Name:"
        '
        'txtDBName
        '
        Me.txtDBName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDBName.Location = New System.Drawing.Point(186, 267)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(290, 23)
        Me.txtDBName.TabIndex = 4
        '
        'btnSelectPath
        '
        Me.btnSelectPath.ImageOptions.Image = CType(resources.GetObject("SimpleButton7.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSelectPath.Location = New System.Drawing.Point(745, 220)
        Me.btnSelectPath.Name = "btnSelectPath"
        Me.btnSelectPath.Size = New System.Drawing.Size(86, 34)
        Me.btnSelectPath.TabIndex = 3
        Me.btnSelectPath.Text = "Select"
        Me.btnSelectPath.Visible = False
        '
        'opnFle
        '
        Me.opnFle.Filter = "XLS|*.xls|XLSX|*.xlsx|XLSB|*.xlsb"
        '
        'frmCreateConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 501)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSelectPath)
        Me.Controls.Add(Me.txtDBName)
        Me.Controls.Add(Me.lblDBTitle)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.lblServerPathTitle)
        Me.Controls.Add(Me.popDBType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtConName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmCreateConnection.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmCreateConnection"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New Connection"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.popMenuDBType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtConName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents popMenuDBType As DevExpress.XtraBars.PopupMenu
    Friend WithEvents popDBType As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents Label3 As Label
    Friend WithEvents lblServerPathTitle As Label
    Friend WithEvents txtPath As TextBox
    Friend WithEvents lblDBTitle As Label
    Friend WithEvents txtDBName As TextBox
    Friend WithEvents chkTypeExcel As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents chkTypeSQL As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnSelectPath As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents opnFle As OpenFileDialog
End Class
