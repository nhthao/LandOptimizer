<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewProject
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdThoat = New System.Windows.Forms.Button()
        Me.cmdKhoitao = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkMaDVDDMoi = New System.Windows.Forms.CheckBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnBrowseProject = New System.Windows.Forms.Button()
        Me.btnBrowseDVDD = New System.Windows.Forms.Button()
        Me.txtSlgLUT = New System.Windows.Forms.TextBox()
        Me.txtFile_project = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFileDVDD = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.txtSLgDvdd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdThoat)
        Me.GroupBox2.Controls.Add(Me.cmdKhoitao)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 223)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(541, 57)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'cmdThoat
        '
        Me.cmdThoat.Location = New System.Drawing.Point(419, 19)
        Me.cmdThoat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdThoat.Name = "cmdThoat"
        Me.cmdThoat.Size = New System.Drawing.Size(77, 28)
        Me.cmdThoat.TabIndex = 1
        Me.cmdThoat.Text = "&Thoát"
        Me.cmdThoat.UseVisualStyleBackColor = True
        '
        'cmdKhoitao
        '
        Me.cmdKhoitao.Location = New System.Drawing.Point(52, 19)
        Me.cmdKhoitao.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdKhoitao.Name = "cmdKhoitao"
        Me.cmdKhoitao.Size = New System.Drawing.Size(80, 28)
        Me.cmdKhoitao.TabIndex = 0
        Me.cmdKhoitao.Text = "&Tạo dự án"
        Me.cmdKhoitao.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkMaDVDDMoi)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.btnBrowseProject)
        Me.GroupBox1.Controls.Add(Me.btnBrowseDVDD)
        Me.GroupBox1.Controls.Add(Me.txtSlgLUT)
        Me.GroupBox1.Controls.Add(Me.txtSLgDvdd)
        Me.GroupBox1.Controls.Add(Me.txtFile_project)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFileDVDD)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(541, 202)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chọn thông tin thiết lập"
        '
        'chkMaDVDDMoi
        '
        Me.chkMaDVDDMoi.AutoSize = True
        Me.chkMaDVDDMoi.Checked = True
        Me.chkMaDVDDMoi.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMaDVDDMoi.Location = New System.Drawing.Point(386, 101)
        Me.chkMaDVDDMoi.Name = "chkMaDVDDMoi"
        Me.chkMaDVDDMoi.Size = New System.Drawing.Size(148, 20)
        Me.chkMaDVDDMoi.TabIndex = 3
        Me.chkMaDVDDMoi.Text = "Sử dụng cột mã mới"
        Me.chkMaDVDDMoi.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(213, 99)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(163, 24)
        Me.ComboBox1.TabIndex = 3
        '
        'btnBrowseProject
        '
        Me.btnBrowseProject.Location = New System.Drawing.Point(492, 172)
        Me.btnBrowseProject.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowseProject.Name = "btnBrowseProject"
        Me.btnBrowseProject.Size = New System.Drawing.Size(34, 22)
        Me.btnBrowseProject.TabIndex = 2
        Me.btnBrowseProject.Text = "..."
        Me.btnBrowseProject.UseVisualStyleBackColor = True
        '
        'btnBrowseDVDD
        '
        Me.btnBrowseDVDD.Location = New System.Drawing.Point(492, 64)
        Me.btnBrowseDVDD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowseDVDD.Name = "btnBrowseDVDD"
        Me.btnBrowseDVDD.Size = New System.Drawing.Size(34, 22)
        Me.btnBrowseDVDD.TabIndex = 1
        Me.btnBrowseDVDD.Text = "..."
        Me.btnBrowseDVDD.UseVisualStyleBackColor = True
        '
        'txtSlgLUT
        '
        Me.txtSlgLUT.Location = New System.Drawing.Point(213, 31)
        Me.txtSlgLUT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSlgLUT.Name = "txtSlgLUT"
        Me.txtSlgLUT.Size = New System.Drawing.Size(163, 22)
        Me.txtSlgLUT.TabIndex = 0
        '
        'txtFile_project
        '
        Me.txtFile_project.Enabled = False
        Me.txtFile_project.Location = New System.Drawing.Point(213, 172)
        Me.txtFile_project.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFile_project.Name = "txtFile_project"
        Me.txtFile_project.Size = New System.Drawing.Size(273, 22)
        Me.txtFile_project.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Lưu tên file dự án"
        '
        'txtFileDVDD
        '
        Me.txtFileDVDD.Enabled = False
        Me.txtFileDVDD.Location = New System.Drawing.Point(213, 64)
        Me.txtFileDVDD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFileDVDD.Name = "txtFileDVDD"
        Me.txtFileDVDD.Size = New System.Drawing.Size(273, 22)
        Me.txtFileDVDD.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(169, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Chọn tên file ĐVĐĐ cần mở"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tên cột mã ĐVĐĐ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Số lượng kiểu sử dụng ( LUT)"
        '
        'txtSLgDvdd
        '
        Me.txtSLgDvdd.Location = New System.Drawing.Point(213, 137)
        Me.txtSLgDvdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSLgDvdd.Name = "txtSLgDvdd"
        Me.txtSLgDvdd.Size = New System.Drawing.Size(163, 22)
        Me.txtSLgDvdd.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Số lượng ĐVĐĐ"
        '
        'frmNewProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 293)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmNewProject"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tạo dự án mới"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdThoat As System.Windows.Forms.Button
    Friend WithEvents cmdKhoitao As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txtSlgLUT As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseDVDD As System.Windows.Forms.Button
    Friend WithEvents txtFileDVDD As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents chkMaDVDDMoi As System.Windows.Forms.CheckBox
    Friend WithEvents btnBrowseProject As System.Windows.Forms.Button
    Friend WithEvents txtFile_project As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSLgDvdd As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
