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
            Console.WriteLine(Environment.NewLine)
            Console.WriteLine(ErrorBanners.OpenFileError())
            Console.ReadLine()
        End Try

        If fileString <> "" Then
            For Each character As Char In fileString
                AddCharacterToArray(character, characterCount)
            Next
            Console.WriteLine("Processing Completed...")
            Console.WriteLine(Environment.NewLine)
            Console.WriteLine("Please enter the path and name of the report file to generate:")
            Console.WriteLine(Environment.NewLine)
            Console.WriteLine("Report File Generation Completed...")
            Console.WriteLine(Environment.NewLine)
            Console.Write("Would you like to see the report file? [Y:N] ")
            userInput = Console.ReadLine().ToUpper()
            If userInput = "Y" Then
                Dim headerStartLocation As Integer = (Console.WindowWidth - 29) / 2
                Dim statsHeader As StringBuilder = New StringBuilder()
                statsHeader.Append(New String(" ", headerStartLocation))
                statsHeader.Append("Character Analysis Statistics")
                Console.WriteLine(statsHeader.ToString())
                Console.WriteLine(Environment.NewLine)
            End If
        End If
    End Sub

    Sub AddCharacterToArray(character As Char, characterCountAray() As Integer)
        Dim index As Integer = 0
        Dim asciiCode As Integer = Asc(character)
        If (asciiCode > 64 And asciiCode < 91) Or (asciiCode > 96 And asciiCode < 123) Then
            index = Asc(character) - 1 Mod 32
        End If
        index = 26
        characterCountAray(index) = characterCountAray(index) + 1
    End Sub

End Module
