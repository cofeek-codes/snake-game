using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.Entities;

public class Entity
{
    public static bool CollideWith(Rectangle e1, Rectangle e2)
    {
        if (e1.Intersects(e2)) return true; else return false;
    }
}