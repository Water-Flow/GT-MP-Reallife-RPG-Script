using System;
using System.Data;
using System.Globalization;
using System.ServiceModel;

namespace TerraTex_RL_RPG.Lib.Admin.BanSystem
{
    public class Ban
    {
        public string AdminName { get; }
        public bool IsAdminSystem { get; }
        public string Nickname { get; }
        public string HardwareId { get; }
        public string Reason { get; }
        public DateTime BannedUntil { get; }
        public DateTime BannedAt { get; }
        public bool IsBlackList { get; }
        public int ReferenceId { get; }

        public Ban(DataRow dataRow)
        {
            if (dataRow.IsNull("SystemName"))
            {
                AdminName = (string) dataRow["Admin"];
                IsAdminSystem = false;
            }
            else
            {
                AdminName = (string)dataRow["SystemName"];
                IsAdminSystem = true;
            }
            HardwareId = dataRow.IsNull("HardwareID") ? null : (string) dataRow["HardwareID"];
            Nickname = (string) dataRow["UserName"];
            IsBlackList = (bool) dataRow["BlacklistBan"];
            ReferenceId = (int) dataRow["ID"];
            BannedAt = DateTime.Parse(dataRow["DateFrom"].ToString());
            Reason = (string) dataRow["Reason"];
            if (dataRow.IsNull("DateTo"))
            {
                BannedUntil = new DateTime(DateTime.Now.Year + 2, DateTime.Now.Month, DateTime.Now.Day);
            }
            else
            {
                BannedUntil = DateTime.Parse(dataRow["DateTo"].ToString());
            }
        }
    }
}
 