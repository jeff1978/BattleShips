using BattleShips.BattleGround;
using BattleShips.BShip;
using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using System;
using System.Collections.Generic;
using BattleShips;

namespace BattleShips
{
    /// <summary>
    /// This class is used to get setup information from each individual player
    /// </summary>
    public class PlayerSetup : IPlayerSetup
    {
        #region
        public IGameSetup thisGameSetup = new GameSetup(new GameSetupParser());
        public IPlayerSetupParser thisPlayerSetup = new PlayerSetupParser();
        public IPlayerShipValidation thisValidation = new PlayerShipValidation();
        public List<Player> playerList { get; private set; }
        #endregion

        #region Setup All Players Method
        public void SetupAllPlayers()
        {
            //set up a new game
            thisGameSetup.SetupGame();

            // create a list of new players and add it to the playerList
            var tempList = new List<Player>();
            for (int i = 0; i < thisGameSetup.numberOfPlayers; i++)
            {
                tempList.Add(new Player());
            }
            playerList = tempList;

            // setup all players
            playerList.ForEach(p => SetupOnePlayer(p));

            // add a suffix to each name, to make for easier gameplay
            AddPrefixToName(playerList);

            // add a space and display the list of players 
            // ready to start the game.
            Console.WriteLine("");
            playerList.ForEach(p => Console.WriteLine(p.PlayerName));
        } 
        #endregion

        #region Individual Player Setup Method
        private void SetupOnePlayer(Player thisPlayer)
        {
            // show messages and get player name
            AddPlayerName(thisPlayer);

            // show ship menu message and create player ships
            thisValidation.createPlayerShips(thisGameSetup.listOfShipTypes, thisPlayer);
            Console.WriteLine(PlayerSetupMessages.getPlacementCommand);

            // for each ship ask for the place command and place the ship.
            // give the user 10 goes then remove the ship and move onto next one.
            foreach (var thisShip in thisPlayer.PlayerShips)
            {
                bool shipIsAdded = false;
                var count = 0;
                while (shipIsAdded == false)
                {
                    count++;
                    shipIsAdded = AddShipDetails(thisShip, thisPlayer);
                    if (count == 10 && shipIsAdded == false)
                    {
                        Console.WriteLine(PlayerSetupMessages.commandsRejectedErrorMessage);
                        thisPlayer.PlayerShips.Remove(thisShip);
                        shipIsAdded = true;
                    }
                }
            }
        }
        #endregion

        #region Add Player Name Method
        private void AddPlayerName(Player thisPlayer)
        {
            Console.WriteLine(PlayerSetupMessages.playerSetupIntro);
            Console.WriteLine(PlayerSetupMessages.getPlayerName);
            thisPlayerSetup.GetUserInput(RequestType.SetPlayerName);
            thisPlayer.PlayerName = thisPlayerSetup.playerName;
        }
        #endregion

        #region Add Ship Details Method
        private bool AddShipDetails(Ship thisShip, Player thisPlayer)
        {
            Console.WriteLine(PlayerSetupMessages.shipTypeDetails, thisShip.ShipType, (int)thisShip.ShipType);

            // get user input and format it
            var placePosition = GetNewShipDetailsFromUser(thisShip);

            // get the player's existing ship positions and this ship's positions to check for clashes
            // make sure that no positions lie outside the sea. If all is well then save ship and return true, else do nothing and return false.

            var existingShipPositions = thisValidation.GetPlayerShipsPositions(thisPlayer.PlayerShips);
            var shipPositionList = thisShip.GetShipPositions(placePosition);
            if (thisValidation.CanShipBeAdded(thisGameSetup.gameSea, shipPositionList, existingShipPositions))
            {
                thisShip.SetShipPositions(placePosition);
                return true;
            }
            else
            {
                Console.WriteLine(PlayerSetupMessages.placementErrorMessage);
                return false;
            }
        }
        #endregion

        #region Get New Ship Details From User Method
        private Position GetNewShipDetailsFromUser(Ship thisShip)
        {
            thisPlayerSetup.GetUserInput(RequestType.PlaceNewShip);
            string[] userInput = thisPlayerSetup.newShipPlaceString.Split(',');
            if (userInput[2] == "h")
            {
                thisShip.IsHorizontal = true;
            }
            return new Position(int.Parse(userInput[0]), int.Parse(userInput[1]));
        }
        #endregion

        #region Add Prefix To Name Method
        private void AddPrefixToName(List<Player> playerList)
        {
            int i = 1;
            playerList.ForEach(p => p.PlayerName = "Player " + (i++) + ": " + p.PlayerName);
        } 
        #endregion
    }
}
