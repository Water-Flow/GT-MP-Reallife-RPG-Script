using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace TerraTex_RL_RPG.Lib.Helper
{
    public static class PlayerHelper
    {
        public static Client GetPlayerById(int id)
        {
            List<Client> clients = TTRPG.Api.getAllPlayers();

            foreach (Client player in clients)
            {
                if ((int) player.getSyncedData("ID") == id)
                {
                    return player;
                }
            }

            return null;
        }

        public static Client GetPlayerByPartialNickname(string nickname)
        {
            Client playerFromName = API.shared.getPlayerFromName(nickname);
            if (playerFromName != null)
            {
                return playerFromName;
            }

            if (nickname == null || nickname.Length <= 3)
            {
                return null;
            }

            List<Client> foundClients = new List<Client>();
            List<Client> clients = TTRPG.Api.getAllPlayers();

            foreach (Client player in clients)
            {
                if (player.name != null && player.name.IndexOf(nickname, StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    foundClients.Add(player);
                }
            }

            if (foundClients.Count == 1)
            {
                return foundClients[0];
            }

            return null;
        }

        public static Client GetPlayerFromNameOrId(string playerNameOrId)
        {
            Client player = null;
            if (int.TryParse(playerNameOrId, out int result))
            {
                player = GetPlayerById(result);
            }
            else
            {
                player = GetPlayerByPartialNickname(playerNameOrId);
            }
            return player;
        }
    }
}