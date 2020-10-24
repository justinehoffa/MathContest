'Justine Hoffa
'RCET0265
'Fall2020
'Math Contest
'https://github.com/justinehoffa/MathContest

Public Class MathContestForm

    Dim userMessage As String
    Dim randomNumber As Integer
    Dim studentAnswer As Integer
    Dim correctAnswer As Integer
    Dim firstNumber As Integer
    Dim secondNumber As Integer
    Dim numbersCorrect As Integer
    Dim numberOfProblems As Integer
    Dim ageNumber As Integer
    Dim gradeNumber As Integer
    Dim gradeValidated As Boolean = False

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        'Ends Program
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        'Dim ResetAllControls
        NameTextBox.Text = ""
        GradeTextBox.Text = ""
        AgeTextBox.Text = ""
        StudentAnswerTextBox.Text = ""
        AddRadioButton.Enabled = True
        numbersCorrect = 0
        numberOfProblems = 0
    End Sub

    Private Sub MathContestForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Random Number Generator
        randomNumber = CInt(Int((20 * Rnd()) + 0))
        FirstNumberTextBox.Text = Str(Int((20 * Rnd()) + 0))
        SecondNumberTextBox.Text = Str(Int((20 * Rnd()) + 0))
        FirstNumberTextBox.Enabled = False
        SecondNumberTextBox.Enabled = False
        SummaryButton.Enabled = False
        AddRadioButton.Checked = True
    End Sub

    Sub AlertUser(ByVal Message As String)
        MsgBox(Message)
        AccumulateMessage("", True)
    End Sub

    Function AccumulateMessage(ByVal newMessage As String, Clear As Boolean) As String
        Static message As String
        If Clear Then
            message = ""
        ElseIf newMessage <> "" Then
            message &= newMessage & vbNewLine
        End If
        Return message
    End Function

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click

        Dim age As String
        Dim grade As String
        Dim userMessage As String

        If NameTextBox.Text = "" Then
            userMessage = "Please enter a valid name." & vbNewLine
            NameTextBox.Select()
        End If

        If AgeTextBox.Text = "" Then
            userMessage = "Please enter a valid age." & vbNewLine
            AgeTextBox.Select()
        ElseIf AgeTextBox.Text <> "" Then
            age = CInt(AgeTextBox.Text)
            If age < 7 Then
                userMessage = "This student is too young to partipate." & vbNewLine
            ElseIf age > 11 Then
                userMessage = "This student is too old to partipate." & vbNewLine
            End If
        End If

        If GradeTextBox.Text = "" Then
            userMessage = "Please enter a valid grade." & vbNewLine
            GradeTextBox.Select()
        ElseIf GradeTextBox.Text <> "" Then
            grade = CInt(GradeTextBox.Text)
            If grade < 1 Then
                userMessage = "This student's grade is too low to participate." & vbNewLine
            ElseIf grade > 4 Then
                userMessage = "This student's grade is too high to participate." & vbNewLine
            End If
        End If


        If gradeValidated = True Then
            firstNumber = CInt(FirstNumberTextBox.Text)
            secondNumber = CInt(SecondNumberTextBox.Text)
            studentAnswer = CInt(StudentAnswerTextBox.Text)
            If AddRadioButton.Checked = True Then
                correctAnswer = firstNumber + secondNumber
            ElseIf SubtractRadioButton.Checked = True Then
                correctAnswer = firstNumber - secondNumber
            ElseIf DivideRadioButton.Checked = True Then
                correctAnswer = firstNumber / secondNumber
            ElseIf MultiplyRadioButton.Checked = True Then
                correctAnswer = firstNumber * secondNumber
            End If
            If studentAnswer = correctAnswer Then
                userMessage = "Good job, that is correct!"
                numbersCorrect += 1
            End If
            If studentAnswer <> correctAnswer Then
                userMessage = "Sorry, that is not correct. The correct answer was " & correctAnswer & "."
            End If
            MsgBox(userMessage)
            SummaryButton.Enabled = True
            numberOfProblems += 1
            randomNumber = CInt(Int((20 * Rnd()) + 0))
            FirstNumberTextBox.Text = Str(Int((20 * Rnd()) + 0))
            SecondNumberTextBox.Text = Str(Int((20 * Rnd()) + 0))
            StudentAnswerTextBox.Text = ""
        End If
    End Sub

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        'Displays summary
        MsgBox("You got " & numbersCorrect & " answers correct out of " & numberOfProblems & " problems.")
    End Sub


End Class

