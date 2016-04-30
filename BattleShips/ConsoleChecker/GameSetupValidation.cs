using System;

namespace BattleShips.ConsoleChecker
{
    public static class GameSetupValidation
    {
        public static int setNoOfPlayers()
        {
            return int.Parse(Console.ReadLine());
        }

        public static int SetNoOfShips()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
