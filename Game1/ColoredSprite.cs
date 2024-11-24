using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1;

public class ColoredSprite(Texture2D texture, Vector2 position, Color color) 
    : ScaledSprite(texture, position)
{
    public Color Color = color;
}