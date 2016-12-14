using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning;
using NUnit.Framework;
using Planning.Model;

namespace Planning.UnitTest.Model
{
    class Group_Test
    {
        Group _group;

        #region Set up
        [SetUp]
        public void BeforeTest()
        {
            _group = new Group("testName", "testAddress");
        }
        #endregion

        #region New Instance
        [Test]
        [Category("Constructor")]
        public void GroupConstructor_NameIsSet_True()
        {
            Assert.AreEqual("testName", _group.Name);
        }

        [Test]
        [Ignore("No address?")]
        [Category("Constructor")]
        public void GroupConstructor_AddressIsSet_True()
        {
            Assert.AreEqual("testAddress", _group.GroupAddress.AddressName);
        }
        #endregion

        #region Edit Employee
        [Test]
        [Category("Edit Employee")]
        public void AddEmployee_EmployeeAdded_True()
        {
            Employee employee = new Employee("testFirstname", "testLastname", new DateTime(2016, 12, 21), "testNote", "testPhoneNumber");

            _group.AddEmployee(employee);

            Assert.AreEqual(employee, _group.GetEmployees(new Predicate<Employee>(e => e.Firstname == employee.Firstname))[0]);
        }

        [Test]
        [Category("Edit Employee")]
        public void RemoveEmployee_EmployeeRemoved_True()
        {
            Employee employee = new Employee("testFirstname", "testLastname", new DateTime(2016, 12, 21), "testNote", "testPhoneNumber");
            _group.AddEmployee(employee);

            _group.RemoveEmployee(employee);

            Assert.AreEqual(new List<Employee>(), _group.GetEmployees(new Predicate<Employee>(e => e.Firstname == employee.Firstname)));
        }

        [Test] // Should be more GetEmployeeTests
        [Category("Edit Employee")]
        public void GetEmployee_EmployeeGotten_True()
        {
            _group.AddEmployee(new Employee("testFirstname", "testLastname", new DateTime(2016, 12, 21), "testNote", "testPhoneNumber"));
            _group.AddEmployee(new Employee("Bob", "Jespersen", new DateTime(1, 1, 1), "Cleans House Real Good", "22002200"));

            int actual = _group.GetEmployees().Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test] // Should be more GetEmployeeTests
        [Category("Edit Employee")]
        public void GetEmployee_GetsEmployeesThatAreGoodAtCleaning_True()
        {
            _group.AddEmployee(new Employee("testFirstname", "testLastname", new DateTime(2016, 12, 21), "testNote", "testPhoneNumber"));
            _group.AddEmployee(new Employee("Bob", "Jespersen", new DateTime(1, 1, 1), "Cleans House Real Good", "22002200"));

            int actual = _group.GetEmployees(e => e.Notes.Contains("Clean")).Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Edit Schedule
        [Test]
        [Ignore("Not implemented")]
        [Category("Edit Schedule")]
        [Category("NOT FINISHED")]
        public void AddSchedule_StringAsInput_ScheduleAdded()
        {

        }

        [Test]
        [Ignore("Not implemented")]
        [Category("Edit Schedule")]
        [Category("NOT FINISHED")]
        public void AddSchedule_DateTimeAsInput_SchduleAdded()
        {

        }
        #endregion
    }
}
