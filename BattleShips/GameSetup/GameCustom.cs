using BattleShips.ConsoleChecker;
using BattleShips.Ship;
using System;
using System.Collections.Generic;

namespace BattleShips.Setup
{
    /// <summary>
    /// This class enables the users to specify the quantities of each ship type.
    /// </summary>
    public class GameCustom
    {
        public static List<ShipTypeInGame> setCustom()
        {
            // Get the list of ships.
            // For each one get the user to type in the quantity needed.
            // Create a new shipTypeInGame instance and add it to a list.

            // setup the validation
            IInputParser inputParser = new InputParser();

            // create the list
            var thisList = new List<ShipTypeInGame>();

            foreach (int item in Enum.GetValues(typeof(ShipType)))
            {
                Console.WriteLine("   Please enter the number of {0}s needed:", (ShipType)item);
                var thisType = new ShipTypeInGame();
                (new ShipTypeInGame()).shipType = (ShipType)item;
                inputParser.getUserInput(RequestType.SetNoOfPlayers);

                // if no of ships chosen greater than zero then...
                if (inputParser.noOfPlayers > 0)
                {
                    thisType.typeQuantity = inputParser.noOfShips;
                    thisList.Add(thisType);
                }
                // else do nothing.
            }
            return thisList;
        }

    }
}
