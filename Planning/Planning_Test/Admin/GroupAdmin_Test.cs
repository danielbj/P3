using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Planning.ViewModel;
using Planning.Model;

namespace Planning.UnitTest.Admin

{
    [TestFixture]
    class GroupAdmin_Test
    {
        //GetAllGroups()
        //GetEmployeesOnDuty(Group group, DateTime date) 
        //GetEmployeeClipBoard()
        //GetGroupInfo(Group group)
        //GetAllEmployeesInGroup(Group group)
        //AssignTaskDecriptionToGroup(TaskDescription taskDescription, Group targetGroup) //taskItems skal i taskClipBoard i scheduleAdmin
        //AddNewGroup(string name)
        //DeleteGroup(Group group)
        //NewEmployee(string firstname, string lastname, string notes, string phoneNumber, Group group, TimeSpan startTime, TimeSpan endTime)
        //RemoveEmployeeFromGroup(Group group, Employee employee)
        //AssignEmployeeToGroup(Group group, Employee employee)
        //AddNotesToEmployee(Employee employee, string note)


        #region TestGroups
        private Group NewTestGroup(int i)
        {
            List<Group> TestGroups = new List<Group>();
            TestGroups.Add(new Group("Snedsted", "Kærvej 3, 7752, Snedsted, Denmark"));
            TestGroups.Add(new Group("Hørdum", "Kærvej 3, 7752, Snedsted, Denmark"));
            TestGroups.Add(new Group("Koldby", "Kærvej 3, 7752, Snedsted, Denmark"));

            return TestGroups[i];
        }


        #endregion

        #region GroupContainer
        private GroupContainer NewTestGroupContainer()
        {
            GroupContainer grpContainer = new GroupContainer();
            grpContainer.AddGroup(NewTestGroup(0));
            grpContainer.AddGroup(NewTestGroup(1));
            return grpContainer;
        }

        #endregion

        #region TestEmployees

        private Employee NewTestEmployee(int i)
        {
            List<Employee> TestEmployees = new List<Employee>();

            TestEmployees.Add(new Employee("Hanne", "Hansen", DateTime.Today, "Hjemmeplejer", "11111111", TimeSpan.FromHours(8), TimeSpan.FromHours(16)));
            TestEmployees.Add(new Employee("Lars", "Larsen", DateTime.Today, "Hjemmeplejer", "11111111", TimeSpan.FromHours(8), TimeSpan.FromHours(16)));
            TestEmployees.Add(new Employee("Trine", "Trinesen", DateTime.Today, "Hjemmeplejer", "11111111", TimeSpan.FromHours(8), TimeSpan.FromHours(16)));
            TestEmployees.Add(new Employee("Grethe", "Grethesen", DateTime.Today, "Hjemmeplejer", "11111111", TimeSpan.FromHours(8), TimeSpan.FromHours(16)));
            TestEmployees.Add(new Employee("Kanokporn", "kanokpornsen", DateTime.Today, "Hjemmeplejer", "11111111", TimeSpan.FromHours(8), TimeSpan.FromHours(16)));
            TestEmployees.Add(new Employee("Sidse", "Sidsesen", DateTime.Today, "Hjemmeplejer", "11111111", TimeSpan.FromHours(8), TimeSpan.FromHours(16)));
            TestEmployees.Add(new Employee("Nico", "Nicosen", DateTime.Today, "Hjemmeplejer", "11111111", TimeSpan.FromHours(8), TimeSpan.FromHours(16)));

            return TestEmployees[i];
        }

        #endregion




    }
}
