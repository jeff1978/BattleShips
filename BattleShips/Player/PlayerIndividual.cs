using BattleShips.BattleGround;
using BattleShips.BShip;
using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using System;
using System.Collections.Generic;

namespace BattleShips
{
    /// <summary>
    /// This class is used to get setup information from each individual player
    /// </summary>
    public class PlayerIndividual
    {
        #region
        public IGameSetup thisGameSetup = new GameSetup(new GameSetupParser());
        public IPlayerSetupParser thisPlayerSetup = new PlayerSetupParser();
        public IPlayerShipValidation thisValidation = new PlayerShipValidation();
        public List<Player> playerList { get; private set; }
        #endregion

        public void setupAllPlayers()
        {

        }

        #region Individual Player Setup Method
        public void setupPlayer()
        {
            var thisPlayer = new Player();
            // show messages and get player name
            AddPlayerName(thisPlayer);

            // show ship menu message and create player ships
            thisValidation.createPlayerShips(thisGameSetup.listOfShipTypes, thisPlayer);

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
                        Console.WriteLine("Too many incorrect placement commands were made. The ship was removed from your fleet.");
                        thisPlayer.PlayerShips.Remove(thisShip);
                        shipIsAdded = true;
                    }
                }
            }
        }
        #endregion

        #region Add Player Name Method
        public void AddPlayerName(Player thisPlayer)
        {
            Console.WriteLine(PlayerSetupMessages.welcomePlayers);
            Console.WriteLine(PlayerSetupMessages.getPlayerName);
            thisPlayerSetup.GetUserInput(RequestType.SetPlayerName);
            thisPlayer.PlayerName = thisPlayerSetup.playerName;
        }
        #endregion

        #region Add Ship Details Method
        public bool AddShipDetails(Ship thisShip, Player thisPlayer)
        {
            Console.WriteLine("Ship to add: {0}, size {1}....", thisShip.ShipType, (int)thisShip.ShipType);
            Console.WriteLine(PlayerSetupMessages.getPlacementCommand);

            // get user input and format it
            var placePosition = GetNewShipDetailsFromUser(thisShip);

            // get the player's existing ship positions and this ship's positions to check for clashes
            // make sure that no positions lie in the sea. If all is well then save ship and return true, else do nothing and return false.

            var existingShipPositions = thisValidation.GetPlayerShipsPositions(thisPlayer.PlayerShips);
            var shipPositionList = thisShip.GetShipPositions(placePosition);
            if (thisValidation.CanShipBeAdded(thisGameSetup.gameSea, shipPositionList, existingShipPositions))
            {
                thisShip.SetShipPositions(placePosition);
                return true;
            }
            else
            {
                Console.WriteLine("Ship not added because at least one position is already occupied or lies outside the sea boundary.");
                return false;
            }
        }
        #endregion

        #region Get New Ship Details From User Method
        public Position GetNewShipDetailsFromUser(Ship thisShip)
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
    }
}
