using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using Planning.View;

namespace Planning.ViewModel
{
    public class EmployeeDeleteViewModel : ViewModelBase
    {
        private GroupAdmin _groupAdmin;
        private EmployeeDeleteWindow _window;

        private List<Employee> _employees;
        public List<Employee> EmployeeList 
            {
            get { return _employees; }
            set 
            {

            }
        }
        private Employee _selectedEmployee;
        public Employee SelectedEmployee {
            get { return _selectedEmployee; }
            set {
                if (value == _selectedEmployee)
                    return;
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }
        private List<Group> _groups;
        public List<Group> GroupList 
        {
            get { return _groups; }
            set 
            {

            }
        }
        private Group _selectedGroup;
        public Group SelectedGroup {
            get { return _selectedGroup; }
            set {
                if (value == _selectedGroup)
                    return; 
                _selectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }

        public EmployeeDeleteViewModel(EmployeeDeleteWindow window)
        {
            _groupAdmin = GroupAdmin.Instance;
            GroupList = _groupAdmin.GetAllGroups();
            EmployeeList = _groupAdmin.GetAllEmployeesInGroup(SelectedGroup);

        }
    }
}
