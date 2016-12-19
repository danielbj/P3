using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Planning.View;
using System.Windows;

namespace Planning.ViewModel
{
    class GroupViewModel : ViewModelBase
    {
        public RelayCommand NewGroupCommand { get; }
        public RelayCommand NewEmployeeCommand { get; }
        //LoadTemplateScheduleCommand = new RelayCommand(p => ImportTemplate(), p => (SelectedDate != null && SelectedCalendarType == CalendarTypes[0]));

        private GroupAdmin _groupAdmin;

        private List<Employee> TempEmployees = new List<Employee>();

        public GroupViewModel()
        {
            _groupAdmin = GroupAdmin.Instance;
            NewEmployeeCommand = new RelayCommand(p => CreateNewEmployee());
            NewGroupCommand = new RelayCommand(p => CreateNewGroup());
        }

        private void CreateNewEmployee()
        {
            var window = new NewEmployeeWindow();
            var viewModel = new EmployeeCreationViewModel(TempEmployees, window);
            window.DataContext = viewModel;
            window.ShowDialog();
        }

        private void CreateNewGroup()
        {
            var window = new NewGroupCreationWindow();
            var viewModel = new GroupCreationViewModel(window);
            window.DataContext = viewModel;
            window.ShowDialog();
        }
    }
}


