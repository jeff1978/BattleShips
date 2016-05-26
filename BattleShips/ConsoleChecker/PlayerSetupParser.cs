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
        private string playerName { get; set; }

        public PlayerSetupParser(IConsoleReader thisReader)
        {
            ThisReader = thisReader;
            playerName = string.Empty;
            isValidInput = false;
        }

        public string SetPlayerName()
        {
            while (isValidInput == false)
            {
                // get user input, validate and process it.
                processUserInput();
            }
            // reset the property
            isValidInput = false;
            return playerName;
        }

        private void processUserInput()
        {
            isValidInput = true;
            string userInput = ThisReader.ReadConsole();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine(Resources.getNameErrorMessage);
                isValidInput = false;
            }
            else { playerName = userInput; }
        }

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
                if (dimensions.Length != 3 || !(dimensions[2] == "h" || dimensions[2] == "v") || int.TryParse(dimensions[1],
                    out y)==false || int.TryParse(dimensions[0], out x)==false)
                {
                    isValid = false;
                }

                if (isValid == false){ 
                    Console.WriteLine(Resources.getPlaceErrorMessage);
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
    }
}