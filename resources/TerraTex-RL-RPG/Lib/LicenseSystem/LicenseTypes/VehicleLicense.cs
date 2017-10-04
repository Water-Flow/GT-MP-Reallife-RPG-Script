using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;

namespace TerraTex_RL_RPG.Lib.LicenseSystem.LicenseTypes
{
    public abstract class VehicleLicense : ILicense
    {
        public abstract VehicleHash[] ExcludedVehicleHashes { get; }
        public abstract VehicleHash[] AdditionalVehicleHashes { get; }
        public abstract VehicleClass[] CoveredVehicleClasses { get; }

        public bool IsVehicleCoveredByThisLicense(VehicleHash vehicleHash)
        {
            if (Array.IndexOf(ExcludedVehicleHashes, vehicleHash) > -1)
            {
                return false;
            }
            if (Array.IndexOf(CoveredVehicleClasses, (VehicleClass) API.shared.getVehicleClass(vehicleHash)) > -1)
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
        public abstract string GetHumanReadableName();
        public abstract string GetHumanReadableDescription();
        public abstract float GetLicensePrice();
    }
}