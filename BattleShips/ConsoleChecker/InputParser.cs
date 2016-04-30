using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This class is used to process the console readline requests.
    /// The class implements an interface which is used for the unit tests.
    /// </summary>
    public class InputParser : IInputParser
    {
        public int noOfPlayers { get; set; }
        public int noOfShips { get; set; }

        public void getUserInput(RequestType thisRequest)
        {
            switch (thisRequest)
            {
                case RequestType.SetNoOfPlayers:
                    noOfPlayers = GameSetupValidation.setNoOfPlayers();
                    break;
                case RequestType.SetNoOfShips:
                    noOfShips = GameSetupValidation.SetNoOfShips();
                    break;
                default:
                    throw new ArgumentException("The input cannot be processed. No method implementation has been found for your request.");
            }
        }
    }
}
