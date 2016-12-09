using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public interface IGroupSchedule
    {
        string Name { get; }
        string Description { get; set; }
        bool Approved { get; }
        bool Saved { get; }
        Dictionary<Employee, EmployeeSchedule> EmployeeSchedules { get; set; }
        void DeleteSchedule();
        void Save();
        void Approve(bool state);
    }
}
