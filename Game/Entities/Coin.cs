using System;
using Engine.Utils;
using Engine.Utils.Converters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Entities;

public class Coin
{

    public Texture2D texture { get; set; }

    public Rectangle position { get; set; }

    public bool isCollected { get; set; } = false;
    public Coin(World world)
    {
        int initX = Randomizer.Randomize(world.padding, world.worldWidth);
        int initY = Randomizer.Randomize(world.padding, world.worldWidth);
        position = RectangleConverter.VectorToRectangle(new Vector2(initX, initY));
    }

    public void LoadTexture(ContentManager Content)
    {
        texture = Content.Load<Texture2D>("textures/coin");
    }

    public void Respawn(World world, SpriteBatch drawer, GameTime gameTime)
    {
        Random randomizer = new Random();

        float x = randomizer.Next(0, world.worldWidth);
        float y = randomizer.Next(0, world.worldHeight);

        Rectangle newPosition = RectangleConverter.VectorToRectangle(new Vector2(x, y));

        drawer.Draw(texture, newPosition, Color.White);
    }

    public void InitialSpawn(SpriteBatch drawer)
    {
        drawer.Draw(texture, position, Color.White);
    }

    public void TestPosition()
    {
        Console.WriteLine(position.X.ToString());
        Console.WriteLine(position.Y.ToString());
    }
}