﻿namespace BattleShips.Setup
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
   0 - Default game : every player has just two destroyer ships.
   1 - Custom game : choose the the ship types and the quantities needed.
   Enter 0 or 1:
";
        public const string getSeaSize =
@"
   Note: the sea grid size typed here must be > or = 5 x 5 :
   Enter the size of the sea, use a comma to separate the x and y dimensions eg. 6,7
   Enter the sea size.....
";
    }
}