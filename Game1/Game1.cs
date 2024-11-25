﻿using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1;

public class Game1 : Game
{
    private SpriteBatch _spriteBatch;

    private ScaledSprite _blazorSprite;
    
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
        _blazorSprite = new ScaledSprite(blazorTexture, Vector2.Zero);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            Vector2 newPos = _blazorSprite.Position += new Vector2(1, 0);
            _blazorSprite.Position = newPos;
        }
        
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            Vector2 newPos = _blazorSprite.Position += new Vector2(-1, 0);
            _blazorSprite.Position = newPos;
        }
        
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            Vector2 newPos = _blazorSprite.Position += new Vector2(0, -1);
            _blazorSprite.Position = newPos;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            Vector2 newPos = _blazorSprite.Position += new Vector2(0, 1);
            _blazorSprite.Position = newPos;
        }
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.LightBlue);
        
        _spriteBatch.Begin();
        _spriteBatch.Draw(_blazorSprite.Texture, _blazorSprite.Rect, Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}