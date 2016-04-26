using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Ship
{
    /// <summary>
    /// This class is used to store the ship type and quantity used in a game.
    /// </summary>
    class ShipTypeInGame
    {
        public ShipType shipType { get; set; }
        public int typeQuantity { get; set; }

        public ShipTypeInGame(ShipType thisType, int thisQuantity)
        {
            shipType = thisType;
            typeQuantity = thisQuantity;
        }
    }
}
