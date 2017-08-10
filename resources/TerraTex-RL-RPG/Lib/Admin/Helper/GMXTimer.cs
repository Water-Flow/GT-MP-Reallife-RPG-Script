using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using TerraTex_RL_RPG.Lib.Helper;
using Object = System.Object;

namespace TerraTex_RL_RPG.Lib.Admin.Helper
{
    class GMXTimer
    {
        private int _time;
        private readonly string _reason;
        private Timer _timer;

        public delegate void OnTerraTexStopEventHandler();

        // Declare the event.
        public static event OnTerraTexStopEventHandler OnTerraTexStopEvent;

        public GMXTimer(int minutes, string reason)
        {
            _time = minutes;
            _reason = reason;
        }

        public void Start()
        {
            _timer = new Timer(60000);
            API.shared.sendChatMessageToAll("<span style='color: red; font-weight: bold'>Der Server wird in " + _time + " Minuten neu gestartet.; Grund: " + _reason + "</span>");
            API.shared.consoleOutput("Der Server wird in " + _time + " Minuten neu gestartet.; Grund: " + _reason);

            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        public void Stop()
        {
            _timer.Enabled = false;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _time -= 1;
            API.shared.sendChatMessageToAll("<span style='color: red; font-weight: bold'>Der Server wird in " + _time + " Minuten neu gestartet.; Grund: " + _reason + "</span>");
            API.shared.consoleOutput("Der Server wird in " + _time + " Minuten neu gestartet.; Grund: " + _reason);

            if (_time <= 1)
            {
                StartShutDownKickProcess();
            }
            else if(_time <= -4)
            {
                StartShutDown();
            }
        }

        private void StartShutDown()
        {
            API.shared.stopResource(API.shared.getThisResource());
        }

        private void StartShutDownKickProcess()
        {
            API.shared.setServerPassword(PasswordHelper.GenerateSalt());

            List<Client> allPlayers = API.shared.getAllPlayers();
            foreach (Client player in allPlayers)
            {
                player.kick("Serverneustart....");
            }

            OnTerraTexStopEvent?.Invoke();
        }
    }
}
