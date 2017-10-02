using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class RacingPkwLicense : VehicleLicense
    {
        protected new int[] AdditionalVehicleHashes =
        {
        };

        protected new VehicleClass[] CoveredVehicleClasses =
        {
            VehicleClass.Super
        };

        public override int GetMinRequiredLevel()
        {
            return 10;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-racing-pkw";
        }

        public override float GetLicensePrice()
        {
            return 40000.00f;
        }
    }
}