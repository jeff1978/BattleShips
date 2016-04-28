using BattleShips.Setup;
using BattleShips.Ship;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleShipsTests.GameSetupTests
{
    [TestFixture]
    public class GameSetupTests
    {
        [Test]
        public void CheckGameSetupDefaults()
        {
            // arrange
            var thisMode = GameMode.Default;
            var thisGame = new GameSetup();
            var expected = "";

            // act
            var listOfDefaultSettings = thisGame.getMode(thisMode);
            foreach (var ShipTypeInGame in listOfDefaultSettings)
            {
                expected = expected + $"Ship type is {ShipTypeInGame.shipType} and quantity is {ShipTypeInGame.typeQuantity}\n";
            }

            // assert
            Assert.AreEqual("Ship type is Destroyer and quantity is 2\n", expected);
        }

        [Test]
        public void CheckGameSetupCustom()
        {
            // arrange
            var thisMode = GameMode.Custom;
            var thisGame = new GameSetup();
            var expected = "";

            // act
            var listOfDefaultSettings = thisGame.getMode(thisMode);
            foreach (var ShipTypeInGame in listOfDefaultSettings)
            {
                expected = expected + $"Ship type is {ShipTypeInGame.shipType} and quantity is {ShipTypeInGame.typeQuantity}\n";
            }

            // assert
            Assert.AreEqual("Ship type is Scout and quantity is 1\nShip type is Destroyer and quantity is 1\nShip type is Battleship and quantity is 1\n", expected);
        }
    }
}