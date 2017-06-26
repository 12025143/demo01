<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Track
    Inherits System.Windows.Forms.Form
    'Form 重写 Dispose，以清理组件列表。
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
    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer
    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnP3Homing = New System.Windows.Forms.Button()
        Me.btnP2Homing = New System.Windows.Forms.Button()
        Me.btnP1Homing = New System.Windows.Forms.Button()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.btnP1Action = New System.Windows.Forms.Button()
        Me.btnP2Action = New System.Windows.Forms.Button()
        Me.btnP3Action = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnP3Homing
        '
        Me.btnP3Homing.Location = New System.Drawing.Point(252, 47)
        Me.btnP3Homing.Margin = New System.Windows.Forms.Padding(4)
        Me.btnP3Homing.Name = "btnP3Homing"
        Me.btnP3Homing.Size = New System.Drawing.Size(100, 31)
        Me.btnP3Homing.TabIndex = 21
        Me.btnP3Homing.Text = "工位3复位"
        Me.btnP3Homing.UseVisualStyleBackColor = True
        '
        'btnP2Homing
        '
        Me.btnP2Homing.Location = New System.Drawing.Point(129, 47)
        Me.btnP2Homing.Margin = New System.Windows.Forms.Padding(4)
        Me.btnP2Homing.Name = "btnP2Homing"
        Me.btnP2Homing.Size = New System.Drawing.Size(100, 31)
        Me.btnP2Homing.TabIndex = 22
        Me.btnP2Homing.Text = "工位2复位"
        Me.btnP2Homing.UseVisualStyleBackColor = True
        '
        'btnP1Homing
        '
        Me.btnP1Homing.Location = New System.Drawing.Point(21, 47)
        Me.btnP1Homing.Margin = New System.Windows.Forms.Padding(4)
        Me.btnP1Homing.Name = "btnP1Homing"
        Me.btnP1Homing.Size = New System.Drawing.Size(100, 31)
        Me.btnP1Homing.TabIndex = 20
        Me.btnP1Homing.Text = "工位1复位"
        Me.btnP1Homing.UseVisualStyleBackColor = True
        '
        'btnChange
        '
        Me.btnChange.Location = New System.Drawing.Point(381, 47)
        Me.btnChange.Margin = New System.Windows.Forms.Padding(4)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(100, 31)
        Me.btnChange.TabIndex = 23
        Me.btnChange.Text = "切换型号"
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'btnP1Action
        '
        Me.btnP1Action.Location = New System.Drawing.Point(21, 157)
        Me.btnP1Action.Margin = New System.Windows.Forms.Padding(4)
        Me.btnP1Action.Name = "btnP1Action"
        Me.btnP1Action.Size = New System.Drawing.Size(100, 31)
        Me.btnP1Action.TabIndex = 20
        Me.btnP1Action.Text = "工位1动作"
        Me.btnP1Action.UseVisualStyleBackColor = True
        '
        'btnP2Action
        '
        Me.btnP2Action.Location = New System.Drawing.Point(129, 157)
        Me.btnP2Action.Margin = New System.Windows.Forms.Padding(4)
        Me.btnP2Action.Name = "btnP2Action"
        Me.btnP2Action.Size = New System.Drawing.Size(100, 31)
        Me.btnP2Action.TabIndex = 20
        Me.btnP2Action.Text = "工位2动作"
        Me.btnP2Action.UseVisualStyleBackColor = True
        '
        'btnP3Action
        '
        Me.btnP3Action.Location = New System.Drawing.Point(252, 157)
        Me.btnP3Action.Margin = New System.Windows.Forms.Padding(4)
        Me.btnP3Action.Name = "btnP3Action"
        Me.btnP3Action.Size = New System.Drawing.Size(100, 31)
        Me.btnP3Action.TabIndex = 20
        Me.btnP3Action.Text = "工位3动作"
        Me.btnP3Action.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(23, 103)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(99, 20)
        Me.CheckBox1.TabIndex = 24
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Track
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 247)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.btnP3Homing)
        Me.Controls.Add(Me.btnP2Homing)
        Me.Controls.Add(Me.btnP3Action)
        Me.Controls.Add(Me.btnP2Action)
        Me.Controls.Add(Me.btnP1Action)
        Me.Controls.Add(Me.btnP1Homing)
        Me.Controls.Add(Me.btnChange)
        Me.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Track"
        Me.Text = "Track"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents btnP3Homing As System.Windows.Forms.Button
    Friend WithEvents btnP2Homing As System.Windows.Forms.Button
    Friend WithEvents btnP1Homing As System.Windows.Forms.Button
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents btnP1Action As System.Windows.Forms.Button
    Friend WithEvents btnP2Action As System.Windows.Forms.Button
    Friend WithEvents btnP3Action As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
