using BattleShips.ConsoleChecker;
using BattleShips.Ship;
using System;
using System.Collections.Generic;

namespace BattleShips.Setup
{
    /// <summary>
    /// This class enables the users to specify the quantities of each ship type.
    /// </summary>
    public static class GameCustom
    {
            // Get the list of ships.
            // For each one get the user to type in the quantity needed.
            // Create a new shipTypeInGame instance and add it to a list.
            public static List<ShipTypeInGame>  setCustom(IInputParser inputParser)
        {
            // create the list
            var thisList = new List<ShipTypeInGame>();
            foreach (int item in Enum.GetValues(typeof(ShipType)))
            {
                Console.WriteLine("   Please enter the number of {0}s needed:", (ShipType)item);
                inputParser.getUserInput(RequestType.SetNoOfShips);

                // if no of ships chosen greater than zero then...
                if (inputParser.noOfShips > 0)
                {
                    var quantityInput = inputParser.noOfShips;
                    var thisType= new ShipTypeInGame((ShipType)item,quantityInput);
                    thisList.Add(thisType);
                }
                // else do nothing.
            }
            return thisList;
        }

    }
}
