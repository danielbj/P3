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
    public class ScheduleViewModel : ViewModelBase
    {

        #region Events
        public delegate void ButtonClickEventHandler();
        //public delegate void LoadTemplateButtonClickEventHandler(List<EmployeeScheduleViewModel> vM);
        public event ButtonClickEventHandler AddEmployeeButtonClicked;
        //  public event LoadTemplateButtonClickEventHandler LoadTemplateScheduleButtonClicked;

        #endregion

        #region Properties

        //private List<TaskItem> _unplannedTaskItems;
        //public List<TaskItem> UnplannedTaskItems
        //{
        //    get
        //    {
        //        return _unplannedTaskItems;
        //    }
        //    set
        //    {
        //        _unplannedTaskItems = value;
        //        OnPropertyChanged(nameof(UnplannedTaskItems));
        //    }
        //}

        public ObservableCollection<TaskItem> UnplannedTaskItems
        {
            get
            {
                return new ObservableCollection<TaskItem>(_scheduleAdmin.GetTaskClipBoard());
            }
        }

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
                OnPropertyChanged(nameof(EmployeeSchedules));
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
                OnPropertyChanged(nameof(EmployeeSchedules));
            }
        }

   

        public List<GroupSchedule> Templates
        {
            get
            {
                return SelectedGroup.TemplateSchedules;
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
                OnPropertyChanged(nameof(EmployeeSchedules));
            }
        }

        public GroupSchedule _selectedSchedule;
        public GroupSchedule SelectedSchedule
        {
            get
            {
                if (SelectedCalendarType == CalendarTypes[0])
                {
                    var s = SelectedGroup.GetSchedule(SelectedDate);

                    if (s != null)
                    {
                        return s;
                    }
                    else
                    {
                        _scheduleAdmin.CreateSchedule(SelectedDate, SelectedGroup);
                        return SelectedGroup.GetSchedule(SelectedDate);
                    } 
                }
                else
                {
                    return SelectedTemplate;
                }
            }
        }

        public ObservableCollection<EmployeeSchedule> EmployeeSchedules
        {
            get
            {
                return new ObservableCollection<EmployeeSchedule>(SelectedSchedule.EmployeeSchedules);
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
                    OnPropertyChanged(nameof(Templates));
                    OnPropertyChanged(nameof(SelectedTemplate));
                    OnPropertyChanged(nameof(SelectedSchedule));
                    OnPropertyChanged(nameof(EmployeeSchedules));
                }
            }
        }

        public ObservableCollection<Group> Groups { get; set; }

        public RelayCommand ChangeEmployeeCommand { get; }
        public RelayCommand AddEmployeeScheduleCommand { get; }
        public RelayCommand LockTaskCommand { get; }
        public RelayCommand LoadTemplateScheduleCommand { get; }
        public RelayCommand RemoveEmployeeScheduleCommand { get; }
        public RelayCommand ToggleUnplannedTaskItemPanelCommand { get; }

        public RelayCommand FlushToDatabase { get; }

        #endregion

        #region Fields

        private GroupAdmin _groupAdmin;
        private ScheduleAdmin _scheduleAdmin;
        private DatabaseControl _databaseControl;

        #endregion


        public ScheduleViewModel()
        {
            _groupAdmin = new GroupAdmin();
            _scheduleAdmin = new ScheduleAdmin();
            _databaseControl = new DatabaseControl();

            Groups = new ObservableCollection<Group>(_groupAdmin.GetAllGroups());
            SelectedGroup = Groups[0];
            CalendarTypes = new ObservableCollection<string>() { "Kalenderplaner", "Grundplaner" };
            SelectedCalendarType = CalendarTypes[0];
            SelectedDate = DateTime.Today;
            

            ChangeEmployeeCommand = new RelayCommand(p => ChangeEmployee(p as EmployeeSchedule), p => true);

            AddEmployeeScheduleCommand = new RelayCommand(p => AddEmployeeSchedule(), p => true);

            LockTaskCommand = new RelayCommand(p => LockTask(p as TaskItem), p => true);

            LoadTemplateScheduleCommand = new RelayCommand(p => ImportTemplate(), p => (SelectedDate != null && SelectedCalendarType == CalendarTypes[0]));

            RemoveEmployeeScheduleCommand = new RelayCommand(p => RemoveEmployeeSchedule(p as EmployeeSchedule), p=> true);

      

            FlushToDatabase = new RelayCommand(FlushToDatabaseAction, null);
        }


        private void RemoveEmployeeSchedule(EmployeeSchedule employeeSchedule)
        {
            _scheduleAdmin.RemoveEmployeeSchedule(SelectedGroup,SelectedSchedule, employeeSchedule);
            UpdateSchedule();
            OnPropertyChanged(nameof(UnplannedTaskItems));

        }

        public void StartDrag(object source, object item)
        {
            TaskItem taskItem = item as TaskItem;

            if (taskItem != null)
            {
                var employeeSchedule = _scheduleAdmin.FindTask(taskItem, SelectedSchedule);
                _scheduleAdmin.UnPlan(SelectedGroup, employeeSchedule, taskItem);
                UpdateSchedule();
                
                DragDrop.DoDragDrop((DependencyObject)source, taskItem, DragDropEffects.Move);
                OnPropertyChanged(nameof(UnplannedTaskItems));
            }
        }

        public void StartDragPlan(object source, object item)
        {
            TaskItem taskItem = item as TaskItem;

            if (taskItem != null)
            {
                DragDrop.DoDragDrop((DependencyObject)source, taskItem, DragDropEffects.Move);
            }

        }

        public void DropTask(TaskItem draggedTaskItem, object dropTarget)
        {
            TaskItem taskItem = draggedTaskItem;
            TaskItem taskItem2 = dropTarget as TaskItem;
            EmployeeSchedule emplTarget = dropTarget as EmployeeSchedule;

            if (taskItem != null && taskItem2 != null)
            {
                var employeeSchedule = _scheduleAdmin.FindTask(taskItem2, SelectedSchedule);
                int index = employeeSchedule.TaskItems.IndexOf(taskItem2);
                _scheduleAdmin.PlanTask(SelectedGroup,employeeSchedule, taskItem, index);
            }
            else if (taskItem != null && emplTarget != null)
            {
                int index2 = emplTarget.TaskItems.Count;
                _scheduleAdmin.PlanTask(SelectedGroup, emplTarget, taskItem, index2);
            }
            OnPropertyChanged(nameof(UnplannedTaskItems));

            UpdateSchedule();
            
        }

        private void LockTask(TaskItem taskItem)
        {
            _scheduleAdmin.ToggleLockStatusTask(taskItem);
            //UpdateSchedule();
        }

        private void UpdateSchedule()
        {
            OnPropertyChanged(nameof(SelectedSchedule));
            OnPropertyChanged(nameof(EmployeeSchedules));
        }

        private void AddEmployeeSchedule()
        {
            _scheduleAdmin.CreateNewEmployeeSchedule(SelectedSchedule, new TimeSpan(6,0,0));
            UpdateSchedule();
        }

        private void ChangeEmployee(EmployeeSchedule es)
        {
            var window = new EmployeeSelectionWindow();
            // var viewModel = new EmployeeSelectionViewModel(_groupAdmin.GetEmployeesOnDuty(SelectedGroup,SelectedDate),window);  // TODO dette burde være det rigtige
            var viewModel = new EmployeeSelectionViewModel(_groupAdmin.GetEmployeeClipBoard(),window);    // Workaround

            window.DataContext = viewModel;
            window.ShowDialog();

            if (viewModel.Excecute && viewModel.SelectedEmployee != null)
            {
                _scheduleAdmin.AssignEmployeeToEmployeeSchedule(viewModel.SelectedEmployee, es);
            }
            UpdateSchedule();

        }

        private void ImportTemplate()
        {
            var window = new TemplateSelectionWindow();
            var viewModel = new TemplateSelectionViewModel(Templates, window);
            window.DataContext = viewModel;
            window.ShowDialog();

            if (viewModel.Excecute && viewModel.SelectedTemplate != null)
            {
                var template = viewModel.SelectedTemplate;
                var daily = _scheduleAdmin.CopyTemplateScheduleToDailySchedule(template);
                daily.Date = SelectedDate;
                SelectedGroup.AddDailySchedule(daily);
            }
            UpdateSchedule();
        }


        public void FlushToDatabaseAction(object input)
        {
            _databaseControl.EraseDatabaseContent();

            foreach (Group g in _groupAdmin.GetAllGroups())
            {
                _databaseControl.AddGroup(g);
                //Store Daily Schedules 
                //foreach (KeyValuePair<string, GroupSchedule> KVgs in g.TemplateSchedules) { 
                //    DatabaseControl.AddGroupSchedule(KVgs.Value); 
                //} 
                //foreach (KeyValuePair<DateTime, GroupSchedule> KVgs in g.DailySchedules) { 
                //    DatabaseControl.AddGroupSchedule(KVgs.Value); 
                //} 
            }

            //foreach (EmployeeSchedule es in EmployeeSchedules) {
            //    _databaseControl.AddEmployeeSchedule(es);
            //}

            foreach (TaskItem ti in _scheduleAdmin.GetTaskClipBoard())
            {
                _databaseControl.AddTaskItem(ti);
            }

        }
    }
}
