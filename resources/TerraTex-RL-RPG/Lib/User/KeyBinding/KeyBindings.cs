using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using TerraTex_RL_RPG.Lib.Vehicles;

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
                string json = (string) arguments[0];
                player.setSyncedData("KeyBindings", json);
            }
            else if (eventName == "runKeyBindingFunction")
            {
                if (arguments[0].Equals("ToggleEngine"))
                {
                    if (player.isInVehicle && player.vehicleSeat == 0)
                    {
                        VehicleFunction.ToggleEngine(player.vehicle);
                    }
                }
            }
        }
    }
}