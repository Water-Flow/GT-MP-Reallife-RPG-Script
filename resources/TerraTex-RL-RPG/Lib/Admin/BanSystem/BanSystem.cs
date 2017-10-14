using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using MySql.Data.MySqlClient;

namespace TerraTex_RL_RPG.Lib.Admin.BanSystem
{
    public class BanSystem : Script
    {
        public BanSystem()
        {
            
        }

        public static List<Ban> GetBans(Client player)
        {
            const string selectStatement = @"SELECT
                    admin_bans.ID,
                    admin_bans.UserID,
                    (SELECT user.Nickname FROM user WHERE user.ID = admin_bans.UserID) AS UserName,
                    admin_bans.HardwareID,
                    admin_bans.SystemName,
                    admin_bans.BlacklistBan,
                    admin_bans.DateTo,
                    admin_bans.DateFrom,
                    admin_bans.Reason,
                    (SELECT user.Nickname FROM user WHERE user.ID = admin_bans.AdminID) AS Admin
                FROM admin_bans
                WHERE
                    (HardwareID = @hardwareID or UserID = (SELECT ID FROM user WHERE Nickname = @nickname))
                AND
                    DateFrom <= CURRENT_TIMESTAMP()
                AND
                    (
                        (DateTo >= CURRENT_TIMESTAMP() AND BlacklistBan = 0)
                    OR
                        BlacklistBan = 1
                    OR
                        (DateTo IS NULL AND DateFrom >= CURRENT_TIMESTAMP() - INTERVAL 1 YEAR)
                    );";

            MySqlCommand mc = TTRPG.Mysql.Conn.CreateCommand();
            mc.CommandText = selectStatement;
            mc.Parameters.AddWithValue("@nickname", player.name);
            mc.Parameters.AddWithValue("@hardwareID", player.uniqueHardwareId);
            DataTable result = new DataTable();
            result.Load(mc.ExecuteReader());

            List<Ban> bans = new List<Ban>();
            foreach (DataRow row in result.Rows)
            {
                bans.Add(new Ban(row));
            }

            return bans;
        }

        public static void CleanUpBans()
        {
            const string deleteCommand = @"DELETE FROM admin_bans
                WHERE
                  BlacklistBan = 0
                  AND
                  (
                      (DateTo IS NULL AND DateFrom < CURRENT_TIMESTAMP() - INTERVAL 1 YEAR)
                    OR
                      (DateTo IS NOT NULL AND DateTo <= CURRENT_TIMESTAMP())
                  );";
            MySqlCommand mc = TTRPG.Mysql.Conn.CreateCommand();
            mc.CommandText = deleteCommand;
            mc.ExecuteNonQuery();
        }
    }
}