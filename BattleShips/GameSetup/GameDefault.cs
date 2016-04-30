using BattleShips.Ship;
using System.Collections.Generic;

namespace BattleShips.Setup
{
    /// <summary>
    /// This class stores the game default parameters
    /// eg. two destroyer ships
    /// </summary>
    public static class GameDefault
    {
        public static List<ShipTypeInGame> setDefaults()
        {
            var thisType = new ShipTypeInGame(ShipType.Destroyer, 2);
            var thisList = new List<ShipTypeInGame>();
            thisList.Add(thisType);
            return thisList;
        }
    }
}
