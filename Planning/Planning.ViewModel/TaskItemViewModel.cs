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

        public int TaskDuration {
            get { return TaskItem.TaskDescription.Duration.Minutes; }
        }

        public int TaskStartTime {
            get { return TaskItem.TaskDescription.TimeFrame.StartTime.Minutes; }
        }

        #endregion

        public TaskItemViewModel(TaskItem ti)
        {
            TaskItem = ti;

        }
    }
}
