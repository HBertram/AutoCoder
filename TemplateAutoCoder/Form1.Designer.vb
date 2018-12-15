<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.创建模板ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.创建配置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.读取配置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.模板ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.配置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.推出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TemplateTabControl = New System.Windows.Forms.TabControl()
        Me.ConfigTabControl = New System.Windows.Forms.TabControl()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.RichTextBox1 = New TemplateAutoCoder.TemplateRichTextBox()
        Me.TemplateRichTextBox1 = New TemplateAutoCoder.TemplateRichTextBox()
        Me.转换ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.执行ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件ToolStripMenuItem, Me.转换ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 25)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件ToolStripMenuItem
        '
        Me.文件ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.创建模板ToolStripMenuItem, Me.打开ToolStripMenuItem, Me.创建配置ToolStripMenuItem, Me.读取配置ToolStripMenuItem, Me.保存ToolStripMenuItem, Me.推出ToolStripMenuItem})
        Me.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem"
        Me.文件ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.文件ToolStripMenuItem.Text = "文件"
        '
        '创建模板ToolStripMenuItem
        '
        Me.创建模板ToolStripMenuItem.Name = "创建模板ToolStripMenuItem"
        Me.创建模板ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.创建模板ToolStripMenuItem.Text = "创建模板"
        '
        '打开ToolStripMenuItem
        '
        Me.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem"
        Me.打开ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.打开ToolStripMenuItem.Text = "打开模板"
        '
        '创建配置ToolStripMenuItem
        '
        Me.创建配置ToolStripMenuItem.Name = "创建配置ToolStripMenuItem"
        Me.创建配置ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.创建配置ToolStripMenuItem.Text = "创建配置"
        '
        '读取配置ToolStripMenuItem
        '
        Me.读取配置ToolStripMenuItem.Name = "读取配置ToolStripMenuItem"
        Me.读取配置ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.读取配置ToolStripMenuItem.Text = "读取配置"
        '
        '保存ToolStripMenuItem
        '
        Me.保存ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.模板ToolStripMenuItem, Me.配置ToolStripMenuItem})
        Me.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem"
        Me.保存ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.保存ToolStripMenuItem.Text = "保存"
        '
        '模板ToolStripMenuItem
        '
        Me.模板ToolStripMenuItem.Name = "模板ToolStripMenuItem"
        Me.模板ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.模板ToolStripMenuItem.Text = "模板"
        '
        '配置ToolStripMenuItem
        '
        Me.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem"
        Me.配置ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.配置ToolStripMenuItem.Text = "配置"
        '
        '推出ToolStripMenuItem
        '
        Me.推出ToolStripMenuItem.Name = "推出ToolStripMenuItem"
        Me.推出ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.推出ToolStripMenuItem.Text = "退出"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TemplateTabControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TemplateTabControl.Location = New System.Drawing.Point(0, 28)
        Me.TemplateTabControl.Name = "TabControl1"
        Me.TemplateTabControl.SelectedIndex = 0
        Me.TemplateTabControl.Size = New System.Drawing.Size(414, 425)
        Me.TemplateTabControl.TabIndex = 3
        '
        'ConfigTabControl
        '
        Me.ConfigTabControl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.ConfigTabControl.Location = New System.Drawing.Point(413, 28)
        Me.ConfigTabControl.Name = "ConfigTabControl"
        Me.ConfigTabControl.SelectedIndex = 0
        Me.ConfigTabControl.Size = New System.Drawing.Size(387, 425)
        Me.ConfigTabControl.TabIndex = 4
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(3, 3)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(373, 393)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.WordWrap = False
        '
        'TemplateRichTextBox1
        '
        Me.TemplateRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TemplateRichTextBox1.Location = New System.Drawing.Point(3, 3)
        Me.TemplateRichTextBox1.Name = "TemplateRichTextBox1"
        Me.TemplateRichTextBox1.Size = New System.Drawing.Size(400, 393)
        Me.TemplateRichTextBox1.TabIndex = 2
        Me.TemplateRichTextBox1.Text = ""
        Me.TemplateRichTextBox1.WordWrap = False
        '
        '转换ToolStripMenuItem
        '
        Me.转换ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.执行ToolStripMenuItem})
        Me.转换ToolStripMenuItem.Name = "转换ToolStripMenuItem"
        Me.转换ToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.转换ToolStripMenuItem.Text = "转换"
        '
        '执行ToolStripMenuItem
        '
        Me.执行ToolStripMenuItem.Name = "执行ToolStripMenuItem"
        Me.执行ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.执行ToolStripMenuItem.Text = "执行"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ConfigTabControl)
        Me.Controls.Add(Me.TemplateTabControl)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打开ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 读取配置ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents 推出ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TemplateTabControl As TabControl
    Friend WithEvents ConfigTabControl As TabControl
    Friend WithEvents TemplateRichTextBox1 As TemplateRichTextBox
    Friend WithEvents RichTextBox1 As TemplateRichTextBox
    Friend WithEvents 创建模板ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 创建配置ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 模板ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 配置ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents 转换ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 执行ToolStripMenuItem As ToolStripMenuItem
End Class
