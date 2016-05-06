using BattleShips.ConsoleChecker;
using BattleShips.BShip;
using System;
using System.Collections.Generic;

namespace BattleShips.Setup
{
    /// <summary>
    /// This class enables the users to specify the quantities of each ship type when custom game mode is selected.
    /// </summary>
    public static class GameCustom
    {
            public static List<ShipTypeInGame>  SetCustom(IGameSetupParser inputParser)
        {
            // put the enums in an array, needed to access values by index.
            string[] shipNameList = Enum.GetNames(typeof(ShipType));
            // create the list of ship types.
            var thisList = new List<ShipTypeInGame>();
            for (int i = 0; i < shipNameList.Length; i++)
            {
                Console.WriteLine("   Please enter the number of {0}s needed:", shipNameList.GetValue(i));
                inputParser.GetUserInput(RequestType.SetNoOfShips);

                // if number of ships chosen is zero or more then...
                    if (inputParser.noOfShips > -1)
                    {
                        var quantityInput = inputParser.noOfShips;
                        if (quantityInput != 0)
                        {
                        string nameOfType = shipNameList[i];
                        var thisShipType = Enum.Parse(typeof(ShipType), nameOfType);
                        var thisType = new ShipTypeInGame((ShipType)thisShipType, quantityInput);
                        thisList.Add(thisType);
                        }
                 // do nothing, go to next ship
                }
            }
            return thisList;
        }
    }
}
