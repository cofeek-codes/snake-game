using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Entities;

public class Coin : Entity
{

    public bool isCollected { get; set; } = false;
    public Coin()
    {

    }

    public void LoadTexture(ContentManager Content)
    {
        texture = Content.Load<Texture2D>("textures/coin");
    }

    public void Respawn(World world, SpriteBatch drawer)
    {
        Random randomizer = new Random();

        float x = randomizer.Next(0, world.worldWidth);
        float y = randomizer.Next(0, world.worldHeight);

        Vector2 newPosition = new Vector2(x, y);

        drawer.Draw(texture, newPosition, Color.White);
    }
}