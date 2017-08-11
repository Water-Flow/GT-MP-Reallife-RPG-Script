using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using TerraTex_RL_RPG.Lib.Helper;
using TerraTex_RL_RPG.Lib.User.Management;

namespace TerraTex_RL_RPG.Lib.Jobs.Bergwerk
{
    class Bergwerk : IJob
    {
        private readonly Dictionary<int, List<Vector3>> _alreadyUsedPositions = new Dictionary<int, List<Vector3>>();

        private readonly Vector3[] _marker = new[]
        {
            new Vector3(2591.796, 2737.56323, 42.00883),
            new Vector3(2630.61279, 2726.9353, 40.8038635),
            new Vector3(2673.475, 2731.62231, 40.46215),
            new Vector3(2736.40283, 2730.073, 41.91521),
            new Vector3(2746.87573, 2754.64063, 42.21877),
            new Vector3(2795.458, 2753.87256, 51.1925),
            new Vector3(2785.9502, 2777.404, 48.0584221),
            new Vector3(2817.94043, 2812.14258, 55.77284),
            new Vector3(2855.82373, 2786.23486, 62.3976936),
            new Vector3(2899.7644, 2734.88721, 71.5269241),
            new Vector3(2919.562, 2699.9314, 72.88576),
            new Vector3(2946.657, 2673.10229, 75.6143646),
            new Vector3(3001.59155, 2704.77026, 76.50134),
            new Vector3(3037.07178, 2710.82544, 74.18918),
            new Vector3(3070.225, 2737.33765, 73.10236),
            new Vector3(3059.36963, 2824.161, 78.11591),
            new Vector3(3023.34082, 2877.26855, 85.4345551),
            new Vector3(3081.394, 2902.74829, 89.89606),
            new Vector3(3085.10718, 2936.95068, 92.17859),
            new Vector3(3068.39, 2976.032, 91.68142),
            new Vector3(3034.7937, 3020.83862, 89.85893),
            new Vector3(3072.235, 3019.17456, 104.386375),
            new Vector3(3049.22632, 3036.87744, 97.36492),
            new Vector3(3005.033, 3041.705, 99.87259),
            new Vector3(2982.718, 3017.58325, 99.153244),
            new Vector3(2997.62476, 3023.15283, 88.39284),
            new Vector3(2980.29858, 2991.29272, 86.98883),
            new Vector3(3017.391, 3003.03638, 84.06831),
            new Vector3(3053.156, 2994.59448, 82.6704254),
            new Vector3(3067.528, 2952.1377, 79.88512),
            new Vector3(3059.85327, 2901.05029, 80.2277451),
            new Vector3(3054.28784, 2944.72583, 79.6872253),
            new Vector3(3043.54321, 2984.46484, 84.42695),
            new Vector3(2964.816, 2964.81958, 89.16786),
            new Vector3(2937.9353, 2913.66724, 87.82584),
            new Vector3(2889.27637, 2878.37842, 80.00764),
            new Vector3(2877.04565, 2887.29761, 84.9944),
            new Vector3(2855.16064, 2924.79858, 72.9354553),
            new Vector3(2800.85522, 2954.78369, 55.12195),
            new Vector3(2678.19263, 2988.524, 35.21981),
            new Vector3(2660.86, 2927.33862, 37.79349),
            new Vector3(2628.44385, 2880.90747, 35.9514),
            new Vector3(2596.236, 2844.29736, 34.0122757),
            new Vector3(2694.53735, 2831.20947, 41.6051),
            new Vector3(2711.821, 2866.83228, 37.1350746),
            new Vector3(2726.41479, 2879.55469, 39.76519),
            new Vector3(2739.66, 2901.32666, 36.39648),
            new Vector3(2786.90039, 2910.39844, 37.6707954),
            new Vector3(2816.78687, 2861.30054, 40.9834976),
            new Vector3(2828.89478, 2838.75366, 46.6509247),
            new Vector3(2852.86768, 2845.824, 52.7288),
            new Vector3(2857.67969, 2869.829, 56.6553841),
            new Vector3(2875.80151, 2852.162, 61.4612045),
            new Vector3(2905.75635, 2867.57153, 65.70469),
            new Vector3(2994.31616, 2917.74756, 60.3559952),
            new Vector3(3018.65942, 2914.85815, 63.15963),
            new Vector3(3023.19214, 2952.29883, 66.04075),
            new Vector3(2982.43872, 2929.16382, 69.98812),
            new Vector3(2976.305, 2909.55078, 70.43414),
            new Vector3(2957.14722, 2902.36084, 71.61585),
            new Vector3(2961.60767, 2924.80835, 74.74473),
            new Vector3(2990.545, 2957.282, 77.88109),
            new Vector3(3023.37646, 2992.54688, 71.53562),
            new Vector3(3044.19531, 2957.922, 70.5664444),
            new Vector3(3040.91138, 2916.39185, 70.36528),
            new Vector3(3026.03687, 2904.70068, 73.07895),
            new Vector3(3017.83545, 2868.77637, 72.96819),
            new Vector3(3037.59961, 2822.25439, 70.88995),
            new Vector3(3060.85, 2747.87134, 63.76748),
            new Vector3(3051.02734, 2723.18945, 62.75682),
            new Vector3(3038.69019, 2717.339, 62.76705),
            new Vector3(2993.06567, 2708.99731, 63.6857643),
            new Vector3(2984.87085, 2688.71875, 64.29347),
            new Vector3(2958.81982, 2675.33569, 63.6390457),
            new Vector3(2948.29688, 2689.71118, 64.923645),
            new Vector3(2927.858, 2714.25073, 63.63371),
            new Vector3(2912.299, 2743.14063, 62.2544975),
            new Vector3(2885.29565, 2786.32031, 56.22697),
            new Vector3(2894.42847, 2773.60425, 53.7781868),
            new Vector3(2928.37158, 2746.49121, 53.33328),
            new Vector3(2952.68457, 2698.15649, 54.645607),
            new Vector3(2993.06, 2721.231, 56.52143),
            new Vector3(2986.07837, 2745.466, 55.25537),
            new Vector3(3027.47168, 2759.44556, 55.9012032),
            new Vector3(2994.57373, 2807.91016, 55.35803),
            new Vector3(2985.54736, 2859.2998, 59.1138535),
            new Vector3(3013.11426, 2810.097, 65.03325),
            new Vector3(2925.35547, 2856.046, 55.6107445),
            new Vector3(2905.41382, 2829.79419, 54.02548),
            new Vector3(2951.795, 2847.88672, 46.8833466),
            new Vector3(2984.25342, 2810.5835, 43.69481),
            new Vector3(2996.07471, 2758.91064, 42.48086),
            new Vector3(2961.89282, 2732.55347, 44.9579468),
            new Vector3(2972.3728, 2769.36743, 39.0241623),
            new Vector3(2931.684, 2761.041, 44.325325),
            new Vector3(2914.92139, 2779.43457, 43.68919),
            new Vector3(2934.80957, 2816.78687, 44.04231),
            new Vector3(2846.242, 2816.87183, 53.33064),
            new Vector3(2778.59717, 2847.69141, 35.4858131),
            new Vector3(2628.164, 2760.59961, 35.8724365),
            new Vector3(2555.69824, 2773.52881, 39.3047)
        };

