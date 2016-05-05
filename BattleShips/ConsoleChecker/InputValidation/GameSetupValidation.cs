using BattleShips.BattleGround;
using BattleShips.Setup;
using System;
namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This is a list of validation methods used to check user input during game setup. Read line operations are repeated
    /// until valid input is obtained. A count is used to submit default values after 10 unsuccesful attempts.
    /// </summary>
    public class GameSetupValidation
    {
        public IConsoleReader ThisReader { get; set; }

        #region constructors
        /// <summary>
        /// Overloaded constructor used for game and unit testing.
        /// </summary>
        /// <param name="thisReader"></param>
        public GameSetupValidation(IConsoleReader thisReader)
        {
            ThisReader = thisReader;
        }
        public GameSetupValidation()
        {
            IConsoleReader anyReader = new ConsoleReader();
            ThisReader = anyReader;
        }
        #endregion

        /// <summary>
        /// Get an int equal or greater than two and repeat request until valid entry.
        /// Give the user ten goes then submit a default.
        /// </summary>
        /// <returns></returns>
        public int setNoOfPlayers()
        {
            int noOfPlayers;
            int count = 0;
            while (count < 10)
            {
                string input = ThisReader.readConsole();
                bool result = int.TryParse(input, out noOfPlayers);
                if (result == false || int.Parse(input) < 2)
                {
                    Console.WriteLine(@"   Enter a valid number. Two or more players
            are required for this game.");
                    count++;
                }
                else { return noOfPlayers; }
            }
            return 2;
        }

        /// <summary>
        /// Get an int equal or greater than zero and repeat request until valid entry
        /// Give the user ten goes then submit a default.
        /// </summary>
        /// <returns></returns>
        public int setNoOfShips()
        {
            int noOfShips;
            int count = 1;
            while (count < 10)
            {
                string input = ThisReader.readConsole();
                bool result = int.TryParse(input, out noOfShips);
                if (result == false || int.Parse(input) < 0)
                {
                    Console.WriteLine(@"   The number you entered was not recognised. If ships of this
   kind are not required then type 0");
                    count++;
                }
                else { return noOfShips; }
            }
            return 1;
        }

        /// <summary>
        /// Get int of range in GameMode enum list. Give the user ten goes then submit a default.
        /// </summary>
        /// <returns></returns>
        public GameMode selectGameMode()
        {
            GameMode chosenMode;
            var gameModeEnum = Enum.GetValues(typeof(GameMode)).Length;
            int modeEntered;
            int count = 0;
            while (count < 10)
            {
                string input = ThisReader.readConsole();
                bool result = int.TryParse(input, out modeEntered);
                if (result == false || int.Parse(input) < 0 || int.Parse(input) > gameModeEnum - 1)
                {
                    Console.WriteLine(@"   The mode you entered was not recognised. Try again using
   a valid number for your game mode.");
                    count++;
                }
                else {
                    // cast the int to its enum
                    GameMode thisModeAsEnum = (GameMode)modeEntered;
                    chosenMode = thisModeAsEnum;
                    return chosenMode; }
            }
            return GameMode.Default;
        }

        /// <summary>
        /// Get string input in the format a,b where a and b are greater than 4.
        /// Give the user ten goes then submit a default.
        /// </summary>
        /// <returns></returns>
        public Sea setSeaSize()
        {
            int count = 0;
            while (count  < 10)
            {
                bool isValid = true;
                int validItem;
                string input = ThisReader.readConsole();
                string[] dimensions = input.Split(',');
                foreach (var item in dimensions)
                {
                    bool result = int.TryParse(item, out validItem);
                    if (result == false || int.Parse(item) < 5 || dimensions.Length!=2)
                    {
                        isValid = false;
                    }
                }
                if (!isValid)
                {
                    Console.WriteLine(@"   The sea dimensions given were not valid. Ensure that the format is correct
   and that the minimum size is 5,5. Enter the sea dimensions.");
                    count++;
                }
                else
                {
                    return new Sea(int.Parse(dimensions[0]), int.Parse(dimensions[1]));
                }             
             }
            return new Sea(5, 5);
        }
    }
}