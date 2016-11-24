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
        public int EndTime { get; set; }

        public bool Planned;
        public bool Locked;
        public string Duration { //No duration if no start/endtime.
            get {
                TimeSpan time = TimeSpan.FromSeconds(EndTime - StartTime);
                return time.ToString();
            }
        }

        public TaskItem() {
            StartTime = 0;
        }
    }
}
