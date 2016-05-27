using BattleShips.BattleGround;
using BattleShips.BShip;
using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using System;
using System.Collections.Generic;
using BattleShips.Properties;

namespace BattleShips
{
    /// <summary>
    /// This class is used to get setup information from each individual player
    /// </summary>
    public class PlayerSetup : IPlayerSetup
    {
        private IGameSetup thisGameSetup { get; set; }
        private IPlayerSetupParser thisPlayerSetupParser { get; set; }
        private IPlayerShipValidation thisValidation = new PlayerShipValidation();
        public List<Player> playerList { get; private set; }
        private IConsoleReader thisReader { get; set; }

        public PlayerSetup()
        {
            thisReader = new ConsoleReader();
            IGameSetupParser thisParser = new GameSetupParser(thisReader);
            thisGameSetup = new GameSetup(thisParser);
            thisPlayerSetupParser = new PlayerSetupParser(thisReader);
        }

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

            playerList.ForEach(p => SetupOnePlayer(p));
            AddPrefixToName(playerList);
            playerList.ForEach(p => Console.WriteLine(p.PlayerName));
        } 
        #endregion

        #region Individual Player Setup Method
        private void SetupOnePlayer(Player thisPlayer)
        {
            // show messages and get player name
            AddPlayerName(thisPlayer);

            thisValidation.createPlayerShips(thisGameSetup.listOfShipTypes, thisPlayer);
            Console.WriteLine(Resources.getPlacementCommand, thisPlayer.PlayerName);

            // for each ship ask for the place command and place the ship.
            // give the user 10 goes then remove the ship and move onto next one.
            foreach (var thisShip in thisPlayer.PlayerShips)
            {
                bool shipIsAdded = false;
                var count = 0;
                while (shipIsAdded == false)
                {
                    count++;
                    // now try to add the ship
                    shipIsAdded = AddShipDetails(thisShip, thisPlayer);
                    if (count == 10 && shipIsAdded == false)
                    {
                        Console.WriteLine(Resources.commandsRejectedErrorMessage);
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
            Console.WriteLine(Resources.playerSetupIntro);
            Console.WriteLine(Resources.getPlayerName);
            thisPlayer.PlayerName = thisPlayerSetupParser.SetPlayerName();
        }
        #endregion

        #region Add Ship Details Method
        private bool AddShipDetails(Ship thisShip, Player thisPlayer)
        {
            Console.WriteLine(Resources.shipTypeDetails, thisShip.ShipType, (int)thisShip.ShipType);

            // get user input and format it
            var placePosition = GetNewShipDetailsFromUser(thisShip);

            // get the player's existing ship positions and this ship's positions to check for clashes
            var existingShipPositions = thisValidation.GetPlayerShipsPositions(thisPlayer.PlayerShips);
            var shipPositionList = thisShip.GetShipPositions(placePosition);
            if (thisValidation.CanShipBeAdded(thisGameSetup.gameSea, shipPositionList, existingShipPositions))
            {
                thisShip.SetShipPositions(placePosition);
                return true;
            }
            else
            {
                Console.WriteLine(Resources.placementErrorMessage);
                return false;
            }
        }
        #endregion

        #region Get New Ship Details From User Method
        private Position GetNewShipDetailsFromUser(Ship thisShip)
        {
            var shipPlacementString = thisPlayerSetupParser.PlaceNewShip();
            string[] userInput = shipPlacementString.Split(',');
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
            playerList.ForEach(p => p.PlayerName = Resources.playerSuffix + " " + (i++) + " : " + p.PlayerName);
        } 
        #endregion
    }
}
