using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;
using Planning.Model.Employees;

namespace Planning.Model.Schedules
{
    public interface IGroupSchedule
    {
        string Name { get; }
        string Description { get; set; }
        bool Approved { get; }
        bool IsSaved { get; }
        Dictionary<Employee, EmployeeSchedule> EmployeeSchedules { get; set; }
        void DeleteSchedule();
        void Save();
        void Approve(bool state);
    }
}
