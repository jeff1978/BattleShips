using System.Collections.Generic;
using BattleShips.ConsoleChecker;
using System;

namespace BattleShipsTests
{

    /// <summary>
    /// This class mocks the console inputs
    /// It inplements the IInputParser interface
    /// Its constructor takes the game inputs
    /// </summary>
    public class InputMock : IInputParser
    {
        // add appropriate props and methods for interface
        public int noOfPlayers { get; set; }
        public int noOfShips { get; set; }

        private int testVariables;
        private string stringVariables;

        // add a constructor to take the test input
        public InputMock(int TestVariables, string StringVariables)
        {
            testVariables = TestVariables;
            stringVariables = StringVariables;
        }

        public void getUserInput(RequestType thisRequest)
        {
            switch (thisRequest)
            {
                case RequestType.SetNoOfPlayers:
                    noOfPlayers = 3;
                    break;
                case RequestType.SetNoOfShips:
                    noOfShips = 3;
                    break;
                default:
                    throw new ArgumentException("The input cannot be processed. No method implementation has been found for your request.");
            }
        }
    }
}