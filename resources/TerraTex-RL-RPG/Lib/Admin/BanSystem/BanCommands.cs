using System;
using System.Globalization;
using System.Linq;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using TerraTex_RL_RPG.Lib.Helper;
using TerraTex_RL_RPG.Lib.Threads;

namespace TerraTex_RL_RPG.Lib.Admin.BanSystem
{
    public class BanCommands : Script
    {
        public BanCommands()
        {
            ConsoleReader.OnConsoleMessageEvent += OnConsoleMessage;
        }

        private void OnConsoleMessage(string cmd, string[] infos)
        {
            if (cmd.Equals("tban"))
            {
                if (infos[0].Length < 3)
                {
                    Console.WriteLine("Error! Usage: /tban playernameOrId timestring reason");
                    return;
                }

                Client player = PlayerHelper.GetPlayerFromNameOrId(infos[0]);
                if (player == null)
                {
                    Console.WriteLine("Error! Dieser Spieler existiert nicht!");
                    return;
                }

                try
                {
                    TimeSpan ts = Timehelper.GetTimeSpanFromTimeString(infos[1]);

                    DateTime dt = new DateTime();
                    dt = dt.Add(ts);

                    string reason = String.Join(" ", infos.Skip(2).ToArray());

                    BanSystem.AddBanBySystem(player, "System (Console)", reason, dt);
                }
                catch (TimeHelperException)
                {
                    Console.WriteLine("Error! " + infos[1] + " ist kein valider Timestring.");
                }
            }
            else if (cmd.Equals("ban"))
            {
                if (infos[0].Length < 2)
                {
                    Console.WriteLine("Error! Usage: /ban playernameOrId reason");
                    return;
                }


                Client player = PlayerHelper.GetPlayerFromNameOrId(infos[0]);
                if (player == null)
                {
                    Console.WriteLine("Error! Dieser Spieler existiert nicht!");
                    return;
                }

                string reason = String.Join(" ", infos.Skip(1).ToArray());
                BanSystem.AddBanBySystem(player, "System (Console)", reason, null);
            }
        }

        [Command("ban", Group = "admin", SensitiveInfo = false, GreedyArg = true)]
        public void BanCommand(Client admin, string playerNameOrId, string reason)
        {
            if (AdminChecks.CheckAdminLvl(admin, 2))
            {
                Client player = PlayerHelper.GetPlayerFromNameOrId(playerNameOrId);

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

                Client player = PlayerHelper.GetPlayerFromNameOrId(playerNameOrId);

                if (player == null)
                {
                    admin.sendNotification("~r~Error", "Dieser Spieler existiert nicht!");
                    return;
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