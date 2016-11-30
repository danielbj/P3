using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning;
using NUnit.Framework;
using Planning.Model.Employees;
using Planning.Model.Modules;

namespace Planning_Test
{
    class Employee_Test {


        [TestCase("lawd", "savior", 1)]
        [TestCase("lawd", "savior", 2)]
        [TestCase("lawd", "savior", 3)]
        public void FieldValidationEmployee_CorrectInput_DoesNotThrow(string fn, string ln, int q) {
            Assert.DoesNotThrow(() => new Employee(fn, ln, q));
        }

        
    }
}
