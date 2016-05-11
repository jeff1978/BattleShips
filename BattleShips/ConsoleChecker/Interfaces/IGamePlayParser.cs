using BattleShips.BattleGround;

namespace BattleShips.ConsoleChecker
{
    public interface IGamePlayParser
    {
        Position fireCoordinate { get; set; }

        void GetUserInput(RequestType thisRequest);
    }
}