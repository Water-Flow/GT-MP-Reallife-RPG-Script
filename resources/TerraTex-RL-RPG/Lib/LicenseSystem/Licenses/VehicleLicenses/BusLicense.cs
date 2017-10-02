using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class BusLicense : VehicleLicense
    {
        protected new VehicleHash[] AdditionalVehicleHashes =
        {
            VehicleHash.PBus,
            VehicleHash.Airbus,
            VehicleHash.Bus,
            VehicleHash.RentalBus,
            VehicleHash.Tourbus,
            VehicleHash.Coach
        };

        protected new VehicleClass[] CoveredVehicleClasses =
        {
        };

        public override int GetMinRequiredLevel()
        {
            return 5;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-bus";
        }

        public override float GetLicensePrice()
        {
            return 10000.00f;
        }
    }
}