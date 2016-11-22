using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;
using Planning.Model.Modules;

namespace Planning.Employees
{
    public abstract class Employee : IEmployee
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        private int _qualification;
        public int Qualification {
            get { return _qualification; }
            set {
                if (0 < value && value < 4)
                    _qualification = value;
                else
                    throw new ArgumentOutOfRangeException("Qualification", "Must be between 1-3");
            }
        } //May be enum

        //Group and schedule links?
        // PDA
        private List<Modules.Task> Tasks { get; set; }

        public Employee(string firstname, string lastname, int qualification) {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Qualification = qualification;
        }

        //Input is delegate function etc. t => "t.startTime > 12.00"
        public List<Modules.Task> GetTasks(Predicate<Modules.Task> Filter) {
            List<Modules.Task> result = new List<Modules.Task>();

            foreach (Modules.Task t in Tasks) {
                if (Filter(t))
                    result.Add(t);
            }
            return result;
        }

        public bool AssignTask(Modules.Task task) {
            if (task == null)
                return false;
            Tasks.Add(task);
            return Tasks.Contains(task);
        }
    }
}