        public Bergwerk()
        {
            TTRPG.Api.onPlayerExitVehicle += OnPlayerExitVehicleHandler;
            TTRPG.Api.onEntityEnterColShape += OnEntityEnterColShapeHandler;

            foreach (Vector3 position in _marker)
            {
                ColShape shape = TTRPG.Api.createCylinderColShape(position, 3, 5);
                shape.setData("bergwerk_colshape", true);
                shape.setData("position", position);
            }
        }

        private void OnEntityEnterColShapeHandler(ColShape shape, NetHandle entity)
        {
            if (TTRPG.Api.getEntityType(entity) == EntityType.Player
                && shape.getData("bergwerk_colshape") != null
                && (bool) shape.getData("bergwerk_colshape"))
            {
                Client player = TTRPG.Api.getPlayerFromHandle(entity);

                if (player.isInVehicle && player.vehicle.getData("job_bergwerk_bulldozer") != null)
                {
                    Vector3 markerPosition = (Vector3) shape.getData("position");

                    List<Vector3> markers = _alreadyUsedPositions.Get((int) player.getSyncedData("ID"));

                    bool found = false;

                    foreach (Vector3 position in markers)
                    {
                        if (position.DistanceTo(markerPosition) < 1)
                        {
                            markers.Remove(position);
                            found = true;
                            break;
                        }
                    }

                    if (found)
                    {
                        player.triggerEvent("job_bergwerk_destroyMarker", markerPosition);

                        if (markers.Count == 0)
                        {
                            player.vehicle.delete();
                            _alreadyUsedPositions.Remove((int) player.getSyncedData("ID"));

                            int money = _marker.Length * 42;
                            int newEp = (int) Math.Ceiling(_marker.Length * 0.5);

                            MoneyManager.ChangePlayerMoney(player, (float) money / 2, false, MoneyManager.Categorys.Job,
                                "BergwerksJob Barzahlung", "");
                            PayDayManager.AddIncomeToPayDay(player, (double) money / 2, PayDayManager.Category.Job,
                                true);
                            RpLevelManager.AddRpToPlayer(player, newEp, true);


                            player.sendChatMessage(
                                "~b~Vorarbeiter Karl sagt: Hier hast du schon mal die Hälfte deines Verdienstes auf die Hand: " +
                                (money / 2).ToString("C2") + "!" +
                                "Den Rest bekommst als Gehalt beim PayDay... Das Gesetz will es halt so :-/");
                        }
                        else
                        {
                            player.sendNotification("~b~Job Info",
                                "~b~Sehr gut! Dann fehlen ja nur noch " + markers.Count + " Positionen.");
                        }
                    }
                }
            }
        }

