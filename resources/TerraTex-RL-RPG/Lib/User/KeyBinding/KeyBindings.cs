using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace TerraTex_RL_RPG.Lib.User.KeyBinding
{
    class KeyBindings : Script
    {
        public KeyBindings()
        {
            API.onClientEventTrigger += OnClientEvent;
        }

        public void OnClientEvent(Client player, string eventName, params object[] arguments)
        {
            if (eventName == "setNewKeyBindings")
            {
                string json = (string)arguments[0];
                player.setSyncedData("KeyBindings", json);
            }
        }
    }
}
