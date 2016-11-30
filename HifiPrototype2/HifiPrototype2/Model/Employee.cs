using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2.Model
{
    public class Employee
    {
        public string Name { get; set; }
        public string PhoneNumber {get; set;}
        public List<Assignment> Assignments { get; private set; } = new List<Assignment>();

        public delegate void AssignmentsPropertyChangedEventHandler(); // moved
        public event AssignmentsPropertyChangedEventHandler AssignmentsChanged; // moved

        public Employee() { }

        public Employee(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return Name + " " + PhoneNumber;
        }

        public void AddRandomAssignments(int number)
        {
            for (int i = 0; i < number; i++)
            {
                AddAssignment(Assignment.CreateRandomAssignment(i+1));
            }
        }

        public void AddRandomAssignments()
        {
            for (int i = 0; i < 10; i++)
            {
                AddAssignment(Assignment.CreateRandomAssignment(0));
            }
        }

        public void AddAssignment(Assignment assignment) // moved
        {
            if (Assignments.Count > 0)
            {
                assignment.route.StartTime = Assignments[Assignments.Count - 1].EndTime;
                assignment.route.Duration = Math.Abs( assignment.Location - Assignments[Assignments.Count - 1].Location);

            }
            else
            {
                assignment.route.StartTime = 0;
                assignment.route.Duration = assignment.Location;
            }

            Assignments.Add(assignment);
            assignment.Provider = this;
            RaiseAssignmentsChanged();
        }

        public void RemoveAssignment(Assignment assignment) // moved
        {
            Assignments.Remove(assignment);
            assignment.Provider = null;
            if (Assignments.Count != 0)
                AdjustTime();
            RaiseAssignmentsChanged();
        }

        public void AdjustTime() // moved
        {
            Assignments[0].route.StartTime = 0;
            Assignments[0].route.Duration = Assignments[0].Location;
            for (int i = 1; i < Assignments.Count; i++)
            {
                Assignments[i].route.StartTime = Assignments[i - 1].EndTime;
                Assignments[i].route.Duration = Math.Abs(Assignments[i].Location - Assignments[i - 1].Location);
            }
        }

        public void InsertAssignment(int index, Assignment assignment)// moved 
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
            employee.AddRandomAssignments(5);

            return employee;
        }

        public void RaiseAssignmentsChanged()// moved
        {
                AssignmentsChanged?.Invoke();           
        }

    }
}
