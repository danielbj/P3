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
    class EmployeeCreationViewModel : ViewModelBase
    {
        private GroupAdmin _groupAdmin;

        public ObservableCollection<Group> Groups { get; set; }

        private string _firstname;
        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
            }
        }

        private string _lastname;
        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }

        private string _notes;
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
            }
        }

        private Group _selectedGroup;
        public Group SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }
            set
            {
                if (_selectedGroup != value)
                {
                    _selectedGroup = value;
                }
            }
        }

        private TimeSpan _startTime;
        public TimeSpan StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        private TimeSpan _endTime;
        public TimeSpan EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        public RelayCommand CreateButtonClicked { get; }
        public RelayCommand CancelCommand { get; }


        private NewEmployeeWindow _window;

        public EmployeeCreationViewModel(NewEmployeeWindow window)
        {
            _groupAdmin = GroupAdmin.Instance;

            Groups = new ObservableCollection<Group>(_groupAdmin.GetAllGroups());

            SelectedGroup = Groups[0];

            CreateButtonClicked = new RelayCommand(p => CreateEmployee(), p => true);
            CancelCommand = new RelayCommand(p => Cancel(), p => true);

            _window = window;
        }

        public void CreateEmployee()
        {
            _groupAdmin.NewEmployee(Firstname, Lastname, Notes, PhoneNumber, SelectedGroup, StartTime, EndTime);
            _window.Close();
        }
        public void Cancel()
        {
            _window.Close();
        }


    }
}
