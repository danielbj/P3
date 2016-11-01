using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2
{
    public class SchedulePresenter
    {
        
        private ScheduleView _view;
        


        public SchedulePresenter() { }

        public void SetView(ScheduleView view)
        {
            _view = view;
        }

        public void AddDailySchedule(Employee employee)
        {
            var dailyScheduleView = new DailyScheduleView(employee);
            _view.AddDailySchedule(dailyScheduleView);
        }

    }
}
