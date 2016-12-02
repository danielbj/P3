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
        public GroupAdmin()
        {

        }

        public List<Employee> GetEmployeesOnDuty(Group group)
        {
            List<Employee> result = new List<Employee>();
            //group.GetEmployees();

            //predicate workhours, mangler at blive impl.
            return result;
        }

        public void GetGroupInfo()
        {
            //return string with employees & group base address
        }
        
        
            
            
        
    }
}
