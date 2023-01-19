
using Engine.Utils.Checkers;
using Engine.Utils.Converters;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Snake.Entities;
using Snake.Score;
using Snake.State;
using Snake.UI;


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

    public MainMenu mainMenu;




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
        ui = new UIManager();






        world = new World(_graphics.PreferredBackBufferWidth, _graphics.
        PreferredBackBufferHeight);

        scoreManager = new ScoreManager();


        mainMenu = new MainMenu();

        obstacle = new Obstacle(world);

        player = new Player(world);

        coin = new Coin(world);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        player.LoadTextures(Content);

        coin.LoadContent(Content);

        obstacle.LoadContent(Content);


        ui.Init(Content, _spriteBatch);
        mainMenu.Init(Content.Load<SpriteFont>("ui/Default"));
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

        ui.DrawText("Score: " + scoreManager.score);


        player.Spawn(_spriteBatch, gameTime);

        coin.InitialSpawn(_spriteBatch);


        mainMenu.Display(_spriteBatch);


        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
