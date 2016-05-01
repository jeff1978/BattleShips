using BattleShips.BattleGround;
using BattleShips.Setup;
using System;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This is a looooooong list of validation methods used to check user input
    /// and repeat read line operations
    /// until valid input is obtained.
    /// </summary>
    public static class GameSetupValidation
    {
        /// <summary>
        /// Get an int equal or greater than two and repeat request until valid entry
        /// </summary>
        /// <returns></returns>
        public static int setNoOfPlayers()
        {
            int X = 0;
            bool result = false;
            while (X < 2)
            {
                string input = Console.ReadLine();
                result = int.TryParse(input, out X);
                if (result == false || int.Parse(input) < 2)
                {
                    Console.WriteLine(@"   Please enter a valid number. Two or more players
   are required for this game.");
                }            
            }
            return X;
        }

        /// <summary>
        /// Get an int equal or greater than zero and repeat request until valid entry
        /// </summary>
        /// <returns></returns>
        public static int setNoOfShips()
        {
            int X = -1;
            bool result = false;
            while (X < 0)
            {
                string input = Console.ReadLine();
                result = int.TryParse(input, out X);
                if (result == false || int.Parse(input) < 0)
                {
                    Console.WriteLine(@"   Please enter a valid number. If you don't want
   any ships of this kind then enter 0.");
                }
            }
            return X;
        }

        /// <summary>
        /// Get int of range in GameMode enum list
        /// </summary>
        /// <returns></returns>
        public static GameMode selectGameMode()
        {
            //         var enumLength = Enum.GetNames(typeof(GameMode)).Length;
            //         GameMode modes;
            //         int X = -1;
            //         bool result = false;
            //         while (X > enumLength - 1 && X < 0)
            //         {
            //             string input = Console.ReadLine();
            //             result = Enum.TryParse(input, out modes);
            //             if (int.Parse((input)) > enumLength - 1 && int.Parse(input) < 0)
            //             {
            //                 Console.WriteLine(@"   Please enter a valid mode number between 0
            //and {0}", enumLength - 1);
            //             }
            //         }
            //         return (GameMode)X;
            string input = Console.ReadLine();
            return GameMode.Custom;
        }

        /// <summary>
        /// Get string input in the format a,b where a and b are greater than 4.
        /// </summary>
        /// <returns></returns>
        public static Sea setSeaSize()
        {
            //         Sea sea = new Sea(0,0);
            int x = 0;
            int y = 0;
            string input = Console.ReadLine();
            string[] dimensions = input.Split(',');
            x = int.Parse(dimensions[0]);
            y = int.Parse(dimensions[1]);
            //         bool result = false;
            //         while (x < 5 && y < 5)
            //         {
            //             string input = Console.ReadLine();
            //             var commandParams = input[1].Split(',');
            //             result = int.TryParse(input, out X);
            //             if (int.Parse(input) < 2)
            //             {
            //                 Console.WriteLine(@"   Please enter a valid format and ensure that the
            //the sea size is 5 x 5 or greater eg. 6,7");
            //             }
            //         }
            //         return X;
            return new Sea(x, y);
        }
    }
}