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
        public DateTime StartDate { get; set; } = DateTime.MaxValue;
        public int TaskDescriptionID { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.MaxValue;
        public DateTime DateDeleted { get; set; } = DateTime.MaxValue;
        public Citizen Citizen { get; set; }
        public string AssignmentType { get; set; }
        public string Description { get; set; }
        public string NoteFromPlanner { get; private set; }
        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        public TimeSpan Duration { get; set; }        
        public TimePeriod TimeFrame;
        private List<TaskChange> _taskChanges;

        #endregion

        [Obsolete("Only needed for serialization and materialization in Entity Framework", true)]
        public TaskDescription() {       }

        public TaskDescription(int duration, string description, Citizen citizen, TimePeriod timeFrame, DateTime startDate, string assignment)
        { 
            Duration = TimeSpan.FromMinutes(duration);
            Description = description;
            TaskItems = new List<TaskItem>();            
            Citizen = citizen;
            TimeFrame = timeFrame;
            StartDate = startDate;
            AssignmentType = assignment;            
        }

        public void CreateTaskItem()
        {
            TaskItems.Add(new TaskItem(this)); 
        }


        public void SetNote(string note)
        {
            NoteFromPlanner = note;
        }

        public List<TaskChange> GetTaskChanges(Predicate<TaskChange> Filter)
        {
            return _taskChanges.FindAll(t => Filter(t));
        }

        public override string ToString()
        {
            return Citizen.LastName + ", " + Citizen.FirstName + ", " + AssignmentType + ", " + Duration.ToString();
        }

        //Impleement equals method
    }
}
