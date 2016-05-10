using System;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This is a list of validation methods used to check user input during player setup. Read line operations are repeated
    /// until valid input is obtained. A count is used to submit default values or null after 10 unsuccesful attempts.
    /// </summary>
    public class PlayerSetupValidation
    {
        public IConsoleReader ThisReader { get; set; }

        #region constructors
        /// <summary>
        /// Overloaded constructor used for game and unit testing.
        /// </summary>
        /// <param name="thisReader"></param>
        public PlayerSetupValidation(IConsoleReader thisReader)
        {
            ThisReader = thisReader;
        }
        public PlayerSetupValidation()
        {
            IConsoleReader anyReader = new ConsoleReader();
            ThisReader = anyReader;
        }
        #endregion

        /// <summary>
        /// Get a string that is not null or whitespace
        /// Give the user ten goes then submit a default name
        /// </summary>
        /// <returns></returns>
        public string SetPlayerName()
        {
            int count = 0;
            while (count < 10)
            {
                string input = ThisReader.ReadConsole();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(@"   Enter a valid name. Name must not be white
            space or null. Try again.");
                    count++;
                }
                else
                {
                    return input;
                }
            }
            return "Unknown";
        }

        /// <summary>
        /// Get a position and orientation in the format x,y,z where z is either h or v
        /// Give the user ten goes then submit a default.
        /// </summary>
        /// <returns></returns>
        public string PlaceNewShip()
        {
            bool isValid = true;
            int count = 0;
            while (count < 10)
            {
                int x;
                int y;
                string input = ThisReader.ReadConsole();
                string[] dimensions = input.Split(',');
                // now look for any invalid part
                if (dimensions.Length != 3 || !(dimensions[2] == "h" || dimensions[2] == "v") || int.TryParse(dimensions[1], out y)==false || int.TryParse(dimensions[0], out x)==false)
                {
                    isValid = false;
                }

                if (isValid == false){ 
                    Console.WriteLine(@"   The command was not recognised. Ensure that the format is correct
   eg. 4,5,v  or  5,2,h  Enter the coordinates and direction for the ship.");
                    count++;
                    isValid = true;
                }
                else
                {
                    return input;
                }             
             }
            return "-1,-1,v";
        }

        /// <summary>
        /// Get a coordinate from the user in the format x,y Give the user ten goes then submit a default.
        /// </summary>
        /// <returns></returns>
        public string FireCommand()
        {
            bool isValidCommand = true;
            int count = 0;
            while (count < 10)
            {
                int x;
                int y;
                string input = ThisReader.ReadConsole();
                string[] dimensions = input.Split(',');
                // now look for any invalid part
                isValidCommand = int.TryParse(dimensions[0], out x);
                isValidCommand = int.TryParse(dimensions[1], out y);
                if (dimensions.Length != 2)
                {
                    isValidCommand = false;
                }
                if (isValidCommand == false)
                {
                    Console.WriteLine(@"   The command was not recognised. Ensure that the format is correct
   eg. 4,5  or  5,2  Enter coordinates to fire your missile.");
                    count++;
                }
                else
                {
                    return input;
                }
            }
            return "0,0";
        }
    }
}