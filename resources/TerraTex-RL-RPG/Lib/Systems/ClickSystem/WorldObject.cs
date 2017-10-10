using GrandTheftMultiplayer.Shared.Math;

namespace TerraTex_RL_RPG.Lib.Systems.ClickSystem
{
    public class WorldObject
    {
        public Vector3 HitPosition { get; }
        public int EntityHash { get; }

        public WorldObject(Vector3 hitPosition, int entityHash)
        {
            HitPosition = hitPosition;
            EntityHash = entityHash;
        }
    }
}