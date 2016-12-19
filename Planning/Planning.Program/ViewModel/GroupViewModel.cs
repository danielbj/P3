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
using System.Collections.Specialized;
using System.ComponentModel;

namespace Planning.ViewModel
{
    public class GroupViewModel : ViewModelBase
    {
        public delegate void GroupsUpdatedHandler();
        public event GroupsUpdatedHandler GroupChange;
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
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        public RelayCommand NewGroupCommand { get; }
        public RelayCommand NewEmployeeCommand { get; }
        //LoadTemplateScheduleCommand = new RelayCommand(p => ImportTemplate(), p => (SelectedDate != null && SelectedCalendarType == CalendarTypes[0]));

        private GroupAdmin _groupAdmin;

        public List<Group> Groups { get; set; }

        private List<Employee> TempEmployees = new List<Employee>();

        public GroupViewModel()
        {
            _groupAdmin = GroupAdmin.Instance;
            Groups = _groupAdmin.GetAllGroups();
            //_groupAdmin._groupContainer.PropertyChanged += _groupContainer_PropertyChangedHandler;

            NewEmployeeCommand = new RelayCommand(p => CreateNewEmployee());
            NewGroupCommand = new RelayCommand(p => CreateNewGroup());
        }

        //private void _groupContainer_PropertyChangedHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    Groups = new ObservableCollection<Group>(_groupAdmin.GetAllGroups());
        //}

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
            
            GroupChange?.Invoke();
        }
    }
}


