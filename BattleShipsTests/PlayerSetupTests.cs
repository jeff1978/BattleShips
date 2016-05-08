using BattleShips;
using BattleShips.BattleGround;
using BattleShips.BShip;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleShipsTests
{
    [TestFixture]
    public class PlayerSetupTests
    {
        [Test]
        public void CheckIsPositionAvailable()
        {
            // arrange
            List<Position> thisList = new List<Position>();
            thisList.Add(new Position(2, 2));
            thisList.Add(new Position(5, 5));
            thisList.Add(new Position(11, 5));
            //Sea thisSea = new Sea(10, 10);
            Position thisPosition1 = new Position(4, 3);
            Position thisPosition2 = new Position(5, 5);
            Position thisPosition3 = new Position(11, 11);
            // act
            var thisPlayerSetup = new PlayerShipValidation();
            //thisPlayerSetup.gameSea = thisSea;
            var result1 = thisPlayerSetup.IsPositionAvailable(thisPosition1, thisList);
            var result2 = thisPlayerSetup.IsPositionAvailable(thisPosition2, thisList);
            var result3 = thisPlayerSetup.IsPositionAvailable(thisPosition3, thisList);
            // assert

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [Test]
        public void CheckGetPlayerShipPositions()
        {
            // arrange
            var thisPlayerSetup = new PlayerShipValidation();
            var ship1 = new Ship(ShipType.Submarine, true);
            var ship2 = new Ship(ShipType.Destroyer, false);

            ship1.SetShipPositions(new Position(3, 3));
            ship2.SetShipPositions(new Position(4, 5));

            List<Ship> thisList = new List<Ship>();
            thisList.Add(ship1);
            thisList.Add(ship2);



            // act
            var result = thisPlayerSetup.GetPlayerShipsPositions(thisList);

            // assert
            Assert.AreEqual(7, result.Count);
        }

        [Test]
        public void CheckCanShipBeAdded()
        {
            // arrange
            // sea, thisShipPositions, myShipPositions
            var thisSea = new Sea(10, 10);

            List<Position> thisShipList1 = new List<Position>();
            thisShipList1.Add(new Position(3, 3)); // expect false - existing position

            List<Position> thisShipList2 = new List<Position>();
            thisShipList2.Add(new Position(4, 11)); // expect false - out of sea bounds

            List<Position> thisShipList3 = new List<Position>();
            thisShipList3.Add(new Position(6, 1)); // expect true

            List<Position> myShipList = new List<Position>();
            myShipList.Add(new Position(3, 3));
            myShipList.Add(new Position(4, 5));
            myShipList.Add(new Position(6, 8));

            // act
            var thisPlayerSetup = new PlayerShipValidation();
            var result1 = thisPlayerSetup.CanShipBeAdded(thisSea, thisShipList1, myShipList);
            var result2 = thisPlayerSetup.CanShipBeAdded(thisSea, thisShipList2, myShipList);
            var result3 = thisPlayerSetup.CanShipBeAdded(thisSea, thisShipList3, myShipList);

            // assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }
    }
}