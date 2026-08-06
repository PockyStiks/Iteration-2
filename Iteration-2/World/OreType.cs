using Microsoft.Xna.Framework;

namespace Iteration_2;

public sealed class OreType
{
    public static readonly OreType Dirt = new("Dirt", new Color(101, 67, 33));
    public static readonly OreType Copper = new("Copper", new Color(203, 109, 81));
    public static readonly OreType Iron = new("Iron", new Color(161, 157, 148));
    public static readonly OreType Gold = new("Gold", new Color(255, 215, 0));
    
    public string Name { get; }
    public Color Color { get; }

    public OreType(string name, Color color)
    {
        Name = name;
        Color = color;
    }
}