<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcadResultsSummary
    Inherits System.Windows.Forms.Form

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
        Me.pnlResultSummary = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cboTerm = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboStream = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlResultsSummary = New System.Windows.Forms.Panel()
        Me.StatusStrip12 = New System.Windows.Forms.StatusStrip()
        Me.StatusStrip13 = New System.Windows.Forms.StatusStrip()
        Me.StatusStrip14 = New System.Windows.Forms.StatusStrip()
        Me.StatusStrip5 = New System.Windows.Forms.StatusStrip()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbnPointClass = New System.Windows.Forms.RadioButton()
        Me.rbnPointStream = New System.Windows.Forms.RadioButton()
        Me.rbnSchSummaryGradeWise = New System.Windows.Forms.RadioButton()
        Me.rbnSchSummaryMarkWise = New System.Windows.Forms.RadioButton()
        Me.rbnsubjectclass = New System.Windows.Forms.RadioButton()
        Me.rbnbroadgradeclass = New System.Windows.Forms.RadioButton()
        Me.rbnsubjectstream = New System.Windows.Forms.RadioButton()
        Me.rbnbroadclass = New System.Windows.Forms.RadioButton()
        Me.rbnbroadgradestream = New System.Windows.Forms.RadioButton()
        Me.rbnbroadstream = New System.Windows.Forms.RadioButton()
        Me.StatusStrip3 = New System.Windows.Forms.StatusStrip()
        Me.StatusStrip4 = New System.Windows.Forms.StatusStrip()
        Me.StatusStrip6 = New System.Windows.Forms.StatusStrip()
        Me.StatusStrip7 = New System.Windows.Forms.StatusStrip()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pnlResultSummary.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlResultsSummary.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlResultSummary
        '
        Me.pnlResultSummary.BackColor = System.Drawing.SystemColors.Control
        Me.pnlResultSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlResultSummary.Controls.Add(Me.SplitContainer1)
        Me.pnlResultSummary.Controls.Add(Me.StatusStrip2)
        Me.pnlResultSummary.Controls.Add(Me.StatusStrip1)
        Me.pnlResultSummary.Location = New System.Drawing.Point(12, 9)
        Me.pnlResultSummary.Name = "pnlResultSummary"
        Me.pnlResultSummary.Size = New System.Drawing.Size(472, 406)
        Me.pnlResultSummary.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlResultsSummary)
        Me.SplitContainer1.Panel1.Controls.Add(Me.StatusStrip12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.StatusStrip13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.StatusStrip14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.StatusStrip5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip6)
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip7)
        Me.SplitContainer1.Size = New System.Drawing.Size(470, 354)
        Me.SplitContainer1.SplitterDistance = 126
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 33
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(82, 76)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(130, 23)
        Me.btnPreview.TabIndex = 70
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(314, 76)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(130, 23)
        Me.btnClose.TabIndex = 69
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cboTerm
        '
        Me.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerm.FormattingEnabled = True
        Me.cboTerm.Location = New System.Drawing.Point(314, 10)
        Me.cboTerm.Name = "cboTerm"
        Me.cboTerm.Size = New System.Drawing.Size(130, 21)
        Me.cboTerm.TabIndex = 132
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(230, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 131
        Me.Label6.Text = "Term Name :"
        '
        'cboStream
        '
        Me.cboStream.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStream.FormattingEnabled = True
        Me.cboStream.Location = New System.Drawing.Point(314, 43)
        Me.cboStream.Name = "cboStream"
        Me.cboStream.Size = New System.Drawing.Size(130, 21)
        Me.cboStream.TabIndex = 126
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(230, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "Stream Name :"
        '
        'cboClass
        '
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.FormattingEnabled = True
        Me.cboClass.Location = New System.Drawing.Point(82, 43)
        Me.cboClass.Name = "cboClass"
        Me.cboClass.Size = New System.Drawing.Size(130, 21)
        Me.cboClass.TabIndex = 124
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Class Name :"
        '
        'cboYear
        '
        Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(82, 10)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(130, 21)
        Me.cboYear.TabIndex = 122
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Term Year:"
        '
        'pnlResultsSummary
        '
        Me.pnlResultsSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlResultsSummary.Controls.Add(Me.cboYear)
        Me.pnlResultsSummary.Controls.Add(Me.Label6)
        Me.pnlResultsSummary.Controls.Add(Me.cboTerm)
        Me.pnlResultsSummary.Controls.Add(Me.btnClose)
        Me.pnlResultsSummary.Controls.Add(Me.btnPreview)
        Me.pnlResultsSummary.Controls.Add(Me.cboStream)
        Me.pnlResultsSummary.Controls.Add(Me.Label2)
        Me.pnlResultsSummary.Controls.Add(Me.Label3)
        Me.pnlResultsSummary.Controls.Add(Me.cboClass)
        Me.pnlResultsSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlResultsSummary.Location = New System.Drawing.Point(5, 5)
        Me.pnlResultsSummary.Name = "pnlResultsSummary"
        Me.pnlResultsSummary.Size = New System.Drawing.Size(458, 114)
        Me.pnlResultsSummary.TabIndex = 90
        '
        'StatusStrip12
        '
        Me.StatusStrip12.AutoSize = False
        Me.StatusStrip12.BackColor = System.Drawing.Color.MediumAquamarine
        Me.StatusStrip12.Dock = System.Windows.Forms.DockStyle.Left
        Me.StatusStrip12.Location = New System.Drawing.Point(0, 5)
        Me.StatusStrip12.Name = "StatusStrip12"
        Me.StatusStrip12.Size = New System.Drawing.Size(5, 114)
        Me.StatusStrip12.SizingGrip = False
        Me.StatusStrip12.TabIndex = 68
        Me.StatusStrip12.Text = "StatusStrip12"
        '
        'StatusStrip13
        '
        Me.StatusStrip13.AutoSize = False
        Me.StatusStrip13.BackColor = System.Drawing.Color.MediumAquamarine
        Me.StatusStrip13.Location = New System.Drawing.Point(0, 119)
        Me.StatusStrip13.Name = "StatusStrip13"
        Me.StatusStrip13.Size = New System.Drawing.Size(463, 5)
        Me.StatusStrip13.SizingGrip = False
        Me.StatusStrip13.TabIndex = 67
        Me.StatusStrip13.Text = "StatusStrip13"
        '
        'StatusStrip14
        '
        Me.StatusStrip14.AutoSize = False
        Me.StatusStrip14.BackColor = System.Drawing.Color.MediumAquamarine
        Me.StatusStrip14.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatusStrip14.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip14.Name = "StatusStrip14"
        Me.StatusStrip14.Size = New System.Drawing.Size(463, 5)
        Me.StatusStrip14.SizingGrip = False
        Me.StatusStrip14.TabIndex = 66
        Me.StatusStrip14.Text = "StatusStrip14"
        '
        'StatusStrip5
        '
        Me.StatusStrip5.AutoSize = False
        Me.StatusStrip5.BackColor = System.Drawing.Color.MediumAquamarine
        Me.StatusStrip5.Dock = System.Windows.Forms.DockStyle.Right
        Me.StatusStrip5.Location = New System.Drawing.Point(463, 0)
        Me.StatusStrip5.Name = "StatusStrip5"
        Me.StatusStrip5.Size = New System.Drawing.Size(5, 124)
        Me.StatusStrip5.SizingGrip = False
        Me.StatusStrip5.TabIndex = 65
        Me.StatusStrip5.Text = "StatusStrip5"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(458, 215)
        Me.Panel1.TabIndex = 73
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbnPointClass)
        Me.GroupBox1.Controls.Add(Me.rbnPointStream)
        Me.GroupBox1.Controls.Add(Me.rbnSchSummaryGradeWise)
        Me.GroupBox1.Controls.Add(Me.rbnSchSummaryMarkWise)
        Me.GroupBox1.Controls.Add(Me.rbnsubjectclass)
        Me.GroupBox1.Controls.Add(Me.rbnbroadgradeclass)
        Me.GroupBox1.Controls.Add(Me.rbnsubjectstream)
        Me.GroupBox1.Controls.Add(Me.rbnbroadclass)
        Me.GroupBox1.Controls.Add(Me.rbnbroadgradestream)
        Me.GroupBox1.Controls.Add(Me.rbnbroadstream)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(434, 196)
        Me.GroupBox1.TabIndex = 88
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Examinations Analysis Reports"
        '
        'rbnPointClass
        '
        Me.rbnPointClass.AutoSize = True
        Me.rbnPointClass.Location = New System.Drawing.Point(229, 98)
        Me.rbnPointClass.Name = "rbnPointClass"
        Me.rbnPointClass.Size = New System.Drawing.Size(179, 17)
        Me.rbnPointClass.TabIndex = 89
        Me.rbnPointClass.TabStop = True
        Me.rbnPointClass.Text = "Broad Sheet Pointwise Per Class"
        Me.rbnPointClass.UseVisualStyleBackColor = True
        '
        'rbnPointStream
        '
        Me.rbnPointStream.AutoSize = True
        Me.rbnPointStream.Location = New System.Drawing.Point(19, 98)
        Me.rbnPointStream.Name = "rbnPointStream"
        Me.rbnPointStream.Size = New System.Drawing.Size(187, 17)
        Me.rbnPointStream.TabIndex = 88
        Me.rbnPointStream.TabStop = True
        Me.rbnPointStream.Text = "Broad Sheet Pointwise Per Stream"
        Me.rbnPointStream.UseVisualStyleBackColor = True
        '
        'rbnSchSummaryGradeWise
        '
        Me.rbnSchSummaryGradeWise.AutoSize = True
        Me.rbnSchSummaryGradeWise.Location = New System.Drawing.Point(229, 164)
        Me.rbnSchSummaryGradeWise.Name = "rbnSchSummaryGradeWise"
        Me.rbnSchSummaryGradeWise.Size = New System.Drawing.Size(160, 17)
        Me.rbnSchSummaryGradeWise.TabIndex = 87
        Me.rbnSchSummaryGradeWise.TabStop = True
        Me.rbnSchSummaryGradeWise.Text = "School Summary GradeWise"
        Me.rbnSchSummaryGradeWise.UseVisualStyleBackColor = True
        '
        'rbnSchSummaryMarkWise
        '
        Me.rbnSchSummaryMarkWise.AutoSize = True
        Me.rbnSchSummaryMarkWise.Location = New System.Drawing.Point(19, 164)
        Me.rbnSchSummaryMarkWise.Name = "rbnSchSummaryMarkWise"
        Me.rbnSchSummaryMarkWise.Size = New System.Drawing.Size(155, 17)
        Me.rbnSchSummaryMarkWise.TabIndex = 86
        Me.rbnSchSummaryMarkWise.TabStop = True
        Me.rbnSchSummaryMarkWise.Text = "School Summary MarkWise"
        Me.rbnSchSummaryMarkWise.UseVisualStyleBackColor = True
        '
        'rbnsubjectclass
        '
        Me.rbnsubjectclass.AutoSize = True
        Me.rbnsubjectclass.Location = New System.Drawing.Point(229, 131)
        Me.rbnsubjectclass.Name = "rbnsubjectclass"
        Me.rbnsubjectclass.Size = New System.Drawing.Size(154, 17)
        Me.rbnsubjectclass.TabIndex = 81
        Me.rbnsubjectclass.TabStop = True
        Me.rbnsubjectclass.Text = "Subject Summary Per Class"
        Me.rbnsubjectclass.UseVisualStyleBackColor = True
        '
        'rbnbroadgradeclass
        '
        Me.rbnbroadgradeclass.AutoSize = True
        Me.rbnbroadgradeclass.Location = New System.Drawing.Point(229, 65)
        Me.rbnbroadgradeclass.Name = "rbnbroadgradeclass"
        Me.rbnbroadgradeclass.Size = New System.Drawing.Size(184, 17)
        Me.rbnbroadgradeclass.TabIndex = 80
        Me.rbnbroadgradeclass.TabStop = True
        Me.rbnbroadgradeclass.Text = "Broad Sheet Gradewise Per Class"
        Me.rbnbroadgradeclass.UseVisualStyleBackColor = True
        '
        'rbnsubjectstream
        '
        Me.rbnsubjectstream.AutoSize = True
        Me.rbnsubjectstream.Location = New System.Drawing.Point(19, 131)
        Me.rbnsubjectstream.Name = "rbnsubjectstream"
        Me.rbnsubjectstream.Size = New System.Drawing.Size(162, 17)
        Me.rbnsubjectstream.TabIndex = 78
        Me.rbnsubjectstream.TabStop = True
        Me.rbnsubjectstream.Text = "Subject Summary Per Stream"
        Me.rbnsubjectstream.UseVisualStyleBackColor = True
        '
        'rbnbroadclass
        '
        Me.rbnbroadclass.AutoSize = True
        Me.rbnbroadclass.Location = New System.Drawing.Point(229, 32)
        Me.rbnbroadclass.Name = "rbnbroadclass"
        Me.rbnbroadclass.Size = New System.Drawing.Size(179, 17)
        Me.rbnbroadclass.TabIndex = 77
        Me.rbnbroadclass.TabStop = True
        Me.rbnbroadclass.Text = "Broad Sheet Markwise Per Class"
        Me.rbnbroadclass.UseVisualStyleBackColor = True
        '
        'rbnbroadgradestream
        '
        Me.rbnbroadgradestream.AutoSize = True
        Me.rbnbroadgradestream.Location = New System.Drawing.Point(19, 65)
        Me.rbnbroadgradestream.Name = "rbnbroadgradestream"
        Me.rbnbroadgradestream.Size = New System.Drawing.Size(192, 17)
        Me.rbnbroadgradestream.TabIndex = 79
        Me.rbnbroadgradestream.TabStop = True
        Me.rbnbroadgradestream.Text = "Broad Sheet Gradewise Per Stream"
        Me.rbnbroadgradestream.UseVisualStyleBackColor = True
        '
        'rbnbroadstream
        '
        Me.rbnbroadstream.AutoSize = True
        Me.rbnbroadstream.Location = New System.Drawing.Point(19, 32)
        Me.rbnbroadstream.Name = "rbnbroadstream"
        Me.rbnbroadstream.Size = New System.Drawing.Size(187, 17)
        Me.rbnbroadstream.TabIndex = 76
        Me.rbnbroadstream.TabStop = True
        Me.rbnbroadstream.Text = "Broad Sheet Markwise Per Stream"
        Me.rbnbroadstream.UseVisualStyleBackColor = True
        '
        'StatusStrip3
        '
        Me.StatusStrip3.AutoSize = False
        Me.StatusStrip3.BackColor = System.Drawing.Color.MediumAquamarine
        Me.StatusStrip3.Dock = System.Windows.Forms.DockStyle.Left
        Me.StatusStrip3.Location = New System.Drawing.Point(0, 5)
        Me.StatusStrip3.Name = "StatusStrip3"
        Me.StatusStrip3.Size = New System.Drawing.Size(5, 215)
        Me.StatusStrip3.SizingGrip = False
        Me.StatusStrip3.TabIndex = 72
        Me.StatusStrip3.Text = "StatusStrip3"
        '
        'StatusStrip4
        '
        Me.StatusStrip4.AutoSize = False
        Me.StatusStrip4.BackColor = System.Drawing.Color.MediumAquamarine
        Me.StatusStrip4.Location = New System.Drawing.Point(0, 220)
        Me.StatusStrip4.Name = "StatusStrip4"
        Me.StatusStrip4.Size = New System.Drawing.Size(463, 5)
        Me.StatusStrip4.SizingGrip = False
        Me.StatusStrip4.TabIndex = 71
        Me.StatusStrip4.Text = "StatusStrip4"
        '
        'StatusStrip6
        '
        Me.StatusStrip6.AutoSize = False
        Me.StatusStrip6.BackColor = System.Drawing.Color.MediumAquamarine
        Me.StatusStrip6.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatusStrip6.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip6.Name = "StatusStrip6"
        Me.StatusStrip6.Size = New System.Drawing.Size(463, 5)
        Me.StatusStrip6.SizingGrip = False
        Me.StatusStrip6.TabIndex = 70
        Me.StatusStrip6.Text = "StatusStrip6"
        '
        'StatusStrip7
        '
        Me.StatusStrip7.AutoSize = False
        Me.StatusStrip7.BackColor = System.Drawing.Color.MediumAquamarine
        Me.StatusStrip7.Dock = System.Windows.Forms.DockStyle.Right
        Me.StatusStrip7.Location = New System.Drawing.Point(463, 0)
        Me.StatusStrip7.Name = "StatusStrip7"
        Me.StatusStrip7.Size = New System.Drawing.Size(5, 225)
        Me.StatusStrip7.SizingGrip = False
        Me.StatusStrip7.TabIndex = 69
        Me.StatusStrip7.Text = "StatusStrip7"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.AutoSize = False
        Me.StatusStrip2.BackColor = System.Drawing.Color.LightSeaGreen
        Me.StatusStrip2.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(470, 25)
        Me.StatusStrip2.SizingGrip = False
        Me.StatusStrip2.TabIndex = 32
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(170, 20)
        Me.ToolStripStatusLabel1.Text = "EXAM RESULTS SUMMARY"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 379)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(470, 25)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 31
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'frmAcadResultsSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(494, 429)
        Me.Controls.Add(Me.pnlResultSummary)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAcadResultsSummary"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Results Summary"
        Me.pnlResultSummary.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlResultsSummary.ResumeLayout(False)
        Me.pnlResultsSummary.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlResultSummary As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusStrip12 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusStrip13 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusStrip14 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusStrip5 As System.Windows.Forms.StatusStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbnsubjectclass As System.Windows.Forms.RadioButton
    Friend WithEvents rbnbroadgradeclass As System.Windows.Forms.RadioButton
    Friend WithEvents rbnsubjectstream As System.Windows.Forms.RadioButton
    Friend WithEvents rbnbroadclass As System.Windows.Forms.RadioButton
    Friend WithEvents rbnbroadgradestream As System.Windows.Forms.RadioButton
    Friend WithEvents rbnbroadstream As System.Windows.Forms.RadioButton
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cboTerm As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboStream As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbnSchSummaryGradeWise As System.Windows.Forms.RadioButton
    Friend WithEvents rbnSchSummaryMarkWise As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip3 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusStrip4 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusStrip6 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusStrip7 As System.Windows.Forms.StatusStrip
    Friend WithEvents rbnPointClass As System.Windows.Forms.RadioButton
    Friend WithEvents rbnPointStream As System.Windows.Forms.RadioButton
    Friend WithEvents pnlResultsSummary As System.Windows.Forms.Panel
End Class
