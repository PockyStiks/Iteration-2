using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Iteration_2;

public class Player
{
    private Vector2 _position =  Vector2.Zero;
    public Vector2 Position => _position;
    
    private float _speed = 100f;
    public float Speed => _speed;
    
    private Texture2D _texture;

    public void Update(GameTime gameTime)
    {
       Vector2 direction = GetMovementInput();
       Move(direction, gameTime); 
    }

    public void Move(Vector2 direction, GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _position += direction * _speed * deltaTime;
    }

    public Vector2 GetMovementInput()
    {
        Vector2 direction = Vector2.Zero;
        KeyboardState newState = Keyboard.GetState();

        if (newState.IsKeyDown(Keys.W)) direction.Y--;
        if (newState.IsKeyDown(Keys.A)) direction.X--;
        if (newState.IsKeyDown(Keys.S)) direction.Y++;
        if (newState.IsKeyDown(Keys.D)) direction.X++;
       
        if (direction != Vector2.Zero) direction.Normalize();
        return direction;
    }

    public void LoadContent(GraphicsDevice graphicsDevice)
    {
        _texture = new Texture2D(graphicsDevice, 1, 1);
        _texture.SetData(new[] { Color.White });

        _position = new Vector2(100, 100);
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            _texture,
            new Rectangle(
                (int)_position.X, 
                (int)_position.Y,
                50, 
                50
            ), 
            Color.Red
        );
    }
}