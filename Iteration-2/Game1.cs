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

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.IsFullScreen = true;
        _graphics.HardwareModeSwitch = false;
        Window.AllowUserResizing = true;
        _graphics.ApplyChanges();
        
        Vector2 spawnPosition = Vector2.Zero;
        
        _world = new World();
        _player = new Player(spawnPosition);
        _camera = new Camera(GraphicsDevice, _player.Center);
        
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
        _camera.Update(gameTime, _player.Center);
        _world.Update(_player.Position);

        Point p = World.MouseToGlobalTile(_camera);
        Console.WriteLine(p);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        
        _spriteBatch.Begin(transformMatrix: _camera.View, samplerState: SamplerState.PointClamp);
        
        _world.Draw(_spriteBatch);
        _player.Draw(_spriteBatch);
        
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}