using BattleShips.BattleGround;
using BattleShips.BShip;
using System;
using System.Collections.Generic;

namespace BattleShips
{
    public class PlayerSetup
    {
        /// <summary>
        /// Checks to find out if a position is not already occupied by an existing ship, and if it is in the area of the sea.
        /// </summary>
        /// <param name="thisPosition"></param>
        /// <param name="myShipPositions"></param>
        /// <param name="gameSea"></param>
        /// <returns></returns>
        public bool isPositionAvailable(Position thisPosition, List<Position> myShipPositions, Sea gameSea)
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
