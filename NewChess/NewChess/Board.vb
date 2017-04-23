Public Class Board

    Public Const BoardX As Byte = 8
    Public Const BoardY As Byte = 9
    Public Const StartX = 21 'Top left hand corner of the board
    Public Const StartY = 8  'Top left hand corner of the board
    Public Const IntervalX As SByte = 86 'For Chesspieces gap
    Public Const IntervalY As SByte = 77 'For Chesspieces gap

    Private ChessMove As MoveChess

    Public Structure Details
        Dim Occupied As Boolean
        Dim Side As Boolean
        Dim ID As Byte
        Dim X As Byte
        Dim Y As Byte
        Dim PicBox As PictureBox
    End Structure

    Public Shared Location(BoardX, BoardY) As Details
    'Public Shared PicBox(BoardX, BoardY) As PictureBox
    Public Shared PossBox(BoardX, BoardY) As PictureBox

    Public Sub New()
        SetupBasePicBox()
        SetupPossible()
    End Sub

    Private Sub SetupBasePicBox()
        For x = 0 To BoardX
            For y = 0 To BoardY
                Location(x, y).PicBox = New PictureBox
                Location(x, y).PicBox.Parent = Form1
                Location(x, y).PicBox.Image = New Bitmap(My.Resources.Black, New Size(50, 50)) 'Default
                Location(x, y).PicBox.Size = Location(x, y).PicBox.Image.Size()
                Location(x, y).PicBox.Location = New Point(StartX + (x * IntervalX), StartY + (y * IntervalY))
                Location(x, y).PicBox.BringToFront()
                Location(x, y).PicBox.Visible = False
                AddHandler Location(x, y).PicBox.Click, AddressOf picBox_Click
            Next
        Next
    End Sub

    Private Sub picBox_Click(sender As Object, e As EventArgs)
        'If Side = VisualBoard.CurrentPlayer And VisualBoard.ChessUp = False Then
        '    'VisualBoard.CurrentPlayer = Not VisualBoard.CurrentPlayer
        '    CurrentID = ChessID
        '    CurrentSide = Side
        '    VisualBoard.ChessUp = True
        '    ChessUp = New PickUpChess(ChessValue, Side, ChessX, ChessY)
        'End If
    End Sub


    Private Sub SetupPossible()
        Const PossX As Integer = IntervalX - 50
        Const PossY As Integer = IntervalY - 40
        For x = 0 To BoardX
            For y = 0 To BoardY
                PossBox(x, y) = New PictureBox
                PossBox(x, y).Parent = Form1
                PossBox(x, y).Image = New Bitmap(My.Resources.Target, New Size(PossX, PossY))
                PossBox(x, y).Size = PossBox(x, y).Image.Size()
                PossBox(x, y).Location = New Point(StartX + (x * IntervalX + 8), StartY + (y * IntervalY + 8))
                PossBox(x, y).BringToFront()
                PossBox(x, y).Visible = False
                AddHandler PossBox(x, y).Click, AddressOf possBox_Click
            Next
        Next
    End Sub

    Private Sub possBox_Click(sender As Object, e As EventArgs)
        If Form1.ChessUp = True Then
            ChessMove = New MoveChess()
        End If
        Form1.ChessUp = False
        Form1.CurrentPlayer = Not Form1.CurrentPlayer
    End Sub


End Class
