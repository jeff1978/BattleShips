using BattleShips.BattleGround;
using BattleShips.BShip;
using System.Collections.Generic;

namespace BattleShips
{
    /// <summary>
    /// This class is used to find out if a position is not already occupied by an existing ship, and if the 
    /// position is in the area of the sea. There are unit tests for all methods - of course!
    /// </summary>
    public class PlayerShipValidation
    {
        public bool CanShipBeAdded(Sea gameSea, List<Position> thisShipPositions, List<Position> myShipPositions)
        {
            // assume all is well.....
            bool positionsAreValid = true;

            // check that all positions fit within the bounds of the sea
            //  if all true then check the positions against the existing positions

            if (thisShipPositions.TrueForAll(p => gameSea.IsValidPosition(p)))
            {
                positionsAreValid = thisShipPositions.TrueForAll(p => IsPositionAvailable(p, myShipPositions));
            }
            else
            {
                positionsAreValid = false;
            }
            return positionsAreValid;
        }

        public bool IsPositionAvailable(Position thisPosition, List<Position> myShipPositions)
        {
            bool positionIsValid = true;

            // check each position in myShipPositions. Use TrueForAll and then negate in lambda expression
            // to find any invalid position.
            positionIsValid = myShipPositions.TrueForAll(p => !(p.row == thisPosition.row && p.column == thisPosition.column));

            return positionIsValid;
        }

        public List<Position> GetPlayerShipsPositions(List<Ship> PlayerShips)
        {
            // iterate through the player ship list, get all the positions, create an empty list to add to
            var playerShipPositions = new List<Position>();
            foreach (var Ship in PlayerShips)
            {
                Ship.ShipPostions.ForEach(p => playerShipPositions.Add(p));
            }
            return playerShipPositions;
        }
    }
}
