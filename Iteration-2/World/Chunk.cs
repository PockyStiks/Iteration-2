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

    public Tile GetTile(Point globalTilePosition)
    {
        Point localTilePosition = World.GlobalTileToLocalTile(globalTilePosition);
        return _tiles[localTilePosition.X, localTilePosition.Y];
    }

    public void Draw(SpriteBatch spriteBatch)
    {
       for (int x = 0; x < ChunkSize; x++)
       {
           for (int y = 0; y < ChunkSize; y++)
           {
               Point globalTilePosition = World.ChunkToGlobalTile(ChunkPosition, new Point(x, y));
               Vector2 worldPosition = World.GlobalTileToWorld(globalTilePosition); 
               
               spriteBatch.Draw(
                   Game1.PixelTexture,
                   new Rectangle(
                       (int)worldPosition.X,
                       (int)worldPosition.Y, 
                       Tile.TileSize,
                       Tile.TileSize
                   ),
                   _tiles[x, y].Color
               );
           }
       }
    }
}