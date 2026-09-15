using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Iteration_2;

public class MathUtils
{
    public static int FloorDiv(int a, int b)
    {
        return (int)Math.Floor((double)a / b);
    }

    public static int Mod(int a, int b)
    {
        return ((a % b) + b) % b;
    }
    
    public static Rectangle GetScaledDestinationRectangle(GraphicsDevice graphicsDevice, int virtualWidth, int virtualHeight)
    {
        int windowWidth = graphicsDevice.PresentationParameters.BackBufferWidth;
        int windowHeight = graphicsDevice.PresentationParameters.BackBufferHeight;

        float scaleX = (float)windowWidth / virtualWidth;
        float scaleY = (float)windowHeight / virtualHeight;
        float scale = Math.Min(scaleX, scaleY);

        int destWidth = (int)(virtualWidth * scale);
        int destHeight = (int)(virtualHeight * scale);
        int destX = (windowWidth - destWidth) / 2;
        int destY = (windowHeight - destHeight) / 2;

        return new Rectangle(destX, destY, destWidth, destHeight);
    }
}