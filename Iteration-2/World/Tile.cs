using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Iteration_2;

public class Tile
{
    public bool Walkable { get; set; } = true;
    public Color Color { get; set; }

    public Tile(Color color)
    {
        Color = color;
    }
}