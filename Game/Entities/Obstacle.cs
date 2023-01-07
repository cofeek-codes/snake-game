using System;

using Engine.Utils.Converters;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Snake.Structs.Enums;

namespace Snake.Entities;

public class Obstacle
{
    private Texture2D texture { get; set; }

    public Rectangle startPosition { get; set; }

    private int wallStackCount = 5;
    private int inStackElementPosition;

    private Vector2 inStackElementCoords;
    public PositionalDirection direction;


    public Obstacle(World world)
    {
        Random r = new Random();

        Vector2 startCoords = new Vector2(r.Next(world.container.Left, world.container.Right), r.Next(world.container.Top, world.container.Bottom));

        startPosition = U.rect(startCoords);



    }



    public void LoadContent(ContentManager Content)
    {
        texture = Content.Load<Texture2D>("textures/brickTest");
    }
    public void createWalls(World world, SpriteBatch drawer)
    {
        Random r = new Random();

        if (r.Next(0, 1) == 0) direction = PositionalDirection.HORIZONTAL; else direction = PositionalDirection.VERTICAL;



        // for (int i = 0; i <= 5; ++i)
        // {
        //     Console.WriteLine($"Before {i}: {testPosition}");
        //     testPosition += testPosition;
        //     Console.WriteLine($"After {i}: {testPosition}");



        // }

        for (int i = 0; i <= wallStackCount; ++i)
        {
            if (i == 0 && direction == PositionalDirection.HORIZONTAL)
            {
                inStackElementPosition = startPosition.Width;
                drawer.Draw(texture, startPosition, Color.White);
            }
            if (i == 0 && direction == PositionalDirection.VERTICAL)
            {
                inStackElementPosition = startPosition.Height;
                drawer.Draw(texture, startPosition, Color.White);
            }

            if (i > 0 && direction == PositionalDirection.HORIZONTAL)
            {
                inStackElementPosition += inStackElementPosition;

                inStackElementCoords = new Vector2(inStackElementPosition, startPosition.Y);

                drawer.Draw(texture, U.rect(inStackElementCoords), Color.White);
            }

            if (i > 0 && direction == PositionalDirection.VERTICAL)
            {
                inStackElementPosition += inStackElementPosition;

                inStackElementCoords = new Vector2(startPosition.X, inStackElementPosition);

                drawer.Draw(texture, U.rect(inStackElementCoords), Color.White);


            }
        }
    }

}