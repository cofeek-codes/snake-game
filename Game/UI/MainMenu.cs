

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;

using Snake.Structs;
using System.Collections.Generic;

using ImGuiNET;

using Im = System.Numerics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Snake.UI
{
    public class MainMenu
    {
        private static string title = "Snake Game";
        private static string copyright = "by cofeek-codes";
        // private SpriteBatch drawer;
        private List<string> menuControls = new List<string>();


        private static int w = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        private static int h = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        private static Im.Vector2 screenSize = new Im.Vector2(w, h);

        private static SpriteFont _font;

        private ImGuiStylePtr _style = ImGui.GetStyle();

        private static ImGuiIOPtr io = ImGui.GetIO();
        public MainMenu()
        {

        }

        public static void Init(SpriteFont font)
        {
            _font = font;

            io.Fonts.AddFontFromFileTTF("Content\\fonts\\andy.ttf", 15);
        }



        public static void Render()
        {
            ImGui.SetNextWindowSize(screenSize);
            ImGui.SetNextWindowPos(new Im.Vector2(0, 0));

            ImGui.Begin("snake game", ImGuiWindowFlags.NoTitleBar);

            //title
            ImGui.SetCursorPos(new Im.Vector2(350, 50));
            ImGui.Text(title);

            ImGui.End();
        }




    }


}
