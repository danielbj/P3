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
        private List<TaskItem> TaskItems = new List<TaskItem>();
        public DateTime DateCreated;
        public DateTime DateDeleted;
        public DateTime EffectiveDate;
        //TIMESPAN TODO migth be implicit



        public EmployeeSchedule(DateTime effectiveFrom) {
            DateCreated = DateTime.Now;
            EffectiveDate = effectiveFrom;
        }

        //Input is delegate function etc. t => "t.startTime > 12.00"
        public List<TaskItem> GetTasks(Predicate<TaskItem> Filter) {
            List<TaskItem> result = new List<TaskItem>();

            foreach (TaskItem t in TaskItems) {
                if (Filter(t))
                    result.Add(t);
            }
            return result;
        }

        public bool AssignTask(TaskItem task, int index) {//This is to plan.
            if (task == null)
                return false;
            TaskItems.Add(task);
            return TaskItems.Contains(task);

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


        }

        public bool RemoveTask(TaskItem tItem) {//This is to unplan.
            return TaskItems.Remove(tItem);

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
            for (int i = startIndex; i < JobModules.Count; i++) //TODO, håndter startindex = 0
            {
                JobModules[i].Route.StartTime = JobModules[i - 1].EndTime;
                JobModules[i].StartTime = JobModules[i].Route.EndTime;

            }
        }

        public bool LockTask() {
            return true;
        }


    }
}
