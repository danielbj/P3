using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using BingMapsRESTService.Common.JSON;
using Planning.Model;

namespace Planning.ViewModel
{
    public static class RouteCalculator
    {
        private static int p = 0;

        #region Fields
        /// <summary>
        /// List of all routes as dictionary with waypoints as key and duration as value.
        /// </summary>
        private static List<RouteItem> RouteItems = new List<RouteItem>();

        public static string[] Waypoints { get; set; }  //TODO slet
        private static string _startURLRoute = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json";
        private static string _startURLLocation = "http://dev.virtualearth.net/REST/v1/Locations/DK/adminDistrict/postalCode/locality/";
        private static string _endURLRoute = "&optimize=distance&avoid=minimizeTolls&key=";
        private static string _endURLLocation = "?&key=";
        private static string _bingKey = "ApHwnCobuvyzfVShxnVZ7_PV8Cf7Ok-zySgYQBd1liGGJU_GpPaCAw6kZmHJF9i4";
        private static Route _route;  // TODO slet

        public static TimeSpan Duration
        {
            get
            {
                return TimeSpan.FromSeconds(_route.TravelDuration);
            }
        }

        public static double Distance
        {
            get { return _route.TravelDistance; }
        }

        #endregion
        public static TimeSpan CalculateRouteDuration(string address1, string address2)
        {
            Console.WriteLine("ping" + p++);
            
            string url = CreateRequestURL(address1, address2);
            WebResponse response = MakeRequest(url);
            JObject jsonFile = ProcessRequest(response);
            Route route = DeserializeJSONObjects(jsonFile);

            return TimeSpan.FromSeconds(route.TravelDuration);
        }

        private static string GetWaypoints(string[] waypoints) // TODO slet
        {
            string name = string.Empty;

            for (int i = 0; i < waypoints.Length; i++) {
                if (i + 1 == waypoints.Length)
                    name += waypoints[i];
                else if (i + 2 == waypoints.Length)
                    name += waypoints[i] + " & ";
                else
                    name += waypoints[i] + ", ";
            }

            return name;
        }

        /// <summary>
        /// Checks if the Route already has been calculated and returns a new RouteItem.
        /// </summary>
        /// <param name="startAddress">Used as start address for route.</param>
        /// <param name="endAddress">Used as end address for route.</param>
        /// <returns>Returns RouteItem.</returns>
        public static RouteItem GetRouteItem(Planning.Model.Address startAddress, Planning.Model.Address endAddress)  //TODO slet
        {
            RouteItem routeItem = RouteItems.FirstOrDefault(r => r.Waypoints[0] == startAddress.AddressName && r.Waypoints[1] == endAddress.AddressName);

            if (routeItem != null)
            {
                return routeItem;
            }
            else
            {
                return CalculateAndAddToList(startAddress.AddressName, endAddress.AddressName);
            }
        }

        /// <summary>
        /// Calculates route and adds new route to _routeList.
        /// </summary>
        /// <param name="startAddressName">Used as start address for route.</param>
        /// <param name="endAddressName">Used as end address for route.</param>
        /// <returns>Returns RouteItem.</returns>
        private static RouteItem CalculateAndAddToList(string startAddressName, string endAddressName)
        {
            RouteItem routeItem;

            Waypoints = new string[] { startAddressName, endAddressName };

            WebResponse response = MakeRequest(CreateRequestURL());
            JObject jsonFile = ProcessRequest(response);
            DeserializeJSONObjects1(jsonFile);

            routeItem = new RouteItem(startAddressName, endAddressName, Duration);

            RouteItems.Add(routeItem);

            return routeItem;
        }

        /// <summary>
        /// Finds the route in the dictionary and returns it.
        /// </summary>
        /// <param name="keyValuePair">Contains waypoints and duration.</param>
        /// <returns>Returns RouteItem.</returns>
        private static RouteItem GetExistingRoute(KeyValuePair<Tuple<string, string>, TimeSpan> keyValuePair)
        {
            return new RouteItem(keyValuePair.Key.Item1, keyValuePair.Key.Item2, keyValuePair.Value);
        }

        /// <summary>
        /// Creates a request to a webservice and returns the reponse.
        /// </summary>
        /// <param name="requestURL">Used as request URL.</param>
        /// <returns>Returns response.</returns>
        private static WebResponse MakeRequest(string requestURL)
        {
            //creating a web request with the url
            var request = WebRequest.Create(requestURL);
            //get response 
            try
            {
                return request.GetResponse();
            }
            catch (Exception)
            {
                return MakeRequest(requestURL);
            }
            

            
        }

        /// <summary>
        /// Process the response and converts to a Json object.
        /// </summary>
        /// <param name="response">Used to hold the answer given by the webservice.</param>
        /// <returns>Returns Json object.</returns>
        private static JObject ProcessRequest(WebResponse response) {
            //read response in json, returns raw json string
            string rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();

            //Turns raw string into a key value lookup
            var json = JObject.Parse(rawJson);

            return json;
        }

        private static Route DeserializeJSONObjects(JObject jsonFile)
        {
            JToken resourceToken = jsonFile["resourceSets"][0]["resources"][0];
            Route route = JsonConvert.DeserializeObject<BingMapsRESTService.Common.JSON.Route>(resourceToken.ToString());

            return route;
        }

        private static void DeserializeJSONObjects1(JObject jsonFile)
        {
            JToken resourceToken = jsonFile["resourceSets"][0]["resources"][0];
            _route = JsonConvert.DeserializeObject<BingMapsRESTService.Common.JSON.Route>(resourceToken.ToString());
        }

        public static string CreateRequestURL() {  //TODO slet
            string substring = "";

            for (int i = 0; i < Waypoints.Length; i++)
            {
                substring += "&wp." + i.ToString() + "=" + Waypoints[i];
            }

            return _startURLRoute + substring + _endURLRoute + _bingKey;
        }

        public static string CreateRequestURL(string address1, string address2)
        {
            string waypointString = "&wp.0=" + address1 + "&wp.1=" + address2;

            return _startURLRoute + waypointString + _endURLRoute + _bingKey;
        }

        public static bool ValidateLocation(string address) 
        {
            string url = _startURLLocation + address + _endURLLocation + _bingKey;
            try
            {
                WebResponse response = MakeRequest(url);
                return true;
            }
            catch (Exception)
            {
                return false;                
            }      
        }
    }
}

