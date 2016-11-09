using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Modules
{
    public class JobModule : Module
    {
        public RouteModule Route { get; set; }
        public string Description { get; set; }
        public Citizen Reciever { get; set; }

        public enum Status
        {
            Unplanned,
            Expired,
            Cancelled,
            Planned
        }

        public enum EmployeeType
        {
            HomeHelper,
            Sosu,
            Nurse
        }

        public Status status { get; set; } = Status.Unplanned;
        public EmployeeType Requirement { get; set; }

        public JobModule(Citizen citizen, string description, int duration, EmployeeType requirement)
        {
            Reciever = citizen;
            Description = description;
            Duration = duration;
            Requirement = requirement;
        }

        public void CalculateRoute(string startPoint)
        {
            Route = new RouteModule(startPoint, Reciever.Address);            

        }


    }
}
