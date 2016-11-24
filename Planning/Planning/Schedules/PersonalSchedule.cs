using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;

namespace Planning.Model.Schedules
{
    public class PersonalSchedule
    {
        private List<TaskItem> TaskItems = new List<TaskItem>();
        public DateTime DateCreated;
        public DateTime DateDeleted;
        public DateTime EffectiveDate;






        //Input is delegate function etc. t => "t.startTime > 12.00"
        public List<TaskItem> GetTasks(Predicate<TaskItem> Filter) {
            List<TaskItem> result = new List<TaskItem>();

            foreach (TaskItem t in TaskItems) {
                if (Filter(t))
                    result.Add(t);
            }
            return result;
        }

        public bool AssignTask(TaskItem task) {//This is to plan.
            if (task == null)
                return false;
            TaskItems.Add(task);
            return TaskItems.Contains(task);
        }

        public bool RemoveTask(TaskItem tItem) {//This is to unplan.
            return TaskItems.Remove(tItem);
        }

        public bool LockTask() {
            return true;
        }


    }
}
