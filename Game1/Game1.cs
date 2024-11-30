using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1;

public class Game1 : Game
{
    private SpriteBatch _spriteBatch;

    private PlayerSprite _playerSprite;
    private readonly List<EnemySprite> _enemySprites = [];
    
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
        
        
        EnemySprite enemy1 = new (enemyTexture, new Vector2(400, 100));
        EnemySprite enemy2 = new (enemyTexture, new Vector2(600, 200));
        EnemySprite enemy3 = new (enemyTexture, new Vector2(700, 300));
        _enemySprites.AddRange([enemy1, enemy2, enemy3]);
        
        _playerSprite = new PlayerSprite(blazorTexture, Vector2.Zero, _enemySprites);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape) || _enemySprites.Count == 0)
            Exit();
        
        _playerSprite.UpdatePosition(Keyboard.GetState().IsKeyDown, speed: 7f);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.LightBlue);
        
        Action<ScaledSprite> draw = sprite => 
            _spriteBatch.Draw(sprite.Texture, sprite.Rect, Color.White);
        
        _spriteBatch.Begin();
        
        draw(_playerSprite);
        _enemySprites.ForEach(draw);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}