using BattleShips.BattleGround;
using BattleShips.BShip;
using System.Collections.Generic;

namespace BattleShips
{
    /// <summary>
    /// This class is used to find out if a position is not already occupied by an existing ship, and if the 
    /// position is in the area of the sea. There are unit tests for all methods - of course!
    /// </summary>
    public class PlayerShipValidation : IPlayerShipValidation
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
            // check each position in myShipPositions. Use TrueForAll and then negate
            // in a lambda expression to find any invalid position.
            return myShipPositions.TrueForAll(p => !(p.row == thisPosition.row && p.column == thisPosition.column));
        }

        public List<Position> GetPlayerShipsPositions(List<Ship> PlayerShips)
        {
            // iterate through the player ship list, get all the positions, create an empty list to add to
            var playerShipPositions = new List<Position>();
            foreach (var Ship in PlayerShips)
            {
                if (Ship.ShipPositions != null)
                {
                    Ship.ShipPositions.ForEach(p => playerShipPositions.Add(p));
                }
            }
            return playerShipPositions;
        }

        public void createPlayerShips(List<ShipTypeInGame> typesInThisGame, Player thisPlayer)
        {
            var thisList = new List<Ship>();
            foreach (var item in typesInThisGame)
            {
                for (int i = 0; i < item.typeQuantity; i++)
                {
                    thisList.Add(new Ship(item.shipType, false));
                }
            }
            thisPlayer.PlayerShips = thisList;
        }
    }
}
