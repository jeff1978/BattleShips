using BattleShips.BattleGround;
using System;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This is a list of validation methods used to check user input during game play. Read line operations are repeated
    /// until valid input is obtained. A count is used to submit default values or null after 10 unsuccesful attempts.
    /// </summary>
    public class GamePlayParser : IGamePlayParser
    {
        public IConsoleReader ThisReader { get; set; }

        #region constructors
        /// <summary>
        /// Overloaded constructor used for game and unit testing.
        /// </summary>
        /// <param name="thisReader"></param>
        public GamePlayParser(IConsoleReader thisReader)
        {
            ThisReader = thisReader;
        }
        public GamePlayParser()
        {
            IConsoleReader anyReader = new ConsoleReader();
            ThisReader = anyReader;
        }
        #endregion

        /// <summary>
        /// Get a coordinate from the user in the format x,y Give the user ten goes then submit a default.
        /// </summary>
        /// <returns></returns>
        public Position FireCommand()
        {
            int count = 0;
            while (count < 10)
            {
                bool isValid = true;
                int validItem;
                string input = ThisReader.ReadConsole();
                string[] dimensions = input.Split(',');
                foreach (var item in dimensions)
                {
                    bool result = int.TryParse(item, out validItem);
                    if (result == false || int.Parse(item) < 0 || dimensions.Length != 2)
                    {
                        isValid = false;
                    }
                }
                if (isValid == false)
                {
                    Console.WriteLine(GamePlayMessages.fireErrorMessage);
                    count++;
                }
                else
                {
                    return new Position(int.Parse(dimensions[0]), int.Parse(dimensions[1]));
                }
            }
            // else return this default
            return new Position(5, 5);
        }
    }
}