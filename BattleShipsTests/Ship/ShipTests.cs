using BattleShips.Sea;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleShips.Ship.Tests
{
    [TestFixture]
    public class ShipTests
    {
        [Test]
        public void GetHorizontalShipPositions()
        {
            // arrange
            // set up the test with some initialised objects
            var placePosition = new Position(2, 3);
            Ship thisShip = new Ship(ShipType.Battelship, true);

            // act
            var actualResult = thisShip.getShipPositions(placePosition, 3, true);

            // assert
            // check that the result list has appropriate size
            Assert.AreEqual(3, actualResult.ThisList.Count);
        }

    }
}