using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;

namespace Planning.ViewModel
{
    class GroupAdmin
    {
        private Group _group;

        public GroupAdmin(Group group)
        {
            _group = group;
        }

        public List<Employee> GetEmployeesOnDuty(Group group)
        {
            List<Employee> result = new List<Employee>();
            //group.GetEmployees();

            //predicate workhours, mangler at blive impl.
            return result;
        }

        public string GetGroupInfo()
        {
            return _group.ToString();//IMPLEMENT TODO = return string with employees & group base address

        }
    }
}
