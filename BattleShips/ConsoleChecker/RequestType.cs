namespace BattleShips.ConsoleChecker
{
    /// <summary>
    /// This is an important list of enums used to validate/error handle the console.readline operations.
    /// </summary>
    public enum RequestType
    {
        SetSeaSize,
        SetNoOfPlayers,
        SelectGameMode,
        SetNoOfShips,
        SetPlayerName,
        PlaceNewShip,
        Leave,
        Exit
    }
}
