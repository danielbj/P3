using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.Modules
{
    public class RouteItem
    {
        public TimePeriod TimePeriod { get; set; }
        public int Duration { get; set; }

        public RouteItem(int duration)
        {
            Duration = duration;
        }





    }
}
