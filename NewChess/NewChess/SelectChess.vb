﻿Public Class SelectChess
    Private Shared PossCounter As Byte
    Private Shared XPoss(20) As Byte
    Private Shared YPoss(20) As Byte


    Public Sub New(ByVal ChessSide As Boolean, ByVal Value As Byte, ByRef ChessX As Byte, ByRef ChessY As Byte)
        PossCounter = 0
        CalculatePossibles(ChessSide, Value, ChessX, ChessY)
        Form1.ChessUp = True

        If PossCounter = 1 Then
            Form1.StatusLabel.Text = ("There is " & PossCounter & " possible move.")
        Else
            Form1.StatusLabel.Text = ("There are " & PossCounter & " possible moves.")
        End If

        For a = 0 To PossCounter
            MsgBox(a & XPoss(a) & YPoss(a))
            MakePossVisible(XPoss(a), YPoss(a))
        Next

    End Sub

    Private Sub CalculatePossibles(ByVal ChessSide As Boolean, ByVal Value As Byte, ByVal ChessX As Byte, ByVal ChessY As Byte)

        XPoss(PossCounter) = ChessX
        YPoss(PossCounter) = ChessY



        'Bunch of Checks

        Select Case Value
            Case 1 'General

            Case 2 'Soldier
                If ChessSide = True Then
                    If ChessY < 9 Then
                        If IsOwnChessThere(ChessSide, ChessX, ChessY + 1) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX
                            YPoss(PossCounter) = ChessY + 1
                        End If
                    End If

                    If ChessY >= 5 Then
                        If ChessX <> 0 Then
                            If IsOwnChessThere(ChessSide, ChessX - 1, ChessY) = False Then
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX - 1
                                YPoss(PossCounter) = ChessY
                            End If
                            If ChessX <> 8 Then
                                If IsOwnChessThere(ChessSide, ChessX + 1, ChessY) = False Then
                                    PossCounter += 1
                                    XPoss(PossCounter) = ChessX + 1
                                    YPoss(PossCounter) = ChessY
                                End If
                            End If
                        End If
                    End If

                Else
                    If ChessY > 0 Then
                        If IsOwnChessThere(ChessSide, ChessX, ChessY - 1) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX
                            YPoss(PossCounter) = ChessY - 1
                        End If
                    End If

                    If ChessY <= 4 Then
                        If ChessX <> 0 Then
                            If IsOwnChessThere(ChessSide, ChessX - 1, ChessY) = False Then
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX - 1
                                YPoss(PossCounter) = ChessY
                            End If
                            If ChessX <> 8 Then
                                If IsOwnChessThere(ChessSide, ChessX + 1, ChessY) = False Then
                                    PossCounter += 1
                                    XPoss(PossCounter) = ChessX + 1
                                    YPoss(PossCounter) = ChessY
                                End If
                            End If
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
