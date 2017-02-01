'------------------------------------------------------------ 
'-                File Name : CharacterAnalysis.vb          - 
'-                Part of Project: Assignment 3             - 
'------------------------------------------------------------
'-                Written By: Trent Killinger               - 
'-                Written On: 1-25-17                       - 
'------------------------------------------------------------ 
'- File Purpose:                                            - 
'-                                                          - 
'- This file is contains the struct for character analysis  -
'------------------------------------------------------------
'- Variable Dictionary                                      - 
'- alphabeticalCount - alphabetical character count         -
'- nonAlphabeticalCount - non alphabetical character count  -
'- highestLetterUtilizationCount - count of highest used    -
'-                                 chars                    -
'- lowestLetterUtilizationCount - count of lowest used chars-
'- highestLetterUtilizationList -list of highest used chars -
'- lowestLetterUtilizationList - list of lowest used chars  -
'- alphabeticList - list of character/character count tuple -
'------------------------------------------------------------

Public Structure CharacterAnalysis
    Public alphabeticalCount As Integer
    Public nonAlphabeticalCount As Integer
    Public highestLetterUtilizationCount
    Public lowestLetterUtilizationCount
    Public highestLetterUtilizationList As List(Of Char)
    Public lowestLetterUtilizationList As List(Of Char)
    Public alphabeticList As List(Of Tuple(Of Char, Integer))
End Structure
