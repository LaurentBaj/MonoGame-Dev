using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1;

public class Sprite(Texture2D texture, Vector2 size)
{
    public Texture2D Texture { get; } = texture;
    public Vector2 Position { get; set; } = size;
    
    public void UpdatePosition(KeyboardState keyboardState)
    {
        if (keyboardState.IsKeyDown(Keys.Right))
            Position = Position with { X = Position.X + 1 };
        if (keyboardState.IsKeyDown(Keys.Left))
            Position = Position with { X = Position.X - 1 };
        if (keyboardState.IsKeyDown(Keys.Up))
            Position = Position with { Y = Position.Y - 1 };
        if (keyboardState.IsKeyDown(Keys.Down))
            Position = Position with { Y = Position.Y + 1 };
    }
}