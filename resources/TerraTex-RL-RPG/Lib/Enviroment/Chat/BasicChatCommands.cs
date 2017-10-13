using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using TerraTex_RL_RPG.Lib.Helper;

namespace TerraTex_RL_RPG.Lib.Enviroment.Chat
{
    class BasicChatCommands : Script
    {
        [Command("cry", Alias = "c", Group = "chat", SensitiveInfo = false, GreedyArg = true)]
        public void CryCommand(Client player, string message = "")
        {
            message = TextHelper.RemoveColorStrings(message);

            List<Client> players = API.getPlayersInRadiusOfPlayer(20, player);
            foreach (Client sendToPlayer in players)
            {
                float distance = player.position.DistanceTo(sendToPlayer.position);
                if (distance >= 25)
                {
                    sendToPlayer.sendChatMessage("~m~" + player.name + " schreit: " + message);
                }
                else if (distance >= 20)
                {
                    sendToPlayer.sendChatMessage("~c~" + player.name + " schreit: " + message);
                }
                else
                {
                    sendToPlayer.sendChatMessage("~s~" + player.name + " schreit: " + message);
                }
            }
        }

        [Command("quiet", Alias = "q", Group = "chat", SensitiveInfo = false, GreedyArg = true)]
        public void QuietCommand(Client player, string message = "")
        {
            message = TextHelper.RemoveColorStrings(message);

            List<Client> players = API.getPlayersInRadiusOfPlayer(20, player);
            foreach (Client sendToPlayer in players)
            {
                float distance = player.position.DistanceTo(sendToPlayer.position);
                if (distance >= 10)
                {
                    sendToPlayer.sendChatMessage("~m~" + player.name + " flüstert: " + message);
                }
                else if (distance >= 5)
                {
                    sendToPlayer.sendChatMessage("~c~" + player.name + " flüstert: " + message);
                }
                else
                {
                    sendToPlayer.sendChatMessage("~s~" + player.name + " flüstert: " + message);
                }
            }
        }

        [Command("me", Group = "chat", SensitiveInfo = false, GreedyArg = true)]
        public void MeCommand(Client player, string message = "")
        {
            message = TextHelper.RemoveColorStrings(message);

            List<Client> players = API.getPlayersInRadiusOfPlayer(20, player);
            foreach (Client sendToPlayer in players)
            {
                sendToPlayer.sendChatMessage("~p~" + player.name + " " + message);
            }
        }

        [Command("global", Alias = "g", Group = "chat", SensitiveInfo = false, GreedyArg = true)]
        public void GlobalCommand(Client player, string message = "")
        {
            message = TextHelper.RemoveColorStrings(message);

            API.sendChatMessageToAll("~q~[Global] " + player.name + ": " + message);
        }
    }
}
