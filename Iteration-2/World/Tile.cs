using Microsoft.Xna.Framework;

namespace Iteration_2;

public class Tile
{
    public const int TileSize = 32;
    public Ore Ore { get; set; } =  Ore.None;
    public Rectangle Texture { get; set; } = SpriteAtlas.Ground;

    public void SetOre(Ore ore)
    {
        Ore = ore;
    }
}