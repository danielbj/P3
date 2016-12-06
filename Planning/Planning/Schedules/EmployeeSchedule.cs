using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;
using Planning.Model.Employees;

namespace Planning.Model.Schedules
{
    public class EmployeeSchedule
    {
        public int EmployeeScheduleId { get; set; }
        public List<TaskItem> TaskItems { get; set; }        
        public DateTime EffectiveDate;        
        public Employee Employee { get; set; }
        public TimePeriod TimePeriod { get; set; }



        public EmployeeSchedule(DateTime effectiveFrom, TimeSpan startTime)
        {
            EffectiveDate = effectiveFrom;
            TaskItems = new List<TaskItem>();
            TimePeriod.StartTime = startTime;
            
        }        


        //Input is delegate function etc. t => "t.startTime > 12.00"
        public List<TaskItem> GetTasks(Predicate<TaskItem> Filter) {
            List<TaskItem> result = new List<TaskItem>();

            foreach (TaskItem t in TaskItems) {
                if (Filter(t))
                    result.Add(t);
            }
            return result;
        }

        public List<TaskItem> GetTasks()
        {
            return TaskItems;
        }   

    }
}
