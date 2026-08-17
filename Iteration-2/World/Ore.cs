using Microsoft.Xna.Framework.Graphics;

namespace Iteration_2;

public sealed class Ore
{
    public static readonly Ore None = new("None", null, 0f, 0f);
    public static readonly Ore Copper = new("Copper", GameAssets.Copper, 0.8f, 0.015f);
    public static readonly Ore Iron = new("Iron", GameAssets.Iron, 0.9f, 0.018f);
    public static readonly Ore Gold = new("Gold", GameAssets.Gold, 0.98f, 0.02f);
    
    public static readonly Ore[] All = { Copper, Iron, Gold };
    
    public string Name { get; }
    public Texture2D? Texture { get; }
    public float Threshold { get; }
    public float Frequency { get; }

    public Ore(string name, Texture2D? texture, float threshold, float frequency)
    {
        Name = name;
        Texture = texture;
        Threshold = threshold;
        Frequency = frequency;
    }
}