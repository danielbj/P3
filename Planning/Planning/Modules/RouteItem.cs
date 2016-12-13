using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class RouteItem
    {
        public TimeSpan Duration { get; set; }

        public string[] Waypoints = new string[] { }; //og hvorfor skal vi lagre den samme addresse to forskellige steder?

        public RouteItem(string startAddressName, string endAddressName, TimeSpan duration)
        {
            Waypoints = new string[] { startAddressName, endAddressName };
            Duration = duration;
        }

        public override string ToString()
        {
            return Duration.ToString() + Waypoints.Aggregate(new Func<string, string, string>((s1,s2) => s1 + ", " + s2));
        }
    }
}
