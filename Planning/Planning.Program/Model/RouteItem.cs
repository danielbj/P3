using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class RouteItem
    {
        public int RouteItemId { get; set; }
        public TimeSpan Duration
        {
            get
            {
                int m = (int)(TimePeriod.Duration.TotalMinutes + 0.5);
                return new TimeSpan(0,m,0);
            }
        }
        public TimePeriod TimePeriod { get; set; }

        public string[] Waypoints = new string[2]; //og hvorfor skal vi lagre den samme addresse to forskellige steder?
        public string WaypointsForDatabase { get; set; }

        public RouteItem(string startAddressName, string endAddressName, TimeSpan duration)
        {
            TimePeriod = new TimePeriod(duration);
            Waypoints = new string[] { startAddressName, endAddressName };
            WaypointsForDatabase = Waypoints[0] + "|" + Waypoints[1];
        }

        public RouteItem()
        {
            TimePeriod = new TimePeriod(new TimeSpan(0,0,0));
        }

        /// <summary>
        /// Used to read routeitems waypoint from database.
        /// </summary>
        public void GenerateWayPointsFromDatabase() {
            if(WaypointsForDatabase != null)
                Waypoints = WaypointsForDatabase.Split('|');
        }

        public override string ToString()
        {
            return Duration.ToString() + Waypoints.Aggregate(new Func<string, string, string>((s1,s2) => s1 + ", " + s2));
        }

        public override bool Equals(object obj) {
            RouteItem tempRI = obj as RouteItem;
            if (tempRI != null && tempRI.WaypointsForDatabase != null && this.WaypointsForDatabase != null)
                return String.Equals(tempRI.WaypointsForDatabase, this.WaypointsForDatabase);

            return false;

        }

        public override int GetHashCode() {
            if (WaypointsForDatabase != null)
                return WaypointsForDatabase.GetHashCode() + base.GetHashCode();
            return base.GetHashCode();
        }
    }
}
