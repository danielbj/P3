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
        private Dictionary<DayOfWeek, TimePeriod> _workhours;

        [Obsolete("Only needed for serialization and materialization in Entity Framework", true)]
        public Employee() { }

        public Employee(string firstname, string lastname, DateTime dateHired, string notes, string phoneNumber, TimeSpan startTime, TimeSpan endTime) {
            Firstname = firstname;
            Lastname = lastname;
            Notes = notes;
            DateHired = dateHired;
            PhoneNumber = phoneNumber;
            _workhours = new Dictionary<DayOfWeek, TimePeriod>();
            TimePeriod defaultWorkHours = new TimePeriod(endTime - startTime);
            defaultWorkHours.StartTime = startTime;
            defaultWorkHours.EndTime = endTime;
            SetWorkHoursForWeek(defaultWorkHours);            
        }

        public bool IsWorking(DateTime date)
        {
            DayOfWeek weekday = date.DayOfWeek;
            return _workhours.ContainsKey(weekday);
        }

        public TimePeriod GetWorkHours(DateTime date)
        {
            if (_workhours.ContainsKey(date.DayOfWeek))
            {
                return _workhours[date.DayOfWeek];
            }
            else
            {
                throw new KeyNotFoundException("Work hours not found.");
                //return defaultWorkHours;
            }
        }

        public void SetWorkhours(DayOfWeek day, TimePeriod timeperiod)
        {
            if (_workhours.ContainsKey(day))
            {
                _workhours[day] = timeperiod;  //overrides the old work hours
            }
            else
            {
                _workhours.Add(day, timeperiod);
            }
        }

        public void SetWorkHoursForWeek(TimePeriod timeperiod)
        {
            _workhours.Add(DayOfWeek.Monday, timeperiod);
            for (int i = 0; i <= 6; i++)
            {
                SetWorkhours((DayOfWeek)i, timeperiod);
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
    }
}

