using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Iteration_2;

public class World
{
    private readonly Dictionary<Point, Chunk> _chunks = new();

    public static Vector2 GridToWorld(Vector2 gridPos)
    {
        return new Vector2(
            gridPos.X * World.ChunkSize,
            gridPos.Y * World.ChunkSize);
    }

    public static Vector2 WorldToGrid(Vector2 worldPos)
    {
        return new Vector2(
            (int)(worldPos.X / World.ChunkSize),
            (int)(worldPos.Y / World.ChunkSize));
    }

    public void Draw(SpriteBatch spriteBatch)
    {
    }
}