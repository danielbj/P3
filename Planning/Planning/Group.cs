using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;
using Planning.Model.Schedules;
using Planning.Model.Modules;

namespace Planning
{
    public class Group
    {
        public List<Employee> Employees { get; private set; } = new List<Employee>();
        //public ICollection<Schedule> DailySchedules { get; set; }
        //public ICollection<Schedule> TemporarySchedules { get; set; }

        public Dictionary<DateTime, GroupSchedule> DailySchedules { get; set; } = new Dictionary<DateTime, GroupSchedule>();
        public Dictionary<string, GroupSchedule> TemplateSchedules { get; set; } = new Dictionary<string, GroupSchedule>();


        public void AddEmployee(Employee employee)
        {

        }

        public void RemoveEmployee(Employee employee)
        {

        }
    }
}
