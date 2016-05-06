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
            Sea thisSea = new Sea(10, 10);
            Position thisPosition1 = new Position(4, 3);
            Position thisPosition2 = new Position(5, 5);
            Position thisPosition3 = new Position(11, 11);
            // act
            var thisPlayerSetup = new PlayerShipValidation();
            thisPlayerSetup.gameSea = thisSea;
            var result1 = thisPlayerSetup.IsPositionAvailable(thisPosition1, thisList);
            var result2 = thisPlayerSetup.IsPositionAvailable(thisPosition2, thisList);
            var result3 = thisPlayerSetup.IsPositionAvailable(thisPosition3, thisList);
            // assert

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [Test]
        public void CheckGetPlayerShipPositions()
        {
            // arrange
            var ship1 = new Ship(ShipType.Submarine, true);
            var ship2 = new Ship(ShipType.Destroyer, false);

            ship1.SetShipPositions(new Position(3, 3));
            ship2.SetShipPositions(new Position(4, 5));

            List<Ship> thisList = new List<Ship>();
            thisList.Add(ship1);
            thisList.Add(ship2);

            var thisPlayerSetup = new PlayerShipValidation();

            // act
            var result = thisPlayerSetup.GetPlayerShipsPositions(thisList);
            
            // assert
            Assert.AreEqual(7,result.Count);
        }
    }
}