Public Class levenshtein

    Public Shared Function percentage(str1, str2) As Double

        Dim levenshteinIndex As Integer = levenshtein.distance(str1, str2)

        Dim largestStr As String = If(str1.Length > str2.Length, str1, str2)
        Dim shortestStr As String = If(str1.Length < str2.Length, str1, str2)

        Return ((largestStr.Length - levenshteinIndex) / largestStr.Length) * 100

    End Function

    Public Shared Function distance(ByVal s As String,
                    ByVal t As String) As Integer
        Dim n As Integer = s.Length
        Dim m As Integer = t.Length
        Dim d(n + 1, m + 1) As Integer

        If n = 0 Then
            Return m
        End If

        If m = 0 Then
            Return n
        End If

        Dim i As Integer
        Dim j As Integer

        For i = 0 To n
            d(i, 0) = i
        Next

        For j = 0 To m
            d(0, j) = j
        Next

        For i = 1 To n
            For j = 1 To m

                Dim cost As Integer
                If t(j - 1) = s(i - 1) Then
                    cost = 0
                Else
                    cost = 1
                End If

                d(i, j) = Math.Min(Math.Min(d(i - 1, j) + 1, d(i, j - 1) + 1),
                           d(i - 1, j - 1) + cost)
            Next
        Next

        Return d(n, m)
    End Function

End Class
