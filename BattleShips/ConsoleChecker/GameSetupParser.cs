using BattleShips.BattleGround;
using BattleShips.Setup;
using BattleShips.BShip;
using System;
using System.Collections.Generic;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This class is used to process the console readline requests during game setup.The class
    /// implements an interface which is used for the unit tests.
    /// </summary>
    public class GameSetupParser : IGameSetupParser
    {
        public int noOfPlayers { get; set; }
        public int noOfShips { get; set; }
        public GameMode gameMode { get; set; }
        public Sea seaSize { get; set; }
        public List<ShipTypeInGame> listOfShipTypes { get; set; }

        public void GetUserInput(RequestType thisRequest)
        {
            var thisSetup = new GameSetupValidation();
            switch (thisRequest)
            {
                case RequestType.SetNoOfPlayers:
                    noOfPlayers = thisSetup.SetNumberOfPlayers();
                    break;
                case RequestType.SetNoOfShips:
                    noOfShips = thisSetup.SetNumberOfShips();
                    break;
                case RequestType.SelectGameMode:
                    gameMode = thisSetup.SelectGameMode();
                    break;
                case RequestType.SetSeaSize:
                    seaSize = thisSetup.SetSeaSize();
                    break;
                default:
                    throw new ArgumentException(GameSetupMessages.noMethodErrorMessage);
            }
        }
    }
}
