using System.Collections.Generic;
using BattleShips.ConsoleChecker;
using System;
using BattleShips.Setup;
using BattleShips.BattleGround;
using BattleShips.Ship;

namespace BattleShipsTests
{

    /// <summary>
    /// This class mocks the console inputs. It inplements the IInputParser interface
    /// </summary>
    public class MockSetupDefault : IInputParser
    {
        // add appropriate props and methods for interface
        public int noOfPlayers { get; set; }
        public int noOfShips { get; set; }
        public GameMode gameMode { get; set; }
        public Sea seaSize { get; set; }
        public List<ShipTypeInGame> listOfShipTypes { get; set; }

        public void getUserInput(RequestType thisRequest)
        {
            switch (thisRequest)
            {
                case RequestType.SetNoOfPlayers:
                    noOfPlayers = 3;
                    break;
                case RequestType.SetNoOfShips:
                    // not needed for this test.
                    break;
                case RequestType.SelectGameMode:
                    gameMode = GameMode.Default;
                    break;
                case RequestType.SetSeaSize:
                    seaSize = new Sea(6, 7);
                    break;
                default:
                    throw new ArgumentException("The input cannot be processed. No method implementation has been found for your request.");
            }
        }
    }
}