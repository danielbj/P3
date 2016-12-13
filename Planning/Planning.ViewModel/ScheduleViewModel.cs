using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Planning.ViewModel
{
    public class ScheduleViewModel : ViewModelBase
    {

        #region Events
        public delegate void ButtonClickEventHandler();
        public delegate void LoadTemplateButtonClickEventHandler(List<EmployeeScheduleViewModel> vM);
        public event ButtonClickEventHandler AddEmployeeButtonClicked;
        public event LoadTemplateButtonClickEventHandler LoadTemplateScheduleButtonClicked;

        #endregion

        #region Properties

        public ObservableCollection<string> CalendarTypes { get; set; }

        private string _selectedCalendarType;
        public string SelectedCalenderType
        {
            get
            {
                return _selectedCalendarType;
            }
            set
            {
                _selectedCalendarType = value;
                OnPropertyChanged(nameof(SelectedCalenderType));
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
                if (SelectedCalenderType == CalendarTypes[0])
                {
                    return SelectedGroup.GetSchedule(SelectedDate);
                }
                else
                {
                    return SelectedGroup.GetSchedule(SelectedTemplateName);
                }
            }
        }

        private List<EmployeeSchedule> _employeeSchedules;
        public List<EmployeeSchedule> EmployeeSchedules {
            get { return _employeeSchedules; }
            set {
                if(_employeeSchedules != value) {
                    _employeeSchedules = value;
                    OnPropertyChanged(nameof(EmployeeSchedules));
                }
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
                if(_selectedGroup != value)
                {
                    _selectedGroup = value;
                    OnPropertyChanged(nameof(SelectedGroup));
                    OnPropertyChanged(nameof(SelectedSchedule));
                    List<string> tempStrings = new List<string>();
                    foreach (GroupSchedule gs in _selectedGroup.TemplateSchedules.FindAll(g => g is GroupSchedule)) {
                        tempStrings.Add(gs.Name);
                    }
                    TemplateNames = tempStrings;
                    if (TemplateNames.Count > 0)
                    {
                        SelectedTemplateName = TemplateNames[0];
                    }
                    OnPropertyChanged(nameof(SelectedTemplateName));
                }
            }
        }

        public ObservableCollection<Group> Groups { get; set; }

        public RelayCommand AddEmployeeColumn { get; }
        public RelayCommand LoadTemplateSchedule { get; }
        public RelayCommand FlushToDatabase { get; }

        #endregion

        #region Fields

        private GroupAdmin _groupAdmin;
        private ScheduleAdmin _scheduleAdmin;
        private List<EmployeeScheduleViewModel> EmployeeScheduleViewModels = new List<EmployeeScheduleViewModel>();
        private DatabaseControl DatabaseControl = new DatabaseControl();

        #endregion


        public ScheduleViewModel() {
            _groupAdmin = new GroupAdmin();
            _scheduleAdmin = new ScheduleAdmin();
            Groups = new ObservableCollection<Group>(_groupAdmin.GetAllGroups());
            SelectedGroup = Groups[0];
            CalendarTypes = new ObservableCollection<string>() { "Kalenderplaner", "Grundplaner" };
            SelectedCalenderType = CalendarTypes[0];
            SelectedDate = DateTime.Today;



            AddEmployeeColumn = new RelayCommand(parameter => AddEmployeeButtonClicked?.Invoke(), null);

            CreateEmployeeScheduleViewModels();
            LoadTemplateSchedule = new RelayCommand(parameter => LoadTemplateScheduleButtonClicked?.Invoke(EmployeeScheduleViewModels), parameter => (SelectedDate != null && SelectedCalenderType == CalendarTypes[0]));

            FlushToDatabase = new RelayCommand(FlushToDatabaseAction, null);
        }
        private void CreateEmployeeScheduleViewModels() {
            EmployeeSchedules = Groups.First(g => g.Equals(SelectedGroup)).GetSchedule(SelectedTemplateName).EmployeeSchedules;

            foreach (EmployeeSchedule es in EmployeeSchedules) {
                EmployeeScheduleViewModels.Add(new EmployeeScheduleViewModel(es));
            }

        }

        public void FlushToDatabaseAction(object input)
        {
            DatabaseControl.EraseDatabaseContent(); 

            foreach (Group g in _groupAdmin.GetAllGroups()) {  
                DatabaseControl.AddGroup(g);
                //Store Daily Schedules
                //foreach (KeyValuePair<string, GroupSchedule> KVgs in g.TemplateSchedules) {
                //    DatabaseControl.AddGroupSchedule(KVgs.Value);
                //}
                //foreach (KeyValuePair<DateTime, GroupSchedule> KVgs in g.DailySchedules) {
                //    DatabaseControl.AddGroupSchedule(KVgs.Value);
                //}
            }

            //foreach (EmployeeSchedule es in EmployeeSchedules) {
            //    //DatabaseControl.AddEmployeeSchedule(es);
            //}

            foreach (TaskItem ti in _scheduleAdmin.GetTaskClipBoard()) {
                DatabaseControl.AddTaskItem(ti);
            }

            



            
        }
    }
}
