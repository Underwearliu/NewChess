<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.PlayerTurn = New System.Windows.Forms.PictureBox()
        Me.ChessTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label = New System.Windows.Forms.Label()
        Me.Player1Name = New System.Windows.Forms.Label()
        Me.Player1Score = New System.Windows.Forms.Label()
        Me.Player2Name = New System.Windows.Forms.Label()
        Me.Player2Score = New System.Windows.Forms.Label()
        CType(Me.PlayerTurn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabel.Location = New System.Drawing.Point(326, 374)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(62, 16)
        Me.StatusLabel.TabIndex = 0
        Me.StatusLabel.Text = "StatusLabel"
        '
        'PlayerTurn
        '
        Me.PlayerTurn.Location = New System.Drawing.Point(764, -1)
        Me.PlayerTurn.Name = "PlayerTurn"
        Me.PlayerTurn.Size = New System.Drawing.Size(19, 13)
        Me.PlayerTurn.TabIndex = 1
        Me.PlayerTurn.TabStop = False
        '
        'ChessTimer
        '
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(694, -1)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(73, 13)
        Me.Label.TabIndex = 2
        Me.Label.Text = "Current Player"
        '
        'Player1Name
        '
        Me.Player1Name.AutoSize = True
        Me.Player1Name.Location = New System.Drawing.Point(57, 374)
        Me.Player1Name.Name = "Player1Name"
        Me.Player1Name.Size = New System.Drawing.Size(70, 13)
        Me.Player1Name.TabIndex = 3
        Me.Player1Name.Text = "Player1Name"
        '
        'Player1Score
        '
        Me.Player1Score.AutoSize = True
        Me.Player1Score.Location = New System.Drawing.Point(26, 374)
        Me.Player1Score.Name = "Player1Score"
        Me.Player1Score.Size = New System.Drawing.Size(70, 13)
        Me.Player1Score.TabIndex = 4
        Me.Player1Score.Text = "Player1Score"
        '
        'Player2Name
        '
        Me.Player2Name.AutoSize = True
        Me.Player2Name.Location = New System.Drawing.Point(678, 374)
        Me.Player2Name.Name = "Player2Name"
        Me.Player2Name.Size = New System.Drawing.Size(70, 13)
        Me.Player2Name.TabIndex = 5
        Me.Player2Name.Text = "Player2Name"
        '
        'Player2Score
        '
        Me.Player2Score.AutoSize = True
        Me.Player2Score.Location = New System.Drawing.Point(742, 374)
        Me.Player2Score.Name = "Player2Score"
        Me.Player2Score.Size = New System.Drawing.Size(70, 13)
        Me.Player2Score.TabIndex = 6
        Me.Player2Score.Text = "Player2Score"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.NewChess.My.Resources.Resources.Board
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(784, 761)
        Me.Controls.Add(Me.Player2Score)
        Me.Controls.Add(Me.Player2Name)
        Me.Controls.Add(Me.Player1Score)
        Me.Controls.Add(Me.Player1Name)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.PlayerTurn)
        Me.Controls.Add(Me.StatusLabel)
        Me.DoubleBuffered = True
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PlayerTurn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusLabel As Label
    Friend WithEvents PlayerTurn As PictureBox
    Friend WithEvents ChessTimer As Timer
    Friend WithEvents Label As Label
    Friend WithEvents Player1Name As Label
    Friend WithEvents Player1Score As Label
    Friend WithEvents Player2Name As Label
    Friend WithEvents Player2Score As Label
End Class
