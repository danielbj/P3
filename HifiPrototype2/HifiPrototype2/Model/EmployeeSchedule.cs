using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2.Model
{
    public delegate void AssignmentsPropertyChangedEventHandler();

    public class EmployeeSchedule
    {
        public Employee Employee { get; set; }
        public GroupSchedule GroupSchedule { get; set; }
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

        public string Name
        {
            get { return Employee != null ? Employee.Name : "( Tom )"; }
        }

        
        public event AssignmentsPropertyChangedEventHandler AssignmentsChanged;

        public void RaiseAssignmentsChanged()
        {
            AssignmentsChanged?.Invoke();
        }

        public void AddAssignment(Assignment assignment)
        {
            if (Assignments.Count > 0)
            {
                assignment.route.StartTime = Assignments[Assignments.Count - 1].EndTime;
                assignment.route.Duration = Math.Abs(assignment.Location - Assignments[Assignments.Count - 1].Location);

            }
            else
            {
                assignment.route.StartTime = 0;
                assignment.route.Duration = assignment.Location;
            }

            Assignments.Add(assignment);
            assignment.EmployeeSchedule = this;
            RaiseAssignmentsChanged();
        }

        public void RemoveAssignment(Assignment assignment)
        {
            Assignments.Remove(assignment);
            assignment.EmployeeSchedule = null;

            if (Assignments.Count != 0)
                AdjustTime();
            RaiseAssignmentsChanged();
        }

        public void AdjustTime()
        {
            Assignments[0].route.StartTime = 0;
            Assignments[0].route.Duration = Assignments[0].Location;
            for (int i = 1; i < Assignments.Count; i++)
            {
                Assignments[i].route.StartTime = Assignments[i - 1].EndTime;
                Assignments[i].route.Duration = Math.Abs(Assignments[i].Location - Assignments[i - 1].Location);
            }
        }

        public void InsertAssignment(int index, Assignment assignment)
        {
            Assignments.Insert(index, assignment);
            assignment.EmployeeSchedule = this;

            AdjustTime();
            RaiseAssignmentsChanged();
        }


    }
}
