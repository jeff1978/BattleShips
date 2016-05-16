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
            List<Position> thisList = new List<Position>() { new Position(2, 2), new Position(5, 5), new Position(11, 5) };

            // act
            var thisPlayerSetup = new PlayerShipValidation();
            var result1 = thisPlayerSetup.IsPositionAvailable(new Position(4, 3), thisList);
            var result2 = thisPlayerSetup.IsPositionAvailable(new Position(5, 5), thisList);
            var result3 = thisPlayerSetup.IsPositionAvailable(new Position(11, 11), thisList);
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
            List<Ship> thisList = new List<Ship>() {ship1, ship2 };

            // act
            var result = thisPlayerSetup.GetPlayerShipsPositions(thisList);

            // assert
            Assert.AreEqual(7, result.Count);
        }

        [Test]
        public void CheckCanShipBeAdded()
        {
            // arrange
            var thisSea = new Sea(10, 10);
            List<Position> myShipList = new List<Position>() { new Position(3, 3), new Position(4, 5), new Position(6, 8) };

            // expect false - existing position
            List<Position> thisShipList1 = new List<Position>() { new Position(3, 3) };

            // expect false - out of sea bounds
            List<Position> thisShipList2 = new List<Position>() { new Position(4, 11) };
            
            // expect true
            List<Position> thisShipList3 = new List<Position>() { new Position(6, 1) };

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

        [Test]
        public void CheckCreatePlayerShips()
        {
            // arrange
            var thisValidation = new PlayerShipValidation();
            List<ShipTypeInGame> theseTypes = new List<ShipTypeInGame>();
            var thisPlayer = new Player();
            theseTypes.Add(new ShipTypeInGame(ShipType.Destroyer, 1));
            theseTypes.Add(new ShipTypeInGame(ShipType.Battleship, 2));
            theseTypes.Add(new ShipTypeInGame(ShipType.Scout, 3));

            // act
            thisValidation.createPlayerShips(theseTypes, thisPlayer);
            var expected = thisPlayer.PlayerShips.Count;

            // assert
            Assert.AreEqual(6, expected);
        }
    }
}