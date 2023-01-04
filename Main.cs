using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Snake.Entities;
using Snake.Structs.Enums;

namespace Snake;

public class Main : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;


    public Player player;

    public World world;

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
        world = new World(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        player.LoadTexture(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();



        player.Move(gameTime);



        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        // _spriteBatch.Draw(player.texture, player.position, Color.White);
        player.Draw(_spriteBatch, gameTime);
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
