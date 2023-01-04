using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Snake.Input;
public class PlayerInput
{
    public Dictionary<string, Keys> playerInputProfile { get; set; }
    public PlayerInput()
    {
        playerInputProfile = new Dictionary<string, Keys>() {
            {"MoveUp", Keys.W},
            {"MoveDown", Keys.S},
            {"MoveLeft", Keys.A},
            {"MoveRight", Keys.D},



        };


    }
}