using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BingMapsRESTService.Common.JSON;

namespace MapTool
{
    class Routes
    {
        #region

        public string[] Waypoints { get; set; }
        private string startURL = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json";
        private string endURL = "&optimize=distance&avoid=minimizeTolls&key=";
        private string BingKey = "ApHwnCobuvyzfVShxnVZ7_PV8Cf7Ok-zySgYQBd1liGGJU_GpPaCAw6kZmHJF9i4";        
        private Route route;

        public string duration
        {
            get
            {
                TimeSpan time = TimeSpan.FromSeconds(route.TravelDuration);
                return time.ToString();
            }                        
        }

        public double distance
        {
            get { return route.TravelDistance; }
        }
        #endregion


        public Routes(params string[] waypoints)
        {
            this.Waypoints = waypoints;            
        }

        public void CalculateRoute()
        {
            WebResponse response =  MakeRequest(CreateRequestURL());
            Console.WriteLine("response ok");
            JObject jsonFile = ProcessRequest(response);
            Console.WriteLine("jobject ok");
            DeserializeJSONObjects(jsonFile);
            Console.WriteLine("deserialize ok");
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
            route = JsonConvert.DeserializeObject<Route>(resourceToken.ToString());
            

        }

        public string CreateRequestURL()
        {            
            string substring = "";

            for (int i = 0; i < Waypoints.Length; i++)
            {
                substring += "&wp." + i.ToString() + "=" + Waypoints[i];
            }            

            return startURL + substring + endURL + BingKey;
        }
    }
}
