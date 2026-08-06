using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Iteration_2.Utils;

namespace Iteration_2;

public class World
{
    private readonly Dictionary<Point, Chunk> _chunks = new();
    private Point[] _chunksToLoad = new Point[9];

    // public static void GenerateChunk(Point position)
    // {
    // }

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

    public void Update(Vector2 playerPosition)
    {
        Point playerTile =  WorldToGlobalTile(playerPosition);
        Point playerChunk = GlobalTileToChunk(playerTile);
        Console.WriteLine(_chunksToLoad[0]);
        int index = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                _chunksToLoad[index] = new Point(playerChunk.X + i, playerChunk.Y + j);
                if (!_chunks.ContainsKey(_chunksToLoad[index]))
                {
                    _chunks[_chunksToLoad[index]] = new Chunk(_chunksToLoad[index]);
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