Public Class Form1

    Private NewGame As Game
    Public CurrentPlayer As Boolean = False 'Red Side always start first
    Public ChessUp As Boolean = False

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

        For x = 1 To Board.BoardX
            For y = 1 To Board.BoardY
                Board.Location(x, y).PicBox.Visible = Board.Location(x, y).Occupied
            Next
        Next

    End Sub

End Class
