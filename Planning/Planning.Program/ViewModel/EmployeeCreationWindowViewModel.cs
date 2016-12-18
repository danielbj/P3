using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using Planning.View;

namespace Planning.ViewModel
{
    class EmployeeCreationWindowViewModel : ViewModelBase
    {
        private List<Employee> _employees;
        public List<Employee> Templates
        {
            get { return _employees; }
            set { _employees = value; }
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
            }
        }

        public RelayCommand CancelCommand { get; }
        public RelayCommand ImportCommand { get; }
        public bool Excecute { get; private set; }

        private NewEmployeeWindow _window;

        public EmployeeCreationWindowViewModel(List<Employee> Employees, NewEmployeeWindow window)
        {
            _employees = Employees;
            CancelCommand = new RelayCommand(p => Cancel(), p => true);
            ImportCommand = new RelayCommand(p => Import(), p => true);

            _window = window;
        }

        public void Import()
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
