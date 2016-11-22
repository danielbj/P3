using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;



namespace Planning.Model.Employees
{
    public interface IEmployee
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        int Qualification { get; set; }
        //List<Modules.Task> Tasks { get; set; }//Might be unecessary since we have method.


        List<Model.Modules.Task> GetTasks(Predicate<Model.Modules.Task> Filter);
        bool AssignTask(Model.Modules.Task task);
    }
}
