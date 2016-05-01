using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using System;

namespace BattleShips
{
    public class MainProgram
    {
        public IGameSetup thisSetup { get; set; }

        public MainProgram(IGameSetup anyInt) {
            this.thisSetup = anyInt;
        }

        static void Main(string[] args)
        {
            IInputParser thisParser = new InputParser();
            IGameSetup thisGame = new GameSetup(thisParser);
            var thisProgram = new MainProgram(thisGame);
            thisProgram.thisSetup.setupGame();
        }
    }
}
