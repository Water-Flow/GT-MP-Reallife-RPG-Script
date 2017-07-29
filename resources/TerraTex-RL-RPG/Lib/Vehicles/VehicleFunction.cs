using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace TerraTex_RL_RPG.Lib.Vehicles
{
    class VehicleFunction : Script
    {
        public static void ToggleEngine(Vehicle handle)
        {
            handle.engineStatus = !handle.engineStatus;
        }
    }
}
