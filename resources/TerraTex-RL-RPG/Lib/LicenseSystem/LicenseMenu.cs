using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using TerraTex_RL_RPG.Lib.Helper;
using TerraTex_RL_RPG.Lib.User.Management;

namespace TerraTex_RL_RPG.Lib.LicenseSystem
{
    public class LicenseMenu : Script
    {
        public LicenseMenu()
        {
            API.onResourceStart += CreateMenuMarker;
            API.onClientEventTrigger += OnClientLicenseTrigger;
        }

        private void OnClientLicenseTrigger(Client sender, string eventName, params object[] arguments)
        {
            if (eventName.Equals("buyLicense"))
            {
                string identifier = (string) arguments[0];
                ILicense lic = Licenses.GetLicenseByIdentifier(identifier);
                if (!Licenses.HasLicense(sender, lic.GetLicenseIdentifierName()))
                {
                    bool hasPaid = MoneyManager.PlayerPayMoneyOrBank(sender, -lic.GetLicensePrice(), MoneyManager.Categorys.Purchase, "Lizenzkauf: " + lic.GetHumanReadableName(), null);
                    if (hasPaid)
                    {
                        ChatHelper.SendChatNotificationToPlayer(sender, "Lizenzkauf", "Du hast die Lizenz \"" + lic.GetHumanReadableName() + "\" erworben.");
                        // Add License to player and database
                        List<ILicense> userLicenses = (List<ILicense>)sender.getData("UserLicenses");
                        userLicenses.Add(lic);
                        sender.setData("UserLicenses", userLicenses);

                        MySqlCommand createLicenseCommand = TTRPG.Mysql.Conn.CreateCommand();
                        createLicenseCommand.CommandText =
                            "INSERT INTO user_licenses (UserID, LicenseKey) " +
                            "VALUES (@userID, @licenseKey)";

                        createLicenseCommand.Parameters.AddWithValue("@userID", (int) sender.getSyncedData("ID"));
                        createLicenseCommand.Parameters.AddWithValue("@licenseKey", lic.GetLicenseIdentifierName());

                        createLicenseCommand.ExecuteNonQuery();

                        SendLicenseMenuToPlayer(sender, true);
                    }
                    else
                    {
                        ChatHelper.SendChatNotificationToPlayer(sender, "Lizenzkauf", "~r~Du hast nicht gnügend Geld auf der Hand oder deinem Konto um die Lizenz zu erwerben.");
                    }

                }
            }
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
                    SendLicenseMenuToPlayer(player);
                }
            }
        }

        private void SendLicenseMenuToPlayer(Client player, bool isUpdate = false)
        {
            List<Dictionary<string, dynamic>> vehicleLicenseList = new List<Dictionary<string, dynamic>>();
            List<Dictionary<string, dynamic>> weaponLicenseList = new List<Dictionary<string, dynamic>>();
            List<Dictionary<string, dynamic>> featureLicenseList = new List<Dictionary<string, dynamic>>();

            List<string> ownedLicenses = Licenses.GetUserLicensesIndentifiers(player);

            foreach (ILicense lic in Licenses.GetAllLicenses())
            {
                Dictionary<string, dynamic> licenseObject = new Dictionary<string, dynamic>();
                licenseObject.Add("price", lic.GetLicensePrice());
                licenseObject.Add("identifier", lic.GetLicenseIdentifierName());
                licenseObject.Add("name", lic.GetHumanReadableName());
                licenseObject.Add("description", lic.GetHumanReadableDescription());
                if ((int)player.getSyncedData("Level") < lic.GetMinRequiredLevel())
                {
                    licenseObject.Add("error", "Level " + lic.GetMinRequiredLevel());
                    licenseObject.Add("enabled", false);
                }
                else if (ownedLicenses.Contains(lic.GetLicenseIdentifierName()))
                {
                    licenseObject.Add("error", "im Besitz");
                    licenseObject.Add("enabled", false);
                }
                else if (MoneyManager.GetPlayerMoney(player) < lic.GetLicensePrice() && MoneyManager.GetPlayerBank(player) < lic.GetLicensePrice())
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
                else if (memberInfo != null && memberInfo.Name.Equals("FeatureLicense"))
                {
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

            player.triggerEvent(isUpdate ? "updateLicensesMenu" : "createLicensesMenu", json);
        }
    }    
}