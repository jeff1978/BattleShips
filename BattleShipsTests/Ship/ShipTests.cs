using BattleShips.BattleGround;
using BattleShips.Ship;
using NUnit.Framework;

namespace BattleShipsTest.ShipTests
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
            var thisShip = new Ship(ShipType.Battleship, true);

            // act
            var actualResult = thisShip.getShipPositions(placePosition, ShipType.Battleship, true);

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
            var thisShip = new Ship(ShipType.Destroyer, true);
            var actual = "";

            // act
            var ThisList = thisShip.getShipPositions(placePosition, ShipType.Destroyer, true);

            foreach (var Position in ThisList)
            {
                actual = actual + $"Position floating is {Position.IsFloating} row is {Position.row} and column is {Position.column}\n";
            }

            // assert
            Assert.AreEqual("Position floating is False row is 2 and column is 3\nPosition floating is False row is 3 and column is 3\n", actual);
        }

        [Test]
        public void CheckShipPositionsVertical()
        {
            // arrange
            // set up the test with some initialised objects
            var placePosition = new Position(2, 3);
            var thisShip = new Ship(ShipType.Battleship, true);
            var actual = "";

            // act
            var ThisList = thisShip.getShipPositions(placePosition, ShipType.Battleship, true);

            foreach (var Position in ThisList)
            {
                actual = actual + $"Position floating is {Position.IsFloating} row is {Position.row} and column is {Position.column}\n";
            }
            // assert
            Assert.AreEqual("Position floating is False row is 2 and column is 3\nPosition floating is False row is 3 and column is 3\nPosition floating is False row is 4 and column is 3\n", actual);
        }
    }
}