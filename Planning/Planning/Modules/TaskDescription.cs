﻿using System;
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

        public Citizen Citizen { get; set; }
        public string assignment { get; set; }
        public string Description { get; protected set; }
        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
        public int Duration { get; private set; }
     

        public TaskDescription(int duration, string description) {
            Duration = duration;
            Description = description;
            DateCreated = DateTime.Now;
        }

        public void EditTask() {

        }
       
        public TaskItem MakeNewTaskItem() {
            TaskItem tempTask = new TaskItem(Duration);
            TaskItems.Add(tempTask);


            return tempTask;
        }
        //Impleement equals method
    }
}
