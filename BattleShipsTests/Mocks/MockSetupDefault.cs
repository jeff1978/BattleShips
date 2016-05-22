using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using BattleShips.BattleGround;

namespace BattleShipsTests
{

    /// <summary>
    /// This class mocks the console inputs for user commands during Default game mode setup.
    /// It inplements the IGameSetupParser interface
    /// </summary>
    public class MockSetupDefault : IGameSetupParser
    {
        public int SetNumberOfPlayers()
        {
            return 3;
        }

        public int SetNumberOfShips()
        {
            // Not needed for this test!
            return 4;
        }

        public GameMode SelectGameMode()
        {
            return GameMode.Default;
        }

        public Sea SetSeaSize()
        {
            return new Sea(6, 7);
        }
    }
}