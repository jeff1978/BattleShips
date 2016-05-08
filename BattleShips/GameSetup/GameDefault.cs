using BattleShips.BShip;
using System.Collections.Generic;

namespace BattleShips.Setup
{
    /// <summary>
    /// This class stores the game default parameters eg. two destroyer ships
    /// </summary>
    public static class GameDefault
    {
        public static List<ShipTypeInGame> SetDefaults()
        {
            var thisList = new List<ShipTypeInGame>();
            thisList.Add(new ShipTypeInGame(ShipType.Destroyer, 2));
            return thisList;
        }
    }
}
