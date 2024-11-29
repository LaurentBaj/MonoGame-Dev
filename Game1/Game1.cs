using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1;

public class Game1 : Game
{
    private SpriteBatch _spriteBatch;

    private ScaledSprite _blazorSprite;
    private EnemySprite _enemySprite;
    
    public Game1()
    {
        new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Texture2D blazorTexture = Content.Load<Texture2D>("blazor");
        Texture2D enemyTexture = Content.Load<Texture2D>("spongebob");
        
        _blazorSprite = new ScaledSprite(blazorTexture, Vector2.Zero);
        _enemySprite = new EnemySprite(enemyTexture, new Vector2(200, 300));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _enemySprite.MoveTowardsPlayer(_blazorSprite.Position, speed: 5f);
        _blazorSprite.UpdatePosition(Keyboard.GetState().IsKeyDown, speed: 16f);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.LightBlue);
        
        _spriteBatch.Begin();
        _spriteBatch.Draw(_blazorSprite.Texture, _blazorSprite.Rect, Color.White);
        _spriteBatch.Draw(_enemySprite.Texture, _enemySprite.Rect, Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}