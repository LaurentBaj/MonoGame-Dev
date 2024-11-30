using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1;

public class PlayerSprite(Texture2D texture, Vector2 position, List<EnemySprite> enemySprites)
    : ScaledSprite(texture, position)
{
    public override void UpdatePosition(Func<Keys, bool> keyPressed, float speed = 1)
    {
        Speed = speed;

        // Determine direction based on key pressed
        Vector2 directionVector = GetDirectionVector(keyPressed);

        // Calculate new position
        Vector2 nextPositionVector = Position + directionVector * Speed;

        // Move if no collision detected
        if (IsCollisionDetected(nextPositionVector)) 
            return;
            
        Move(directionVector);
    }

    // Extract method to determine direction vector
    private Vector2 GetDirectionVector(Func<Keys, bool> keyPressed)
    {
        if (keyPressed(Keys.Up))
            return new Vector2(0, -1);
        if (keyPressed(Keys.Down))
            return new Vector2(0, 1);
        if (keyPressed(Keys.Left))
            return new Vector2(-1, 0);
        if (keyPressed(Keys.Right))
            return new Vector2(1, 0);

        return Vector2.Zero;
    }

    // Extract method to check for collision
    private bool IsCollisionDetected(Vector2 newPosition)
    {
        Rectangle newRect = new Rectangle(newPosition.ToPoint(), Rect.Size);
        return enemySprites.Any(enemy => newRect.Intersects(enemy.Rect));
    }

    private void Move(Vector2 direction)
    {
        Position += direction * Speed;
    }
}