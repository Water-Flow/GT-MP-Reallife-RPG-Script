using System;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using TerraTex_RL_RPG.Lib.Helper;
using TerraTex_RL_RPG.Lib.User.Management;

namespace TerraTex_RL_RPG.Lib.Jobs.Fischer
{
    class Fischer : IJob
    {
        private bool _isUiOpen = false;
        
        private readonly Vector3[] _fishingPositions = new Vector3[]
        {
            new Vector3(-1803.04932, -1229.82117, 1.59479892),
            new Vector3(32.12362, 856.7382, 197.73259),
            new Vector3(-193.046249, 790.5808, 198.107437),
            new Vector3(-1605.67407, 5258.80469, 2.08688378),
            new Vector3(-268.7067, 6659.041, 1.28240061),
            new Vector3(3854.83545, 4459.558, 1.84926391),
            new Vector3(3863.94385, 4463.63037, 2.72120953),
            new Vector3(1299.32825, 4218.44727, 33.90869),
            new Vector3(1338.77087, 4225.44141, 33.91553),
            new Vector3(1333.87219, 4269.881, 31.5031834),
            new Vector3(1733.2522, 3985.55835, 31.9831886),
            new Vector3(-879.046448, -1455.44031, 1.59539115)
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
                    "~b~Fischhändler Fritz sagt: Okay, diese Menge Fisch kaufe ich dir für " + money.ToString("C2") + " ab");
            }
        }

        public void StartJob(Client player)
        {
            _isUiOpen = true;
            player.triggerEvent("startFisherJob");
        }

        public Vector3 GetJobAcceptionPoint()
        {
            return new Vector3(26.3082237, 863.6872, 197.739182);
        }

        public void SendJobHelp(Client player)
        {
            player.sendChatMessage(
                "~b~Fischkäufer Karl sagt: Benutz einfach deine Angel mit /startjob und bring mir große Fische. Je größer der Fisch um so mehr lohnt es sich!");
            player.sendChatMessage(
                "~b~Fischkäufer Karl sagt: Ich habe dir alle Stege, an dennen du Angeln kannst, auf deiner Karte markiert (rote J?) !");
            player.sendChatMessage(
                "~b~Fischkäufer Karl sagt: Ob du in einen Bereich bist, an dem du Angeln kannst siehst du an dem Angel-Icon auf deinen Monitor oben rechts!");
        }

        public bool CanPlayerStartJob(Client player)
        {
            // @todo: See #45 - https://github.com/TerraTex-Community/GT-MP-Reallife-RPG-Script/issues/45
            if (CheckForValidFishingPosition(player))
            {
                return true;
            }

            ChatHelper.SendChatNotificationToPlayer(player, "~r~Job Error", "~r~Du bist an keinem Steg bei dem das Fischen erlaubt ist!");
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
