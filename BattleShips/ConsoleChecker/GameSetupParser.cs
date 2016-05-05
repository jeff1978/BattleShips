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

        public void getUserInput(RequestType thisRequest)
        {
            var thisSetup = new GameSetupValidation();
            switch (thisRequest)
            {
                case RequestType.SetNoOfPlayers:
                    noOfPlayers = thisSetup.setNoOfPlayers();
                    break;
                case RequestType.SetNoOfShips:
                    noOfShips = thisSetup.setNoOfShips();
                    break;
                case RequestType.SelectGameMode:
                    gameMode = thisSetup.selectGameMode();
                    break;
                case RequestType.SetSeaSize:
                    seaSize = thisSetup.setSeaSize();
                    break;
                default:
                    throw new ArgumentException("The input cannot be processed. No method implementation has been found for your request.");
            }
        }
    }
}
