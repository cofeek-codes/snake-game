
using Engine.Utils.Checkers;
using Engine.Utils.Converters;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Snake.Entities;
using Snake.Score;
using Snake.State;
using Snake.Structs.Enums;
using Snake.UI;
using System.Windows.Forms;

using MonoGame.ImGui;


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

    public GameState gameState;

    public ImGuiRenderer renderer;

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

        renderer = new ImGuiRenderer(this).Initialize().RebuildFontAtlas();

        GameState.SetState(ApplicationState.MENU);

        

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
        MainMenu.Init(Content.Load<SpriteFont>("ui/Default"));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GameState.GetCurrentState() == ApplicationState.GAME) 
        GameState.RunningUpdate(player, gameTime, world, coin, _spriteBatch, scoreManager); 

        base.Update(gameTime);
    }
     
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        if (GameState.GetCurrentState() == ApplicationState.GAME)
        {


        _spriteBatch.Begin();

        GameState.RunningDraw(player, _spriteBatch, gameTime, coin);


        _spriteBatch.End();

        }

        if (GameState.GetCurrentState().Equals(ApplicationState.MENU))
        
        {

            renderer.BeginLayout(gameTime);
            MainMenu.Render();
            renderer.EndLayout();


        }

        base.Draw(gameTime);
    }
}
