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
        public int minimumValue { get; set; }
        public string errorMsg { get; set; }
        public bool isValidInput { get; set; }
        private GameMode thisGameMode { get; set; }
        private Sea thisSea { get; set; }

        public GameSetupParser(IConsoleReader thisReader)
        {
            ThisReader = thisReader;
            isValidInput = false;
        }

        public int SetNumberOfPlayers()
        {
            GetUserInt(MinimumValue: 2, ErrorMsg: Resources.getPlayerNoErrorMessage);
            Console.WriteLine(Resources.playerNoSetConfirmation, operationResult);
            return operationResult;
        }

        public int SetNumberOfShips()
        {
            GetUserInt(MinimumValue: 0, ErrorMsg: Resources.getShipNoErrorMessage);
            Console.WriteLine(Resources.shipNoSetConfirmation, operationResult);
            return operationResult;
        }

        private void GetUserInt(int MinimumValue, string ErrorMsg)
        {
            minimumValue = MinimumValue;
            errorMsg = ErrorMsg;
            while (isValidInput == false)
            {
                processUserInt();
            }
            isValidInput = false;
        }

        public void processUserInt()
        {
            isValidInput = true;
            int validItem;
            string input = ThisReader.ReadConsole();
            isValidInput = int.TryParse(input, out validItem);
            if (isValidInput == false || int.Parse(input) < minimumValue)
            {
                Console.WriteLine(errorMsg);
                isValidInput = false;
            }
            else { operationResult = validItem; }
        }

        public GameMode SelectGameMode()
        {
            var gameModeEnumLength = Enum.GetValues(typeof(GameMode)).Length;
            while (isValidInput == false)
            {
                // the the user mode int, validate and process it.
                processUserModeInput(gameModeEnumLength);
            }
            isValidInput = false;
            return thisGameMode;
        }

        public void processUserModeInput(int gameModeEnumLength)
        {
            int modeEntered;
            string userInput = ThisReader.ReadConsole();
            bool result = int.TryParse(userInput, out modeEntered);
            if (result == false || int.Parse(userInput) < 0 || int.Parse(userInput) > gameModeEnumLength - 1)
            {
                Console.WriteLine(Resources.getModeErrorMessage);
                isValidInput = false;
            }
            else
            {
                isValidInput = true;
                // cast the int to its enum
                thisGameMode = (GameMode)modeEntered;
                Console.WriteLine(Resources.modeSetConfirmation, thisGameMode);
            }
        }

        public Sea SetSeaSize()
        {
            while (isValidInput == false)
            {
                // split the user input and validate it
                string[] stringSplits = splitUserInput(ThisReader.ReadConsole());
                // process the strings and act on the result
                processInput(stringSplits);
            }
            // reset the property
            isValidInput = false;
            return thisSea;
        }

        public string[] splitUserInput(string userInput)
        {
            isValidInput = true;
            int validItem;
            string[] stringSplits = userInput.Split(',');
            foreach (var splitItem in stringSplits)
            {
                // try parsing each split part
                bool result = int.TryParse(splitItem, out validItem);
                if (result == false || int.Parse(splitItem) < 5 || stringSplits.Length != 2)
                { isValidInput = false; }
            }
            return stringSplits;
        }

        private void processInput(string[] stringSplits)
        {
            if (isValidInput == false) { Console.WriteLine(Resources.getSeaErrorMessage); }
            else
            {
                thisSea = new Sea(int.Parse(stringSplits[0]), int.Parse(stringSplits[1]));
                Console.WriteLine(Resources.seaSetConfirmation, stringSplits[0], stringSplits[1]);
            }
        }
    }
}