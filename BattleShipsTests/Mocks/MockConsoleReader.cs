namespace BattleShips.ConsoleChecker
{
    public class MockConsoleReader : IConsoleReader
    {
        private string Input { get; set; }

        public MockConsoleReader(string input)
        {
            Input = input;
        }
        public string ReadConsole()
        {
            return Input;
        }
    }
}
