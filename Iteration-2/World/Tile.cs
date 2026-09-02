namespace Iteration_2;

public class Tile
{
    public const int TileSize = 32;
    public Ore Ore { get; private set; } =  Ore.None;
    public Crater Crater { get; private set; } =  Crater.None;

    public void SetOre(Ore ore)
    {
        Ore = ore;
    }

    public void SetCrater(Crater crater)
    {
        Crater = crater;
    }
}