using System.Collections.Generic;
using BattleShips.BattleGround;
using BattleShips.BShip;

namespace BattleShips.Setup
{
    public interface IGameSetup
    {
        Sea gameSea { get; }
        List<ShipTypeInGame> listOfShipTypes { get; }
        int numberOfPlayers { get; }

        void SetupGame();
        void useMode(GameMode thisMode);
    }
}