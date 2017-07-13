using System;
using System.Collections.Generic;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading;
using GrandTheftMultiplayer.Server.Elements;
using Newtonsoft.Json.Linq;
using TerraTex_RL_RPG.Lib.User.Management;

namespace TerraTex_RL_RPG.Lib.Threads
{
    public class UpdatePlayerPlayTime
    {
        private bool _interuped = false;

        public void DoWork()
        {
            TTRPG.Api.consoleOutput("Started Update Player PlayTime Thread");

            while (!_interuped)
            {
                List<Client> players = TTRPG.Api.getAllPlayers();

                foreach (Client player in players)
                {
                    if (player.hasSyncedData("loggedin") && (bool)player.getSyncedData("loggedin"))
                    {
                        player.setSyncedData("PlayTime", player.getSyncedData("PlayTime") + 1);

                        UpdatePlayerPlayTimeDisplay(player);
                        // Add one RP for playtime
                        RpLevelManager.AddRpToPlayer(player, 1, false);

                        if (player.getSyncedData("PlayTime") % 60 == 0)
                        {
                            SendPayDay(player);
                        }
                    }
                }

                Thread.Sleep(60000);
            }
        }

        public static void UpdatePlayerPlayTimeDisplay(Client player)
        {
            int playTime = player.getSyncedData("PlayTime");

            // format PlayTime for ScoreBoard
            StringBuilder sbd = new StringBuilder();

            int hours = playTime / 60;
            sbd.Append(hours);
            sbd.Append(" | ");
            int minutes = playTime - hours * 60;
            sbd.Append(minutes.ToString("D2"));

            TTRPG.Api.exported.scoreboard.setPlayerScoreboardData(player, "PlayTime", sbd.ToString());
        }

        public static void SendPayDay(Client player)
        {

            // Add additional 10 RP for each PayDay
            RpLevelManager.AddRpToPlayer(player, 10, false);

            Dictionary<string, double> income = player.getSyncedData("PayDayIncome");
            Dictionary<string, double> outgoings = player.getSyncedData("PayDayOutgoings");

            double sum = 0;

            foreach (KeyValuePair<string, double> value in income)
            {
                sum += value.Value;
            }

            foreach (KeyValuePair<string, double> value in outgoings)
            {
                sum -= value.Value;
            }

            Dictionary<string, Dictionary<string, double>> payDay = new Dictionary<string, Dictionary<string, double>>();
            payDay.Add("Income", player.getSyncedData("PayDayIncome"));
            payDay.Add("Outgoings", player.getSyncedData("PayDayOutgoings"));

            MoneyManager.ChangePlayerMoney(player, (float) sum, true, MoneyManager.Categorys.PayDay, "PayDay", JObject.FromObject(payDay).ToString());

            if (sum >= 0)
            {
                TTRPG.Api.sendNotificationToPlayer(player, "Zahltag! Dir wurden ~g~" + sum + " €~s~ überwiesen.");
            } 
            else
            {
                TTRPG.Api.sendNotificationToPlayer(player, "Zahltag! Dir wurden ~r~" + sum + " €~s~ abgezogen.");
            }

            player.setSyncedData("LastPayDayIncome", income);
            player.setSyncedData("LastPayDayOutgoings", outgoings);
            income.Clear();
            outgoings.Clear();
            player.setSyncedData("PayDayIncome", income);
            player.setSyncedData("PayDayOutgoings", outgoings);
        }

        public void StopThread()
        {
            _interuped = true;
        }
    }
}
