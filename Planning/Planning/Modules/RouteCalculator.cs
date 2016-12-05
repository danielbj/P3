﻿using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Planning.Model.Modules
{
    public class RouteCalculator
    {
        #region

        public string[] Waypoints { get; set; }
        private string _startURLRoute = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json";
        private string _startURLLocation = "http://dev.virtualearth.net/REST/v1/Locations/DK/adminDistrict/postalCode/locality/";
        private string _endURLRoute = "&optimize=distance&avoid=minimizeTolls&key=";
        private string _endURLLocation = "?&key=";
        private string _bingKey = "ApHwnCobuvyzfVShxnVZ7_PV8Cf7Ok-zySgYQBd1liGGJU_GpPaCAw6kZmHJF9i4";
        private BingMapsRESTService.Common.JSON.Route _route;

        public TimeSpan Duration
        {
            get
            {
                
                return TimeSpan.FromMinutes(_route.TravelDuration);
            }
        }

        public double Distance
        {
            get { return _route.TravelDistance; }
        }

        #endregion

        private string GetWaypoints(string[] waypoints)
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

        public RouteCalculator(params string[] waypoints)
        {
            Waypoints = waypoints;
            CalculateRoute();
        }

        public void CalculateRoute()
        {
            WebResponse response = MakeRequest(CreateRequestURL());
            JObject jsonFile = ProcessRequest(response);
            DeserializeJSONObjects(jsonFile);

        }

        private WebResponse MakeRequest(string requestURL)
        {
            //creating a web request with the url
            var request = WebRequest.Create(requestURL);
            //get response 
            var response = request.GetResponse();

            return response;
        }

        private JObject ProcessRequest(WebResponse response) {
            //read response in json, returns raw json string
            string rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();

            //Turns raw string into a key value lookup
            var json = JObject.Parse(rawJson);

            return json;
        }

        private void DeserializeJSONObjects(JObject jsonFile) {
            //is only returning distance&duration between first two waypoints
            //JToken resourceToken = jsonFile["resourceSets"][0]["resources"][0]["routeLegs"][0];
            //routeLegs = JsonConvert.DeserializeObject<RouteLeg>(resourceToken.ToString());

            JToken resourceToken = jsonFile["resourceSets"][0]["resources"][0];
            _route = JsonConvert.DeserializeObject<BingMapsRESTService.Common.JSON.Route>(resourceToken.ToString());


        }

        public string CreateRequestURL() {
            string substring = "";

            for (int i = 0; i < Waypoints.Length; i++)
            {
                substring += "&wp." + i.ToString() + "=" + Waypoints[i];
            }

            return _startURLRoute + substring + _endURLRoute + _bingKey;
        }

        public bool ValidateLocation(string address) //kunne måske returnere en address?
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
