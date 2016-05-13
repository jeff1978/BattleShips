using BattleShips;
using BattleShips.BattleGround;
using BattleShips.BShip;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipsTest
{

    public class PlayerTests
    {
        [TestFixture]
        public class ShipTests
        {
            [Test]
            public void CheckIsShipFloating()
            {
                // arrange
                // set up the test with two initialised objects
                // set one of the ships with all floating but not the other
                var placePosition1 = new Position(2, 3);
                var placePosition2 = new Position(7, 2);
                var thisShip1 = new Ship(ShipType.Battleship, true);
                var thisShip2 = new Ship(ShipType.Submarine, false);

                // act
                thisShip1.SetShipPositions(placePosition1);
                thisShip2.ShipPostions = thisShip2.GetShipPositions(placePosition2);

                // assert
                Assert.IsTrue(thisShip1.IsShipFloating());
                Assert.IsFalse(thisShip2.IsShipFloating());
            }

            [Test]
            public void CheckIsPlayerAlive()
            {
                // arrange
                // set up the test with two initialised ships
                // set one of the ships with all floating but not the other
                // check that player is alive
                var placePosition1 = new Position(2, 3);
                var placePosition2 = new Position(7, 2);
                var thisShip1 = new Ship(ShipType.Battleship, true);
                var thisShip2 = new Ship(ShipType.Submarine, false);
                var thisPlayer = new Player();
                var tempList = new List<Ship>();

                // act
                thisShip1.SetShipPositions(placePosition1);
                thisShip2.ShipPostions = thisShip2.GetShipPositions(placePosition2);
                tempList.Add(thisShip1); // floating ship
                tempList.Add(thisShip2); // sunk ship
                thisPlayer.PlayerShips = tempList;

                var deadPlayer = thisPlayer;
                var tempList2 = deadPlayer.PlayerShips;
                tempList2.RemoveAt(0); // remove floating ship
                deadPlayer.PlayerShips = tempList2;

                // assert
                Assert.IsTrue(thisPlayer.IsPlayerAlive());
                Assert.IsFalse(deadPlayer.IsPlayerAlive());
            }
        }
    }
}