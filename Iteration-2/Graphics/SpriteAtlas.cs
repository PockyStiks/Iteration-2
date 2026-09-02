using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Iteration_2;

public class SpriteAtlas
{
    public static Texture2D SpriteSheet { get; private set; }

    public static readonly Rectangle Ground = new(0, 0, 32, 32);
    public static readonly Rectangle Copper = new(32, 0, 32, 32);
    public static readonly Rectangle Gold = new(64, 0, 32, 32);
    public static readonly Rectangle Iron = new(96, 0, 32, 32);
    public static readonly Rectangle CraterLarge = new(128, 0, 32, 32);
    public static readonly Rectangle CraterSmall = new(160, 0, 32, 32);
    public static readonly Rectangle CraterMultiple = new(192, 0, 32, 32);
    public static readonly Rectangle PlayerWalkDownRightFoot = new(224, 0, 32, 32);
    public static readonly Rectangle PlayerWalkRightLeftFoot = new(0, 32, 32, 32);
    public static readonly Rectangle PlayerWalkUpRightFoot = new(32, 32, 32, 32);
    public static readonly Rectangle PlayerStandDown = new(64, 32, 32, 32);
    public static readonly Rectangle PlayerStandRight = new(96, 32, 32, 32);
    public static readonly Rectangle PlayerStandUp = new(128, 32, 32, 32);
    public static readonly Rectangle PlayerWalkDownLeftFoot = new(160, 32, 32, 32);
    public static readonly Rectangle PlayerWalkRightRightFoot = new(192, 32, 32, 32);
    public static readonly Rectangle PlayerWalkUpLeftFoot = new(224, 32, 32, 32);

    public static void LoadAssets(ContentManager content)
    {
       SpriteSheet = content.Load<Texture2D>("SpriteSheet"); 
    }
}