using BattleShips.BattleGround;
using BattleShips.ConsoleChecker;
using BattleShips.BShip;
using System;
using System.Collections.Generic;

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
        public GameSetup(IGameSetupParser thisIIParser){ inputParser = thisIIParser;}

        // The game setup information will be stored here   
        public int numberOfPlayers { get; private set; }
        public List<ShipTypeInGame> listOfShipTypes { get; private set; }
        public Sea gameSea { get; private set; }

        // Public method for access to this class
        public void setupGame()
        {           
            // show welcome message
            Console.WriteLine(GameSetupMessages.welcome);

            // get and set the number of players
            Console.WriteLine(GameSetupMessages.getNumberOfPlayers);
            inputParser.getUserInput(RequestType.SetNoOfPlayers);
            numberOfPlayers = inputParser.noOfPlayers;

            // get and set the game mode
            Console.WriteLine(GameSetupMessages.getGameMode);
            inputParser.getUserInput(RequestType.SelectGameMode);
            var gameMode = inputParser.gameMode;
            listOfShipTypes = GameInput.getSettings(gameMode, inputParser);

            // get and set the sea dimensions
            Console.WriteLine(GameSetupMessages.getSeaSize);
            inputParser.getUserInput(RequestType.SetSeaSize);
            gameSea = inputParser.seaSize;
        }

        public void useMode(GameMode thisMode)
        {
            listOfShipTypes = GameInput.getSettings(thisMode, inputParser);
        }
    }
}
