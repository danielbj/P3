using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.View;

namespace Planning.ViewModel
{
    class TemplateSelectionViewModel : ViewModelBase
    {
        private List<string> _templateNames;
        public List<string> TemplateNames
        {
            get { return _templateNames; }
            set { _templateNames = value; }
        }

        private string _selectedName;
        public string SelectedName
        {
            get
            {
                return _selectedName;
            }
            set
            {
                _selectedName = value;
                OnPropertyChanged(nameof(SelectedName));
            }
        }

        public RelayCommand CancelCommand { get; }
        public RelayCommand ImportCommand { get; }
        public bool Excecute { get; private set; }

        private TemplateSelectionWindow _window;

        public TemplateSelectionViewModel(List<string> templateNames, TemplateSelectionWindow window)
        {
            _templateNames = new List<string>();
            _templateNames = templateNames;
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
