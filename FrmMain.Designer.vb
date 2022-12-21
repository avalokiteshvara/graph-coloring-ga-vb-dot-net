<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.txtMaxIteration = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMutationProbability = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCrossProbability = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPopulationSize = New System.Windows.Forms.TextBox()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.txtLogs = New System.Windows.Forms.TextBox()
        Me.picBox = New System.Windows.Forms.PictureBox()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMaxIteration
        '
        Me.txtMaxIteration.Location = New System.Drawing.Point(122, 12)
        Me.txtMaxIteration.Name = "txtMaxIteration"
        Me.txtMaxIteration.Size = New System.Drawing.Size(120, 20)
        Me.txtMaxIteration.TabIndex = 30
        Me.txtMaxIteration.Text = "1000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Jumlah Generasi"
        '
        'txtMutationProbability
        '
        Me.txtMutationProbability.Location = New System.Drawing.Point(122, 90)
        Me.txtMutationProbability.Name = "txtMutationProbability"
        Me.txtMutationProbability.Size = New System.Drawing.Size(120, 20)
        Me.txtMutationProbability.TabIndex = 28
        Me.txtMutationProbability.Text = "0.7"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Mutation Probability"
        '
        'txtCrossProbability
        '
        Me.txtCrossProbability.Location = New System.Drawing.Point(122, 64)
        Me.txtCrossProbability.Name = "txtCrossProbability"
        Me.txtCrossProbability.Size = New System.Drawing.Size(120, 20)
        Me.txtCrossProbability.TabIndex = 26
        Me.txtCrossProbability.Text = "0.8"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Cross Probability"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "n Individu"
        '
        'txtPopulationSize
        '
        Me.txtPopulationSize.Location = New System.Drawing.Point(122, 38)
        Me.txtPopulationSize.Name = "txtPopulationSize"
        Me.txtPopulationSize.Size = New System.Drawing.Size(120, 20)
        Me.txtPopulationSize.TabIndex = 23
        Me.txtPopulationSize.Text = "40"
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(167, 116)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(75, 23)
        Me.btnProcess.TabIndex = 22
        Me.btnProcess.Text = "Process"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'txtLogs
        '
        Me.txtLogs.Location = New System.Drawing.Point(266, 12)
        Me.txtLogs.Multiline = True
        Me.txtLogs.Name = "txtLogs"
        Me.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLogs.Size = New System.Drawing.Size(370, 98)
        Me.txtLogs.TabIndex = 21
        '
        'picBox
        '
        Me.picBox.Location = New System.Drawing.Point(266, 125)
        Me.picBox.Name = "picBox"
        Me.picBox.Size = New System.Drawing.Size(370, 130)
        Me.picBox.TabIndex = 33
        Me.picBox.TabStop = False
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 267)
        Me.Controls.Add(Me.picBox)
        Me.Controls.Add(Me.txtMaxIteration)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtMutationProbability)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCrossProbability)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPopulationSize)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.txtLogs)
        Me.Name = "FrmMain"
        Me.Text = "FrmMain"
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMaxIteration As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMutationProbability As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCrossProbability As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPopulationSize As System.Windows.Forms.TextBox
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents txtLogs As System.Windows.Forms.TextBox
    Friend WithEvents picBox As System.Windows.Forms.PictureBox
End Class
