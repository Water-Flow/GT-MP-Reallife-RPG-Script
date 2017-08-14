using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace TerraTex_RL_RPG.Lib.Jobs
{
    interface IJob
    {
        /// <summary>
        /// Starts the Job. If not needed: Do nothing!
        /// </summary>
        /// <param name="player"></param>
        void StartJob(Client player);

        /// <summary>
        /// Pickup Position
        /// </summary>
        /// <returns></returns>
        Vector3 GetJobAcceptionPoint();
        void SendJobHelp(Client player);

        /// <summary>
        ///     Checks upfront if startjob can be executed
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        bool CanPlayerStartJob(Client player);

        /// <summary>
        /// Additional Informations about Job on Pickup
        /// Like a short Description
        /// </summary>
        /// <returns></returns>
        string GetAdditionalPickUpJobInfo();

        /// <summary>
        /// Has player all minimum requirements to do the job?
        /// Requirements like licenses, minimum level, ...
        /// </summary>
        /// <param name="player">the player that has to be checked</param>
        /// <returns></returns>
        bool HasPlayerAllRequirements(Client player);

        /// <summary>
        /// Sends a list of all requirements or missing requirements via Chat.
        /// </summary>
        /// <param name="player"></param>
        void SendMissingRequirementsToPlayer(Client player);

        /// <summary>
        /// This function should check that every task is completed before player can use /quitjob.
        /// </summary>
        /// <param name="player">the player that has to be checked</param>
        /// <returns></returns>
        bool CanPlayerQuitJob(Client player);
    }
}