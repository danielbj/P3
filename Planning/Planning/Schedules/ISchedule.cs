using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;
using Planning.Model.Employees;

namespace Planning.Model.Schedules
{
    public interface ISchedule
    {
        string Name { get; }
        string Description { get; set; }
        bool Approved { get; }
        bool IsSaved { get; }
        Dictionary<Employee, PersonalSchedule> EmployeeSchedules { get; set; }
        void AddTaskItem(TaskItem taskItem, Employee targetEmployee);
        void DeleteTaskItem(TaskItem taskItem);
        void DeleteSchedule();
        void InsertTaskItem(int index, TaskItem taskItem);
        //void AdjustTime(int startIndex);
        void Save();
        void Approve(bool state);
    }
}
