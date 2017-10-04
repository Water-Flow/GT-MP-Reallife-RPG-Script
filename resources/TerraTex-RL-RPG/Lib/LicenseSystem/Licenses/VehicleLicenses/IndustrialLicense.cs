using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class IndustrialLicense : VehicleLicense
    {
        public override VehicleHash[] ExcludedVehicleHashes { get; } = { };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
            // Industrial
            VehicleHash.Bulldozer,
            VehicleHash.Cutter,
            VehicleHash.Dump,
            VehicleHash.Handler,

            // Utility
            VehicleHash.Forklift,
            VehicleHash.Tractor,
            VehicleHash.Tractor2,
            VehicleHash.Tractor3
        };

        public override string GetHumanReadableDescription()
        {
            return "Diese Lizenz erlaubt die Nutzung und Steuerung größeren Industriemaschinen und -fahrzeugen.";
        }

        public override string GetHumanReadableName()
        {
            return "Industriemaschinenlizenz";
        }

        public override VehicleClass[] CoveredVehicleClasses { get; } =
        {
        };

        public override int GetMinRequiredLevel()
        {
            return 5;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-industrial";
        }

        public override float GetLicensePrice()
        {
            return 10000.00f;
        }
    }
}