using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShips
{
    public interface IGamePlay
    {
        List<Player> playerList { get; set; }
        void PlayGame();
    }
}
