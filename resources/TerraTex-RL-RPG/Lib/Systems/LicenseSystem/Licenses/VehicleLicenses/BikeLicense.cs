using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.Systems.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.Systems.LicenseSystem.VehicleLicenses
{
    public class BikeLicense : VehicleLicense
    {
        public override VehicleHash[] ExcludedVehicleHashes { get; } = { };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
            // Emergency Vehicles
            VehicleHash.Policeb
        };

        public override VehicleClass[] CoveredVehicleClasses { get; } =
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

        public override string GetHumanReadableName()
        {
            return "Motorradführerschein";
        }

        public override string GetHumanReadableDescription()
        {
            return "Dieser Führerschein wird zum führen eines Motorrades benötigt.";
        }

        public override float GetLicensePrice()
        {
            return 4500.00f;
        }
    }
}