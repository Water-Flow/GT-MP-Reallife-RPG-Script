using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using TerraTex_RL_RPG.Lib.Helper;

namespace TerraTex_RL_RPG.Lib.Enviroment.Chat
{
    class DistanceChat : Script
    {
        public DistanceChat()
        {
            API.onChatMessage += OnChatMessageHandler;
        }

        public void OnChatMessageHandler(Client player, string message, CancelEventArgs e)
        {
            e.Cancel = true;

            message = TextHelper.RemoveColorStrings(message);
            
            List<Client> players = API.getPlayersInRadiusOfPlayer(20, player);
            foreach (Client sendToPlayer in players)
            {
                float distance = player.position.DistanceTo(sendToPlayer.position);
                if (distance >= 15)
                {
                    sendToPlayer.sendChatMessage("~m~" + player.name, message);
                }
                else if(distance >= 10)
                {
                    sendToPlayer.sendChatMessage("~c~" + player.name, message);
                }
                else
                {
                    sendToPlayer.sendChatMessage("~s~" + player.name, message);
                }
            }
        }
    }
}
