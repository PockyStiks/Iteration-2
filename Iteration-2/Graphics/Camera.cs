using Microsoft.Xna.Framework;

namespace Iteration_2;

public class Camera
{
    public Vector2 Position { get; set; }
    public float Zoom { get; set; } = 2f;
    public float Rotation { get; set; } = 0f;
    public float FollowSpeed { get; set; } = 8f;

    private readonly int _virtualWidth;
    private readonly int _virtualHeight;

    public Matrix View =>
        Matrix.CreateTranslation(new Vector3(-Position, 0)) *
        Matrix.CreateRotationZ(Rotation) *
        Matrix.CreateScale(Zoom, Zoom, 1f) *
        Matrix.CreateTranslation(new Vector3(_virtualWidth * 0.5f, _virtualHeight * 0.5f, 0f));

    public Camera(int virtualWidth, int virtualHeight, Vector2 position)
    {
        _virtualWidth = virtualWidth;
        _virtualHeight = virtualHeight;
        Position = position;
    }

    public void Update(GameTime gameTime, Vector2 targetPosition)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Position = Vector2.Lerp(Position, targetPosition, FollowSpeed * deltaTime);
    }
}
