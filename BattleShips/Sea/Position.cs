using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Sea
{
    /// <summary>
    /// This class represents the coordinates of a grid using x and y integers.
    /// There is an optional IsFloating parameter used to determine when a coordinate has
    /// been hit.
    /// </summary>
    public class Position
    {
        #region property
        public int row { get; set; }
        public int column { get; set; }
        public bool IsFloating { get; set; }
        #endregion

        /// <summary>
        /// This is the principal class used to represent the coordinates of a grid. This also
        ///  includes a boolean property called IsFloating that is used as a flag for
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="IsFloating"> This is an optional default parameter already initialised.</param>

        #region constructor
        public Position(int x, int y, bool IsFloating=true)
        {
            this.row = x;
            this.column = y;
        }
        #endregion
    }
}
