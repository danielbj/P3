﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.Modules
{
    public class TaskItem
    {
               
        public enum Status
        {
            Unplanned,
            Expired,
            Cancelled,
            Planned
        }

        public Status State { get; set; }
        public bool Locked;
        public RouteItem Route;        
        public TimePeriod TimePeriod { get; set; }
        public TaskDescription TaskDescription { get; } //Skal den være her? 
        public DateTime FirstTimeLoaded { get; set; } = new DateTime(0, 0, 0, 12, 0, 0);

        public TaskItem(TaskDescription taskDescription)
        {
            TaskDescription = taskDescription;
            State = Status.Unplanned;
            Locked = false;
            TimePeriod = new TimePeriod(taskDescription.Duration);              
        }

        public override string ToString()
        {
            return TaskDescription.ToString(); 
        }
    }
}
