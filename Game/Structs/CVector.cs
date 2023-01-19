using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;

namespace Snake.Structs
{
    /// <summary>
    ///  Custom Vector
    /// </summary>
    //Custom Vector
    public class CVector
    {
        private static float _screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        private static float _screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        /// <summary>
        /// Vector with coordinates of center of screen
        /// </summary>

        public static  Vector2 Center { get; } =  new Vector2(_screenWidth / 2, _screenHeight / 2);


        
       
    }
}
