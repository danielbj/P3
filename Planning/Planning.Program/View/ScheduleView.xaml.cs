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
using Planning.Model;

namespace Planning.View
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        public ScheduleView()
        {
            DataContext = new ScheduleViewModel();
            InitializeComponent();

            
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var vm = this.DataContext as ScheduleViewModel;
            Grid g = sender as Grid;
            var item = g.DataContext;            

            vm.StartDrag(sender,item);            
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            var vm = this.DataContext as ScheduleViewModel;
            Grid g = sender as Grid;
            var target = g.DataContext;

            var item = e.Data.GetData(typeof(TaskItem)) as TaskItem;

            vm.DropTask(item,target);
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            var vm = this.DataContext as ScheduleViewModel;
            ListBox l = sender as ListBox;
            var target = l.DataContext;

            var item = e.Data.GetData(typeof(TaskItem)) as TaskItem;

            vm.DropTask(item, target);
        }
    }
}
