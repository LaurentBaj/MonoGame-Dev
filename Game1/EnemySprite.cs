using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1;

public class EnemySprite(Texture2D texture, Vector2 position) 
    : ScaledSprite(texture, position)
{
    public override Rectangle Rect 
        => new ((int)Position.X, (int)Position.Y, 50, 50);

    public void MoveTowardsPlayer(Vector2 playerPosition, float speed = 1f)
    {
        Vector2 direction = playerPosition - Position;

        Vector2 normalizedDirection = NormalizedRelativeToEnemyPosition(direction);

        Position += normalizedDirection * speed;
    }

    public virtual Vector2 NormalizedRelativeToEnemyPosition(Vector2 direction)
    {
        float magnitude = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);

        // Check if the magnitude is 0 to avoid dividing by zero
        if (magnitude == 0)
            return Vector2.Zero;

        return direction / magnitude; // Divide direction by its magnitude
    }
}