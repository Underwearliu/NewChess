Public Class SelectChess
    Private Shared PossCounter As Byte
    Private Shared XPoss(20) As Byte
    Private Shared YPoss(20) As Byte


    Public Sub New(ByVal Value As Byte, ByVal ChessSide As Boolean, ByRef ChessX As Byte, ByRef ChessY As Byte)
        PossCounter = 0
        CalculatePossibles(Value, ChessSide, ChessX, ChessY)
        Form1.ChessUp = True
        'Board.PicBox(ChessX, ChessY).Visible = False
        If PossCounter = 1 Then
            Form1.StatusLabel.Text = ("There is " & PossCounter & " possible move.")
        Else
            Form1.StatusLabel.Text = ("There are " & PossCounter & " possible moves.")
        End If

        For a = 1 To PossCounter
            MakePossVisible(XPoss(a), YPoss(a))
        Next

        If PossCounter = 0 Then
            Form1.ChessUp = False
        End If
    End Sub

    Private Sub CalculatePossibles(ByVal Value As Byte, ByVal ChessSide As Boolean, ByRef ChessX As Byte, ByRef ChessY As Byte)
        'Bunch of Checks
        Select Case Value
            Case 1 'Soldier
                'Before River
                If ChessSide = True And ChessY < 9 Then
                    If IsOwnChessThere(ChessSide, ChessX, ChessY + 1) = False Then
                        PossCounter += 1
                        XPoss(PossCounter) = ChessX
                        YPoss(PossCounter) = ChessY + 1
                    End If
                End If
                If ChessSide = False And ChessY > 0 Then
                    If IsOwnChessThere(ChessSide, ChessX, ChessY - 1) = False Then
                        PossCounter += 1
                        XPoss(PossCounter) = ChessX
                        YPoss(PossCounter) = ChessY - 1
                    End If
                End If
                If (ChessSide = True And ChessY >= 5) Or (ChessSide = False And ChessY <= 4) Then
                    'Passed River               
                    If ChessX <> 0 Then
                        'Move Left
                        If IsOwnChessThere(ChessSide, ChessX - 1, ChessY) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX - 1
                            YPoss(PossCounter) = ChessY
                        End If
                    ElseIf ChessX <> 9 Then
                        'Move Right
                        If IsOwnChessThere(ChessSide, ChessX + 1, ChessY) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX + 1
                            YPoss(PossCounter) = ChessY
                        End If
                    End If
                End If

            Case 2 'General
                If ChessX >= 3 And ChessX <= 4 Then
                    If IsOwnChessThere(ChessSide, ChessX + 1, ChessY) = False Then
                        PossCounter += 1
                        XPoss(PossCounter) = ChessX + 1
                        YPoss(PossCounter) = ChessY
                    End If
                End If
                If ChessX >= 4 And ChessX <= 5 Then
                    If IsOwnChessThere(ChessSide, ChessX - 1, ChessY) = False Then
                        PossCounter += 1
                        XPoss(PossCounter) = ChessX - 1
                        YPoss(PossCounter) = ChessY
                    End If
                End If
                If ChessSide = True Then
                    If ChessY = 0 Or ChessY = 1 Then
                        If IsOwnChessThere(ChessSide, ChessX, ChessY + 1) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX
                            YPoss(PossCounter) = ChessY + 1
                        End If
                    End If
                    If ChessY = 1 Or ChessY = 2 Then
                        If IsOwnChessThere(ChessSide, ChessX, ChessY - 1) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX
                            YPoss(PossCounter) = ChessY - 1
                        End If
                    End If
                Else
                    If ChessY = 7 Or ChessY = 8 Then
                        If IsOwnChessThere(ChessSide, ChessX, ChessY + 1) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX
                            YPoss(PossCounter) = ChessY + 1
                        End If
                    End If
                    If ChessY = 8 Or ChessY = 9 Then
                        If IsOwnChessThere(ChessSide, ChessX, ChessY - 1) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX
                            YPoss(PossCounter) = ChessY - 1
                        End If
                    End If
                End If

            Case 3 'Chariot
            Case 4 'Horse
            Case 5 'Elephant
            Case 6 'Advisor
            Case 7 'Cannon
        End Select

    End Sub

    Public Function IsOwnChessThere(ByRef CSide As Boolean, ByVal PossChessX As Byte, ByVal PossChessY As Byte)

        If Board.Location(PossChessX, PossChessY).Occupied = False Then
            Return False
        Else
            If Board.Location(PossChessX, PossChessY).Side = CSide Then
                Return True
            Else
                Return False
            End If
        End If

    End Function

    Private Sub MakePossVisible(ByVal PossX As Byte, ByVal PossY As Byte)
        Board.PossBox(PossX, PossY).Visible = True
    End Sub

    Public Shared Function getPossCounter()
        Return PossCounter
    End Function

    Public Shared Function getXPoss(ByRef Poss As Byte)
        Return XPoss(Poss)
    End Function

    Public Shared Function getYPoss(ByRef Poss As Byte)
        Return YPoss(Poss)
    End Function
End Class
