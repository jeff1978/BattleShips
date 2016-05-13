using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using System;

namespace BattleShips
{
    public class MainProgram
    {
        static void Main(string[] args)
            {
            // setup the game and the players
            IPlayerSetup thisGame = new PlayerSetup();
            thisGame.SetupAllPlayers();

            // copy the player list to the gameplay instance
            IGamePlay thisGamePlay = new GamePlay();
            thisGamePlay.playerList = thisGame.playerList;

            // play the game
            thisGamePlay.PlayGame();
        }
    }
}
