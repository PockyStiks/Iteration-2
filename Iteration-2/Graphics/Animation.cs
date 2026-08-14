using Microsoft.Xna.Framework;

namespace Iteration_2;

public class Animation
{
    public Rectangle[] Frames { get; }
    public float FrameDuration { get; }

    public Animation(Rectangle[] frames, float frameDuration)
    {
        Frames = frames;
        FrameDuration = frameDuration;
    }}