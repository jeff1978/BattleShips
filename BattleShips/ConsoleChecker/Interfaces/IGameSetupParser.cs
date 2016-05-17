using BattleShips.BattleGround;
using BattleShips.Setup;
using BattleShips.BShip;
using System.Collections.Generic;

namespace BattleShips.ConsoleChecker
{
    public interface IGameSetupParser
    {
        int SetNumberOfPlayers();
        int SetNumberOfShips();
        GameMode SelectGameMode();
        Sea SetSeaSize();
    }
}