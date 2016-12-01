using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;
using Planning.Model.Schedules;
using System.ComponentModel;

namespace Planning.ViewModel
{
    public class ScheduleViewModel : INotifyPropertyChanged
    {
        //IGroupSchedule Schedule;
        //public ScheduleViewModel(IGroupSchedule schedule)
        //{
        //    Schedule = schedule;
        //}

        private GroupContainer _groupContainer = new GroupContainer();

        // Internal property variables
        private Group _selectedGroup;

        // Events
        public event PropertyChangedEventHandler PropertyChanged;

        public ScheduleViewModel()
        {
            // Load from database
            // _groupContainer.Groups = GetAllGroups();
        }

        public Group SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }
            private set
            {
                _selectedGroup = value;
            }
        }


        /// <summary>
        /// Event property invoke
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GroupScheduleSelected()
        {

        }
    }
}
