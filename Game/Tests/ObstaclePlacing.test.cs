
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Snake.Structs.Enums;

namespace Snake.Tests;

public class ObstaclePlacingTest : Test
{

    public ObstaclePlacingTest() : base() { }
    public static void Test(World world, Rectangle startPosition, PositionalDirection direction)
    {
        Random r = new Random();



        int testPosition = startPosition.Right;

        for (int i = 0; i <= 5; ++i)
        {
            Console.WriteLine($"Before {i}: {testPosition}");
            testPosition += testPosition;
            Console.WriteLine($"After {i}: {testPosition}");

            Console.WriteLine($"Direction: {direction}");




        }



    }




}
