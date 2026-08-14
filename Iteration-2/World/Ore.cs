using Microsoft.Xna.Framework;

namespace Iteration_2;

public sealed class Ore
{
    public static readonly Ore None = new("None", new Color(255, 255, 255), 0f, 0f);
    public static readonly Ore Copper = new("Copper", new Color(203, 109, 81), 0.8f, 0.015f);
    public static readonly Ore Iron = new("Iron", new Color(161, 157, 148), 0.9f, 0.018f);
    public static readonly Ore Gold = new("Gold", new Color(255, 215, 0), 0.98f, 0.02f);
    
    public static readonly Ore[] All =
    {
        Copper,
        Iron,
        Gold
    };
    
    public string Name { get; }
    public Color Color { get; }
    public float Threshold { get; }
    public float Frequency { get; }

    public Ore(string name, Color color, float threshold, float frequency)
    {
        Name = name;
        Color = color;
        Threshold = threshold;
        Frequency = frequency;
    }
}