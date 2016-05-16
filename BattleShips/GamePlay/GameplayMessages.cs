namespace BattleShips
{
    /// <summary>
    /// This class stores all the console messages used during game play
    /// </summary>
    public static class GamePlayMessages
    {
        public const string gameStart =
@"   
   Game starting....
";
        public const string getFireCommand =
@"   {0} enter the coordinates to fire at....
";
        public const string missMessage =
@"   Miss!!
";
        public const string hitMessage = 
@"   Position Hit!!
";
        public const string sinkMessage =
@"   Position hit and {0} sunk!!
";
        public const string leaveMessage =
@"   {0} has no remaining ships and has left
   the game.
";
        public const string winMessage =
@"   ***** W I N N E R *****
   Congratulations {0}
    You are the winner.
";
        public const string gameEndMessage =
@"   *** This game has ended ***
      Press any key to exit...
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
