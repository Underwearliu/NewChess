Public Class MoveChess
    Public Sub New()
        For b = 0 To SelectChess.getPossCounter
            MakePossInvisible(SelectChess.getXPoss(b), SelectChess.getYPoss(b))
        Next
    End Sub

    Public Sub MakePossInvisible(ByVal PossX As Byte, ByVal PossY As Byte)
        Board.PossBox(PossX, PossY).Visible = False
    End Sub
End Class
