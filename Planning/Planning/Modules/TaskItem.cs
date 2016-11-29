using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.Modules
{
    public class TaskItem
    {
        public int StartTime { get; set; }
        public int EndTime { get { return StartTime + Duration; } }
        public enum Status
        {
            Unplanned,
            Expired,
            Cancelled,
            Planned
        }

        public Status State { get; set; } = Status.Unplanned;
        public bool Locked;
        public int Duration { get; private set; }
        public Route Route;
        public Citizen Citizen;




        public TaskItem(int duration, Route route, Citizen citizen) {
            Duration = duration;
            Route = route;
            Citizen = citizen;
            StartTime = 0;
        }


        
    }
}
