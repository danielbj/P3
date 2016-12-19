using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.ViewModel
{
    public class GroupAdmin
    {
        private static GroupAdmin _instance;

        public static GroupAdmin Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GroupAdmin();
                }
                return _instance;
            }
        }

        public GroupContainer _groupContainer;
        List<Employee> _employeeClipBoard;  
        private DatabaseControl DatabaseControl = new DatabaseControl();

        
        private GroupAdmin()
        {
            _groupContainer = DataBaseMockUp.LoadGroups();
            //_groupContainer = DatabaseControl.ReadAll();            
            _employeeClipBoard = DataBaseMockUp.LoadEmployees();
            //_employeeClipBoard = DatabaseControl.ReadDistinctEmployees();
            
        }

        public GroupAdmin(GroupContainer groupContainer)
        {
            _groupContainer = groupContainer;
            _employeeClipBoard = new List<Employee>();
            _instance = this;
            
        }

        /// <summary>
        /// Gets all groups in the group container
        /// </summary>
        /// <returns></returns>
        public List<Group> GetAllGroups()
        {
            return _groupContainer.GetGroups();
        }
        /// <summary>
        /// Gets all the employees in a group that are at work a given date.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="date"></param>
        /// <returns>List of employees</returns>
        public List<Employee> GetEmployeesOnDuty(Group group, DateTime date) 
        {
            List<Employee> result = new List<Employee>();
            if (_groupContainer.Groups.Contains(group))
            {
                result = group.GetEmployees(e => e.IsWorking(date));
            }
            else
            {
                throw new ArgumentException("Group not found.");
            }            

            return result;
        }

        public List<Employee> GetEmployeeClipBoard()
        {
            List<Employee> result = new List<Employee>();
            result = _employeeClipBoard;
            result.Sort();
            return result;
        }

        /// <summary>
        /// Gets information about a group.
        /// </summary>
        /// <param name="group"></param>
        /// <returns>A string with group information</returns>
        public string GetGroupInfo(Group group)
        {
            if (_groupContainer.Groups.Contains(group))
            {
                return group.ToString();
            }
            else
            {
                throw new ArgumentException("Group not found");
            }            
        }
        /// <summary>
        /// Gets all the employees in a group.
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public List<Employee> GetAllEmployeesInGroup(Group group)
        {
            if (_groupContainer.Groups.Contains(group))
            {
                return group.GetEmployees();
            }
            else
            {
                throw new ArgumentException("Group not found.");
            }
        }

        /// <summary>
        /// Adds a new group to the group container.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public Group AddNewGroup(string name)
        {
            Group group = new Group(name, "Kærvej 2, 7752 Snedsted");
            _groupContainer.AddGroup(group);
            return group;
        }
        /// <summary>
        /// Deletes a group from groupcontainer
        /// </summary>
        /// <param name="group"></param>
        public void DeleteGroup(Group group)
        {
            foreach (Employee employee in group.Employees)
            {
                _employeeClipBoard.Add(employee);
            }
            _groupContainer.RemoveGroup(group);            
        }

        public void NewEmployee(string firstname, string lastname, string notes, string phoneNumber, Group group, TimeSpan startTime, TimeSpan endTime)
        {
            Employee empl = new Employee(firstname, lastname, DateTime.Today, notes, phoneNumber, startTime, endTime);
            group.AddEmployee(empl);
            //workhours
            
        }

        public void RemoveEmployeeFromGroup(Group group, Employee employee)
        {
            group.RemoveEmployee(employee);
            _employeeClipBoard.Add(employee);
        }

        public void AssignEmployeeToGroup(Group group, Employee employee)
        {
            group.AddEmployee(employee);
            _employeeClipBoard.Remove(employee);
        }

        public void AddNotesToEmployee(Employee employee, string note)
        {
            employee.AddNotes(note);
        }
    }
}
