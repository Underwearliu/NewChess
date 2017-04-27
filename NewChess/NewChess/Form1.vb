Public Class Form1


    Private NewGame As Game
    Private Player1 As PlayerDetails
    Private Player2 As PlayerDetails
    Private CurrentPlayer As Boolean = False 'Red Side always start first
    Private Round As Byte = 0
    Public ChessUp As Boolean = False
    Private GameEnd As Boolean = False
    Private Answer As String

    Private Structure PlayerDetails
        Dim Name As String
        Dim Score As Byte
        Dim CurrentColour As Boolean
    End Structure

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Player1.Name = InputBox("Please enter the name of Player 1 (Starting First)", "Player 1 Name", "Player 1")
        Player2.Name = InputBox("Please enter the name of Player 2 (Starting Second)", "Player 2 Name", "Player 2")

        If Player1.Name = "" Then
            Player1.Name = "Player 1"
        End If
        If Player2.Name = "" Then
            Player2.Name = "Player 2"
        End If

        Player1.Score = 0
        Player2.Score = 0

        Player1Name.Text = Player1.Name
        Player2Name.Text = Player2.Name

        StartNewRound()

        ChessTimer.Enabled = True


        NewGame = New Game

    End Sub


    Private Sub ChessTimer_Tick(sender As Object, e As EventArgs) Handles ChessTimer.Tick

        Player1Score.Text = Player1.Score
        Player2Score.Text = Player2.Score

        If CurrentPlayer = True Then 'Display Player Turn
            PlayerTurn.Image = My.Resources.Black
        Else
            PlayerTurn.Image = My.Resources.Red
        End If

        If getChessUp() = False Then
            If CurrentPlayer = Player1.CurrentColour Then
                StatusLabel.Text = "It is " & Player1.Name & "'s turn!"
            Else
                StatusLabel.Text = "It is " & Player2.Name & "'s turn!"
            End If

        End If

        NewGameQuestionMark()

    End Sub


    Public Function getCurrentPlayer()
        Return CurrentPlayer
    End Function


    Public Sub PlayerChange()
        CurrentPlayer = Not CurrentPlayer
    End Sub


    Public Function getChessUp()
        Return ChessUp
    End Function


    Public Sub ChessUpChange()
        ChessUp = Not ChessUp
    End Sub


    Public Sub ChangeGameState()
        GameEnd = Not GameEnd
    End Sub


    Private Sub NewGameQuestionMark()

        If GameEnd = True Then

            If CurrentPlayer <> Player1.CurrentColour Then
                Player1.Score += 1
            Else
                Player2.Score += 1
            End If

            ChessTimer.Enabled = False

            Do
                Answer = InputBox("Do you wish to start a new game? (Yes/No)", "New Game", "Yes")
                If Answer = "Yes" Or Answer = "yes" Then
                    'Great
                ElseIf Answer = "No" Or Answer = "no" Then
                    If Player1.Score > Player2.Score Then
                        MsgBox("Congratulations to " & Player1.Name & " who beat " & Player2.Name & " " & Player1.Score & " to " & Player2.Score & "!")
                    ElseIf Player1.Score < Player2.Score Then
                        MsgBox("Congratulations to " & Player2.Name & " who beat " & Player1.Name & " " & Player2.Score & " to " & Player1.Score & "!")
                    Else
                        MsgBox("Phew! It was a draw between " & Player1.Name & " and " & Player2.Name & " with a score of " & Player1.Score & " to " & Player2.Score & "!")
                    End If
                    End
                Else
                    MsgBox("Please enter a valid answer!")
                End If
            Loop Until Answer = "Yes" Or Answer = "yes"

            If Answer = "Yes" Or Answer = "yes" Then
                ChangeGameState()
                ClearsBoard()
                NewGame = New Game
                CurrentPlayer = False
                StartNewRound()
                ChessTimer.Enabled = True
                End If

            End If

    End Sub


    Private Sub ClearsBoard()

        For a = 0 To Board.BoardX
            For b = 0 To Board.BoardY
                Board.Location(a, b).Occupied = False
                Board.Location(a, b).PicBox.Visible = False
            Next
        Next

    End Sub

    Private Sub StartNewRound()
        Round += 1
        If Round Mod 2 = 1 Then
            Player1.CurrentColour = False
            Player2.CurrentColour = True
        Else
            Player1.CurrentColour = True
            Player2.CurrentColour = False
        End If
    End Sub

End Class
