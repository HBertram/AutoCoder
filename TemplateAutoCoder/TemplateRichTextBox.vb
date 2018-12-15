Public Class TemplateRichTextBox
    Inherits RichTextBox

    Private _FileName As String

    Private _IdentityStack As Stack(Of KeywordSpliter) = New Stack(Of KeywordSpliter)

    Private _KeywordSpliters As List(Of KeywordSpliter) = New List(Of KeywordSpliter)

    Public Sub New(Optional strFileName As String = "")
        _FileName = strFileName
        Init()
    End Sub
    Public Sub SetFileName(strFileName As String)
        _FileName = strFileName
    End Sub
    Public Sub New()
        Init()
    End Sub
    Public Function IsFileConnected() As Boolean
        Return Not String.IsNullOrWhiteSpace(_FileName)
    End Function
    Public Sub Save()
        If String.IsNullOrWhiteSpace(_FileName) Then
            Return
        End If
        Me.SaveFile(_FileName, RichTextBoxStreamType.PlainText)
    End Sub

    Private Sub Init()
        _KeywordSpliters.Add(New KeywordSpliter With {
           .m_oColor = Color.Red,
           .m_strKeyword = "##"
        })
        _KeywordSpliters.Add(New KeywordSpliter With {
           .m_oColor = Color.Green,
           .m_strKeyword = "$$"
        })
        _IdentityStack.Push(New KeywordSpliter With {
           .m_oColor = ForeColor,
           .m_strKeyword = ""
        })
    End Sub

    Public Function ReplaceTemplate(oTemplateMark As TemplateMark) As String
        Return oTemplateMark.ReplaceAll(Text)
    End Function

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        Dim positon As Integer = Me.SelectionStart
        Dim _color As Color = SelectionColor
        ReplaceText()
        SelectionColor = _color
        SelectionStart = positon
    End Sub

    Private Sub Reset()
        _IdentityStack = New Stack(Of KeywordSpliter)
        _IdentityStack.Push(New KeywordSpliter With {
            .m_oColor = ForeColor,
            .m_strKeyword = ""
        })

        For Each oKeywordSpliter As KeywordSpliter In _KeywordSpliters
            oKeywordSpliter.Reset()
        Next
    End Sub

    Private Sub ReplaceText()
        If _KeywordSpliters.Count = 0 Then
            Return
        End If
        Dim strText = Text
        Text = ""
        Dim pos As Integer = 0
        Dim nextScaner As Integer = 0
        While True
            Dim nKeySp As KeywordSpliter = Nothing
            For Each oKeywordSpliter As KeywordSpliter In _KeywordSpliters
                If oKeywordSpliter.GetNextShownIndex(strText, nextScaner) <> -1 AndAlso
                    (IsNothing(nKeySp) OrElse nKeySp.GetNextShownIndex(strText, nextScaner) > oKeywordSpliter.GetNextShownIndex(strText, nextScaner)) Then
                    nKeySp = oKeywordSpliter
                End If
            Next
            '没有找到 即可以跑到走后
            If IsNothing(nKeySp) Then
                AppendText(strText.Substring(pos))
                Exit While
            End If
            If _IdentityStack.Peek() Is nKeySp Then
                '表示该标志该结束了
                _IdentityStack.Pop()
                Dim nextPos As String = nKeySp.GetNextShownIndex(strText, nextScaner) + nKeySp.m_strKeyword.Length
                AppendText(strText.Substring(pos, nextPos - pos))
                pos = nextPos
            Else
                '表示新的标签开始
                _IdentityStack.Push(nKeySp)
                AppendText(strText.Substring(pos, nKeySp.GetNextShownIndex(strText, nextScaner) - pos))
                pos = nKeySp.GetNextShownIndex(strText, nextScaner)
            End If
            nextScaner = nKeySp.GetNextShownIndex(strText, nextScaner) + nKeySp.m_strKeyword.Length
            SelectionColor = _IdentityStack.Peek().m_oColor
        End While
        Reset()

    End Sub


    Friend Class KeywordSpliter
        Property m_strKeyword As String

        Property m_oColor As Color

        Private m_iNextShownIndex As Integer = -99
        Private m_iLastFindIndex As Integer = -1

        Public Function GetNextShownIndex(text As String, index As Integer) As Integer
            If index <> m_iLastFindIndex AndAlso m_iNextShownIndex <> -1 Then
                m_iNextShownIndex = CalNextShownIndex(text, index)
                m_iLastFindIndex = index
            End If
            Return m_iNextShownIndex
        End Function

        Private Function CalNextShownIndex(text As String, index As Integer) As Integer
            Return text.IndexOf(m_strKeyword, index)
        End Function

        Public Sub Reset()
            m_iNextShownIndex = -99
            m_iLastFindIndex = -1
        End Sub

    End Class
End Class
