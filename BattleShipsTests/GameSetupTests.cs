using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using BattleShips.BShip;
using NUnit.Framework;

namespace BattleShipsTests
{
    [TestFixture]
    public class GameSetupTests
    {
        [Test]
        public void CheckGameSetupDefaults()
        {
            // arrange and Act
            IGameSetupParser thisParser = new MockSetupDefault();
            var thisGame = new GameSetup(thisParser);
            var expected = "";
            thisGame.setupGame();

            foreach (var ShipTypeInGame in thisGame.listOfShipTypes)
            {
                expected = expected + $"Ship type is {ShipTypeInGame.shipType} and quantity is {ShipTypeInGame.typeQuantity}\n";
            }

            //assert
            Assert.AreEqual("Ship type is Destroyer and quantity is 2\n", expected);
            Assert.AreEqual(3, thisGame.numberOfPlayers);
            Assert.AreEqual(6, thisGame.gameSea.seaRow);
            Assert.AreEqual(7, thisGame.gameSea.seaColumn);
        }

        [Test]
        public void CheckGameSetupCustom()
        {
            // arrange and Act
            IGameSetupParser thisParser = new MockSetupCustom();
            var thisGame = new GameSetup(thisParser);
            var expected = "";
            thisGame.setupGame();

            foreach (var ShipTypeInGame in thisGame.listOfShipTypes)
            {
                expected = expected + $"Ship type is {ShipTypeInGame.shipType} and quantity is {ShipTypeInGame.typeQuantity}\n";
            }

            //assert
            Assert.AreEqual("Ship type is Scout and quantity is 4\nShip type is Destroyer and quantity is 4\nShip type is Battleship and quantity is 4\nShip type is Submarine and quantity is 4\n", expected);
            Assert.AreEqual(5, thisGame.numberOfPlayers);
            Assert.AreEqual(10, thisGame.gameSea.seaRow);
            Assert.AreEqual(10, thisGame.gameSea.seaColumn);
        }
    }
}