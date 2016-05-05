using BattleShips.BattleGround;
using BattleShips.Setup;
using BattleShips.BShip;
using System;
using System.Collections.Generic;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This class is used to process the console readline requests during player setup.The class
    /// implements an interface which is used for the unit tests.
    /// </summary>
    public class PlayerSetupParser
    {
        public string playerName { get; set; }
        public string newShipPlaceString { get; set; }

        public void getUserInput(RequestType thisRequest)
        {
            var thisPlayerSetup = new PlayerSetupValidation();
            switch (thisRequest)
            {
                case RequestType.SetPlayerName:
                    playerName = thisPlayerSetup.setPlayerName();
                    break;
                case RequestType.PlaceNewShip:
                    newShipPlaceString = thisPlayerSetup.placeNewShip();
                    break;
                default:
                    throw new ArgumentException("The input cannot be processed. No method implementation has been found for your request.");
            }
        }
    }
}
