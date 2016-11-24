using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;

namespace Planning.Model.Modules
{
    public class Task : ITask
    {
        public DateTime DateCreated;
        public DateTime DateDeleted;
        
        public Citizen Citizen { get; set; }
        public string assignment { get; set; }
        public string Description { get; protected set; }
        public List<TaskItem> TaskItems { get; set; }

     

        public Task(string description) {
            Description = description;
            DateCreated = DateTime.Now;
        }

        public void EditTask() {

        }
        

        public int CalculateSize()
        {
            throw new NotImplementedException();
        }


        //Impleement equals method
    }
}
