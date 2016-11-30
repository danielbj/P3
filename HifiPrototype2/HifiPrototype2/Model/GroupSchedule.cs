using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2.Model
{
    public class GroupSchedule
    {

        public DateTime Date { get; set; }
        public string Name { get; set; }
        private EmployeeSchedule _unplanned = new EmployeeSchedule();

        public List<EmployeeSchedule> EmployeeScheduleList { get; set; } = new List<EmployeeSchedule>();
        public List<Assignment> Unplanned { get { return _unplanned.Assignments; } }

        public void SubscribeToEvent(AssignmentsPropertyChangedEventHandler handler)
        {
            _unplanned.AssignmentsChanged += handler;
            _unplanned.GroupSchedule = this;
        }



        public override string ToString()
        {
            return Name;
        }

        public void UnplanAssignment(Assignment assigment)
        {
            _unplanned.AddAssignment(assigment);
        }

    }
}
