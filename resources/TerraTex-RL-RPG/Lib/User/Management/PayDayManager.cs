using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using Newtonsoft.Json.Linq;

namespace TerraTex_RL_RPG.Lib.User.Management
{
    public class PayDayManager : Script
    {
        [Command("payday", Group = "general", SensitiveInfo = false)]
        public void PayDayCommand(Client player)
        {

            Dictionary<string, double> income = (Dictionary<string, double>)player.getData("LastPayDayIncome");
            Dictionary<string, double> outgoings = (Dictionary<string, double>)player.getData("LastPayDayOutgoings");

            Dictionary<string, Dictionary<string, double>> payDay = new Dictionary<string, Dictionary<string, double>>();
            payDay.Add("Income", income);
            payDay.Add("Outgoings", outgoings);

            player.triggerEvent("openPayDayUI", JObject.FromObject(payDay).ToString());
        }

        public class Category
        {
            private readonly string _name;
            private readonly string _identifier;
    
            public static readonly Category Tax =new Category("Tax", "Steuern");
            public static readonly Category Job =new Category("Job", "Jobgehälter");

            private Category(String identifier, String name)
            {
                this._identifier = identifier;
                this._name = name;
            }

            public override String ToString()
            {
                return _name;
            }

            public String ToIdentifierString()
            {
                return _identifier;
            }

            public bool Equals(Category obj)
            {
                return obj.ToIdentifierString().Equals(_identifier);
            }
        }


        public static void AddOutgoingToPayDay(Client player, double amount, Category category)
        {
            throw new NotImplementedException("Currently not implemented.");
        }

        public static void AddIncomeToPayDay(Client player, double amount, Category category, bool withTax)
        {
            throw new NotImplementedException("Currently not implemented.");
        }

        public static void SendPayDay(Client player)
        {
            // Add additional 10 RP for each PayDay
            RpLevelManager.AddRpToPlayer(player, 10, false);

            Dictionary<string, double> income = (Dictionary<string, double>)player.getData("PayDayIncome");
            Dictionary<string, double> outgoings = (Dictionary<string, double>)player.getData("PayDayOutgoings");

            double sum = 0;

            foreach (KeyValuePair<string, double> value in income)
            {
                sum += value.Value;
            }

            foreach (KeyValuePair<string, double> value in outgoings)
            {
                sum -= value.Value;
            }

            Dictionary<string, Dictionary<string, double>> payDay =
                new Dictionary<string, Dictionary<string, double>>();
            payDay.Add("Income", income);
            payDay.Add("Outgoings", outgoings);

            MoneyManager.ChangePlayerMoney(player, (float)sum, true, MoneyManager.Categorys.PayDay, "PayDay",
                JObject.FromObject(payDay).ToString());

            if (sum >= 0)
            {
                TTRPG.Api.sendNotificationToPlayer(player, "Zahltag! Dir wurden ~g~" + sum + " €~s~ überwiesen.");
            }
            else
            {
                TTRPG.Api.sendNotificationToPlayer(player, "Zahltag! Dir wurden ~r~" + sum + " €~s~ abgezogen.");
            }

            player.setData("LastPayDayIncome", new Dictionary<string, double>(income));
            player.setData("LastPayDayOutgoings", new Dictionary<string, double>(outgoings));
            income.Clear();
            outgoings.Clear();
            player.setData("PayDayIncome", income);
            player.setData("PayDayOutgoings", outgoings);
        }
    }
}