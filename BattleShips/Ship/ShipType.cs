namespace BattleShips.BShip
{
    /// <summary>
    /// This class stores the ship types.
    /// The enum values are explicit and are used the represent the number
    /// of positions that the ship occupies ie. the ship size.
    /// The list can be added to if you want to include more ship types. ShipTypes cannot have the same name.
    /// </summary>
    public enum ShipType
    {
        Battleship = 3,
        Scout = 1,
        Destroyer = 2,
        Submarine = 5
    } 

}
