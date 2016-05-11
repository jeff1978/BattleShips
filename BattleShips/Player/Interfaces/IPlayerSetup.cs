using System.Collections.Generic;

namespace BattleShips
{
    public interface IPlayerSetup
    {
        List<Player> playerList { get; }

        void SetupAllPlayers();
    }
}