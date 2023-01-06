using Microsoft.Xna.Framework;

using Engine.Utils.Converters;

using Snake;
using Snake.Entities;
using Snake.Structs.Enums;
using System;

namespace Engine.Utils.Checkers;

public class OutOfBounds
{


    public static bool Test(Player player, World world)
    {
        Vector2 p = RectangleConverter.RectangleToVector(player.position);
        Rectangle c = world.container;

        if (p.X < c.Left || p.X > c.Right) return true;
        else if (p.Y < c.Top || p.Y > c.Bottom) return true;
        else return false;


    }

    public static Vector2 ByDirection(Player player, World world, MovementDirection direction)
    {
        Vector2 p = RectangleConverter.RectangleToVector(player.position);
        Rectangle c = world.container;

        switch (direction)
        {
            case MovementDirection.LEFT:
                if (p.X < c.Left) return new Vector2(c.Right, p.Y);
                break;
            case MovementDirection.RIGHT:
                if (p.X > c.Right) return new Vector2(c.Left, p.Y);
                break;
            case MovementDirection.UP:
                if (p.Y < c.Top) return new Vector2(p.X, c.Bottom);
                break;
            case MovementDirection.DOWN:
                if (p.Y > c.Bottom) return new Vector2(p.X, c.Top);
                break;
        }
        return p;

    }
}