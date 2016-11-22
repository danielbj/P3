using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;

namespace Planning.ViewModel
{
    class EmployeeViewModel
    {
        IEmployee Employee;
        public EmployeeViewModel(IEmployee employee) {
            Employee = employee;
        }
    }
}
