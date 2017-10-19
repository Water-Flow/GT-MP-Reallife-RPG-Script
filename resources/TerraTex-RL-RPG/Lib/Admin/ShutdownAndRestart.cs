using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using TerraTex_RL_RPG.Lib.Admin.Helper;
using TerraTex_RL_RPG.Lib.Helper;
using TerraTex_RL_RPG.Lib.Threads;

namespace TerraTex_RL_RPG.Lib.Admin
{
    class ShutdownAndRestart : Script
    {
        private GmxTimer _gmxTimer;
        private static bool _autoShutdown;
        private static TimeSpan _autoShutdownTime;

        public ShutdownAndRestart()
        {
            API.onResourceStop += OnResourceStopHandler;
            ConsoleReader.OnConsoleMessageEvent += OnConsoleMessage;
            TTRPG.OnTerraTexStartUpFinishedEvent += OnTerraTexStartUpFinishedEvent;
        }

        private void OnTerraTexStartUpFinishedEvent()
        {
            XmlDocument config = TTRPG.Configs.GetConfig("server");
            _autoShutdown = config.GetElementsByTagName("automaticShutDown")[0].InnerText.Equals("true");
            _autoShutdownTime = Timehelper.GetTimeSpanFromTimeString(config.GetElementsByTagName("automaticShutDownTime")[0].InnerText);
        }


        public void Check24HShutdown(DateTime time)
        {
            if (_autoShutdown)
            {
                if (time.Hour == _autoShutdownTime.Hours && time.Minute == _autoShutdownTime.Minutes)
                {
                    InitShutdown("System", 20, "24h Restart");
                }
            }
        }

        private void OnConsoleMessage(string cmd, string[] infos)
        {
            if (cmd.Equals("gmx") || cmd.Equals("shutdown"))
            {
                int timeInMinutes = Int32.Parse(infos.Length > 0 ? infos[0] : "0");
                string reason = "UNKNOWN";
                if (infos.Length > 1)
                {
                    reason = string.Join(" ", infos.Skip(1).ToArray());
                }
                API.consoleOutput("Started Server Shutdown");
                InitShutdown("Console", timeInMinutes, reason);
            }
        }

        private void OnResourceStopHandler()
        {
            API.stopServer();
        }

        public void InitShutdown(string admin, int timeInMinutes, string reason)
        {
            if (timeInMinutes <= 1)
            {
                API.stopResource(API.getThisResource());
            }
            else
            {
                if (_gmxTimer != null)
                {
                    _gmxTimer.Stop();
                    _gmxTimer = null;
                }

                _gmxTimer = new GmxTimer(timeInMinutes, reason);
                _gmxTimer.Start();
            }
        }

        [Command("gmx", Group = "admin", SensitiveInfo = false, GreedyArg = true)]
        public void GmxCommand(Client player, int timeInMinutes, string info = "")
        {
            if (AdminChecks.CheckAdminLvl(player, 4))
            {
                InitShutdown(player.name, timeInMinutes, info);
            }
        }
    }
}
