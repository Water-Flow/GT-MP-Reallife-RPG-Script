using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class BoatLicense : VehicleLicense
    {
        protected new VehicleHash[] AdditionalVehicleHashes =
        {
            VehicleHash.Predator
        };

        protected new VehicleClass[] CoveredVehicleClasses =
        {
            VehicleClass.Boats
        };

        public override int GetMinRequiredLevel()
        {
            return 5;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-boat";
        }

        public override float GetLicensePrice()
        {
            return 7500.00f;
        }
    }
}