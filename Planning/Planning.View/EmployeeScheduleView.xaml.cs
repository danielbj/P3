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
        public EmployeeScheduleView()
        {
            for (int i = 0; i < 660; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = new GridLength(1, GridUnitType.Star);

                ScheduleGrid.RowDefinitions.Add(rowdef);
            }


            InitializeComponent();
            DataContext = new EmployeeScheduleViewModel();
        }


        public void AddTaskItemViewToGrid(TaskItemView tiView)
        {
            ScheduleGrid.Children.Add(tiView);
            Grid.SetRow(tiView, tiView.VM.TaskStartTime);
            Grid.SetRowSpan(tiView, tiView.VM.TaskDuration);
        }
    }
}
