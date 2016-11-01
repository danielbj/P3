using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2
{
    public class Employee
    {
        public string Name { get; set; }
        public List<Assignment> Assignments { get; private set; } = new List<Assignment>();

        public delegate void AssignmentsPropertyChangedEventHandler();
        public AssignmentsPropertyChangedEventHandler AssignmentsChanged;

        public void AddRandomAssignments(int number)
        {
            for (int i = 0; i < number; i++)
            {
                AddAssignment(Assignment.CreateRandomAssignment());
            }
        }

        public void AddAssignment(Assignment assignment)
        {
            Assignments.Add(assignment);
            assignment.Provider = this;
            RaiseAssignmentsChanged();
        }

        public void RemoveAssignment(Assignment assignment)
        {
            Assignments.Remove(assignment);
            assignment.Provider = null;
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
            if (AssignmentsChanged != null)
            {
                AssignmentsChanged();
            }
        }

    }
}
