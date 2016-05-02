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
            for (int i = 0; i < Enum.GetValues(typeof(ShipType)).Length; i++)
            {
                Console.WriteLine("   Please enter the number of {0}s needed:", (ShipType)i+1);
                inputParser.getUserInput(RequestType.SetNoOfShips);

                // if no of ships chosen is zero or more then...
                    if (inputParser.noOfShips > -1)
                    {
                        var quantityInput = inputParser.noOfShips;
                        if (quantityInput != 0)
                        {
                            var thisType = new ShipTypeInGame((ShipType)i+1, quantityInput);
                            thisList.Add(thisType);
                        }
                 // do nothing, go to next ship
                }
            }
            return thisList;
        }
    }
}
