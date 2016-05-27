namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This class is used to mock the console read class.
    /// an input parameter can be passed to its method.
    /// </summary>
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
