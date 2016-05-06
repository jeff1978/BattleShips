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

        public void GetUserInput(RequestType thisRequest)
        {
            var thisPlayerSetup = new PlayerSetupValidation();
            switch (thisRequest)
            {
                case RequestType.SetPlayerName:
                    playerName = thisPlayerSetup.SetPlayerName();
                    break;
                case RequestType.PlaceNewShip:
                    newShipPlaceString = thisPlayerSetup.PlaceNewShip();
                    break;
                default:
                    throw new ArgumentException("The input cannot be processed. No method implementation has been found for your request.");
            }
        }
    }
}
