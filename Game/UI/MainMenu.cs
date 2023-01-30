

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;

using Snake.Structs;
using System.Collections.Generic;

using ImGuiNET;

using Im = System.Numerics;
using System.Linq;
using System.Runtime.CompilerServices;
using Snake.State;
using Snake.Structs.Enums;

namespace Snake.UI
{
    public class MainMenu
    {
        private static string title = "Snake Game";
        private static string copyright = "by cofeek-codes";
        // private SpriteBatch drawer;
        private static bool newGamePressed = false;
        private static bool exitPressed = false;
        private static Game instance;

        private static List<string> menuControls = new List<string>()
        {
            "New Game", "Exit"
        };



        private static int w = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        private static int h = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        private static Im.Vector2 screenSize = new Im.Vector2(w, h);


        private ImGuiStylePtr _style = ImGui.GetStyle();

        private static ImGuiIOPtr io = ImGui.GetIO();
        public static ImFontPtr font = io.Fonts.AddFontFromFileTTF("C:\\Users\\cofeek-codes\\Desktop\\snake-game\\Content\\fonts\\andy.ttf", 35);
        public MainMenu()
        {

        }

        public static void Init(Game game)
        {

            instance = game;

        }



        public static void Render()
        {

            ImGui.SetNextWindowSize(screenSize);
            ImGui.SetNextWindowPos(new Im.Vector2(0, 0));

            ImGui.Begin("snake game", ImGuiWindowFlags.NoTitleBar);

            //title
            ImGui.SetCursorPos(new Im.Vector2(350, 50));

            ImGui.Text(title);

            int ycoord = 135;

            ImGui.SetCursorPos(new Im.Vector2(350, ycoord));

            if (ImGui.Button(menuControls[0])) newGamePressed = true;

            ycoord += 50;

            ImGui.SetCursorPos(new Im.Vector2(350, ycoord));

            if (ImGui.Button(menuControls[1])) exitPressed = true;




            if (newGamePressed)
            {
                GameState.SetState(ApplicationState.GAME);

            }

            if (exitPressed)
            {
                instance.Exit();
            }

            ImGui.End();
        }




    }


}
