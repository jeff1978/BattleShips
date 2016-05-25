using BattleShips.BattleGround;
using BattleShips.Properties;
using System;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This is a list of validation methods used to check user input during game play.
    /// </summary>
    public class GamePlayParser : IGamePlayParser
    {
        public IConsoleReader ThisReader { get; set; }
        private Position firePosition { get; set; }
        private bool isValidInput { get; set; }

        public GamePlayParser(IConsoleReader thisReader)
        {
            ThisReader = thisReader;
            isValidInput = false;
        }

        public Position FireCommand()
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
            return firePosition;
        }

        private string[] splitUserInput(string userInput)
        {
            isValidInput = true;
            int validItem;
            string[] stringSplits = userInput.Split(',');
            foreach (var splitItem in stringSplits)
            {
                // try parsing each split part
                bool result = int.TryParse(splitItem, out validItem);
                if (result == false || int.Parse(splitItem) < 0 || stringSplits.Length != 2) { isValidInput = false; }
            }
            return stringSplits;
        }

        private void processInput(string[] stringSplits)
        {
            if (isValidInput == false){ Console.WriteLine(Resources.fireErrorMessage); }
            else
            {
                firePosition = new Position(int.Parse(stringSplits[0]), int.Parse(stringSplits[1]));
            }
        }
    }
}