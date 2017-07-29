using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace TerraTex_RL_RPG.Lib.Jobs
{
    class JobSystem : Script
    {
        private readonly List<Pickup> jobPickups = new List<Pickup>();

        public JobSystem()
        {
            // Create all Job Blips & Pickups
            Dictionary<int, Job> allJobs = Job.JobTable;

            foreach (KeyValuePair<int, Job> jobEntry in allJobs)
            {
                Pickup pickup = API.createPickup(PickupHash.MoneySecurityCase,
                    jobEntry.Value.GetInstance().GetJobStartPoint(), new Vector3(0, 0, 0), 0, 1, 0);
                pickup.setData("ConnectedJob", jobEntry.Value);
                pickup.setData("IsJobPickup", true);

                Blip blip = API.createBlip(jobEntry.Value.GetInstance().GetJobStartPoint());
                blip.name = "Job: " + jobEntry.Value.ToString();
                blip.color = 77;
                blip.sprite = 385;
                blip.shortRange = true;

                jobPickups.Add(pickup);
            }

            API.onPlayerPickup += OnPlayerPickupHandler;
        }

        private void OnPlayerPickupHandler(Client player, NetHandle pickupHandle)
        {
            // Currently not working because of https://bug.gt-mp.net/view.php?id=258

            Pickup pickup = API.getEntityFromHandle<Pickup>(pickupHandle);

            if ((bool) pickup.getSyncedData("IsJobPickup"))
            {
                Job connectedJob = (Job) pickup.getData("ConnectedJob");
                if (player.getSyncedData("CurrentJobId") == connectedJob.GetId())
                {
                    player.sendNotification("Job: " + connectedJob.ToString(),
                        "Du kannst hier deinen Job fortsetzen. Nutze einfach /startjob oder nutze /jobhelp um eine Hilfe zu erhalten. ~n~Kündigen kannst du mit /quitjob",
                        false);
                }
                else
                {
                    if (player.getSyncedData("CurrentJobId") != 0)
                    {
                        player.sendNotification("Job: " + connectedJob.ToString(),
                            "Du hast bereits einen anderen Job, um diesen zu beginnen zu können, kündige erst bei deinem alten Job!");
                    }
                    else
                    {
                        string additional = connectedJob.GetInstance().GetAdditionalPickUpJobInfo();
                        if (additional.Length > 0)
                        {
                            additional = "~n~" + additional;
                        }

                        player.sendNotification("Job: " + connectedJob.ToString(),
                            "Du kannst den annehmen mit /getjob." + additional, false);
                    }
                }
            }
        }

        private Job GetJobAtPlayerPosition(Client player)
        {
            Dictionary<int, Job> allJobs = Job.JobTable;

            foreach (KeyValuePair<int, Job> jobEntry in allJobs)
            {
                if (jobEntry.Value.GetInstance().GetJobStartPoint().DistanceTo(player.position) < 5)
                {
                    return jobEntry.Value;
                }
            }

            return null;
        }

        [Command("getjob", Group = "job", SensitiveInfo = false)]
        public void GetJobCommand(Client player)
        {
            Job currentJobPosition = GetJobAtPlayerPosition(player);

            if (currentJobPosition != null)
            {
                if ((int) player.getSyncedData("CurrentJobId") == 0)
                {
                    if (currentJobPosition.GetInstance().HasPlayerAllRequirements(player))
                    {
                        if (player.isInVehicle)
                        {
                            player.sendNotification("~r~Job Error",
                                "~r~Du kannst erst einen Job annehmen, wenn du dein Fahrzeug verlässt!");
                        }
                        else
                        {
                            player.setSyncedData("CurrentJobId", currentJobPosition.GetId());
                            player.sendNotification("~b~Job " + currentJobPosition.ToString(),
                                "~b~Willkommen im Dienst! Nutze einfach /startjob oder nutze /jobhelp um eine Hilfe zu erhalten.");
                        }
                    }
                    else
                    {
                        player.sendChatMessage(
                            "~r~Du erfüllst nicht alle Vorraussetzungen für den Job. Folgende Vorrausetzungen musst du erüllen: ");
                        currentJobPosition.GetInstance().SendMissingRequirementsToPlayer(player);
                    }
                }
                else
                {
                    Job currentJob = Job.JobTable.Get((int) player.getSyncedData("CurrentJobId"));
                    player.sendNotification("~r~Job Error",
                        "~r~Du hast bereits den Job " + currentJob.ToString() +
                        ". Kündige bei deinem aktuellen Arbeitgeber, dann kannst du wiederkommen!");
                }
            }
            else
            {
                player.sendNotification("~r~Job Error",
                    "~r~Du bist bei keinen Arbeitgeber. Welchen Job willst du hier bekommen? Streifen auf dem Asphalt vielleicht?");
            }
        }

        [Command("quitjob", Group = "job", SensitiveInfo = false)]
        public void QuitJobCommand(Client player)
        {
            Job currentJobPosition = GetJobAtPlayerPosition(player);

            if (currentJobPosition != null)
            {
                if ((int) player.getSyncedData("CurrentJobId") == currentJobPosition.GetId())
                {
                    if (currentJobPosition.GetInstance().CanPlayerQuitJob(player))
                    {
                        if (player.isInVehicle)
                        {
                            player.sendNotification("~r~Job Error",
                                "~r~Du kannst erst einen Job kündigen, wenn du dein Fahrzeug verlässt!");
                        }
                        else
                        {
                            player.setSyncedData("CurrentJobId", 0);
                            player.sendNotification("~b~Job " + currentJobPosition.ToString(),
                                "~b~Schade, dass du nicht mehr für uns arbeiten möchtest...");
                        }
                    }
                }
                else
                {
                    player.sendNotification("~r~Job Error",
                        "~r~Du bist nicht bei deinem aktuellen Arbeitgeber. Du kannst so nicht kündigen!");
                }
            }
            else
            {
                if ((int) player.getSyncedData("CurrentJobId") > 0)
                {
                    player.sendNotification("~r~Job Error",
                        "~r~Du bist nicht bei deinem aktuellen Arbeitgeber. Du kannst so nicht kündigen!");
                }
                else
                {
                    player.sendNotification("~r~Job Error", "~r~Du hast keinen Job, den du kündigen könntest!");
                }
            }
        }

        [Command("startjob", Group = "job", SensitiveInfo = false)]
        public void StartJobCommand(Client player)
        {
            Job currentJobPosition = GetJobAtPlayerPosition(player);

            if (currentJobPosition != null)
            {
                if ((int) player.getSyncedData("CurrentJobId") == currentJobPosition.GetId())
                {
                    if (currentJobPosition.GetInstance().CanPlayerQuitJob(player))
                    {
                        currentJobPosition.GetInstance().StartJob(player);
                    }
                }
                else
                {
                    player.sendNotification("~r~Job Error",
                        "~r~Du bist bei dem falschen Arbeitgeber. Du kannst den Job nicht von hier aus starten!");
                }
            }
            else
            {
                if ((int) player.getSyncedData("CurrentJobId") > 0)
                {
                    player.sendNotification("~r~Job Error",
                        "~r~Du bist nicht bei deinem aktuellen Arbeitgeber. Du kannst den Job nicht von hier aus starten!");
                }
            }
        }

        [Command("jobhelp", Group = "job", SensitiveInfo = false)]
        public void JobHelpCommand(Client player)
        {
            if ((int) player.getSyncedData("CurrentJobId") > 0)
            {
                Job job = Job.JobTable.Get((int) player.getSyncedData("CurrentJobId"));

                player.sendChatMessage("~b~Job Hilfe für den Job " + job.ToString() + ": ");
                job.GetInstance().SendJobHelp(player);
            }
        }
    }
}