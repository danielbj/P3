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
            _group = new Group("testName", "Snerlevej 11, Aalborg");
        }
        #endregion

        #region Constructor
        [Test]
        [Category("Constructor")]
        public void GroupConstructor_NameIsSet_True()
        {
            Assert.AreEqual("testName", _group.Name);
        }

        [Test]
        [Category("Constructor")]
        public void GroupConstructor_AddressIsSet_True()
        {
            Assert.AreEqual("Snerlevej 11, Aalborg", _group.GroupAddress.AddressName);
        }
        #endregion

        #region Edit Employee
        [Test]
        [Category("Edit Employee")]
        public void AddEmployee_EmployeeAdded_True()
        {
            Employee employee = new Employee("testFirstname", "testLastname", new DateTime(2016, 12, 21), "testNote", "testPhoneNumber",new TimeSpan(6,0,0), new TimeSpan(12,0,0));

            _group.AddEmployee(employee);

            Assert.AreEqual(employee, _group.GetEmployees(new Predicate<Employee>(e => e.Firstname == employee.Firstname))[0]);
        }

        [Test]
        [Category("Edit Employee")]
        public void RemoveEmployee_EmployeeRemoved_True()
        {
            Employee employee = new Employee("testFirstname", "testLastname", new DateTime(2016, 12, 21), "testNote", "testPhoneNumber",new TimeSpan(6, 0, 0), new TimeSpan(12, 0, 0));

            _group.RemoveEmployee(employee);

            Assert.AreEqual(new List<Employee>(), _group.GetEmployees(new Predicate<Employee>(e => e.Firstname == employee.Firstname)));
        }

        [Test] // Should be more GetEmployeeTests
        [Category("Edit Employee")]
        public void GetEmployee_EmployeeGotten_True()
        {
            _group.AddEmployee(new Employee("testFirstname", "testLastname", new DateTime(2016, 12, 21), "testNote", "testPhoneNumber", new TimeSpan(6, 0, 0), new TimeSpan(12, 0, 0)));
            _group.AddEmployee(new Employee("Bob", "Jespersen", new DateTime(1, 1, 1), "Cleans House Real Good", "22002200", new TimeSpan(6, 0, 0), new TimeSpan(12, 0, 0)));

            int actual = _group.GetEmployees().Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test] // Should be more GetEmployeeTests
        [Category("Edit Employee")]
        public void GetEmployee_GetsEmployeesThatAreGoodAtCleaning_True()
        {
            _group.AddEmployee(new Employee("testFirstname", "testLastname", new DateTime(2016, 12, 21), "testNote", "testPhoneNumber", new TimeSpan(6, 0, 0), new TimeSpan(12, 0, 0)));
            _group.AddEmployee(new Employee("Bob", "Jespersen", new DateTime(1, 1, 1), "Cleans House Real Good", "22002200", new TimeSpan(6, 0, 0), new TimeSpan(12, 0, 0)));

            int actual = _group.GetEmployees(e => e.Notes.Contains("Clean")).Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Edit Schedule
        [TestCase("Name")]
        [TestCase("")]
        [Category("Edit Schedule")]
        public void AddDailySchedule_GroupScheduleAdded_AreEqual(string name)
        {
            GroupSchedule schedule = new GroupSchedule(name);

            _group.AddDailySchedule(schedule);

            string actual = _group.DailySchedules[0].Name;
            string expected = name;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Name")]
        [TestCase("")]
        [Category("Edit Schedule")]
        public void AddScheduleTemplate_GroupScheduleAdded_AreEqual(string name)
        {
            GroupSchedule schedule = new GroupSchedule(name);

            _group.AddScheduleTemplate(schedule);

            string actual = _group.TemplateSchedules[0].Name;
            string expected = name;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Name")]
        [TestCase("")]
        [Category("Edit Schedule")]
        public void RemoveDailySchedule_GroupScheduleRemoved_AreEqual(string name)
        {
            GroupSchedule schedule = new GroupSchedule(name);
            _group.AddDailySchedule(schedule);

            _group.RemoveDailySchedule(schedule);

            int actual = _group.DailySchedules.Count;
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Name")]
        [TestCase("")]
        [Category("Edit Schedule")]
        public void RemoveTemplateSchedule_GroupScheduleRemoved_AreEqual(string name)
        {
            GroupSchedule schedule = new GroupSchedule(name);
            _group.AddScheduleTemplate(schedule);

            _group.RemoveScheduleTmeplate(schedule);

            int actual = _group.DailySchedules.Count;
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("2016-12-21")]
        [TestCase("1-1-1")]
        [Category("Edit Schedule")]
        public void GetSchedule_GetsDailySchedule_AreEqual(DateTime dateTime)
        {
            GroupSchedule schedule = new GroupSchedule(dateTime);
            _group.AddDailySchedule(schedule);

            DateTime actual = _group.GetSchedule(dateTime).Date;
            DateTime expected = dateTime;

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Name")]
        [TestCase("")]
        [Category("Edit Schedule")]
        public void GetSchedule_GetsTemplateSchedule_AreEqual(string name)
        {
            GroupSchedule schedule = new GroupSchedule(name);
            _group.AddScheduleTemplate(schedule);

            string actual = _group.GetSchedule(name).ToString();
            string expected = name;

            Assert.AreEqual(expected, actual);
        }
        #endregion

        [TestCase("Name")]
        [Category("ToString Method")]
        public void ToString_GetsName_AreEqual(string name)
        {
            _group.Name = name;

            string actual = _group.ToString();
            string expected = name;

            Assert.AreEqual(expected, actual);
        }
    }
}
