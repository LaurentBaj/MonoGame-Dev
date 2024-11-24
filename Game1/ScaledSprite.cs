using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1;

public class ScaledSprite(Texture2D texture, Vector2 position) : Sprite(texture, position)
{
    public Texture2D Texture = texture;
    public Vector2 Position = position;

    public Rectangle Rect 
        => new ((int)Position.X, (int)Position.Y, 100, 100);
}