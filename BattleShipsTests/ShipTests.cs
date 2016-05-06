﻿using BattleShips.BattleGround;
using BattleShips.BShip;
using NUnit.Framework;

namespace BattleShipsTest
{
    [TestFixture]
    public class ShipTests
    {
        [Test]
        public void CheckShipGetShipPositions()
        {
            // arrange
            // set up the test with some initialised objects
            var placePosition = new Position(2, 3);
            var thisShip = new Ship(ShipType.Battleship, true);

            // act
            var actualResult = thisShip.GetShipPositions(placePosition);

            // assert
            // check that the result list has appropriate size
            Assert.AreEqual(3, actualResult.Count);
        }

        [Test]
        public void CheckShipPositionsHorizontal()
        {
            // arrange
            // set up the test with some initialised objects
            // add a ship and expect two horizontal grid positions returned
            var placePosition = new Position(2, 3);
            var thisShip = new Ship(ShipType.Destroyer, true);
            var actual = "";

            // act
            var ThisList = thisShip.GetShipPositions(placePosition);

            foreach (var Position in ThisList)
            {
                actual = actual + $"{Position.IsFloating},{Position.row},{Position.column}\n";
            }

            // assert
            Assert.AreEqual("False,2,3\nFalse,3,3\n", actual);
        }

        [Test]
        public void CheckShipPositionsVertical()
        {
            // arrange
            // set up the test with some initialised objects
            // add a ship and expect three vertical grid positions returned
            var placePosition = new Position(2, 3);
            var thisShip = new Ship(ShipType.Battleship, false);
            var actual = "";

            // act
            var ThisList = thisShip.GetShipPositions(placePosition);

            foreach (var Position in ThisList)
            {
                actual = actual + $"{Position.IsFloating},{Position.row},{Position.column}\n";
            }
            // assert
            Assert.AreEqual("False,2,3\nFalse,2,4\nFalse,2,5\n", actual);
        }

        [Test]
        public void CheckShipSetShipPositions()
        {
            // arrange
            // set up the test with some initialised objects
            var placePosition = new Position(2, 3);
            var thisShip = new Ship(ShipType.Battleship, true);

            // act
            thisShip.SetShipPositions(placePosition);
            var actualResult = thisShip.ShipPostions.Count;

            // assert
            // check that the result list has appropriate size
            Assert.AreEqual(3, actualResult);
        }
    }
}