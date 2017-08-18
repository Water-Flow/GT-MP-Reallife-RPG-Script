using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using TerraTex_RL_RPG.Lib.User.Management;

namespace TerraTex_RL_RPG.Lib.Jobs.Fischer
{
    class Fischer : IJob
    {
        private bool _isUiOpen = false;

        //@todo: fill with fishing points
        private readonly Vector3[] _fishingPositions = new Vector3[]
        {
            new Vector3(0,0,0)
        };

        public Fischer()
        {
            TTRPG.Api.onClientEventTrigger += onClientEventHandler;
        }

        private void onClientEventHandler(Client player, string eventName, params object[] arguments)
        {
            if (eventName.Equals("stopFisherJob"))
            {
                _isUiOpen = true;
            }
            else if (eventName.Equals("payFisherJob"))
            {
                float money = (float) arguments[0];
                Int32 steps = (Int32) arguments[1];

                MoneyManager.ChangePlayerMoney(player, money, false, MoneyManager.Categorys.Job,
                    "Fischerjob", "");

                RpLevelManager.AddRpToPlayer(player, steps, true);

                player.sendChatMessage(
                    "~b~Fischhändler Fritz sagt: Okay, diese Menge Fisch kaufe ich dir für " + money.ToString("C2") + " € ab");
            }
        }

        public void StartJob(Client player)
        {
            _isUiOpen = true;
            player.triggerEvent("startFisherJob");
        }

        public Vector3 GetJobAcceptionPoint()
        {
            // @todo: change to correct point 
            return new Vector3(0,0,0);
        }

        public void SendJobHelp(Client player)
        {
            player.sendChatMessage(
                "~b~Fischkäufer Karl sagt: Benutz einfach deine Angel mit /startjob und bring mir große Fische. Je größer der Fisch um so mehr lohnt es sich!");
        }

        public bool CanPlayerStartJob(Client player)
        {
            // @todo: See #45 - https://github.com/TerraTex-Community/GT-MP-Reallife-RPG-Script/issues/45
            if (CheckForValidFishingPosition(player))
            {
                return true;
            }

            player.sendNotification("~r~Job Error", "~r~Du bist an keinem Steg bei dem das Fischen erlaubt ist!");
            return false;
        }

        public string GetAdditionalPickUpJobInfo() => "";

        public bool HasPlayerAllRequirements(Client player)
        {
            //@todo: See #45 - https://github.com/TerraTex-Community/GT-MP-Reallife-RPG-Script/issues/45
            return true;
        }

        public void SendMissingRequirementsToPlayer(Client player)
        {
            //@todo: See #45 - https://github.com/TerraTex-Community/GT-MP-Reallife-RPG-Script/issues/45
        }

        public bool CanPlayerQuitJob(Client player)
        {
            return _isUiOpen;
        }

        private bool CheckForValidFishingPosition(Client player)
        {
            foreach (Vector3 position in _fishingPositions)
            {
                if (position.DistanceTo(player.position) < 20)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
