using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Employees;
using Planning.Model.Schedules;

namespace Planning
{
    public class Group
    {
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Schedule> DailySchedules { get; set; }
        public ICollection<Schedule> TemporarySchedules { get; set; }

    }
}
