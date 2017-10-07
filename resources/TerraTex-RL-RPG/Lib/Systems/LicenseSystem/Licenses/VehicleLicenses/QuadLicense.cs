using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.Systems.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.Systems.LicenseSystem.VehicleLicenses
{
    public class QuadLicense : VehicleLicense
    {
        public override VehicleHash[] ExcludedVehicleHashes { get; } = { };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
            // Off-Road
            VehicleHash.Blazer, VehicleHash.Blazer2, VehicleHash.Blazer3, VehicleHash.Blazer5, VehicleHash.Blazer4

        };

        public override VehicleClass[] CoveredVehicleClasses { get; } =
        {
        };

        public override string GetHumanReadableName()
        {
            return "Quadführerschein";
        }

        public override string GetHumanReadableDescription()
        {
            return "Dieser Führerschein erlaubt das fahren von Quads im öffentlichen Straßenverkehr.";
        }

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