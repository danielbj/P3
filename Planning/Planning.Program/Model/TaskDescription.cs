﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class TaskDescription 
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
        public int Frequency { get; set; }
        private List<ITaskdescritpionChange> _changes;

        #endregion

        [Obsolete("Only needed for serialization and materialization in Entity Framework", true)]
        public TaskDescription() { }

        public TaskDescription(int duration, string description, Citizen citizen, TimePeriod timeFrame, DateTime startDate, string assignment, int frequencyPerWeek)
        { 
            Duration = TimeSpan.FromMinutes(duration);
            Description = description;
            TaskItems = new List<TaskItem>();
            _changes = new List<ITaskdescritpionChange>();            
            Citizen = citizen;
            TimeFrame = timeFrame;
            StartDate = startDate;
            AssignmentType = assignment;
            Frequency = frequencyPerWeek;
            CreateTaskItem(frequencyPerWeek); 

        }

        private void CreateTaskItem(int count)
        {
            for (int i = 0; i < count; i++)
            {
                TaskItems.Add(new TaskItem(this));
            }
        }

        public void AddNote(string note)
        {
            NoteFromPlanner += note;
        }

        public List<ITaskdescritpionChange> GetTaskChanges(Predicate<ITaskdescritpionChange> Filter)
        {
            return _changes.FindAll(t => Filter(t));
        }

        public void AddTaskChange(ITaskdescritpionChange change)
        {
            _changes.Add(change);
        }

        public override string ToString()
        {
            return Citizen.FirstName + ", " + Citizen.LastName + ", " + Description + ", " + Duration.ToString();
        }


        
    }
}
