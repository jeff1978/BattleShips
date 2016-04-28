using System;

namespace BattleShips.Setup
{
    public static class GameMessages
    {
        public const string welcome =
@"****************************
****************************
***   Battleships v1.0   ***
****************************
****************************
";
        public const string getNumberOfPlayers =
@"
Please enter the number of players for this game ( must be 2 or more ): 
";
        public const string getGameMode =
@"
Game mode choices.....
0 - Default game : every player has just two destroyer ships.
1 - Custom game : choose the the ship types and the quantities needed.
Please enter 0 or 1:
";
        public const string getSeaSizeWidth =
@"
Note: the sea grid size typed here must be > or = 5 x 5 :
Please enter the WIDTH size....
";
        public const string getSeaSizeHight =
@"
Please enter the HIGHT size....
";
    }
}
