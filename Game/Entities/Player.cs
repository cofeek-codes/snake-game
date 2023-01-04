using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Snake.Structs.Enums;

namespace Snake.Entities;

public class Player
{
    public Vector2 position { get; set; }
    private Texture2D texture { get; set; }

    public MovementDirection direction { get; set; }
    public Player(Vector2 position)
    {
        this.position = position;
    }

    public void LoadTexture(ContentManager Content)
    {
        texture = Content.Load<Texture2D>("textures/snake");

    }

    public void Draw(SpriteBatch drawer, GameTime gameTime)
    {
        drawer.Draw(texture, position, Color.White);
    }





    public void Move(GameTime gameTime, float basicSpeed = 100f)
    {
        float speed = basicSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        KeyboardState ks = Keyboard.GetState();
        if (ks.IsKeyDown(Keys.A)) this.direction = MovementDirection.LEFT;
        if (ks.IsKeyDown(Keys.D)) this.direction = MovementDirection.RIGHT;
        if (ks.IsKeyDown(Keys.W)) this.direction = MovementDirection.UP;
        if (ks.IsKeyDown(Keys.S)) this.direction = MovementDirection.DOWN;


        switch (direction)
        {
            case MovementDirection.DOWN:
                position = new Vector2(position.X, position.Y + speed);
                Console.WriteLine("down");
                break;
            case MovementDirection.UP:
                position = new Vector2(position.X, position.Y - speed);

                Console.WriteLine("up");


                break;
            case MovementDirection.LEFT:
                position = new Vector2(position.X - speed, position.Y);

                Console.WriteLine("left");

                break;
            case MovementDirection.RIGHT:
                position = new Vector2(position.X + speed, position.Y);

                Console.WriteLine("right");


                break;
        }
    }
}