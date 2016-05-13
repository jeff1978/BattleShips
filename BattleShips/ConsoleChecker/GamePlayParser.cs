using BattleShips.BattleGround;
using BattleShips.Setup;
using BattleShips.BShip;
using System;
using System.Collections.Generic;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This class is used to process the console readline requests during game play.The class
    /// doesn't contain much but has been left this way for future development.
    /// </summary>
    public class GamePlayParser : IGamePlayParser
    {
        public Position fireCoordinate { get; set; }

        public void GetUserInput(RequestType thisRequest)
        {
            var thisPlayerSetup = new GamePlayValidation();
            switch (thisRequest)
            {
                case RequestType.SetFireCommand:
                    fireCoordinate = thisPlayerSetup.FireCommand();
                    break;
                default:
                    throw new ArgumentException(GamePlayMessages.noMethodErrorMessage);
            }
        }
    }
}
