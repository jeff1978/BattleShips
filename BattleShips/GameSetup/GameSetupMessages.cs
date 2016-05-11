namespace BattleShips.Setup
{
    /// <summary>
    /// This class stores all the console messages used during the game setup
    /// </summary>
    public static class GameSetupMessages
    {
        public const string welcome =
@"   __________________________________
   |   ___________________________   |
   |  |                           |  |
   |  |                           |  |
   |  |      Battleships v1.0     |  |
   |  |                           |  |
   |  |___________________________|  |
   |                                 |
   |*********************************|
   |              J A W              |
   |_________________________________|

        Welcome to Battleships!
";
        public const string getNumberOfPlayers =
@"   Enter the number of players for this game ( must be two or more ): 
";
        public const string getGameMode =
@"
   Game mode choices.....
   0 - Default game : every player has just one scout and one destroyer ship.
   1 - Custom game : choose the the ship types and the quantities needed.
   Enter 0 or 1:
";
        public const string getSeaSize =
@"
   Note: the sea grid size typed here must be > or = 5 x 5 :
   Enter the size of the sea, use a comma to separate the x and
   y dimensions eg. 6,7  Enter the sea size.....
";
        public const string getPlayerNoErrorMessage =
@"   Enter a valid number.Two or more players
   are required for this game.
";
        public const string getShipNoErrorMessage =
@"   The number you entered was not recognised. If ships of this
   kind are not required then type 0
";
        public const string getModeErrorMessage =
@"   The mode you entered was not recognised. Try again using
   a valid number for your game mode.
";
        public const string getSeaErrorMessage =
@"   The sea dimensions given were not valid. Ensure that 
   the format is correct and that the minimum size is 5,5.
   Enter the sea dimensions.
";
        public const string getShipTypeNo =
@"   Please enter the number of {0}s needed:
";
        public const string noMethodErrorMessage =
@"   The input cannot be processed. No method implementation has
   been found for the request.
";
    }
}
