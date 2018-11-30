Public Class TemplateRichTextBox
    Inherits RichTextBox

    Public Sub New()
        WordWrap = False
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        Dim i As Integer = Me.SelectionStart
        Dim s As String = Text
        Text = ""
        Dim c As Color = SelectionColor
        Dim f As Font = SelectionFont
        Dim start As Integer = s.IndexOf("##")
        If start <> -1 Then
        End If
        Find("##*##", RichTextBoxFinds.NoHighlight)
        SelectionFont = New Font("Verdana", 12, FontStyle.Bold)
        SelectionColor = Color.Green
        If SelectionLength > 0 Then
            SelectedText = " " & SelectedText & " "
        End If
        
        DeselectAll()
        AppendText(s)
        SelectionFont = f
        SelectionColor = c
        SelectionStart = i
    End Sub


    Private Sub ReplaceText()
        Dim selectionStart As Integer = Me.SelectionStart
        Dim oriText As String = Text
        Dim i As Integer = 0
        While True
            SelectionColor = Me.ForeColor
            Dim pos As Integer = oriText.IndexOf("##")
            If pos = -1 Then

            End If
        End While
        Me.SelectionStart = selectionStart
    End Sub

End Class
