using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using Newtonsoft.Json;

namespace TerraTex_RL_RPG.Lib.Systems.ClickSystem
{
    public class ClickSystem : Script
    {
        // Declare the delegate (if using non-generic pattern).
        public delegate void OnClickEventHandler(Client player, NetHandle handle);
        public delegate void OnClickWorldEventHandler(Client player, WorldObject clickedWorldObject);

        // Declare the event.
        public static event OnClickEventHandler OnClickEvent;
        public static event OnClickWorldEventHandler OnClickWorldEvent;

        public ClickSystem()
        {
            API.onClientEventTrigger += OnReceiveClick;
        }

        private void OnReceiveClick(Client sender, string eventName, params object[] arguments)
        {
            if (eventName.Equals("onClientClick"))
            {
                NetHandle handle = (NetHandle) arguments[0];
                OnClickEvent?.Invoke(sender, handle);
            }
            if (eventName.Equals("onClientClickWorld"))
            {

                Dictionary<string, dynamic> obj = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>((string) arguments[0]);
                OnClickWorldEvent?.Invoke(sender, new WorldObject(
                    new Vector3((float)obj.Get("positionX"), (float)obj.Get("positionY"), (float)obj.Get("positionZ")),
                    (int) obj.Get("hash")
                ));
            }
        }
    }
}