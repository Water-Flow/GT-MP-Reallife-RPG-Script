using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class BusLicense : VehicleLicense
    {
        public override VehicleHash[] ExcludedVehicleHashes { get; } = { };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
            VehicleHash.PBus,
            VehicleHash.Airbus,
            VehicleHash.Bus,
            VehicleHash.RentalBus,
            VehicleHash.Tourbus,
            VehicleHash.Coach
        };

        public override string GetHumanReadableName()
        {
            return "Busführerschein";
        }

        public override string GetHumanReadableDescription()
        {
            return "Dieser Führerschein erlaubt das fahren eines Busses und das Transportieren einer größeren Passagiermenge im öffentlichen Straßenverkehr.";
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
            return "vehicle-bus";
        }

        public override float GetLicensePrice()
        {
            return 10000.00f;
        }
    }
}