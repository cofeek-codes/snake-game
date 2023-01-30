
using Engine.Utils.Checkers;
using Engine.Utils.Converters;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Snake.Entities;
using Snake.Score;
using Snake.State;

using Snake.Structs.Enums;
using Snake.UI;

using MonoGame.ImGui;
using ImGuiNET;
using Microsoft.Xna.Framework.Input;
using Snake.Input;

namespace Snake;

public class Main : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public ImGuiIOPtr io;

    public Player player;

    public World world;

    public Coin coin;

    public Obstacle obstacle;

    public ScoreManager scoreManager;

    public UIManager ui;

    public MainMenu mainMenu;

    public GameState gameState;

    public ImGuiRenderer renderer;

    KeyboardState previousState;

    public bool isPaused = false;
    public ImFontPtr andyFont;
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
        io = ImGui.GetIO();

        GameState.SetState(ApplicationState.MENU);

        previousState = Keyboard.GetState();

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

        MainMenu.Init(this);
    }


    protected override void Update(GameTime gameTime)
    {
        KeyboardState currentState = Keyboard.GetState();
        if (currentState.IsKeyDown(Keys.Escape) && !previousState.IsKeyDown(Keys.Escape))
        {
            GameState.SetState(ApplicationState.MENU);
            isPaused = true;
        }

        if (GameState.GetCurrentState() == ApplicationState.GAME && isPaused == false)
        {

            GameState.RunningUpdate(player, gameTime, world, coin, _spriteBatch, scoreManager);

        }
        else

            base.Update(gameTime);

        previousState = currentState;
    }

    protected override void Draw(GameTime gameTime)
    {

        if (GameState.GetCurrentState() == ApplicationState.GAME && isPaused == false)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            GameState.RunningDraw(player, _spriteBatch, gameTime, coin);
            _spriteBatch.End();
        }
        else if (GameState.GetCurrentState() == ApplicationState.MENU)
        {
            renderer.BeginLayout(gameTime);
            MainMenu.Render();
            renderer.EndLayout();
        }


        base.Draw(gameTime);
    }
}
