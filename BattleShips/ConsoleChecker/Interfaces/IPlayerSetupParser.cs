namespace BattleShips.ConsoleChecker
{
    public interface IPlayerSetupParser
    {
        string newShipPlaceString { get; set; }
        string playerName { get; set; }

        void GetUserInput(RequestType thisRequest);
    }
}