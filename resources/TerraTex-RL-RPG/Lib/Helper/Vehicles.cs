﻿using System;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace TerraTex_RL_RPG.Lib.Helper
{
    static class VehiclesHelper
    {
        public static Vehicle CreateVehicleIdleRespawn(VehicleHash hash, Vector3 pos, Vector3 rot, int respawnMinutes = 10,
            int color1 = 0, int color2 = 0, int dim = 0)
        {
            VehicleHash vehicleHash = hash;
            Vehicle veh = TTRPG.Api.createVehicle(vehicleHash, pos, rot, color1, color2, dim);
            veh.setSyncedData("MaxIdleTime", respawnMinutes * 60000);
            veh.setSyncedData("SpawnPosition", pos);
            veh.setSyncedData("SpawnRotation", rot);
            veh.setData("last-driver-name", "");
            veh.setData("last-driver-id", -1);
            veh.setData("last-driver-time", DateTime.Now);
            veh.setData("last-death-time", DateTime.Now);
            veh.engineStatus = false;
            return veh;
        }

        public static Vehicle CreateVehicleWithDefaultData(VehicleHash hash, Vector3 pos, Vector3 rot, int color1 = 0,
            int color2 = 0, int dim = 0)
        {
            VehicleHash vehicleHash = hash;
            Vehicle veh = TTRPG.Api.createVehicle(vehicleHash, pos, rot, color1, color2, dim);
            veh.setSyncedData("MaxIdleTime", -1);
            veh.setSyncedData("SpawnPosition", pos);
            veh.setSyncedData("SpawnRotation", rot);
            veh.setData("last-driver-name", "");
            veh.setData("last-driver-id", -1);
            veh.setData("last-driver-time", DateTime.Now);
            veh.setData("last-death-time", DateTime.Now);
            veh.engineStatus = false;

            return veh;
        }

        public static void RespawnVehicle(Vehicle veh, bool repair)
        {
            if (veh.health <= 0 && repair)
            {
                Vehicle newVeh = TTRPG.Api.createVehicle((VehicleHash) veh.model, (Vector3) veh.getSyncedData("SpawnPosition"), (Vector3) veh.getSyncedData("SpawnRotation"), veh.primaryColor, veh.secondaryColor, veh.dimension);

                string[] allData = TTRPG.Api.getAllEntityData(veh);
                string[] allSyncedData = TTRPG.Api.getAllEntitySyncedData(veh);

                foreach (string key in allData)
                {
                    newVeh.setData(key, veh.getData(key));
                }

                foreach (string key in allSyncedData)
                {
                    newVeh.setSyncedData(key, veh.getSyncedData(key));
                }

                veh.delete();
                veh = newVeh;
            }

            if (repair)
            {
                veh.repair();
            }

            veh.position = (Vector3) veh.getSyncedData("SpawnPosition");
            veh.rotation = (Vector3) veh.getSyncedData("SpawnRotation");
        }

        public static double GetDistanceToSpawnLocation(Entity veh)
        {
            Vector3 spawn = (Vector3) veh.getSyncedData("SpawnPosition");
            
            return spawn.DistanceTo(veh.position);
        }
    }
}