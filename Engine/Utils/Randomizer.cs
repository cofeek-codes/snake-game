

using System;

namespace Engine.Utils;

public class Randomizer
{
    public int[] values;

    public static int Randomize(int minValue, int maxValue)
    {
        Random r = new Random();

        return r.Next(minValue, maxValue);
    }
}