using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.Modules
{
    public interface ITask
    {
        DateTime DateCreated { get; set; }
        DateTime DateDeleted { get; set; }
        string Description { get; }

        int Duration { get; }
        Citizen Citizen { get; set; }
        string assignment { get; set; }
        List<TaskItem> TaskItems { get; set; }


        void EditTask();
        TaskItem MakeNewTaskItem();
    }
}
