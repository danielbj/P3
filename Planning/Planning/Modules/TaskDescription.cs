using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;

namespace Planning.Model.Modules
{
    public class TaskDescription : ITask
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateDeleted { get; set; }
        //TODO Add frequency if needed.
        public Citizen Citizen { get; set; }
        public string assignment { get; set; }
        public string Description { get; protected set; }
        public string Note { get; private set; }
        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        public TimeSpan Duration { get; private set; }        
        public TimePeriod TimeFrame;
        private List<TaskChange> _taskChanges;


        public TaskDescription(int duration, string description) {//Maybe citizen input TODO
            Duration = TimeSpan.FromMinutes(duration);
            Description = description;
            DateCreated = DateTime.Now;
        }

        public void AddNote() {

        }
        public List<TaskChange> GetTaskChanges(Predicate<TaskChange> Filter)
        {
            List<TaskChange> result = new List<TaskChange>();

            foreach (TaskChange e in _taskChanges)
            {
                if (Filter(e))
                    result.Add(e);
            }
            return result;
        }
       
        public TaskItem MakeNewTaskItem() {
            TaskItem tempTask = new TaskItem(this);
            TaskItems.Add(tempTask);

            return tempTask;
        }

      
        //Impleement equals method
    }
}
