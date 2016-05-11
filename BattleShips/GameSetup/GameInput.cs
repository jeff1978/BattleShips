using BattleShips.ConsoleChecker;
using BattleShips.BShip;
using System.Collections.Generic;

namespace BattleShips.Setup
{
    /// <summary>
    /// This class is used to call appropriate methods 
    /// for user inputs during game setup.
    /// </summary>
    public static class GameInput
    {
        public static List<ShipTypeInGame> GetSettings(GameMode gameMode, IGameSetupParser inputParser)
        {
            switch (gameMode)
            {
                case GameMode.Default:
                    return GameDefault.SetDefaults();              
                case GameMode.Custom:
                    return GameCustom.SetCustom(inputParser);

                //   more cases can be added here in the future
                //   eg.a new game mode. eg. single player vs computer AI.

                default:
                    return GameDefault.SetDefaults();
            }
        }
    }
}
