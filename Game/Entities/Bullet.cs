using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Snake.Structs.Enums;

namespace Snake.Entities;

public class Bullet
{
    public Rectangle position { get; set; }

    private float speed;

    private SpriteEffects effect;
    public MovementDirection direction { get; set; }
    private Dictionary<string, Texture2D> textures { get; set; }

    public Bullet()
    {
        textures = new Dictionary<string, Texture2D>() { { "h", null }, { "v", null } };
    }

    public void LoadContent(ContentManager Content)
    {
        textures["h"] = Content.Load<Texture2D>("textures/horizontalBullet");
        textures["v"] = Content.Load<Texture2D>("textures/verticalBullet");
    }
}

