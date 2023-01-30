using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using ImGuiNET;
using Snake.State;

namespace Snake.UI;

public class UIManager
{
    public SpriteFont font;
    private SpriteBatch drawer;

    public UIManager()
    {

    }



    public void Init(ContentManager Content, SpriteBatch drawer)
    {
        font = Content.Load<SpriteFont>("ui/Default");
        this.drawer = drawer;
    }
    public void DrawText(string text)
    {
        drawer.DrawString(font, text, new Vector2(25, 25), Color.Black);
    }


}