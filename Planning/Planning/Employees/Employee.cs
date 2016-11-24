using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;
using Planning.Model.Modules;

namespace Planning.Model.Employees
{
    public class Employee : IEmployee
    {
        public DateTime DateHired { get; set; }
        public DateTime DateResigned { get; set; }

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
        

        public Employee(string firstname, string lastname, int qualification) {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Qualification = qualification;
        }

        public void EditEmployee() {

        }
        
    }
}

