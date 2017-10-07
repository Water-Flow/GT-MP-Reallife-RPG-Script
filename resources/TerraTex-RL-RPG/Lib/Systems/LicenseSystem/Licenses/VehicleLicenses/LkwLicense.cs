using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.Systems.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.Systems.LicenseSystem.VehicleLicenses
{
    public class LkwLicense : VehicleLicense
    {
        public override VehicleHash[] ExcludedVehicleHashes { get; } = { };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
            // Emergency
            VehicleHash.Ambulance,

            // Industrial
            VehicleHash.Flatbed, VehicleHash.Mixer, VehicleHash.Mixer2, VehicleHash.Rubble, VehicleHash.TipTruck, VehicleHash.TipTruck2, 

            // Military
            VehicleHash.Barracks, VehicleHash.Barracks2, VehicleHash.Barracks3, 

            // Service
            VehicleHash.Brickade, VehicleHash.Rallytruck, VehicleHash.Trash, VehicleHash.Trash2, 

            // Utility
            VehicleHash.Docktug, VehicleHash.Ripley, VehicleHash.Scrap, VehicleHash.TowTruck, VehicleHash.TowTruck2, VehicleHash.UtilliTruck, VehicleHash.UtilliTruck3
        };

        public override string GetHumanReadableName()
        {
            return "LKW-Führerschein";
        }

        public override string GetHumanReadableDescription()
        {
            return "Dieser Führerschein erlaubt das führen von Lastkraftwagen.";
        }

        public override VehicleClass[] CoveredVehicleClasses { get; } =
        {
            VehicleClass.Commercial,
        };

        public override int GetMinRequiredLevel()
        {
            return 5;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-lkw";
        }

        public override float GetLicensePrice()
        {
            return 10000.00f;
        }
    }
}