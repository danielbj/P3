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
using Planning.ViewModel;

namespace Planning.View
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        ScheduleViewModel VM;
        public ScheduleView()
        {
            DataContext = VM = new ScheduleViewModel();
            InitializeComponent();
            VM.AddEmployeeButtonClicked += VM_AddEmployeeButtonClicked;
            VM.LoadTemplateScheduleButtonClicked += VM_LoadTemplateScheduleButtonClicked;


        }

        private void VM_LoadTemplateScheduleButtonClicked()
        {
            throw new NotImplementedException();
        }

        private void VM_AddEmployeeButtonClicked()
        {
            EmployeeScheduleView ESV = new EmployeeScheduleView();
            SchedulePanel.Children.Add(ESV);
        }
    }
}
