using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class PlaneLicense : VehicleLicense
    {
        protected new int[] AdditionalVehicleHashes =
        {
        };

        protected new VehicleClass[] CoveredVehicleClasses =
        {
            VehicleClass.Planes
        };

        public override int GetMinRequiredLevel()
        {
            return 15;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-planes";
        }

        public override float GetLicensePrice()
        {
            return 150000.00f;
        }
    }
}