using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.Systems.LicenseSystem.LicenseTypes;
using TerraTex_RL_RPG.Lib.Systems.LicenseSystem.VehicleLicenses;

namespace TerraTex_RL_RPG.Lib.Systems.LicenseSystem
{
    public static class Licenses
    {
        private static List<ILicense> licenses = new List<ILicense>();

        public static void Init()
        {
            // create instances of all licenses
            licenses.Add(new BikeLicense());
            licenses.Add(new BoatLicense());
            licenses.Add(new BusLicense());
            licenses.Add(new HelicopterLicense());
            licenses.Add(new IndustrialLicense());
            licenses.Add(new LkwLicense());
            licenses.Add(new MilitaryLicense());
            licenses.Add(new PkwLicense());
            licenses.Add(new PlaneLicense());
            licenses.Add(new QuadLicense());
            licenses.Add(new RacingPkwLicense());
            licenses.Add(new StuntVehicleLicense());
        }

        /// <summary>
        /// Checks if vehicle is useable by the user
        /// Info: It Adds additional to the return Value an EnitiyData to the player named "missedLicenses" if there are some missing!
        /// </summary>
        /// <param name="player">The User</param>
        /// <param name="veh">The Vehicle</param>
        /// <returns></returns>
        public static bool CanUseVehicle(Client player, Vehicle veh, bool saveMissed = false)
        {
            return CanUseVehicle(player, (VehicleHash) veh.model, saveMissed);
        }

        /// <summary>
        /// Is Entity by Nethandle useable by the user
        /// Info: It Adds additional to the return Value an EnitiyData to the player named "missedLicenses" if there are some missing!
        /// </summary>
        /// <param name="player"> The User</param>
        /// <param name="entityHandle">The Entity by NetHandle</param>
        /// <returns></returns>
        public static bool CanUseVehicle(Client player, NetHandle entityHandle, bool saveMissed = false)
        {
            Vehicle veh = API.shared.getEntityFromHandle<Vehicle>(entityHandle);
            return CanUseVehicle(player, (VehicleHash) veh.model, saveMissed);
        }

        /// <summary>
        /// Is Vehicle Entity by Hash useable by the user
        /// Info: It Adds additional to the return Value an EnitiyData to the player named "missedLicense" if there are some missing and save missed is true!
        /// </summary>
        /// <param name="player">The User</param>
        /// <param name="hash">The Entity by Hash</param>
        /// <returns></returns>
        public static bool CanUseVehicle(Client player, VehicleHash hash, bool saveMissed = false)
        {
            if ((VehicleClass) API.shared.getVehicleClass(hash) == VehicleClass.Cycles)
            {
                return true;
            }
            VehicleHash[] faggios = { VehicleHash.Faggio, VehicleHash.Faggio2, VehicleHash.Faggio3};
            if (Array.IndexOf(faggios, hash) > -1)
            {
                return true;
            }
            
            List<ILicense> userLicenses = (List<ILicense>)player.getData("UserLicenses");
            foreach (ILicense lic in userLicenses)
            {
                var memberInfo = lic.GetType().BaseType;
                if (memberInfo != null && memberInfo.Name.Equals("VehicleLicense"))
                {
                    if (((VehicleLicense) lic).IsVehicleCoveredByThisLicense(hash))
                    {
                        return true;
                    }
                }
            }

            if (saveMissed)
            {
                SetPlayerMissedVehicleLicenses(player, hash);
            }
            return false;
        }

        private static void SetPlayerMissedVehicleLicenses(Client player, VehicleHash hash)
        {
            foreach (ILicense license in licenses)
            {
                var memberInfo = license.GetType().BaseType;
                if (memberInfo != null && memberInfo.Name.Equals("VehicleLicense"))
                {
                    if (((VehicleLicense)license).IsVehicleCoveredByThisLicense(hash))
                    {
                        player.setData("MissedLicense", license);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Is Weapon Entity by Hash useable by the user
        /// Info: It Adds additional to the return Value an EnitiyData to the player named "missedLicenses" if there are some missing!
        /// </summary>
        /// <param name="player">The User</param>
        /// <param name="hash">The Entity by Hash</param>
        /// <returns></returns>
        public static bool CanUseWeapon(Client player, int hash)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is Feature useable by player with his current Licenses
        /// Info: It Adds additional to the return Value an EnitiyData to the player named "missedLicenses" if there are some missing!
        /// </summary>
        /// <param name="player">The User</param>
        /// <param name="feature">Feature Identity String</param>
        /// <returns></returns>
        public static bool CanUse(Client player, string feature)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Has User license by identifier string
        /// </summary>
        /// <param name="player">The User</param>
        /// <param name="licenseIdentifier">License Name</param>
        /// <returns></returns>
        public static bool HasLicense(Client player, string licenseIdentifier)
        {
            List<ILicense> userLicenses = (List<ILicense>) player.getData("UserLicenses");
            foreach (ILicense lic in userLicenses)
            {
                if (lic.GetLicenseIdentifierName().Equals(licenseIdentifier))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get All Licenses
        /// </summary>
        /// <returns></returns>
        public static List<ILicense> GetAllLicenses()
        {
            return licenses;
        }

        /// <summary>
        /// Get License by Identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns>License or Null if there is not such license</returns>
        public static ILicense GetLicenseByIdentifier(string identifier)
        {
            foreach (ILicense license in licenses)
            {
                if (license.GetLicenseIdentifierName().Equals(identifier))
                {
                    return license;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a list of all licenses that can be bought by specific level
        /// </summary>
        /// <param name="level">The Level</param>
        /// <returns></returns>
        public static List<ILicense> GetLicensesByLevel(int level)
        {
            List<ILicense> levelBasedList = new List<ILicense>();
            foreach (ILicense license in licenses)
            {
                if (license.GetMinRequiredLevel() <= level)
                {
                    levelBasedList.Add(license);
                }
            }

            return levelBasedList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static List<String> GetUserLicensesIndentifiers(Client player)
        {
            List<ILicense> userLicenses = (List<ILicense>)player.getData("UserLicenses");
            List<string> ownedLicenses = new List<string>();
            foreach (ILicense lic in userLicenses)
            {
                ownedLicenses.Add(lic.GetLicenseIdentifierName());
            }
            return ownedLicenses;
        }
    }
}