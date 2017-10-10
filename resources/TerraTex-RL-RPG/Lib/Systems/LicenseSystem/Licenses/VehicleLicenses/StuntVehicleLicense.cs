using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.Systems.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.Systems.LicenseSystem.VehicleLicenses
{
    public class StuntVehicleLicense : VehicleLicense
    {

        public override VehicleHash[] ExcludedVehicleHashes { get; } = { };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
            // Off-Road
            VehicleHash.Dune4, VehicleHash.Dune5, VehicleHash.Marshall, VehicleHash.Monster

        };

        public override string GetHumanReadableName()
        {
            return "Stuntlizenz";
        }

        public override string GetHumanReadableDescription()
        {
            return "Diese Lizenz erlaubt das fahren von Fahrzeugen, die zum Zwecke von Stunts gebaut wurden.";
        }

        public override VehicleClass[] CoveredVehicleClasses { get; } =
        {
        };

        public override int GetMinRequiredLevel()
        {
            return 30;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-stunt";
        }

        public override float GetLicensePrice()
        {
            return 100000.00f;
        }
    }
}