using System;

namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This class is used to decouple the console readline from the application.
    /// It implements an interface used for unit and mock testing.
    /// </summary>
    public class ConsoleReader : IConsoleReader
    {
        public string readConsole()
        {
            return Console.ReadLine();
        }
    }
}
