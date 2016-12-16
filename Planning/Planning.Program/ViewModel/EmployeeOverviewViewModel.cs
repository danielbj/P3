using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.ViewModel
{
    public class EmployeeOverviewViewModel: ViewModelBase
    {

        private DateTime _dateOfMonday;

        public GroupAdmin groupAdmin { get; set; }
        public List<Group> Groups
        {
            get
            {
                return groupAdmin.GetAllGroups();
            }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }

        }

        public TimePeriod Monday { get { return GetWorkHours(_dateOfMonday); } }
        public TimePeriod Tuesday { get { return GetWorkHours(_dateOfMonday.AddDays(1)); } }
        public TimePeriod Wednesday { get { return GetWorkHours(_dateOfMonday.AddDays(2)); } }
        public TimePeriod Thursday { get { return GetWorkHours(_dateOfMonday.AddDays(3)); } }
        public TimePeriod Friday { get { return GetWorkHours(_dateOfMonday.AddDays(4)); } }
        public TimePeriod Saturday { get { return GetWorkHours(_dateOfMonday.AddDays(5)); } }
        public TimePeriod Sunday { get { return GetWorkHours(_dateOfMonday.AddDays(6)); } }

        public EmployeeOverviewViewModel()
        {
            groupAdmin = GroupAdmin.Instance;
            _dateOfMonday = GetDateOfMonday(DateTime.Today);
        }

        private DateTime GetDateOfMonday(DateTime day)
        {
            int daysSinceMonday = ((int) day.DayOfWeek + 6) % 7; 
            DateTime dateOfMonday = day.AddDays(-daysSinceMonday);

            return dateOfMonday;
        }

        private TimePeriod GetWorkHours(DateTime day)
        {
            var timePeriod = _selectedEmployee.GetWorkHours(day);
            if (timePeriod == null)
            {
                timePeriod = new TimePeriod(TimeSpan.FromMinutes(0));
            }
            return timePeriod;
        }





    }
}
