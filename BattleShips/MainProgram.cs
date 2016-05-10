using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using System;

namespace BattleShips
{
    public class MainProgram
    {
        static void Main(string[] args)
            {
            var thisGame = new PlayerSetup();
            thisGame.thisGameSetup.SetupGame();
            thisGame.SetupAllPlayers();

        }
    }
}
