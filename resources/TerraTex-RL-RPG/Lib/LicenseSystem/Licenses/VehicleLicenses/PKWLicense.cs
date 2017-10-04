using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class PkwLicense : VehicleLicense
    {
        public override VehicleHash[] ExcludedVehicleHashes { get; } =
        {
            VehicleHash.Limo2
        };
        public override VehicleHash[] AdditionalVehicleHashes { get; } =
        {
            // Emergency Vehicles
            VehicleHash.Ambulance, VehicleHash.FBI, VehicleHash.FBI2, VehicleHash.Police, VehicleHash.Police2, VehicleHash.Police3, VehicleHash.Police4, 
            VehicleHash.PoliceOld1, VehicleHash.PoliceOld2, VehicleHash.PoliceT, VehicleHash.Pranger, VehicleHash.Riot, VehicleHash.Sheriff, VehicleHash.Sheriff2, 

            // Industrial
            VehicleHash.Guardian, 

            // Military
            VehicleHash.Crusader, 

            // Off-Road
            VehicleHash.BfInjection, VehicleHash.Bifta, VehicleHash.Bodhi2, VehicleHash.Brawler, VehicleHash.DLoader, VehicleHash.Dune, VehicleHash.Dune2, 
            VehicleHash.Dune3, VehicleHash.Insurgent2, VehicleHash.Kalahari, VehicleHash.Lguard, VehicleHash.Mesa, VehicleHash.Mesa2, VehicleHash.Mesa3, 
            VehicleHash.Nightshark, VehicleHash.RancherXL, VehicleHash.RancherXL2, VehicleHash.Rebel, VehicleHash.Rebel2, VehicleHash.Sandking, VehicleHash.Sandking2, 
            VehicleHash.Trophytruck, VehicleHash.Trophytruck2,

            // Service
            VehicleHash.Taxi, 

            // Utility
            VehicleHash.Airtug, VehicleHash.Caddy, VehicleHash.Caddy2, VehicleHash.Caddy3, VehicleHash.Mower, VehicleHash.Sadler, VehicleHash.UtilliTruck3

        };

        public override string GetHumanReadableName()
        {
            return "PKW-Führerschein";
        }

        public override string GetHumanReadableDescription()
        {
            return "Dieser Führerschein erlaubt das führen eines Personenkraftwagens.";
        }

        public override VehicleClass[] CoveredVehicleClasses { get; } =
        {
            VehicleClass.Compacts, 
            VehicleClass.Coupes, 
            VehicleClass.Muscle, 
            VehicleClass.SUVs, 
            VehicleClass.Sedans, 
            // Sports Classic
            VehicleClass.Sports, 
            // Sports
            VehicleClass.Sports2, 
            VehicleClass.Vans
        };

        public override int GetMinRequiredLevel()
        {
            return 0;
        }

        public override string GetLicenseIdentifierName()
        {
            return "vehicle-pkw";
        }

        public override float GetLicensePrice()
        {
            return 4000.00f;
        }
    }
}