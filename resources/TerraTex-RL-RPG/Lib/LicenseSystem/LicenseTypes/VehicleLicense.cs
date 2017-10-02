using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes
{
    public abstract class VehicleLicense : ILicense
    {
        protected VehicleHash[] AdditionalVehicleHashes =
        {

        };

        protected VehicleClass[] CoveredVehicleClasses =
        {

        };

        public bool IsVehicleCoveredByThisLicense(VehicleHash vehicleHash)
        {
            if (Array.IndexOf(CoveredVehicleClasses, API.shared.getVehicleClass(vehicleHash)) > -1)
            {
                return true;
            }
            if (Array.IndexOf(AdditionalVehicleHashes, vehicleHash) > -1)
            {
                return true;
            }

            return false;
        }

        public bool IsVehicleCoveredByThisLicense(NetHandle vehicleHandle)
        {
            Vehicle veh = API.shared.getEntityFromHandle<Vehicle>(vehicleHandle);
            return IsVehicleCoveredByThisLicense((VehicleHash) veh.model);
        }

        public bool IsVehicleCoveredByThisLicense(Vehicle vehicle)
        {
            return IsVehicleCoveredByThisLicense((VehicleHash) vehicle.model);
        }

        public abstract int GetMinRequiredLevel();
        public abstract string GetLicenseIdentifierName();
        public abstract float GetLicensePrice();
    }
}