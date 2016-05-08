namespace BattleShips
{
    /// <summary>
    /// This class stores all the console messages used during the game setup
    /// </summary>
    public static class PlayerSetupMessages
    {
        public const string welcomePlayers =
@"   Player setup....
";
        public const string getPlayerName =
@"   Enter your name. You must submit any value except spaces or null...: 
";
        public const string getPlacementCommand =
@"
   Ship placement.....
   Enter the coordinates and orientation for your ship e.g. 3,4,v or 7,2,h
   (Coordinates must lie in the bounds of the sea, and cannot overlap your other ships)
   Enter the command to place your ship...
";
    }
}
