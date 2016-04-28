using BattleShips.BattleGround;
using NUnit.Framework;

namespace BattleShipsTests.SeaTests
{
    [TestFixture]
    public class SeaTests
    {
        [Test]
        public void IsValidPosition()
        {
            // arrange
            Sea thisSea = new Sea(5, 5);
            Position validPosition = new Position(4, 3);
            // act
            var result = thisSea.IsValidPosition(validPosition); 
            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsInvalidPosition()
        {
            // arrange
            Sea thisSea = new Sea(5, 5);
            Position inValidPosition = new Position(6, 6);
            // act
            var result = thisSea.IsValidPosition(inValidPosition);
            // assert
            Assert.IsFalse(result);
        }
    }
}