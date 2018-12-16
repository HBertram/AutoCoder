Imports System.IO
Imports System.Text

Public Class Form1
    Protected Sub DeliverPanelSize() Handles Me.SizeChanged
        Me.TemplateTabControl.Width = Me.Width / 2
        Me.TemplateTabControl.Left = 0
        Me.ConfigTabControl.Width = Me.Width / 2 - 15
        Me.ConfigTabControl.Left = Me.Width / 2
    End Sub

    Private Sub 创建模板ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 创建模板ToolStripMenuItem.Click
        InsertNewRichboxTabPage(TemplateTabControl)
    End Sub
    Private Sub 打开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开ToolStripMenuItem.Click
        If Not Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Return
        End If
        InsertNewRichboxTabPage(TemplateTabControl, OpenFileDialog1.FileName)
    End Sub
    Private Sub 创建配置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 创建配置ToolStripMenuItem.Click
        InsertNewRichboxTabPage(ConfigTabControl)
    End Sub
    Private Sub 读取配置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 读取配置ToolStripMenuItem.Click
        If Not Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Return
        End If
        InsertNewRichboxTabPage(ConfigTabControl, OpenFileDialog1.FileName)
    End Sub
    Private Sub 模板ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 模板ToolStripMenuItem.Click
        If IsNothing(TemplateTabControl.SelectedTab) Then
            Return
        End If
        Dim oRichbox As TemplateRichTextBox = TemplateTabControl.SelectedTab.Controls.Item(0)
        If Not oRichbox.IsFileConnected Then
            If DialogResult.OK <> Me.SaveFileDialog1.ShowDialog Then
                Return
            End If
            oRichbox.SetFileName(Me.SaveFileDialog1.FileName)
        End If
        oRichbox.Save()
    End Sub
    Private Sub 配置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 配置ToolStripMenuItem.Click
        If IsNothing(ConfigTabControl.SelectedTab) Then
            Return
        End If
        Dim oRichbox As TemplateRichTextBox = ConfigTabControl.SelectedTab.Controls.Item(0)
        oRichbox.Save()
    End Sub
    Private Sub 推出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 推出ToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub InsertNewRichboxTabPage(oTabControll As TabControl, Optional strFileName As String = "")
        Dim strCreateName As String = ""
        Dim strContent As String = ""
        If strFileName <> "" AndAlso File.Exists(strFileName) Then
            strCreateName = strFileName
            Dim oReader As StreamReader = New StreamReader(strFileName, Encoding.GetEncoding("gb2312"))
            strContent = oReader.ReadToEnd
            oReader.Close()
        End If

        Dim oTabPage As TabPage = CreateNewTabPageWithRichTextBox(strFileName)
        oTabControll.Controls.Add(oTabPage)
        Dim oTemplateRichTextBox As TemplateRichTextBox = oTabPage.Controls.Find(strFileName & "_richbox", False).First
        oTemplateRichTextBox.Text = strContent

        oTabControll.SelectTab(oTabPage)
    End Sub
    Private Function CreateNewTabPageWithRichTextBox(strFileName As String) As TabPage
        Dim strSafeFileName As String = strFileName.Substring(If(strFileName.LastIndexOf("\") >= 0, strFileName.LastIndexOf("\") + 1, 0))
        Dim oTemplateRichTextBox As TemplateRichTextBox = New TemplateRichTextBox(strFileName) With {
            .Dock = DockStyle.Fill,
            .Location = New System.Drawing.Point(3, 3),
            .Name = strFileName + "_richbox",
            .WordWrap = False
        }

        Dim oTabPage As TabPage = New TabPage With {
            .ToolTipText = strFileName,
            .Location = New System.Drawing.Point(4, 22),
            .Name = strSafeFileName,
            .Text = strSafeFileName,
            .UseVisualStyleBackColor = True
        }

        oTabPage.Controls.Add(oTemplateRichTextBox)
        Return oTabPage
    End Function

    Private Sub 执行ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 执行ToolStripMenuItem.Click
        Dim oTemplateMark As TemplateMark = New TemplateMark()
        oTemplateMark.ParseTemplateConfig(ConfigTabControl.SelectedTab.Controls(0).Text)
        Dim oTemplateRichTextBox As TemplateRichTextBox = TemplateTabControl.SelectedTab.Controls(0)
        oTemplateRichTextBox.Text = oTemplateRichTextBox.ReplaceTemplate(oTemplateMark)
    End Sub

    Private Sub CloseTabPage(sender As Object, e As EventArgs) Handles ConfigTabControl.DoubleClick, TemplateTabControl.DoubleClick
        Dim oTabControl As TabControl = sender
        oTabControl.Controls.Remove(oTabControl.SelectedTab)
    End Sub



End Class
