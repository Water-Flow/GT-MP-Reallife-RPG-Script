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
        public override VehicleHash[] ExcludedVehicleHashes { get; } = { };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
            VehicleHash.Predator
        };

        public override string GetHumanReadableName()
        {
            return "Bootslizenz";
        }

        public override string GetHumanReadableDescription()
        {
            return "Diese Lizenz erlaubt das fahren und führen eines Bootes.";
        }

        public override VehicleClass[] CoveredVehicleClasses { get; } =
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