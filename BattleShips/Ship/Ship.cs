using BattleShips.Sea;
using System.Collections.Generic;

namespace BattleShips.Ship
{
    /// <summary>
    /// This class represents a ship on the sea.
    /// </summary>
    public class Ship
    {
        public bool IsHorizontal{ get; set; }
        public ShipType ShipType { get; set; }

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
        public List<Position> getShipPositions(Position placePosition, ShipType shipType, bool isShipHorizontal)
        {
            // lets breakdown the placePosition and work out the 
            // other coordinates.
            var x = placePosition.row;
            var y = placePosition.column;

            var newList = new List<Position> ();

            // if isHoriz true then use a for loop to work out the other coords.
            if (isShipHorizontal)
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

        /// <summary>
        /// A method that takes a list of positions and returns text showing the
        /// full properties of each position. It is useful for unit testing.
        /// </summary>
        /// <param name="aListOfPositions"></param>
        /// <returns></returns>
        public string showList(List<Position> aListOfPositions)
        {
            // this is a string used to build the result
            string thesePostions="";
            foreach (var Position in aListOfPositions)
            {
                thesePostions = thesePostions + $"Position floating is {Position.IsFloating} row is {Position.row} and column is {Position.column}\n";         
            }
            return thesePostions;
       }
    }
}

