using BattleShips.BattleGround;
using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using NUnit.Framework;
using System;

namespace BattleShipsTests
{
        [TestFixture]
        public class GamePlayParserTests
        {
            [Test]
            public void FireAtValidCoordinates()
            {
                // arrange
                string inputString1 = "2,3";
                string inputString2 = "33,1";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputFireTest1 = new GamePlayValidation(thisReader1);
                var actual1 = inputFireTest1.FireCommand();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputFireTest2 = new GamePlayValidation(thisReader2);
                var actual2 = inputFireTest2.FireCommand();

                // assert
                Assert.AreEqual(2, actual1.row);
                Assert.AreEqual(3, actual1.column);
                Assert.AreEqual(33, actual2.row);
                Assert.AreEqual(1, actual2.column);
            }

            [Test]
            public void FireAtInvalidCoordinates()
            {
                // arrange
                string inputString1 = "2,";
                string inputString2 = "33,one";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputFireTest1 = new GamePlayValidation(thisReader1);
                var actual1 = inputFireTest1.FireCommand();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputFireTest2 = new GamePlayValidation(thisReader2);
                var actual2 = inputFireTest2.FireCommand();

                // assert
                Assert.AreEqual(5, actual1.row);
                Assert.AreEqual(5, actual1.column);
                Assert.AreEqual(5, actual2.row);
                Assert.AreEqual(5, actual2.column);
            }
        }
}