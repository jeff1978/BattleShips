using BattleShips.BattleGround;
using System.Collections.Generic;

namespace BattleShips.BShip
{
    /// <summary>
    /// This class represents a ship on the sea.
    /// </summary>
    public class Ship
    {
        public bool IsHorizontal { get; set; }
        public ShipType ShipType { get; set; }
        public List<Position> ShipPostions {get; set;}

    public Ship(ShipType thisType, bool isHorizontal)
        {
            IsHorizontal = isHorizontal;
            ShipType = thisType;
        }
        
        /// <summary>
        /// This method will take the place parameters and work out the occupied grid
        /// coordinates based on the ship type and direction. Assume that the ship
        /// placement coordinate is on the far left (if horizontal) or bottom (if
        /// vertical.
        /// </summary>
        /// <param name="placePosition"></param>
        /// <param name="shipSize"></param>
        /// <param name="isShipHorizontal"></param>
        /// <returns></returns>
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

        public void SetShipPositions(Position placePosition)
        {
            var tempList = GetShipPositions(placePosition);
            tempList.ForEach(p => p.IsFloating = true);
            ShipPostions = tempList;
        }

        public bool IsShipFloating()
        {
            return ShipPostions.TrueForAll(p => p.IsFloating);
        }
    }
}