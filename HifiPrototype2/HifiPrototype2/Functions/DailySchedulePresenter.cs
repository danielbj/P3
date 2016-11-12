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
        public Employee _employee;
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

        private void SortAssignments() {
            _employee.Assignments.OrderByDescending((a) => a.StartTime).ThenByDescending((a) => a.Duration);

            //for (int i = 1; i < _employee.Assignments.Count; i++) {
            //        if (_employee.Assignments[i].StartTime < _employee.Assignments[i - 1].EndTime) {
            //            _employee.Assignments[i].StartTime = _employee.Assignments[i - 1].EndTime + 1;
            //            _employee.Assignments[i].EndTime = (_employee.Assignments[i].StartTime + _employee.Assignments[i].Duration);
            //        }

            //}
            
        }

        public void LoadAssignments()
        {
            _view.Clear();
            SortAssignments();

            foreach (Assignment assignment in _employee.Assignments)
            {
                AssignmentView assignmentView = new AssignmentView(assignment);
                _view.AddAssignment(assignmentView);
            }
        }


    }
}
