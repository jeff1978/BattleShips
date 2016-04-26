using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Sea
{
    public class Sea
    {
        #region property
        public int seaRow { get; set; }
        public int seaColumn { get; set; }
        #endregion

        public Sea(int a, int b)
        {
            seaRow = a;
            seaColumn = b;
        }
        /// <summary>
        /// A method to check x and y coordinates to see if they lie within
        /// the sea.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsValidPosition(Position position)
        {
            return position.row < seaRow && position.column < seaColumn && position.row >= 0 && position.column >= 0;
        }
    }
}
