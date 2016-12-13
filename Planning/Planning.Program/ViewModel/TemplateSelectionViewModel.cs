using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.View;
using Planning.Model;

namespace Planning.ViewModel
{
    class TemplateSelectionViewModel : ViewModelBase
    {
        private List<GroupSchedule> _templates;
        public List<GroupSchedule> Templates
        {
            get { return _templates; }
            set { _templates = value; }
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

        private TemplateSelectionWindow _window;

        public TemplateSelectionViewModel(List<GroupSchedule> templates, TemplateSelectionWindow window)
        {
            
            _templates = templates;
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
