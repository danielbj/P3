using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;
using Planning.Model.Schedules;
using Planning.Model.Modules;

namespace Planning.ViewModel
{
    class ScheduleAdmin
    {
        
        public ScheduleAdmin()
        {
            
        }

        public List<TaskChange> GetRecentTaskChanges(TaskDescription task, DateTime fromDate)
        {
            return task.GetTaskChanges(t => t.Date >= fromDate); 
        }

        public void CalcTaskPlacement()
        {

        }

        public void CalcShortestRoute()
        {

        }

        public void CalcRoute()
        {

        }

        public void GetScheduleInfo()
        {

        }


    }
}
