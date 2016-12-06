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
        #region Fields
        public DateTime DateCreated { get; set; }
        public DateTime DateDeleted { get; set; }
        public Citizen Citizen { get; set; }
        public string Assignment { get; set; }
        public string Description { get; set; }
        public string Note { get; private set; }
        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        public TimeSpan Duration { get; set; }        
        public TimePeriod TimeFrame;
        private List<TaskChange> _taskChanges;
        private enum Days : int { Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        private int _startValue = 12;
        #region Frequency Fields
        /// <summary>
        /// The factor that determines how often the task should occur.
        /// </summary>
        private double _frequencyFactor;
        /// <summary>
        /// Magic number that enables occurance of tasks. Is set to 12 since it is easily dividable by 2, 3 and 4.
        /// </summary>
        private readonly static double _frequencyNumber = 12;
        /// <summary>
        /// The current frequency value.
        /// </summary>
        private double _frequencyCounter; 
        public DateTime StartDate { get; set; }
        #endregion
        #endregion

        public TaskDescription(int duration, string description, Citizen citizen, TimePeriod timeFrame, DateTime startDate, string assignment, double frequency)
        { 
            Duration = TimeSpan.FromMinutes(duration);
            Description = description;
            DateCreated = DateTime.Now;
            TaskItems = new List<TaskItem>();            
            Citizen = citizen;
            TimeFrame = timeFrame;
            StartDate = startDate;
            Assignment = assignment;
            _frequencyFactor = frequency * _frequencyNumber; //Test if valid else no frequency
            //AddNewTaskItems(count);
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
       
        //private void AddNewTaskItems(int count) {
        //    for (int i = 1; i <= count; i++)
        //    {
        //        TaskItem newTaskItem = new TaskItem(this);
        //        TaskItems.Add(newTaskItem);
        //    }
        //}

        public TaskItem MakeNewTaskItem(DayOfWeek selectedDate)
        {
            if (_startValue >= 12 && _frequencyFactor > _frequencyNumber)
            {
                int startDayIndex = (int)((Days)Enum.Parse(typeof(Days), selectedDate.ToString()));

                _startValue = (int)(((_frequencyFactor) * (2 - startDayIndex)) / 7);
                _frequencyCounter += _frequencyFactor + _startValue;
            }

            if (_frequencyFactor > _frequencyNumber)
            {
                DoDaily();
            }
            else
            {
                DoWeekly();
            }
        }

        public override string ToString()
        {
            return Citizen.LastName + ", " + Citizen.FirstName + ", " + Assignment + ", " + Duration.ToString();
        }

        //Impleement equals method
    }
}
