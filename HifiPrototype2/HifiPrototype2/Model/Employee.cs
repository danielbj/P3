using System.Collections.Generic;

namespace HifiPrototype2
{
    public class Employee
    {
        public string Name { get; set; }
        public List<Assignment> Assignments { get; private set; } = new List<Assignment>();

        public delegate void AssignmentsPropertyChangedEventHandler();
        public event AssignmentsPropertyChangedEventHandler AssignmentsChanged;

        public void AddRandomAssignments(int number)
        {
            for (int i = 0; i < number; i++)
            {
                AddAssignment(Assignment.CreateRandomAssignment(i+1));
            }
        }

        public void AddAssignment(Assignment assignment)
        {
            if (Assignments.Count > 0)
            {
                assignment.StartTime = Assignments[Assignments.Count - 1].EndTime;
            }
            else
            {
                assignment.StartTime = 0;
            }

            Assignments.Add(assignment);
            assignment.Provider = this;
            RaiseAssignmentsChanged();
        }

        public void RemoveAssignment(Assignment assignment)
        {
            Assignments.Remove(assignment);
            assignment.Provider = null;
            AdjustTime();
            RaiseAssignmentsChanged();
        }

        public void AdjustTime()
        {
            for (int i = 1; i < Assignments.Count; i++)
            {
                Assignments[i].StartTime = Assignments[i - 1].EndTime;
            }
        }

        public void InsertAssignment(int index, Assignment assignment)
        {
            Assignments.Insert(index, assignment);
            assignment.Provider = this;
            AdjustTime();
            RaiseAssignmentsChanged();
        }

        public static Employee CreateRandomEmployee(string name)
        {
            var employee = new Employee();
            employee.Name = name;
            employee.AddRandomAssignments(3);

            return employee;
        }

        public void RaiseAssignmentsChanged()
        {
                AssignmentsChanged?.Invoke();           
        }

    }
}
