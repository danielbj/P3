using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HifiPrototype2
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
            var employee = Employee.CreateRandomEmployee("Navn");
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
