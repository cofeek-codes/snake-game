using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.UI;

public class UIManager
{
    private SpriteFont font;

    public UIManager()
    {

    }


    public void Init(ContentManager Content)
    {
        font = Content.Load<SpriteFont>("ui/Default");
    }
    public void DrawText(SpriteBatch drawer, string text)
    {
        drawer.DrawString(font, text, new Vector2(25, 25), Color.Black);
    }
}