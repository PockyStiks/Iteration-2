using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Iteration_2;

public class Tile
{
    public const int TileSize = 16;
    public TerrainType TerrainType { get; set; } = TerrainType.Dirt;
    public OreType OreType { get; set; } =  OreType.Dirt; // Temporary, should be assigned by chunk generation to an ore
    public string Name => TerrainType.Name + " "  + OreType.Name;
    public Color Color => OreType.Color; // Temporary, should be TerrainType.Color

    public void SetOre(OreType oreType)
    {
        OreType = oreType;
    }
}