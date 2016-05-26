using BattleShips.BattleGround;
using BattleShips.Properties;
using BattleShips.Setup;
using System;
namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This is a list of validation methods used to check user input during game setup. Read line operations are repeated
    /// until valid input is obtained. A count is used to submit default values after 10 unsuccesful attempts.
    /// </summary>
    public class GameSetupParser : IGameSetupParser
    {
        public IConsoleReader ThisReader { get; set; }

        public GameSetupParser(IConsoleReader thisReader)
        {
            ThisReader = thisReader;
        }

        public int SetNumberOfPlayers()
        {
            int noOfPlayers;
            int count = 0;
            while (count < 10)
            {
                string input = ThisReader.ReadConsole();
                bool result = int.TryParse(input, out noOfPlayers);
                if (result == false || int.Parse(input) < 2)
                {
                    Console.WriteLine(Resources.getPlayerNoErrorMessage);
                    count++;
                }
                else { return noOfPlayers; }
            }
            return 2;
        }

        /// <summary>
        /// This method gets the user to type in an integer for the number of ships and then validates it
        /// before returning it.
        /// Get an int equal or greater than zero and repeat request until valid entry
        /// Give the user ten goes then submit a default.
        /// </summary>
        /// <returns></returns>
        public int SetNumberOfShips()
        {
            int noOfShips;
            int count = 1;
            while (count < 10)
            {
                string input = ThisReader.ReadConsole();
                bool result = int.TryParse(input, out noOfShips);
                if (result == false || int.Parse(input) < 0)
                {
                    Console.WriteLine(Resources.getShipNoErrorMessage);
                    count++;
                }
                else { return noOfShips; }
            }
            return 1;
        }

        /// <summary>
        /// This method gets the user to type in an integer for the game mode and then validates it
        /// before returning it as a GameMode object.
        /// Get int of range in GameMode enum list. Give the user ten goes then submit a default.
        /// </summary>
        /// <returns></returns>
        public GameMode SelectGameMode()
        {
            GameMode chosenMode;
            var gameModeEnum = Enum.GetValues(typeof(GameMode)).Length;
            int modeEntered;
            int count = 0;
            while (count < 10)
            {
                string input = ThisReader.ReadConsole();
                bool result = int.TryParse(input, out modeEntered);
                if (result == false || int.Parse(input) < 0 || int.Parse(input) > gameModeEnum - 1)
                {
                    Console.WriteLine(Resources.getModeErrorMessage);
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
        /// This method gets the user to type in a string for the sea size and then validates it.
        /// before returning it as a Sea object.
        /// Get string input in the format a,b where a and b are greater than 4.
        /// Give the user ten goes then submit a default.
        /// </summary>
        /// <returns></returns>
        public Sea SetSeaSize()
        {
            int count = 0;
            while (count  < 10)
            {
                bool isValid = true;
                int validItem;
                string input = ThisReader.ReadConsole();
                string[] dimensions = input.Split(',');
                foreach (var item in dimensions)
                {
                    bool result = int.TryParse(item, out validItem);
                    if (result == false || int.Parse(item) < 5 || dimensions.Length!=2)
                    {
                        isValid = false;
                    }
                }
                if (isValid == false)
                {
                    Console.WriteLine(Resources.getSeaErrorMessage);
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