using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using BattleShips.Ship;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleShipsTests
{
    [TestFixture]
    public class GameSetupTests
    {
        private readonly IInputParser thisInterface;

        public GameSetupTests(IInputParser anyInterface)
        {
            thisInterface = anyInterface;
        }
        public GameSetupTests() { }

        [Test]
        public void CheckGameSetupDefaults()
        {
            // arrange
            var thisGame = new GameSetup();
            var expected = "";

            // act
            thisGame.useMode(GameMode.Default);
            foreach (var ShipTypeInGame in thisGame.listOfShipTypes)
            {
                expected = expected + $"Ship type is {ShipTypeInGame.shipType} and quantity is {ShipTypeInGame.typeQuantity}\n";
            }

            //assert
            Assert.AreEqual("Ship type is Destroyer and quantity is 2\n", expected);
        }
    }
}