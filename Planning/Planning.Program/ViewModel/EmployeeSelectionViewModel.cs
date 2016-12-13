using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using Planning.View;


namespace Planning.ViewModel
{
    public class EmployeeSelectionViewModel: ViewModelBase
    {
        private EmployeeSelectionWindow _window;

        private List<Employee> _employees;
        public List<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        public RelayCommand CancelCommand { get; }
        public RelayCommand SelectCommand { get; }
        public bool Excecute { get; private set; }

        public EmployeeSelectionViewModel(List<Employee> employees, EmployeeSelectionWindow window)
        {
            _employees = employees;
            _window = window;

            CancelCommand = new RelayCommand(p => Cancel(), p => true);
            SelectCommand = new RelayCommand(p => Select(), p => true);
        }

        public void Select()
        {
            Excecute = true;
            _window.Close();
        }

        public void Cancel()
        {
            Excecute = false;
            _window.Close();
        }
    }
}
