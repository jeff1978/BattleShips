using System;

namespace BattleShips.ConsoleChecker
{
    public static class GameSetupValidation
    {
        public static int setNoOfPlayers()
        {
            int X = 0;
            bool result = false;
            while (result == false)
            {
                string input = Console.ReadLine();
                result = int.TryParse(input, out X);
                if (result == false)// || int.Parse(input) < 2)
                {
                    Console.WriteLine(@"   Please enter a valid number. Two or more players
   are required for this game.");
                }
                else
                {
                    return X;
                }
                
            }
            break;
        }

        public static int SetNoOfShips()
        {
            int X;
            String Result = Console.ReadLine();
            while (!int.TryParse(Result, out X))
            {
                Console.WriteLine(@"   Please enter a valid number. If you don't want
   any ships of this kind then enter 0.");
                Result = Console.ReadLine();
            }
            return X;
        }
    }
}

