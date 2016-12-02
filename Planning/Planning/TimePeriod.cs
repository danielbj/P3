using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning
{
    public class TimePeriod
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan EndTime { get{ return StartTime + Duration; } }
        

        public TimePeriod(TimeSpan duration)
        {
            Duration = duration;            
        }
    }


}
