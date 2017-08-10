using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Shared;

namespace TerraTex_RL_RPG.Lib.Jobs
{
    class Job : IEquatable<Job>
    {
        private readonly string _name;
        private readonly int _id;
        private readonly IJob _instance;
        public static Dictionary<int, Job> JobTable = new Dictionary<int, Job>();

        // list of jobs
        public static readonly Job Bergwerk = new Job(1, "Berkwerksarbeiter", new Bergwerk.Bergwerk());


        // job class
        private Job(int id, String name, IJob instance)
        {
            this._id = id;
            this._name = name;
            this._instance = instance;

            JobTable.Add(id, this);
        }

        public IJob GetInstance()
        {
            return _instance;
        }

        public override String ToString()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public bool Equals(Job obj)
        {
            return obj.GetId().Equals(_id);
        }
    }
}