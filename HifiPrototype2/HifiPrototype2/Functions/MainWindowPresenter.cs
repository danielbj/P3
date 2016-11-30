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

    }
}
