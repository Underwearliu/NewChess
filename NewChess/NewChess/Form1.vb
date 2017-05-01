Public Class Form1


    Private NewGame As Game
    Private Player1 As PlayerDetails
    Private Player2 As PlayerDetails
    Private CurrentPlayer As Boolean = False 'Red Side always start first
    Private Round As Byte = 0
    Private TotalRounds As Byte
    Public ChessUp As Boolean = False
    Private GameEnd As Boolean = False
    Private Answer As String

    Private Structure PlayerDetails
        Dim Name As String
        Dim Score As Byte
        Dim CurrentSide As Boolean
    End Structure

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Name input
        Player1.Name = InputBox("Please enter the name of Player 1 (Starting First)", "Player 1 Name", "Player 1")
        Player2.Name = InputBox("Please enter the name of Player 2 (Starting Second)", "Player 2 Name", "Player 2")

        'If nothing is entered give them a name
        If Player1.Name = "" Then
            Player1.Name = "Player 1"
        End If
        If Player2.Name = "" Then
            Player2.Name = "Player 2"
        End If

        'Input Number of rounds
        TotalRounds = getTotalRound()

        'Set score of both player to 0
        Player1.Score = 0
        Player2.Score = 0

        'Display players' name
        Player1Name.Text = Player1.Name
        Player2Name.Text = Player2.Name

        'Start a new round and put players to their corresponding side this round
        StartNewRound()

        'Start timer
        ChessTimer.Enabled = True

        'Start a new game
        NewGame = New Game

    End Sub


    Private Sub ChessTimer_Tick(sender As Object, e As EventArgs) Handles ChessTimer.Tick

        'Display players' score
        Player1Score.Text = Player1.Score
        Player2Score.Text = Player2.Score

        'Checks and Update the display of current player picture box on screen (top right hand corner)
        If CurrentPlayer = True Then 'Display Player Turn
            PlayerTurn.Image = My.Resources.Black
        Else
            PlayerTurn.Image = My.Resources.Red
        End If

        'Display a message in the middle after one player has made a move to signal it's the other player's turn
        If getChessUp() = False Then
            If CurrentPlayer = Player1.CurrentSide Then
                StatusLabel.Text = "It is " & Player1.Name & "'s turn!"
            Else
                StatusLabel.Text = "It is " & Player2.Name & "'s turn!"
            End If

        End If

        'New Game?
        NewGameQuestionMark()

    End Sub


    Private Function getTotalRound() 'Request user the number of rounds to play

        Dim Input As String
        Dim Rounds As Byte

        Do
            Try

                Input = InputBox("How many rounds do you want to play? (1 - 10 recommended) (Leave blank or (0) if undecided)", "Number of Rounds")

                If Input = "" Then
                    Input = "255"
                End If

                Rounds = CInt(Input)

            Catch ex As Exception 'If input is not an integer

                MsgBox("Please enter a valid number")

            End Try

        Loop Until Rounds >= 1 And Rounds <= 255

        Return Rounds

    End Function


    Private Sub NewGameQuestionMark() 'Decides whether to go to next round or ending the game

        If GameEnd = True Then

            If CurrentPlayer <> Player1.CurrentSide Then
                Player1.Score += 1
            Else
                Player2.Score += 1
            End If

            ChessTimer.Enabled = False


            If Round = TotalRounds And TotalRounds <> 255 Then

                DisplayEndingMessage()

            Else

                Do
                    Answer = InputBox("Do you wish to start the next round? (Yes/No) (No = Quit)", "New Game", "Yes")
                    If Answer = "Yes" Or Answer = "yes" Then
                        'Great
                    ElseIf Answer = "No" Or Answer = "no" Then
                        DisplayEndingMessage()
                    Else
                        MsgBox("Please enter a valid answer!")
                    End If
                Loop Until Answer = "Yes" Or Answer = "yes"

            End If

            If Round <> TotalRounds And Answer = "Yes" Or Answer = "yes" Then
                ChangeGameState()
                ClearsBoard()
                NewGame = New Game
                CurrentPlayer = False
                StartNewRound()
                ChessTimer.Enabled = True
            End If


        End If

    End Sub


    Private Sub DisplayEndingMessage() 'If game is ending then display message as shown as below
        If Player1.Score > Player2.Score Then
            MsgBox("Congratulations to " & Player1.Name & " who beat " & Player2.Name & " " & Player1.Score & " to " & Player2.Score & "!")
        ElseIf Player1.Score < Player2.Score Then
            MsgBox("Congratulations to " & Player2.Name & " who beat " & Player1.Name & " " & Player2.Score & " to " & Player1.Score & "!")
        Else
            MsgBox("Phew! It was a draw between " & Player1.Name & " and " & Player2.Name & " with a score of " & Player1.Score & " to " & Player2.Score & "!")
        End If
        End
    End Sub


    Private Sub ClearsBoard() 'Wipes board for new round

        For a = 0 To Board.BoardX
            For b = 0 To Board.BoardY
                Board.Location(a, b).Occupied = False
                Board.Location(a, b).PicBox.Visible = False
            Next
        Next

    End Sub


    Private Sub StartNewRound() 'Add 1 to counter for new round
        Round += 1
        If Round Mod 2 = 1 Then
            Player1.CurrentSide = False
            Player2.CurrentSide = True
        Else
            Player1.CurrentSide = True
            Player2.CurrentSide = False
        End If
    End Sub


    Public Function getRound()
        Return Round
    End Function


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


End Class
