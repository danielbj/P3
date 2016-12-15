﻿using System;
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

        public string[] Waypoints = new string[] { }; //og hvorfor skal vi lagre den samme addresse to forskellige steder?

        public RouteItem(string startAddressName, string endAddressName, TimeSpan duration)
        {
            TimePeriod = new TimePeriod(duration);
            Waypoints = new string[] { startAddressName, endAddressName };
        }

        public RouteItem()
        {
            TimePeriod = new TimePeriod(new TimeSpan(0,0,0));
        }

        public override string ToString()
        {
            return Duration.ToString() + Waypoints.Aggregate(new Func<string, string, string>((s1,s2) => s1 + ", " + s2));
        }
    }
}
