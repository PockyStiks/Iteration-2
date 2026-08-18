using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Iteration_2;

public class Player
{
    public Vector2 Position { get; private set; }
    public float Speed { get; private set; } = 100f;

    private readonly AnimationPlayer _animationPlayer = new();
    
    private readonly Animation _walkDown;
    private readonly Animation _walkUp;
    private readonly Animation _walkLeft;
    private readonly Animation _walkRight;
    
    private readonly Animation _idleDown;
    private readonly Animation _idleUp;
    private readonly Animation _idleLeft;
    private readonly Animation _idleRight;
    
    private enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    private Direction _facingDirection = Direction.Down;
    private float _walkAnimationSpeed = 20f;
    
    public Player(Vector2 position)
    {
       Position = position;

       float walkAnimationSpeed = _walkAnimationSpeed / Speed;
       _walkDown = new Animation(
           [
               SpriteAtlas.PlayerWalkDownRightFoot,
               SpriteAtlas.PlayerStandDown,
               SpriteAtlas.PlayerWalkDownLeftFoot,
               SpriteAtlas.PlayerStandDown
           ],
           walkAnimationSpeed);
       
       _walkUp = new Animation(
           [
               SpriteAtlas.PlayerWalkUpRightFoot,
               SpriteAtlas.PlayerStandUp,
               SpriteAtlas.PlayerWalkUpLeftFoot,
               SpriteAtlas.PlayerStandUp
           ],
           walkAnimationSpeed);
       
       _walkRight = new Animation(
           [
               SpriteAtlas.PlayerWalkRightRightFoot,
               SpriteAtlas.PlayerStandRight,
               SpriteAtlas.PlayerWalkRightLeftFoot,
               SpriteAtlas.PlayerStandRight
           ],
           walkAnimationSpeed);

       _idleDown = new Animation( [ SpriteAtlas.PlayerStandDown ], walkAnimationSpeed);
       _idleUp = new Animation( [ SpriteAtlas.PlayerStandUp ], walkAnimationSpeed);
       _idleRight = new Animation( [ SpriteAtlas.PlayerStandRight ], walkAnimationSpeed);
       
       _walkLeft = _walkRight;
       _idleLeft = _idleRight;
    }

    private Vector2 GetMovementInput()
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

    private void Move(Vector2 direction, GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Position += direction * Speed * deltaTime;
    }

    private Animation GetAnimation(Direction direction, bool walking)
    {
        return direction switch
        {
            Direction.Up => walking ? _walkUp : _idleUp,
            Direction.Down => walking ? _walkDown : _idleDown,
            Direction.Left => walking ? _walkLeft : _idleLeft,
            Direction.Right => walking ? _walkRight : _idleRight,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    private void UpdateAnimation(Vector2 movement)
    {
        if (movement != Vector2.Zero)
        {
            if (Math.Abs(movement.X) >= Math.Abs(movement.Y))
                _facingDirection = movement.X > 0 ? Direction.Right : Direction.Left;
            else
                _facingDirection = movement.Y > 0 ? Direction.Down : Direction.Up;
        }

        _animationPlayer.Play(GetAnimation(_facingDirection, movement != Vector2.Zero));
    }

    public void Update(GameTime gameTime)
    {
       Vector2 direction = GetMovementInput();
       Move(direction, gameTime); 
       UpdateAnimation(direction);
       _animationPlayer.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        SpriteEffects effects = _facingDirection == Direction.Left ? 
            SpriteEffects.FlipHorizontally : SpriteEffects.None;
        
        spriteBatch.Draw(
            SpriteAtlas.SpriteSheet,
            Position,
            _animationPlayer.CurrentFrame,
            Color.White,
            0f,
            Vector2.Zero,
            1f,
            effects,
            0f
        );
    }
}