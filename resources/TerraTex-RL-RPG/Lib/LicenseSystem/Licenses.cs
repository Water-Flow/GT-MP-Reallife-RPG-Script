using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using TerraTex_RL_RPG.Lib.LicenseSystem.VehicleLicenses;

namespace TerraTex_RL_RPG.Lib.LicenseSystem
{
    public static class Licenses
    {
        // @todo: load & store Licenses of user in database

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
        public static bool CanUseVehicle(Client player, Vehicle veh)
        {
            return CanUseVehicle(player, (VehicleHash) veh.model);
        }

        /// <summary>
        /// Is Entity by Nethandle useable by the user
        /// Info: It Adds additional to the return Value an EnitiyData to the player named "missedLicenses" if there are some missing!
        /// </summary>
        /// <param name="player"> The User</param>
        /// <param name="entityHandle">The Entity by NetHandle</param>
        /// <returns></returns>
        public static bool CanUseVehicle(Client player, NetHandle entityHandle)
        {
            Vehicle veh = API.shared.getEntityFromHandle<Vehicle>(entityHandle);
            return CanUseVehicle(player, (VehicleHash) veh.model);
        }

        /// <summary>
        /// Is Vehicle Entity by Hash useable by the user
        /// Info: It Adds additional to the return Value an EnitiyData to the player named "missedLicenses" if there are some missing!
        /// </summary>
        /// <param name="player">The User</param>
        /// <param name="hash">The Entity by Hash</param>
        /// <returns></returns>
        public static bool CanUseVehicle(Client player, VehicleHash hash)
        {
            if ((VehicleClass) API.shared.getVehicleClass(hash) == VehicleClass.Cycles)
            {
                return true;
            }
            VehicleHash[] faggios = { };
            if (Array.IndexOf(faggios, hash) > -1)
            {
                return true;
            }
            
            // loop through all player-owned licenses and check vehicle licenses that one of them returns true
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
    }
}