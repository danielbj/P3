using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning;
using NUnit.Framework;
using Planning.Model.Employees;
using Planning.Model.Modules;

namespace Planning.UnitTest.Model
{
    class Employee_Test
    {

        #region Fields
        Employee _employee;
        TimePeriod _timePeriod;
        #endregion

        #region Set Up
        [OneTimeSetUp]
        public void InitEmployee()
        {
            _employee = new Employee("testFirstname", "testLastname", new DateTime(2016,12,21), "testNote", "testPhoneNumber");
        }

        [OneTimeSetUp]
        public void InitTimePeriod()
        {
            _timePeriod = new TimePeriod(new TimeSpan(12, 0, 0));
        }
        #endregion

        #region Create new Employee test
        //[TestCase("lawd", "savior", 1)]
        //[TestCase("lawd", "savior", 2)]
        //[TestCase("lawd", "savior", 3)]
        //public void FieldValidationEmployee_CorrectInput_DoesNotThrow(string fn, string ln, int q) {
        //    Assert.DoesNotThrow(() => new Employee(fn, ln, q));
        //}

        [TestCase("testFirstname", "testLastname", "2016-12-21", "testNote", "testPhoneNumber")]
        [Category("Constructor")]
        public void NewEmployee_EmployeeCreated_EmployeeFirstnameIsSet(string firstname, string lastname, DateTime dateHired, string notes, string phoneNumber)
        {
            Employee newEmployee = new Employee(firstname, lastname, dateHired, notes, phoneNumber);

            Assert.AreEqual("testFirstname", newEmployee.Firstname);
        }

        [TestCase("testFirstname", "testLastname", "2016-12-21", "testNote", "testPhoneNumber")]
        [Category("Constructor")]
        public void NewEmployee_EmployeeCreated_EmployeeLastnameIsSet(string firstname, string lastname, DateTime dateHired, string notes, string phoneNumber)
        {
            Employee newEmployee = new Employee(firstname, lastname, dateHired, notes, phoneNumber);

            Assert.AreEqual("testLastname", newEmployee.Lastname);
        }

        [TestCase("testFirstname", "testLastname", "2016-12-21", "testNote", "testPhoneNumber")]
        [Category("Constructor")]
        public void NewEmployee_EmployeeCreated_EmployeeDateHiredSetIsSet(string firstname, string lastname, DateTime dateHired, string notes, string phoneNumber)
        {
            Employee newEmployee = new Employee(firstname, lastname, dateHired, notes, phoneNumber);

            Assert.AreEqual("2016-12-21", newEmployee.DateHired.ToString("yyyy-MM-dd"));
        }

        [TestCase("testFirstname", "testLastname", "2016-12-21", "testNote", "testPhoneNumber")]
        [Category("Constructor")]
        public void NewEmployee_EmployeeCreated_EmployeeNoteIsSet(string firstname, string lastname, DateTime dateHired, string notes, string phoneNumber)
        {
            Employee newEmployee = new Employee(firstname, lastname, dateHired, notes, phoneNumber);

            Assert.AreEqual("testNote", newEmployee.Notes);
        }

        [TestCase("testFirstname", "testLastname", "2016-12-21", "testNote", "testPhoneNumber")]
        [Category("Constructor")]
        public void NewEmployee_EmployeeCreated_EmployeePhoneNumberIsSet(string firstname, string lastname, DateTime dateHired, string notes, string phoneNumber)
        {
            Employee newEmployee = new Employee(firstname, lastname, dateHired, notes, phoneNumber);

            Assert.AreEqual("testPhoneNumber", newEmployee.PhoneNumber);
        }
        #endregion

        [TestCase("2016-12-21")]
        [Category("Edit WorkHours")]
        public void SetWorkHours_CorrectInput_WorkHoursSet(DateTime dateTime)
        {
            _employee.SetWorkhours(dateTime, _timePeriod);

            Assert.AreEqual(_timePeriod, _employee.GetWorkHours(dateTime));
        }

        //TODO: TestCase for edit employee
    }
}
