using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class BikeLicense : VehicleLicense
    {
        protected new VehicleHash[] AdditionalVehicleHashes =
        {
            // Emergency Vehicles
            VehicleHash.Policeb
        };

        protected new VehicleClass[] CoveredVehicleClasses =
        {
            VehicleClass.Motorcycles

        };

        public override int GetMinRequiredLevel()
        {
            return 0;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-bike";
        }

        public override float GetLicensePrice()
        {
            return 4500.00f;
        }
    }
}