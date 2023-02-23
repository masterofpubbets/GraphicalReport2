<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectDrawingHeader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectDrawingHeader))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.rDrawingName = New System.Windows.Forms.RadioButton()
        Me.rCustom = New System.Windows.Forms.RadioButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtHeader = New System.Windows.Forms.TextBox()
        Me.rgpNameCustom = New System.Windows.Forms.RadioButton()
        Me.gpNameCustom = New DevExpress.XtraEditors.GroupControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rEnd = New System.Windows.Forms.RadioButton()
        Me.rStart = New System.Windows.Forms.RadioButton()
        Me.txtCustomHeader = New System.Windows.Forms.TextBox()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpNameCustom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpNameCustom.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Size = New System.Drawing.Size(700, 66)
        '
        'rDrawingName
        '
        Me.rDrawingName.AutoSize = True
        Me.rDrawingName.Checked = True
        Me.rDrawingName.Location = New System.Drawing.Point(34, 103)
        Me.rDrawingName.Name = "rDrawingName"
        Me.rDrawingName.Size = New System.Drawing.Size(118, 21)
        Me.rDrawingName.TabIndex = 1
        Me.rDrawingName.TabStop = True
        Me.rDrawingName.Text = "Drawing Name"
        Me.rDrawingName.UseVisualStyleBackColor = True
        '
        'rCustom
        '
        Me.rCustom.AutoSize = True
        Me.rCustom.Location = New System.Drawing.Point(34, 145)
        Me.rCustom.Name = "rCustom"
        Me.rCustom.Size = New System.Drawing.Size(77, 21)
        Me.rCustom.TabIndex = 2
        Me.rCustom.Text = "Custom"
        Me.rCustom.UseVisualStyleBackColor = True
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(330, 402)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(176, 53)
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "Add"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(512, 402)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(176, 53)
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "Cancel"
        '
        'txtHeader
        '
        Me.txtHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeader.Location = New System.Drawing.Point(163, 144)
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(525, 23)
        Me.txtHeader.TabIndex = 3
        Me.txtHeader.Visible = False
        '
        'rgpNameCustom
        '
        Me.rgpNameCustom.AutoSize = True
        Me.rgpNameCustom.Location = New System.Drawing.Point(34, 190)
        Me.rgpNameCustom.Name = "rgpNameCustom"
        Me.rgpNameCustom.Size = New System.Drawing.Size(197, 21)
        Me.rgpNameCustom.TabIndex = 4
        Me.rgpNameCustom.Text = "Drawing Name and Custom"
        Me.rgpNameCustom.UseVisualStyleBackColor = True
        '
        'gpNameCustom
        '
        Me.gpNameCustom.Controls.Add(Me.Label2)
        Me.gpNameCustom.Controls.Add(Me.Label1)
        Me.gpNameCustom.Controls.Add(Me.rEnd)
        Me.gpNameCustom.Controls.Add(Me.rStart)
        Me.gpNameCustom.Controls.Add(Me.txtCustomHeader)
        Me.gpNameCustom.Location = New System.Drawing.Point(163, 218)
        Me.gpNameCustom.Name = "gpNameCustom"
        Me.gpNameCustom.Size = New System.Drawing.Size(525, 124)
        Me.gpNameCustom.TabIndex = 7
        Me.gpNameCustom.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Direction:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Custom:"
        '
        'rEnd
        '
        Me.rEnd.AutoSize = True
        Me.rEnd.Location = New System.Drawing.Point(199, 75)
        Me.rEnd.Name = "rEnd"
        Me.rEnd.Size = New System.Drawing.Size(53, 21)
        Me.rEnd.TabIndex = 2
        Me.rEnd.Text = "End"
        Me.rEnd.UseVisualStyleBackColor = True
        '
        'rStart
        '
        Me.rStart.AutoSize = True
        Me.rStart.Checked = True
        Me.rStart.Location = New System.Drawing.Point(122, 75)
        Me.rStart.Name = "rStart"
        Me.rStart.Size = New System.Drawing.Size(59, 21)
        Me.rStart.TabIndex = 1
        Me.rStart.TabStop = True
        Me.rStart.Text = "Start"
        Me.rStart.UseVisualStyleBackColor = True
        '
        'txtCustomHeader
        '
        Me.txtCustomHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomHeader.Location = New System.Drawing.Point(122, 29)
        Me.txtCustomHeader.Name = "txtCustomHeader"
        Me.txtCustomHeader.Size = New System.Drawing.Size(398, 23)
        Me.txtCustomHeader.TabIndex = 0
        '
        'frmSelectDrawingHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 467)
        Me.Controls.Add(Me.gpNameCustom)
        Me.Controls.Add(Me.rgpNameCustom)
        Me.Controls.Add(Me.txtHeader)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.rCustom)
        Me.Controls.Add(Me.rDrawingName)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmSelectDrawingHeader.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmSelectDrawingHeader"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Drawing Header"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpNameCustom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpNameCustom.ResumeLayout(False)
        Me.gpNameCustom.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents rDrawingName As RadioButton
    Friend WithEvents rCustom As RadioButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtHeader As TextBox
    Friend WithEvents rgpNameCustom As RadioButton
    Friend WithEvents gpNameCustom As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents rEnd As RadioButton
    Friend WithEvents rStart As RadioButton
    Friend WithEvents txtCustomHeader As TextBox
End Class
