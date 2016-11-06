using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2
{
    public class DailySchedulePresenter
    {
        private DailyScheduleView _view;
        private Employee _employee;
        public string Name { get { return _employee.Name; } }

        public delegate void ScheduleChangedHandler();
        public ScheduleChangedHandler ScheduleChangedEvent;

        public DailySchedulePresenter() { }

        public void SetView(DailyScheduleView view)
        {
            _view = view;
        }

        public void SetEmployee(Employee employee)
        {
            _employee = employee;
            _employee.AssignmentsChanged += LoadAssignments;
        }

        public void LoadAssignments()
        {
            _view.Clear();
            foreach (Assignment assignment in _employee.Assignments)
            {
                AssignmentView assignmentView = new AssignmentView(assignment);
                _view.AddAssignment(assignmentView);
            }
        }


    }
}
