using System;
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
    public Coin()
    {

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
}