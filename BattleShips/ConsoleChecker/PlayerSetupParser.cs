using BattleShips.Properties;
using System;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This is a list of validation methods used to check user input during player setup.
    /// </summary>
    public class PlayerSetupParser : IPlayerSetupParser
    {
        public IConsoleReader ThisReader { get; set; }
        public bool isValidInput { get; set; }
        private string operationResult { get; set; }

        public PlayerSetupParser(IConsoleReader thisReader)
        {
            ThisReader = thisReader;
            operationResult = string.Empty;
            isValidInput = false;
        }

        public string SetPlayerName()
        {
            while (isValidInput == false)
            {
                // get user input, validate and process it.
                processUserNameInput();
            }
            // reset the property
            isValidInput = false;
            return operationResult;
        }

        public void processUserNameInput()
        {
            isValidInput = true;
            string userInput = ThisReader.ReadConsole();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine(Resources.getNameErrorMessage);
                isValidInput = false;
            }
            else
            {
                operationResult = userInput;
                Console.WriteLine(Resources.playerNameSetConfirmation);
            }
        }

        public string PlaceNewShip()
        {
            while (isValidInput == false)
            {
                // get the user input and validate it
                string userInput = ValidateUserShipInput(ThisReader.ReadConsole());
                // process the string and act on the result
                ValidateUserNameInput(userInput);
            }
            // reset the property
            isValidInput = false;
            return operationResult;
        }

        public void ValidateUserNameInput(string userInput)
        {
            if (isValidInput == false)
            { Console.WriteLine(Resources.getPlaceErrorMessage); }
            else
            {
                operationResult = userInput;
                Console.WriteLine(Resources.shipPositionsSetConfirmation);
            }
        }

        public string ValidateUserShipInput(string userInput)
        {
            // assume all is well
            isValidInput = true;
            int x;
            int y;
            string[] stringSplits = userInput.Split(',');
            // now look for any invalid part
            if (stringSplits.Length != 3 || !(stringSplits[2] == "h" || stringSplits[2] == "v") || int.TryParse(stringSplits[1],
                out y) == false || int.TryParse(stringSplits[0], out x) == false)
            {
                isValidInput = false;
            }
            return userInput;
        }
    }
}