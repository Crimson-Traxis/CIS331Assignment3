Public Class ErrorBanners
    Public Shared Function OpenFileError() As String
        Dim errorBanner As Text.StringBuilder = New Text.StringBuilder()
        errorBanner.Append("****************************************************")
        errorBanner.Append(Environment.NewLine)
        errorBanner.Append("**** Could not open input file for processing ! ****")
        errorBanner.Append(Environment.NewLine)
        errorBanner.Append("****************************************************")
        errorBanner.Append(Environment.NewLine)
        Return errorBanner.ToString()
    End Function

    Public Shared Function SaveFileError() As String
        Dim errorBanner As Text.StringBuilder = New Text.StringBuilder()
        errorBanner.Append("****************************************************")
        errorBanner.Append(Environment.NewLine)
        errorBanner.Append("** Could not save output file in spcified folder! **")
        errorBanner.Append(Environment.NewLine)
        errorBanner.Append("****************************************************")
        errorBanner.Append(Environment.NewLine)
        Return errorBanner.ToString()
    End Function
End Class
