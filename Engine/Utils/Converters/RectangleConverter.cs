using Microsoft.Xna.Framework;

namespace Engine.Utils.Converters;

public class RectangleConverter
{
    public static Rectangle VectorToRectangle(Vector2 vec)
    {

        Point convertablePoint = new Point((int)vec.X, (int)vec.Y);


        return new Rectangle(convertablePoint, new Point(32, 32));
    }
}