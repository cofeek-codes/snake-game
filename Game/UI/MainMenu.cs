

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snake.Structs;
using System.Collections.Generic;


namespace Snake.UI
{
    public class MainMenu
    {
        private string title = "Snake Game";
        private string copyright = "by cofeek-codes";
        // private SpriteBatch drawer;
        private List<string> menuControls = new List<string>();

        private SpriteFont font;
        public MainMenu()
        {

        }

        public void Init(SpriteFont font)
        {
            this.font = font;
        }
        public void Display(SpriteBatch drawer)
        {
            float x = CVector.Center.X;
            float y = CVector.Center.Y;

            // titles
            drawer.DrawString(font, title, CVector.Center, Color.White);
            //copyright
            drawer.DrawString(font, copyright, new Vector2(x, y += 215), Color.White);


            foreach (string control in menuControls)
            {
                int i = 1;
                drawer.DrawString(font, control, new Vector2(x, y += 15 * i), Color.White);
                i++;
            }

        }
    }


}
