using System;
using System.Collections.Generic;
using Planning.Model.Modules;
using Planning.Model.Schedules;
using Planning.Model.Employees;

namespace Planning.Model.Schedules
{
    public abstract class GroupSchedule : IGroupSchedule    //hvorfor abstract??
    {
        public abstract string Name { get; }       //se under Date!
        public abstract string Description { get; set; }                            // Might be a method to collect data from container element
       
        public virtual bool Approved { get; private set; }                          // Shows state of approval
        public virtual bool IsSaved { get; private set; } = false;                  // Shows if saved or not
        public DateTime Date { get; set; }   //bør ikke have en date, da de findes i dic i Group + temp har ingen dato!
        public Dictionary<Employee, EmployeeSchedule> EmployeeSchedules { get; set; } = new Dictionary<Employee, EmployeeSchedule>();
        

        public GroupSchedule()
        {

        }


        
        public void AssignEmployee (Employee employee, EmployeeSchedule employeeSchedule)
        {

        }

        /// <summary>
        /// Clears all data from schedule
        /// </summary>
        public abstract void DeleteSchedule();

        /// <summary>
        /// Saves data and updates
        /// </summary>
        public abstract void Save();

        /// <summary>
        /// Set state of Approved variable
        /// </summary>
        /// <param name="state">Indicate approve status</param>
        public abstract void Approve(bool state);
    }
}

