using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using TerraTex_RL_RPG.Lib.Systems.ClickSystem;
using TerraTex_RL_RPG.Lib.User.Management;

namespace TerraTex_RL_RPG.Lib.Enviroment.Banking
{
    public class Atm : Script
    {
        private readonly int[] atmHashes =
        {
            -1126237515,
            -1364697528,
            506770882,
            -870868698
        };

        public Atm()
        {
            API.onResourceStart += RegisterClickHandler;
            API.onClientEventTrigger += onATMEventTrigger;
        }

        private void onATMEventTrigger(Client sender, string eventname, object[] arguments)
        {
            if (eventname.Equals("onATMPayInPayOut"))
            {
                string type = (string) arguments[0];
                float amount = float.Parse((string)arguments[1]);
                string reason = (string) arguments[2];

                if (amount < 0)
                {
                    return;
                }

                if (type.Equals("in"))
                {
                    if (MoneyManager.CanPlayerPayMoney(sender, amount))
                    {
                        MoneyManager.ChangePlayerMoney(sender, -amount, false, MoneyManager.Categorys.BankToMoney,
                            reason, null);
                        MoneyManager.ChangePlayerMoney(sender, amount, true, MoneyManager.Categorys.BankToMoney, reason,
                            null);
                        sender.sendNotification("ATM", "~g~Betrag erfolgreich eingezahlt.");
                        sender.triggerEvent("updateATM");
                    }
                    else
                    {
                        sender.sendNotification("ATM", "~r~Nicht genug Geld.");
                    }
                }
                else
                {
                    if (MoneyManager.CanPlayerPayBank(sender, amount))
                    {
                        MoneyManager.ChangePlayerMoney(sender, amount, false, MoneyManager.Categorys.BankToMoney, reason, null);
                        MoneyManager.ChangePlayerMoney(sender, -amount, true, MoneyManager.Categorys.BankToMoney, reason, null);
                        sender.sendNotification("ATM", "~g~Betrag erfolgreich ausgezahlt.");
                        sender.triggerEvent("updateATM");
                    }
                    else
                    {
                        sender.sendNotification("ATM", "~r~Nicht genug Guthaben.");
                    }
                }
            }
        }

        private void RegisterClickHandler()
        {
            ClickSystem.OnClickWorldEvent += OnClickAtm;
        }

        private void OnClickAtm(Client player, WorldObject clickedWorldObject)
        {
            if (Array.IndexOf(atmHashes, clickedWorldObject.EntityHash) > -1)
            {
                player.triggerEvent("OpenATM");
            }
        }
    }
}