using System;
using System.Runtime.InteropServices.WindowsRuntime;
using GrandTheftMultiplayer.Server.Elements;
using MySql.Data.MySqlClient;

namespace TerraTex_RL_RPG.Lib.User.Management
{
    public static class MoneyManager
    {
        public static float GetPlayerMoney(Client player)
        {
            return player.getSyncedData("Money");
        }

        public static float GetPlayerBank(Client player)
        {
            return player.getSyncedData("BankAccount");
        }

        public enum Categorys
        {
            BankToMoney,
            PlayerToPlayer,
            PayDay,
            Job,
            Purchase,
            Other
        }

        /// <summary>
        /// Checks if a player can pay with money on hand or with bankaccount and pays the amount
        /// </summary>
        /// <param name="player"></param>
        /// <param name="amount">has to be negative</param>
        /// <param name="category"></param>
        /// <param name="reason"></param>
        /// <param name="additionalDataAsJson"></param>
        /// <returns></returns>
        public static bool PlayerPayMoneyOrBank(Client player, float amount, Categorys category, string reason,
            string additionalDataAsJson)
        {
            if (GetPlayerBank(player) < -amount && GetPlayerMoney(player) < -amount)
            {
                return false;
            }

            if (GetPlayerMoney(player) >= -amount)
            {
                // pay with money
                ChangePlayerMoney(player, amount, false, category, reason, additionalDataAsJson);
            }
            else
            {
                // pay with bank
                ChangePlayerMoney(player, amount, true, category, reason, additionalDataAsJson);
                player.sendNotification("EC-Zahlung", "Dein Konto wurde mit einem Betrag von ~r~" + amount.ToString("C2") + "~s~ belastet.");
            }

            return true;
        }

        public static void ChangePlayerMoney(Client player, float amount, bool bankPay,
            Categorys category, string reason, string additionalDataAsJson)
        {
            float money = bankPay ? GetPlayerBank(player) : GetPlayerMoney(player);
            if (bankPay)
            {
                player.setSyncedData("BankAccount", money + amount);
            }
            else
            {
                player.setSyncedData("Money", money + amount);
            }

            MySqlCommand logInsertCommand = TTRPG.Mysql.Conn.CreateCommand();
            logInsertCommand.CommandText = "INSERT INTO log_player_money (UserID, Typ, Category, Amount, Reason, AdditionalData) VALUES (@UserID, @Typ, @Category, @Amount, @Reason, @AdditionalData)";
            logInsertCommand.Parameters.AddWithValue("@UserID", player.getSyncedData("ID"));
            logInsertCommand.Parameters.AddWithValue("@Typ", bankPay ? "BANKACCOUNT" : "MONEY");
            logInsertCommand.Parameters.AddWithValue("@Category", category);
            logInsertCommand.Parameters.AddWithValue("@Amount", Math.Round(amount, 2));
            logInsertCommand.Parameters.AddWithValue("@Reason", reason);
            logInsertCommand.Parameters.AddWithValue("@AdditionalData", additionalDataAsJson);

            logInsertCommand.ExecuteNonQuery();

            RefreshPlayerMoneyDisplay(player);
        }

        public static void RefreshPlayerMoneyDisplay(Client player)
        {
            player.triggerEvent("RefreshMoneyUI", player.getSyncedData("Money"));
        }

        public static bool CanPlayerPayMoney(Client player, float price)
        {
            return GetPlayerMoney(player) >= price;
        }

        public static bool CanPlayerPayBank(Client player, float price)
        {
            return GetPlayerBank(player) >= price;
        }
    }
}