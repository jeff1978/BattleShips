using BattleShips.BattleGround;
using BattleShips.Setup;
using System;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This is a list of validation methods used to check user input
    /// and repeat read line operations until valid input is obtained.
    /// </summary>
    public static class GameSetupValidation
    {
        /// <summary>
        /// Get an int equal or greater than two and repeat request until valid entry
        /// </summary>
        /// <returns></returns>
        public static int setNoOfPlayers()
        {
            int noOfPlayers;
            while (true)
            {
                string input = Console.ReadLine();
                bool result = int.TryParse(input, out noOfPlayers);
                if (result == false || int.Parse(input) < 2)
                {
                    Console.WriteLine(@"   Please enter a valid number. Two or more players
   are required for this game.");
                }
                else { return noOfPlayers; }
            }
        }

        /// <summary>
        /// Get an int equal or greater than zero and repeat request until valid entry
        /// </summary>
        /// <returns></returns>
        public static int setNoOfShips()
        {
            int noOfShips;
            while (true)
            {
                string input = Console.ReadLine();
                bool result = int.TryParse(input, out noOfShips);
                if (result == false || int.Parse(input) < 0)
                {
                    Console.WriteLine(@"   The number you entered was not recognised. If no ships of this
   kind are required then type 0");
                }
                else { return noOfShips; }
            }
        }

        /// <summary>
        /// Get int of range in GameMode enum list
        /// </summary>
        /// <returns></returns>
        public static GameMode selectGameMode()
        {
            GameMode chosenMode;
            var gameModeEnum = Enum.GetValues(typeof(GameMode)).Length;
            int modeEntered;
            while (true)
            {
                string input = Console.ReadLine();
                bool result = int.TryParse(input, out modeEntered);
                if (result == false || int.Parse(input) < 0 || int.Parse(input) > gameModeEnum - 1)
                {
                    Console.WriteLine(@"   The mode you entered was not recognised. Try again using
   a valid number for your game mode.");
                }
                else {
                    // cast the int to its enum
                    GameMode thisModeAsEnum = (GameMode)modeEntered;
                    chosenMode = thisModeAsEnum;
                    return chosenMode; }
            }
        }

        /// <summary>
        /// Get string input in the format a,b where a and b are greater than 4.
        /// </summary>
        /// <returns></returns>
        public static Sea setSeaSize()
        {
            while (true)
            {
                bool isValid = true;
                int validItem;
                string input = Console.ReadLine();
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
                }
                else
                {
                    return new Sea(int.Parse(dimensions[0]), int.Parse(dimensions[1]));
                }             
             }
        }
    }
}