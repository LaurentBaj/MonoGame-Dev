using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1;

public class Sprite(Texture2D texture, Vector2 size)
{
    public Texture2D Texture { get; } = texture;
    public Vector2 Position { get; } = size;

    public virtual void Update()
    {
        
    }
}