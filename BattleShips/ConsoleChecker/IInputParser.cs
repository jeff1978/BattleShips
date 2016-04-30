namespace BattleShips.ConsoleChecker
{
    public interface IInputParser
    {
        int noOfPlayers { get; set; }
        int noOfShips { get; set; }

        void getUserInput(RequestType thisRequest);
    }
}