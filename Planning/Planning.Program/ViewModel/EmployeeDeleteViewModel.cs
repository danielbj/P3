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
        public RelayCommand ConfirmCommand { get; }
        public RelayCommand CancelCommand { get; }

        private List<Employee> _employees;
        public List<Employee> EmployeeList 
            {
            get { return _employees; }
            set 
            {
                if (value == _employees)
                    return;
                _employees = value;
                OnPropertyChanged(nameof(EmployeeList));
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
                if (value == _groups)
                    return;
                _groups = value;
                OnPropertyChanged(nameof(GroupList));
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
            _window = window;
            _groupAdmin = GroupAdmin.Instance;
            GroupList = _groupAdmin.GetAllGroups();
            SelectedGroup = GroupList.First();
            EmployeeList = _groupAdmin.GetAllEmployeesInGroup(SelectedGroup);
            SelectedEmployee = EmployeeList.FirstOrDefault();


            ConfirmCommand = new RelayCommand(p => Confirm(), p => SelectedEmployee != null);
            CancelCommand = new RelayCommand(p => Cancel(), p => true);

        }

        private void Confirm()
        {
            _groupAdmin.RemoveEmployeeFromGroup(SelectedGroup, SelectedEmployee);
            _window.Close();
        }

        private void Cancel()
        {
            _window.Close();
        }
    }
}
