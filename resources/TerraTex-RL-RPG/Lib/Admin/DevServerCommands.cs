using System;
using System.Globalization;
using System.IO;
using System.Text;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using TerraTex_RL_RPG.Lib.Helper;

namespace TerraTex_RL_RPG.Lib.Admin
{
    class DevServerCommands : Script
    {
        [Command("save", Group = "dev", SensitiveInfo = false, GreedyArg = true)]
        public void SaveCommand(Client player, string info = "")
        {
            if (DevServer.CheckDevCommandAccess(player))
            {
                Vector3 position = player.position;
                Directory.CreateDirectory(API.getResourceFolder() + "/Logs");
                string path = API.getResourceFolder() + "/Logs/Position.log";

                if (!File.Exists(path))
                {
                    string createText = "" + Environment.NewLine;
                    File.WriteAllText(path, createText);
                }

                string appendText = position.X.ToString("R").Replace(",", ".") + ", " +
                                    position.Y.ToString("R").Replace(",", ".") + ", " +
                                    position.Z.ToString("R").Replace(",", ".") + " // " + info + Environment.NewLine;
                File.AppendAllText(path, appendText);
                player.sendNotification("Dev-System",
                    "Saved Position: X: " + position.X + "; Y: " + position.Y + "; Z: " + position.Z);
            }
        }

        [Command("savem", Group = "dev", SensitiveInfo = false, GreedyArg = true)]
        public void SaveAndMarkCommand(Client player, string info = "")
        {
            if (DevServer.CheckDevCommandAccess(player))
            {
                Vector3 position = player.position;

                API.createMarker(28, position, new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(5,5, 100), 150, 255, 100 , 100);

                Directory.CreateDirectory(API.getResourceFolder() + "/Logs");
                string path = API.getResourceFolder() + "/Logs/Position.log";

                if (!File.Exists(path))
                {
                    string createText = "" + Environment.NewLine;
                    File.WriteAllText(path, createText);
                }

                string appendText = position.X.ToString("R").Replace(",", ".") + ", " +
                                    position.Y.ToString("R").Replace(",", ".") + ", " +
                                    position.Z.ToString("R").Replace(",", ".") + " // " + info + Environment.NewLine;
                File.AppendAllText(path, appendText);
                player.sendNotification("Dev-System",
                    "Saved Position: X: " + position.X + "; Y: " + position.Y + "; Z: " + position.Z);

               
            }
        }

        [Command("saveVeh", Group = "dev", SensitiveInfo = false, GreedyArg = true)]
        public void SaveVehCommand(Client player, string info = "")
        {
            if (DevServer.CheckDevCommandAccess(player) && player.isInVehicle)
            {
                Vehicle veh = player.vehicle;
                Vector3 position = veh.position;
                Vector3 rotation = veh.rotation;

                Directory.CreateDirectory(API.getResourceFolder() + "/Logs");
                string path = API.getResourceFolder() + "/Logs/Position.log";

                if (!File.Exists(path))
                {
                    string createText = "" + Environment.NewLine;
                    File.WriteAllText(path, createText);
                }

                StringBuilder sb  = new StringBuilder();

                if (info.Length > 0)
                {
                    sb.AppendLine("// (ModelHash: " + veh.model.ToString() + ") " + info);
                }


                String name = veh.displayName;

                string posText = position.X.ToString("R").Replace(",", ".") + ", " +
                                 position.Y.ToString("R").Replace(",", ".") + ", " +
                                 position.Z.ToString("R").Replace(",", ".");

                string rotText = rotation.X.ToString("R").Replace(",", ".") + ", " +
                                 rotation.Y.ToString("R").Replace(",", ".") + ", " +
                                 rotation.Z.ToString("R").Replace(",", ".");

                sb.AppendLine("VehiclesHelper.CreateVehicleFromName(\"" + name + "\", new Vector3(" + posText +
                              "), new Vector3(" + rotText + "));");
                sb.AppendLine("");

                File.AppendAllText(path, sb.ToString());
                player.sendNotification("Dev-System",
                    "Saved Vehicle-Position: X: " + position.X + "; Y: " + position.Y + "; Z: " + position.Z);
            }
        }

        [Command("pos", Group = "dev", SensitiveInfo = false)]
        public void PosCommand(Client player)
        {
            if (DevServer.CheckDevCommandAccess(player) || AdminChecks.CheckAdminLvl(player, 3))
            {
                Vector3 position = player.position;
                ChatHelper.SendChatNotificationToPlayer(player, "Position", 
                    position.X.ToString(CultureInfo.CreateSpecificCulture("en-GB"))
                   + ", " + position.Y.ToString(CultureInfo.CreateSpecificCulture("en-GB"))
                   + ", " + position.Z.ToString(CultureInfo.CreateSpecificCulture("en-GB")));
            }
        }

        [Command("veh", Group = "dev", SensitiveInfo = false)]
        public void VehCommand(Client player, string vehicleModelName)
        {
            if (DevServer.CheckDevCommandAccess(player) || AdminChecks.CheckAdminLvl(player, 3))
            {
                Vector3 position = player.position.Add(new Vector3(2, 2, 2));
                Vector3 rotation = player.rotation;

                VehicleHash myVehicle = API.vehicleNameToModel(vehicleModelName);
                Random rnd = new Random();
                API.createVehicle(myVehicle, position, rotation, rnd.Next(0, 159), rnd.Next(0, 159));
            }
        }
    }
}