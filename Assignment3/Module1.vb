Imports System.IO
Imports System.Text

Module Module1

    Sub Main()
        '0-25 a-z
        '26 is not alphabetic
        Dim characterCount(26) As Integer
        Dim userInput As String = ""
        Dim fileString As String = ""

        Console.Write("Please enter the path and name of the file to process: ")
        userInput = Console.ReadLine()
        Try
            fileString = File.ReadAllText(userInput)
        Catch ex As Exception
            Console.WriteLine("")
            Console.WriteLine(ErrorBanners.OpenFileError())
        End Try

        If fileString <> "" Then
            For Each character As Char In fileString
                AddCharacterToArray(character, characterCount)
            Next
            Console.WriteLine("")
            Console.WriteLine("Processing Completed...")
            Console.WriteLine("")
            Console.Write("Sort output based on highest occurrence? [Y:N] ")
            Dim output As String = ""
            If Console.ReadLine().ToUpper() = "Y" Then
                output = PrintAnalysis(AnalyzeArray(characterCount), True)
            Else
                output = PrintAnalysis(AnalyzeArray(characterCount), False)
            End If
            Console.WriteLine("")
            Console.Write("Please enter the path and name of the report file to generate: ")
            userInput = Console.ReadLine()
            Dim savedFile As Boolean = True
            Try
                Using writer As StreamWriter = New StreamWriter(userInput)
                    writer.Write(output)
                End Using
            Catch ex As Exception
                savedFile = False
                Console.WriteLine(ErrorBanners.SaveFileError())
            End Try
            If savedFile Then
                Console.WriteLine("")
                Console.WriteLine("Report File Generation Completed...")
                Console.WriteLine("")
                Console.Write("Would you like to see the report file? [Y:N] ")
                userInput = Console.ReadLine().ToUpper()
                If userInput = "Y" Then
                    Console.WriteLine(output)
                End If
            End If
        End If
        Console.WriteLine("** Application will exit -- press and key to exit **")
        Console.ReadKey()
    End Sub

    Public Sub AddCharacterToArray(character As Char, characterCountAray() As Integer)
        Dim index As Integer = 0
        Dim asciiCode As Integer = Asc(character)
        If (asciiCode > 64 And asciiCode < 91) Or (asciiCode > 96 And asciiCode < 123) Then
            index = (Asc(character) - 1) Mod 32
        Else
            index = 26
        End If
        characterCountAray(index) = characterCountAray(index) + 1
    End Sub

    Public Function AnalyzeArray(characterCountAray() As Integer) As CharacterAnalysis
        Dim analysis As CharacterAnalysis
        With analysis
            .alphabeticalCount = 0
            .nonAlphabeticalCount = 0
            .highestLetterUtilizationCount = 0
            .lowestLetterUtilizationCount = Integer.MaxValue
            .highestLetterUtilizationList = New List(Of Char)
            .lowestLetterUtilizationList = New List(Of Char)
            .alphabeticList = New List(Of Tuple(Of Char, Integer))
        End With
        Dim count As Integer = 0
        For index As Integer = 0 To characterCountAray.Length - 2
            If characterCountAray(index) >= analysis.highestLetterUtilizationCount Then
                If characterCountAray(index) > analysis.highestLetterUtilizationCount Then
                    analysis.highestLetterUtilizationCount = characterCountAray(index)
                    analysis.highestLetterUtilizationList.Clear()
                    analysis.highestLetterUtilizationList.Add(Chr(index + 65))
                Else
                    analysis.highestLetterUtilizationList.Add(Chr(index + 65))
                End If
            End If
            If characterCountAray(index) <= analysis.lowestLetterUtilizationCount Then
                If characterCountAray(index) < analysis.lowestLetterUtilizationCount Then
                    analysis.lowestLetterUtilizationCount = characterCountAray(index)
                    analysis.lowestLetterUtilizationList.Clear()
                    analysis.lowestLetterUtilizationList.Add(Chr(index + 65))
                Else
                    analysis.lowestLetterUtilizationList.Add(Chr(index + 65))
                End If
            End If
            analysis.alphabeticList.Add(Tuple.Create(Of Char, Integer)(Chr(index + 65), characterCountAray(index)))
            count += characterCountAray(index)
        Next
        analysis.alphabeticalCount = count
        analysis.nonAlphabeticalCount = characterCountAray(characterCountAray.Length - 1)
        Return analysis
    End Function

    Public Function PrintAnalysis(analysis As CharacterAnalysis, printOrdered As Boolean) As String
        If printOrdered Then
            analysis.alphabeticList.Sort(Function(p As Tuple(Of Char, Integer), q As Tuple(Of Char, Integer)) q.Item2.CompareTo(p.Item2))
        End If
        Dim output As StringBuilder = New StringBuilder
        Dim headerStartLocation As Integer = (Console.WindowWidth - 29) / 2
        Dim statsHeader As StringBuilder = New StringBuilder()
        statsHeader.Append(New String(" ", headerStartLocation))
        statsHeader.Append("Character Analysis Statistics")
        output.AppendLine("")
        output.AppendLine(New String("-", Console.WindowWidth))
        output.AppendLine(statsHeader.ToString())
        output.AppendLine("")
        output.AppendLine(New String("-", Console.WindowWidth))
        output.AppendLine("")
        output.AppendLine("There were a total of " + (analysis.nonAlphabeticalCount + analysis.alphabeticalCount).ToString() + " characters processed.")
        output.AppendLine(analysis.alphabeticalCount.ToString() + " were letters and " + analysis.nonAlphabeticalCount.ToString() + " were other characters.")
        output.AppendLine("")
        Dim leftPaddingValue As Integer = analysis.highestLetterUtilizationCount.ToString().Count
        For Each character As Tuple(Of Char, Integer) In analysis.alphabeticList
            output.Append(character.Item1.ToString() + " : ")
            output.Append(character.Item2.ToString().PadLeft(leftPaddingValue, "0") + " ")
            output.Append(" " + String.Format("{0,-9:p}", character.Item2 / analysis.alphabeticalCount) + " ")
            output.Append(New String("*", (character.Item2 / analysis.alphabeticalCount) * (Console.WindowWidth * 0.9)))
            output.AppendLine("")
        Next
        output.AppendLine("")
        output.AppendLine("Average Letter Value: " + ((analysis.nonAlphabeticalCount + analysis.alphabeticalCount) / analysis.alphabeticalCount).ToString())
        output.AppendLine("Highest Letter Utilization: " + analysis.highestLetterUtilizationCount.ToString() + " on " + String.Join(", ", analysis.highestLetterUtilizationList))
        output.AppendLine("Lowest Letter Utilization: " + analysis.lowestLetterUtilizationCount.ToString() + " on " + String.Join(", ", analysis.lowestLetterUtilizationList))
        Return output.ToString()
    End Function
End Module


