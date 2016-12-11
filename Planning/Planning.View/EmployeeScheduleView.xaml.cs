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
        private Point _startPoint;
        private bool IsDragging = false;

        public EmployeeScheduleView()
        {
            InitializeComponent();
            DataContext = VM = new EmployeeScheduleViewModel();


        }
        public EmployeeScheduleView(EmployeeScheduleViewModel eSVM) {
            InitializeComponent();
            DataContext = VM = eSVM;
        }
        private void EmployeeListBox_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            _startPoint = e.GetPosition(null);
        }

        private void EmployeeListBox_PreviewMouseMove(object sender, MouseEventArgs e) {
            if (sender is ListBoxItem && e.LeftButton == MouseButtonState.Pressed && !IsDragging) {
    
                Point position = e.GetPosition(null);
                if (Math.Abs(position.X - _startPoint.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(position.Y - _startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                    StartDrag(sender, e);
            }
        }
        /// <summary>
        /// Eventhandler to handle the removing of the dragged object from the correct employeeview object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartDrag(object sender, MouseEventArgs e) {
            IsDragging = true;

            ListBoxItem draggedItem = sender as ListBoxItem;
            VM.UnplanAndRemoveTask(sender); //Removes old taskItem when taskItem is dropped on another employeeView, and "Drop" event has been handled.
            DragDrop.DoDragDrop(draggedItem, draggedItem.DataContext, DragDropEffects.Copy); //TODO figure if it should be move instead, and if it removes it from list.
            draggedItem.IsSelected = true;
            IsDragging = false;
        }

        /// <summary>
        /// Event handler to drop the dragged task onto another(or itself) employeeview object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeListBox_Drop(object sender, DragEventArgs e) {
            //VM.DropAndPlanTask(sender, e);        

            EmployeeListBox.Items.Refresh();
        }



        //public void AddTaskItemViewToGrid(TaskItemView tiView)
        //{
        //    EmployeeListBox.Add(tiView);
        //    Grid.SetRow(tiView, tiView.VM.TaskStartTime);
        //    Grid.SetRowSpan(tiView, tiView.VM.TaskDuration);
        //}
    }
}
