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
    class GroupViewModel : ViewModelBase
    {

        public delegate void GroupsUpdatedHandler();
        public event GroupsUpdatedHandler GroupChange;

        #region Properties
        public List<Group> Groups { get; set; }
        #endregion

        #region Fields
        public RelayCommand NewGroupCommand { get; }
        public RelayCommand NewEmployeeCommand { get; }
        public RelayCommand DeleteEmployeeCommand { get; }
        public RelayCommand DeleteGroupCommand { get; }

        private GroupAdmin _groupAdmin;

        

        #endregion

        public GroupViewModel()
        {
            _groupAdmin = GroupAdmin.Instance;
            Groups = _groupAdmin.GetAllGroups();
            

            NewEmployeeCommand = new RelayCommand(p => CreateNewEmployee());
            DeleteEmployeeCommand = new RelayCommand(p => DeleteEmployee(), p => Groups.Count != 0);
            NewGroupCommand = new RelayCommand(p => CreateNewGroup());
            DeleteGroupCommand = new RelayCommand(p => DeleteGroup(), p => Groups.Count != 0);

        }

        private void CreateNewEmployee()
        {
            var window = new NewEmployeeWindow();
            var viewModel = new EmployeeCreationViewModel(window);
            window.DataContext = viewModel;
            window.ShowDialog();
        }
        private void DeleteEmployee()
        {
            var window = new EmployeeDeleteWindow();
            var viewModel = new EmployeeDeleteViewModel(window);
            window.DataContext = viewModel;
            window.ShowDialog();

            GroupChange?.Invoke();
        }

        private void CreateNewGroup()
        {
            var window = new NewGroupCreationWindow();
            var viewModel = new GroupCreationViewModel(window);
            window.DataContext = viewModel;
            window.ShowDialog();
            
            GroupChange?.Invoke();
        }


        private void DeleteGroup()
        {
            var window = new GroupDeleteWindow();
            var viewModel = new GroupDeleteViewModel(window);
            window.DataContext = viewModel;
            window.ShowDialog();

            GroupChange?.Invoke();
        }
    }
}


