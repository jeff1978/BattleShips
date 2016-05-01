namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This is an important list of enums that are used to
    /// validate/error handle the console.readline operations.
    /// </summary>
    public enum RequestType
    {
        Place,
        Fire,
        SetSeaSize,
        SetNoOfPlayers,
        SelectGameMode,
        SetNoOfShips,
        Leave,
        Exit
    }
}
