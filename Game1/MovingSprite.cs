using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1;

public class MovingSprite(Texture2D texture, Vector2 position, float speed) : ScaledSprite(texture, position)
{
    public override void Update()
    {
        base.Update();
        
        Position.X = Position.X += speed;
    }
}