using BattleShips.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShips
{
    public interface IPlayerSetup
    {
        void SetupAllPlayers();
        List<Player> playerList { get; }
    }
}
