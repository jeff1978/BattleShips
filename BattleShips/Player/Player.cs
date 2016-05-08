using BattleShips.BattleGround;
using BattleShips.BShip;
using System.Collections.Generic;

namespace BattleShips
{
    public class Player
    {
        public List<Ship> PlayerShips { get; set; }
        public string PlayerName { get; set; }

        //public bool CreateShip(ShipType thisType, bool isHorizontal, Position placePosition)
        //{
        //    // create new instance of player ship validation class
        //    var thisValidaton = new PlayerShipValidation();

        //    // create a new ship
        //    var newShip = new Ship(thisType, isHorizontal);

        //    // get positions from all existing ships, then check to see if new ship can be added
        //    var existingShipPositions = thisValidaton.GetPlayerShipsPositions(PlayerShips);

        //    if (thisValidaton.CanShipBeAdded(newShip, placePosition, existingShipPositions))
        //    {
        //        // all good to add, so set the ship positions to floating.
        //        newShip.SetShipPositions(placePosition);
        //        // add ship to PlayerShips
        //        PlayerShips.Add(newShip);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
