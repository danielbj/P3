using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class EmployeeSchedule
    {
        public List<TaskItem> TaskItems { get; set; }        
        public DateTime EffectiveDate;        
        public Employee Employee { get; set; }
        public TimePeriod TimeFrame { get; set; }



        public EmployeeSchedule(DateTime effectiveFrom, TimeSpan startTime)
        {
            EffectiveDate = effectiveFrom;
            TaskItems = new List<TaskItem>();
            TimeFrame.StartTime = startTime;
            
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
