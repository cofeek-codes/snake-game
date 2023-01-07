using Engine.Utils.Converters;
using Microsoft.Xna.Framework;

namespace Engine.Utils;

public class InnerUtils
{
    public static Rectangle rect(Vector2 vec) => RectangleConverter.VectorToRectangle(vec);

    public static Vector2 vec(Rectangle rect) => RectangleConverter.RectangleToVector(rect);
}