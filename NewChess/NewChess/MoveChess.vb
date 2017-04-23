Public Class MoveChess

    Public Sub New(ByVal PossBoxX As Byte, ByVal PossBoxY As Byte)

        Dim OriginalX As Byte = SelectChess.getSelectX
        Dim OriginalY As Byte = SelectChess.getSelectY


        Board.Location(PossBoxX, PossBoxY).Occupied = True
        Board.Location(PossBoxX, PossBoxY).Side = Board.Location(OriginalX, OriginalY).Side
        Board.Location(PossBoxX, PossBoxY).Value = Board.Location(OriginalX, OriginalY).Value
        Board.Location(PossBoxX, PossBoxY).PicBox.Image = New Bitmap(Board.Location(OriginalX, OriginalY).PicBox.Image, New Size(50, 50))
        Board.Location(PossBoxX, PossBoxY).PicBox.Visible = True


        For b = 0 To SelectChess.getPossCounter
            MakePossInvisible(SelectChess.getXPoss(b), SelectChess.getYPoss(b))
        Next

        Form1.ChessUp = False

        If OriginalX <> PossBoxX Or OriginalY <> PossBoxY Then
            'Form1.CurrentPlayer = Not Form1.CurrentPlayer
            Board.Location(OriginalX, OriginalY).Occupied = False
            Board.Location(OriginalX, OriginalY).PicBox.Visible = False
        End If

    End Sub


    Private Sub MakePossInvisible(ByVal PossX As Byte, ByVal PossY As Byte)
        Board.PossBox(PossX, PossY).Visible = False
    End Sub


End Class
