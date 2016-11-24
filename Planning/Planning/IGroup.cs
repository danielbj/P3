using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Schedules;
using Planning.Model.Employees;



namespace Planning
{
    public interface IGroup
    {
        List<Employee> Employees { get; set; }
        Dictionary<DateTime, Schedule> DailySchedules { get; set; }
        Dictionary<string, Schedule> TemplateSchedules { get; set; }
    }
}
