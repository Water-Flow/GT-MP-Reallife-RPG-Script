using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using TerraTex_RL_RPG.Lib.Jobs;

namespace TerraTex_RL_RPG.Lib.Admin
{
    public class Teleports : Script
    {
        [Command("gotojob", Group = "admin", SensitiveInfo = false)]
        public void GotoJobCommand(Client player, int jobId)
        {
            if (AdminChecks.CheckAdminLvl(player, 1))
            {
                player.position = Job.JobTable.Get(jobId).GetInstance().GetJobAcceptionPoint();
            }
        }
    }
}