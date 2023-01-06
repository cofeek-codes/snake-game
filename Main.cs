using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Snake.Entities;
using Snake.Score;
using Snake.Structs.Enums;

namespace Snake;

public class Main : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;


    public Player player;

    public World world;

    public Coin coin;

    public ScoreManager scoreManager;
    public Main()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.Title = "Snake";
        // _graphics.PreferredBackBufferWidth = 900;
        // _graphics.PreferredBackBufferHeight = 1200;
    }

    protected override void Initialize()
    {
        player = new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
        world = new World(_graphics.PreferredBackBufferWidth, _graphics.
        PreferredBackBufferHeight);
        coin = new Coin();
        scoreManager = new ScoreManager();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        player.LoadTextures(Content);

        coin.LoadTexture(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();



        player.Move(gameTime);

        if (player.position.Intersects(coin.position) && coin.isCollected == false)
        {
            coin.Respawn(world, _spriteBatch);
            scoreManager.AddPoint();

        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        player.Spawn(_spriteBatch, gameTime);

        coin.InitialSpawn(_spriteBatch);

        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
