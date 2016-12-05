using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;
using Planning.Model.Modules;

namespace Planning.ViewModel
{
    class GroupAdmin
    {
        GroupContainer _groupContainer;
        ScheduleAdmin _scheduleAdmin; 
        List<TaskDescription> _taskDescriptionsClipBoard; //unassigned taskdescriptions
        List<Employee> _employeeClipBoard;                //unassigned employees
           
        public GroupAdmin()
        {
            _groupContainer = new GroupContainer();
            _taskDescriptionsClipBoard = new List<TaskDescription>();
        }

        public List<Employee> GetEmployeesOnDuty(Group group, DateTime date) //på dagen
        {
            List<Employee> result = new List<Employee>();
            result = group.GetEmployees(e => e.IsWorking(date));

            return result;
        }

        public string GetGroupInfo(Group group)
        {
            return group.ToString(); //returns group name
        }

        public List<Employee> GetAllEmployeesInGroup(Group group)
        {
            return group.GetEmployees();
        }

        public void AssignTaskDecriptionToGroup(TaskDescription taskDescription, Group targetGroup) //taskItems skal i taskClipBoard i scheduleAdmin
        {
            targetGroup.TaskDescriptions.Add(taskDescription);
            _scheduleAdmin.AddTasksToClipBoard(taskDescription.TaskItems);
        }

        public void AddNewGroup(string name, string address)
        {
            Group group = new Group(name, address);
            _groupContainer.AddGroup(group);
        }

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

            //what happens to employees and tasks?
        }
    }
}
