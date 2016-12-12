using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class RouteItem
    {
        public TimeSpan Duration { get; private set; }

        public string[] Waypoints = new string[] { };

        public RouteItem(string startAddressName, string endAddressName, TimeSpan duration)
        {
            Waypoints = new string[] { startAddressName, endAddressName };
            Duration = duration;
        }

        public override string ToString()
        {
            return Duration.ToString() + Waypoints.Aggregate((s1,s2) => s1 + ", " + s2);
        }
    }
}
