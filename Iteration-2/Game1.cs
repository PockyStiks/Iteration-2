using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Iteration_2;

public class Game1 : Game
{
    public static Texture2D PixelTexture { get; private set; } 
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player;
    private World _world;
    private Camera _camera;
    private RenderTarget2D _renderTarget;
    
    private const int VirtualWidth = 960;
    private const int VirtualHeight = 540;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
        _graphics.IsFullScreen = true;
        _graphics.HardwareModeSwitch = false;
        _graphics.ApplyChanges();
        
        _renderTarget = new RenderTarget2D(GraphicsDevice, VirtualWidth, VirtualHeight);
        _world = new World();
        Vector2 spawnPosition = Vector2.Zero;
        _player = new Player(spawnPosition);
        _camera = new Camera(VirtualWidth, VirtualHeight, spawnPosition);
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        SpriteAtlas.LoadAssets(Content);
        PixelTexture = new Texture2D(GraphicsDevice, 1, 1);
        PixelTexture.SetData(new[] { Color.White });
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _player.Update(gameTime);
        _camera.Update(gameTime, _player.Position);
        _world.Update(_player.Position);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.SetRenderTarget(_renderTarget);
        GraphicsDevice.Clear(Color.Black);
        
        _spriteBatch.Begin(transformMatrix: _camera.View, samplerState: SamplerState.PointClamp);
        _world.Draw(_spriteBatch);
        _player.Draw(_spriteBatch);
        _spriteBatch.End();
        
        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.Black);

        Rectangle destRect = GetScaledDestinationRectangle();
        
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _spriteBatch.Draw(_renderTarget, destRect, Color.White);
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
    
    private Rectangle GetScaledDestinationRectangle()
    {
        int windowWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
        int windowHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;

        float scaleX = (float)windowWidth / VirtualWidth;
        float scaleY = (float)windowHeight / VirtualHeight;
        float scale = Math.Min(scaleX, scaleY);

        int destWidth = (int)(VirtualWidth * scale);
        int destHeight = (int)(VirtualHeight * scale);
        int destX = (windowWidth - destWidth) / 2;
        int destY = (windowHeight - destHeight) / 2;

        return new Rectangle(destX, destY, destWidth, destHeight);
    }
}