using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1;

public class Sprite(Texture2D texture, Vector2 size)
{
    public Texture2D Texture { get; } = texture;
    public Vector2 Position { get; set; } = size;

    private float _speed = 1f;

    public void UpdatePosition(KeyboardState state) 
        => UpdatePosition(state, 1f);

    public void UpdatePosition(KeyboardState state, float speed)
    {
        _speed = speed;
        
        if (state.IsKeyDown(Keys.Up))
        {
            MoveUp();
        }
        else if (state.IsKeyDown(Keys.Down))
        {
            MoveDown();
        }
        else if (state.IsKeyDown(Keys.Left))
        {
            MoveLeft();
        }
        else if (state.IsKeyDown(Keys.Right))
        {
            MoveRight();
        }
    }
    
    private void MoveUp()
    {
        Position = new Vector2(Position.X, Position.Y - _speed);
    }

    private void MoveDown()
    {
        Position = new Vector2(Position.X, Position.Y + _speed);
    }

    private void MoveLeft()
    {
        Position = new Vector2(Position.X - _speed, Position.Y);
    }

    private void MoveRight()
    {
        Position = new Vector2(Position.X + _speed, Position.Y);
    }
}