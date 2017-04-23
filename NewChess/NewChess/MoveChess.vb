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
            Form1.CurrentPlayer = Not Form1.CurrentPlayer
            Board.Location(OriginalX, OriginalY).Occupied = False
        End If

    End Sub



    Private Sub MakePossInvisible(ByVal PossX As Byte, ByVal PossY As Byte)
        Board.PossBox(PossX, PossY).Visible = False
    End Sub

    Private Function getImage(ByVal Side As Boolean, ByVal ChessValue As Byte)

        If Side = True Then
            Select Case ChessValue
                Case 1
                    Return My.Resources.General__Black_
                Case 2
                    Return My.Resources.Soldier__Black_
                Case 3
                    Return My.Resources.Chariot__Black_
                Case 4
                    Return My.Resources.Horse__Black_
                Case 5
                    Return My.Resources.Elephant__Black_
                Case 6
                    Return My.Resources.Advisor__Black_
                Case 7
                    Return My.Resources.Cannon__Black_
            End Select
        Else
            Select Case ChessValue
                Case 1
                    Return My.Resources.General__Red_
                Case 2
                    Return My.Resources.Soldier__Red_
                Case 3
                    Return My.Resources.Chariot__Red_
                Case 4
                    Return My.Resources.Horse__Red_
                Case 5
                    Return My.Resources.Elephant__Red_
                Case 6
                    Return My.Resources.Advisor__Red_
                Case 7
                    Return My.Resources.Cannon__Red_
            End Select
        End If

        Return Nothing

    End Function


End Class
