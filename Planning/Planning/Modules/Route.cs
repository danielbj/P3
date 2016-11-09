using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Planning.Modules
{
    public class RouteModule : Module
    {
        #region

        public string[] Waypoints { get; set; }
        private string _startURL = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json";
        private string _endURL = "&optimize=distance&avoid=minimizeTolls&key=";
        private string _bingKey = "ApHwnCobuvyzfVShxnVZ7_PV8Cf7Ok-zySgYQBd1liGGJU_GpPaCAw6kZmHJF9i4";        
        private BingMapsRESTService.Common.JSON.Route _route;

        public override int Duration
        {
            get
            {
                TimeSpan time = TimeSpan.FromSeconds(_route.TravelDuration);
                return (int)time.TotalMinutes;
            }                        
        }

        public double Distance
        {
            get { return _route.TravelDistance; }
        }
        #endregion

        private static string GetWaypoints(string[] waypoints)
        {
            string name = string.Empty;

            for (int i = 0; i < waypoints.Length; i++)
            {
                if (i + 1 == waypoints.Length)
                    name += waypoints[i];
                else if (i + 2 == waypoints.Length)
                    name += waypoints[i] + " & ";
                else
                    name += waypoints[i] + ", ";
            }

            return name;
        } 

        public RouteModule(params string[] waypoints)          
        {
           Waypoints = waypoints;
            CalculateRoute();         
        }

        public void CalculateRoute()
        {
            WebResponse response =  MakeRequest(CreateRequestURL());
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

        private JObject ProcessRequest(WebResponse response)
        {
            //read response in json, returns raw json string
            string rawJson = new StreamReader(response.GetResponseStream()).ReadToEnd();

            //Turns raw string into a key value lookup
            var json = JObject.Parse(rawJson);

            return json;                  
        }

        private void DeserializeJSONObjects(JObject jsonFile)
        {
            //is only returning distance&duration between first two waypoints
            //JToken resourceToken = jsonFile["resourceSets"][0]["resources"][0]["routeLegs"][0];
            //routeLegs = JsonConvert.DeserializeObject<RouteLeg>(resourceToken.ToString());

            JToken resourceToken = jsonFile["resourceSets"][0]["resources"][0];
            _route = JsonConvert.DeserializeObject<BingMapsRESTService.Common.JSON.Route>(resourceToken.ToString());
            

        }

        public string CreateRequestURL()
        {            
            string substring = "";

            for (int i = 0; i < Waypoints.Length; i++)
            {
                substring += "&wp." + i.ToString() + "=" + Waypoints[i];
            }            

            return _startURL + substring + _endURL + _bingKey;
        }


    }
}
