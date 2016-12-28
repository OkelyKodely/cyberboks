''' <summary>
''' This is the main type for your game
''' </summary>
Public Class Game1
    Inherits Microsoft.Xna.Framework.Game

    Public Class UpZapp
        Inherits Shape
    End Class

    Public Class DownZapp
        Inherits Shape
    End Class

    Public Class LeftZapp
        Inherits Shape
    End Class

    Public Class RightZapp
        Inherits Shape
    End Class

    Public Class UpMover
        Inherits Shape
    End Class

    Public Class DownMover
        Inherits Shape
    End Class

    Public Class LeftMover
        Inherits Shape
    End Class

    Public Class RightMover
        Inherits Shape
    End Class

    Public Class Yellow
        Inherits Shape
    End Class

    Public Class Green
        Inherits Shape
    End Class

    Public Class Blue
        Inherits Shape
    End Class

    Public Class Block1
        Inherits Shape
    End Class

    Public Class Block2
        Inherits Shape
    End Class

    Public Class Shape
        Public X As Integer
        Public Y As Integer
        Public vector As New Vector2(0, 0)
    End Class

    Public Class Brick
        Public X As Integer
        Public Y As Integer
        Public vector As New Vector2(0, 0)
    End Class

    Public Class Circle
        Public X As Integer
        Public Y As Integer
        Public prevX As Integer
        Public prevY As Integer
        Public vector As New Vector2(0, 0)
    End Class

    Private cheat As Boolean = True
    Private rooms As String()
    Private graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Private block1s As New List(Of Block1)
    Private block2s As New List(Of Block2)
    Private bricks As New List(Of Brick)
    Private greens As New List(Of Green)
    Private yellows As New List(Of Yellow)
    Private blues As New List(Of Blue)
    Private leftmovers As New List(Of LeftMover)
    Private rightmovers As New List(Of RightMover)
    Private downmovers As New List(Of DownMover)
    Private upmovers As New List(Of UpMover)
    Private upzapps As New List(Of UpZapp)
    Private downzapps As New List(Of DownZapp)
    Private leftzapps As New List(Of LeftZapp)
    Private rightzapps As New List(Of RightZapp)
    Private spriteFont As SpriteFont, spriteFont2 As SpriteFont, spriteFont3 As SpriteFont, cyberFont As SpriteFont
    Private circl As Texture2D, brik As Texture2D, gren As Texture2D, yelow As Texture2D, blu As Texture2D, downMuver As Texture2D, upMuver As Texture2D, rightMuver As Texture2D, leftMuver As Texture2D, blok1 As Texture2D, blok2 As Texture2D
    Private player As Circle
    Private pixel As Texture2D, upzap As Texture2D, downzap As Texture2D, leftzap As Texture2D, rightzap As Texture2D
    Private _currentKeyboardState As KeyboardState
    Private _previousKeyboardState As KeyboardState
    Private rect As Rectangle
    Private currentLevel As Integer = 0
    Private drawwin As Boolean = False
    Private loadlevel As Boolean = True
    Private attempts As Integer = 4

    Public Sub New()
        graphics = New GraphicsDeviceManager(Me)
        Me.Window.Title = "Cyberbox"
        graphics.PreferredBackBufferWidth = 685
        graphics.PreferredBackBufferHeight = 490
        Content.RootDirectory = "Content"
    End Sub

    ''' <summary>
    ''' Allows the game to perform any initialization it needs to before starting to run.
    ''' This is where it can query for any required services and load any non-graphic
    ''' related content.  Calling MyBase.Initialize will enumerate through any components
    ''' and initialize them as well.
    ''' </summary>
    Protected Overrides Sub Initialize()
        ' TODO: Add your initialization logic here
        MyBase.Initialize()
    End Sub

    ''' <summary>
    ''' LoadContent will be called once per game and is the place to load
    ''' all of your content.
    ''' </summary>
    Protected Overrides Sub LoadContent()
        ' Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = New SpriteBatch(GraphicsDevice)

        ' TODO: use Me.Content to load your game content here
        ' Somewhere in your LoadContent() method:
        pixel = New Texture2D(Me.GraphicsDevice, 1, 1, False, SurfaceFormat.Color)
        pixel.SetData(New Color() {Color.White})

        ' Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = New SpriteBatch(GraphicsDevice)

        ' TODO: use this.Content to load your game content here
        circl = Content.Load(Of Texture2D)("circle")
        blok1 = Content.Load(Of Texture2D)("block1")
        blok2 = Content.Load(Of Texture2D)("block2")
        brik = Content.Load(Of Texture2D)("brick")
        gren = Content.Load(Of Texture2D)("green")
        yelow = Content.Load(Of Texture2D)("yellow")
        blu = Content.Load(Of Texture2D)("blue")
        rightMuver = Content.Load(Of Texture2D)("rightmover")
        leftMuver = Content.Load(Of Texture2D)("leftmover")
        downMuver = Content.Load(Of Texture2D)("downmover")
        upMuver = Content.Load(Of Texture2D)("upmover")
        upzap = Content.Load(Of Texture2D)("upzapp")
        downzap = Content.Load(Of Texture2D)("downzapp")
        leftzap = Content.Load(Of Texture2D)("leftzapp")
        rightzap = Content.Load(Of Texture2D)("rightzapp")
        spriteFont = Content.Load(Of SpriteFont)("SpriteFont1")
        cyberFont = Content.Load(Of SpriteFont)("SpriteFont2")
        spriteFont2 = Content.Load(Of SpriteFont)("SpriteFont3")
        spriteFont3 = Content.Load(Of SpriteFont)("SpriteFont4")

        ReDim rooms(17)
        rooms(0) = "The Lobby"
        rooms(1) = "No Problem"
        rooms(2) = "Think Ahead"
        rooms(3) = "Choices, Choices"
        rooms(4) = "You Can Do It"
        rooms(5) = "Chain Reaction"
        rooms(6) = "Your Guess"
        rooms(7) = "Go With The Flow"
        rooms(8) = "Don't Get Zapped!"
        rooms(9) = "Prioritize!"
        rooms(10) = "Fifty Fifty..."
        rooms(11) = "Watch Your Step!"
        rooms(12) = "Move It Or Lose It"
        rooms(13) = "Zapperland"
        rooms(14) = "Logistics..."
        rooms(15) = "Last But Not Least"
        rooms(16) = "...Almost!"
    End Sub

    Public Sub Level1()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()

        player = New Circle()
        player.prevX = 7
        player.prevY = 9
        player.X = 7
        player.Y = 9
        player.vector.X = player.X * CInt(30 * 1.3)
        player.vector.Y = player.Y * CInt(30 * 1.3)

        AddBrick(4, 0)
        AddBrick(10, 0)
        AddBlue(5, 1)
        AddYellow(6, 1)
        AddBlue(7, 1)
        AddYellow(8, 1)
        AddBlue(9, 1)
        AddYellow(0, 2)
        AddGreen(6, 2)
        AddGreen(8, 2)
        AddYellow(14, 2)
        AddYellow(0, 3)
        AddBrick(2, 3)
        AddBrick(5, 3)
        AddYellow(7, 3)
        AddBrick(9, 3)
        AddBrick(12, 3)
        AddYellow(14, 3)
        AddBrick(1, 5)
        AddBrick(3, 5)
        AddBlue(5, 5)
        AddGreen(7, 5)
        AddBlue(9, 5)
        AddBrick(11, 5)
        AddBrick(13, 5)
        AddYellow(0, 7)
        AddBrick(2, 7)
        AddBrick(5, 7)
        AddYellow(7, 7)
        AddBrick(9, 7)
        AddBrick(12, 7)
        AddYellow(14, 7)
        AddBlue(4, 9)
        AddBlue(5, 9)
        AddBlue(9, 9)
        AddBlue(10, 9)
    End Sub

    Public Sub Level2()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()

        AddBrick(4, 0)
        AddBrick(9, 0)
        AddBrick(10, 0)
        AddBrick(4, 1)
        AddBrick(5, 1)
        AddBrick(10, 1)
        AddBlue(2, 2)
        AddBlue(3, 2)
        AddBlue(4, 2)
        AddBlue(5, 2)
        AddBlue(6, 2)
        AddYellow(7, 2)
        AddBlue(8, 2)
        AddBlue(9, 2)
        AddBlue(10, 2)
        AddBrick(13, 2)
        AddYellow(14, 2)
        AddBrick(2, 3)
        AddGreen(7, 3)
        AddYellow(8, 3)
        AddBrick(11, 3)
        AddBrick(12, 3)
        AddBrick(13, 3)
        AddYellow(14, 3)
        AddYellow(0, 4)
        AddBlue(2, 4)
        AddGreen(8, 4)
        AddYellow(14, 4)
        AddYellow(0, 5)
        AddGreen(1, 5)
        AddBrick(3, 5)
        AddBrick(4, 5)
        AddBrick(11, 5)
        AddYellow(0, 6)
        AddBrick(1, 6)
        AddBrick(2, 6)
        AddBrick(5, 6)
        AddBrick(6, 6)
        AddBrick(7, 6)
        AddBrick(8, 6)
        AddBrick(13, 6)
        AddYellow(0, 7)
        AddYellow(3, 7)
        AddBrick(6, 7)
        AddBrick(7, 7)
        AddBrick(8, 7)
        AddBrick(11, 7)
        AddBlue(13, 7)
        AddYellow(0, 8)
        AddBrick(2, 8)
        AddGreen(4, 8)
        AddYellow(5, 8)
        AddBrick(8, 8)
        AddBlue(11, 8)
        AddYellow(12, 8)
        AddBrick(13, 8)
        AddBrick(2, 9)
        AddBrick(4, 9)
        AddBlue(8, 9)
        AddBrick(11, 9)
        AddBlue(13, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level3()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()

        AddBrick(0, 0)
        AddBrick(3, 0)
        AddBrick(6, 0)
        AddBrick(11, 0)
        AddYellow(2, 1)
        AddBrick(3, 1)
        AddBrick(5, 1)
        AddYellow(9, 1)
        AddYellow(10, 1)
        AddBrick(13, 1)
        AddYellow(1, 2)
        AddGreen(2, 2)
        AddBrick(3, 2)
        AddBrick(4, 2)
        AddBrick(5, 2)
        AddBrick(6, 2)
        AddBrick(7, 2)
        AddBrick(8, 2)
        AddGreen(9, 2)
        AddGreen(10, 2)
        AddBrick(11, 2)
        AddBrick(12, 2)
        AddYellow(2, 3)
        AddBlue(5, 3)
        AddYellow(9, 3)
        AddBrick(13, 3)
        AddBrick(1, 4)
        AddBrick(7, 4)
        AddBrick(8, 4)
        AddGreen(9, 4)
        AddBrick(10, 4)
        AddBrick(12, 4)
        AddBrick(2, 5)
        AddBrick(3, 5)
        AddBrick(4, 5)
        AddBrick(5, 5)
        AddBrick(8, 5)
        AddYellow(9, 5)
        AddBlue(12, 5)
        AddBlue(13, 5)
        AddBrick(1, 6)
        AddBrick(6, 6)
        AddBrick(8, 6)
        AddYellow(9, 6)
        AddBrick(10, 6)
        AddBlue(12, 6)
        AddBlue(13, 6)
        AddBrick(2, 7)
        AddGreen(3, 7)
        AddGreen(4, 7)
        AddBrick(6, 7)
        AddRM(10, 7)
        AddYellow(11, 7)
        AddBrick(12, 7)
        AddYellow(3, 8)
        AddYellow(4, 8)
        AddBrick(7, 8)
        AddBrick(10, 8)
        AddGreen(12, 8)
        AddBrick(2, 9)
        AddBrick(5, 9)
        AddBrick(8, 9)
        AddBrick(10, 9)
        AddGreen(12, 9)
        AddBrick(14, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level4()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()

        AddGreen(6, 0)
        AddBlue(7, 0)
        AddGreen(8, 0)
        AddGreen(9, 0)
        AddGreen(10, 0)
        AddGreen(11, 0)
        AddGreen(12, 0)
        AddDM(13, 0)
        AddBrick(4, 1)
        AddBrick(9, 1)
        AddBrick(11, 1)
        AddBlue(13, 1)
        AddYellow(14, 1)
        AddBrick(2, 2)
        AddBrick(3, 2)
        AddBrick(5, 2)
        AddBrick(6, 2)
        AddBrick(7, 2)
        AddBlue(11, 2)
        AddBrick(1, 3)
        AddBrick(8, 3)
        AddBrick(9, 3)
        AddBrick(10, 3)
        AddBrick(11, 3)
        AddBrick(13, 3)
        AddYellow(14, 3)
        AddBrick(1, 4)
        AddBlue(3, 4)
        AddBrick(5, 4)
        AddBrick(6, 4)
        AddBlue(8, 4)
        AddBrick(13, 4)
        AddBrick(1, 5)
        AddBrick(3, 5)
        AddYellow(4, 5)
        AddBrick(7, 5)
        AddBlue(9, 5)
        AddBrick(12, 5)
        AddYellow(0, 6)
        AddBrick(1, 6)
        AddBrick(3, 6)
        AddYellow(4, 6)
        AddBrick(5, 6)
        AddBrick(8, 6)
        AddBrick(9, 6)
        AddBrick(10, 6)
        AddBrick(11, 6)
        AddGreen(13, 6)
        AddYellow(0, 7)
        AddLM(1, 7)
        AddYellow(2, 7)
        AddLM(3, 7)
        AddYellow(4, 7)
        AddLM(5, 7)
        AddBlue(7, 7)
        AddBlue(8, 7)
        AddBlue(9, 7)
        AddBlue(10, 7)
        AddBrick(1, 8)
        AddBrick(3, 8)
        AddBrick(5, 8)
        AddBrick(6, 8)
        AddBrick(7, 8)
        AddBrick(8, 8)
        AddBrick(8, 9)
        AddBlue(10, 9)
        AddBlue(11, 9)
        AddBlue(12, 9)
        AddBlue(13, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level5()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()

        AddBrick(6, 0)
        AddBlue(12, 0)
        AddBlue(13, 0)
        AddBrick(1, 1)
        AddBrick(7, 1)
        AddYellow(9, 1)
        AddBlue(11, 1)
        AddBrick(13, 1)
        AddBrick(0, 2)
        AddBrick(2, 2)
        AddYellow(4, 2)
        AddYellow(6, 2)
        AddBrick(8, 2)
        AddBrick(12, 2)
        AddBrick(0, 3)
        AddBrick(2, 3)
        AddBrick(3, 3)
        AddYellow(4, 3)
        AddBrick(5, 3)
        AddYellow(7, 3)
        AddBrick(9, 3)
        AddBrick(10, 3)
        AddBrick(11, 3)
        AddYellow(14, 3)
        AddBrick(0, 4)
        AddBrick(2, 4)
        AddDM(3, 4)
        AddDM(4, 4)
        AddBrick(5, 4)
        AddYellow(8, 4)
        AddBrick(11, 4)
        AddYellow(1, 5)
        AddBlue(2, 5)
        AddBlue(3, 5)
        AddBlue(4, 5)
        AddGreen(5, 5)
        AddBrick(9, 5)
        AddBrick(11, 5)
        AddYellow(1, 6)
        AddBrick(2, 6)
        AddBrick(5, 6)
        AddBrick(6, 6)
        AddBrick(7, 6)
        AddBrick(9, 6)
        AddBrick(11, 6)
        AddBrick(13, 6)
        AddBrick(14, 6)
        AddGreen(1, 7)
        AddBrick(2, 7)
        AddBrick(6, 7)
        AddBrick(7, 7)
        AddBrick(8, 7)
        AddBrick(9, 7)
        AddBlue(11, 7)
        AddBlue(12, 7)
        AddGreen(13, 7)
        AddBrick(0, 8)
        AddYellow(1, 8)
        AddBrick(2, 8)
        AddBrick(3, 8)
        AddBrick(4, 8)
        AddBrick(5, 8)
        AddBrick(6, 8)
        AddBrick(7, 8)
        AddBrick(8, 8)
        AddBrick(9, 8)
        AddGreen(11, 8)
        AddBlue(12, 8)
        AddBlue(13, 8)
        AddBrick(8, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level6()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()

        AddBrick(3, 0)
        AddDM(6, 0)
        AddBlue(3, 1)
        AddBlue(4, 1)
        AddBlue(5, 1)
        AddDM(6, 1)
        AddBlue(7, 1)
        AddBlue(8, 1)
        AddBlue(9, 1)
        AddBlue(10, 1)
        AddBlue(11, 1)
        AddBlue(12, 1)
        AddYellow(13, 1)
        AddLM(14, 1)
        AddBlue(6, 2)
        AddBrick(12, 2)
        AddGreen(13, 2)
        AddYellow(13, 3)
        AddBrick(6, 4)
        AddYellow(13, 4)
        AddRM(0, 5)
        AddBlue(1, 5)
        AddBlue(2, 5)
        AddBlue(3, 5)
        AddYellow(4, 5)
        AddBrick(5, 5)
        AddBrick(6, 5)
        AddBrick(7, 5)
        AddBrick(8, 5)
        AddBrick(9, 5)
        AddBrick(10, 5)
        AddBrick(11, 5)
        AddBrick(12, 5)
        AddYellow(13, 5)
        AddBrick(14, 5)
        AddBrick(0, 6)
        AddBrick(1, 6)
        AddBrick(2, 6)
        AddBrick(3, 6)
        AddBrick(5, 6)
        AddBrick(7, 6)
        AddBrick(11, 6)
        AddBrick(12, 6)
        AddYellow(13, 6)
        AddBlue(5, 7)
        AddBrick(12, 7)
        AddYellow(13, 7)
        AddBrick(5, 8)
        AddBrick(6, 8)
        AddBrick(7, 8)
        AddBrick(8, 8)
        AddBrick(9, 8)
        AddBrick(10, 8)
        AddYellow(11, 8)
        AddGreen(12, 8)
        AddBlue(13, 8)
        AddBrick(8, 9)
        AddUM(13, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level7()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()

        AddBlue(0, 0)
        AddBlue(1, 0)
        AddDM(2, 0)
        AddBlue(3, 0)
        AddBlue(4, 0)
        AddBlue(5, 0)
        AddBlue(6, 0)
        AddBrick(9, 0)
        AddBlue(2, 1)
        AddBrick(6, 1)
        AddGreen(7, 1)
        AddBrick(9, 1)
        AddGreen(4, 2)
        AddRM(5, 2)
        AddRM(6, 2)
        AddYellow(7, 2)
        AddBrick(9, 2)
        AddBrick(12, 2)
        AddBrick(13, 2)
        AddBrick(0, 3)
        AddBrick(1, 3)
        AddGreen(4, 3)
        AddBlue(5, 3)
        AddBrick(8, 3)
        AddBrick(11, 3)
        AddBrick(14, 3)
        AddRM(1, 4)
        AddYellow(2, 4)
        AddGreen(4, 4)
        AddBlue(7, 4)
        AddBrick(14, 4)
        AddGreen(4, 5)
        AddUM(7, 5)
        AddBrick(13, 5)
        AddGreen(4, 6)
        AddBrick(12, 6)
        AddBrick(0, 7)
        AddBrick(1, 7)
        AddBlue(3, 7)
        AddBlue(4, 7)
        AddGreen(5, 7)
        AddBlue(6, 7)
        AddBlue(7, 7)
        AddBlue(8, 7)
        AddBlue(9, 7)
        AddBlue(10, 7)
        AddBrick(12, 7)
        AddBrick(12, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level8()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()
        upzapps.Clear()
        downzapps.Clear()
        leftzapps.Clear()
        rightzapps.Clear()

        AddBrick(6, 0)
        AddBrick(8, 0)
        AddBrick(1, 1)
        AddBrick(2, 1)
        AddBrick(5, 1)
        AddUZ(7, 1)
        AddBrick(9, 1)
        AddBrick(12, 1)
        AddBrick(13, 1)
        AddBrick(0, 2)
        AddBrick(3, 2)
        AddYellow(6, 2)
        AddBlue(7, 2)
        AddYellow(8, 2)
        AddBrick(12, 2)
        AddBrick(13, 2)
        AddDZ(2, 3)
        AddGreen(6, 3)
        AddBrick(7, 3)
        AddGreen(8, 3)
        AddBrick(12, 3)
        AddBrick(13, 3)
        AddBrick(1, 4)
        AddBrick(3, 4)
        AddYellow(6, 4)
        AddBrick(7, 4)
        AddYellow(8, 4)
        AddBrick(12, 4)
        AddBrick(13, 4)
        AddUZ(0, 5)
        AddRM(1, 5)
        AddYellow(2, 5)
        AddBlue(6, 5)
        AddBlue(7, 5)
        AddBlue(8, 5)
        AddBlue(9, 5)
        AddBrick(1, 6)
        AddBrick(3, 6)
        AddBrick(4, 6)
        AddBrick(5, 6)
        AddUM(6, 6)
        AddBrick(7, 6)
        AddUM(8, 6)
        AddUM(9, 6)
        AddBrick(12, 6)
        AddBrick(13, 6)
        AddBrick(1, 7)
        AddBrick(3, 7)
        AddLZ(5, 7)
        AddBrick(8, 7)
        AddBrick(12, 7)
        AddBrick(13, 7)
        AddBrick(1, 8)
        AddBrick(2, 8)
        AddBrick(3, 8)
        AddLZ(5, 8)
        AddBrick(8, 8)
        AddLZ(5, 9)
        AddBrick(8, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level9()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()
        upzapps.Clear()
        downzapps.Clear()
        leftzapps.Clear()
        rightzapps.Clear()

        AddBrick(5, 0)
        AddDM(6, 0)
        AddDM(7, 0)
        AddDM(8, 0)
        AddBlue(11, 0)
        AddDM(12, 0)
        AddYellow(0, 1)
        AddBlue(1, 1)
        AddBlue(2, 1)
        AddBlue(3, 1)
        AddBlue(4, 1)
        AddGreen(5, 1)
        AddBlue(6, 1)
        AddBlue(7, 1)
        AddGreen(8, 1)
        AddBlue(12, 1)
        AddBrick(1, 2)
        AddBrick(2, 2)
        AddDZ(3, 2)
        AddRZ(6, 2)
        AddLZ(8, 2)
        AddBrick(11, 2)
        AddUZ(0, 3)
        AddBrick(2, 3)
        AddBrick(5, 3)
        AddBrick(6, 3)
        AddBrick(8, 3)
        AddBrick(9, 3)
        AddBrick(10, 3)
        AddBrick(2, 4)
        AddBrick(3, 4)
        AddBrick(4, 4)
        AddLZ(6, 4)
        AddRZ(8, 4)
        AddBrick(10, 4)
        AddBrick(1, 5)
        AddLZ(3, 5)
        AddBrick(6, 5)
        AddBrick(8, 5)
        AddBrick(10, 5)
        AddBrick(11, 5)
        AddUZ(12, 5)
        AddBrick(13, 5)
        AddBrick(14, 5)
        AddUZ(0, 6)
        AddUZ(2, 6)
        AddDZ(4, 6)
        AddBrick(6, 6)
        AddBrick(8, 6)
        AddBlue(11, 6)
        AddBlue(12, 6)
        AddBlue(13, 6)
        AddLZ(1, 7)
        AddRZ(3, 7)
        AddDZ(5, 7)
        AddBrick(6, 7)
        AddUZ(7, 7)
        AddBrick(8, 7)
        AddDM(13, 7)
        AddRZ(0, 8)
        AddUZ(2, 8)
        AddDZ(4, 8)
        AddBrick(6, 8)
        AddBrick(8, 8)
        AddBlue(11, 8)
        AddGreen(12, 8)
        AddBlue(13, 8)
        AddLZ(1, 9)
        AddLZ(3, 9)
        AddBrick(5, 9)
        AddBrick(6, 9)
        AddBrick(8, 9)
        AddBrick(14, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level10()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()
        upzapps.Clear()
        downzapps.Clear()
        leftzapps.Clear()
        rightzapps.Clear()

        AddBrick(1, 0)
        AddBrick(6, 0)
        AddBrick(8, 0)
        AddBrick(10, 0)
        AddRM(1, 1)
        AddYellow(2, 1)
        AddBlue(7, 1)
        AddBrick(11, 1)
        AddBrick(12, 1)
        AddBrick(13, 1)
        AddBrick(14, 1)
        AddGreen(2, 2)
        AddBrick(3, 2)
        AddBrick(6, 2)
        AddBrick(8, 2)
        AddBrick(9, 2)
        AddBrick(10, 2)
        AddYellow(2, 3)
        AddBrick(5, 3)
        AddBlue(7, 3)
        AddYellow(2, 4)
        AddBrick(5, 4)
        AddRM(6, 4)
        AddYellow(7, 4)
        AddBrick(8, 4)
        AddBrick(12, 4)
        AddBrick(13, 4)
        AddBrick(1, 5)
        AddYellow(2, 5)
        AddBrick(5, 5)
        AddBrick(6, 5)
        AddBrick(8, 5)
        AddBrick(9, 5)
        AddBrick(10, 5)
        AddBrick(11, 5)
        AddUZ(0, 6)
        AddBlue(2, 6)
        AddGreen(3, 6)
        AddBlue(4, 6)
        AddBlue(5, 6)
        AddBlue(6, 6)
        AddBrick(8, 6)
        AddRM(9, 6)
        AddRM(10, 6)
        AddRM(11, 6)
        AddGreen(12, 6)
        AddGreen(13, 6)
        AddGreen(14, 6)
        AddBrick(1, 7)
        AddYellow(2, 7)
        AddBrick(5, 7)
        AddBrick(6, 7)
        AddUZ(7, 7)
        AddBrick(8, 7)
        AddBrick(9, 7)
        AddBrick(3, 8)
        AddBrick(4, 8)
        AddBrick(12, 9)
        AddBrick(13, 9)
        AddBrick(14, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level11()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()
        upzapps.Clear()
        downzapps.Clear()
        leftzapps.Clear()
        rightzapps.Clear()

        AddBrick(4, 0)
        AddBrick(5, 0)
        AddBrick(6, 0)
        AddDM(7, 0)
        AddBrick(8, 0)
        AddBrick(9, 0)
        AddBrick(10, 0)
        AddBrick(11, 0)
        AddBrick(3, 1)
        AddBlue(6, 1)
        AddBlue(7, 1)
        AddBlue(8, 1)
        AddGreen(9, 1)
        AddBlue(10, 1)
        AddBrick(12, 1)
        AddBrick(2, 2)
        AddGreen(4, 2)
        AddBlue(5, 2)
        AddBlue(6, 2)
        AddBlue(7, 2)
        AddBlue(8, 2)
        AddBrick(13, 2)
        AddBrick(2, 3)
        AddBlue(5, 3)
        AddBlue(6, 3)
        AddBlue(7, 3)
        AddGreen(8, 3)
        AddBlue(9, 3)
        AddBlue(10, 3)
        AddBrick(13, 3)
        AddBrick(2, 4)
        AddBlue(4, 4)
        AddGreen(5, 4)
        AddBlue(6, 4)
        AddBlue(7, 4)
        AddGreen(8, 4)
        AddBlue(9, 4)
        AddBlue(10, 4)
        AddBrick(13, 4)
        AddBrick(2, 5)
        AddBlue(5, 5)
        AddBlue(6, 5)
        AddBlue(7, 5)
        AddGreen(8, 5)
        AddBlue(9, 5)
        AddBlue(10, 5)
        AddBrick(13, 5)
        AddBrick(3, 6)
        AddBlue(7, 6)
        AddBrick(12, 6)
        AddBrick(6, 7)
        AddBrick(8, 7)
        AddBrick(5, 8)
        AddDM(6, 8)
        AddBrick(7, 8)
        AddDM(8, 8)
        AddBrick(9, 8)
        AddBlue(5, 9)
        AddBlue(6, 9)
        AddBlue(8, 9)
        AddBlue(9, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level12()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()
        upzapps.Clear()
        downzapps.Clear()
        leftzapps.Clear()
        rightzapps.Clear()

        AddBrick(2, 0)
        AddDM(3, 0)
        AddBlock1(5, 0)
        AddBlue(6, 0)
        AddBlue(7, 0)
        AddDM(10, 0)
        AddBlue(3, 1)
        AddBrick(7, 1)
        AddYellow(10, 1)
        AddBrick(0, 2)
        AddUZ(1, 2)
        AddBrick(2, 2)
        AddYellow(3, 2)
        AddBrick(8, 2)
        AddBrick(9, 2)
        AddGreen(10, 2)
        AddBrick(11, 2)
        AddYellow(3, 3)
        AddBlue(4, 3)
        AddBlue(5, 3)
        AddBlue(6, 3)
        AddBlue(7, 3)
        AddBlue(8, 3)
        AddBlue(9, 3)
        AddLM(10, 3)
        AddBrick(12, 3)
        AddLZ(2, 4)
        AddGreen(5, 4)
        AddBrick(7, 4)
        AddDZ(8, 4)
        AddBrick(9, 4)
        AddBrick(10, 4)
        AddBrick(11, 4)
        AddLZ(2, 5)
        AddGreen(5, 5)
        AddGreen(8, 5)
        AddBlue(11, 5)
        AddBlue(12, 5)
        AddLZ(2, 6)
        AddGreen(5, 6)
        AddGreen(8, 6)
        AddBrick(10, 6)
        AddBrick(11, 6)
        AddUM(12, 6)
        AddUZ(13, 6)
        AddUZ(14, 6)
        AddBrick(3, 7)
        AddBrick(4, 7)
        AddBrick(6, 7)
        AddBrick(7, 7)
        AddBrick(8, 7)
        AddBrick(10, 7)
        AddBlock1(5, 8)
        AddBlue(7, 8)
        AddBlock1(9, 8)
        AddBlock1(5, 9)
        AddBlock1(9, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level13()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()
        upzapps.Clear()
        downzapps.Clear()
        leftzapps.Clear()
        rightzapps.Clear()
        block1s.Clear()

        AddBlock1(6, 0)
        AddBlock1(7, 0)
        AddBlock1(8, 0)
        AddBrick(8, 1)
        AddBrick(9, 1)
        AddBrick(10, 1)
        AddBrick(11, 1)
        AddBrick(5, 2)
        AddBrick(6, 2)
        AddBrick(7, 2)
        AddLZ(11, 2)
        AddBrick(0, 3)
        AddBrick(1, 3)
        AddBrick(2, 3)
        AddBrick(3, 3)
        AddBrick(4, 3)
        AddBrick(10, 3)
        AddBrick(11, 3)
        AddBrick(6, 4)
        AddBrick(7, 4)
        AddBrick(8, 4)
        AddBrick(9, 4)
        AddBrick(12, 4)
        AddBrick(14, 4)
        AddBrick(2, 5)
        AddBlue(7, 5)
        AddLZ(12, 5)
        AddBrick(0, 6)
        AddBrick(2, 6)
        AddBrick(3, 6)
        AddBrick(4, 6)
        AddBrick(5, 6)
        AddBrick(6, 6)
        AddBrick(7, 6)
        AddBrick(9, 6)
        AddBrick(11, 6)
        AddGreen(5, 7)
        AddLZ(7, 7)
        AddBrick(9, 7)
        AddBrick(11, 7)
        AddBrick(6, 8)
        AddBrick(7, 8)
        AddBlue(13, 8)
        AddBrick(8, 9)
        AddBrick(11, 9)
        AddBrick(12, 9)
        AddUM(13, 9)
        AddBrick(14, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level14()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()
        upzapps.Clear()
        downzapps.Clear()
        leftzapps.Clear()
        rightzapps.Clear()
        block1s.Clear()

        AddRZ(2, 0)
        AddRZ(4, 0)
        AddRZ(6, 0)
        AddRZ(8, 0)
        AddLZ(10, 0)
        AddLZ(12, 0)
        AddRZ(1, 1)
        AddRZ(3, 1)
        AddLZ(5, 1)
        AddLZ(7, 1)
        AddLZ(9, 1)
        AddRZ(11, 1)
        AddLZ(13, 1)
        AddUZ(0, 2)
        AddDZ(2, 2)
        AddUZ(4, 2)
        AddUZ(6, 2)
        AddDZ(8, 2)
        AddUZ(10, 2)
        AddDZ(12, 2)
        AddUZ(14, 2)
        AddLZ(1, 3)
        AddLZ(3, 3)
        AddRZ(5, 3)
        AddLZ(7, 3)
        AddDZ(9, 3)
        AddLZ(11, 3)
        AddLZ(13, 3)
        AddDZ(0, 4)
        AddDZ(2, 4)
        AddUZ(4, 4)
        AddUZ(6, 4)
        AddDZ(8, 4)
        AddLZ(10, 4)
        AddRZ(12, 4)
        AddUZ(14, 4)
        AddRZ(1, 5)
        AddLZ(3, 5)
        AddLZ(5, 5)
        AddLZ(7, 5)
        AddRZ(9, 5)
        AddUZ(11, 5)
        AddRZ(13, 5)
        AddUZ(0, 6)
        AddDZ(2, 6)
        AddDZ(4, 6)
        AddDZ(6, 6)
        AddDZ(8, 6)
        AddUZ(10, 6)
        AddUZ(12, 6)
        AddDZ(14, 6)
        AddLZ(1, 7)
        AddRZ(3, 7)
        AddRZ(5, 7)
        AddLZ(7, 7)
        AddRZ(9, 7)
        AddRZ(11, 7)
        AddRZ(13, 7)
        AddDZ(0, 8)
        AddUZ(2, 8)
        AddUZ(4, 8)
        AddUZ(6, 8)
        AddUZ(8, 8)
        AddUZ(10, 8)
        AddDZ(12, 8)
        AddUZ(14, 8)
        AddRZ(1, 9)
        AddLZ(3, 9)
        AddLZ(5, 9)
        AddRZ(9, 9)
        AddRZ(11, 9)
        AddRZ(13, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level15()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()
        upzapps.Clear()
        downzapps.Clear()
        leftzapps.Clear()
        rightzapps.Clear()
        block1s.Clear()
        block2s.Clear()

        AddGreen(1, 0)
        AddBlue(5, 0)
        AddBlue(6, 0)
        AddDM(7, 0)
        AddBlue(8, 0)
        AddBlue(9, 0)
        AddDM(10, 0)
        AddBlue(11, 0)
        AddBlue(12, 0)
        AddDM(13, 0)
        AddBlue(14, 0)
        AddGreen(1, 1)
        AddBrick(4, 1)
        AddBrick(5, 1)
        AddBrick(6, 1)
        AddYellow(7, 1)
        AddBrick(8, 1)
        AddBlock1(10, 1)
        AddBlock1(13, 1)
        AddBrick(1, 2)
        AddBrick(2, 2)
        AddBrick(3, 2)
        AddBrick(6, 2)
        AddYellow(7, 2)
        AddBrick(8, 2)
        AddBlock2(10, 2)
        AddBlock2(13, 2)
        AddUZ(0, 3)
        AddBrick(3, 3)
        AddBrick(4, 3)
        AddBrick(5, 3)
        AddYellow(7, 3)
        AddBrick(8, 3)
        AddBlock2(10, 3)
        AddBlock2(13, 3)
        AddYellow(1, 4)
        AddYellow(2, 4)
        AddBrick(4, 4)
        AddBlock1(7, 4)
        AddBrick(8, 4)
        AddBrick(9, 4)
        AddBrick(10, 4)
        AddGreen(11, 4)
        AddBrick(13, 4)
        AddBrick(0, 5)
        AddBlock2(1, 5)
        AddBlock2(2, 5)
        AddUZ(3, 5)
        AddBrick(4, 5)
        AddBlock2(7, 5)
        AddBrick(10, 5)
        AddBrick(12, 5)
        AddBrick(13, 5)
        AddBrick(14, 5)
        AddYellow(1, 6)
        AddYellow(2, 6)
        AddBrick(4, 6)
        AddBlock2(7, 6)
        AddBrick(10, 6)
        AddBrick(12, 6)
        AddBrick(0, 7)
        AddBrick(1, 7)
        AddBrick(3, 7)
        AddBrick(4, 7)
        AddBrick(5, 7)
        AddBrick(7, 7)
        AddBrick(9, 7)
        AddBrick(10, 7)
        AddBrick(4, 9)
        AddBrick(10, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level16()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()
        upzapps.Clear()
        downzapps.Clear()
        leftzapps.Clear()
        rightzapps.Clear()
        block1s.Clear()
        block2s.Clear()

        AddBrick(6, 0)
        AddLZ(8, 0)
        AddBrick(0, 1)
        AddBrick(1, 1)
        AddBrick(5, 1)
        AddBrick(7, 1)
        AddBrick(9, 1)
        AddBrick(10, 1)
        AddBrick(11, 1)
        AddBrick(12, 1)
        AddYellow(2, 2)
        AddBlock2(3, 2)
        AddYellow(4, 2)
        AddBrick(7, 2)
        AddBrick(9, 2)
        AddBrick(12, 2)
        AddBrick(14, 2)
        AddUZ(0, 3)
        AddBlock1(2, 3)
        AddBrick(3, 3)
        AddBlock1(4, 3)
        AddBrick(5, 3)
        AddYellow(8, 3)
        AddBlue(11, 3)
        AddBlock2(12, 3)
        AddBlue(13, 3)
        AddLZ(1, 4)
        AddBlock2(2, 4)
        AddBlock2(4, 4)
        AddBrick(6, 4)
        AddBlock1(8, 4)
        AddBrick(9, 4)
        AddBrick(10, 4)
        AddBrick(11, 4)
        AddBrick(12, 4)
        AddBrick(14, 4)
        AddBrick(0, 5)
        AddBrick(6, 5)
        AddBlock2(8, 5)
        AddBlue(11, 5)
        AddBlock2(12, 5)
        AddBlue(13, 5)
        AddBrick(6, 6)
        AddDZ(7, 6)
        AddBlock1(8, 6)
        AddBrick(9, 6)
        AddBrick(10, 6)
        AddBrick(11, 6)
        AddBrick(12, 6)
        AddBrick(14, 6)
        AddBrick(6, 7)
        AddYellow(8, 7)
        AddRZ(9, 7)
        AddBlue(11, 7)
        AddBlock2(12, 7)
        AddBlue(13, 7)
        AddBlue(1, 8)
        AddBlue(2, 8)
        AddGreen(3, 8)
        AddBlue(4, 8)
        AddLZ(6, 8)
        AddBrick(9, 8)
        AddBrick(10, 8)
        AddDZ(11, 8)
        AddBrick(12, 8)
        AddBrick(14, 8)
        AddUM(2, 9)
        AddUM(4, 9)
        AddBrick(6, 9)
        AddBrick(8, 9)
        AddBrick(9, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Public Sub Level17()
        bricks.Clear()
        greens.Clear()
        yellows.Clear()
        blues.Clear()
        leftmovers.Clear()
        downmovers.Clear()
        rightmovers.Clear()
        upmovers.Clear()
        upzapps.Clear()
        downzapps.Clear()
        leftzapps.Clear()
        rightzapps.Clear()
        block1s.Clear()
        block2s.Clear()

        AddYellow(2, 0)
        AddYellow(4, 0)
        AddDM(7, 0)
        AddBrick(10, 0)
        AddBrick(13, 0)
        AddYellow(2, 1)
        AddYellow(4, 1)
        AddYellow(6, 1)
        AddGreen(7, 1)
        AddYellow(8, 1)
        AddBrick(10, 1)
        AddBrick(13, 1)
        AddYellow(3, 2)
        AddYellow(6, 2)
        AddGreen(7, 2)
        AddYellow(8, 2)
        AddBrick(10, 2)
        AddBrick(13, 2)
        AddYellow(3, 3)
        AddYellow(6, 3)
        AddGreen(7, 3)
        AddYellow(8, 3)
        AddBrick(10, 3)
        AddBrick(13, 3)
        AddYellow(3, 4)
        AddUM(7, 4)
        AddBrick(11, 4)
        AddBrick(12, 4)
        AddBlue(1, 6)
        AddBlue(5, 6)
        AddYellow(7, 6)
        AddYellow(9, 6)
        AddYellow(12, 6)
        AddBlue(1, 7)
        AddBlue(3, 7)
        AddBlue(5, 7)
        AddYellow(7, 7)
        AddYellow(9, 7)
        AddGreen(10, 7)
        AddYellow(12, 7)
        AddBlue(2, 8)
        AddBlue(3, 8)
        AddBlue(4, 8)
        AddYellow(7, 8)
        AddYellow(9, 8)
        AddGreen(11, 8)
        AddYellow(12, 8)
        AddBlue(2, 9)
        AddBlue(4, 9)
        AddYellow(9, 9)
        AddYellow(12, 9)

        player.prevX = player.X
        player.prevY = player.Y
        player.Y = 9
        player.vector.Y = player.Y * CInt(30 * 1.3)
    End Sub

    Private Sub AddBlock1(x As Integer, y As Integer)
        Dim b1 = New Block1()
        b1.X = x
        b1.Y = y
        b1.vector.X = b1.X * CInt(30 * 1.3)
        b1.vector.Y = b1.Y * CInt(30 * 1.3)
        block1s.Add(b1)
    End Sub

    Private Sub AddBlock2(x As Integer, y As Integer)
        Dim b2 = New Block2()
        b2.X = x
        b2.Y = y
        b2.vector.X = b2.X * CInt(30 * 1.3)
        b2.vector.Y = b2.Y * CInt(30 * 1.3)
        block2s.Add(b2)
    End Sub

    Private Sub AddUZ(x As Integer, y As Integer)
        Dim uz = New UpZapp()
        uz.X = x
        uz.Y = y
        uz.vector.X = uz.X * CInt(30 * 1.3)
        uz.vector.Y = uz.Y * CInt(30 * 1.3)
        upzapps.Add(uz)
    End Sub

    Private Sub AddDZ(x As Integer, y As Integer)
        Dim dz = New DownZapp()
        dz.X = x
        dz.Y = y
        dz.vector.X = dz.X * CInt(30 * 1.3)
        dz.vector.Y = dz.Y * CInt(30 * 1.3)
        downzapps.Add(dz)
    End Sub

    Private Sub AddLZ(x As Integer, y As Integer)
        Dim lz = New LeftZapp()
        lz.X = x
        lz.Y = y
        lz.vector.X = lz.X * CInt(30 * 1.3)
        lz.vector.Y = lz.Y * CInt(30 * 1.3)
        leftzapps.Add(lz)
    End Sub

    Private Sub AddRZ(x As Integer, y As Integer)
        Dim rz = New RightZapp()
        rz.X = x
        rz.Y = y
        rz.vector.X = rz.X * CInt(30 * 1.3)
        rz.vector.Y = rz.Y * CInt(30 * 1.3)
        rightzapps.Add(rz)
    End Sub

    Private Sub AddLM(x As Integer, y As Integer)
        Dim lm = New LeftMover()
        lm.X = x
        lm.Y = y
        lm.vector.X = lm.X * CInt(30 * 1.3)
        lm.vector.Y = lm.Y * CInt(30 * 1.3)
        leftmovers.Add(lm)
    End Sub

    Private Sub AddRM(x As Integer, y As Integer)
        Dim rm = New RightMover()
        rm.X = x
        rm.Y = y
        rm.vector.X = rm.X * CInt(30 * 1.3)
        rm.vector.Y = rm.Y * CInt(30 * 1.3)
        rightmovers.Add(rm)
    End Sub

    Private Sub AddDM(x As Integer, y As Integer)
        Dim dm = New DownMover()
        dm.X = x
        dm.Y = y
        dm.vector.X = dm.X * CInt(30 * 1.3)
        dm.vector.Y = dm.Y * CInt(30 * 1.3)
        downmovers.Add(dm)
    End Sub

    Private Sub AddUM(x As Integer, y As Integer)
        Dim um = New UpMover()
        um.X = x
        um.Y = y
        um.vector.X = um.X * CInt(30 * 1.3)
        um.vector.Y = um.Y * CInt(30 * 1.3)
        upmovers.Add(um)
    End Sub

    Private Sub AddBrick(x As Integer, y As Integer)
        Dim brick = New Brick()
        brick.X = x
        brick.Y = y
        brick.vector.X = brick.X * CInt(30 * 1.3)
        brick.vector.Y = brick.Y * CInt(30 * 1.3)
        bricks.Add(brick)
    End Sub

    Private Sub AddGreen(x As Integer, y As Integer)
        Dim green = New Green()
        green.X = x
        green.Y = y
        green.vector.X = green.X * CInt(30 * 1.3)
        green.vector.Y = green.Y * CInt(30 * 1.3)
        greens.Add(green)
    End Sub

    Private Sub AddYellow(x As Integer, y As Integer)
        Dim yellow = New Yellow()
        yellow.X = x
        yellow.Y = y
        yellow.vector.X = yellow.X * CInt(30 * 1.3)
        yellow.vector.Y = yellow.Y * CInt(30 * 1.3)
        yellows.Add(yellow)
    End Sub

    Private Sub AddBlue(x As Integer, y As Integer)
        Dim blue = New Blue()
        blue.X = x
        blue.Y = y
        blue.vector.X = blue.X * CInt(30 * 1.3)
        blue.vector.Y = blue.Y * CInt(30 * 1.3)
        blues.Add(blue)
    End Sub

    ''' <summary>
    ''' UnloadContent will be called once per game and is the place to unload
    ''' all content.
    ''' </summary>
    Protected Overrides Sub UnloadContent()
        ' TODO: Unload any non ContentManager content here
    End Sub

    ''' <summary>
    ''' Allows the game to run logic such as updating the world,
    ''' checking for collisions, gathering input, and playing audio.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Update(ByVal gameTime As GameTime)
        ' Allows the game to exit
        If GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed Then
            Me.Exit()
        End If

        If currentLevel = 0 And loadlevel = True Then
            currentLevel = 1
            Level1()
            loadlevel = False
        ElseIf currentLevel = 2 And loadlevel = True Then
            Level2()
            loadlevel = False
        ElseIf currentLevel = 3 And loadlevel = True Then
            Level3()
            loadlevel = False
        ElseIf currentLevel = 4 And loadlevel = True Then
            Level4()
            loadlevel = False
        ElseIf currentLevel = 5 And loadlevel = True Then
            Level5()
            loadlevel = False
        ElseIf currentLevel = 6 And loadlevel = True Then
            Level6()
            loadlevel = False
        ElseIf currentLevel = 7 And loadlevel = True Then
            Level7()
            loadlevel = False
        ElseIf currentLevel = 8 And loadlevel = True Then
            Level8()
            loadlevel = False
        ElseIf currentLevel = 9 And loadlevel = True Then
            Level9()
            loadlevel = False
        ElseIf currentLevel = 10 And loadlevel = True Then
            Level10()
            loadlevel = False
        ElseIf currentLevel = 11 And loadlevel = True Then
            Level11()
            loadlevel = False
        ElseIf currentLevel = 12 And loadlevel = True Then
            Level12()
            loadlevel = False
        ElseIf currentLevel = 13 And loadlevel = True Then
            Level13()
            loadlevel = False
        ElseIf currentLevel = 14 And loadlevel = True Then
            Level14()
            loadlevel = False
        ElseIf currentLevel = 15 And loadlevel = True Then
            Level15()
            loadlevel = False
        ElseIf currentLevel = 16 And loadlevel = True Then
            Level16()
            loadlevel = False
        ElseIf currentLevel = 17 And loadlevel = True Then
            Level17()
            loadlevel = False
        End If

        ' Before handling input
        _currentKeyboardState = Keyboard.GetState()

        If (_currentKeyboardState.IsKeyDown(Keys.Up) And
               _previousKeyboardState.IsKeyUp(Keys.Up)) Then
            Dim cnt As Boolean = False
            For i = 0 To block1s.Count - 1
                If block1s(i).X = player.X And block1s(i).Y = player.Y - 1 Then
                    cnt = True
                End If
            Next
            For i = 0 To downzapps.Count - 1
                If downzapps(i).X = player.X And downzapps(i).Y = player.Y - 1 Then
                    cnt = True
                End If
            Next
            For i = 0 To leftzapps.Count - 1
                If leftzapps(i).X = player.X And leftzapps(i).Y = player.Y - 1 Then
                    cnt = True
                End If
            Next
            For i = 0 To rightzapps.Count - 1
                If rightzapps(i).X = player.X And rightzapps(i).Y = player.Y - 1 Then
                    cnt = True
                End If
            Next
            For i = 0 To blues.Count - 1
                If blues(i).X = player.X And blues(i).Y = player.Y - 1 Then
                    cnt = True
                End If
            Next
            Dim ispushed As Boolean = False
            Dim stuck As Boolean = False
            For i = 0 To upzapps.Count - 1
                If upzapps(i).X = player.X And upzapps(i).Y = player.Y - 1 Then
                    player.Y = player.Y - 1
                    player.vector.Y = player.Y * 39
                    stuck = False
                End If
            Next
            For i = 0 To greens.Count - 1
                If greens(i).X = player.X And greens(i).Y = player.Y - 1 Then
                    ispushed = pushGreen(greens(i), 0, -1)
                    If ispushed Then
                        If greens(i).Y > 0 Then
                            greens(i).Y = greens(i).Y - 1
                        End If
                        greens(i).vector.Y = greens(i).Y * CInt(30 * 1.3)
                    Else
                        stuck = True
                    End If
                End If
            Next
            For i = 0 To yellows.Count - 1
                If yellows(i).X = player.X And yellows(i).Y = player.Y - 1 Then
                    ispushed = pushYellow(yellows(i), -1)
                    If ispushed Then
                        If yellows(i).Y > 0 Then
                            yellows(i).Y = yellows(i).Y - 1
                        End If
                        yellows(i).vector.Y = yellows(i).Y * CInt(30 * 1.3)
                    Else
                        stuck = True
                    End If
                End If
            Next
            Dim cant As Boolean = False
            For i = 0 To bricks.Count - 1
                If bricks(i).X = player.X And bricks(i).Y = player.Y - 1 Then
                    cant = True
                End If
            Next
            If Not cant And Not cnt Then
                If Not stuck Then
                    player.prevX = player.X
                    player.prevY = player.Y
                    player.Y = player.Y - 1
                    player.vector.Y = player.vector.Y - CInt(30 * 1.3)
                End If
            End If
        End If
        If _currentKeyboardState.IsKeyDown(Keys.Down) And
           _previousKeyboardState.IsKeyUp(Keys.Down) Then
            Dim ispushed As Boolean = False
            Dim stuck As Boolean = False
            Dim cnt As Boolean = False
            For i = 0 To block1s.Count - 1
                If block1s(i).X = player.X And block1s(i).Y = player.Y + 1 Then
                    cnt = True
                End If
            Next
            For i = 0 To upzapps.Count - 1
                If upzapps(i).X = player.X And upzapps(i).Y = player.Y + 1 Then
                    cnt = True
                End If
            Next
            For i = 0 To leftzapps.Count - 1
                If leftzapps(i).X = player.X And leftzapps(i).Y = player.Y + 1 Then
                    cnt = True
                End If
            Next
            For i = 0 To rightzapps.Count - 1
                If rightzapps(i).X = player.X And rightzapps(i).Y = player.Y + 1 Then
                    cnt = True
                End If
            Next
            For i = 0 To blues.Count - 1
                If blues(i).X = player.X And blues(i).Y = player.Y + 1 Then
                    cnt = True
                End If
            Next
            For i = 0 To downzapps.Count - 1
                If downzapps(i).X = player.X And downzapps(i).Y = player.Y + 1 Then
                    Dim inc As Boolean = True
                    For j = 0 To greens.Count - 1
                        If greens(j).X = player.X And greens(j).Y = player.Y + 2 Then
                            inc = False
                        End If
                    Next
                    If inc Then
                        player.Y = player.Y + 1
                    Else
                        cnt = True
                    End If
                    player.vector.Y = player.Y * 39
                    stuck = False
                End If
            Next
            For i = 0 To greens.Count - 1
                If greens(i).X = player.X And greens(i).Y = player.Y + 1 Then
                    ispushed = pushGreen(greens(i), 0, 1)
                    If ispushed Then
                        If greens(i).Y < 9 Then
                            greens(i).Y = greens(i).Y + 1
                        End If
                        greens(i).vector.Y = greens(i).Y * CInt(30 * 1.3)
                    Else
                        stuck = True
                    End If
                End If
            Next
            For i = 0 To yellows.Count - 1
                If yellows(i).X = player.X And yellows(i).Y = player.Y + 1 Then
                    ispushed = pushYellow(yellows(i), 1)
                    If ispushed Then
                        If yellows(i).Y < 9 Then
                            yellows(i).Y = yellows(i).Y + 1
                        End If
                        yellows(i).vector.Y = yellows(i).Y * CInt(30 * 1.3)
                    Else
                        stuck = True
                    End If
                End If
            Next
            Dim cant As Boolean = False
            For i = 0 To bricks.Count - 1
                If bricks(i).X = player.X And bricks(i).Y = player.Y + 1 Then
                    cant = True
                End If
            next
            If Not cant And Not cnt Then
                If Not stuck Then
                    player.prevX = player.X
                    player.prevY = player.Y
                    player.Y = player.Y + 1
                    player.vector.Y = player.vector.Y + CInt(30 * 1.3)
                End If
            End If
        End If
        If _currentKeyboardState.IsKeyDown(Keys.Left) And
           _previousKeyboardState.IsKeyUp(Keys.Left) Then
            Dim ispushed As Boolean = False
            Dim stuck As Boolean = False
            Dim cnt As Boolean = False
            For i = 0 To block1s.Count - 1
                If block1s(i).X = player.X - 1 And block1s(i).Y = player.Y Then
                    cnt = True
                End If
            Next
            For i = 0 To upzapps.Count - 1
                If upzapps(i).X = player.X - 1 And upzapps(i).Y = player.Y Then
                    cnt = True
                End If
            Next
            For i = 0 To downzapps.Count - 1
                If downzapps(i).X = player.X - 1 And downzapps(i).Y = player.Y Then
                    cnt = True
                End If
            Next
            For i = 0 To rightzapps.Count - 1
                If rightzapps(i).X = player.X - 1 And rightzapps(i).Y = player.Y Then
                    cnt = True
                End If
            Next
            For i = 0 To yellows.Count - 1
                If yellows(i).X = player.X - 1 And yellows(i).Y = player.Y Then
                    cnt = True
                End If
            Next
            For i = 0 To leftzapps.Count - 1
                If leftzapps(i).X = player.X - 1 And leftzapps(i).Y = player.Y Then
                    player.X = player.X - 1
                    player.vector.X = player.X * 39
                    stuck = False
                End If
            Next
            For i = 0 To greens.Count - 1
                If greens(i).X = player.X - 1 And greens(i).Y = player.Y Then
                    ispushed = pushGreen(greens(i), -1, 0)
                    If ispushed Then
                        If greens(i).X > 0 Then
                            greens(i).X = greens(i).X - 1
                        End If
                        greens(i).vector.X = greens(i).X * CInt(30 * 1.3)
                    Else
                        stuck = True
                    End If
                End If
            Next
            For i = 0 To blues.Count - 1
                If blues(i).X = player.X - 1 And blues(i).Y = player.Y Then
                    ispushed = pushBlue(blues(i), -1)
                    If ispushed Then
                        If blues(i).X > 0 Then
                            blues(i).X = blues(i).X - 1
                        End If
                        blues(i).vector.X = blues(i).X * CInt(30 * 1.3)
                    Else
                        stuck = True
                    End If
                End If
            Next
            Dim cant As Boolean = False
            For i = 0 To bricks.Count - 1
                If bricks(i).X = player.X - 1 And bricks(i).Y = player.Y Then
                    cant = True
                End If
            Next
            If Not cant And Not cnt Then
                If Not stuck Then
                    player.prevX = player.X
                    player.prevY = player.Y
                    player.X = player.X - 1
                    player.vector.X = player.vector.X - CInt(30 * 1.3)
                End If
            End If
        End If
        If _currentKeyboardState.IsKeyDown(Keys.Right) AndAlso
               _previousKeyboardState.IsKeyUp(Keys.Right) Then
            Dim ispushed As Boolean = False
            Dim stuck As Boolean = False
            Dim cnt As Boolean = False
            For i As Integer = 0 To block1s.Count - 1
                If block1s(i).X = player.X + 1 AndAlso block1s(i).Y = player.Y Then
                    cnt = True
                End If
            Next
            For i As Integer = 0 To upzapps.Count - 1
                If upzapps(i).X = player.X + 1 AndAlso upzapps(i).Y = player.Y Then
                    cnt = True
                End If
            Next
            For i As Integer = 0 To downzapps.Count - 1
                If downzapps(i).X = player.X + 1 AndAlso downzapps(i).Y = player.Y Then
                    cnt = True
                End If
            Next
            For i As Integer = 0 To leftzapps.Count - 1
                If leftzapps(i).X = player.X + 1 AndAlso leftzapps(i).Y = player.Y Then
                    cnt = True
                End If
            Next
            For i As Integer = 0 To yellows.Count - 1
                If yellows(i).X = player.X + 1 AndAlso yellows(i).Y = player.Y Then
                    cnt = True
                End If
            Next
            For i As Integer = 0 To rightzapps.Count - 1
                If rightzapps(i).X = player.X + 1 AndAlso rightzapps(i).Y = player.Y Then
                    player.X += 1
                    player.vector.X = player.X * 39
                End If
            Next
            For i As Integer = 0 To greens.Count - 1
                If greens(i).X = player.X + 1 AndAlso greens(i).Y = player.Y Then
                    ispushed = pushGreen(greens(i), 1, 0)
                    If ispushed Then
                        If greens(i).X < 14 Then
                            greens(i).X += 1
                        End If
                        greens(i).vector.X = greens(i).X * CInt(Math.Truncate(30 * 1.3))
                    Else
                        stuck = True
                    End If
                End If
            Next
            For i As Integer = 0 To blues.Count - 1
                If blues(i).X = player.X + 1 AndAlso blues(i).Y = player.Y Then
                    ispushed = pushBlue(blues(i), 1)
                    If ispushed Then
                        If blues(i).X < 14 Then
                            blues(i).X += 1
                        End If
                        blues(i).vector.X = blues(i).X * CInt(Math.Truncate(30 * 1.3))
                    Else
                        stuck = True
                    End If
                End If
            Next
            Dim cant As Boolean = False
            For i As Integer = 0 To bricks.Count - 1
                If bricks(i).X = player.X + 1 AndAlso bricks(i).Y = player.Y Then
                    cant = True
                End If
            Next
            If Not cant AndAlso Not cnt Then
                If Not stuck Then
                    player.prevX = player.X
                    player.prevY = player.Y
                    player.X += 1
                    player.vector.X += CInt(Math.Truncate(30 * 1.3))
                End If
            End If
        End If
        If _currentKeyboardState.IsKeyUp(Keys.Up) And
            _currentKeyboardState.IsKeyUp(Keys.Down) And
            _currentKeyboardState.IsKeyUp(Keys.Left) And
            _currentKeyboardState.IsKeyUp(Keys.Right) Then
            If downmovers.Count > 0 Then
                For i As Integer = 0 To downmovers.Count - 1
                    Dim ispushe As Boolean = False
                    Dim stuc As Boolean = False
                    ispushe = pushDM(player, downmovers(i), 0, 1)
                    If ispushe Then
                        If downmovers(i).Y < 9 Then
                            downmovers(i).Y = downmovers(i).Y + 1
                            If player.X = downmovers(i).X And player.Y = downmovers(i).Y Then
                                downmovers(i).Y = downmovers(i).Y - 1
                            End If
                        End If
                        downmovers(i).vector.Y = downmovers(i).Y * CInt(30 * 1.3)
                    End If
                Next
            End If
            If upmovers.Count > 0 Then
                For i As Integer = 0 To upmovers.Count - 1
                    Dim ispushe As Boolean = False
                    Dim stuc As Boolean = False
                    ispushe = pushUM(player, upmovers(i), 0, -1)
                    If ispushe Then
                        If upmovers(i).Y > 0 Then
                            upmovers(i).Y -= 1
                            If player.X = upmovers(i).X AndAlso player.Y = upmovers(i).Y Then
                                upmovers(i).Y += 1
                            End If
                        End If
                        upmovers(i).vector.Y = upmovers(i).Y * CInt(Math.Truncate(30 * 1.3))
                    End If
                Next
            End If
            If leftmovers.Count > 0 Then
                For i As Integer = 0 To leftmovers.Count - 1
                    Dim ispushe As Boolean = False
                    Dim stuc As Boolean = False
                    ispushe = pushLM(player, leftmovers(i), -1, 0)
                    If ispushe Then
                        If leftmovers(i).X > 0 Then
                            leftmovers(i).X -= 1
                            If player.X = leftmovers(i).X AndAlso player.Y = leftmovers(i).Y Then
                                leftmovers(i).X += 1
                            End If
                        End If
                        leftmovers(i).vector.X = leftmovers(i).X * CInt(Math.Truncate(30 * 1.3))
                    End If
                Next
            End If
            If rightmovers.Count > 0 Then
                For i As Integer = 0 To rightmovers.Count - 1
                    Dim ispushe As Boolean = False
                    Dim stuc As Boolean = False
                    ispushe = pushRM(player, rightmovers(i), 1, 0)
                    If ispushe Then
                        If rightmovers(i).X < 14 Then
                            rightmovers(i).X += 1
                            If player.X = rightmovers(i).X AndAlso player.Y = rightmovers(i).Y Then
                                rightmovers(i).X -= 1
                            End If
                        End If
                        rightmovers(i).vector.X = rightmovers(i).X * CInt(30 * 1.3)
                    End If
                Next
            End If
        End If

        For i As Integer = 0 To greens.Count - 1
            If player.X = greens(i).X AndAlso player.Y = greens(i).Y Then
                player.X = player.prevX
                player.Y = player.prevY
                player.vector.X = player.X * 39
                player.vector.Y = player.Y * 39
            End If
        Next

        For i As Integer = 0 To yellows.Count - 1
            If player.X = yellows(i).X AndAlso player.Y = yellows(i).Y Then
                player.X = player.prevX
                player.Y = player.prevY
                player.vector.X = player.X * 39
                player.vector.Y = player.Y * 39
            End If
        Next

        For i As Integer = 0 To blues.Count - 1
            If player.X = blues(i).X AndAlso player.Y = blues(i).Y Then
                player.X = player.prevX
                player.Y = player.prevY
                player.vector.X = player.X * 39
                player.vector.Y = player.Y * 39
            End If
        Next

        For i As Integer = 0 To upmovers.Count - 1
            If player.X = upmovers(i).X AndAlso player.Y = upmovers(i).Y Then
                player.X = player.prevX
                player.Y = player.prevY
                player.vector.X = player.X * 39
                player.vector.Y = player.Y * 39
            End If
        Next

        For i As Integer = 0 To downmovers.Count - 1
            If player.X = downmovers(i).X AndAlso player.Y = downmovers(i).Y Then
                player.X = player.prevX
                player.Y = player.prevY
                player.vector.X = player.X * 39
                player.vector.Y = player.Y * 39
            End If
        Next

        For i As Integer = 0 To leftmovers.Count - 1
            If player.X = leftmovers(i).X AndAlso player.Y = leftmovers(i).Y Then
                player.X = player.prevX
                player.Y = player.prevY
                player.vector.X = player.X * 39
                player.vector.Y = player.Y * 39
            End If
        Next

        For i As Integer = 0 To rightmovers.Count - 1
            If player.X = rightmovers(i).X AndAlso player.Y = rightmovers(i).Y Then
                player.X = player.prevX
                player.Y = player.prevY
                player.vector.X = player.X * 39
                player.vector.Y = player.Y * 39
            End If
        Next

        If _currentKeyboardState.IsKeyDown(Keys.R) And
            _previousKeyboardState.IsKeyUp(Keys.R) And
            cheat And
            attempts > 0 Then
            If (currentLevel = 1) Then
                Level1()
            End If
            If (currentLevel = 2) Then
                Level2()
            End If
            If (currentLevel = 3) Then
                Level3()
            End If
            If (currentLevel = 4) Then
                Level4()
            End If
            If (currentLevel = 5) Then
                Level5()
            End If
            If (currentLevel = 6) Then
                Level6()
            End If
            If currentLevel = 7 Then
                Level7()
            End If
            If currentLevel = 8 Then
                Level8()
            End If
            If currentLevel = 9 Then
                Level9()
            End If
            If currentLevel = 10 Then
                Level10()
            End If
            If currentLevel = 11 Then
                Level11()
            End If
            If currentLevel = 12 Then
                Level12()
            End If
            If currentLevel = 13 Then
                Level13()
            End If
            If currentLevel = 14 Then
                Level14()
            End If
            If currentLevel = 15 Then
                Level15()
            End If
            If currentLevel = 16 Then
                Level16()
            End If
            If currentLevel = 17 Then
                Level17()
            End If

            attempts -= 1

            player.X = 7
            player.Y = 9
            player.vector.X = player.X * 39
            player.vector.Y = player.Y * 39
        End If

        ' After handling input
        _previousKeyboardState = _currentKeyboardState

        If Not (player.X = 7 AndAlso player.Y = -1) Then
            If player.X < 0 OrElse player.X > 14 OrElse player.Y < 0 OrElse player.Y > 9 Then
                player.X = player.prevX
                player.Y = player.prevY
                player.vector.X = player.X * CInt(Math.Truncate(30 * 1.3))
                player.vector.Y = player.Y * CInt(Math.Truncate(30 * 1.3))
            End If
        End If

        If player.X = 7 AndAlso player.Y = -1 AndAlso currentLevel < 18 Then
            currentLevel = currentLevel + 1
            loadlevel = True
            If currentLevel = 18 Then
                drawwin = True
            End If
        Else
            drawwin = False
        End If

        If currentLevel = 18 Then

            player.X = 7
            player.Y = -1

            player.vector.X = player.X * 39
            player.vector.Y = player.Y * 39

            drawwin = True

        End If

        ' TODO: Add your update logic here
        MyBase.Update(gameTime)

    End Sub

    Public Function pushRM(player As Circle, shp As Shape, x As Integer, y As Integer) As Boolean
        Dim ispushed As Boolean = True
        For i = 0 To upzapps.Count - 1
            If shp.X + x = upzapps(i).X And shp.Y + y = upzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To downzapps.Count - 1
            If shp.X + x = downzapps(i).X And shp.Y + y = downzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To leftzapps.Count - 1
            If shp.X + x = leftzapps(i).X And shp.Y + y = leftzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To rightzapps.Count - 1
            If shp.X + x = rightzapps(i).X And shp.Y + y = rightzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To bricks.Count - 1
            If shp.X + x = bricks(i).X And shp.Y + y = bricks(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To upmovers.Count - 1
            If shp.X + x = upmovers(i).X And shp.Y + y = upmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To downmovers.Count - 1
            If shp.X + x = downmovers(i).X And shp.Y + y = downmovers(i).Y Then
                ispushed = False
            End If
        Next
        If x = 0 And y <> 0 Then
            For i = 0 To blues.Count - 1
                If shp.X = blues(i).X And shp.Y + y = blues(i).Y Then
                    ispushed = False
                End If
            Next
        ElseIf y = 0 And x <> 0 Then
            For i = 0 To yellows.Count - 1
                If shp.X + x = yellows(i).X And shp.Y = yellows(i).Y Then
                    ispushed = False
                End If
            Next
        End If
        If shp.X + x = player.X And shp.Y + y = player.Y Then
            ispushed = False
            Return ispushed
        End If
        For i = 0 To rightmovers.Count - 1
            If shp.X + x = rightmovers(i).X And shp.Y + y = rightmovers(i).Y Then
                ispushed = pushRM(player, rightmovers(i), x, y)
                If ispushed Then
                    If rightmovers(i).X > 0 And rightmovers(i).X < 14 Then
                        rightmovers(i).X = rightmovers(i).X + x
                    Else
                        If rightmovers(i).X = 0 Then
                            If x < 0 Then
                                ispushed = False
                            End If
                        ElseIf rightmovers(i).X = 14 Then
                            If x > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    If rightmovers(i).Y > 0 And rightmovers(i).Y < 9 Then
                        rightmovers(i).Y = rightmovers(i).Y + y
                    Else
                        If rightmovers(i).Y = 0 Then
                            If y < 0 Then
                                ispushed = False
                            End If
                        ElseIf rightmovers(i).Y = 9 Then
                            If y > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    rightmovers(i).vector.X = rightmovers(i).X * CInt(30 * 1.3)
                    rightmovers(i).vector.Y = rightmovers(i).Y * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To greens.Count - 1
            If shp.X + x = greens(i).X And shp.Y + y = greens(i).Y Then
                ispushed = pushGreen(greens(i), x, y)
                If ispushed Then
                    If greens(i).X > 0 And greens(i).X < 14 Then
                        greens(i).X = greens(i).X + x
                    Else
                        If greens(i).X = 0 Then
                            If x < 0 Then
                                ispushed = False
                            End If
                        ElseIf greens(i).X = 14 Then
                            If x > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    If greens(i).Y > 0 And greens(i).Y < 9 Then
                        greens(i).Y = greens(i).Y + y
                    Else
                        If greens(i).Y = 0 Then
                            If y < 0 Then
                                ispushed = False
                            End If
                        ElseIf greens(i).Y = 9 Then
                            If y > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    greens(i).vector.X = greens(i).X * CInt(30 * 1.3)
                    greens(i).vector.Y = greens(i).Y * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To blues.Count - 1
            If shp.X + x = blues(i).X And shp.Y + y = blues(i).Y Then
                ispushed = pushBlue(blues(i), x)
                If ispushed Then
                    If blues(i).X > 0 And blues(i).X < 14 Then
                        blues(i).X = blues(i).X + x
                    Else
                        If blues(i).X = 0 Then
                            If x < 0 Then
                                ispushed = False
                            End If
                        ElseIf blues(i).X = 14 Then
                            If x > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    blues(i).vector.X = blues(i).X * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        Return ispushed
    End Function

    Public Function pushBlock1(player As Circle, shp As Shape, x As Integer, y As Integer) As Boolean
        Dim ispushed As Boolean = True
        For i = 0 To upzapps.Count - 1
            If shp.X + x = upzapps(i).X And shp.Y + y = upzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To downzapps.Count - 1
            If shp.X + x = downzapps(i).X And shp.Y + y = downzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To leftzapps.Count - 1
            If shp.X + x = leftzapps(i).X And shp.Y + y = leftzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To rightzapps.Count - 1
            If shp.X + x = rightzapps(i).X And shp.Y + y = rightzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To bricks.Count - 1
            If shp.X + x = bricks(i).X And shp.Y + y = bricks(i).Y Then
                ispushed = False
            End If
        Next
        If x = 0 And y <> 0 Then
            For i = 0 To blues.Count - 1
                If shp.X = blues(i).X And shp.Y + y = blues(i).Y Then
                    ispushed = False
                End If
            Next
        ElseIf y = 0 And x <> 0 Then
            For i = 0 To yellows.Count - 1
                If shp.X + x = yellows(i).X And shp.Y = yellows(i).Y Then
                    ispushed = False
                End If
            Next
        End If
        If shp.X + x = player.X And shp.Y + y = player.Y Then
            ispushed = False
            Return ispushed
        End If
        For i = 0 To block1s.Count - 1
            If shp.X + x = block1s(i).X And shp.Y + y = block1s(i).Y Then
                ispushed = pushBlock1(player, block1s(i), x, y)
                If ispushed Then
                    If block1s(i).X > 0 And block1s(i).X < 14 Then
                        block1s(i).X = block1s(i).X + x
                    Else
                        If block1s(i).X = 0 Then
                            If x < 0 Then
                                ispushed = False
                            End If
                        ElseIf block1s(i).X = 14 Then
                            If x > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    If block1s(i).Y > 0 And block1s(i).Y < 9 Then
                        block1s(i).Y = block1s(i).Y + y
                    Else
                        If block1s(i).Y = 0 Then
                            If y < 0 Then
                                ispushed = False
                            End If
                        ElseIf block1s(i).Y = 9 Then
                            If y > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    block1s(i).vector.X = block1s(i).X * CInt(30 * 1.3)
                    block1s(i).vector.Y = block1s(i).Y * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To block2s.Count - 1
            If shp.X + x = block2s(i).X And shp.Y + y = block2s(i).Y Then
                ispushed = pushBlock2(player, block2s(i), x, y)
                If ispushed Then
                    If block2s(i).X > 0 And block2s(i).X < 14 Then
                        block2s(i).X = block2s(i).X + x
                    Else
                        If block2s(i).X = 0 Then
                            If x < 0 Then
                                ispushed = False
                            End If
                        ElseIf block2s(i).X = 14 Then
                            If x > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    If block2s(i).Y > 0 And block2s(i).Y < 9 Then
                        block2s(i).Y = block2s(i).Y + y
                    Else
                        If block2s(i).Y = 0 Then
                            If y < 0 Then
                                ispushed = False
                            End If
                        ElseIf block2s(i).Y = 9 Then
                            If y > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    block2s(i).vector.X = block2s(i).X * CInt(30 * 1.3)
                    block2s(i).vector.Y = block2s(i).Y * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To greens.Count - 1
            If shp.X + x = greens(i).X And shp.Y + y = greens(i).Y Then
                ispushed = pushGreen(greens(i), x, y)
                If ispushed Then
                    If greens(i).X > 0 And greens(i).X < 14 Then
                        greens(i).X = greens(i).X + x
                    Else
                        If greens(i).X = 0 Then
                            If x < 0 Then
                                ispushed = False
                            End If
                        ElseIf greens(i).X = 14 Then
                            If x > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    If greens(i).Y > 0 And greens(i).Y < 9 Then
                        greens(i).Y = greens(i).Y + y
                    Else
                        If greens(i).Y = 0 Then
                            If y < 0 Then
                                ispushed = False
                            End If
                        ElseIf greens(i).Y = 9 Then
                            If y > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    greens(i).vector.X = greens(i).X * CInt(30 * 1.3)
                    greens(i).vector.Y = greens(i).Y * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To blues.Count - 1
            If shp.X + x = blues(i).X And shp.Y + y = blues(i).Y Then
                ispushed = pushBlue(blues(i), x)
                If ispushed Then
                    If blues(i).X > 0 And blues(i).X < 14 Then
                        blues(i).X = blues(i).X + x
                    Else
                        If blues(i).X = 0 Then
                            If x < 0 Then
                                ispushed = False
                            End If
                        ElseIf blues(i).X = 14 Then
                            If x > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    blues(i).vector.X = blues(i).X * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To yellows.Count - 1
            If shp.X + x = yellows(i).X And shp.Y + y = yellows(i).Y Then
                ispushed = pushYellow(yellows(i), y)
                If ispushed Then
                    If yellows(i).Y > 0 And yellows(i).Y < 9 Then
                        yellows(i).Y = yellows(i).Y + y
                    Else
                        If yellows(i).Y = 0 Then
                            If y < 0 Then
                                ispushed = False
                            End If
                        ElseIf yellows(i).Y = 9 Then
                            If y > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    yellows(i).vector.Y = yellows(i).Y * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        Return ispushed
    End Function

    Public Function pushBlock2(player As Circle, shp As Shape, x As Integer, y As Integer) As [Boolean]
        Dim ispushed As [Boolean] = True
        For i As Integer = 0 To upzapps.Count - 1
            If shp.X + x = upzapps(i).X AndAlso shp.Y + y = upzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To downzapps.Count - 1
            If shp.X + x = downzapps(i).X AndAlso shp.Y + y = downzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To leftzapps.Count - 1
            If shp.X + x = leftzapps(i).X AndAlso shp.Y + y = leftzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To rightzapps.Count - 1
            If shp.X + x = rightzapps(i).X AndAlso shp.Y + y = rightzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To bricks.Count - 1
            If shp.X + x = bricks(i).X AndAlso shp.Y + y = bricks(i).Y Then
                ispushed = False
            End If
        Next
        If x = 0 AndAlso y <> 0 Then
            For i As Integer = 0 To blues.Count - 1
                If shp.X = blues(i).X AndAlso shp.Y + y = blues(i).Y Then
                    ispushed = False
                End If
            Next
        ElseIf y = 0 AndAlso x <> 0 Then
            For i As Integer = 0 To yellows.Count - 1
                If shp.X + x = yellows(i).X AndAlso shp.Y = yellows(i).Y Then
                    ispushed = False
                End If
            Next
        End If
        If shp.X + x = player.X AndAlso shp.Y + y = player.Y Then
            ispushed = False
            Return ispushed
        End If
        For i As Integer = 0 To block1s.Count - 1
            If shp.X + x = block1s(i).X AndAlso shp.Y + y = block1s(i).Y Then
                ispushed = pushBlock1(player, block1s(i), x, y)
                If ispushed Then
                    If block1s(i).X > 0 AndAlso block1s(i).X < 14 Then
                        block1s(i).X += x
                    ElseIf block1s(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf block1s(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If block1s(i).Y > 0 AndAlso block1s(i).Y < 9 Then
                        block1s(i).Y += y
                    ElseIf block1s(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf block1s(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    block1s(i).vector.X = block1s(i).X * CInt(Math.Truncate(30 * 1.3))
                    block1s(i).vector.Y = block1s(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To block2s.Count - 1
            If shp.X + x = block2s(i).X AndAlso shp.Y + y = block2s(i).Y Then
                ispushed = pushBlock2(player, block2s(i), x, y)
                If ispushed Then
                    If block2s(i).X > 0 AndAlso block2s(i).X < 14 Then
                        block2s(i).X += x
                    ElseIf block2s(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf block2s(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If block2s(i).Y > 0 AndAlso block2s(i).Y < 9 Then
                        block2s(i).Y += y
                    ElseIf block2s(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf block2s(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    block2s(i).vector.X = block2s(i).X * CInt(Math.Truncate(30 * 1.3))
                    block2s(i).vector.Y = block2s(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To greens.Count - 1
            If shp.X + x = greens(i).X AndAlso shp.Y + y = greens(i).Y Then
                ispushed = pushGreen(greens(i), x, y)
                If ispushed Then
                    If greens(i).X > 0 AndAlso greens(i).X < 14 Then
                        greens(i).X += x
                    ElseIf greens(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf greens(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If greens(i).Y > 0 AndAlso greens(i).Y < 9 Then
                        greens(i).Y += y
                    ElseIf greens(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf greens(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    greens(i).vector.X = greens(i).X * CInt(Math.Truncate(30 * 1.3))
                    greens(i).vector.Y = greens(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To blues.Count - 1
            If shp.X + x = blues(i).X AndAlso shp.Y + y = blues(i).Y Then
                ispushed = pushBlue(blues(i), x)
                If ispushed Then
                    If blues(i).X > 0 AndAlso blues(i).X < 14 Then
                        blues(i).X += x
                    ElseIf blues(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf blues(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    blues(i).vector.X = blues(i).X * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To yellows.Count - 1
            If shp.X + x = yellows(i).X AndAlso shp.Y + y = yellows(i).Y Then
                ispushed = pushYellow(yellows(i), y)
                If ispushed Then
                    If yellows(i).Y > 0 AndAlso yellows(i).Y < 9 Then
                        yellows(i).Y += y
                    ElseIf yellows(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf yellows(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    yellows(i).vector.Y = yellows(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        Return ispushed
    End Function

    Public Function pushDM(player As Circle, shp As Shape, x As Integer, y As Integer) As Boolean
        Dim ispushed As [Boolean] = True
        For i As Integer = 0 To upmovers.Count - 1
            If shp.X + x = upmovers(i).X AndAlso shp.Y + y = upmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To upzapps.Count - 1
            If shp.X + x = upzapps(i).X AndAlso shp.Y + y = upzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To downzapps.Count - 1
            If shp.X + x = downzapps(i).X AndAlso shp.Y + y = downzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To leftzapps.Count - 1
            If shp.X + x = leftzapps(i).X AndAlso shp.Y + y = leftzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To rightzapps.Count - 1
            If shp.X + x = rightzapps(i).X AndAlso shp.Y + y = rightzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To bricks.Count - 1
            If shp.X + x = bricks(i).X AndAlso shp.Y + y = bricks(i).Y Then
                ispushed = False
            End If
        Next
        If x = 0 AndAlso y <> 0 Then
            For i As Integer = 0 To blues.Count - 1
                If shp.X = blues(i).X AndAlso shp.Y + y = blues(i).Y Then
                    ispushed = False
                End If
            Next
        ElseIf y = 0 AndAlso x <> 0 Then
            For i As Integer = 0 To yellows.Count - 1
                If shp.X + x = yellows(i).X AndAlso shp.Y = yellows(i).Y Then
                    ispushed = False
                End If
            Next
        End If
        For i As Integer = 0 To downmovers.Count - 1
            If shp.X + x = downmovers(i).X AndAlso shp.Y + y = downmovers(i).Y Then
                ispushed = pushGreen(downmovers(i), x, y)
                If ispushed Then
                    If downmovers(i).X > 0 AndAlso downmovers(i).X < 14 Then
                        downmovers(i).X += x
                    ElseIf downmovers(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf downmovers(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If downmovers(i).Y > 0 AndAlso downmovers(i).Y < 9 Then
                        downmovers(i).Y += y
                    ElseIf downmovers(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf downmovers(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    downmovers(i).vector.X = downmovers(i).X * CInt(Math.Truncate(30 * 1.3))
                    downmovers(i).vector.Y = downmovers(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To block1s.Count - 1
            If shp.X + x = block1s(i).X AndAlso shp.Y + y = block1s(i).Y Then
                ispushed = pushBlock1(player, block1s(i), x, y)
                If ispushed Then
                    If block1s(i).X > 0 AndAlso block1s(i).X < 14 Then
                        block1s(i).X += x
                    ElseIf block1s(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf block1s(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If block1s(i).Y > 0 AndAlso block1s(i).Y < 9 Then
                        block1s(i).Y += y
                    ElseIf block1s(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf block1s(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    block1s(i).vector.X = block1s(i).X * CInt(Math.Truncate(30 * 1.3))
                    block1s(i).vector.Y = block1s(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To block2s.Count - 1
            If shp.X + x = block2s(i).X AndAlso shp.Y + y = block2s(i).Y Then
                ispushed = pushBlock2(player, block2s(i), x, y)
                If ispushed Then
                    If block2s(i).X > 0 AndAlso block2s(i).X < 14 Then
                        block2s(i).X += x
                    ElseIf block2s(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf block2s(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If block2s(i).Y > 0 AndAlso block2s(i).Y < 9 Then
                        block2s(i).Y += y
                    ElseIf block2s(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf block2s(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    block2s(i).vector.X = block2s(i).X * CInt(Math.Truncate(30 * 1.3))
                    block2s(i).vector.Y = block2s(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To greens.Count - 1
            If shp.X + x = greens(i).X AndAlso shp.Y + y = greens(i).Y Then
                ispushed = pushGreen(greens(i), x, y)
                If ispushed Then
                    If greens(i).X > 0 AndAlso greens(i).X < 14 Then
                        greens(i).X += x
                    ElseIf greens(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf greens(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If greens(i).Y > 0 AndAlso greens(i).Y < 9 Then
                        greens(i).Y += y
                    ElseIf greens(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf greens(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    greens(i).vector.X = greens(i).X * CInt(Math.Truncate(30 * 1.3))
                    greens(i).vector.Y = greens(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To yellows.Count - 1
            If shp.X + x = yellows(i).X AndAlso shp.Y + y = yellows(i).Y Then
                ispushed = pushYellow(yellows(i), y)
                If ispushed Then
                    If yellows(i).Y > 0 AndAlso yellows(i).Y < 9 Then
                        yellows(i).Y += y
                    ElseIf yellows(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf yellows(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    yellows(i).vector.Y = yellows(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        Return ispushed
    End Function

    Public Function pushUM(player As Circle, shp As Shape, x As Integer, y As Integer) As [Boolean]
        Dim ispushed As [Boolean] = True
        For i As Integer = 0 To downmovers.Count - 1
            If shp.X + x = downmovers(i).X AndAlso shp.Y + y = downmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To upzapps.Count - 1
            If shp.X + x = upzapps(i).X AndAlso shp.Y + y = upzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To downzapps.Count - 1
            If shp.X + x = downzapps(i).X AndAlso shp.Y + y = downzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To leftzapps.Count - 1
            If shp.X + x = leftzapps(i).X AndAlso shp.Y + y = leftzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To rightzapps.Count - 1
            If shp.X + x = rightzapps(i).X AndAlso shp.Y + y = rightzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To upmovers.Count - 1
            If shp.X + x = upmovers(i).X AndAlso shp.Y + y = upmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To bricks.Count - 1
            If shp.X + x = bricks(i).X AndAlso shp.Y + y = bricks(i).Y Then
                ispushed = False
            End If
        Next
        If x = 0 AndAlso y <> 0 Then
            For i As Integer = 0 To blues.Count - 1
                If shp.X = blues(i).X AndAlso shp.Y + y = blues(i).Y Then
                    ispushed = False
                End If
            Next
        ElseIf y = 0 AndAlso x <> 0 Then
            For i As Integer = 0 To yellows.Count - 1
                If shp.X + x = yellows(i).X AndAlso shp.Y = yellows(i).Y Then
                    ispushed = False
                End If
            Next
        End If
        For i As Integer = 0 To block1s.Count - 1
            If shp.X + x = block1s(i).X AndAlso shp.Y + y = block1s(i).Y Then
                ispushed = pushBlock1(player, block1s(i), x, y)
                If ispushed Then
                    If block1s(i).X > 0 AndAlso block1s(i).X < 14 Then
                        block1s(i).X += x
                    ElseIf block1s(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf block1s(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If block1s(i).Y > 0 AndAlso block1s(i).Y < 9 Then
                        block1s(i).Y += y
                    ElseIf block1s(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf block1s(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    block1s(i).vector.X = block1s(i).X * CInt(Math.Truncate(30 * 1.3))
                    block1s(i).vector.Y = block1s(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To block2s.Count - 1
            If shp.X + x = block2s(i).X AndAlso shp.Y + y = block2s(i).Y Then
                ispushed = pushBlock2(player, block2s(i), x, y)
                If ispushed Then
                    If block2s(i).X > 0 AndAlso block2s(i).X < 14 Then
                        block2s(i).X += x
                    ElseIf block2s(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf block2s(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If block2s(i).Y > 0 AndAlso block2s(i).Y < 9 Then
                        block2s(i).Y += y
                    ElseIf block2s(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf block2s(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    block2s(i).vector.X = block2s(i).X * CInt(Math.Truncate(30 * 1.3))
                    block2s(i).vector.Y = block2s(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To greens.Count - 1
            If shp.X + x = greens(i).X AndAlso shp.Y + y = greens(i).Y Then
                ispushed = pushGreen(greens(i), x, y)
                If ispushed Then
                    If greens(i).X > 0 AndAlso greens(i).X < 14 Then
                        greens(i).X += x
                    ElseIf greens(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf greens(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If greens(i).Y > 0 AndAlso greens(i).Y < 9 Then
                        greens(i).Y += y
                    ElseIf greens(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf greens(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    greens(i).vector.X = greens(i).X * CInt(Math.Truncate(30 * 1.3))
                    greens(i).vector.Y = greens(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To yellows.Count - 1
            If shp.X + x = yellows(i).X AndAlso shp.Y + y = yellows(i).Y Then
                ispushed = pushYellow(yellows(i), y)
                If ispushed Then
                    If yellows(i).Y > 0 AndAlso yellows(i).Y < 9 Then
                        yellows(i).Y += y
                    ElseIf yellows(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf yellows(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    yellows(i).vector.Y = yellows(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        Return ispushed
    End Function

    Public Function pushLM(player As Circle, shp As Shape, x As Integer, y As Integer) As [Boolean]
        Dim ispushed As [Boolean] = True
        For i As Integer = 0 To upzapps.Count - 1
            If shp.X + x = upzapps(i).X AndAlso shp.Y + y = upzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To downzapps.Count - 1
            If shp.X + x = downzapps(i).X AndAlso shp.Y + y = downzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To leftzapps.Count - 1
            If shp.X + x = leftzapps(i).X AndAlso shp.Y + y = leftzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To rightzapps.Count - 1
            If shp.X + x = rightzapps(i).X AndAlso shp.Y + y = rightzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To leftmovers.Count - 1
            If shp.X + x = leftmovers(i).X AndAlso shp.Y + y = leftmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To bricks.Count - 1
            If shp.X + x = bricks(i).X AndAlso shp.Y + y = bricks(i).Y Then
                ispushed = False
            End If
        Next
        If x = 0 AndAlso y <> 0 Then
            For i As Integer = 0 To blues.Count - 1
                If shp.X = blues(i).X AndAlso shp.Y + y = blues(i).Y Then
                    ispushed = False
                End If
            Next
        ElseIf y = 0 AndAlso x <> 0 Then
            For i As Integer = 0 To yellows.Count - 1
                If shp.X + x = yellows(i).X AndAlso shp.Y = yellows(i).Y Then
                    ispushed = False
                End If
            Next
        End If
        For i As Integer = 0 To greens.Count - 1
            If shp.X + x = greens(i).X AndAlso shp.Y + y = greens(i).Y Then
                ispushed = pushGreen(greens(i), x, y)
                If ispushed Then
                    If greens(i).X > 0 AndAlso greens(i).X < 14 Then
                        greens(i).X += x
                    ElseIf greens(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf greens(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If greens(i).Y > 0 AndAlso greens(i).Y < 9 Then
                        greens(i).Y += y
                    ElseIf greens(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf greens(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    greens(i).vector.X = greens(i).X * CInt(Math.Truncate(30 * 1.3))
                    greens(i).vector.Y = greens(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To blues.Count - 1
            If shp.X + x = blues(i).X AndAlso shp.Y + y = blues(i).Y Then
                ispushed = pushBlue(blues(i), x)
                If ispushed Then
                    If blues(i).X > 0 AndAlso blues(i).X < 14 Then
                        blues(i).X += x
                    ElseIf blues(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf blues(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    blues(i).vector.X = blues(i).X * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        Return ispushed
    End Function

    Public Function pushGreen(shp As Shape, x As Integer, y As Integer) As [Boolean]
        Dim ispushed As [Boolean] = True
        For i As Integer = 0 To upzapps.Count - 1
            If shp.X + x = upzapps(i).X AndAlso shp.Y + y = upzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To downzapps.Count - 1
            If shp.X + x = downzapps(i).X AndAlso shp.Y + y = downzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To leftzapps.Count - 1
            If shp.X + x = leftzapps(i).X AndAlso shp.Y + y = leftzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To rightzapps.Count - 1
            If shp.X + x = rightzapps(i).X AndAlso shp.Y + y = rightzapps(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To upmovers.Count - 1
            If shp.X + x = upmovers(i).X AndAlso shp.Y + y = upmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To downmovers.Count - 1
            If shp.X + x = downmovers(i).X AndAlso shp.Y + y = downmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To leftmovers.Count - 1
            If shp.X + x = leftmovers(i).X AndAlso shp.Y + y = leftmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i As Integer = 0 To bricks.Count - 1
            If shp.X + x = bricks(i).X AndAlso shp.Y + y = bricks(i).Y Then
                ispushed = False
            End If
        Next
        If shp.X + x = player.X AndAlso shp.Y + y = player.Y Then
            ispushed = False
            Return ispushed
        End If
        For i As Integer = 0 To block1s.Count - 1
            If shp.X + x = block1s(i).X AndAlso shp.Y + y = block1s(i).Y Then
                ispushed = pushBlock1(player, block1s(i), x, y)
                If ispushed Then
                    If block1s(i).X > 0 AndAlso block1s(i).X < 14 Then
                        block1s(i).X += x
                    ElseIf block1s(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf block1s(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If block1s(i).Y > 0 AndAlso block1s(i).Y < 9 Then
                        block1s(i).Y += y
                    ElseIf block1s(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf block1s(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    block1s(i).vector.X = block1s(i).X * CInt(Math.Truncate(30 * 1.3))
                    block1s(i).vector.Y = block1s(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To block2s.Count - 1
            If shp.X + x = block2s(i).X AndAlso shp.Y + y = block2s(i).Y Then
                ispushed = pushBlock2(player, block2s(i), x, y)
                If ispushed Then
                    If block2s(i).X > 0 AndAlso block2s(i).X < 14 Then
                        block2s(i).X += x
                    ElseIf block2s(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf block2s(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If block2s(i).Y > 0 AndAlso block2s(i).Y < 9 Then
                        block2s(i).Y += y
                    ElseIf block2s(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf block2s(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    block2s(i).vector.X = block2s(i).X * CInt(Math.Truncate(30 * 1.3))
                    block2s(i).vector.Y = block2s(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To greens.Count - 1
            If shp.X + x = greens(i).X AndAlso shp.Y + y = greens(i).Y Then
                ispushed = pushGreen(greens(i), x, y)
                If ispushed Then
                    If greens(i).X > 0 AndAlso greens(i).X < 14 Then
                        greens(i).X += x
                    ElseIf greens(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf greens(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    If greens(i).Y > 0 AndAlso greens(i).Y < 9 Then
                        greens(i).Y += y
                    ElseIf greens(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf greens(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    greens(i).vector.X = greens(i).X * CInt(Math.Truncate(30 * 1.3))
                    greens(i).vector.Y = greens(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To yellows.Count - 1
            If shp.X + x = yellows(i).X AndAlso shp.Y + y = yellows(i).Y Then
                If x <> 0 AndAlso y = 0 Then
                    ispushed = False
                    Return ispushed
                End If
                ispushed = pushYellow(yellows(i), y)
                If ispushed Then
                    If yellows(i).Y > 0 AndAlso yellows(i).Y < 9 Then
                        yellows(i).Y += y
                    ElseIf yellows(i).Y = 0 Then
                        If y < 0 Then
                            ispushed = False
                        End If
                    ElseIf yellows(i).Y = 9 Then
                        If y > 0 Then
                            ispushed = False
                        End If
                    End If
                    yellows(i).vector.Y = yellows(i).Y * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        For i As Integer = 0 To blues.Count - 1
            If shp.X + x = blues(i).X AndAlso shp.Y + y = blues(i).Y Then
                If x = 0 AndAlso y <> 0 Then
                    ispushed = False
                    Return ispushed
                End If
                ispushed = pushBlue(blues(i), x)
                If ispushed Then
                    If blues(i).X > 0 AndAlso blues(i).X < 14 Then
                        blues(i).X += x
                    ElseIf blues(i).X = 0 Then
                        If x < 0 Then
                            ispushed = False
                        End If
                    ElseIf blues(i).X = 14 Then
                        If x > 0 Then
                            ispushed = False
                        End If
                    End If
                    blues(i).vector.X = blues(i).X * CInt(Math.Truncate(30 * 1.3))
                    Return ispushed
                End If
            End If
        Next
        Return ispushed
    End Function

    Public Function pushYellow(shp As Shape, y As Integer) As Boolean
        Dim ispushed As Boolean = True
        For i = 0 To bricks.Count - 1
            If shp.X = bricks(i).X And shp.Y + y = bricks(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To blues.Count - 1
            If shp.X = blues(i).X And shp.Y + y = blues(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To leftmovers.Count - 1
            If shp.X = leftmovers(i).X And shp.Y + y = leftmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To rightmovers.Count - 1
            If shp.X = rightmovers(i).X And shp.Y + y = rightmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To downmovers.Count - 1
            If shp.X = downmovers(i).X And shp.Y + y = downmovers(i).Y Then
                ispushed = False
            End If
        Next
        If shp.X = player.X And shp.Y + y = player.Y Then
            ispushed = False
            Return ispushed
        End If
        For i = 0 To yellows.Count - 1
            If shp.X = yellows(i).X And shp.Y + y = yellows(i).Y Then
                ispushed = pushYellow(yellows(i), y)
                If ispushed Then
                    If yellows(i).Y > 0 And yellows(i).Y < 9 Then
                        yellows(i).Y += y
                    Else
                        If yellows(i).Y = 0 Then
                            If y < 0 Then
                                ispushed = False
                            End If
                        ElseIf greens(i).Y = 9 Then
                            If y > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    yellows(i).vector.Y = yellows(i).Y * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To block2s.Count - 1
            If shp.X = block2s(i).X And shp.Y + y = block2s(i).Y Then
                ispushed = pushBlock2(player, block2s(i), 0, y)
                If ispushed Then
                    If block2s(i).Y > 0 And block2s(i).Y < 9 Then
                        block2s(i).Y = block2s(i).Y + y
                    Else
                        If block2s(i).Y = 0 Then
                            If y < 0 Then
                                ispushed = False
                            End If
                        ElseIf block2s(i).Y = 9 Then
                            If y > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    block2s(i).vector.Y = block2s(i).Y * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To block1s.Count - 1
            If shp.X = block1s(i).X And shp.Y + y = block1s(i).Y Then
                ispushed = pushBlock1(player, block1s(i), 0, y)
                If ispushed Then
                    If block1s(i).Y > 0 And block1s(i).Y < 9 Then
                        block1s(i).Y = block1s(i).Y + y
                    Else
                        If block1s(i).Y = 0 Then
                            If y < 0 Then
                                ispushed = False
                            End If
                        ElseIf block1s(i).Y = 9 Then
                            If y > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    block1s(i).vector.Y = block1s(i).Y * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To greens.Count - 1
            If shp.X = greens(i).X And shp.Y + y = greens(i).Y Then
                ispushed = pushGreen(greens(i), 0, y)
                If ispushed Then
                    If greens(i).Y > 0 And greens(i).Y < 9 Then
                        greens(i).Y = greens(i).Y + y
                    Else
                        If greens(i).Y = 0 Then
                            If y < 0 Then
                                ispushed = False
                            End If
                        ElseIf greens(i).Y = 9 Then
                            If y > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    greens(i).vector.Y = greens(i).Y * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        Return ispushed
    End Function

    Public Function pushBlue(shp As Shape, x As Integer) As Boolean
        Dim ispushed As Boolean = True
        For i = 0 To bricks.Count - 1
            If shp.X + x = bricks(i).X And shp.Y = bricks(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To yellows.Count - 1
            If shp.X + x = yellows(i).X And shp.Y = yellows(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To leftmovers.Count - 1
            If shp.X + x = leftmovers(i).X And shp.Y = leftmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To rightmovers.Count - 1
            If shp.X + x = rightmovers(i).X And shp.Y = rightmovers(i).Y Then
                ispushed = False
            End If
        Next
        For i = 0 To downmovers.Count - 1
            If shp.X + x = downmovers(i).X And shp.Y = downmovers(i).Y Then
                ispushed = False
            End If
        Next
        If shp.X + x = player.X And shp.Y = player.Y Then
            ispushed = False
            Return ispushed
        End If
        For i = 0 To block2s.Count - 1
            If shp.X + x = block2s(i).X And shp.Y = block2s(i).Y Then
                ispushed = pushBlock2(player, block2s(i), x, 0)
                If ispushed Then
                    If block2s(i).X > 0 And block2s(i).X < 14 Then
                        block2s(i).X = block2s(i).X + x
                    Else
                        If block2s(i).X = 0 Then
                            If x < 0 Then
                                ispushed = False
                            End If
                        ElseIf block2s(i).X = 14 Then
                            If x > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    block2s(i).vector.X = block2s(i).X * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To block1s.Count - 1
            If shp.X + x = block1s(i).X And shp.Y = block1s(i).Y Then
                ispushed = pushBlock1(player, block1s(i), x, 0)
                If ispushed Then
                    If block1s(i).X > 0 And block1s(i).X < 14 Then
                        block1s(i).X = block1s(i).X + x
                    Else
                        If block1s(i).X = 0 Then
                            If x < 0 Then
                                ispushed = False
                            End If
                        ElseIf block1s(i).X = 14 Then
                            If x > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    block1s(i).vector.X = block1s(i).X * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To blues.Count - 1
            If shp.X + x = blues(i).X And shp.Y = blues(i).Y Then
                ispushed = pushBlue(blues(i), x)
                If ispushed Then
                    If blues(i).X > 0 And blues(i).X < 14 Then
                        blues(i).X = blues(i).X + x
                    Else
                        If blues(i).X = 0 Then
                            If x < 0 Then
                                ispushed = False
                            End If
                        ElseIf blues(i).X = 14 Then
                            If x > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    blues(i).vector.X = blues(i).X * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        For i = 0 To greens.Count - 1
            If shp.X + x = greens(i).X And shp.Y = greens(i).Y Then
                ispushed = pushGreen(greens(i), x, 0)
                If ispushed Then
                    If greens(i).X > 0 And greens(i).X < 14 Then
                        greens(i).X = greens(i).X + x
                    Else
                        If greens(i).X = 0 Then
                            If x < 0 Then
                                ispushed = False
                            End If
                        ElseIf greens(i).X = 14 Then
                            If x > 0 Then
                                ispushed = False
                            End If
                        End If
                    End If
                    greens(i).vector.X = greens(i).X * CInt(30 * 1.3)
                    Return ispushed
                End If
            End If
        Next
        Return ispushed
    End Function

    ''' <summary>
    ''' This is called when the game should draw itself.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Draw(ByVal gameTime As GameTime)
        GraphicsDevice.Clear(Color.Indigo)

        ' TODO: Add your drawing code here
        spriteBatch.Begin()
        ' Create any rectangle you want. Here we'll use the TitleSafeArea for fun.
        Dim titleSafeRectangle As Rectangle = New Rectangle(48, 58, 590, 396)
        ' Call our method (also defined in this blog-post)
        DrawBorder(titleSafeRectangle, 1, Color.White)
        ' Create any rectangle you want. Here we'll use the TitleSafeArea for fun.
        Dim exit_ As Rectangle = New Rectangle(324, 58, 39, 1)
        ' Call our method (also defined in this blog-post)
        DrawBorder(exit_, 1, Color.Indigo)
        Dim exitLeft As Rectangle = New Rectangle(323, 0, 1, 58)
        ' Call our method (also defined in this blog-post)
        DrawBorder(exitLeft, 1, Color.White)
        Dim exitRight As Rectangle = New Rectangle(363, 0, 1, 58)
        ' Call our method (also defined in this blog-post)
        DrawBorder(exitRight, 1, Color.White)
        For i = 0 To bricks.Count - 1
            spriteBatch.Draw(brik, bricks(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To greens.Count - 1
            spriteBatch.Draw(gren, greens(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To blues.Count - 1
            spriteBatch.Draw(blu, blues(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To yellows.Count - 1
            spriteBatch.Draw(yelow, yellows(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To downmovers.Count - 1
            spriteBatch.Draw(downMuver, downmovers(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To upmovers.Count - 1
            spriteBatch.Draw(upMuver, upmovers(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To rightmovers.Count - 1
            spriteBatch.Draw(rightMuver, rightmovers(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To leftmovers.Count - 1
            spriteBatch.Draw(leftMuver, leftmovers(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To upzapps.Count - 1
            spriteBatch.Draw(upzap, upzapps(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To downzapps.Count - 1
            spriteBatch.Draw(downzap, downzapps(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To leftzapps.Count - 1
            spriteBatch.Draw(leftzap, leftzapps(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To rightzapps.Count - 1
            spriteBatch.Draw(rightzap, rightzapps(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To block1s.Count - 1
            spriteBatch.Draw(blok1, block1s(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        For i = 0 To block2s.Count - 1
            spriteBatch.Draw(blok2, block2s(i).vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        Next
        spriteBatch.Draw(circl, player.vector + New Vector2(50, 60), New Rectangle(0, 0, 31, 31), Color.White, 0, Vector2.Zero, 1.3F, SpriteEffects.None, 0.0F)
        If drawwin Then
            spriteBatch.DrawString(spriteFont, "You Won.", New Vector2(0, 0), Color.White)
        Else
            'spriteBatch.DrawString(spriteFont, "You Won.", New Vector2(0, 0), Color.Indigo)
            spriteBatch.DrawString(cyberFont, "Cyberbox", New Vector2(376, 7), Color.Silver)
            If Not drawwin Then
                spriteBatch.DrawString(spriteFont2, "Press 'R' To Retry Level", New Vector2(101, 10), Color.White)
                spriteBatch.DrawString(spriteFont2, "Attempts Remaining: " + attempts.ToString(), New Vector2(101, 30), Color.White)
            End If
            Dim roomNumberIndex As Integer = currentLevel - 1
            If currentLevel = 18 Then
                roomNumberIndex = roomNumberIndex - 1
            End If
            spriteBatch.DrawString(spriteFont3, "Room " + currentLevel.ToString()+ ": " + rooms(roomNumberIndex), New Vector2(250, 470), Color.White)
        End If
        spriteBatch.End()
        MyBase.Draw(gameTime)
    End Sub

    ' <summary>
    ' Will draw a border (hollow rectangle) of the given 'thicknessOfBorder' (in pixels)
    ' of the specified color.
    '
    ' By Sean Colombo, from http://bluelinegamestudios.com/blog
    ' </summary>
    ' <param name="rectangleToDraw"></param>
    ' <param name="thicknessOfBorder"></param>
    Private Sub DrawBorder(rectangleToDraw As Rectangle, thicknessOfBorder As Integer, borderColor As Color)
        ' Draw top line
        spriteBatch.Draw(pixel, New Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor)

        ' Draw left line
        spriteBatch.Draw(pixel, New Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor)

        ' Draw right line
        spriteBatch.Draw(pixel, New Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor)
        ' Draw bottom line
        spriteBatch.Draw(pixel, New Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor)
    End Sub
End Class