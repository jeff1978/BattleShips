using BattleShips.BattleGround;
using BattleShips.Ship;
using System;
using System.Collections.Generic;

namespace BattleShips.Setup
{
    /// <summary>
    /// This class gets all the information needed to start a new game.
    /// </summary>
    public class GameSetup : IGameSetup
    {
        // The game setup information will be stored here   
        public int numberOfPlayers { get; private set; }
        public List<ShipTypeInGame> listOfShipTypes { get; private set; }
        public Sea gameSea { get; private set; }

        // Public method for access to this class
        public void setupGame()
        {
            // show welcome message
            Console.WriteLine(GameMessages.welcome);

            // get and set the number of players
            Console.WriteLine(GameMessages.getNumberOfPlayers);
            numberOfPlayers = Int32.Parse(Console.ReadLine());

            // get and set the game mode
            Console.WriteLine(GameMessages.getGameMode);
            var gameMode = Int32.Parse(Console.ReadLine());
            listOfShipTypes = GameInput.getSettings((GameMode)gameMode);

            // get and set the sea dimensions
            Console.WriteLine(GameMessages.getSeaSizeWidth);
            var x = int.Parse(Console.ReadLine());
            Console.WriteLine(GameMessages.getSeaSizeHight);
            var y = int.Parse(Console.ReadLine());
            gameSea = new Sea(x, y);
        }

        public void useMode(GameMode thisMode)
        {
          GameInput.getSettings(thisMode);
        }

    }
}
