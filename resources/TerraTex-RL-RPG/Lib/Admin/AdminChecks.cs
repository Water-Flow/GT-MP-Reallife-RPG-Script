using GrandTheftMultiplayer.Server.Elements;

namespace TerraTex_RL_RPG.Lib.Admin
{
    static class AdminChecks
    {
        /// <summary>
        /// This function checks if player has correct adminlvl <br/>
        /// AdminLvl Range: <br/>
        ///     0 - No Admin <br/>
        ///     1 - Supporter <br/>
        ///     2 - Moderator / Supermoderator (Moderators with special rights)<br/>
        ///     3 - Administrator<br/>
        ///     4 - Serverleadership
        /// </summary>
        /// <param name="player">Player to Check</param>
        /// <param name="minLevel">Minimum required Adminlvl</param>
        /// <returns>True or False</returns>
        public static bool CheckAdminLvl(Client player, int minLevel)
        {
            if (player.getSyncedData("Admin") >= minLevel)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
