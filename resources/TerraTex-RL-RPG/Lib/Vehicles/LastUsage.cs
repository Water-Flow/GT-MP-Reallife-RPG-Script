using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;

namespace TerraTex_RL_RPG.Lib.Vehicles
{
    public class LastUsage : Script
    {
        public LastUsage()
        {
            API.onPlayerExitVehicle += OnPlayerExitVehicleHandler;
            API.onVehicleDeath += OnVehicleDeathHandler;
        }

        private void OnPlayerExitVehicleHandler(Client player, NetHandle vehicle)
        {
            Vehicle veh = TTRPG.Api.getEntityFromHandle<Vehicle>(vehicle);

            veh.setData("last-driver-name", player.name);
            veh.setData("last-driver-id", player.getSyncedData("ID"));
            veh.setData("last-driver-time", DateTime.Now);
        }

        private void OnVehicleDeathHandler(NetHandle vehicle)
        {
            Vehicle veh = TTRPG.Api.getEntityFromHandle<Vehicle>(vehicle);
            veh.setData("last-death-time", DateTime.Now);
        }
    }
}