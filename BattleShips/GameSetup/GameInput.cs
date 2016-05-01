using BattleShips.ConsoleChecker;
using BattleShips.Ship;
using System.Collections.Generic;

namespace BattleShips.Setup
{
    /// <summary>
    /// This class is used to call appropriate methods 
    /// for user inputs during game setup.
    /// </summary>
    public static class GameInput
    {
        public static List<ShipTypeInGame> getSettings(GameMode gameMode, IInputParser inputParser)
        {
            switch (gameMode)
            {
                case GameMode.Default:
                    return GameDefault.setDefaults();              
                case GameMode.Custom:
                    //var thisCustomGame = new GameCustom();
                    return GameCustom.setCustom(inputParser);

                //   more cases can be added here in the future
                //   eg.a new game mode. eg. single player vs computer AI.

                default:
                    return GameDefault.setDefaults();
            }
        }
    }
}
