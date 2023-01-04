using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Snake.Input;


public class InputProfile
{

    public Dictionary<string, Keys> proifle { get; set; }
    public InputProfile()
    {


        proifle = new Dictionary<string, Keys>()
        {
{"Exit", Keys.Escape}
        };



    }
}