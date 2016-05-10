using BattleShips.Setup;
using System.Collections.Generic;

namespace BattleShips

{
    /// <summary>
    /// This class contains a list of the players and their ships, ready to start the game.
    /// </summary>
    public class PlayerSetup
    {
        public IGameSetup thisGameSetup { get; set; }
        public List<Player> thesePlayers { get; set; }

        public List<Player> createPlayers(int noOfPlayers)
        {
            List<Player> gamePlayers = new List<Player>();
            for (int i = 0; i < noOfPlayers; i++)
            {
                gamePlayers.Add(new Player());
            }
            return gamePlayers;
        }

    }
}
