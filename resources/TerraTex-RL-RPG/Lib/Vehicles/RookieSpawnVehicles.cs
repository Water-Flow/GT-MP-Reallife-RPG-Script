using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
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

            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Faggio, new Vector3(296.731171, -1179.04529, 28.88412), new Vector3(1.4278388, -6.8676095, 141.525116), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Faggio2, new Vector3(298.578278, -1178.75635, 28.8814621), new Vector3(0.741092, -12.2546453, 136.83107), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Faggio3, new Vector3(300.740967, -1178.64014, 28.88448), new Vector3(0.6942585, -10.4744749, 134.169952), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Faggio, new Vector3(302.906158, -1178.44751, 28.8839283), new Vector3(1.42269766, -8.435299, 125.943192), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Faggio2, new Vector3(303.970978, -1179.64014, 28.9428444), new Vector3(-1.38316345, -11.53366, 130.697021), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Faggio3, new Vector3(304.376678, -1181.7301, 28.8405571), new Vector3(1.13158381, -11.0757275, 122.46537), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Faggio, new Vector3(304.280182, -1183.55994, 28.8393173), new Vector3(1.42047763, -9.035119, 123.103973), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Faggio2, new Vector3(304.379578, -1185.31812, 28.8399849), new Vector3(1.8780477, -8.304562, 116.56395), 10, rnd.Next(0, 159), rnd.Next(0, 159));

            // bikes
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Bmx, new Vector3(291.049957, -1208.726, 28.6792774), new Vector3(0.110616662, 3.08629727, -101.332367), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Bmx, new Vector3(291.055756, -1207.61035, 28.6794548), new Vector3(0.128078029, 3.581896, -99.67836), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Cruiser, new Vector3(291.0148, -1206.528, 28.8737717), new Vector3(1.57156491, -5.77497053, -99.2768555), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Cruiser, new Vector3(291.0581, -1205.42065, 28.8735085), new Vector3(1.60271585, -6.20666, -103.867561), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Scorcher, new Vector3(290.969727, -1204.28992, 28.9529419), new Vector3(0.0138275782, -5.103698, -105.642082), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Scorcher, new Vector3(291.0428, -1203.20447, 28.9535027), new Vector3(0.3681051, -5.59804249, -106.642509), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.TriBike, new Vector3(291.0772, -1202.23914, 28.9062328), new Vector3(0.0623252578, -5.016445, -107.754646), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.TriBike, new Vector3(291.041321, -1201.35974, 28.9056263), new Vector3(-0.0340393148, -5.904286, -114.534142), 10, rnd.Next(0, 159), rnd.Next(0, 159));


            // temporary vehicles
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy, new Vector3(259.3892, -1150.53064, 28.6171017), new Vector3(0.03388112, 8.167082E-05, 178.7713), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy2, new Vector3(256.123322, -1149.97668, 28.6154518), new Vector3(-0.0415702462, 0.1458071, -176.761215), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy, new Vector3(253.312485, -1149.63232, 28.605938), new Vector3(-0.342038453, 0.0354574136, 178.165558), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy2, new Vector3(249.943, -1150.17139, 28.59868), new Vector3(-0.351597458, 0.379967153, -179.982712), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy, new Vector3(246.941162, -1150.40283, 28.58104), new Vector3(0.16751723, 0.442015648, 178.560989), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy2, new Vector3(243.322144, -1149.839, 28.52863), new Vector3(0.128850058, 1.75735247, -179.634109), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy, new Vector3(-118.395424, 886.288, 235.083954), new Vector3(-0.103173949, -5.905765, -171.0234), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy2, new Vector3(-110.676704, 862.319, 234.969086), new Vector3(-0.247676119, 4.21763325, -151.833847), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy, new Vector3(-76.624054, 854.537964, 234.91803), new Vector3(-0.117970675, 3.817026, -47.2387161), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy2, new Vector3(-67.3473053, 894.847, 234.867447), new Vector3(-0.0151297888, 0.1476637, 114.136246), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy, new Vector3(-70.16939, 900.424255, 234.902756), new Vector3(0.3902838, -0.08479121, 112.995377), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy2, new Vector3(2550.38257, 2614.197, 37.2699051), new Vector3(0.0437661074, 0.0020795844, 18.9332314), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy, new Vector3(2547.38525, 2613.01758, 37.2703552), new Vector3(-0.04496815, 0.03137926, 19.9104729), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy2, new Vector3(2544.42627, 2611.967, 37.2692566), new Vector3(0.06727948, 0.00304508838, 21.231514), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy, new Vector3(2541.61182, 2610.54761, 37.2711258), new Vector3(0.0241145939, 0.00357693, 22.1967487), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy2, new Vector3(2529.47119, 2636.324, 37.26787), new Vector3(-0.09965336, -0.230169684, -86.8055954), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy, new Vector3(2551.48438, 2741.12427, 42.17878), new Vector3(-7.96585035, -4.374467, -50.619), 10, rnd.Next(0, 159), rnd.Next(0, 159));
            VehiclesHelper.CreateVehicleIdleRespawn(VehicleHash.Elegy2, new Vector3(2556.57837, 2735.54321, 42.65151), new Vector3(-1.91005886, -4.18826, -92.363945), 10, rnd.Next(0, 159), rnd.Next(0, 159));
        }
    }
}