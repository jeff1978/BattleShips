using BattleShips.BattleGround;
using BattleShips.Properties;
using BattleShips.Setup;
using System;
namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This is a list of validation methods used to check user input during game setup.
    /// </summary>
    public class GameSetupParser : IGameSetupParser
    {
        public IConsoleReader ThisReader { get; set; }
        private int operationResult { get; set; }
        private int minimumValue { get; set; }
        private string errorMsg { get; set; }
        public bool isValidInput { get; set; }

        public GameSetupParser(IConsoleReader thisReader)
        {
            ThisReader = thisReader;
            isValidInput = false;
        }

        public int SetNumberOfPlayers()
        {
            GetUserInt(MinimumValue: 2, ErrorMsg: Resources.getPlayerNoErrorMessage);
            return operationResult;
        }

        public int SetNumberOfShips()
        {
            GetUserInt(MinimumValue: 0, ErrorMsg: Resources.getShipNoErrorMessage);
            return operationResult;
        }

        private void GetUserInt(int MinimumValue, string ErrorMsg)
        {
            minimumValue = MinimumValue;
            errorMsg = ErrorMsg;
            while (isValidInput == false)
            {
                isValidInput = true;
                int validItem;
                string input = ThisReader.ReadConsole();
                isValidInput = int.TryParse(input, out validItem);
                processUserInt(validItem, input);
            }
            isValidInput = false;
        }

        private void processUserInt(int validItem, string input)
        {
            if (isValidInput == false || int.Parse(input) < minimumValue)
            {
                Console.WriteLine(errorMsg);
                isValidInput = false;
            }
            else { operationResult = validItem; }
        }

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