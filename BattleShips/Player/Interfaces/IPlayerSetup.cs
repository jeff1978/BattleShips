using System.Collections.Generic;

namespace BattleShips
{
    public interface IPlayerSetup
    {
        void SetupAllPlayers();
        List<Player> playerList { get; }
    }
}
