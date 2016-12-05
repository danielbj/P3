using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;

namespace Planning.Model.Modules
{
    public class TaskDescription// : ITask
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateDeleted { get; set; }
        //TODO Add frequency .
        public Citizen Citizen { get; set; }
        public string Assignment { get; set; }
        public string Description { get; set; }
        public string Note { get; private set; }
        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        public TimeSpan Duration { get; set; }        
        public TimePeriod TimeFrame;
        private List<TaskChange> _taskChanges;
        public DateTime StartDate { get; set; }

        public TaskDescription(int duration, string description, Citizen citizen, TimePeriod timeFrame, DateTime startDate, string assignment, int count) { 
            Duration = TimeSpan.FromMinutes(duration);
            Description = description;
            DateCreated = DateTime.Now;
            TaskItems = new List<TaskItem>();            
            Citizen = citizen;
            TimeFrame = timeFrame;
            StartDate = startDate;
            Assignment = assignment;
            AddNewTaskItems(count);
        }

        public void AddNote(string note)
        {
            Note = note;
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
       
        private void AddNewTaskItems(int count) {
            for (int i = 1; i <= count; i++)
            {
                TaskItem newTaskItem = new TaskItem(this);
                TaskItems.Add(newTaskItem);
            }
        }

        public TaskItem MakeNewTaskItem()
        {
            TaskItem tempTask = new TaskItem(this);
            TaskItems.Add(tempTask);

            return tempTask;
        }

        public override string ToString()
        {
            return Citizen.LastName + ", " + Citizen.FirstName + ", " + Assignment + ", " + Duration.ToString();
        }

        //Impleement equals method
    }
}