        private void OnPlayerExitVehicleHandler(Client player, NetHandle vehicle)
        {
            Vehicle veh = TTRPG.Api.getEntityFromHandle<Vehicle>(vehicle);
            if (veh.getData("job_bergwerk_bulldozer") != null && (bool) veh.getData("job_bergwerk_bulldozer"))
            {
                Client driver = (Client) veh.getData("job_bergwerk_driver");
                if (driver.exists)
                {
                    driver.sendChatMessage(
                        "~b~Vorarbeiter Karl sagt: Da du offentsichtlich den Bulldozer nicht mehr brauchst, haben wir ihn weggeräumt. Falls du " +
                        "ihn doch noch brauchst, hol dir einen neuen!");
                    driver.triggerEvent("job_bergwerk_destroyAllMarkers");
                }

                veh.delete();
            }
        }

        public Vector3 GetJobStartPoint()
        {
            return new Vector3(2569.71313, 2719.22656, 42.8665237);
        }

        public void SendJobHelp(Client player)
        {
            player.sendChatMessage(
                "~b~Vorarbeiter Karl sagt: Schnappe dir einfach den Bulldozer, den wir dir bereitstellen sobald du den Job startest und prüfe den " +
                "Steinbruch auf Probleme an den markierten Stellen!");
        }

        public string GetAdditionalPickUpJobInfo()
        {
            return
                "Bei diesem Job wirst du dir die Hände dreckig machen und den Bulldozer bändigen müssen! Bist du dem gewachsen?";
        }

        public bool HasPlayerAllRequirements(Client player)
        {
            // @todo: add license requirements after license implementation @see https://github.com/TerraTex-Community/GT-MP-Reallife-RPG-Script/issues/42
            return true;
        }

        public void SendMissingRequirementsToPlayer(Client player)
        {
            // @todo see HasPlayerAllRequirements
        }

        public bool CanPlayerQuitJob(Client player)
        {
            return true;
        }

        public void StartJob(Client player)
        {
            Vehicle bulldozi = VehiclesHelper.CreateVehicleFromName("Bulldozer",
                new Vector3(2587.20581, 2722.64185, 42.2129631),
                new Vector3(-1.93598115, -0.36494568, -96.7531));

            bulldozi.setData("job_bergwerk_bulldozer", true);
            bulldozi.setData("job_bergwerk_driver", player);

            player.sendChatMessage("~b~Vorarbeiter Karl sagt: Schnappe dir den Bulldozer, und prüfe den " +
                                   "Steinbruch auf Probleme an den markierten Stellen (siehe Blips + Marker)! " +
                                   "Geld bekommst du wenn du alle Stellen geprüft hast!");

            TTRPG.Api.setPlayerIntoVehicle(player, bulldozi, -1);

            if (!_alreadyUsedPositions.ContainsKey((int) player.getSyncedData("ID")))
            {
                List<Vector3> newVectorList = new List<Vector3>();
                foreach (Vector3 position in _marker)
                {
                    newVectorList.Add(position);
                }
                _alreadyUsedPositions.Add((int) player.getSyncedData("ID"), newVectorList);
            }

            player.triggerEvent("job_bergwerk_createMarker",
                _alreadyUsedPositions.Get((int) player.getSyncedData("ID")));
        }
    }
}