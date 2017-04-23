Public Class Player

    Public Sub New(ByRef Side As Boolean)

        SetUpChess(Side)

    End Sub

    Private Sub SetUpChess(ByVal Side As Boolean)

        If Side = True Then 'Black Side Chess
            For a = 1 To 16
                Select Case a
                    Case 1 'Black General
                        LocateChess(a, 1, My.Resources.General__Black_, 4, 0, Side)
                    Case 2 To 6 'Black Soldiers
                        LocateChess(a, 2, My.Resources.Soldier__Black_, (a - 2) * 2, 3, Side)
                    Case 7 'Black Chariot (Left)
                        LocateChess(a, 3, My.Resources.Chariot__Black_, 0, 0, Side)
                    Case 8 'Black Chariot (Right)
                        LocateChess(a, 3, My.Resources.Chariot__Black_, 8, 0, Side)
                    Case 9 'Black Horse (Left)
                        LocateChess(a, 4, My.Resources.Horse__Black_, 1, 0, Side)
                    Case 10 'Black Horse (Right)
                        LocateChess(a, 4, My.Resources.Horse__Black_, 7, 0, Side)
                    Case 11 'Black Elephant (Left)
                        LocateChess(a, 4, My.Resources.Elephant__Black_, 2, 0, Side)
                    Case 12 'Black Elephant (Right)
                        LocateChess(a, 4, My.Resources.Elephant__Black_, 6, 0, Side)
                    Case 13 'Black Advisor (Left)
                        LocateChess(a, 4, My.Resources.Advisor__Black_, 3, 0, Side)
                    Case 14 'Black Advisor (Right)
                        LocateChess(a, 4, My.Resources.Advisor__Black_, 5, 0, Side)
                    Case 15 'Black Cannon (Left)
                        LocateChess(a, 4, My.Resources.Cannon__Black_, 1, 2, Side)
                    Case 16 'Black Cannon (Right)
                        LocateChess(a, 4, My.Resources.Cannon__Black_, 7, 2, Side)
                End Select
            Next
        Else
            For b = 1 To 16
                Select Case b
                    Case 1 'Red General
                        LocateChess(b, 1, My.Resources.General__Red_, 4, 9, Side)
                    Case 2 To 6 'Red Soldiers
                        LocateChess(b, 2, My.Resources.Soldier__Red_, (b - 2) * 2, 6, Side)
                    Case 7 'Red Chariot (Left)
                        LocateChess(b, 3, My.Resources.Chariot__Red_, 0, 9, Side)
                    Case 8 'Red Chariot (Right)
                        LocateChess(b, 3, My.Resources.Chariot__Red_, 8, 9, Side)
                    Case 9 'Red Horse (Left)
                        LocateChess(b, 4, My.Resources.Horse__Red_, 1, 9, Side)
                    Case 10 'Red Horse (Right)
                        LocateChess(b, 4, My.Resources.Horse__Red_, 7, 9, Side)
                    Case 11 'Red Elephant (Left)
                        LocateChess(b, 4, My.Resources.Elephant__Red_, 2, 9, Side)
                    Case 12 'Red Elephant (Right)
                        LocateChess(b, 4, My.Resources.Elephant__Red_, 6, 9, Side)
                    Case 13 'Red Advisor (Left)
                        LocateChess(b, 4, My.Resources.Advisor__Red_, 3, 9, Side)
                    Case 14 'Red Advisor (Right)
                        LocateChess(b, 4, My.Resources.Advisor__Red_, 5, 9, Side)
                    Case 15 'Red Cannon (Left)
                        LocateChess(b, 4, My.Resources.Cannon__Red_, 1, 7, Side)
                    Case 16 'Red Cannon (Right)
                        LocateChess(b, 4, My.Resources.Cannon__Red_, 7, 7, Side)
                End Select
            Next
        End If

    End Sub

    Private Sub LocateChess(ByRef ID As Byte, ByRef Value As Byte, ByRef Icon As Image, ByRef BoardX As Byte, ByRef BoardY As Byte, ByRef ChessSide As Boolean)
        Board.Location(BoardX, BoardY).Occupied = True
        Board.Location(BoardX, BoardY).Side = ChessSide
        Board.Location(BoardX, BoardY).ID = ID
        Board.Location(BoardX, BoardY).PicBox.Image = New Bitmap(Icon, New Size(50, 50))
        Board.Location(BoardX, BoardY).PicBox.Visible = True
    End Sub

End Class
