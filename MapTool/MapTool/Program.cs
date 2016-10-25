using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MapTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Routes route = new Routes("aalborg", "odense", "århus", "vodskov");
            route.CalculateRoute();
            

            Console.WriteLine(route.CreateRequestURL());

            Console.WriteLine("Distance : " +  route.distance.ToString() + " km");
            Console.WriteLine("Duration : " + route.duration + " (hh:mm:ss)");



            Console.ReadKey();




        }
    }
}
