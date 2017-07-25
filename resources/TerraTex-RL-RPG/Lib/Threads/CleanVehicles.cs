using System;
using System.Collections.Generic;
using System.Threading;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using TerraTex_RL_RPG.Lib.Helper;

namespace TerraTex_RL_RPG.Lib.Threads
{
    public class CleanVehicles
    {
        private bool _interuped = false;

        public void DoWork()
        {
            TTRPG.Api.consoleOutput("Started Clean Vehicles Thread");

            while (!_interuped)
            {
                List<NetHandle> vehicles = TTRPG.Api.getAllVehicles();
                foreach (NetHandle handle in vehicles)
                {
                    Vehicle veh = TTRPG.Api.getEntityFromHandle<Vehicle>(handle);

                    if (veh.occupants.Length == 0 && veh.health > 0 && (int) veh.getSyncedData("MaxIdleTime") != -1)
                    {
                        // Idle
                        int maxIdleTime = (int) veh.getSyncedData("MaxIdleTime");
                        DateTime lastUsage = (DateTime) veh.getData("last-driver-time");

                        if (DateTime.Now.Subtract(lastUsage).TotalMilliseconds >= maxIdleTime)
                        {
                            VehiclesHelper.RespawnVehicle(veh, true);
                        }
                    }
                    else if (veh.health <= 0)
                    {
                        int maxIdleTime = (int)veh.getSyncedData("MaxIdleTime");
                        DateTime lastUsage = (DateTime)veh.getData("last-death-time");

                        // destroyed
                        if ((int) veh.getSyncedData("MaxIdleTime") != -1 &&
                            DateTime.Now.Subtract(lastUsage).TotalMilliseconds >= maxIdleTime)
                        {
                            VehiclesHelper.RespawnVehicle(veh, true);
                        }
                        else if (DateTime.Now.Subtract(lastUsage).TotalMilliseconds >= 300000)
                        {
                            veh.delete();
                        }
                    }

                }


                // Run Thread only every Minutes
                Thread.Sleep(60000);
            }
        }
        
        public void StopThread()
        {
            _interuped = true;
        }
    }
}