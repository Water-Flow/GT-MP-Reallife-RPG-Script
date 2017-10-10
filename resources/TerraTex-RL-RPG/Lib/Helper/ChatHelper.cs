using System.Text;
using GrandTheftMultiplayer.Server.Elements;

namespace TerraTex_RL_RPG.Lib.Helper
{
    public static class ChatHelper
    {
        public static void SendChatNotificationToPlayer(Client player, string title, string content)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='htmlChatEntry'>");
            sb.Append("<span style='font-weight:bold; text-decoration: underline'>");
            sb.Append(title);
            sb.Append("</span><br/>");
            sb.Append(content);
            sb.Append("</div>");
            
            player.triggerEvent("addHtmlMessage", sb.ToString());
        }
    }
}