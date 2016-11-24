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

        public bool Planned;
        public bool Locked;
        public int Duration { get; private set; }
        public Route Route;




        public TaskItem(int duration) {
            Duration = duration;
            StartTime = 0;
        }
    }
}
