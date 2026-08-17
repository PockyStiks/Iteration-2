using Microsoft.Xna.Framework;

namespace Iteration_2;

public class AnimationPlayer
{
    private Animation? _animation;
    private int _frame;
    private float _timer;

    public Rectangle CurrentFrame =>
        _animation!.Frames[_frame];

    public void Play(Animation animation)
    {
        if (_animation == animation)
            return;

        _animation = animation;
        _frame = 0;
        _timer = 0f;
    }

    public void Update(GameTime gameTime)
    {
        if (_animation == null || _animation.Frames.Length < 2)
            return;

        _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (_timer >= _animation.FrameDuration)
        {
            _timer -= _animation.FrameDuration;
            _frame = (_frame + 1) % _animation.Frames.Length;
        }
    }
}