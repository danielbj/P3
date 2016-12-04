using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;
using Planning.Model.Modules;

namespace Planning.ViewModel
{
    class TaskAdmin  
    {
        
        public TaskAdmin()
        {
            
        }

        public List<TaskItem> GetUnplannedTasks()
        {
            List<TaskItem> result = new List<TaskItem>();
            //do something
            return result;
        }

        public List<TaskItem> GetTasksDueToday()
        {
            List<TaskItem> result = new List<TaskItem>();
            //do something
            return result;
        }

        public void GetTaskItemInfo(TaskDescription task)
        {
            task.ToString();
        }

        public string GetRuoteInfo(TaskItem task)
        {
            return task.Route.ToString();
        }
    }
}
