using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Game1.Direction;

namespace Game1;

public class PlayerSprite(Texture2D texture, Vector2 position, List<EnemySprite> enemySprites) : ScaledSprite(texture, position)
{
    // Define a mapping from Direction to Vector2
    private readonly Dictionary<Direction, Vector2> _directionVectors = new()
    {
        { UP, new Vector2(0, -1) },
        { DOWN, new Vector2(0, 1) },
        { LEFT, new Vector2(-1, 0) },
        { RIGHT, new Vector2(1, 0) }
    };

    public override void UpdatePosition(Func<Keys, bool> keyPressed, float speed = 1)
    {
        Speed = speed;
        
        Direction? movementDirection = null;

        if (keyPressed(Keys.Up))
        {
            movementDirection = UP;
        }
        else if (keyPressed(Keys.Down))
        {
            movementDirection = DOWN;
        }
        else if (keyPressed(Keys.Left))
        {
            movementDirection = LEFT;
        }
        else if (keyPressed(Keys.Right))
        {
            movementDirection = RIGHT;
        }

        if (!movementDirection.HasValue) 
            return;
        
        Vector2 directionVector = _directionVectors[movementDirection.Value];
        Vector2 newPosition = Position + directionVector * speed;

        // Check if new position would collide with any enemy
        bool collisionDetected = enemySprites.Any(enemy =>
            new Rectangle(newPosition.ToPoint(), Rect.Size).Intersects(enemy.Rect));

        if (!collisionDetected)
        {
            Move(directionVector);
        }
    }
    
    private void Move(Vector2 direction)
    {
        Position += direction * Speed;
    }
}