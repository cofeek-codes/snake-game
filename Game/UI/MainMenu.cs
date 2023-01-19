

using Accessibility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snake.Structs;
using Snake.Structs.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Snake.UI
{
    public class MainMenu : UIManager
    {
        private string title = "Snake Game";
        private string copyright = "by cofeek-codes";

        private List<string> menuControls = new List<string>();
public MainMenu()
        {
        
        }
        public void Display()
        {
            float x = CVector.Center.X;
            float y = CVector.Center.Y;
           
            // title
            drawer.DrawString(base.font, title, CVector.Center, Color.White);
            //copyright
        drawer.DrawString(base.font, copyright, new Vector2(x, y+=215), Color.White);


            foreach (string control in menuControls)
            {
                int i = 1;
                drawer.DrawString(base.font, control, new Vector2(x, y+=15 * i), Color.White);
                i++;
            }

        }
    }

    
}
