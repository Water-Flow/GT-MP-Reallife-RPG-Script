using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses
{
    public class MilitaryLicense : VehicleLicense
    {
        protected new VehicleHash[] AdditionalVehicleHashes =
        {
            VehicleHash.APC, VehicleHash.Halftrack, VehicleHash.Rhino, VehicleHash.Insurgent3, VehicleHash.Insurgent,
            VehicleHash.Technical, VehicleHash.Technical2, VehicleHash.Technical3, 
        };

        protected new VehicleClass[] CoveredVehicleClasses =
        {
        };

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