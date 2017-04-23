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

    Private Sub CalculatePossibles(ByVal ChessSide As Boolean, ByVal Value As Byte, ByRef ChessX As Byte, ByRef ChessY As Byte)
        'Bunch of Checks
        Select Case Value
            Case 1 'General
            Case 2 'Soldier
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
