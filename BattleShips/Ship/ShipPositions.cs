using BattleShips.Sea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Ship
{
    /// <summary>
    /// This class stores the list of grid positions occupied by a ship. This also
    ///  includes a boolean property called IsFloating that is used as a flag for
    /// positions hit by missiles.
    /// </summary>
    public class ShipPositions
    {
        public List<Position> ThisList { get; set; }

        public ShipPositions(List<Position> anyList)
        {
            ThisList = anyList;
        }
     }
}
