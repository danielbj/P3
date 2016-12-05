using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning;
using NUnit.Framework;
using Planning.Model.Employees;

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
        [Ignore("Address implementation needed")]
        [Category("Constructor")]
        [Category("NOT FINISHED")]
        public void GroupConstructor_NameIsSet_True()
        {
            Assert.AreEqual("testName", _group.Name.ToString());
        }

        [Test]
        [Ignore("Address implementation needed")]
        [Category("Constructor")]
        [Category("NOT FINISHED")]
        public void GroupConstructor_AddressIsSet_True()
        {
            Assert.AreEqual("testAddress", _group.GroupAddress.AddressName);
        }
        #endregion

        #region Edit Employee
        [Test]
        [Ignore("Address not implemented")]
        [Category("Edit Employee")]
        [Category("NOT FINISHED")]
        [Description("Depend on method: GetEmployee")]
        public void AddEmployee_EmployeeAdded_True()
        {
            Employee employee = new Employee("testFirstname", "testLastname", new DateTime(2016, 12, 21), "testNote", "testPhoneNumber");

            _group.AddEmployee(employee);

            Assert.AreEqual(employee, _group.GetEmployees(new Predicate<Employee>(e => e.Firstname == employee.Firstname))[0]);
        }

        [Test]
        [Ignore("Address not implemented")]
        [Category("Edit Employee")]
        [Category("NOT FINISHED")]
        [Description("Depend on method: AddEmployee")]
        public void RemoveEmployee_EmployeeRemoved_True()
        {
            Employee employee = new Employee("testFirstname", "testLastname", new DateTime(2016, 12, 21), "testNote", "testPhoneNumber");
            _group.AddEmployee(employee);

            _group.RemoveEmployee(employee);

            Assert.AreEqual(null, _group.GetEmployees(new Predicate<Employee>(e => e.Firstname == employee.Firstname)));
        }

        [Test] // Should be more GetEmployeeTests
        [Ignore("Not implemented")]
        [Category("Edit Employee")]
        [Category("NOT FINISHED")]
        public void GetEmployee_EmployeeGotten_True()
        {

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
