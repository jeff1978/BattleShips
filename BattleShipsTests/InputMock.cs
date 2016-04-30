using System.Collections.Generic;
using BattleShips.ConsoleChecker;
using System;

namespace BattleShipsTests
{

    public class InputMock : IInputParser
    {
        // add appropriate props and methods for interface
        public int noOfPlayers { get; set; }
        public int noOfShips { get; set; }

        private int testVariables;

        // add a constructor to take the test input
        public InputMock(int TestVariables)
        {
            testVariables = TestVariables;
        }

        public void getUserInput(RequestType thisRequest)
        {
            switch (thisRequest)
            {
                case RequestType.SetNoOfPlayers:
                    noOfPlayers = testVariables;
                    break;
                case RequestType.SetNoOfShips:
                    noOfShips = testVariables;
                    break;
                default:
                    throw new ArgumentException("The input cannot be processed. No method implementation has been found for your request.");
            }
        }
    }
}