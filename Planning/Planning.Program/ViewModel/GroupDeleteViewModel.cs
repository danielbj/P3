using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.View;
using Planning.Model;

namespace Planning.ViewModel
{
    public class GroupDeleteViewModel : ViewModelBase
    {
        private GroupAdmin _groupAdmin;
        private GroupDeleteWindow _window;
        public RelayCommand ConfirmCommand { get; }
        public RelayCommand CancelCommand { get; }

        private List<Group> _groups;
        public List<Group> GroupList {
            get { return _groups; }
            set {
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

        public GroupDeleteViewModel(GroupDeleteWindow window)
        {
            _window = window;
            _groupAdmin = GroupAdmin.Instance;
            GroupList = _groupAdmin.GetAllGroups();
            SelectedGroup = GroupList.First();
           


            ConfirmCommand = new RelayCommand(p => Confirm(), p => SelectedGroup != null);
            CancelCommand = new RelayCommand(p => Cancel(), p => true);
        }

        private void Confirm()
        {
            _groupAdmin.DeleteGroup(SelectedGroup);
            _window.Close();
        }

        private void Cancel()
        {
            _window.Close();
        }
    }
}
