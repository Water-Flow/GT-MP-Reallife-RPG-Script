using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace TerraTex_RL_RPG.Lib.Helper
{
    static class VehiclesHelper
    {
        public static Vehicle CreateVehicleIdleRespawn(string name, Vector3 pos, Vector3 rot, int respawnMinutes = 10,
            int color1 = 0, int color2 = 0, int dim = 0)
        {
            VehicleHash vehicleHash = TTRPG.Api.vehicleNameToModel(name);
            Vehicle veh = TTRPG.Api.createVehicle(vehicleHash, pos, rot, color1, color2, dim);
            veh.setSyncedData("MaxIdleTime", respawnMinutes * 60000);
            veh.setSyncedData("SpawnPosition", pos);
            veh.setSyncedData("SpawnRotation", rot);
            veh.setData("last-driver-name", "");
            veh.setData("last-driver-id", -1);
            veh.setData("last-driver-time", DateTime.Now);
            veh.setData("last-death-time", DateTime.Now);

            return veh;
        }

        public static Vehicle CreateVehicleFromName(string name, Vector3 pos, Vector3 rot, int color1 = 0,
            int color2 = 0, int dim = 0)
        {
            VehicleHash vehicleHash = TTRPG.Api.vehicleNameToModel(name);
            Vehicle veh = TTRPG.Api.createVehicle(vehicleHash, pos, rot, color1, color2, dim);
            veh.setSyncedData("MaxIdleTime", -1);
            veh.setSyncedData("SpawnPosition", pos);
            veh.setSyncedData("SpawnRotation", rot);
            veh.setData("last-driver-name", "");
            veh.setData("last-driver-id", -1);
            veh.setData("last-driver-time", DateTime.Now);
            veh.setData("last-death-time", DateTime.Now);

            return veh;
        }

        public static void RespawnVehicle(Vehicle veh, bool repair)
        {
            if (repair)
            {
                veh.repair();
            }

            veh.position = (Vector3) veh.getSyncedData("SpawnPosition");
            veh.rotation = (Vector3) veh.getSyncedData("SpawnRotation");
        }

        public static double GetDistanceToSpawnLocation(Vehicle veh)
        {
            Vector3 spawn = (Vector3) veh.getSyncedData("SpawnPosition");
            return spawn.DistanceTo(spawn);
        }
    }
}