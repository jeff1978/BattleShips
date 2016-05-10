using BattleShips.BShip;
using System.Collections.Generic;

namespace BattleShips.Setup
{
    /// <summary>
    /// This class stores the game default parameters eg. one scout ship and one destroyer ship
    /// </summary>
    public static class GameDefault
    {
        public static List<ShipTypeInGame> SetDefaults()
        {
            var thisList = new List<ShipTypeInGame>();
            thisList.Add(new ShipTypeInGame(ShipType.Destroyer, 1));
            thisList.Add(new ShipTypeInGame(ShipType.Scout, 1));
            return thisList;
        }
    }
}
