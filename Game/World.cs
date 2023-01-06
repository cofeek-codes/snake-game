using System;
using Microsoft.Xna.Framework;

namespace Snake;

public class World
{
    private int padding { get; set; }
    public int worldWidth { get; set; }
    public int worldHeight { get; set; }
    public Rectangle container { get; }
    public World(int screenWidth, int screenHeight)
    {
        this.padding = 15;
        this.worldWidth = screenWidth - padding;
        this.worldHeight = screenHeight - padding;

        this.container = new Rectangle(0, 0, worldWidth, worldHeight);


    }

}
