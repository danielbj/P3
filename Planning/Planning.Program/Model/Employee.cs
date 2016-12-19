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
        private Dictionary<DateTime, TimePeriod> _workhours;

        [Obsolete("Only needed for serialization and materialization in Entity Framework", true)]
        public Employee() { }

        public Employee(string firstname, string lastname, DateTime dateHired, string notes, string phoneNumber, TimeSpan startTime, TimeSpan endTime)
        {
            Firstname = firstname;
            Lastname = lastname;
            Notes = notes;
            DateHired = dateHired;
            PhoneNumber = phoneNumber;
            _workhours = new Dictionary<DateTime, TimePeriod>();           
        }

        public Employee(string firstname, string lastname, DateTime dateHired, string phoneNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateHired = dateHired;
            PhoneNumber = phoneNumber;
            _workhours = new Dictionary<DateTime, TimePeriod>();
        }

        public bool IsWorking(DateTime date)
        {
            return _workhours.ContainsKey(date);
        }

        public TimePeriod GetWorkHours(DateTime date)
        {
            if (_workhours.ContainsKey(date))
            {
                return _workhours[date];
            }
            else
            {
                throw new KeyNotFoundException("Work hours not found.");
                //return defaultWorkHours;
            }
        }

        public void SetWorkhours(DateTime date, TimePeriod timeperiod)
        {
            if (_workhours.ContainsKey(date))
            {
                _workhours[date] = timeperiod;  //overrides the old work hours
            }
            else
            {
                _workhours.Add(date, timeperiod);
            }
        }

        public void AddNotes(string notes)
        {
            Notes += notes;
        }

        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }

        public override bool Equals(object obj) {
            Employee tempEmpl = obj as Employee;
            if (tempEmpl != null)
                return String.Equals(tempEmpl.ToString(), this.ToString());
            return false;
        }

        public override int GetHashCode() {
            return this.ToString().GetHashCode();
        }
    }
}

