using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Iteration_2;

public class Tile
{
    public const int TileSize = 32;
    public TerrainType TerrainType { get; set; } =  TerrainType.Dirt;
    public OreType OreType { get; set; }
    public string Name { get; set; }
    public Color Color { get; set; }

    public Tile()
    {
        Name = TerrainType.Name;
        Color = TerrainType.Color;
    }
}