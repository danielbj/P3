using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model.Modules
{
    public interface ITask
    {
        string Description { get; }

        //string Duration { get; }
        //int StartTime { get; set; }
        //int EndTime { get; set; }
        int CalculateSize();
        Citizen Citizen { get; set; }
        string assignment { get; set; }
        void EditTask();
        List<TaskItem> TaskItems { get; set; }
    }
}
