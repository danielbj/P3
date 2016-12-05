using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.Modules
{
    public class RouteItem
    {
        /// <summary>
        /// List of all routes as dictionary with waypoints as key and duration as value.
        /// </summary>
        private static Dictionary<Tuple<string,string>, TimeSpan> _routeList;
        //public TimePeriod TimePeriod { get; set; } //nødvendig egentlig?
        public TimeSpan Duration { get; private set; }

        public string[] Waypoints = new string[] { };

        public RouteItem(Address startAddress, Address endAddress)
        {
            CalculateRoute(startAddress, endAddress);
        }

        public void CalculateRoute(Address startAddresse, Address endAddress)
        {
            KeyValuePair<Tuple<string, string>, TimeSpan> keyValuePair = _routeList.FirstOrDefault(new Func<KeyValuePair<Tuple<string, string>, TimeSpan>, bool>(r => r.Key == new Tuple<string, string>(startAddresse.AddressName, endAddress.AddressName)));

            if (keyValuePair.Equals(default(KeyValuePair<Tuple<string, string>, TimeSpan>)))
            {
                SetThisInstance(keyValuePair);
            }
            else
            {
                CalculateAndAddToList(startAddresse.AddressName, endAddress.AddressName);
            }
        }

        /// <summary>
        /// Calculates route and adds new route to _routeList
        /// </summary>
        /// <param name="startAddressName">Used as start address for route</param>
        /// <param name="endAddressName">User as end address for route</param>
        private void CalculateAndAddToList(string startAddressName, string endAddressName)
        {
            RouteCalculator.CalculateRoute(startAddressName, endAddressName);

            Duration = RouteCalculator.Duration;
            Waypoints = (string[])RouteCalculator.Waypoints.Clone();

            _routeList.Add(new Tuple<string, string>(Waypoints[0], Waypoints[1]), Duration);
        }

        /// <summary>
        /// Set the duration and waypoints of this instance.
        /// </summary>
        /// <param name="keyValuePair">Contains waypoints and duration</param>
        private void SetThisInstance(KeyValuePair<Tuple<string, string>, TimeSpan> keyValuePair)
        {
            Waypoints = new string[] { keyValuePair.Key.Item1, keyValuePair.Key.Item2 };
            Duration = keyValuePair.Value;
        }

        public override string ToString()
        {
            return Duration.ToString() + Waypoints.Aggregate(new Func<string, string, string>((s1,s2) => s1 + ", " + s2));
        }
    }
}
