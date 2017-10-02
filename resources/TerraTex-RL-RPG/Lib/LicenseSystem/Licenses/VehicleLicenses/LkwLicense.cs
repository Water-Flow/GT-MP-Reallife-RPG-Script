using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class LkwLicense : VehicleLicense
    {
        protected new VehicleHash[] AdditionalVehicleHashes =
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

        protected new VehicleClass[] CoveredVehicleClasses =
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