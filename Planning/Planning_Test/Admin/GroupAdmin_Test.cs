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

        private GroupAdmin _groupAdmin;

        [SetUp]
        public void SetUp()
        {
            _groupAdmin = GroupAdmin.Instance;
        }


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

        ////GetAllGroups()

        [Test]
        public void GetAllGroups_ThereAreGroups_ReturnsAllGroups()
        {
           
            int expected = 7;
            int actual;

            var groups = _groupAdmin.GetAllGroups();

            actual = groups.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetEmployeesOnDuty_NoEmployeesOnDuty_ReturnsEmptyList()
        {
            int expected = 0;

            // var employees = _groupAdmin.GetEmployeesOnDuty(group,new DateTime(2016,1,1));

            //int actual = employees.Count;

            // Assert.AreEqual(expected, actual);
            Assert.Fail();
        }

        [Test]
        public void GetEmployeesOnDuty_EmployeesOnDuty_ReturnsList()
        {
            int expected = 0;

            // var employees = _groupAdmin.GetEmployeesOnDuty(group,new DateTime(2016,1,1));

            //int actual = employees.Count;

            // Assert.AreEqual(expected, actual);
            Assert.Fail();
        }

        [Test]
        public void GetEmployeesOnDuty_GroupDoesNotExistInGroupContainer_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => _groupAdmin.GetEmployeesOnDuty(new Group("group","address"), new DateTime(2016, 1, 1)));
        }

        [Test]
        public void GetGroupInfo_GroupDoesNotExistInGroupContainer_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => _groupAdmin.GetGroupInfo(new Group("group", "address")));
        }

        [Test]
        public void GetGroupInfo_GroupDoesExistInGroupContainer_ReturnsString()
        {
            Assert.Fail();
        }

        [Test]
        public void GetAllEmployeesInGroup_GroupDoesNotExistInGroupContainer_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => _groupAdmin.GetAllEmployeesInGroup(new Group("group", "address")));
        }

        [Test]
        public void GetAllEmployeesInGroup_GroupDoesExistInGroupContainer_ReturnsString()
        {
            Assert.Fail();
        }

        [Test]
        public void DeleteGroup_GroupDoesNotExistInGroupContainer_ReturnsString()
        {
            Assert.Throws<ArgumentException>(() => _groupAdmin.DeleteGroup(new Group("group", "address")));
        }

        [Test]
        public void DeleteGroup_GroupDoesExistInGroupContainer_GroupIsRemoved()
        {
            Assert.Fail();
        }

        [Test]
        public void DeleteGroup_GroupDoesExistInGroupContainer_EmployeesAddedToClipBoard()
        {
            Assert.Fail();
        }
    }
}
