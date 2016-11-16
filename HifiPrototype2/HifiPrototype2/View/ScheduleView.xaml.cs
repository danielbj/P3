using HifiPrototype2.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HifiPrototype2
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        private SchedulePresenter _presenter;
        public int DailyScheduleWidth { get; set; } = 100;

        Dictionary<string, Group> _groups = new Dictionary<string, Group>() { { "Gruppe 1", new Group() } };
        //TemplateSchedule;
        //CalenderSchedule;

        public ScheduleView()
        {
            InitializeComponent();
            _presenter = new SchedulePresenter();
            _presenter.SetView(this);

        }

        

        //public void AddDailySchedule(DailyScheduleView dailySchedule)
        //{
        //    dailySchedule.Width = DailyScheduleWidth;
        //    //SchedulePanel.Children.Add(dailySchedule);
        //    //DailySchedule.DailySchedulePanel.Children.Add(dailySchedule);

        //    var label = new Label();
        //    label.Content = dailySchedule.Presenter.Name;
        //    label.Width = DailyScheduleWidth;
        //    //DailySchedule.HeaderPanel.Children.Add(label);
        //    //HeaderPanel.Children.Add(label);
        //}

        //public void AddDailySchedule(Employee employee)
        //{
        //    var dailySchedule = new DailyScheduleView();
        //    dailySchedule.Width = DailyScheduleWidth;

        //    foreach (var Assignment in employee.Assignments)
        //    {
        //        var btn = new Button();
        //        btn.Content = Assignment.Description;
        //        btn.Height = Assignment.Duration;
        //        //dailySchedule.DailySchedulePanel.Children.Add(btn);
        //    }
        //    //DailySchedule.DailySchedulePanel.Children.Add(dailySchedule);
        //    //SchedulePanel.Children.Add(dailySchedule);

        //    var label = new Label();
        //    label.Content = employee.Name;
        //    label.Width = DailyScheduleWidth;
        //    //DailySchedule.HeaderPanel.Children.Add(label);
        //    //HeaderPanel.Children.Add(label);


        //}

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Employee testemployee = Employee.CreateRandomEmployee("TEST");

            DailyScheduleView DailyView = new DailyScheduleView(testemployee);
            SchedulePanel.Children.Add(DailyView);
            DailyView.Width = DailyScheduleWidth;

            DailyView.NameLabel.Content = testemployee.Name;

            // Add to list            
        }

        private void AddToGroupList()
        {

        }

        private void AddJobButton_Click(object sender, RoutedEventArgs e) {
            //PopupWindow popup = new PopupWindow();
            //PopupChooseEmployee pce = new PopupChooseEmployee();

            //popup.PopupGrid.Children.Add(pce);

            //popup.Show();
        }

        private void CalenderScheduleComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void TemplateScheduleComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void GroupComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = sender as ComboBoxItem;

            if (sender != null)
            {
                Group group = _groups[item.Content.ToString()];
            } 
        }
    }
}
