Public Class Game1
    Inherits Microsoft.Xna.Framework.Game

    Private WithEvents graphics As GraphicsDeviceManager
    Private WithEvents spriteBatch As SpriteBatch
    Dim player As Texture2D
    Dim playerY As Integer
    Dim background As Texture2D
    Dim oldkeystate As KeyboardState
    Dim over As SoundEffect
    Dim space As SoundEffect
    Dim gameover1 As Texture2D
    Dim gameover As Boolean
    Dim pipeup As Texture2D
    Dim pipedown As Texture2D
    Dim upY, upY1 As Integer
    Dim downY, downY1 As Integer
    Dim upX As Integer
    Dim downX As Integer
    Dim inter As Integer = 0
    Dim upY2, downY2 As Integer

    Public Sub New()
        graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
    End Sub

    Protected Overrides Sub Initialize()
        playerY = 70
        gameover = False
        upY = -60
        upX = 800
        downX = 800
        downY = 430
        MyBase.Initialize()

    End Sub
    Protected Overrides Sub LoadContent()

        graphics.PreferredBackBufferHeight = 670
        graphics.PreferredBackBufferWidth = 480
        spriteBatch = New SpriteBatch(GraphicsDevice)
        background = Content.Load(Of Texture2D)("background")
        player = Content.Load(Of Texture2D)("player")
        pipeup = Content.Load(Of Texture2D)("pipeup")
        pipedown = Content.Load(Of Texture2D)("pipedown")
        over = Content.Load(Of SoundEffect)("over")
        Space = Content.Load(Of SoundEffect)("space")
        gameover1 = Content.Load(Of Texture2D)("da")
        graphics.ApplyChanges()


    End Sub
    Protected Overrides Sub Update(ByVal gameTime As GameTime)
        Dim fl1 As Integer
        If gameover = False Then
            If Keyboard.GetState.IsKeyDown(Keys.Space) And oldkeystate <> Keyboard.GetState Then
                playerY -= 90
                space.Play()
            End If

            If Keyboard.GetState.IsKeyDown(Keys.Escape) Then
                End
            End If
            If inter = 0 Then
                playerY += 4
            End If
            If inter = 1 Then
                playerY += 20
            End If
            oldkeystate = Keyboard.GetState
            If playerY <= -6 Then
                playerY = 0

            End If
            If playerY >= 600 Then
                over.Play()
                gameover = True
            End If
            If inter = 0 Then
                upX -= 4
                downX -= 4
            End If

            If upX <= -75 And downX <= -75 Then
                While fl1 = 0
                    Randomize()
                    upY1 = CInt(Int((312 * Rnd()) + 1))
                    downY1 = (312 - upY1) + 180
                    upY = upY1 * (-1)
                    downY = downY1
                    If downY <= 670 - 312 Or upY <= 0 Or downY < downY1 Then
                        fl1 = 1
                    End If
                End While
                upX = 482
                downX = 482
            End If

        End If

        If Keyboard.GetState.IsKeyDown(Keys.R) Then
            Initialize()
        End If
        If New Rectangle(30, playerY, 54, 38).Intersects(New Rectangle(upX, upY2, 68, 312)) Or New Rectangle(30, playerY, 54, 38).Intersects(New Rectangle(downX, downY2, 68, 312)) Then
            inter = 1
        End If

        If Keyboard.GetState.IsKeyDown(Keys.Escape) Then
            End
        End If

        MyBase.Update(gameTime)
    End Sub


    Protected Overrides Sub Draw(ByVal gameTime As GameTime)

        GraphicsDevice.Clear(Color.CornflowerBlue)

        upY2 = upY + 30
        downY2 = downY + 30
        spriteBatch.Begin()
        spriteBatch.Draw(background, Vector2.Zero, Color.White)
        spriteBatch.Draw(pipeup, New Vector2(upX, upY2), Color.White)
        spriteBatch.Draw(pipedown, New Vector2(downX, downY2), Color.White)
        spriteBatch.Draw(player, New Vector2(30, playerY), Color.White)
        If gameover = True Then
            spriteBatch.Draw(gameover1, New Vector2(130, 75), Color.White)
        End If
        spriteBatch.End()
        MyBase.Draw(gameTime)
    End Sub

End Class
