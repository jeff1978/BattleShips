using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Sea
{
    /// <summary>
    /// This class represents the coordinates of a grid using an x and y integer.
    /// </summary>
    class Position
    {
        public int row { get; set; }
        public int column { get; set; }

        #region properties
        public Position(int x, int y)
        {
            this.row = x;
            this.row = y;
        } 
        #endregion
    }
}
