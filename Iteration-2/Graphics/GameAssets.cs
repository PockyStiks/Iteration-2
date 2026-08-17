using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Iteration_2;

public class GameAssets
{
    public static Texture2D Ground { get; private set; }
    public static Texture2D PlayerWalk { get; private set; }
    public static Texture2D Copper { get; private set; }
    public static Texture2D Iron { get; private set; }
    public static Texture2D Gold { get; private set; }

    public static void LoadAssets(ContentManager content)
    {
       Ground = content.Load<Texture2D>("Tiles/Ground"); 
       PlayerWalk =  content.Load<Texture2D>("Player/PlayerWalk");
       Copper  = content.Load<Texture2D>("Ore/Copper");
       Iron  = content.Load<Texture2D>("Ore/Iron");
       Gold  = content.Load<Texture2D>("Ore/Gold");
    }
}