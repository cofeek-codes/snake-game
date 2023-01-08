
using Engine.Utils.Checkers;
using Engine.Utils.Converters;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Snake.Entities;
using Snake.Score;
using Snake.UI;
using Snake.Tests;

namespace Snake;

public class Main : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;



    public Player player;

    public World world;

    public Coin coin;

    public Obstacle obstacle;

    public ScoreManager scoreManager;

    public UIManager ui;
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

        world = new World(_graphics.PreferredBackBufferWidth, _graphics.
        PreferredBackBufferHeight);

        scoreManager = new ScoreManager();

        ui = new UIManager();

        obstacle = new Obstacle(world);

        player = new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), world);

        coin = new Coin(world);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        player.LoadTextures(Content);

        coin.LoadContent(Content);

        obstacle.LoadContent(Content);


        ui.Init(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();



        player.Move(gameTime);

        if (OutOfBounds.Test(player, world))
        {
            player.position = RectangleConverter.VectorToRectangle(OutOfBounds.ByDirection(player, world, player.direction));
        }

        if (player.position.Intersects(coin.position) && coin.isCollected == false)
        {
            coin.Respawn(world, _spriteBatch);
            scoreManager.AddPoint();
            player.basicSpeed += 15f;


        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        ui.DrawText(_spriteBatch, "Score: " + scoreManager.score);


        player.Spawn(_spriteBatch, gameTime);

        coin.InitialSpawn(_spriteBatch);


        ObstaclePlacingTest.Test(world, obstacle.startPosition, obstacle.direction);


        obstacle.createWalls(world, _spriteBatch);


        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
