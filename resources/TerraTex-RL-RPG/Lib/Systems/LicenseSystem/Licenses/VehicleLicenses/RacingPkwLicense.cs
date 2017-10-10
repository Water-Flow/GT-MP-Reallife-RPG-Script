using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.Systems.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.Systems.LicenseSystem.VehicleLicenses
{
    public class RacingPkwLicense : VehicleLicense
    {
        public override VehicleHash[] ExcludedVehicleHashes { get; } = { };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
        };

        public override VehicleClass[] CoveredVehicleClasses { get; } =
        {
            VehicleClass.Super
        };

        public override string GetHumanReadableName()
        {
            return "Stuntlizenz";
        }

        public override string GetHumanReadableDescription()
        {
            return "Diese Lizenz erlaubt das fahren von Fahrzeugen mit erhöhter Höchstgeschwindigkeit," +
                   " darunter fallen Renn- und Supersportfahrzeuge, im öffentlichen Straßenverkehr.";
        }

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