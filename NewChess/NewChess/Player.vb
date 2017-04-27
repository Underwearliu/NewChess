Public Class Player
    'For Distributing Chess pieces to location on the board

    Public Sub New(ByRef Side As Boolean)

        SetUpChess(Side)

    End Sub


    Private Sub SetUpChess(ByVal Side As Boolean)

        If Side = True Then 'Black Side Chess
            For a = 1 To 16
                Select Case a
                    Case 1 'Black General
                        LocateChess(1, getImage(True, 1), 4, 0, Side)
                    Case 2 To 6 'Black Soldiers
                        LocateChess(2, getImage(True, 2), (a - 2) * 2, 3, Side)
                    Case 7 'Black Chariot (Left)
                        LocateChess(3, getImage(True, 3), 0, 0, Side)
                    Case 8 'Black Chariot (Right)
                        LocateChess(3, getImage(True, 3), 8, 0, Side)
                    Case 9 'Black Horse (Left)
                        LocateChess(4, getImage(True, 4), 1, 0, Side)
                    Case 10 'Black Horse (Right)
                        LocateChess(4, getImage(True, 4), 7, 0, Side)
                    Case 11 'Black Elephant (Left)
                        LocateChess(5, getImage(True, 5), 2, 0, Side)
                    Case 12 'Black Elephant (Right)
                        LocateChess(5, getImage(True, 5), 6, 0, Side)
                    Case 13 'Black Advisor (Left)
                        LocateChess(6, getImage(True, 6), 3, 0, Side)
                    Case 14 'Black Advisor (Right)
                        LocateChess(6, getImage(True, 6), 5, 0, Side)
                    Case 15 'Black Cannon (Left)
                        LocateChess(7, getImage(True, 7), 1, 2, Side)
                    Case 16 'Black Cannon (Right)
                        LocateChess(7, getImage(True, 7), 7, 2, Side)
                End Select
            Next
        Else
            For b = 1 To 16
                Select Case b
                    Case 1 'Red General
                        LocateChess(1, getImage(False, 1), 4, 9, Side)
                    Case 2 To 6 'Red Soldiers
                        LocateChess(2, getImage(False, 2), (b - 2) * 2, 6, Side)
                    Case 7 'Red Chariot (Left)
                        LocateChess(3, getImage(False, 3), 0, 9, Side)
                    Case 8 'Red Chariot (Right)
                        LocateChess(3, getImage(False, 3), 8, 9, Side)
                    Case 9 'Red Horse (Left)
                        LocateChess(4, getImage(False, 4), 1, 9, Side)
                    Case 10 'Red Horse (Right)
                        LocateChess(4, getImage(False, 4), 7, 9, Side)
                    Case 11 'Red Elephant (Left)
                        LocateChess(5, getImage(False, 5), 2, 9, Side)
                    Case 12 'Red Elephant (Right)
                        LocateChess(5, getImage(False, 5), 6, 9, Side)
                    Case 13 'Red Advisor (Left)
                        LocateChess(6, getImage(False, 6), 3, 9, Side)
                    Case 14 'Red Advisor (Right)
                        LocateChess(6, getImage(False, 6), 5, 9, Side)
                    Case 15 'Red Cannon (Left)
                        LocateChess(7, getImage(False, 7), 1, 7, Side)
                    Case 16 'Red Cannon (Right)
                        LocateChess(7, getImage(False, 7), 7, 7, Side)
                End Select
            Next
        End If

    End Sub


    Private Sub LocateChess(ByRef Value As Byte, ByRef Icon As Image, ByRef BoardX As Byte, ByRef BoardY As Byte, ByRef ChessSide As Boolean)
        Board.Location(BoardX, BoardY).Occupied = True
        Board.Location(BoardX, BoardY).Side = ChessSide
        Board.Location(BoardX, BoardY).Value = Value
        Board.Location(BoardX, BoardY).PicBox.Image = New Bitmap(Icon, New Size(50, 50))
        Board.Location(BoardX, BoardY).PicBox.Visible = True
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
