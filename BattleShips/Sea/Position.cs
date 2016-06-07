namespace BattleShips.BattleGround
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

        #region constructor
        public Position(int x, int y, bool IsFloating=false)
        {
            this.row = x;
            this.column = y;
        }
        #endregion
    }
}
