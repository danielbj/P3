using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.Modules
{
    public class RouteItem
    {
        public TimePeriod TimePeriod { get; set; } //nødvendig egentlig?
        public TimeSpan Duration { get; set; }
        private RouteCalculator _routeCalc;


        public RouteItem(int duration)
        {
            Duration = TimeSpan.FromMinutes(duration);
            _routeCalc = new RouteCalculator();

        }

        public override string ToString()
        {
            string wayPoints = "";
            foreach (string waypoint in _routeCalc.Waypoints)
            {
                wayPoints += waypoint + ", ";
            }
            return Duration.ToString() + wayPoints;
        }







    }
}
