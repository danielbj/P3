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

        private List<TaskItem> _taskItem;
        public List<TaskItem> TaskItem {
            get { return _taskItem; }
            set {
                _taskItem = value;
                OnPropertyChanged(nameof(TaskItem));
            }
        }

        #endregion


        public EmployeeScheduleViewModel(/*EmployeeSchedule es*/)
        {
            _groupAdmin = new GroupAdmin();
            _scheduleAdmin = new ScheduleAdmin();
            //EmployeeSchedule = es;
            //TaskItem = EmployeeSchedule.GetTasks();
        }
    }
}
