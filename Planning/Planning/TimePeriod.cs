using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class TimePeriod
    {
        public TimeSpan StartTime { get; set; } 
        public TimeSpan Duration { get; set; }
        public TimeSpan EndTime { get; set; }

        [Obsolete("Only needed for serialization and materialization in Entity Framework", true)]
        public TimePeriod() {    }

        public TimePeriod(TimeSpan duration)
        {
            Duration = duration;            
        }
    }


}
