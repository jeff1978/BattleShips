using BattleShips.Sea;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BattleShips.Ship.Tests
{
    [TestFixture]
    public class ShipTests
    {
        [Test]
        public void CheckShipPositionsCreated()
        {
            // arrange
            // set up the test with some initialised objects
            var placePosition = new Position(2, 3);
            Ship thisShip = new Ship(ShipType.Battelship, true);

            // act
            var actualResult = thisShip.getShipPositions(placePosition, ShipType.Battelship, true);

            // assert
            // check that the result list has appropriate size
            Assert.AreEqual(3, actualResult.Count);
        }

        [Test]
        public void CheckShipPositionsHorizontal()
        {
            // arrange
            // set up the test with some initialised objects
            var placePosition = new Position(2, 3);
            Ship thisShip = new Ship(ShipType.Destroyer, true);

            // act
            var ThisList = thisShip.getShipPositions(placePosition, ShipType.Destroyer, true);
           // var ThisList = shipPositionsOb.ThisList;
            
            // assert
            Assert.AreEqual("Position floating is False row is 2 and column is 3\nPosition floating is False row is 3 and column is 3\n", thisShip.showList(ThisList));
        }

        [Test]
        public void CheckShipPositionsVertical()
        {
            // arrange
            // set up the test with some initialised objects
            var placePosition = new Position(2, 3);
            Ship thisShip = new Ship(ShipType.Battelship, true);

            // act
            var ThisList = thisShip.getShipPositions(placePosition, ShipType.Battelship, true);
            //var ThisList = shipPositionsOb.ThisList;

            // assert
            Assert.AreEqual("Position floating is False row is 2 and column is 3\nPosition floating is False row is 3 and column is 3\nPosition floating is False row is 4 and column is 3\n", thisShip.showList(ThisList));
        }
    }
}