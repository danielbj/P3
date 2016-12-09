using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class TaskDescription// : ITask
    {
        #region Fields
        public DateTime StartDate { get; set; }
        public DateTime DateDeleted { get; set; }
        public Citizen Citizen { get; set; }
        public string Assignment { get; set; }
        public string Description { get; set; }
        public string Note { get; private set; }
        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        public TimeSpan Duration { get; set; }        
        public TimePeriod TimeFrame;
        private List<TaskChange> _taskChanges;
        public int Frequency { get; }

        #endregion

        public TaskDescription(int duration, string description, Citizen citizen, TimePeriod timeFrame, DateTime startDate, string assignment, int frequency)
        { 
            Duration = TimeSpan.FromMinutes(duration);
            Description = description;
            TaskItems = new List<TaskItem>();            
            Citizen = citizen;
            TimeFrame = timeFrame;
            StartDate = startDate;
            Assignment = assignment;
            Frequency = frequency;
            
        }
        public void CreateTaskItem()
        {
            TaskItems.Add(new TaskItem(this)); 
        }


        public void AddNote(string note)
        {
            Note = note;
        }

        public List<TaskChange> GetTaskChanges(Predicate<TaskChange> Filter)
        {
            return _taskChanges.FindAll(t => Filter(t));
        }

        public override string ToString()
        {
            return Citizen.LastName + ", " + Citizen.FirstName + ", " + Assignment + ", " + Duration.ToString();
        }

        //Impleement equals method
    }
}
