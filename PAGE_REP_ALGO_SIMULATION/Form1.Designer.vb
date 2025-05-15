<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        cmbFrame = New ComboBox()
        btnShow = New Button()
        lblPgRepStr = New Label()
        pgRefStr = New Label()
        Label1 = New Label()
        Label2 = New Label()
        btnGenerate = New Button()
        ppnlOutput = New Panel()
        lblFrames = New Label()
        Label5 = New Label()
        lblRefString = New Label()
        Label4 = New Label()
        pnlOutput = New Panel()
        lblPageFault = New Label()
        Label3 = New Label()
        cmbAlgo = New ComboBox()
        lblPageRef = New Label()
        ppnlOutput.SuspendLayout()
        SuspendLayout()
        ' 
        ' cmbFrame
        ' 
        cmbFrame.FormattingEnabled = True
        cmbFrame.Location = New Point(415, 83)
        cmbFrame.Margin = New Padding(4)
        cmbFrame.Name = "cmbFrame"
        cmbFrame.Size = New Size(180, 33)
        cmbFrame.TabIndex = 0
        ' 
        ' btnShow
        ' 
        btnShow.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnShow.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnShow.ForeColor = Color.FromArgb(CByte(206), CByte(171), CByte(205))
        btnShow.Location = New Point(931, 111)
        btnShow.Margin = New Padding(4)
        btnShow.Name = "btnShow"
        btnShow.Size = New Size(160, 52)
        btnShow.TabIndex = 2
        btnShow.Text = "Show"
        btnShow.UseVisualStyleBackColor = True
        ' 
        ' lblPgRepStr
        ' 
        lblPgRepStr.AutoSize = True
        lblPgRepStr.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold)
        lblPgRepStr.ForeColor = Color.FromArgb(CByte(206), CByte(171), CByte(205))
        lblPgRepStr.Location = New Point(56, 31)
        lblPgRepStr.Margin = New Padding(4, 0, 4, 0)
        lblPgRepStr.Name = "lblPgRepStr"
        lblPgRepStr.Size = New Size(342, 38)
        lblPgRepStr.TabIndex = 4
        lblPgRepStr.Text = "Page Reference String: "
        ' 
        ' pgRefStr
        ' 
        pgRefStr.AutoSize = True
        pgRefStr.Font = New Font("Segoe UI", 12F)
        pgRefStr.Location = New Point(300, 31)
        pgRefStr.Margin = New Padding(4, 0, 4, 0)
        pgRefStr.Name = "pgRefStr"
        pgRefStr.Size = New Size(0, 32)
        pgRefStr.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold)
        Label1.ForeColor = Color.FromArgb(CByte(206), CByte(171), CByte(205))
        Label1.Location = New Point(28, 83)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(370, 38)
        Label1.TabIndex = 6
        Label1.Text = "Number of Page Frames: "
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold)
        Label2.ForeColor = Color.FromArgb(CByte(206), CByte(171), CByte(205))
        Label2.Location = New Point(813, 218)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(172, 38)
        Label2.TabIndex = 7
        Label2.Text = "Page Fault:"
        ' 
        ' btnGenerate
        ' 
        btnGenerate.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnGenerate.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnGenerate.ForeColor = Color.FromArgb(CByte(206), CByte(171), CByte(205))
        btnGenerate.Location = New Point(844, 31)
        btnGenerate.Margin = New Padding(4)
        btnGenerate.Name = "btnGenerate"
        btnGenerate.Size = New Size(247, 52)
        btnGenerate.TabIndex = 8
        btnGenerate.Text = "Generate String"
        btnGenerate.UseVisualStyleBackColor = True
        ' 
        ' ppnlOutput
        ' 
        ppnlOutput.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ppnlOutput.BackColor = Color.FromArgb(CByte(206), CByte(171), CByte(205))
        ppnlOutput.Controls.Add(lblFrames)
        ppnlOutput.Controls.Add(Label5)
        ppnlOutput.Controls.Add(lblRefString)
        ppnlOutput.Controls.Add(Label4)
        ppnlOutput.Controls.Add(pnlOutput)
        ppnlOutput.Location = New Point(12, 274)
        ppnlOutput.Name = "ppnlOutput"
        ppnlOutput.Size = New Size(1095, 393)
        ppnlOutput.TabIndex = 14
        ' 
        ' lblFrames
        ' 
        lblFrames.AutoSize = True
        lblFrames.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFrames.ForeColor = Color.FromArgb(CByte(5), CByte(27), CByte(30))
        lblFrames.Location = New Point(292, 47)
        lblFrames.Margin = New Padding(4, 0, 4, 0)
        lblFrames.Name = "lblFrames"
        lblFrames.Size = New Size(39, 38)
        lblFrames.TabIndex = 24
        lblFrames.Text = "--"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.FromArgb(CByte(5), CByte(27), CByte(30))
        Label5.Location = New Point(156, 47)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(126, 38)
        Label5.TabIndex = 23
        Label5.Text = "Frames:"
        ' 
        ' lblRefString
        ' 
        lblRefString.AutoSize = True
        lblRefString.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRefString.ForeColor = Color.FromArgb(CByte(5), CByte(27), CByte(30))
        lblRefString.Location = New Point(292, 9)
        lblRefString.Margin = New Padding(4, 0, 4, 0)
        lblRefString.Name = "lblRefString"
        lblRefString.Size = New Size(39, 38)
        lblRefString.TabIndex = 22
        lblRefString.Text = "--"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.FromArgb(CByte(5), CByte(27), CByte(30))
        Label4.Location = New Point(26, 9)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(258, 38)
        Label4.TabIndex = 21
        Label4.Text = "Reference String:"
        ' 
        ' pnlOutput
        ' 
        pnlOutput.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlOutput.BackColor = Color.FromArgb(CByte(5), CByte(27), CByte(30))
        pnlOutput.BorderStyle = BorderStyle.FixedSingle
        pnlOutput.Location = New Point(26, 99)
        pnlOutput.Name = "pnlOutput"
        pnlOutput.Size = New Size(1041, 275)
        pnlOutput.TabIndex = 0
        ' 
        ' lblPageFault
        ' 
        lblPageFault.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblPageFault.AutoSize = True
        lblPageFault.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold)
        lblPageFault.ForeColor = Color.FromArgb(CByte(206), CByte(171), CByte(205))
        lblPageFault.Location = New Point(993, 218)
        lblPageFault.Margin = New Padding(4, 0, 4, 0)
        lblPageFault.Name = "lblPageFault"
        lblPageFault.Size = New Size(39, 38)
        lblPageFault.TabIndex = 15
        lblPageFault.Text = "--"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold)
        Label3.ForeColor = Color.FromArgb(CByte(206), CByte(171), CByte(205))
        Label3.Location = New Point(220, 130)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(169, 38)
        Label3.TabIndex = 19
        Label3.Text = "Algorithm:"
        ' 
        ' cmbAlgo
        ' 
        cmbAlgo.FormattingEnabled = True
        cmbAlgo.Location = New Point(415, 130)
        cmbAlgo.Margin = New Padding(4)
        cmbAlgo.Name = "cmbAlgo"
        cmbAlgo.Size = New Size(180, 33)
        cmbAlgo.TabIndex = 20
        ' 
        ' lblPageRef
        ' 
        lblPageRef.AutoSize = True
        lblPageRef.Font = New Font("Segoe UI Black", 14F, FontStyle.Bold)
        lblPageRef.ForeColor = Color.FromArgb(CByte(206), CByte(171), CByte(205))
        lblPageRef.Location = New Point(406, 31)
        lblPageRef.Margin = New Padding(4, 0, 4, 0)
        lblPageRef.Name = "lblPageRef"
        lblPageRef.Size = New Size(39, 38)
        lblPageRef.TabIndex = 21
        lblPageRef.Text = "--"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(144F, 144F)
        AutoScaleMode = AutoScaleMode.Dpi
        AutoScroll = True
        BackColor = Color.FromArgb(CByte(5), CByte(27), CByte(30))
        ClientSize = New Size(1141, 689)
        Controls.Add(lblPageRef)
        Controls.Add(cmbAlgo)
        Controls.Add(Label3)
        Controls.Add(lblPageFault)
        Controls.Add(ppnlOutput)
        Controls.Add(btnGenerate)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(pgRefStr)
        Controls.Add(lblPgRepStr)
        Controls.Add(btnShow)
        Controls.Add(cmbFrame)
        Margin = New Padding(4)
        MinimumSize = New Size(596, 589)
        Name = "Form1"
        Text = " "
        ppnlOutput.ResumeLayout(False)
        ppnlOutput.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cmbFrame As ComboBox
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents btnShow As Button
    Friend WithEvents lblPgRepStr As Label
    Friend WithEvents pgRefStr As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGenerate As Button
    Friend WithEvents ppnlOutput As Panel
    Friend WithEvents pnlOutput As Panel
    Friend WithEvents lblPageFault As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbAlgo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblFrames As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblRefString As Label
    Friend WithEvents lblPageRef As Label

End Class
