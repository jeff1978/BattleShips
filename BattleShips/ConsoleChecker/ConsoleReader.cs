using System;

namespace BattleShips.ConsoleChecker
{
    public class ConsoleReader : IConsoleReader
    {
        public string readConsole()
        {
            return Console.ReadLine();
        }
    }
}
