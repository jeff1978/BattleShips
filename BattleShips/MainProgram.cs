using BattleShips.ConsoleChecker;
using BattleShips.Formatting;
using System;

namespace BattleShips
{
    public class MainProgram
    {
        static void Main(string[] args)
            {
            // override the console writeline
            // for better formatting.
            Console.SetOut(new OutputFormat());

            // get the language option from the user
            // and set up the chosen language or default
            ISetupLanguage thisLanguage = new SetupLanguage();
            thisLanguage.GetUserLanguageOption();

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
