using Microsoft.Xna.Framework;

namespace Iteration_2;

public sealed class TerrainType
{
    public static readonly TerrainType Dirt = new("Dirt", new Color(101, 67, 33));
    
    public string Name { get; }
    public Color Color { get; }

    public TerrainType(string name, Color color)
    {
        Name = name;
        Color = color;
    }
}