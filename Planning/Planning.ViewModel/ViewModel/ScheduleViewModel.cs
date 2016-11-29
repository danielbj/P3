using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;
using Planning.Model.Schedules;

namespace Planning.ViewModel
{
    class ScheduleViewModel
    {
        IGroupSchedule Schedule;
        public ScheduleViewModel(IGroupSchedule schedule) {
            Schedule = schedule;
        }
    }
}
