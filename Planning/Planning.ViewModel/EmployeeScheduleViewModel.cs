using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;

namespace Planning.ViewModel
{
    public class EmployeeScheduleViewModel : ViewModelBase
    {

        #region Fields

        private GroupAdmin _groupAdmin;
        private ScheduleAdmin _scheduleAdmin;
        private EmployeeSchedule EmployeeSchedule;


        #endregion

        #region properties

        private List<TaskItem> _taskItems;
        public List<TaskItem> TaskItems {
            get { return _taskItems; }
            set {
                _taskItems = value;
                OnPropertyChanged(nameof(TaskItems));
            }
        }

        #endregion

        public EmployeeScheduleViewModel() {
            _groupAdmin = new GroupAdmin();
            _scheduleAdmin = new ScheduleAdmin();
            TaskItems = new List<TaskItem>();
            
        }

        public EmployeeScheduleViewModel(EmployeeSchedule es)
        {
            _groupAdmin = new GroupAdmin();
            _scheduleAdmin = new ScheduleAdmin();
            EmployeeSchedule = es;
            TaskItems = EmployeeSchedule.GetTasks();
        }

        public void DropAndPlanTask(object sender, DragEventArgs e) {
            TaskItem draggedTask = e.Data.GetData(typeof(TaskItem)) as TaskItem;
            TaskItem target = ((ListBoxItem)(sender)).DataContext as TaskItem;
            

            
            int targetIdx = TaskItems.IndexOf(target);
            if(draggedTask != target)
                _scheduleAdmin.PlanTask(null, EmployeeSchedule, draggedTask, targetIdx+1);
        }

        public void UnplanAndRemoveTask(object sender) {
            //TaskItem draggedTask = e.Data.GetData(typeof(TaskItem)) as TaskItem;

            ////EmployeeSchedule targetEmployeeSchedule = ((ListBox)sender).DataContext as EmployeeSchedule; //TODO find the correct target schedule.
            //EmployeeSchedule senderEmployeeSchedule =  e.Data.GetData(typeof(EmployeeSchedule)) as EmployeeSchedule;

            TaskItem draggedTask = ((ListBoxItem)sender).DataContext as TaskItem;
            if (draggedTask != null)
                _scheduleAdmin.UnPlan(null, EmployeeSchedule, draggedTask);
        }
    }
}
