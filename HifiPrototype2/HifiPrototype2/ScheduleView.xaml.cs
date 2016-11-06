using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HifiPrototype2
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        private SchedulePresenter _presenter;
        public ScheduleView()
        {
            InitializeComponent();
            _presenter = new SchedulePresenter();
            _presenter.SetView(this);
        }

        public int DailyScheduleWidth { get; set; } = 100;

        public void AddDailySchedule(DailyScheduleView dailySchedule)
        {
            dailySchedule.Width = DailyScheduleWidth;
            //SchedulePanel.Children.Add(dailySchedule);
            //DailySchedule.DailySchedulePanel.Children.Add(dailySchedule);

            var label = new Label();
            label.Content = dailySchedule.Presenter.Name;
            label.Width = DailyScheduleWidth;
            //DailySchedule.HeaderPanel.Children.Add(label);
            //HeaderPanel.Children.Add(label);
        }

        public void AddDailySchedule(Employee employee)
        {
            var dailySchedule = new DailyScheduleView();
            dailySchedule.Width = DailyScheduleWidth;

            foreach (var Assignment in employee.Assignments)
            {
                var btn = new Button();
                btn.Content = Assignment.Description;
                btn.Height = Assignment.Duration;
                //dailySchedule.DailySchedulePanel.Children.Add(btn);
            }
            //DailySchedule.DailySchedulePanel.Children.Add(dailySchedule);
            //SchedulePanel.Children.Add(dailySchedule);

            var label = new Label();
            label.Content = employee.Name;
            label.Width = DailyScheduleWidth;
            //DailySchedule.HeaderPanel.Children.Add(label);
            //HeaderPanel.Children.Add(label);


        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            Employee testemployee = Employee.CreateRandomEmployee("TEST");

            TextBlock empTextBlock = new TextBlock();
            empTextBlock.Text = testemployee.Name;
            empTextBlock.Width = 200;

            Grid ScheduleGrid = new Grid();

            ScheduleGrid.Width = 200;
            ScheduleGrid.Height = 660;
            for (int i = 0; i < 660; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = new GridLength(1, GridUnitType.Star);

                ScheduleGrid.RowDefinitions.Add(rowdef);
            }

            testemployee.AddRandomAssignments(3);
            

            NamePanel.Children.Add(empTextBlock);
            SchedulePanel.Children.Add(ScheduleGrid);
        }
    }
}
