'------------------------------------------------------------ 
'-                File Name : ErrorBanners.vb               - 
'-                Part of Project: Assignment 3             - 
'------------------------------------------------------------
'-                Written By: Trent Killinger               - 
'-                Written On: 1-25-17                       - 
'------------------------------------------------------------ 
'- File Purpose:                                            - 
'-                                                          - 
'- This file is contains the error banners                  -
'------------------------------------------------------------
'- Variable Dictionary                                      - 
'- (none)                                                   -
'------------------------------------------------------------
Public Class ErrorBanners
    '------------------------------------------------------------ 
    '-                Function Name: OpenFileError              - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-25-17                       - 
    '------------------------------------------------------------
    '- Function Purpose:                                        - 
    '-                                                          - 
    '- This function returns the openFileError banner in        -
    '- string format                                            -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- (None)                                                   - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- errorBanner - string builder that builds the error banner-
    '------------------------------------------------------------
    '- Returns                                                  - 
    '- error banner as string                                   - 
    '------------------------------------------------------------
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

    '------------------------------------------------------------ 
    '-                Function Name: SaveFileError              - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-25-17                       - 
    '------------------------------------------------------------
    '- Function Purpose:                                        - 
    '-                                                          - 
    '- This function returns the SaveFileError banner in        -
    '- string format                                            -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- (None)                                                   - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- errorBanner - string builder that builds the error banner-
    '------------------------------------------------------------
    '- Returns                                                  - 
    '- error banner as string                                   - 
    '------------------------------------------------------------
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
