using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Iteration_2;

public class World
{
    public const int Seed = 42;
    public const int ChunkRenderDistance = 1;
    private readonly Dictionary<Point, Chunk> _chunks = new();
    private readonly Point[] _chunksToLoad = new Point[((ChunkRenderDistance * 2) + 1) * ((ChunkRenderDistance * 2) + 1)];
    private readonly WorldGenerator _worldGenerator = new();
    
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
        for (int i = -ChunkRenderDistance; i <= ChunkRenderDistance; i++)
        {
            for (int j = -ChunkRenderDistance; j <= ChunkRenderDistance; j++)
            {
                Point newChunkPosition = new Point(playerChunk.X + i, playerChunk.Y + j);
                _chunksToLoad[index] = newChunkPosition; 
                
                if (!_chunks.ContainsKey(newChunkPosition))
                {
                    Chunk newChunk = _worldGenerator.GenerateChunk(newChunkPosition);
                    _chunks.Add(newChunkPosition, newChunk);
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