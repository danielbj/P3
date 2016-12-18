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
            _groupAdmin = new GroupAdmin(new GroupContainer());
        }

        [Test]
        public void GetAllGroups_ThereAreNoGroups_ReturnsEmptyList()
        {
            int expected = 0;
            int actual;

            var groups = _groupAdmin.GetAllGroups();

            actual = groups.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllGroups_ThereAreGroups_ReturnsAllGroups()
        {
            _groupAdmin.AddNewGroup("Group 1");
            _groupAdmin.AddNewGroup("Group 2");
            int expected = 2;
            int actual;

            var groups = _groupAdmin.GetAllGroups();
            actual = groups.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetEmployeesOnDuty_NoEmployeesOnDuty_ReturnsEmptyList()
        {
            Group group1 =_groupAdmin.AddNewGroup("Group 1");
            Employee employee = new Employee("Hanne", "Hansen", DateTime.Today, "12345678");
            employee.SetWorkhours(new DateTime(2016, 1, 1), new TimePeriod(TimeSpan.FromHours(8)));
            group1.AddEmployee(employee);

            int expected = 0;

            var employees = _groupAdmin.GetEmployeesOnDuty(group1, new DateTime(2016, 1, 2));

            int actual = employees.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetEmployeesOnDuty_NoEmployeesInGroup_ReturnsEmptyList()
        {
            Group group1 = _groupAdmin.AddNewGroup("Group 1");

            int expected = 0;

            var employees = _groupAdmin.GetEmployeesOnDuty(group1, new DateTime(2016, 1, 2));

            int actual = employees.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetEmployeesOnDuty_GroupNotFoud_ThrowsException()
        {
            Group group1 = new Group("group1", "a 0");

            Assert.Throws<ArgumentException>(() => _groupAdmin.GetEmployeesOnDuty(group1, new DateTime(2016, 1, 2)));
        }

        [Test]
        public void GetEmployeesOnDuty_EmployeesOnDuty_ReturnsListOfEmployeesOnDuty()
        {
            Group group1 = _groupAdmin.AddNewGroup("Group 1");
            Employee employee = new Employee("Hanne", "Hansen", DateTime.Today, "12345678");
            employee.SetWorkhours(new DateTime(2016, 1, 1), new TimePeriod(TimeSpan.FromHours(8)));
            group1.AddEmployee(employee);

            int expected = 1;

            var employees = _groupAdmin.GetEmployeesOnDuty(group1, new DateTime(2016, 1, 1));

            int actual = employees.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
