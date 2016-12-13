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
        GroupContainer _groupContainer;
        ScheduleAdmin _scheduleAdmin; 
        List<TaskDescription> _taskDescriptionsClipBoard; //unassigned taskdescriptions
        List<Employee> _employeeClipBoard;                //unassigned employees
        private DatabaseControl DatabaseControl = new DatabaseControl();
           
        public GroupAdmin()
        {
            _groupContainer = DatabaseControl.ReadAll();//DataBaseMockUp.LoadGroups(); // TODO rigtig database
            //_groupContainer = new GroupContainer();
            _taskDescriptionsClipBoard = new List<TaskDescription>();
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
        /// Assigns a TaskDescription to a group.
        /// </summary>
        /// <param name="taskDescription"></param>
        /// <param name="targetGroup"></param>
        public void AssignTaskDecriptionToGroup(TaskDescription taskDescription, Group targetGroup) //taskItems skal i taskClipBoard i scheduleAdmin
        {
            targetGroup.TaskDescriptions.Add(taskDescription);
            _scheduleAdmin.AddTasksToClipBoard(taskDescription.TaskItems);
        }

        /// <summary>
        /// Adds a new group to the group container.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public void AddNewGroup(string name, string address)
        {
            Group group = new Group(name, address);
            _groupContainer.AddGroup(group);
        }
        /// <summary>
        /// Deletes a group from groupcontainer
        /// </summary>
        /// <param name="group"></param>
        public void DeleteGroup(Group group)
        {
            foreach (TaskDescription taskDesription in group.TaskDescriptions)
            {
                _taskDescriptionsClipBoard.Add(taskDesription);
            }

            foreach (Employee employee in group.Employees)
            {
                _employeeClipBoard.Add(employee);
            }
            _groupContainer.RemoveGroup(group);            
        }
    }
}
