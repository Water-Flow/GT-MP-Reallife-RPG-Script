using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using GrandTheftMultiplayer.Server.API;
using TerraTex_RL_RPG.Lib.Helper;

namespace TerraTex_RL_RPG.Lib.Admin.Helper
{
    class GMXTimer
    {
        private int _time;
        private string _reason;
        private bool _shutdown = false;
        private Timer _timer;

        public GMXTimer(int minutes, string reason, bool shutdown = false)
        {
            _time = minutes;
            _reason = reason;
            _shutdown = false;
            _shutdown = shutdown;
        }

        public void start()
        {
            _timer = new Timer(60000);
            string shutdownName = _shutdown ? "heruntergefahren" : "neu gestartet";
            API.shared.sendChatMessageToAll("<span style='color: red; font-weight: bold'>Der Server wird in " + _time + " Minuten " + shutdownName + "; Grund: " + _reason + "</span>");
            API.shared.consoleOutput("Der Server wird in " + _time + " Minuten " + shutdownName + "; Grund: " + _reason);

            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _time -= 1;
            string shutdownName = _shutdown ? "heruntergefahren" : "neu gestartet";
            API.shared.sendChatMessageToAll("<span style='color: red; font-weight: bold'>Der Server wird in " + _time + " Minuten " + shutdownName + "; Grund: " + _reason + "</span>");
            API.shared.consoleOutput("Der Server wird in " + _time + " Minuten " + shutdownName + "; Grund: " + _reason);

            if (_time <= 1)
            {
                StartShutDownKickProcess();
            }
            else if(_time <= 3)
            {
                StartShutDown();
            }
        }

        private void StartShutDown()
        {
            // @todo: shutdown 
        }

        private void StartShutDownKickProcess()
        {
            API.shared.setServerPassword(PasswordHelper.GenerateSalt());
            //@todo: kick all users
        }
    }
}
