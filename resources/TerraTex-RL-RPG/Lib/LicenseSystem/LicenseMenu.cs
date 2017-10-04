using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using Newtonsoft.Json.Linq;

namespace TerraTex_RL_RPG.Lib.LicenseSystem
{
    public class LicenseMenu : Script
    {
        public LicenseMenu()
        {
            API.onResourceStart += CreateMenuMarker;
        }

        private void CreateMenuMarker()
        {
            API.createMarker(29, new Vector3(243.17, -408.3, 48), new Vector3(0, 0, 0), new Vector3(0, 0, 0),
                new Vector3(1, 1, 1), 255, 0, 255, 255, 0);
            ColShape shape = API.createCylinderColShape(new Vector3(243.17, -408.3, 48), 1, 3);
            shape.setData("isLicenseMarker", true);


            API.onEntityEnterColShape += OnEntityEnterColShapeHandler;
        }

        private void OnEntityEnterColShapeHandler(ColShape colshape, NetHandle entity)
        {
            if (API.getEntityType(entity) == EntityType.Player)
            {
                if (colshape.hasData("isLicenseMarker"))
                {
                    Client player = API.getPlayerFromHandle(entity);

                    // @todo: create Menu
                    List<Dictionary<string, dynamic>> vehicleLicenseList = new List<Dictionary<string, dynamic>>();
                    List<Dictionary<string, dynamic>> weaponLicenseList = new List<Dictionary<string, dynamic>>();
                    List<Dictionary<string, dynamic>> featureLicenseList = new List<Dictionary<string, dynamic>>();

                    List<string> ownedLicenses = new List<string>();
                    List<ILicense> userLicenses = (List<ILicense>) player.getData("UserLicenses");

                    foreach (ILicense lic in userLicenses)
                    {
                        ownedLicenses.Add(lic.GetLicenseIdentifierName());
                    }

                    foreach (ILicense lic in Licenses.GetAllLicenses())
                    {
                        Dictionary<string, dynamic> licenseObject = new Dictionary<string, dynamic>();
                        licenseObject.Add("price", lic.GetLicensePrice());
                        licenseObject.Add("identifier", lic.GetLicenseIdentifierName());
                        licenseObject.Add("name", lic.GetHumanReadableName());
                        licenseObject.Add("description", lic.GetHumanReadableDescription());
                        if ((int) player.getSyncedData("Level") < lic.GetMinRequiredLevel())
                        {
                            licenseObject.Add("error", "Level " + lic.GetMinRequiredLevel());
                            licenseObject.Add("enabled", false);
                        }
                        else if (ownedLicenses.Contains(lic.GetLicenseIdentifierName()))
                        {
                            licenseObject.Add("error", "im Besitz");
                            licenseObject.Add("enabled", false);
                        }
                        else if ((float) player.getSyncedData("Money") < lic.GetLicensePrice())
                        {
                            licenseObject.Add("color", "~r~");
                            licenseObject.Add("enabled", false);
                        }
                        else
                        {
                            licenseObject.Add("enabled", true);
                        }

                        var memberInfo = lic.GetType().BaseType;
                        if (memberInfo != null && memberInfo.Name.Equals("VehicleLicense"))
                        {
                            vehicleLicenseList.Add(licenseObject);
                        }
                        else if (memberInfo != null && memberInfo.Name.Equals("FeatureLicense")) { 
                            featureLicenseList.Add(licenseObject);
                        }
                        else if (memberInfo != null && memberInfo.Name.Equals("WeaponLicense"))
                        {
                            weaponLicenseList.Add(licenseObject);
                        }
                    }

                    Dictionary<string, dynamic> licensesDictionary = new Dictionary<string, dynamic>();
                    licensesDictionary.Add("vehicleLicenses", vehicleLicenseList);
                    licensesDictionary.Add("featureLicenses", featureLicenseList);
                    licensesDictionary.Add("weaponLicenses", weaponLicenseList);

                    string json = JObject.FromObject(licensesDictionary).ToString();
                    player.triggerEvent("createLicensesMenu", json);
                }
            }
        }
    }
}