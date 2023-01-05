using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Entities;

public class Entity
{
    public Texture2D texture { get; set; }

    public Vector2 position { get; set; }
}