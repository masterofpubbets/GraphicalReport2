<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddStatus))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.picSS = New System.Windows.Forms.PictureBox()
        Me.cmbSStyle = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblSTValue = New System.Windows.Forms.Label()
        Me.tbST = New System.Windows.Forms.TrackBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSW = New System.Windows.Forms.Label()
        Me.tbW = New System.Windows.Forms.TrackBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCK = New System.Windows.Forms.Label()
        Me.ck = New DevExpress.XtraEditors.ColorPickEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTTValue = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tt = New System.Windows.Forms.TrackBar()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.cs = New DevExpress.XtraEditors.ColorPickEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ck.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Size = New System.Drawing.Size(823, 66)
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(635, 634)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(176, 53)
        Me.SimpleButton1.TabIndex = 14
        Me.SimpleButton1.Text = "Cancel"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(453, 634)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(176, 53)
        Me.SimpleButton2.TabIndex = 13
        Me.SimpleButton2.Text = "Add"
        '
        'picSS
        '
        Me.picSS.Location = New System.Drawing.Point(332, 492)
        Me.picSS.Name = "picSS"
        Me.picSS.Size = New System.Drawing.Size(309, 112)
        Me.picSS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSS.TabIndex = 57
        Me.picSS.TabStop = False
        '
        'cmbSStyle
        '
        Me.cmbSStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSStyle.FormattingEnabled = True
        Me.cmbSStyle.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19"})
        Me.cmbSStyle.Location = New System.Drawing.Point(187, 536)
        Me.cmbSStyle.Name = "cmbSStyle"
        Me.cmbSStyle.Size = New System.Drawing.Size(110, 24)
        Me.cmbSStyle.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(27, 536)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 20)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Stroke Style:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(27, 433)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(177, 20)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Stroke Transparent:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSTValue
        '
        Me.lblSTValue.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSTValue.Location = New System.Drawing.Point(187, 459)
        Me.lblSTValue.Name = "lblSTValue"
        Me.lblSTValue.Size = New System.Drawing.Size(378, 22)
        Me.lblSTValue.TabIndex = 11
        Me.lblSTValue.Text = "1"
        Me.lblSTValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbST
        '
        Me.tbST.Location = New System.Drawing.Point(190, 424)
        Me.tbST.Maximum = 100
        Me.tbST.Minimum = 10
        Me.tbST.Name = "tbST"
        Me.tbST.Size = New System.Drawing.Size(375, 56)
        Me.tbST.TabIndex = 10
        Me.tbST.Value = 100
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(27, 347)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 20)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Stroke Width:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSW
        '
        Me.lblSW.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSW.Location = New System.Drawing.Point(187, 393)
        Me.lblSW.Name = "lblSW"
        Me.lblSW.Size = New System.Drawing.Size(378, 22)
        Me.lblSW.TabIndex = 9
        Me.lblSW.Text = "0.4"
        Me.lblSW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbW
        '
        Me.tbW.Location = New System.Drawing.Point(187, 347)
        Me.tbW.Maximum = 400
        Me.tbW.Minimum = 10
        Me.tbW.Name = "tbW"
        Me.tbW.Size = New System.Drawing.Size(378, 56)
        Me.tbW.TabIndex = 8
        Me.tbW.Value = 40
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(546, 282)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 19)
        Me.Label5.TabIndex = 7
        '
        'lblCK
        '
        Me.lblCK.BackColor = System.Drawing.Color.Black
        Me.lblCK.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCK.Location = New System.Drawing.Point(533, 266)
        Me.lblCK.Name = "lblCK"
        Me.lblCK.Size = New System.Drawing.Size(75, 51)
        Me.lblCK.TabIndex = 6
        Me.lblCK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ck
        '
        Me.ck.EditValue = System.Drawing.Color.Empty
        Me.ck.Location = New System.Drawing.Point(187, 280)
        Me.ck.Name = "ck"
        Me.ck.Properties.AutomaticColor = System.Drawing.Color.Black
        Me.ck.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ck.Size = New System.Drawing.Size(322, 22)
        Me.ck.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(27, 283)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 20)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Stroke Color:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTTValue
        '
        Me.lblTTValue.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTTValue.Location = New System.Drawing.Point(187, 238)
        Me.lblTTValue.Name = "lblTTValue"
        Me.lblTTValue.Size = New System.Drawing.Size(378, 22)
        Me.lblTTValue.TabIndex = 4
        Me.lblTTValue.Text = "1"
        Me.lblTTValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(27, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 20)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Fill Color Transparency:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(27, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 20)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Fill Color:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tt
        '
        Me.tt.Location = New System.Drawing.Point(187, 205)
        Me.tt.Maximum = 100
        Me.tt.Name = "tt"
        Me.tt.Size = New System.Drawing.Size(378, 56)
        Me.tt.TabIndex = 3
        Me.tt.Value = 100
        '
        'lblColor
        '
        Me.lblColor.BackColor = System.Drawing.Color.Black
        Me.lblColor.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblColor.Location = New System.Drawing.Point(533, 133)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(48, 48)
        Me.lblColor.TabIndex = 2
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cs
        '
        Me.cs.EditValue = System.Drawing.Color.Empty
        Me.cs.Location = New System.Drawing.Point(187, 146)
        Me.cs.Name = "cs"
        Me.cs.Properties.AutomaticColor = System.Drawing.Color.Black
        Me.cs.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cs.Size = New System.Drawing.Size(325, 22)
        Me.cs.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 20)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Status Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtName
        '
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Location = New System.Drawing.Point(187, 96)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(564, 23)
        Me.txtName.TabIndex = 0
        '
        'frmAddStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 699)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.picSS)
        Me.Controls.Add(Me.cmbSStyle)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblSTValue)
        Me.Controls.Add(Me.tbST)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblSW)
        Me.Controls.Add(Me.tbW)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblCK)
        Me.Controls.Add(Me.ck)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTTValue)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tt)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.cs)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmAddStatus.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmAddStatus"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Status"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ck.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picSS As PictureBox
    Friend WithEvents cmbSStyle As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblSTValue As Label
    Friend WithEvents tbST As TrackBar
    Friend WithEvents Label6 As Label
    Friend WithEvents lblSW As Label
    Friend WithEvents tbW As TrackBar
    Friend WithEvents Label5 As Label
    Friend WithEvents lblCK As Label
    Friend WithEvents ck As DevExpress.XtraEditors.ColorPickEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTTValue As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tt As TrackBar
    Friend WithEvents lblColor As Label
    Friend WithEvents cs As DevExpress.XtraEditors.ColorPickEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents txtName As TextBox
End Class
