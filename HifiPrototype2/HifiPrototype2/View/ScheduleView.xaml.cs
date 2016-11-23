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
        private static int _id = 0;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ScheduleView()
        {
            InitializeComponent();
            this.DataContext = this;
            _presenter = new SchedulePresenter();
            _presenter.SetView(this);

            SecretAssignments(); // hush hush

        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Employee testemployee = Employee.CreateRandomEmployee("TEST" + _id);
            _id++;

            DailyScheduleView DailyView = new DailyScheduleView(testemployee);
            SchedulePanel.Children.Add(DailyView);
            DailyView.Width = DailyScheduleWidth;

            DailyView.NameLabel.Text = testemployee.Name;

            // Add to list            
        }

        private void AddToGroupList()
        {

        }

        private void CalenderScheduleComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void TemplateScheduleComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void GroupComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            //ComboBoxItem item = sender as ComboBoxItem;

            //if (sender != null)
            //{
            //    Group group = _groups[item.Content.ToString()];
            //} 
        }

        private void DateForwardButton_Click(object sender, RoutedEventArgs e)
        {
            Dato = _date.AddDays(1);
        }

        private void DateBackButton_Click(object sender, RoutedEventArgs e)
        {
            Dato = _date.AddDays(-1);
        }

        private void JobButton_Click(object sender, RoutedEventArgs e)
        {
            if (JobPanel.Visibility == Visibility.Visible)
            {
                JobPanel.Visibility = Visibility.Collapsed;
            }
            else
	        {
                JobPanel.Visibility = Visibility.Visible;
            }  
        }

        private void SecretAssignments()
        {
            var a = new Assignment();
            a.Description = "Bad";
            a.Duration = 25;
            a.Location = 20;
            var av = new AssignmentView(a);
            av.LoadAssignment();

            var b = new Assignment();
            b.Description = "Rengøring";
            b.Duration = 40;
            b.Location = 15;
            var bv = new AssignmentView(b);
            bv.LoadAssignment();

            var c = new Assignment();
            c.Description = "Trimning af næsehår";
            c.Duration = 10;
            c.Location = 2;
            var cv = new AssignmentView(c);
            cv.LoadAssignment();

            JobPanel.Children.Add(av);
            JobPanel.Children.Add(bv);
            JobPanel.Children.Add(cv);

        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MagicButton_Click(object sender, RoutedEventArgs e)
        {
            var f = new ProtoScheduleFactory(500);
            List<Employee> EmployeeList =  f.MakeEmployees(12);

            foreach (var empl in EmployeeList)
            {
                DailyScheduleView DailyView = new DailyScheduleView(empl);
                SchedulePanel.Children.Add(DailyView);
                DailyView.Width = DailyScheduleWidth;

                DailyView.NameLabel.Text = empl.Name;
            }

            
        }
    }
}
