using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class Employee //: IEmployee
    {
        public int EmployeeId { get; set; }
        public DateTime DateHired { get; private set; } = DateTime.MaxValue;
        public DateTime DateResigned { get; private set; } = DateTime.MaxValue;      
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Notes { get; private set; }
        public string PhoneNumber { get; private set; }

        private Dictionary<DateTime, TimePeriod> WorkHours;

        [Obsolete("Only needed for serialization and materialization in Entity Framework", true)]
        public Employee() {  }

        public Employee(string firstname, string lastname, DateTime dateHired, string notes, string phoneNumber) {
            Firstname = firstname;
            Lastname = lastname;
            Notes = notes;
            DateHired = dateHired;
            PhoneNumber = phoneNumber;
            WorkHours = new Dictionary<DateTime, TimePeriod>(); 
        }

        public bool IsWorking(DateTime date)
        {
            return WorkHours.ContainsKey(date);
        }

        public TimePeriod GetWorkHours(DateTime date)
        {
            if (WorkHours.ContainsKey(date))
            {
                return WorkHours[date];
            }
            else
            {
                throw new KeyNotFoundException("Work hours not found for the date");
            }
        }

        public void SetWorkhours(DateTime date, TimePeriod timeperiod)
        {
            if (WorkHours.ContainsKey(date))
            {
                WorkHours[date] = timeperiod;  //overrides the old work hours
            }
            else
            {
                WorkHours.Add(date, timeperiod);
            }
        }

        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }
    }
}

