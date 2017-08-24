using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using TerraTex_RL_RPG.WebApi;
using TerraTex_RL_RPG.Lib.Data;
using TerraTex_RL_RPG.Lib.Threads;

namespace TerraTex_RL_RPG
{
    public class TTRPG : Script
    {
        private static Database _mysql;
        private static Configs _configs;
        private static API _api;
        private static StorePlayerData _storePlayerDataThread;
        private static UpdatePlayerPlayTime _updatePlayerPlayTimeThread;
        private static UpdateWeather _dynamicWeatherThread;
        private static CleanVehicles _cleanVehiclesThread;
        private static ConsoleReader _consoleReaderThread;

        public static Database Mysql => _mysql;

        public static Configs Configs => _configs;

        public static API Api => _api;

        public static StorePlayerData StorePlayerDataThread => _storePlayerDataThread;
        public static UpdatePlayerPlayTime UpdatePlayerPlayTimeThread => _updatePlayerPlayTimeThread;
        public static CleanVehicles CleanVehiclesThread => _cleanVehiclesThread;
        public static ConsoleReader ConsoleReaderThread => _consoleReaderThread;
        public static UpdateWeather DynamicWeatherThread => _dynamicWeatherThread;

        public delegate void OnTerraTexStartUpFinishedEventHandler();

        // Declare the event.
        public static event OnTerraTexStartUpFinishedEventHandler OnTerraTexStartUpFinishedEvent;


        public TTRPG()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");

            _api = API;
            API.onResourceStart += PrepareStartUp;
        }

        public void PrepareStartUp()
        {
            TtStartUp();
        }

        public static void TtStartUp()
        {
            _configs = new Configs();
            _mysql = new Database();

            if (!Configs.ConfigExists("server"))
            {
                _api.consoleOutput(LogCat.Fatal, "Configuration for server is missing in Configs directory.");
                _api.stopResource(_api.getThisResource());
            }

            _api.consoleOutput("Starting TerraTex_RL_RPG Gamemode");

            // start Player Threads
            _storePlayerDataThread = new StorePlayerData();
            _api.startThread(_storePlayerDataThread.DoWork);

            _updatePlayerPlayTimeThread = new UpdatePlayerPlayTime();
            _api.startThread(_updatePlayerPlayTimeThread.DoWork);

            _dynamicWeatherThread = new UpdateWeather();
            _api.startThread(_dynamicWeatherThread.DoWork);

            _cleanVehiclesThread = new CleanVehicles();
            _api.startThread(_cleanVehiclesThread.DoWork);

            _consoleReaderThread = new ConsoleReader();
            _api.startThread(_consoleReaderThread.DoWork);

            _api.exported.scoreboard.addScoreboardColumn("Level", "Level", 120);
            _api.exported.scoreboard.addScoreboardColumn("PlayTime", "PlayTime", 120);
            _api.exported.scoreboard.addScoreboardColumn("Nachname", "Nachname", 175);
            _api.exported.scoreboard.addScoreboardColumn("Vorname", "Vorname", 175);
            _api.exported.scoreboard.addScoreboardColumn("ID", "ID", 40);

            _api.setServerPassword(null);
            OnTerraTexStartUpFinishedEvent?.Invoke();

            new ApiServer();
        }
    }
}