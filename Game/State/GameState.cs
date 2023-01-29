using Engine.Utils.Checkers;
using Engine.Utils.Converters;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Snake.Entities;
using Snake.Score;
using Snake.Structs.Enums;
using Snake.UI;

using System;

namespace Snake.State;

public class GameState
{

    static private ApplicationState _state;
   
    public static ApplicationState GetCurrentState()
    {
        return _state;
    }
    public static void SetState(ApplicationState state)
    {
        _state = state;
    }

    public static void RunningDraw(Player player, SpriteBatch _spriteBatch, GameTime gameTime, Coin coin)
    {


        player.Spawn(_spriteBatch, gameTime);

    
        coin.InitialSpawn(_spriteBatch);


    }
    public static void RunningUpdate(Player player, GameTime gameTime, World world, Coin coin, SpriteBatch _spriteBatch, ScoreManager scoreManager)
    {
       



        player.Move(gameTime);

        if (OutOfBounds.Test(player, world))
        {
            player.position = RectangleConverter.VectorToRectangle(OutOfBounds.ByDirection(player, world, player.direction));
        }

        if (player.position.Intersects(coin.position) && coin.isCollected == false)
        {
            coin.Respawn(world, _spriteBatch);
            scoreManager.AddPoint();
            player.basicSpeed += 15f;


        }

    }

    public static void Pause()
    {

    }

public static void Menu()
{

}

}