using Microsoft.Xna.Framework;

namespace Iteration_2;

public sealed class Crater
{
    public static readonly Crater None = new("None", null);
    public static readonly Crater Small = new("Small Crater", SpriteAtlas.CraterSmall);
    public static readonly Crater Large = new("Large Crater", SpriteAtlas.CraterLarge);
    public static readonly Crater Multiple = new("Multiple Craters", SpriteAtlas.CraterMultiple);

    public static readonly Crater[] All = { Small, Large, Multiple };
    
    public string Name { get; }
    public Rectangle? Texture { get; }
    
    public Crater(string name, Rectangle? texture)
    {
        Name = name;
        Texture = texture;
    }
}