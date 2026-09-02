using Microsoft.Xna.Framework;
using System;

namespace Iteration_2;

public class WorldGenerator
{
    private readonly Random _random = new(World.Seed);
    private readonly FastNoiseLite _oreNoiseGenerator;
    private readonly FastNoiseLite _craterNoiseGenerator;
    private const float CraterFrequency = 0.5f;
    private const float CraterThreshold = 0.9f;

    public WorldGenerator()
    {
        _oreNoiseGenerator = new FastNoiseLite();
        _oreNoiseGenerator.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
        
        _craterNoiseGenerator = new FastNoiseLite();
        _craterNoiseGenerator.SetNoiseType(FastNoiseLite.NoiseType.Value);
        _craterNoiseGenerator.SetFrequency(CraterFrequency);
        _craterNoiseGenerator.SetSeed(World.Seed + 1000);
    }
    
    private Ore? SelectOreType(int x, int y)
    {
        Ore? winner = null;
        float bestExcess = 0f;
        int seedOffset = 0;
        
        foreach (Ore ore in Ore.All)
        {
            _oreNoiseGenerator.SetFrequency(ore.Frequency);
            _oreNoiseGenerator.SetSeed(World.Seed + seedOffset);
            
            float noiseVal = _oreNoiseGenerator.GetNoise(x, y);
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
    
    private Crater? SelectCraterType(int x, int y)
    {
        float noise = _craterNoiseGenerator.GetNoise(x, y);

        if (noise < CraterThreshold)
            return null;

        return _random.Next(3) switch
        {
            0 => Crater.Small,
            1 => Crater.Large,
            _ => Crater.Multiple
        };
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
                Crater? crater = SelectCraterType(globalTilePosition.X, globalTilePosition.Y);

                if (ore != null)
                {
                    chunk.GetTile(new Point(x, y)).SetOre(ore);
                }
                else if (crater != null)
                {
                    chunk.GetTile(new Point(x, y)).SetCrater(crater);
                }
            }
        }
        
        return chunk;
    }
}