﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using TerraTex_RL_RPG.Lib.Threads;

namespace TerraTex_RL_RPG.Lib.Admin
{
    class ShutdownAndRestart : Script
    {
        public ShutdownAndRestart()
        {
            API.onResourceStop += OnResourceStopHandler;
            ConsoleReader.OnConsoleMessageEvent += OnConsoleMessage;
        }

        private void OnConsoleMessage(string cmd, string[] infos)
        {
            if (cmd.Equals("shutdown"))
            {
                int timeInMinutes = Int32.Parse(infos.Length > 0 ? infos[0] : "0");
                string reason = "UNKNOWN";
                if (infos.Length > 1)
                {
                    reason = string.Join(" ", infos.Skip(1).ToArray());
                }

                InitShutdown("Console", timeInMinutes, reason);
            }
        }

        private void OnResourceStopHandler()
        {
            API.consoleOutput("shutdown init");
            //@todo: create stopfile
        }

        public void InitShutdown(string admin, int timeInMinutes, string reason)
        {
            if (timeInMinutes <= 1)
            {
                API.stopResource(API.getThisResource());
            }
            else
            {
                //@todo: timer
            }
        }

        [Command("shutdown", Group = "admin", SensitiveInfo = false, GreedyArg = true)]
        public void SaveAndMarkCommand(Client player, int timeInMinutes, string info = "")
        {
            if (AdminChecks.CheckAdminLvl(player, 4))
            {
                InitShutdown(player.name, timeInMinutes, info);
            }
        }
    }
}
