Public Class SelectChess


    Private Shared SelectX As Byte
    Private Shared SelectY As Byte

    Private Shared PossCounter As Byte
    Private Shared XPoss(20) As Byte
    Private Shared YPoss(20) As Byte


    Public Sub New(ByVal ChessSide As Boolean, ByVal Value As Byte, ByRef ChessX As Byte, ByRef ChessY As Byte)

        SelectX = ChessX
        SelectY = ChessY

        PossCounter = 0
        CalculatePossibles(ChessSide, Value, ChessX, ChessY)
        Form1.ChessUp = True

        If PossCounter = 1 Then
            Form1.StatusLabel.Text = ("There is " & PossCounter & " possible move.")
        Else
            Form1.StatusLabel.Text = ("There are " & PossCounter & " possible moves.")
        End If

        For a = 0 To PossCounter
            MakePossVisible(XPoss(a), YPoss(a))
        Next

    End Sub


    Private Sub CalculatePossibles(ByVal ChessSide As Boolean, ByVal Value As Byte, ByVal ChessX As Byte, ByVal ChessY As Byte)

        'The Cancel SelectChess Move
        XPoss(PossCounter) = ChessX
        YPoss(PossCounter) = ChessY

        'Bunch of Checks

        Select Case Value
            Case 1 'General

                'Horizontal Movements
                If ChessX = 3 Or ChessX = 4 Then
                    If IsOwnChessThere(ChessSide, ChessX + 1, ChessY) = False Then
                        PossCounter += 1
                        XPoss(PossCounter) = ChessX + 1
                        YPoss(PossCounter) = ChessY
                    End If
                End If
                If ChessX = 4 Or ChessX = 5 Then
                    If IsOwnChessThere(ChessSide, ChessX - 1, ChessY) = False Then
                        PossCounter += 1
                        XPoss(PossCounter) = ChessX - 1
                        YPoss(PossCounter) = ChessY
                    End If
                End If

                'Vertical Movements
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
                Dim Left As Byte = 0
                Dim Right As Byte = 0
                Dim Up As Byte = 0
                Dim Down As Byte = 0

                If ChessX <> 0 Then
                    Do
                        Left += 1
                    Loop Until ChessX - Left = 0 Or Board.Location(ChessX - Left, ChessY).Occupied = True
                    If IsOwnChessThere(ChessSide, ChessX - Left, ChessY) = True Then
                        Left -= 1
                    End If
                    If Left <> 0 Then
                        For a = 1 To Left
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX - a
                            YPoss(PossCounter) = ChessY
                        Next
                    End If
                End If

                If ChessX <> 8 Then
                    Do
                        Right += 1
                    Loop Until ChessX + Right = 8 Or Board.Location(ChessX + Right, ChessY).Occupied = True
                    If IsOwnChessThere(ChessSide, ChessX + Right, ChessY) = True Then
                        Right -= 1
                    End If
                    If Right <> 0 Then
                        For b = 1 To Right
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX + b
                            YPoss(PossCounter) = ChessY
                        Next
                    End If
                End If

                If ChessY <> 0 Then
                    Do
                        Up += 1
                    Loop Until ChessY - Up = 0 Or Board.Location(ChessX, ChessY - Up).Occupied = True
                    If IsOwnChessThere(ChessSide, ChessX, ChessY - Up) = True Then
                        Up -= 1
                    End If
                    If Up <> 0 Then
                        For c = 1 To Up
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX
                            YPoss(PossCounter) = ChessY - c
                        Next
                    End If
                End If

                If ChessY <> 9 Then
                    Do
                        Down += 1
                    Loop Until ChessY + Down = 9 Or Board.Location(ChessX, ChessY + Down).Occupied = True
                    If IsOwnChessThere(ChessSide, ChessX, ChessY + Down) = True Then
                        Down -= 1
                    End If
                    If Down <> 0 Then
                        For d = 1 To Down
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX
                            YPoss(PossCounter) = ChessY + d
                        Next
                    End If
                End If

            Case 4 'Horse

                'Up then
                If ChessY >= 2 Then
                    If Board.Location(ChessX, ChessY - 1).Occupied = False Then
                        If ChessX <> 0 Then
                            If IsOwnChessThere(ChessSide, ChessX - 1, ChessY - 2) = False Then 'Left
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX - 1
                                YPoss(PossCounter) = ChessY - 2
                            End If
                        End If
                        If ChessX <> 8 Then
                            If IsOwnChessThere(ChessSide, ChessX + 1, ChessY - 2) = False Then 'Right
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX + 1
                                YPoss(PossCounter) = ChessY - 2
                            End If
                        End If
                    End If
                End If

                'Down then
                If ChessY <= 7 Then
                    If Board.Location(ChessX, ChessY + 1).Occupied = False Then
                        If ChessX <> 0 Then
                            If IsOwnChessThere(ChessSide, ChessX - 1, ChessY + 2) = False Then 'Left
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX - 1
                                YPoss(PossCounter) = ChessY + 2
                            End If
                        End If
                        If ChessX <> 8 Then
                            If IsOwnChessThere(ChessSide, ChessX + 1, ChessY + 2) = False Then 'Right
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX + 1
                                YPoss(PossCounter) = ChessY + 2
                            End If
                        End If
                    End If
                End If

                'Left then
                If ChessX >= 2 Then
                    If Board.Location(ChessX - 1, ChessY).Occupied = False Then
                        If ChessY <> 0 Then
                            If IsOwnChessThere(ChessSide, ChessX - 2, ChessY - 1) = False Then 'Up
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX - 2
                                YPoss(PossCounter) = ChessY - 1
                            End If
                        End If
                        If ChessY <> 9 Then
                            If IsOwnChessThere(ChessSide, ChessX - 2, ChessY + 1) = False Then 'Down
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX - 2
                                YPoss(PossCounter) = ChessY + 1
                            End If
                        End If
                    End If
                End If

                'Right then
                If ChessX <= 6 Then
                    If Board.Location(ChessX + 1, ChessY).Occupied = False Then
                        If ChessY <> 0 Then
                            If IsOwnChessThere(ChessSide, ChessX + 2, ChessY - 1) = False Then 'Up
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX + 2
                                YPoss(PossCounter) = ChessY - 1
                            End If
                        End If
                        If ChessY <> 9 Then
                            If IsOwnChessThere(ChessSide, ChessX + 2, ChessY + 1) = False Then 'Down
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX + 2
                                YPoss(PossCounter) = ChessY + 1
                            End If
                        End If
                    End If
                End If

            Case 5 'Elephant

                If ChessY = 0 Or ChessY = 2 Or ChessY = 5 Or ChessY = 7 Then
                    If ChessX <> 0 Then
                        If IsOwnChessThere(ChessSide, ChessX - 2, ChessY + 2) = False Then
                            If Board.Location(ChessX - 1, ChessY + 1).Occupied = False Then
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX - 2
                                YPoss(PossCounter) = ChessY + 2
                            End If
                        End If
                    End If
                    If ChessX <> 8 Then
                        If IsOwnChessThere(ChessSide, ChessX + 2, ChessY + 2) = False Then
                            If Board.Location(ChessX + 1, ChessY + 1).Occupied = False Then
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX + 2
                                YPoss(PossCounter) = ChessY + 2
                            End If
                        End If
                    End If
                End If

                If ChessY = 2 Or ChessY = 4 Or ChessY = 7 Or ChessY = 9 Then
                    If ChessX <> 0 Then
                        If IsOwnChessThere(ChessSide, ChessX - 2, ChessY - 2) = False Then
                            If Board.Location(ChessX - 1, ChessY - 1).Occupied = False Then
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX - 2
                                YPoss(PossCounter) = ChessY - 2
                            End If
                        End If
                    End If
                    If ChessX <> 8 Then
                        If IsOwnChessThere(ChessSide, ChessX + 2, ChessY - 2) = False Then
                            If Board.Location(ChessX + 1, ChessY - 1).Occupied = False Then
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX + 2
                                YPoss(PossCounter) = ChessY - 2
                            End If
                        End If
                    End If
                End If

            Case 6 'Advisor

                If ChessX = 3 Then
                    If ChessY = 0 Or ChessY = 7 Then
                        If IsOwnChessThere(ChessSide, ChessX + 1, ChessY + 1) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX + 1
                            YPoss(PossCounter) = ChessY + 1
                        End If
                    Else
                        If IsOwnChessThere(ChessSide, ChessX + 1, ChessY - 1) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX + 1
                            YPoss(PossCounter) = ChessY - 1
                        End If
                    End If
                End If

                If ChessX = 4 Then
                    If IsOwnChessThere(ChessSide, ChessX + 1, ChessY + 1) = False Then
                        PossCounter += 1
                        XPoss(PossCounter) = ChessX + 1
                        YPoss(PossCounter) = ChessY + 1
                    End If
                    If IsOwnChessThere(ChessSide, ChessX - 1, ChessY + 1) = False Then
                        PossCounter += 1
                        XPoss(PossCounter) = ChessX - 1
                        YPoss(PossCounter) = ChessY + 1
                    End If
                    If IsOwnChessThere(ChessSide, ChessX + 1, ChessY - 1) = False Then
                        PossCounter += 1
                        XPoss(PossCounter) = ChessX + 1
                        YPoss(PossCounter) = ChessY - 1
                    End If
                    If IsOwnChessThere(ChessSide, ChessX - 1, ChessY - 1) = False Then
                        PossCounter += 1
                        XPoss(PossCounter) = ChessX - 1
                        YPoss(PossCounter) = ChessY - 1
                    End If
                End If

                If ChessX = 5 Then
                    If ChessY = 0 Or ChessY = 7 Then
                        If IsOwnChessThere(ChessSide, ChessX - 1, ChessY + 1) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX - 1
                            YPoss(PossCounter) = ChessY + 1
                        End If
                    Else
                        If IsOwnChessThere(ChessSide, ChessX - 1, ChessY - 1) = False Then
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX - 1
                            YPoss(PossCounter) = ChessY - 1
                        End If
                    End If
                End If

            Case 7 'Cannon

                Dim Left As Byte = 0
                Dim Left2 As Byte = 0
                Dim Right As Byte = 0
                Dim Right2 As Byte = 0
                Dim Up As Byte = 0
                Dim Up2 As Byte = 0
                Dim Down As Byte = 0
                Dim Down2 As Byte = 0


                'Move Left
                If ChessX <> 0 Then
                    Do
                        Left += 1
                        Left2 += 1
                    Loop Until ChessX - Left = 0 Or Board.Location(ChessX - Left, ChessY).Occupied = True
                    If Board.Location(ChessX - Left, ChessY).Occupied = True Then
                        Left -= 1
                    End If
                    If Left <> 0 Then
                        For a = 1 To Left
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX - a
                            YPoss(PossCounter) = ChessY
                        Next
                    End If

                    'Eat Left
                    If Board.Location(ChessX - Left2, ChessY).Occupied = True Then
                        If ChessX - Left2 <> 0 Then
                            Do
                                Left2 += 1
                            Loop Until ChessX - Left2 = 0 Or Board.Location(ChessX - Left2, ChessY).Occupied = True
                            If Board.Location(ChessX - Left2, ChessY).Occupied = True Then
                                If IsOwnChessThere(ChessSide, ChessX - Left2, ChessY) = False Then
                                    PossCounter += 1
                                    XPoss(PossCounter) = ChessX - Left2
                                    YPoss(PossCounter) = ChessY
                                End If
                            End If
                        End If
                    End If

                End If


                'Move Right
                If ChessX <> 8 Then
                    Do
                        Right += 1
                        Right2 += 1
                    Loop Until ChessX + Right = 8 Or Board.Location(ChessX + Right, ChessY).Occupied = True
                    If Board.Location(ChessX + Right, ChessY).Occupied = True Then
                        Right -= 1
                    End If
                    If Right <> 0 Then
                        For b = 1 To Right
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX + b
                            YPoss(PossCounter) = ChessY
                        Next
                    End If
                End If

                'Eat Right
                If Board.Location(ChessX + Right2, ChessY).Occupied = True Then
                    If ChessX + Right2 <> 8 Then
                        Do
                            Right2 += 1
                        Loop Until ChessX + Right2 = 8 Or Board.Location(ChessX + Right2, ChessY).Occupied = True
                        If Board.Location(ChessX + Right2, ChessY).Occupied = True Then
                            If IsOwnChessThere(ChessSide, ChessX + Right2, ChessY) = False Then
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX + Right2
                                YPoss(PossCounter) = ChessY
                            End If
                        End If
                    End If
                End If


                'Move Up
                If ChessY <> 0 Then
                    Do
                        Up += 1
                        Up2 += 1
                    Loop Until ChessY - Up = 0 Or Board.Location(ChessX, ChessY - Up).Occupied = True
                    If Board.Location(ChessX, ChessY - Up).Occupied = True Then
                        Up -= 1
                    End If
                    If Up <> 0 Then
                        For c = 1 To Up
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX
                            YPoss(PossCounter) = ChessY - c
                        Next
                    End If
                End If

                'Eat Up
                If Board.Location(ChessX, ChessY - Up2).Occupied = True Then
                    If ChessY - Up2 <> 0 Then
                        Do
                            Up2 += 1
                        Loop Until ChessY - Up2 = 0 Or Board.Location(ChessX, ChessY - Up2).Occupied = True
                        If Board.Location(ChessX, ChessY - Up2).Occupied = True Then
                            If IsOwnChessThere(ChessSide, ChessX, ChessY - Up2) = False Then
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX
                                YPoss(PossCounter) = ChessY - Up2
                            End If
                        End If
                    End If
                End If


                'Move Down
                If ChessY <> 9 Then
                    Do
                        Down += 1
                        Down2 += 1
                    Loop Until ChessY + Down = 9 Or Board.Location(ChessX, ChessY + Down).Occupied = True
                    If Board.Location(ChessX, ChessY + Down).Occupied = True Then
                        Down -= 1
                    End If
                    If Down <> 0 Then
                        For d = 1 To Down
                            PossCounter += 1
                            XPoss(PossCounter) = ChessX
                            YPoss(PossCounter) = ChessY + d
                        Next
                    End If
                End If

                'Eat Down
                If Board.Location(ChessX, ChessY + Down2).Occupied = True Then
                    If ChessY + Down2 <> 9 Then
                        Do
                            Down2 += 1
                        Loop Until ChessY + Down2 = 9 Or Board.Location(ChessX, ChessY + Down2).Occupied = True
                        MsgBox(Down2)
                        If Board.Location(ChessX, ChessY + Down2).Occupied = True Then
                            If IsOwnChessThere(ChessSide, ChessX, ChessY + Down2) = False Then
                                PossCounter += 1
                                XPoss(PossCounter) = ChessX
                                YPoss(PossCounter) = ChessY + Down2
                            End If
                        End If
                    End If
                End If


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


    Public Shared Function getSelectX()
        Return SelectX
    End Function


    Public Shared Function getSelectY()
        Return SelectY
    End Function


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
