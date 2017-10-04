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
        public override VehicleHash[] ExcludedVehicleHashes { get; } = { };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
            VehicleHash.Polmav
        };

        public override VehicleClass[] CoveredVehicleClasses { get; } =
        {
            VehicleClass.Helicopters15,
        };

        public override string GetHumanReadableName()
        {
            return "Helicopterlizenz";
        }

        public override string GetHumanReadableDescription()
        {
            return "Diese Lizenz erlaubt das fliegen von Helicoptern.";
        }


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