using BattleShips.BattleGround;
using NUnit.Framework;

namespace BattleShipsTests
{
    [TestFixture]
    public class PlayerSetupTests
    {
        [Test]
        public void CheckPlayersCreated()
        {
            // arrange
            Sea thisSea = new Sea(5, 5);
            Position validPosition = new Position(4, 3);
            // act
            var result = thisSea.IsValidPosition(validPosition); 
            // assert
            Assert.IsTrue(result);
        }
    }
}