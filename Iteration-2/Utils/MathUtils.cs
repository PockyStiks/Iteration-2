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
}