namespace BattleShips
{
    /// <summary>
    /// This class stores all the console messages used during the player setup
    /// </summary>
    public static class PlayerSetupMessages
    {
        public const string playerSetupIntro =
@"   
   Player setup....
";
        public const string getPlayerName =
@"   Enter your name. You must submit any value except spaces or null...: 
";
        public const string getPlacementCommand =
@"
   Enter the coordinates and orientation for your ship
   e.g. 3,4,h or 7,2,v  Hint: All ship positions must lie
   in the bounds of the sea, and cannot overlap your
   other ships) Enter the command to place your ship...
";
        public const string placementErrorMessage = 
@"   Ship not added because at least one position is already
   occupied or lies outside the sea boundary.
   Enter the command to place your ship...
";
        public const string commandsRejectedErrorMessage =
@"   Too many incorrect placement commands were made.
   The ship was removed from your fleet.
";
        public const string shipTypeDetails =
@"   Ship to add: {0}, size {1}....
";
        public const string getNameErrorMessage =
@"   Enter a valid name. Name must not be white space or null. Try again.
";
        public const string getPlaceErrorMessage =
@"   The command was not recognised. Ensure that the format is correct
   eg. 4,5,v  or  5,2,h  Enter the coordinates and direction for the ship.
";
        public const string fireErrorMessage =
@"   The command was not recognised. Ensure that the format is correct
   eg. 4,5  or  5,2  Enter coordinates to fire your missile.
";
        public const string noMethodErrorMessage =
@"   The input cannot be processed. No method implementation has
   been found for the request.
";
    }
}
