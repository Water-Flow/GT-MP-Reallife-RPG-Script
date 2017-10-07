using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.Systems.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.Systems.LicenseSystem.VehicleLicenses
{
    public class MilitaryLicense : VehicleLicense
    {
        public override VehicleHash[] ExcludedVehicleHashes { get; } = { };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
            VehicleHash.APC, VehicleHash.Halftrack, VehicleHash.Rhino, VehicleHash.Insurgent3, VehicleHash.Insurgent,
            VehicleHash.Technical, VehicleHash.Technical2, VehicleHash.Technical3, VehicleHash.Limo2
        };

        public override VehicleClass[] CoveredVehicleClasses { get; } =
        {
        };

        public override string GetHumanReadableName()
        {
            return "Militärlizenz";
        }

        public override string GetHumanReadableDescription()
        {
            return "Diese Lizenz erlaubt die Nutzung von bewaffneten Fahrzeugen und Maschinen.";
        }

        public override int GetMinRequiredLevel()
        {
            return 5;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-military";
        }

        public override float GetLicensePrice()
        {
            return 250000.00f;
        }
    }
}