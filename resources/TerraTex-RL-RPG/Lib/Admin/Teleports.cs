﻿using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
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

        [Command("gotoc", Group = "admin", SensitiveInfo = false)]
        public void GotoCoordinatesCommand(Client player, string pos, int dim = 0)
        {
            if (AdminChecks.CheckAdminLvl(player, 3))
            {
                string[] positionParts = pos.Split(',');

                player.position = new Vector3(float.Parse(positionParts[0]), float.Parse(positionParts[1]), float.Parse(positionParts[2]));
                player.dimension = dim;
            }
        }
    }
}