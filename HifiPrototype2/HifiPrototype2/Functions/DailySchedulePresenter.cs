using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HifiPrototype2.View;
using HifiPrototype2.Model;

namespace HifiPrototype2.Functions
{
    public class DailySchedulePresenter
    {
        private DailyScheduleView _view;
        public Employee _employee;
        public string Name { get { return _employee.Name; } }

        public EmployeeSchedule EmployeeSchedule { get; set; }

        public delegate void ScheduleChangedHandler();
        public ScheduleChangedHandler ScheduleChangedEvent;

        public DailySchedulePresenter() { }

        public void SetView(DailyScheduleView view)
        {
            _view = view;

        }

        public void SetEmployeeSchedule(EmployeeSchedule schedule)
        {
            EmployeeSchedule = schedule;
            EmployeeSchedule.AssignmentsChanged += LoadAssignments;
        }

        public void LoadAssignments()
        {
            _view.Clear();

            foreach (Assignment assignment in EmployeeSchedule.Assignments)
            {
                if (assignment.route.Duration > 0)
                {
                    RouteView routeView = new RouteView(assignment.route);
                    _view.AddRoute(routeView);
                }
                
                AssignmentView assignmentView = new AssignmentView(assignment);
                _view.AddAssignment(assignmentView);
            }
        }
    }
}
