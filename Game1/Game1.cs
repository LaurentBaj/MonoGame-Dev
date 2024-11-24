using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1;

public class Game1 : Game
{
    private SpriteBatch _spriteBatch;
    private Texture2D _iconTexture;

    private Sprite _sprite;
    private ScaledSprite _scaledSprite;
    private ColoredSprite _coloredSprite;
    private MovingSprite _movingSprite;
    private List<MovingSprite> movingSprites = [];

    public Game1()
    {
        new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        _iconTexture = Content.Load<Texture2D>("blazor");
        _scaledSprite = new ScaledSprite(_iconTexture, Vector2.Zero);
        
        Texture2D spongebobTexture = Content.Load<Texture2D>("spongebob");
        _sprite = new Sprite(spongebobTexture, new Vector2(400, 400));
        
        _coloredSprite = new ColoredSprite(_iconTexture, new Vector2(100, 100), Color.Red);

        for (int i = 0; i < 5; i++)
        {
            MovingSprite newSprite = new MovingSprite(spongebobTexture, Vector2.Zero, i + 1);
            movingSprites.Add(newSprite);
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        movingSprites.ForEach(x => x.Update());

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        //_spriteBatch.Draw(_scaledSprite.Texture, _scaledSprite.Rect, Color.White);
        //_spriteBatch.Draw(_sprite.Texture, _sprite.Position, Color.White);
        //_spriteBatch.Draw(_coloredSprite.Texture, _coloredSprite.Position, _coloredSprite.Color);
        
        movingSprites.ForEach(sp => _spriteBatch.Draw(sp.Texture, sp.Position, Color.White));
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}