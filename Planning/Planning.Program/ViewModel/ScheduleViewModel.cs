﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Planning.View;


namespace Planning.ViewModel
{
    public class ScheduleViewModel : ViewModelBase
    {

        #region Events
        public delegate void ButtonClickEventHandler();
        //public delegate void LoadTemplateButtonClickEventHandler(List<EmployeeScheduleViewModel> vM);
        public event ButtonClickEventHandler AddEmployeeButtonClicked;
      //  public event LoadTemplateButtonClickEventHandler LoadTemplateScheduleButtonClicked;

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

        private List<GroupSchedule> _templates;
        public List<GroupSchedule> Templates
        {
            get
            {
                return _templates;
            }
            set
            {
                _templates = value;
                OnPropertyChanged(nameof(Templates));
            }
        }

        private GroupSchedule _selectedTemplate;
        public GroupSchedule SelectedTemplate
        {
            get
            {
                return _selectedTemplate;
            }
            set
            {
                _selectedTemplate = value;
                OnPropertyChanged(nameof(SelectedTemplate));
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
                    return SelectedTemplate;
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
                    OnPropertyChanged(nameof(SelectedTemplate));
                    OnPropertyChanged(nameof(SelectedSchedule));
                }
            }
        }

        public ObservableCollection<Group> Groups { get; set; }

        public RelayCommand ChangeEmployeeCommand { get; }
        public RelayCommand AddEmployeeScheduleCommand { get; }

        public RelayCommand LoadTemplateSchedule { get; }
        public RelayCommand FlushToDatabase { get; }

        #endregion

        #region Fields

        private GroupAdmin _groupAdmin;
        private ScheduleAdmin _scheduleAdmin;
     //   private List<EmployeeScheduleViewModel> EmployeeScheduleViewModels = new List<EmployeeScheduleViewModel>();
        private DatabaseControl DatabaseControl = new DatabaseControl();

        #endregion


        public ScheduleViewModel()
        {
            _groupAdmin = new GroupAdmin();
            _scheduleAdmin = new ScheduleAdmin();
            Groups = new ObservableCollection<Group>(_groupAdmin.GetAllGroups());
            SelectedGroup = Groups[0];
            CalendarTypes = new ObservableCollection<string>() { "Kalenderplaner", "Grundplaner" };
            SelectedCalenderType = CalendarTypes[0];
            SelectedDate = DateTime.Today;
            Templates = SelectedGroup.TemplateSchedules;

            ChangeEmployeeCommand = new RelayCommand(p => ChangeEmployee(p as EmployeeSchedule), p => true);

            AddEmployeeScheduleCommand = new RelayCommand(p => AddEmployeeSchedule(), p => true);

            //CreateEmployeeScheduleViewModels();
            LoadTemplateSchedule = new RelayCommand(parameter => ImportTemplate(), parameter => (SelectedDate != null && SelectedCalenderType == CalendarTypes[0]));

            FlushToDatabase = new RelayCommand(FlushToDatabaseAction, null);
        }

        private void AddEmployeeSchedule()
        {
            _scheduleAdmin.CreateNewEmployeeSchedule(SelectedSchedule, new TimeSpan(6,0,0));
        }

        private void ChangeEmployee(EmployeeSchedule es)
        {
            var window = new EmployeeSelectionWindow();
            var viewModel = new EmployeeSelectionViewModel(_groupAdmin.GetEmployeesOnDuty(SelectedGroup,SelectedDate),window);
            window.DataContext = viewModel;
            window.ShowDialog();

            if (viewModel.Excecute && viewModel.SelectedEmployee != null)
            {
                _scheduleAdmin.AssignEmployeeToEmployeeSchedule(viewModel.SelectedEmployee, es);
                OnPropertyChanged(nameof(SelectedSchedule));
            }

        }

        private void ImportTemplate()
        {
            var window = new TemplateSelectionWindow();
            var viewModel = new TemplateSelectionViewModel(Templates, window);
            window.DataContext = viewModel;
            window.ShowDialog();

            if (viewModel.Excecute && viewModel.SelectedTemplate != null)
            {
                _scheduleAdmin.CreateSchedule(SelectedDate, SelectedGroup);
                var template = viewModel.SelectedTemplate; ;

                var daily = _selectedGroup.GetSchedule(SelectedDate);
               
                daily = _scheduleAdmin.CopyTemplateScheduleToDailySchedule(template);

                _selectedSchedule = daily;
                OnPropertyChanged(nameof(SelectedSchedule));
            }
        }

        

    //    private void CreateEmployeeScheduleViewModels()
    //    {
    //        EmployeeSchedules = SelectedGroup.GetSchedule(SelectedTemplate).EmployeeSchedules;

    //        foreach (EmployeeSchedule es in EmployeeSchedules)
    //        {
    ////            EmployeeScheduleViewModels.Add(new EmployeeScheduleViewModel(es));
    //        }

    //    }

        public void FlushToDatabaseAction(object input)
        {
            DatabaseControl.EraseDatabaseContent(); 

            foreach (Group g in _groupAdmin.GetAllGroups()) {  
                DatabaseControl.AddGroup(g);
            }

            foreach (EmployeeSchedule es in EmployeeSchedules) {
                DatabaseControl.AddEmployeeSchedule(es);
            }

            foreach (TaskItem ti in _scheduleAdmin.GetTaskClipBoard()) {

            }
            
        }
    }
}
