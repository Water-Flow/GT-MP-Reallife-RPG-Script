using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using TerraTex_RL_RPG.Lib.Threads;

namespace TerraTex_RL_RPG.Lib.Admin
{
    public class GeneralConsoleCommands : Script
    {
        public GeneralConsoleCommands()
        {
            ConsoleReader.OnConsoleMessageEvent += OnConsoleMessage;
        }

        private void OnConsoleMessage(string cmd, string[] infos)
        {
            switch (cmd)
            {
                case "players":
                    PlayersCmd();
                    break;
            }
        }

        private void PlayersCmd()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Players Online ");
            
            int maxPlayers = API.getMaxPlayers();
            List<Client> clients = API.getAllPlayers();

            sb.Append(clients.Count + "/" + maxPlayers + ": ");

            foreach (Client client in clients)
            {
                sb.Append(client.name);
                if (clients.Last() != client)
                {
                    sb.Append(", ");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}