using HifiPrototype2.Model;
using HifiPrototype2.View;
using System.Collections.Generic;


namespace HifiPrototype2.Functions
{
    public class MainWindowPresenter
    {


        private List<Assignment> _assignments = new List<Assignment>();

        private MainWindow _view;
       
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public MainWindowPresenter() { }


        public void SetView(MainWindow view)
        {
            _view = view;
        }

        public void AddRandomEmployee()
        {
            Employee employee = Employee.CreateRandomEmployee("Navn");
            Employees.Add(employee);
            var dailySchedule = new DailyScheduleView(employee);
           // _view.Schedule.AddDailySchedule(dailySchedule);
        }

        public void AddRandomAssignment()
        {
            
        }


        //public void AddAssignment()
        //{
        //    Assignment a = Assignment.CreateAssignment();
        //    var btn = new Button();
        //    btn.Content = a.Description;
        //    btn.Height = a.Duration;
        //    btn.PreviewMouseMove += Btn_PreviewMouseMove;
        //    taskHolder.Children.Add(btn);
        //}

    }
}
