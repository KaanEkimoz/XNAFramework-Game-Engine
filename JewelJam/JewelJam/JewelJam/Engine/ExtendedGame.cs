using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;


class ExtendedGame : Game
{
    // Standard MonoGame objects for graphics and sprites.
    protected GraphicsDeviceManager graphics;
    protected SpriteBatch spriteBatch;
    // An object for handling keyboard and mouse input.
    protected InputHelper inputHelper;
    // The width and height of the game world, in game units.
    protected Point worldSize;
    // The width and height of the window, in pixels.
    protected Point windowSize;
    // A matrix used for scaling the game world so that it fits inside the window.
    protected Matrix spriteScale;

    protected static GameObjectList gameWorld;

    #region Properties
    public static JewelJamGameWorld GameWorld
    {
        get { return (JewelJamGameWorld)gameWorld; }
    }
    public static Random Random { get; private set; }
    public static ContentManager ContentManager { get; private set; }

    #endregion

    protected ExtendedGame()
    {
        gameWorld = new GameObjectList();
        Content.RootDirectory = "Content";
        graphics = new GraphicsDeviceManager(this);
        inputHelper = new InputHelper();
        Random = new Random();

        // default window and world size
        windowSize = new Point(1024, 768);
        worldSize = new Point(1024, 768);
    }
    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        // store a static reference to the ContentManager
        ContentManager = Content;
        // by default, we’re not running in full−screen mode

        FullScreen = false;
    }
    protected override void Update(GameTime gameTime)
    {
        HandleInput();
        gameWorld.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        // start drawing sprites, applying the scaling matrix
        spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, spriteScale);
        // let all game objects draw themselves
        gameWorld.Draw(gameTime, spriteBatch);
            
        spriteBatch.End();
    }
    protected virtual void HandleInput()
    {
        inputHelper.Update();
        // quit the game when the player presses ESC
        if (inputHelper.KeyPressed(Keys.Escape))
            Exit();
        // toggle full−screen mode when the player presses F5
        if (inputHelper.KeyPressed(Keys.F5))
            FullScreen = !FullScreen;
        gameWorld.HandleInput(inputHelper);

    }

    #region Screen Settings
    void ApplyResolutionSettings(bool fullScreen)
    {
        graphics.IsFullScreen = fullScreen;
        Point screenSize;
        if (fullScreen)
        {
            screenSize = new Point(
            GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
            GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
        }
        else
        {
            screenSize = windowSize;
        }
        // scale the window to the desired size
        graphics.PreferredBackBufferWidth = screenSize.X;
        graphics.PreferredBackBufferHeight = screenSize.Y;

        graphics.ApplyChanges();

        // calculate how the graphics should be scaled
        GraphicsDevice.Viewport = CalculateViewport(screenSize);
        spriteScale = Matrix.CreateScale(
        (float)GraphicsDevice.Viewport.Width / worldSize.X,
        (float)GraphicsDevice.Viewport.Height / worldSize.Y,
        1);
    }
    private Viewport CalculateViewport(Point windowSize)
    {
        Viewport viewport = new Viewport();
        float gameAspectRatio = (float)worldSize.X / worldSize.Y;
        float windowAspectRatio = (float)windowSize.X / windowSize.Y;
        if (windowAspectRatio > gameAspectRatio)
        {
            viewport.Width = (int)(windowSize.Y * gameAspectRatio);
            viewport.Height = windowSize.Y;
        }
        else
        {
            viewport.Width = windowSize.X;
            viewport.Height = (int)(windowSize.X / gameAspectRatio);
        }
        viewport.X = (windowSize.X - viewport.Width) / 2;
        viewport.Y = (windowSize.Y - viewport.Height) / 2;
        return viewport;
    }
    public bool FullScreen
    {
        get { return graphics.IsFullScreen; }
        protected set { ApplyResolutionSettings(value); }
    }
    Vector2 ScreenToWorld(Vector2 screenPosition)
    {
        Vector2 viewportTopLeft = new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y);
        float screenToWorldScale = worldSize.X / (float)GraphicsDevice.Viewport.Width;
        return (screenPosition - viewportTopLeft) * screenToWorldScale;
    }
    #endregion
}
