using Microsoft.Xna.Framework;

namespace Iteration_2;

public sealed class OreType
{
    public static readonly OreType Dirt = new("Dirt", new Color(101, 67, 33), 0); // Temporary
    public static readonly OreType Copper = new("Copper", new Color(203, 109, 81), 60);
    public static readonly OreType Iron = new("Iron", new Color(161, 157, 148), 30);
    public static readonly OreType Gold = new("Gold", new Color(255, 215, 0), 10);
    
    public static readonly OreType[] All =
    {
        Copper,
        Iron,
        Gold
    };
    
    public string Name { get; }
    public Color Color { get; }
    public int SpawnWeight { get; }

    public OreType(string name, Color color, int spawnWeight)
    {
        Name = name;
        Color = color;
    }
}