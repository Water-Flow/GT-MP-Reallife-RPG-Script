using GrandTheftMultiplayer.Server.API;

namespace TerraTex_RL_RPG.Lib.Vehicles
{
    public class RookieSpawnVehicles : Script
    {
        public RookieSpawnVehicles()
        {
            API.onResourceStart += CreateRookieVehicles;
        }

        private void CreateRookieVehicles()
        {
            // @todo: add rookie vehicles here with VehiclesHelper.CreateVehicleIdleRespawn
        }
    }
}