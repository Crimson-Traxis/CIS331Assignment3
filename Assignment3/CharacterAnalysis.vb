Public Structure CharacterAnalysis
    Public alphabeticalCount As Integer
    Public nonAlphabeticalCount As Integer
    Public highestLetterUtilizationCount
    Public lowestLetterUtilizationCount
    Public highestLetterUtilizationList As List(Of Char)
    Public lowestLetterUtilizationList As List(Of Char)
    Public alphabeticList As List(Of Tuple(Of Char, Integer))
End Structure
