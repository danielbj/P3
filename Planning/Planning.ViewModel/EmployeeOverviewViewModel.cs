using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;

namespace Planning.ViewModel
{
    public class EmployeeOverviewViewModel: ViewModelClass
    {

        public GroupAdmin groupAdmin { get; set; }
        public List<Group> Groups
        {
            get
            {
                return groupAdmin.GetAllGroups();
            }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }

        }

        public EmployeeOverviewViewModel()
        {
            groupAdmin = new GroupAdmin();
        }



    }
}
