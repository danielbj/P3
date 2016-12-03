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
    class Employee_Test {

        private static object[] dateTimeCase = { new DateTime(2016, 12, 21, 12, 00, 00) };

        //[TestCase("lawd", "savior", 1)]
        //[TestCase("lawd", "savior", 2)]
        //[TestCase("lawd", "savior", 3)]
        //public void FieldValidationEmployee_CorrectInput_DoesNotThrow(string fn, string ln, int q) {
        //    Assert.DoesNotThrow(() => new Employee(fn, ln, q));
        //}

        [TestCase("testFirstname", "testLastname", "2016-12-21", "testNote", "testPhoneNumber")]
        public void NewEmployee_EmployeeCreated_EmployeeFirstnameIsSet(string firstname, string lastname, DateTime dateHired, string notes, string phoneNumber)
        {
            Employee newEmployee = new Employee(firstname, lastname, dateHired, notes, phoneNumber);

            Assert.AreEqual("testFirstname", newEmployee.Firstname);
        }

        [TestCase("testFirstname", "testLastname", "2016-12-21", "testNote", "testPhoneNumber")]
        public void NewEmployee_EmployeeCreated_EmployeeLastnameIsSet(string firstname, string lastname, DateTime dateHired, string notes, string phoneNumber)
        {
            Employee newEmployee = new Employee(firstname, lastname, dateHired, notes, phoneNumber);

            Assert.AreEqual("testLastname", newEmployee.Lastname);
        }
    }
}
