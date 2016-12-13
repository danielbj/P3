﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class EmployeeSchedule
    {
        public int EmployeeScheduleId { get; set; }
        public List<TaskItem> TaskItems { get; set; }        
        public DateTime EffectiveDate = DateTime.MaxValue;
        public Employee Employee { get; set; }
        public TimePeriod TimePeriod { get; set; }

        [Obsolete("Only needed for serialization and materialization in Entity Framework", true)]
        public EmployeeSchedule() {    }

        public EmployeeSchedule(DateTime effectiveFrom, TimeSpan startTime)
        {
            EffectiveDate = effectiveFrom;
            TaskItems = new List<TaskItem>();
            TimePeriod = new TimePeriod(startTime);
            //SetRelevantTasks(TaskItems); //Skal ske når du laver en kalenderplan
        }

        //Bliver kaldt når du åbner en grundplan som kalenderplan.
        //public void SetRelevantTasks(List<TaskItem> taskItems)
        //{
        //    taskItems.Add(new TaskItem());
        //    TaskItems = taskItems;
        //    TaskItems = GetTasks(t => CheckIfRelevant(t));

        //}

        //private bool CheckIfRelevant(TaskItem taskItem)
        //{
        //    return (EffectiveDate - taskItem.FirstTimeLoaded).Days % taskItem.TaskDescription.Frequency == 0;
        //}

        //Input is delegate function etc. t => "t.startTime > 12.00"
        public List<TaskItem> GetTasks(Predicate<TaskItem> Filter)
        {
            return TaskItems.FindAll(t => Filter(t));
        }

        public List<TaskItem> GetTasks()
        {
            return TaskItems;
        }   

    }
}
