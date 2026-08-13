using Microsoft.Xna.Framework;

namespace Iteration_2;

public class WorldGenerator
{
    private readonly FastNoiseLite _noiseGenerator;

    public WorldGenerator()
    {
        _noiseGenerator = new FastNoiseLite();
        _noiseGenerator.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
    }
    
    private Ore? SelectOreType(int x, int y)
    {
        Ore? winner = null;
        float bestExcess = 0f;
        int seedOffset = 0;
        
        foreach (Ore ore in Ore.All)
        {
            _noiseGenerator.SetFrequency(ore.Frequency);
            _noiseGenerator.SetSeed(World.Seed + seedOffset);
            
            float noiseVal = _noiseGenerator.GetNoise(x, y);
            float excess = noiseVal - ore.Threshold;

            if (excess > 0f && excess > bestExcess)
            {
                bestExcess = excess;
                winner = ore;
            }
            
            seedOffset++;
        }
        
        return winner;
    }
    
    public Chunk GenerateChunk(Point chunkPosition)
    {
        Chunk chunk = new Chunk(chunkPosition);
        
        for (int x = 0; x < Chunk.ChunkSize; x++)
        {
            for (int y = 0; y < Chunk.ChunkSize; y++)
            {
                Point globalTilePosition = World.ChunkToGlobalTile(chunkPosition, new Point(x, y));
                Ore? ore = SelectOreType(globalTilePosition.X, globalTilePosition.Y);

                if (ore != null)
                {
                    chunk.GetTile(new Point(x, y)).SetOre(ore);
                }
            }
        }
        
        return chunk;
    }
}