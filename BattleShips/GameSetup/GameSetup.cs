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
        // The game setup information will be set
        // to these read only properties.

        public int numberOfPlayers { get; private set; }
        public List<ShipTypeInGame> listOfShipTypes { get; private set; }
        public Sea gameSea { get; private set; }

        // Public method for access to this class
        //
        //
        public void setupGame()
        {
            // show welcome message
            showMessage(GameMessages.welcome);

            // get and set the number of players
            showMessage(GameMessages.getNumberOfPlayers);
            numberOfPlayers = Int32.Parse(Console.ReadLine());

            // get and set the game mode
            showMessage(GameMessages.getGameMode);
            var gameMode = Int32.Parse(Console.ReadLine());
            listOfShipTypes = GameInput.getSettings((GameMode)gameMode);

            // get and set the sea dimensions
            showMessage(GameMessages.getSeaSizeWidth);
            var x = Int32.Parse(Console.ReadLine());
            showMessage(GameMessages.getSeaSizeHight);
            var y = Int32.Parse(Console.ReadLine());
            gameSea = new Sea(x, y);
        }

        // Method to get the mode from the console
        public List<ShipTypeInGame> getMode(GameMode gameMode)
        {
            return GameInput.getSettings(gameMode);
        }

        // Method to show messages from storage class
        public static void showMessage(string thisMessage)
        {
            Console.WriteLine(thisMessage);
        }

    }
}
