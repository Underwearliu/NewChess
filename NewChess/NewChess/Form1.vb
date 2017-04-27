Public Class Form1


    Private NewGame As Game
    Private CurrentPlayer As Boolean = False 'Red Side always start first
    Public ChessUp As Boolean = False
    Private GameEnd As Boolean = False
    Private Answer As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ChessTimer.Enabled = True

        NewGame = New Game

    End Sub


    Private Sub ChessTimer_Tick(sender As Object, e As EventArgs) Handles ChessTimer.Tick


        If CurrentPlayer = True Then 'Display Player Turn
            PlayerTurn.Image = My.Resources.Black
        Else
            PlayerTurn.Image = My.Resources.Red
        End If


        If getChessUp() = False Then
            StatusLabel.Text = ""
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

            ChessTimer.Enabled = False

            Do
                Answer = InputBox("Do you wish to start a new game? (Yes/No)")
                If Answer = "Yes" Or Answer = "yes" Then
                    'Great
                ElseIf Answer = "No" Or Answer = "no" Then
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


End Class
