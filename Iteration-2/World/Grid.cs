using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Iteration_2;

public class Grid
{
    public const int TileSize = 32;

    public int Width { get; }
    public int Height { get; }

    private readonly Tile[,] _tiles;

    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        
        _tiles = new Tile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = new Color(
                    Random.Shared.Next(256), 
                    Random.Shared.Next(256), 
                    Random.Shared.Next(256)
                );
                _tiles[x, y] = new Tile(color);
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
               Tile tile = _tiles[x, y]; 
               
               spriteBatch.Draw(
                   Game1.PixelTexture,
                   new Rectangle(
                       x * TileSize,
                       y * TileSize,
                       TileSize,
                       TileSize
                   ),
                   tile.Color
               );
            }
        }
    }
}