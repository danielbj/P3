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
    /// Interaction logic for EmployeeScheduleView.xaml
    /// </summary>
    public partial class EmployeeScheduleView : UserControl
    {
        EmployeeScheduleViewModel VM;

        public EmployeeScheduleView()
        {
            InitializeComponent();
            DataContext = VM = new EmployeeScheduleViewModel();


        }
        public EmployeeScheduleView(EmployeeScheduleViewModel eSVM) {
            InitializeComponent();
            DataContext = VM = eSVM;
        }


        //public void AddTaskItemViewToGrid(TaskItemView tiView)
        //{
        //    EmployeeListBox.Add(tiView);
        //    Grid.SetRow(tiView, tiView.VM.TaskStartTime);
        //    Grid.SetRowSpan(tiView, tiView.VM.TaskDuration);
        //}
    }
}
