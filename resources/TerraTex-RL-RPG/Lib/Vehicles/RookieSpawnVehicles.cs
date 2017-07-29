using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared.Math;
using TerraTex_RL_RPG.Lib.Helper;

namespace TerraTex_RL_RPG.Lib.Vehicles
{
    public class RookieSpawnVehicles : Script
    {
        public RookieSpawnVehicles()
        {
            API.onResourceStart += CreateRookieVehicles;
        }

        private void CreateRookieVehicles()
        {
            Random rnd = new Random();

            VehiclesHelper.CreateVehicleIdleRespawn("Faggio", new Vector3(296.731171, -1179.04529, 28.88412), new Vector3(1.4278388, -6.8676095, 141.525116), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("Faggio2", new Vector3(298.578278, -1178.75635, 28.8814621), new Vector3(0.741092, -12.2546453, 136.83107), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("Faggio3", new Vector3(300.740967, -1178.64014, 28.88448), new Vector3(0.6942585, -10.4744749, 134.169952), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("Faggio", new Vector3(302.906158, -1178.44751, 28.8839283), new Vector3(1.42269766, -8.435299, 125.943192), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("Faggio2", new Vector3(303.970978, -1179.64014, 28.9428444), new Vector3(-1.38316345, -11.53366, 130.697021), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("Faggio3", new Vector3(304.376678, -1181.7301, 28.8405571), new Vector3(1.13158381, -11.0757275, 122.46537), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("Faggio", new Vector3(304.280182, -1183.55994, 28.8393173), new Vector3(1.42047763, -9.035119, 123.103973), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("Faggio2", new Vector3(304.379578, -1185.31812, 28.8399849), new Vector3(1.8780477, -8.304562, 116.56395), 10, rnd.Next(0, 159), rnd.Next(0, 159));

            // bikes
            VehiclesHelper.CreateVehicleIdleRespawn("BMX", new Vector3(291.049957, -1208.726, 28.6792774), new Vector3(0.110616662, 3.08629727, -101.332367), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("BMX", new Vector3(291.055756, -1207.61035, 28.6794548), new Vector3(0.128078029, 3.581896, -99.67836), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("Cruiser", new Vector3(291.0148, -1206.528, 28.8737717), new Vector3(1.57156491, -5.77497053, -99.2768555), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("Cruiser", new Vector3(291.0581, -1205.42065, 28.8735085), new Vector3(1.60271585, -6.20666, -103.867561), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("Scorcher", new Vector3(290.969727, -1204.28992, 28.9529419), new Vector3(0.0138275782, -5.103698, -105.642082), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("Scorcher", new Vector3(291.0428, -1203.20447, 28.9535027), new Vector3(0.3681051, -5.59804249, -106.642509), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("TriBike", new Vector3(291.0772, -1202.23914, 28.9062328), new Vector3(0.0623252578, -5.016445, -107.754646), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn("TriBike", new Vector3(291.041321, -1201.35974, 28.9056263), new Vector3(-0.0340393148, -5.904286, -114.534142), 10, rnd.Next(0, 159), rnd.Next(0, 159));
        }
    }
}