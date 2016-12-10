using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using System.Collections.ObjectModel;

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
    }
}
