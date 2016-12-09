using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Planning.Model
{
    public interface IGroup
    {
        List<Employee> Employees { get; set; }
        Dictionary<DateTime, GroupSchedule> DailySchedules { get; set; }
        Dictionary<string, GroupSchedule> TemplateSchedules { get; set; }
    }
}
