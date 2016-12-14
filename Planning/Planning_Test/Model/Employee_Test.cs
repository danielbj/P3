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
    class Employee_Test
    {

        #region Fields
        Employee _employee;
        TimePeriod _timePeriod;

        static Employee[] EmployeeCases =
        {
            new Employee("", "", new DateTime(1,1,1), "", ""),
            new Employee("ThisIsAVeryLongFirstname", "ThisIsAVeryLongLastName", new DateTime(9999,12,31), "ThisIsAVeryLongNoteAboutAbsolutelyNothing", "99999999")
        };
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

        #region Edit work hours
        [TestCase("2016-12-21")]
        [TestCase("0001-01-01")]
        [TestCase("9999-12-31")]
        [Category("Edit WorkHours")]
        public void SetWorkHours_CorrectInput_WorkHoursSet(DateTime dateTime)
        {
            _employee.SetWorkhours(dateTime, _timePeriod);

            Assert.AreEqual(_timePeriod, _employee.GetWorkHours(dateTime));
        }

        [TestCase("2016-12-21")]
        [TestCase("0001-01-01")]
        [TestCase("9999-12-31")]
        [Category("Edit WorkHours")]
        public void GetWorkHours_GetsWorkHours_True(DateTime dateTime)
        {
            TimePeriod time;
            _employee.SetWorkhours(dateTime, _timePeriod);

            time = _employee.GetWorkHours(dateTime);

            Assert.AreEqual(_timePeriod, time);
        }

        [TestCase("2016-12-21")]
        [TestCase("0001-01-01")]
        [TestCase("9999-12-31")]
        [Category("Edit WorkHours")]
        public void IsWorking_ChecksIfWorking_True(DateTime dateTime)
        {
            _employee.SetWorkhours(dateTime, _timePeriod);

            Assert.IsTrue(_employee.IsWorking(dateTime));
        } 
        #endregion

        [Test, TestCaseSource("EmployeeCases")]
        [Category("ToString Method")]
        public void ToString_GetsFirstnameAndLastName_AreEqual(Employee employee)
        {
            Assert.AreEqual(employee.Firstname + " " + employee.Lastname, employee.ToString());
        }
    }
}
