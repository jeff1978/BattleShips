using BattleShips.BattleGround;
using BattleShips.ConsoleChecker;
using BattleShips.BShip;
using System;
using System.Collections.Generic;
using BattleShips.Properties;
using System.Resources;
using System.Threading;
using System.Reflection;

namespace BattleShips.Setup
{
    /// <summary>
    /// This class gets and stores all the information needed to start a new game.
    /// </summary>
    public class GameSetup : IGameSetup
    {
        private IGameSetupParser inputParser { get; set; }

        /// <summary>
        /// Constructor injection used here to facilitate mockup for unit testing.
        /// </summary>
        public GameSetup(IGameSetupParser thisIParser)
        {
            inputParser = thisIParser;
        }

        // The game setup information will be stored here   
        public int numberOfPlayers { get; private set; }
        public List<ShipTypeInGame> listOfShipTypes { get; private set; }
        public Sea gameSea { get; private set; }

        // Public method for access to this class
        public void SetupGame()
        {
            // get and set the number of players
            Console.WriteLine(Resources.getNumberOfPlayers);
            numberOfPlayers = inputParser.SetNumberOfPlayers(); 

            // get and set the game mode
            Console.WriteLine(Resources.getGameMode);
            var gameMode = inputParser.SelectGameMode();
            listOfShipTypes = GameInput.GetSettings(gameMode, inputParser);

            // get and set the sea dimensions
            Console.WriteLine(Resources.getSeaSize);
            gameSea = inputParser.SetSeaSize();
        }
    }
}
