using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class PlaneLicense : VehicleLicense
    {
        public override VehicleHash[] ExcludedVehicleHashes { get; } = { };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
        };

        public override VehicleClass[] CoveredVehicleClasses { get; } =
        {
            VehicleClass.Planes
        };

        public override string GetHumanReadableName()
        {
            return "Flugzeuglizenz";
        }

        public override string GetHumanReadableDescription()
        {
            return "Diese Lizenz erlaubt das fliegen von Flugzeugen.";
        }

        public override int GetMinRequiredLevel()
        {
            return 15;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-planes";
        }

        public override float GetLicensePrice()
        {
            return 150000.00f;
        }
    }
}