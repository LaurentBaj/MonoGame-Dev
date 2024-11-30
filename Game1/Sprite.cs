using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Game1.Direction;

namespace Game1;

public class Sprite
{
    public Texture2D Texture { get; }
    public Vector2 Position { get; protected set; }
    private float _speed;

    public Sprite(Texture2D texture, Vector2 startPosition, float initialSpeed = 1f)
    {
        Texture = texture ?? throw new ArgumentNullException(nameof(texture));
        Position = startPosition;
        _speed = initialSpeed;
    }
        
    public virtual void UpdatePosition(Func<Keys, bool> keyPressed, float speed = 1f)
    {
        _speed = speed;

        if (keyPressed(Keys.Up))
        {
            Move(UP);
        }
        else if (keyPressed(Keys.Down))
        {
            Move(DOWN);
        }
        else if (keyPressed(Keys.Left))
        {
            Move(LEFT);
        }
        else if (keyPressed(Keys.Right))
        {
            Move(RIGHT);
        }
    }

    private void Move(Direction direction) => Position = direction switch
    {
        LEFT => new Vector2(Position.X - _speed, Position.Y),
        RIGHT => new Vector2(Position.X + _speed, Position.Y),
        UP => new Vector2(Position.X, Position.Y - _speed),
        DOWN => new Vector2(Position.X, Position.Y + _speed),
        _ => Position
    };
}

public enum Direction
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}