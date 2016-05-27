using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using NUnit.Framework;
using System;

namespace BattleShipsTests
{
        [TestFixture]
        public class PlayerSetupParserTests
        {
            [Test]
            public void SetValidPlayerName()
            {
                // arrange
                string inputString1 = "Jeff";
                string inputString2 = "Sasha";
                string expected1 = "Jeff";
                string expected2 = "Sasha";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputPlayerTest1 = new PlayerSetupParser(thisReader1);
                var actual1 = inputPlayerTest1.SetPlayerName();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputPlayerTest2 = new PlayerSetupParser(thisReader2);
                var actual2 = inputPlayerTest2.SetPlayerName();

                // assert
                Assert.AreEqual(expected1, actual1);
                Assert.AreEqual(expected2, actual2);
            }
            [Test]
            public void SetInvalidPlayerName()
            {
                // arrange
                string inputString1 = null;
                string inputString2 = " ";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputPlayerTest1 = new PlayerSetupParser(thisReader1);
                inputPlayerTest1.ValidateUserNameInput(thisReader1.ReadConsole());

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputPlayerTest2 = new PlayerSetupParser(thisReader2);
                inputPlayerTest2.ValidateUserNameInput(thisReader2.ReadConsole());

                // assert
                Assert.IsFalse(inputPlayerTest1.isValidInput);
                Assert.IsFalse(inputPlayerTest2.isValidInput);
            }

            [Test]
            public void SetValidNewShip()
            {
                // arrange
                string inputString1 = "2,3,h";
                string inputString2 = "5,6,v";
                string expected1 = "2,3,h";
                string expected2 = "5,6,v";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputPlayerTest1 = new PlayerSetupParser(thisReader1);
                var actual1 = inputPlayerTest1.PlaceNewShip();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputPlayerTest2 = new PlayerSetupParser(thisReader2);
                var actual2 = inputPlayerTest2.PlaceNewShip();

                // assert
                Assert.AreEqual(expected1, actual1);
                Assert.AreEqual(expected2, actual2);
            }
            [Test]
            public void SetInvalidNewShip()
            {
                // arrange
                string inputString1 = "2,3,horizontal";
                string inputString2 = "5,six,v";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputPlayerTest1 = new PlayerSetupParser(thisReader1);
                var outputString1 = inputPlayerTest1.ValidateUserShipInput(thisReader1.ReadConsole());

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputPlayerTest2 = new PlayerSetupParser(thisReader2);
                var outputString2 = inputPlayerTest2.ValidateUserShipInput(thisReader2.ReadConsole());

                // assert
                Assert.IsFalse(inputPlayerTest1.isValidInput);
                Assert.IsFalse(inputPlayerTest2.isValidInput);
            }
        }
}