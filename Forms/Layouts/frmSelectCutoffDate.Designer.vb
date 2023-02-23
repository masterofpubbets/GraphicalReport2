<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectCutoffDate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectCutoffDate))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.rPrintDate = New System.Windows.Forms.RadioButton()
        Me.rNoDate = New System.Windows.Forms.RadioButton()
        Me.rQuery = New System.Windows.Forms.RadioButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lblDBType = New System.Windows.Forms.Label()
        Me.lblConName = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblConDBName = New System.Windows.Forms.Label()
        Me.lblConURL = New System.Windows.Forms.Label()
        Me.lblConDBNameHeader = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.gpQuery = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.gpQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpQuery.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Size = New System.Drawing.Size(907, 66)
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(537, 634)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(176, 53)
        Me.SimpleButton2.TabIndex = 10
        Me.SimpleButton2.Text = "Add"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(719, 634)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(176, 53)
        Me.SimpleButton1.TabIndex = 11
        Me.SimpleButton1.Text = "Cancel"
        '
        'rPrintDate
        '
        Me.rPrintDate.AutoSize = True
        Me.rPrintDate.Checked = True
        Me.rPrintDate.Location = New System.Drawing.Point(33, 100)
        Me.rPrintDate.Name = "rPrintDate"
        Me.rPrintDate.Size = New System.Drawing.Size(90, 21)
        Me.rPrintDate.TabIndex = 12
        Me.rPrintDate.TabStop = True
        Me.rPrintDate.Text = "Print Date"
        Me.rPrintDate.UseVisualStyleBackColor = True
        '
        'rNoDate
        '
        Me.rNoDate.AutoSize = True
        Me.rNoDate.Location = New System.Drawing.Point(33, 141)
        Me.rNoDate.Name = "rNoDate"
        Me.rNoDate.Size = New System.Drawing.Size(79, 21)
        Me.rNoDate.TabIndex = 13
        Me.rNoDate.Text = "No Date"
        Me.rNoDate.UseVisualStyleBackColor = True
        '
        'rQuery
        '
        Me.rQuery.AutoSize = True
        Me.rQuery.Location = New System.Drawing.Point(33, 184)
        Me.rQuery.Name = "rQuery"
        Me.rQuery.Size = New System.Drawing.Size(67, 21)
        Me.rQuery.TabIndex = 14
        Me.rQuery.Text = "Query"
        Me.rQuery.UseVisualStyleBackColor = True
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.SimpleButton3)
        Me.GroupControl1.Controls.Add(Me.lblDBType)
        Me.GroupControl1.Controls.Add(Me.lblConName)
        Me.GroupControl1.Controls.Add(Me.Label12)
        Me.GroupControl1.Controls.Add(Me.lblConDBName)
        Me.GroupControl1.Controls.Add(Me.lblConURL)
        Me.GroupControl1.Controls.Add(Me.lblConDBNameHeader)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Location = New System.Drawing.Point(30, 33)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(705, 191)
        Me.GroupControl1.TabIndex = 15
        Me.GroupControl1.Text = "Connection Options"
        '
        'lblDBType
        '
        Me.lblDBType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDBType.Location = New System.Drawing.Point(130, 73)
        Me.lblDBType.Name = "lblDBType"
        Me.lblDBType.Size = New System.Drawing.Size(548, 26)
        Me.lblDBType.TabIndex = 47
        Me.lblDBType.Text = "---"
        Me.lblDBType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConName
        '
        Me.lblConName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblConName.Location = New System.Drawing.Point(130, 39)
        Me.lblConName.Name = "lblConName"
        Me.lblConName.Size = New System.Drawing.Size(548, 26)
        Me.lblConName.TabIndex = 46
        Me.lblConName.Text = "---"
        Me.lblConName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 17)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Name:"
        '
        'lblConDBName
        '
        Me.lblConDBName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblConDBName.Location = New System.Drawing.Point(130, 140)
        Me.lblConDBName.Name = "lblConDBName"
        Me.lblConDBName.Size = New System.Drawing.Size(425, 26)
        Me.lblConDBName.TabIndex = 44
        Me.lblConDBName.Text = "---"
        Me.lblConDBName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConURL
        '
        Me.lblConURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblConURL.Location = New System.Drawing.Point(130, 106)
        Me.lblConURL.Name = "lblConURL"
        Me.lblConURL.Size = New System.Drawing.Size(548, 26)
        Me.lblConURL.TabIndex = 43
        Me.lblConURL.Text = "---"
        Me.lblConURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConDBNameHeader
        '
        Me.lblConDBNameHeader.AutoSize = True
        Me.lblConDBNameHeader.Location = New System.Drawing.Point(19, 144)
        Me.lblConDBNameHeader.Name = "lblConDBNameHeader"
        Me.lblConDBNameHeader.Size = New System.Drawing.Size(70, 17)
        Me.lblConDBNameHeader.TabIndex = 42
        Me.lblConDBNameHeader.Text = "DB Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Location:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 17)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Type:"
        '
        'GroupControl2
        '
        Me.GroupControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl2.Controls.Add(Me.SimpleButton4)
        Me.GroupControl2.Controls.Add(Me.txtSQL)
        Me.GroupControl2.Location = New System.Drawing.Point(30, 232)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(705, 170)
        Me.GroupControl2.TabIndex = 17
        Me.GroupControl2.Text = "SQL"
        '
        'txtSQL
        '
        Me.txtSQL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSQL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSQL.Location = New System.Drawing.Point(22, 38)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.Size = New System.Drawing.Size(663, 76)
        Me.txtSQL.TabIndex = 0
        '
        'gpQuery
        '
        Me.gpQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpQuery.Controls.Add(Me.GroupControl1)
        Me.gpQuery.Controls.Add(Me.GroupControl2)
        Me.gpQuery.Location = New System.Drawing.Point(130, 197)
        Me.gpQuery.Name = "gpQuery"
        Me.gpQuery.Size = New System.Drawing.Size(765, 421)
        Me.gpQuery.TabIndex = 18
        Me.gpQuery.Text = "Qyery Options"
        Me.gpQuery.Visible = False
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(588, 144)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(97, 42)
        Me.SimpleButton3.TabIndex = 48
        Me.SimpleButton3.Text = "Select"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton4.ImageOptions.Image = CType(resources.GetObject("SimpleButton4.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton4.Location = New System.Drawing.Point(588, 120)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(97, 42)
        Me.SimpleButton4.TabIndex = 49
        Me.SimpleButton4.Text = "Execute"
        '
        'frmSelectCutoffDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 699)
        Me.Controls.Add(Me.gpQuery)
        Me.Controls.Add(Me.rQuery)
        Me.Controls.Add(Me.rNoDate)
        Me.Controls.Add(Me.rPrintDate)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmSelectCutoffDate.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmSelectCutoffDate"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Cutoff Date"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.gpQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpQuery.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents rPrintDate As RadioButton
    Friend WithEvents rNoDate As RadioButton
    Friend WithEvents rQuery As RadioButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblConName As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblConDBName As Label
    Friend WithEvents lblConURL As Label
    Friend WithEvents lblConDBNameHeader As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblDBType As Label
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtSQL As TextBox
    Friend WithEvents gpQuery As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
End Class
