using System.Collections.Generic;
using BattleShips.BattleGround;
using BattleShips.Ship;

namespace BattleShips.Setup
{
    public interface IGameSetup
    {
        Sea gameSea { get; }
        List<ShipTypeInGame> listOfShipTypes { get; }
        int numberOfPlayers { get; }

        List<ShipTypeInGame> getMode(GameMode gameMode);
        void setupGame();
    }
}