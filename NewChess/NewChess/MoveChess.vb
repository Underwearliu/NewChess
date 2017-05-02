Public Class MoveChess


    Public Sub New(ByVal PossBoxX As Byte, ByVal PossBoxY As Byte)


        Dim OriginalX As Byte = SelectChess.getSelectX
        Dim OriginalY As Byte = SelectChess.getSelectY
        Dim Win As Boolean = False
        Dim WinningColour As String

        If Board.Location(PossBoxX, PossBoxY).Occupied = True Then
            Win = CheckWin(PossBoxX, PossBoxY)
        End If


        ChessReplacement(OriginalX, OriginalY, PossBoxX, PossBoxY)


        For b = 0 To SelectChess.getPossCounter
            MakePossInvisible(SelectChess.getXPoss(b), SelectChess.getYPoss(b))
        Next


        Form1.ChessUpChange()


        If Win = True Then

            If Form1.getCurrentPlayer = True Then
                WinningColour = "Red"
            Else
                WinningColour = "Black"
            End If

            MsgBox(WinningColour & " wins Game " & Form1.getRound & "!") 'Displays a winning message

            Form1.ChangeGameState()

        End If


    End Sub


    Private Sub ChessReplacement(ByVal X1 As Byte, Y1 As Byte, X2 As Byte, Y2 As Byte)

        'Replaces chess pieces 'Objective 25
        Board.Location(X2, Y2).Occupied = True
        Board.Location(X2, Y2).Side = Board.Location(X1, Y1).Side
        Board.Location(X2, Y2).Value = Board.Location(X1, Y1).Value
        Board.Location(X2, Y2).PicBox.Image = New Bitmap(Board.Location(X1, Y1).PicBox.Image, New Size(50, 50))
        Board.Location(X2, Y2).PicBox.Visible = True

        'Compare Original Location and PossBox Location to see whether player moved a chesspiece or not
        If X1 <> X2 Or Y1 <> Y2 Then
            Form1.PlayerChange() 'Change players 'Objective 16
            Board.Location(X1, Y1).Occupied = False
            Board.Location(X1, Y1).PicBox.Visible = False 'Objective 27
        End If

    End Sub


    Private Sub MakePossInvisible(ByVal PossX As Byte, ByVal PossY As Byte) 'Objective 27
        Board.PossBox(PossX, PossY).Visible = False
    End Sub


    Private Function CheckWin(ByVal X As Byte, Y As Byte)
        'Check if the chess piece being replaced is a General 'Objective 26
        If Form1.getCurrentPlayer <> Board.Location(X, Y).Side And Board.Location(X, Y).Value = 1 Then
            Return True
        End If
        Return False
    End Function


End Class
