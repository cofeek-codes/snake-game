namespace Snake;

public class World
{
    public int padding { get; set; }
    public int worldWidth { get; set; }
    public int worldHeight { get; set; }

    public World(int screenWidth, int screenHeight)
    {
        this.padding = 15;
        this.worldWidth = screenWidth - padding;
        this.worldHeight = screenHeight - padding;

    }

}
