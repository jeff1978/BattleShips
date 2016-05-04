using BattleShips.BattleGround;
using BattleShips.BShip;
using System.Collections.Generic;

namespace BattleShips
{
    public class Player
    {
        public List<Ship> PlayerShips { get; set; }
        public string PlayerName { get; set; }

        public void createShip(ShipType thisType, bool isHorizontal, Position placePosition)
        {
            var newShip = new Ship(thisType, isHorizontal);
            var shipPositions = newShip.getShipPositions(placePosition);

            // bool checkAllValidPositions       list of positions      newShip.getShipPositions(placePosition);

            // void setShipPositionsFloating list of positions

            // add ship to myList
        }
    }
}
