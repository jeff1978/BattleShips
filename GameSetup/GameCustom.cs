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
        public static List<ShipTypeInGame> setCustom()
        {
            // Get the list of ships.
            // For each one get the user to type in the quantity needed.
            // Create a new shipTypeInGame instance and add it to a list.

            var thisList = new List<ShipTypeInGame>();
            foreach (int item in Enum.GetValues(typeof(ShipType)))
            {
                Console.WriteLine("Please enter the number of {0}s needed:", (ShipType)item);
                var thisType = new ShipTypeInGame();
                thisType.shipType = (ShipType)item;
                thisType.typeQuantity = int.Parse(Console.ReadLine());
                //thisType.typeQuantity = 1;
                thisList.Add(thisType);
            }
            return thisList;
        }

    }
}
