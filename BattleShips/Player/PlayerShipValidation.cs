using BattleShips.BattleGround;
using BattleShips.BShip;
using System;
using System.Collections.Generic;

namespace BattleShips
{
    /// <summary>
    /// This class is used to find out if a position is not already occupied by an existing ship, and if the 
    /// position is in the area of the sea.
    /// </summary>
    public class PlayerShipValidation
    {
        public Sea gameSea { get; set; }

        public bool canShipBeAdded(Ship thisShip, Position thisPosition, List<Position> myShipPositions)
        {
            // get the positions of the ship
            var thisShipPositions = thisShip.getShipPositions(thisPosition);

            // assume all is well.....
            bool positionsAreAvailable = true;

            // check for any invalid position against the existing ships or return true
            foreach (var eachPosition in thisShipPositions)
            {
                positionsAreAvailable = isPositionAvailable(eachPosition, myShipPositions);
                positionsAreAvailable = gameSea.IsValidPosition(eachPosition);
            }
            return positionsAreAvailable;
        }

        public bool isPositionAvailable(Position thisPosition, List<Position> myShipPositions)
        {
            bool positionIsValid = true;
            foreach (var item in myShipPositions)
            {
                if (item.row == thisPosition.row && item.column == thisPosition.column || gameSea.IsValidPosition(thisPosition) == false)
                {
                    positionIsValid = false;
                }
            }
            return positionIsValid;
        }

        public List<Position> getPlayerShipsPositions(List<Ship> PlayerShips)
        {
            // iterate through the player ship list, get all the positions
            // create an empty list to add to
            var playerShipPositions = new List<Position>();
            foreach (var Ship in PlayerShips)
            {
                foreach (var thisPosition in Ship.ShipPostions)
                {
                    playerShipPositions.Add(thisPosition);
                }
            }
            return playerShipPositions;
        }
    }
}
