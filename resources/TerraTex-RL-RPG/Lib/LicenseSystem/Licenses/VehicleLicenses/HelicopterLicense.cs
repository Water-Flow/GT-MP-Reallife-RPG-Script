using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class HelicopterLicense : VehicleLicense
    {
        protected new VehicleHash[] AdditionalVehicleHashes =
        {
            VehicleHash.Polmav
        };

        protected new VehicleClass[] CoveredVehicleClasses =
        {
            VehicleClass.Helicopters15,
        };

        public override int GetMinRequiredLevel()
        {
            return 15;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-helicopter";
        }

        public override float GetLicensePrice()
        {
            return 100000.00f;
        }
    }
}