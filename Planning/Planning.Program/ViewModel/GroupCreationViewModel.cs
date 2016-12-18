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
    class GroupCreationViewModel
    {
        private GroupAdmin _groupAdmin;

        public ObservableCollection<Group> Groups { get; set; }


        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public RelayCommand CreateButtonClicked { get; }


        private NewGroupCreationWindow _window;

        public GroupCreationViewModel(NewGroupCreationWindow window)
        {
            _groupAdmin = GroupAdmin.Instance;

            Groups = new ObservableCollection<Group>(_groupAdmin.GetAllGroups());

            CreateButtonClicked = new RelayCommand(p => CreateGroup(), p => true);

            _window = window;
        }

        public void CreateGroup()
        {
            _groupAdmin.AddNewGroup(Name);
            _window.Close();
        }
    }
}
