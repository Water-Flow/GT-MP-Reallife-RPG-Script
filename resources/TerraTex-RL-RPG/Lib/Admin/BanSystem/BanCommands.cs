using System;
using System.Globalization;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using TerraTex_RL_RPG.Lib.Helper;

namespace TerraTex_RL_RPG.Lib.Admin.BanSystem
{
    public class BanCommands : Script
    {

        [Command("ban", Group = "admin", SensitiveInfo = false, GreedyArg = true)]
        public void BanCommand(Client admin, string playerNameOrId, string reason)
        {
            if (AdminChecks.CheckAdminLvl(admin, 2))
            {
                Client player;
                if (int.TryParse(playerNameOrId, out int result))
                {
                    player = PlayerHelper.GetPlayerById(result);
                }
                else
                {
                    player = PlayerHelper.GetPlayerByPartialNickname(playerNameOrId);
                }

                if (player == null)
                {
                    admin.sendNotification("~r~Error", "Dieser Spieler existiert nicht!");
                    return;
                }

                BanSystem.AddBanByAdmin(player, admin, reason, null);
            }
        }

        /// <summary>
        /// Timeban
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="playerNameOrId"></param>
        /// <param name="time">time &lt; 0 => Minutes | time > 0 => Hours </param>
        /// <param name="reason"></param>
        [Command("tban", Group = "admin", SensitiveInfo = false, GreedyArg = true)]
        public void TimeBanCommand(Client admin, string playerNameOrId, string time, string reason)
        {
            if (AdminChecks.CheckAdminLvl(admin, 2))
            {
                Client player;
                if (int.TryParse(playerNameOrId, out int result))
                {
                    player = PlayerHelper.GetPlayerById(result);
                }
                else
                {
                    player = PlayerHelper.GetPlayerByPartialNickname(playerNameOrId);
                }
                try
                {
                    TimeSpan ts = Timehelper.GetTimeSpanFromTimeString(time);
                    
                    DateTime dt = new DateTime();
                    dt = dt.Add(ts);
                    BanSystem.AddBanByAdmin(player, admin, reason, dt);
                }
                catch (TimeHelperException)
                {
                    admin.sendNotification("~r~Error", time + " ist kein valider Timestring.");
                }
            }
        }
    }
}