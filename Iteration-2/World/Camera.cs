using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Iteration_2;

public class Camera
{
    public Vector2 Position { get; set; }
    public float Zoom { get; set; } = 1f;
    public float Rotation { get; set; } = 0f;
    public float FollowSpeed { get; set; } = 8f;
    private Viewport _viewport;
    
    public Matrix View => 
        Matrix.CreateTranslation(new Vector3(-Position, 0)) * 
        Matrix.CreateRotationZ(Rotation) *
        Matrix.CreateScale(Zoom, Zoom, 1f) *
        Matrix.CreateTranslation(new Vector3(_viewport.Width * 0.5f, _viewport.Height * 0.5f, 0f)); 
    
    public Camera(Viewport viewport)
    {
        _viewport = viewport;
    }

    public void Update(GameTime gameTime, Vector2 targetPosition)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Position = Vector2.Lerp(Position, targetPosition, FollowSpeed * deltaTime);
    }
}