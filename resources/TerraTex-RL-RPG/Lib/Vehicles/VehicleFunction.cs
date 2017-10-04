using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using TerraTex_RL_RPG.Lib.LicenseSystem;

namespace TerraTex_RL_RPG.Lib.Vehicles
{
    class VehicleFunction : Script
    {
        public VehicleFunction()
        {
            API.onPlayerEnterVehicle += CheckVehicleLicenses;
        }

        public void CheckVehicleLicenses(Client player, NetHandle vehicle, int seat)
        {
            if (seat == -1)
            {
                if (!Licenses.CanUseVehicle(player, vehicle, true))
                {
                    ILicense lic = (ILicense) player.getData("MissedLicense");
                    API.sendNotificationToPlayer(player, "Du hast nicht die nötige Lizenz (\"" + lic.GetHumanReadableName() + "\") für dieses Fahrzeug!");
                    API.warpPlayerOutOfVehicle(player);
                }
            }
        }

        public static void ToggleEngine(Vehicle handle)
        {
            handle.engineStatus = !handle.engineStatus;
        }
    }
}
