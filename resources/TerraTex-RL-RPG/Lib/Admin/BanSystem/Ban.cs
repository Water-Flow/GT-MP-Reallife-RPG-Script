using System;
using System.Data;

namespace TerraTex_RL_RPG.Lib.Admin.BanSystem
{
    public class Ban
    {
        public string AdminName { get; }
        public bool IsAdminSystem { get; }
        public string Nickname { get; }
        public string HardwareId { get; }
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
            HardwareId = (string) dataRow["HardwareID"];
            Nickname = (string) dataRow["UserName"];
            IsBlackList = (int) dataRow["BlacklistBan"] == 1;
            ReferenceId = (int) dataRow["ID"];
        }
    }
}
 