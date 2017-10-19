using System;
using System.Collections.Generic;
using System.Threading;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using TerraTex_RL_RPG.Lib.Admin;
using TerraTex_RL_RPG.Lib.Helper;

namespace TerraTex_RL_RPG.Lib.Threads
{
    public class RealTimeWorker
    {
        private bool _interuped = false;

        public void DoWork()
        {
            while (!_interuped)
            {
                DateTime currentTime = DateTime.Now;

                // add functions here
                TTRPG.Api.call("ShutdownAndRestart", "Check24HShutdown", currentTime);


                // Run Thread only every Minutes
                Thread.Sleep(60000);
            }
        }

        public void StopThread()
        {
            _interuped = true;
        }
    }
}