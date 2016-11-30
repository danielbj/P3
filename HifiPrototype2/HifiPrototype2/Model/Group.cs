using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2.Model
{
    public class Group
    {
        public string Name { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public Dictionary<DateTime?, GroupSchedule> Shedules { get; set; } = new Dictionary<DateTime?, GroupSchedule>();
        public List<GroupSchedule> Templates { get; set; } = new List<GroupSchedule>();

        public override string ToString()
        {
            return Name;
        }





    }
}
