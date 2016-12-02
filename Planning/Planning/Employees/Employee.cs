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

        
        //Dictionary with date and worktime.
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }

        private Dictionary<DateTime, TimePeriod> _workHours;


        //private int _qualification;   //vi kan ikke holde styr på kurser osv, så har tilføjet 'notes' i stedet
        //public int Qualification {
        //    get { return _qualification; }
        //    set {
        //        if (0 < value && value < 4)
        //           _qualification = value;
        //        else
        //            throw new ArgumentOutOfRangeException("Qualification", "Must be between 1-3");
        //    }
        //} 


        public Employee(string firstname, string lastname, int qualification, DateTime dateHired, string notes, string phoneNumber) {
            Firstname = firstname;
            Lastname = lastname;
            Notes = notes;
            DateHired = dateHired;
            PhoneNumber = phoneNumber;
            _workHours = new Dictionary<DateTime, TimePeriod>(); 
        }

        public TimePeriod GetWorkHours(DateTime date)
        {
            if (_workHours.ContainsKey(date))
            {
                return _workHours[date];
            }
            else
            {
                throw new ArgumentException("Work hours not found for the date");
            }
        }

        public void AddWorkhours(DateTime date, TimePeriod timeperiod)
        {
            if (_workHours.ContainsKey(date))
            {
                _workHours[date] = timeperiod;  //overrides the old work hours
            }
            else
            {
                _workHours.Add(date, timeperiod);
            }
        }


        public void EditEmployee()//???
        {
            
        }

    }
}

