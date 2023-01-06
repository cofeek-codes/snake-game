using System;
using Engine.Utils.Converters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Entities;

public class Coin
{

    public Texture2D texture { get; set; }

    public Rectangle position { get; set; }

    private SoundEffect coinCollectSfx;

    public bool isCollected { get; set; } = false;
    public Coin()
    {
        this.position = RectangleConverter.VectorToRectangle(new Vector2(200, 300));
    }

    public void LoadContent(ContentManager Content)
    {
        texture = Content.Load<Texture2D>("textures/coin");
        coinCollectSfx = Content.Load<SoundEffect>("audio/coinCollect");
    }

    public void Respawn(World world, SpriteBatch drawer)
    {
        coinCollectSfx.Play();

        Random randomizer = new Random();

        float x = randomizer.Next(world.container.Left, world.container.Right);
        float y = randomizer.Next(world.container.Top, world.container.Bottom);

        Vector2 newPosition = new Vector2(x, y);

        position = RectangleConverter.VectorToRectangle(newPosition);
    }

    public void InitialSpawn(SpriteBatch drawer)
    {
        drawer.Draw(texture, position, Color.White);

        Console.WriteLine(position.ToString());
    }
}