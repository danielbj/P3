﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public interface ITask
    {
        DateTime DateCreated { get; set; }
        DateTime DateDeleted { get; set; }
        string Description { get; }

        int Duration { get; }
        Citizen Citizen { get; set; }
        string Assignment { get; set; }
        List<TaskItem> TaskItems { get; set; }


        void AddNote();
        TaskItem MakeNewTaskItem();
    }
}
