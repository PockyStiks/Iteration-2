using Microsoft.Xna.Framework.Graphics;

namespace Iteration_2;

public class Tile
{
    public const int TileSize = 32;
    public Ore Ore { get; set; } =  Ore.None;
    public Texture2D Texture { get; set; } = GameAssets.Ground;

    public void SetOre(Ore ore)
    {
        Ore = ore;
    }
}