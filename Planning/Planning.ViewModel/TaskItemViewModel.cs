using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.ViewModel
{
    public class TaskItemViewModel : ViewModelBase
    {
        #region properties
        private TaskItem _taskItem;
        public TaskItem TaskItem {
            get { return _taskItem; }
            set {
                _taskItem = value;
                OnPropertyChanged(nameof(TaskItem));
            }
        }

        public double TaskDuration {
            get {
                return TaskItem.TaskDescription.Duration.TotalMinutes; }
        }

        public double TaskStartTime {
            get { return TaskItem.TaskDescription.TimeFrame.StartTime.TotalMinutes; }
        }

        #endregion

        public TaskItemViewModel(TaskItem ti)
        {
            TaskItem = ti;

        }
    }
}
