namespace BattleShips.Ship
{
    /// <summary>
    /// This class is used to store the ship type and quantity used in a game.
    /// </summary>
    public class ShipTypeInGame
    {
        public ShipType shipType { get; set; }
        public int typeQuantity { get; set; }

        public ShipTypeInGame(ShipType thisType, int thisQuantity)
        {
            shipType = thisType;
            typeQuantity = thisQuantity;
        }

        /// <summary>
        /// Overloaded constructor needed for when user
        /// inputs parameters via the console.
        /// </summary>
        public ShipTypeInGame() { }
    }
}
