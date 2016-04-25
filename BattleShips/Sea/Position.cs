using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Sea
{
    /// <summary>
    /// This class represents the coordinates of a grid using x and y integers.
    /// </summary>
    public class Position
    {
        #region property
        public int row { get; set; }
        public int column { get; set; }
        #endregion

        #region constructor
        public Position(int x, int y)
        {
            this.row = x;
            this.column = y;
        }
        #endregion
    }
}
