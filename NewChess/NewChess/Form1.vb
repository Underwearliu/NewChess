Public Class Form1

    Private NewGame As Game
    Public CurrentPlayer As Boolean = True 'Red Side always start first
    Public ChessUp As Boolean = False
    Public CurrentX As Byte
    Public CurrentY As Byte


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

        If ChessUp = False Then
            StatusLabel.Text = ""
        End If
    End Sub

End Class
