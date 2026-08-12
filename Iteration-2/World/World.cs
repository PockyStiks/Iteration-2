using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iteration_2;

public class World
{
    public const int Seed = 42;
    public static readonly Random Random = new(Seed);
    private readonly Dictionary<Point, Chunk> _chunks = new();
    private readonly Point[] _chunksToLoad = new Point[9];
    private readonly FastNoiseLite _noiseGenerator;
    
    public World()
    {
        _noiseGenerator = new FastNoiseLite();
        _noiseGenerator.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
        _noiseGenerator.SetFrequency(0.015f);
    }
    
    private OreType SelectOreType()
    {
        float copper = _copperNoise.GetNoise(globalPosition.X, globalPosition.Y);
        float iron = _ironNoise.GetNoise(globalPosition.X, globalPosition.Y);
        float gold = _goldNoise.GetNoise(globalPosition.X, globalPosition.Y);
    }
    
    private void GenerateChunk(Point chunkPosition)
    {
        Chunk chunk = new Chunk(chunkPosition);
        Dictionary<OreType, float> oreNoise = new();
        
        for (int x = 0; x < Chunk.ChunkSize; x++)
        {
            for (int y = 0; y < Chunk.ChunkSize; y++)
            {
                Point globalTilePosition = ChunkToGlobalTile(chunkPosition, new Point(x, y));

                for (int i = 0; i < OreType.All.Length; i++)
                {
                    float noise = _noiseGenerator.GetNoise(globalTilePosition.X, globalTilePosition.Y);
                    oreNoise[OreType.All[i]] = noise;
                }
                    
                KeyValuePair<OreType, float> best = oreNoise.MaxBy(x => x.Value);
                OreType ore = best.Key;
                float score = best.Value;
                
                if (noise >= 0.6f)
                {
                    chunk.GetTile(globalTilePosition).SetOre(ore);
                }
            }
        }
        _chunks[chunkPosition] = chunk;
    }

    public static Point WorldToGlobalTile(Vector2 worldPosition)
    {
        return new Point(
            (int)Math.Floor(worldPosition.X / Tile.TileSize),
            (int)Math.Floor(worldPosition.Y / Tile.TileSize)
        );
    }

    public static Vector2 GlobalTileToWorld(Point globalTilePosition)
    {
        return new Vector2(
            globalTilePosition.X * Tile.TileSize,
            globalTilePosition.Y * Tile.TileSize
        );
    }

    public static Point GlobalTileToChunk(Point globalTilePosition)
    {
        return new Point(
            MathUtils.FloorDiv(globalTilePosition.X, Chunk.ChunkSize),
            MathUtils.FloorDiv(globalTilePosition.Y, Chunk.ChunkSize)
        );
    }

    public static Point GlobalTileToLocalTile(Point globalTilePosition)
    {
        return new Point(
            MathUtils.Mod(globalTilePosition.X, Chunk.ChunkSize),
            MathUtils.Mod(globalTilePosition.Y, Chunk.ChunkSize)
        );
    }
    
    public static Point ChunkToGlobalTile(Point chunkPosition, Point localTilePosition)
    {
        return new Point(
            chunkPosition.X * Chunk.ChunkSize + localTilePosition.X,
            chunkPosition.Y * Chunk.ChunkSize + localTilePosition.Y
        );
    }

    public void Update(Vector2 playerPosition)
    {
        Point playerTile =  WorldToGlobalTile(playerPosition);
        Point playerChunk = GlobalTileToChunk(playerTile);
        int index = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                _chunksToLoad[index] = new Point(playerChunk.X + i, playerChunk.Y + j);
                if (!_chunks.ContainsKey(_chunksToLoad[index]))
                {
                    GenerateChunk(_chunksToLoad[index]);
                }

                index++;
            }
        }
    }
    
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Point chunk in _chunksToLoad)
        {
            _chunks[chunk].Draw(spriteBatch);
        }
    }
}