using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class QuadLicense : VehicleLicense
    {
        protected new VehicleHash[] AdditionalVehicleHashes =
        {
            // Off-Road
            VehicleHash.Blazer, VehicleHash.Blazer2, VehicleHash.Blazer3, VehicleHash.Blazer5, VehicleHash.Blazer4

        };

        protected new VehicleClass[] CoveredVehicleClasses =
        {
        };

        public override int GetMinRequiredLevel()
        {
            return 0;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-quad";
        }

        public override float GetLicensePrice()
        {
            return 1000.00f;
        }
    }
}