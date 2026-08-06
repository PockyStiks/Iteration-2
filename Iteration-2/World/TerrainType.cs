using Microsoft.Xna.Framework;

namespace Iteration_2;

public sealed class TerrainType
{
    public static readonly TerrainType Dirt = new("Dirt", new Color(101, 67, 33));
    public static readonly TerrainType Grass = new("Grass", new Color(34, 139, 34));
    public static readonly TerrainType Stone = new("Stone", new Color(128, 128, 128));
    public static readonly TerrainType Water = new("Water", new Color(28, 107, 160));
    
    public string Name { get; }
    public Color Color { get; }

    public TerrainType(string name, Color color)
    {
        Name = name;
        Color = color;
    }
}