using BattleShips.Ship;
using System;
using System.Collections.Generic;

namespace BattleShips.Setup
{
    /// <summary>
    /// This class is used to implement the methods 
    /// for user inputs during game setup.
    /// </summary>
    public static class GameInput
    {
        public static List<ShipTypeInGame> getSettings(GameMode gameMode)
        {
            switch (gameMode)
            {
                case GameMode.Default:
                    return GameDefault.setDefaults();              
                case GameMode.Custom:
                    return GameCustom.setCustom();                  
                 //   more cases can be added here in the future
                 //   eg.a new game mode.
                default:
                    Console.WriteLine("The game cannot be initialised. No method implementation has been found for your selection.");
                    Console.ReadLine();
                    break;
            }
            return GameDefault.setDefaults();
        }
    }
}
