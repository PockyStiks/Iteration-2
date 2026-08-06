using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Iteration_2;

public class Chunk
{
    public const int ChunkSize = 32;
    public Point ChunkPosition { get; }
    
    private readonly Tile[,] _tiles = new Tile[ChunkSize, ChunkSize];

    public Chunk(Point chunkPosition)
    {
       ChunkPosition = chunkPosition;

       for (int x = 0; x < ChunkSize; x++)
       {
           for (int y = 0; y < ChunkSize; y++)
           {
               _tiles[x, y] = new Tile();
           }
       }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
       for (int x = 0; x < ChunkSize; x++)
       {
           for (int y = 0; y < ChunkSize; y++)
           {
               spriteBatch.Draw(
                   Game1.PixelTexture,
                   new Rectangle(
                       x * ChunkSize,
                       y * ChunkSize,
                       ChunkSize,
                       ChunkSize
                   ),
                   _tiles[x, y].Color
               );
           }
       }
    }
}