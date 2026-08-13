using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Iteration_2;

public class Player
{
    public Vector2 Position { get; set; }
    public float Speed { get; set; } = 200f;

    public Player(Vector2 position)
    {
       Position = position; 
    }

    public void Update(GameTime gameTime)
    {
       Vector2 direction = GetMovementInput();
       Move(direction, gameTime); 
    }

    public void Move(Vector2 direction, GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Position += direction * Speed * deltaTime;
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

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            Game1.PixelTexture,
            new Rectangle(
                (int)Position.X, 
                (int)Position.Y,
                32, 
                32
            ), 
            Color.Red
        );
    }
}