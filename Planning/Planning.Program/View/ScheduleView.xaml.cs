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
        private Point _startpoint;

        public ScheduleView()
        {
            DataContext = new ScheduleViewModel();
            InitializeComponent();
        }

        private void Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var vm = this.DataContext as ScheduleViewModel;
            Grid g = sender as Grid;
            var item = g.DataContext;

            if (item != null && e.LeftButton == MouseButtonState.Pressed)
            {
                var position = e.GetPosition(null);
                var x = Math.Abs(position.X - _startpoint.X);
                var y = Math.Abs(position.Y - _startpoint.Y);
                var xs = SystemParameters.MinimumHorizontalDragDistance;
                var ys = SystemParameters.MinimumVerticalDragDistance;
                if (x > xs || y > ys)
                {
                    vm.StartDrag(sender, item);
                }
            }
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startpoint = e.GetPosition(null);
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

        private void ListBox_Drop_1(object sender, DragEventArgs e)
        {
            var vm = this.DataContext as ScheduleViewModel;

            var item = e.Data.GetData(typeof(TaskItem)) as TaskItem;
        }

        private void Border_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var vm = this.DataContext as ScheduleViewModel;
            Border b = sender as Border;
            var item = b.DataContext;

            if (item != null && e.LeftButton == MouseButtonState.Pressed)
            {
                var position = e.GetPosition(null);
                var x = Math.Abs(position.X - _startpoint.X);
                var y = Math.Abs(position.Y - _startpoint.Y);
                var xs = SystemParameters.MinimumHorizontalDragDistance;
                var ys = SystemParameters.MinimumVerticalDragDistance;
                if (x > xs || y > ys)
                {
                    vm.StartDragPlan(sender, item);
                }
            }
        }


    }
}
