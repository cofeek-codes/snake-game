using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Engine.Utils.Converters;

using Snake.Structs.Enums;
using Engine.Utils.Checkers;

namespace Snake.Entities;

public class Player
{
    public Rectangle position { get; set; }

    public Texture2D texture
    {
        get
        {
            return texturePack[direction.ToString().ToLower()];
        }
    }

    private Dictionary<string, Texture2D> texturePack;
    public float basicSpeed { get; set; } = 100f;
    public MovementDirection direction { get; set; }

    public World world;
    public Player(Vector2 position, World world)
    {
        this.position = RectangleConverter.VectorToRectangle(position);
    }

    public void LoadTextures(ContentManager Content)
    {
        string textureBasepath = "textures/snakeDirections/";
        texturePack = new Dictionary<string, Texture2D>() {
            {"up", null},
            {"down", null},
            {"right", null},
            {"left", null},
        };

        foreach (KeyValuePair<string, Texture2D> texture in texturePack)
        {
            texturePack[texture.Key] = Content.Load<Texture2D>(textureBasepath + texture.Key.ToLower());

            Console.WriteLine(texture);
        }



    }

    public void Spawn(SpriteBatch drawer, GameTime gameTime)
    {
        drawer.Draw(texture, position, Color.White);
    }





    public void Move(GameTime gameTime)
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
                position = RectangleConverter.VectorToRectangle(new Vector2(position.X, position.Y + speed));
                Console.WriteLine("down");
                break;
            case MovementDirection.UP:
                position = RectangleConverter.VectorToRectangle(new Vector2(position.X, position.Y - speed));

                Console.WriteLine("up");


                break;
            case MovementDirection.LEFT:
                position = RectangleConverter.VectorToRectangle(new Vector2(position.X - speed, position.Y));

                Console.WriteLine("left");

                break;
            case MovementDirection.RIGHT:
                position = RectangleConverter.VectorToRectangle(new Vector2(position.X + speed, position.Y));

                Console.WriteLine("right");


                break;
        }


    }
}