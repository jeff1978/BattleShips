using BattleShips.BattleGround;
using System.Collections.Generic;

namespace BattleShips.BShip
{
    /// <summary>
    /// This class represents a ship on the sea. The ship can lie horizontally or vertically. The ship must be of a particular
    /// type that gives it its Type name and size. There is also a list of positions used to represent the ship location.
    /// </summary>
    public class Ship
    {
        public bool IsHorizontal { get; set; }
        public ShipType ShipType { get; set; }
        public List<Position> ShipPositions {get; set;}

    public Ship(ShipType thisType, bool isHorizontal)
        {
            IsHorizontal = isHorizontal;
            ShipType = thisType;
        }
        
        // This method will take the place parameters and work out the occupied grid
        // coordinates based on the ship type and direction. Assume that the ship
        // placement coordinate is on the far left (if horizontal) or bottom (if
        // vertical.
        public List<Position> GetShipPositions(Position placePosition)
        {
            // lets breakdown the placePosition and work out the 
            // other coordinates.
            var x = placePosition.row;
            var y = placePosition.column;

            var newList = new List<Position> ();

            // if isHoriz true then use a for loop to work out the other coords.
            if (IsHorizontal)
            {
                for (int i = 0; i < (int)ShipType; i++)
                {
                    var positionToAdd = new Position(x + i, y);
                    newList.Add(positionToAdd);
                }
            }
            else  
            {
                // if isHoriz false then use a for loop to work out the other coords.
                for (int i = 0; i < (int)ShipType; i++)
                {
                    var positionToAdd = new Position(x, y + i);
                    newList.Add(positionToAdd);
                }
            }
            return newList;
        }

        // This method sets the ships positions to floating.
        public void SetShipPositions(Position placePosition)
        {
            var tempList = GetShipPositions(placePosition);
            tempList.ForEach(p => p.IsFloating = true);
            ShipPositions = tempList;
        }

        // This method checks the ship positions to determine
        // if the ship is floating or sunk.
        public bool IsShipFloating()
        {
            // find at least one floating position
            return ShipPositions.Exists(p => p.IsFloating);
        }
    }
}
