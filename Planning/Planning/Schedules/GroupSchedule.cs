using System;
using System.Collections.Generic;
using Planning.Model.Modules;
using Planning.Model.Schedules;
using Planning.Model.Employees;

namespace Planning.Model.Schedules
{
    public class GroupSchedule : IGroupSchedule    //hvorfor abstract??
    {

        public string Description { get; set; }                            // Might be a method to collect data from container element

        public bool Approved { get; private set; }                          // Shows state of approval
        public bool IsSaved { get; private set; } = false;                  // Shows if saved or not

        public Dictionary<Employee, EmployeeSchedule> EmployeeSchedules { get; set; } = new Dictionary<Employee, EmployeeSchedule>();


        public GroupSchedule()
        {

        }



        public void AssignEmployee(Employee employee, EmployeeSchedule employeeSchedule)
        {

        }

        /// <summary>
        /// Clears all data from schedule
        /// </summary>
        public void DeleteSchedule() { }

        /// <summary>
        /// Saves data and updates
        /// </summary>
        public void Save() { }

        /// <summary>
        /// Set state of Approved variable
        /// </summary>
        /// <param name="state">Indicate approve status</param>
        public void Approve(bool state) { }
    }
}

