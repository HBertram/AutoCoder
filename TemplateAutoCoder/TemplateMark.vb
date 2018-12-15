Public Class TemplateMark
    Private _lstSubTemplateMark As List(Of TemplateMark) = New List(Of TemplateMark)

    Private _strMarkString As String = ""

    Private _oParentTemplateMark As TemplateMark = Nothing

    Private _lstConfigContent As List(Of Dictionary(Of String, String)) = New List(Of Dictionary(Of String, String))

    Public Sub New()

    End Sub

    Public Sub New(strMarkString As String)
        _strMarkString = strMarkString
    End Sub

    Public Sub New(strMarkString As String, oParentTemplateMark As TemplateMark)
        _strMarkString = strMarkString
        _oParentTemplateMark = oParentTemplateMark
    End Sub

    Public Function GetMarkString() As String
        Return Me._strMarkString
    End Function

    Public Sub ParseTemplateConfig(strConfig As String)
        Dim oConfigLines As String() = strConfig.Replace(vbCrLf, vbCr).Replace(vbLf, vbCr).Split(vbCr)
        For i As Integer = 0 To oConfigLines.Count - 1
            Dim strLine As String = oConfigLines(i)
            If String.IsNullOrWhiteSpace(strLine) Then
                Continue For
            End If
            If strLine.IndexOf("=") = -1 Then
                '子标记
                Dim strSubMark As String = strLine.Trim
                Dim oSubTemplateMark As TemplateMark = New TemplateMark(strSubMark, Me)
                _lstSubTemplateMark.Add(oSubTemplateMark)
                Dim strSubConfig As String = ""
                Dim j As Integer
                Dim bIsShow As Boolean = False
                For j = i To oConfigLines.Count - 1
                    Dim strSubLine As String = oConfigLines(j)

                    If strSubLine.Trim = strSubMark Then
                        If bIsShow Then
                            oSubTemplateMark.ParseTemplateConfig(strSubConfig)
                            Exit For
                        End If
                        bIsShow = True
                        Continue For
                    End If

                    strSubConfig &= strSubLine & System.Environment.NewLine
                Next
                i = j
                Continue For
            End If
            Dim left As String = strLine.Substring(0, strLine.IndexOf("=")).Trim
            Dim right As String = strLine.Substring(strLine.IndexOf("=") + 1).Trim
            If _lstConfigContent.Count = 0 OrElse _lstConfigContent.Last.ContainsKey(left) Then
                _lstConfigContent.Add(New Dictionary(Of String, String))
            End If
            Dim dicConfigContent As Dictionary(Of String, String) = _lstConfigContent.Last
            dicConfigContent.Add(left, right)
        Next
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strTemplateString"></param>
    ''' <returns>找不到返回nothing</returns>
    Public Function FindValueOf(strTemplateString As String) As String
        If _lstConfigContent.Count = 1 Then
            Dim dicConfigContent = _lstConfigContent(0)
            For Each key As String In dicConfigContent.Keys
                If key = strTemplateString.Trim Then
                    Return dicConfigContent.Item(strTemplateString)
                End If
            Next
        End If
        If Not IsNothing(_oParentTemplateMark) Then
            Return _oParentTemplateMark.FindValueOf(strTemplateString)
        End If
        Return Nothing
    End Function

    Private Function ReplaceString(strTemplate As String) As String
        Dim strResult As String = ""
        For Each dicConfigContent As Dictionary(Of String, String) In _lstConfigContent
            Dim strItemTemplate As String = strTemplate
            For Each key As String In dicConfigContent.Keys
                strItemTemplate = strItemTemplate.Replace("##" & key & "##", dicConfigContent.Item(key))
            Next
            strResult &= strItemTemplate & System.Environment.NewLine
        Next
        Return strResult
    End Function

    Public Function ReplaceSingle(strTemplate As String) As String
        Dim strResult As String = strTemplate
        If _strMarkString = "" Then
            strResult = ReplaceString(strResult)
        Else
            Dim iFindIndex As Integer = 0
            While True
                Dim leftIndex As Integer = strTemplate.IndexOf(_strMarkString, iFindIndex)
                If leftIndex = -1 Then
                    Exit While
                End If
                iFindIndex = leftIndex + _strMarkString.Length
                Dim rightIndex As Integer = strTemplate.IndexOf(_strMarkString, iFindIndex)
                If rightIndex = -1 Then
                    Exit While
                End If
                iFindIndex = rightIndex + _strMarkString.Length
                strResult = strResult.Substring(0, leftIndex) &
                    ReplaceString(strResult.Substring(leftIndex + _strMarkString.Length, rightIndex - leftIndex - _strMarkString.Length)) &
                    strResult.Substring(rightIndex + _strMarkString.Length)
            End While
        End If
        Return strResult
    End Function

    Public Function ReplaceAll(strTemplate As String) As String
        For Each oTemplateMark As TemplateMark In Me._lstSubTemplateMark
            strTemplate = oTemplateMark.ReplaceAll(strTemplate)
        Next
        Return ReplaceSingle(strTemplate)
    End Function
End Class
