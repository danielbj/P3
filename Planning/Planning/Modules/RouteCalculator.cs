﻿using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Planning.Model
{
    public static class RouteCalculator
    {
        #region Fields
        /// <summary>
        /// List of all routes as dictionary with waypoints as key and duration as value.
        /// </summary>
        private static Dictionary<Tuple<string, string>, TimeSpan> _routeList = new Dictionary<Tuple<string, string>, TimeSpan>();

        public static string[] Waypoints { get; set; }
        private static string _startURLRoute = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json";
        private static string _startURLLocation = "http://dev.virtualearth.net/REST/v1/Locations/DK/adminDistrict/postalCode/locality/";
        private static string _endURLRoute = "&optimize=distance&avoid=minimizeTolls&key=";
        private static string _endURLLocation = "?&key=";
        //CHRISTIANS: private static string _bingKey = "bAxs3SyskXuDizTOa7TV ~iP31vRCcDDXqsUyfSIw2Fg~AlT-xjscp9jj4mJssfX8axpxg8S1DpGXZx6ZhogikZehBFVu57gJLerkgVfN5qbv";
        private static string _bingKey = "ApHwnCobuvyzfVShxnVZ7_PV8Cf7Ok-zySgYQBd1liGGJU_GpPaCAw6kZmHJF9i4";
        private static BingMapsRESTService.Common.JSON.Route _route;

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

        private static string GetWaypoints(string[] waypoints)
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
        public static RouteItem GetRouteItem(Address startAddress, Address endAddress)
        {
        Tuple<string, string> tempTuple = new Tuple<string, string>(startAddress.AddressName, endAddress.AddressName);
        KeyValuePair<Tuple<string, string>, TimeSpan> keyValuePair = _routeList.FirstOrDefault(r => r.Key.Equals(tempTuple));

            if (!keyValuePair.Equals(default(KeyValuePair<Tuple<string, string>, TimeSpan>)))
            {
                return GetExistingRoute(keyValuePair);
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
            Waypoints = new string[] { startAddressName, endAddressName };

            WebResponse response = MakeRequest(CreateRequestURL());
            JObject jsonFile = ProcessRequest(response);
            DeserializeJSONObjects(jsonFile);

            _routeList.Add(new Tuple<string, string>(Waypoints[0], Waypoints[1]), Duration);

            return new RouteItem(startAddressName, endAddressName, Duration);
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
            var response = request.GetResponse();

            return response;
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

        private static void DeserializeJSONObjects(JObject jsonFile) {
            //is only returning distance&duration between first two waypoints
            //JToken resourceToken = jsonFile["resourceSets"][0]["resources"][0]["routeLegs"][0];
            //routeLegs = JsonConvert.DeserializeObject<RouteLeg>(resourceToken.ToString());

            JToken resourceToken = jsonFile["resourceSets"][0]["resources"][0];
            _route = JsonConvert.DeserializeObject<BingMapsRESTService.Common.JSON.Route>(resourceToken.ToString());


        }

        public static string CreateRequestURL() {
            string substring = "";

            for (int i = 0; i < Waypoints.Length; i++)
            {
                substring += "&wp." + i.ToString() + "=" + Waypoints[i];
            }

            return _startURLRoute + substring + _endURLRoute + _bingKey;
        }

        public static bool ValidateLocation(string address) //kunne måske returnere en address?
        {
            string url = _startURLLocation + address + _endURLLocation + _bingKey;
            try
            {
                WebResponse response = MakeRequest(url); //hvis get response ikke lykkes, returner false i metoden, evt.
            }
            catch (Exception)
            {
                return false;                
            }      
            return true;  
        }
    }
}

