using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Modules;

namespace Planning.Model.Schedules
{
    public class EmployeeSchedule
    {
        private List<TaskItem> _taskItems;
        public DateTime EffectiveDate;
        //TIMESPAN TODO migth be implicit


        public EmployeeSchedule(DateTime effectiveFrom)
        {
            EffectiveDate = effectiveFrom;
            _taskItems = new List<TaskItem>();
        }

        public void PlanTask(TaskItem task, int index) //TODO, startTIme til task der bliver planlagt. 
        {
            TaskItem previousTask;
            TaskItem nextTask; 
            if (index == 0) //first
            {
                _taskItems.Insert(index, task);
                //insert travel time from group address
                task.State = TaskItem.Status.Planned;
            }
            else if (index == _taskItems.Count)  //last
            {
                previousTask = _taskItems[index - 1];
                _taskItems.Add(task);
                //insert travel time
                task.State = TaskItem.Status.Planned;

            }

            previousTask = _taskItems[index - 1]; 
            nextTask = _taskItems[index + 1];  
            _taskItems.Insert(index, task);

            //adjust time
            
            task.State = TaskItem.Status.Planned;

        }

        public void UnPlan(TaskItem task)
        {
            TaskItem previousTask;
            TaskItem nextTask;

            //hvis det er den første
            if (_taskItems.IndexOf(task) == 0)
            {
                nextTask = _taskItems[1];
                //adujst travel time, groupaddress -> nextTask
                task.State = TaskItem.Status.Unplanned;
            }
            else if (_taskItems.IndexOf(task) == _taskItems.Count) //sidste
            {
                _taskItems.Remove(task);
                task.State = TaskItem.Status.Unplanned;
                //no need to adjust travel time
            }
                        
            _taskItems.Remove(task);
            //adjust travel time
            task.State = TaskItem.Status.Unplanned;
        }

        public void LockTask(TaskItem task)
        {
            task.Locked = true;
        }

        public void UnlockTask(TaskItem task)
        {
            task.Locked = false;
        }


        //Input is delegate function etc. t => "t.startTime > 12.00"
        public List<TaskItem> GetTasks(Predicate<TaskItem> Filter) {
            List<TaskItem> result = new List<TaskItem>();

            foreach (TaskItem t in _taskItems) {
                if (Filter(t))
                    result.Add(t);
            }
            return result;
        }

        public bool AssignTask(TaskItem task, int index) {//This is to plan. 
            if (task == null)
                return false;
            _taskItems.Add(task);
            return _taskItems.Contains(task);

            //ADDing from Groupschedule
            if (EmployeeSchedules.Count != 0)
            {
                TaskItem previousTaskItem = (EmployeeSchedules[targetEmployee].GetTasks(t => t is TaskItem)).FindLast(t => t is TaskItem);
                job.CalculateRoute(previousJob.Reciever.Address); // Todo: gør noget når det er den samme adresse
                job.Route.StartTime = previousJob.EndTime;
                job.StartTime = job.Route.EndTime;
            }
            else
            {
                job.CalculateRoute(EmployeeGroup.GroupAddress);  // TODO, GroupAddress skal implementeres i Group klassen
                job.Route.StartTime = StartTime;
                job.StartTime = job.Route.EndTime;
            }

            JobModules.Add(job);


            //Insertion
            JobModules.Insert(index, job);
            JobModule previous = JobModules[index - 1];
            JobModule next = JobModules[index + 1];

            job.CalculateRoute(previous.Reciever.Address);
            next.CalculateRoute(job.Reciever.Address);
            AdjustTime(index);
            task.State = Planned;


        }

        public bool RemoveTask(TaskItem tItem) {//This is to unplan.
            return _taskItems.Remove(tItem);

            //Remove from groupschedule
            int index = JobModules.IndexOf(job);   //TODO håndter index = 0 / = count
            JobModule previous = JobModules[index - 1];
            JobModule next = JobModules[index + 1];

            next.CalculateRoute(previous.Reciever.Address);

            JobModules.Remove(job);

            AdjustTime(index);

            IsSaved = false;
        }

        private void AdjustTime(int startIndex)
        {
            for (int i = startIndex; i < _taskItems.Count; i++) //TODO, håndter startindex = 0
            {
                _taskItems[i].Route.StartTime = _taskItems[i - 1].EndTime;
                _taskItems[i].StartTime = _taskItems[i].Route.EndTime;

            }
        }




    }
}
