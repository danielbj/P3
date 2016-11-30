using HifiPrototype2.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using HifiPrototype2.Functions;

namespace HifiPrototype2.View
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl, INotifyPropertyChanged
    {
        // Test feature 
        //private static int _id = 0;

        private SchedulePresenter _presenter;
        public int DailyScheduleWidth { get; set; } = 100;

        private DateTime _date = DateTime.Today;

        public DateTime Dato
        {
            get
            {
                return this._date;
            }
            set
            {
                if (value == this._date)
                    return;

                this._date = value;
                this.OnPropertyChanged(nameof(this.Dato));
            }
        }



        private GroupContainer _groups = new GroupContainer(); // TODO skal være den samme som i group view

        public Group SelectedGroup;
        public Dictionary<DateTime?, GroupSchedule> GroupSchedules { get { return SelectedGroup.Shedules; } }
        public List<GroupSchedule> Templates { get { return SelectedGroup.Templates; } }
        public GroupSchedule SelectedGroupSchedule;


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ScheduleView() //todo
        {
            InitializeComponent();
            this.DataContext = this;  // WTF?
            _presenter = new SchedulePresenter();
            _presenter.SetView(this);

            LoadGroups();

            LoadUnplannedAssignments();
        }

        private void LoadGroups()
        {
            foreach (Group item in _groups.GroupList)
            {
                GroupComboBox.Items.Add(item);
            }
            GroupComboBox.SelectedIndex = 0;
            SelectedGroup = GroupComboBox.Items[0] as Group;

        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e) // TODO
        {
            DailyScheduleView DailyView = new DailyScheduleView();
            SchedulePanel.Children.Add(DailyView);
            DailyView.NameLabel.Text = "( TOM )";
           
        }


        private void CalenderScheduleComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if (this.IsLoaded)
            {
                DateGrid.Visibility = Visibility.Visible;
                TemplateComboBox.Visibility = Visibility.Collapsed;
            } 
        }

        private void TemplateScheduleComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if (this.IsLoaded)
            {
                DateGrid.Visibility = Visibility.Collapsed;
                TemplateComboBox.Visibility = Visibility.Visible;
            }
        }

        private void JobButton_Click(object sender, RoutedEventArgs e) // todo
        {
            if (JobPanel.Visibility == Visibility.Visible)
            {
                JobPanel.Visibility = Visibility.Collapsed;
                LoadUnplannedAssignments();
            }
            else
	        {
                JobPanel.Visibility = Visibility.Visible;
                LoadUnplannedAssignments();
            }  
        }

        public void LoadUnplannedAssignments()
        {
            JobPanel.Children.Clear();
            if (SelectedGroupSchedule != null)
            {
                foreach (Assignment a in SelectedGroupSchedule.Unplanned)
                {
                    JobPanel.Children.Add(new AssignmentView(a));
                }
            }
        } 

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new SelectTemplateWindow(this);
            window.Show();
        }

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedGroup = GroupComboBox.SelectedItem as Group;

            foreach (GroupSchedule item in SelectedGroup.Templates)
            {
                TemplateComboBox.Items.Add(item);
            }
        }

        private void CurrentDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? date = CurrentDatePicker.SelectedDate;

            if (date != null && GroupSchedules.ContainsKey(date))
            {
                SelectedGroupSchedule = GroupSchedules[date];
                LoadSchedule();
            }
            else if (date != null)
            {
                SchedulePanel.Children.Clear();
            }
        }

        private void TemplateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedGroupSchedule = TemplateComboBox.SelectedItem as GroupSchedule;
            LoadSchedule();
        }

        public void LoadSchedule()
        {
            SelectedGroupSchedule.SubscribeToEvent(LoadUnplannedAssignments);

            SchedulePanel.Children.Clear();
            foreach (EmployeeSchedule item in SelectedGroupSchedule.EmployeeScheduleList)
            {
                DailyScheduleView DailyView = new DailyScheduleView(item);
                SchedulePanel.Children.Add(DailyView);
                DailyView.Width = DailyScheduleWidth;

                DailyView.NameLabel.Text = item.Name;
            }
        }

        private void CreateScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            new CreateScheduleWindow(SelectedGroup).Show();
        }
    }
}
