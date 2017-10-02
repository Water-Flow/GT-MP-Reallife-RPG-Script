using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace TerraTex_RL_RPG.Lib.Enviroment
{
    public class GeneralBlips : Script
    {
        public GeneralBlips()
        {
            API.onResourceStart += CreateBlips;
        }

        private void CreateBlips()
        {
            API.consoleOutput("Create general Information Blips");

            // Rookiespawn
            Blip rblip = API.createBlip(new Vector3(259.8162, -1204.156, 29.28907));
            rblip.color = 83;
            rblip.name = "Rookiespawn";
            rblip.sprite = 480;
            rblip.shortRange = true;

            // City Hall
            Blip cHBlip = API.createBlip(new Vector3(245, -381.8, 44.5));
            cHBlip.color = 83;
            cHBlip.name = "Stadthalle";
            cHBlip.sprite = 419;
            cHBlip.shortRange = true;
        }
    }
}