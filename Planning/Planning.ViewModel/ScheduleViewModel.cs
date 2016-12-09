using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using System.Collections.ObjectModel;

namespace Planning.ViewModel
{
    public class ScheduleViewModel : ViewModelClass
    {

        #region Properties

        public ObservableCollection<string> CalendarTypes { get; set; }

        private string _selectedCalendarType;
        public string SelectedCalendarType
        {
            get
            {
                return _selectedCalendarType;
            }
            set
            {
                _selectedCalendarType = value;
                OnPropertyChanged(nameof(SelectedCalendarType));
                OnPropertyChanged(nameof(SelectedSchedule));
            }
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                OnPropertyChanged(nameof(SelectedSchedule));
            }
        }

        private List<string> _templatenames;
        public List<string> TemplateNames
        {
            get
            {
                return _templatenames;
            }
            set
            {
                _templatenames = value;
                OnPropertyChanged(nameof(TemplateNames));
            }
        }

        private string _selectedTemplateName;
        public string SelectedTemplateName
        {
            get
            {
                return _selectedTemplateName;
            }
            set
            {
                _selectedTemplateName = value;
                OnPropertyChanged(nameof(SelectedTemplateName));
                OnPropertyChanged(nameof(SelectedSchedule));
            }
        }

        public GroupSchedule _selectedSchedule;
        public GroupSchedule SelectedSchedule
        {
            get
            {
                if (SelectedCalendarType == CalendarTypes[0])
                {
                    return SelectedGroup.GetSchedule(SelectedDate);
                }
                else
                {
                    return SelectedGroup.TemplateSchedules[SelectedTemplateName];
                }
            }
        }

        public ObservableCollection<EmployeeSchedule> EmployeeSchedules { get; set; }

        private Group _selectedGroup;
        public Group SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }
            set
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(Group));
                OnPropertyChanged(nameof(SelectedSchedule));
                TemplateNames = _selectedGroup.TemplateSchedules.Keys.ToList<string>();
                if (TemplateNames.Count > 0)
                {
                    SelectedTemplateName = TemplateNames[0];
                }
                OnPropertyChanged(nameof(SelectedTemplateName));
            }
        }

        public ObservableCollection<Group> Groups { get; set; }

        #endregion

        #region Fields

        private GroupAdmin _groupAdmin;
        private ScheduleAdmin _scheduleAdmin;

        #endregion


        public ScheduleViewModel()
        {
            _groupAdmin = new GroupAdmin();
            _scheduleAdmin = new ScheduleAdmin();
            Groups = new ObservableCollection<Group>(_groupAdmin.GetAllGroups());
            SelectedGroup = Groups[0];
            CalendarTypes = new ObservableCollection<string>() { "Kalenderplaner", "Grundplaner" };
            SelectedCalendarType = CalendarTypes[0];
            SelectedDate = DateTime.Today;
        }
    }
}
