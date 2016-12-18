using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.ViewModel
{
    class ScheduleAdmin
    {
        private List<TaskItem> _unplannedTaskClipBoard;
        private List<TaskItem> _cancelledTaskClipBoard;     
        
        public ScheduleAdmin()
        {
            _unplannedTaskClipBoard = new List<TaskItem>();
            _cancelledTaskClipBoard = new List<TaskItem>();
        }

        //new
        public void PlanTask(Group targetGroup, EmployeeSchedule targetEmployeeSchedule, TaskItem taskToPlan, int index) 
        {
            DateTime CurrentDate 
                = !targetEmployeeSchedule.EffectiveDate.Equals(DateTime.MaxValue) 
                ? targetEmployeeSchedule.EffectiveDate 
                : DateTime.Today;

            int count = targetEmployeeSchedule.TaskItems.Count;

            string toAddress = taskToPlan.TaskDescription.Citizen.GetAddress(CurrentDate).ToString();

            if (index > count)
            {
                throw new Exception();
            }

            
            targetEmployeeSchedule.TaskItems.Insert(index, taskToPlan);
            taskToPlan.State = TaskItem.Status.Planned;

            if (index == 0) 
            {
                taskToPlan.Route.TimePeriod.Duration = RouteCalculator.CalculateRouteDuration(targetGroup.GroupAddress.ToString(), toAddress);
                taskToPlan.Route.TimePeriod.StartTime = targetEmployeeSchedule.TimePeriod.StartTime;
                taskToPlan.TimePeriod.StartTime = taskToPlan.Route.TimePeriod.EndTime;
            }
            else
            {
                TaskItem previosTaskItem = targetEmployeeSchedule.TaskItems[index - 1];

                AdjustRouteDuration(previosTaskItem, taskToPlan, CurrentDate);
                AdjustStartTime(previosTaskItem, taskToPlan);
            }

            if (index != count)
            {
                TaskItem nextTaskItem = targetEmployeeSchedule.TaskItems[index + 1];
                AdjustRouteDuration(taskToPlan, nextTaskItem, CurrentDate);

                for (int i = index + 1; i <= count; i++)
                {
                    TaskItem previous = targetEmployeeSchedule.TaskItems[i - 1];
                    TaskItem current = targetEmployeeSchedule.TaskItems[i];

                    AdjustStartTime(previous, current);
                }
            }

            _unplannedTaskClipBoard.Remove(taskToPlan);
        }

        public void UnPlan(Group targetGroup, EmployeeSchedule targetEmployeeSchedule, TaskItem targetTask)
        {
            DateTime CurrentDate
                = !targetEmployeeSchedule.EffectiveDate.Equals(DateTime.MaxValue)
                ? targetEmployeeSchedule.EffectiveDate
                : DateTime.Today;

            int index = targetEmployeeSchedule.TaskItems.IndexOf(targetTask);
            int count = targetEmployeeSchedule.TaskItems.Count;

            if (index < 0)
            {
                return;
            }

            targetEmployeeSchedule.TaskItems.Remove(targetTask);
            targetTask.State = TaskItem.Status.Unplanned;
            _unplannedTaskClipBoard.Add(targetTask);

            if (index == count - 1)
            {
                return;
            }
            else
            {
                TaskItem nextTask = targetEmployeeSchedule.TaskItems[index];
                string nextTaskAddress = nextTask.TaskDescription.Citizen.GetAddress(CurrentDate).ToString();

                if (index == 0)
                {
                    nextTask.Route.TimePeriod.StartTime = targetEmployeeSchedule.TimePeriod.StartTime;
                    nextTask.Route.TimePeriod.Duration = RouteCalculator.CalculateRouteDuration(targetGroup.GroupAddress.ToString(), nextTaskAddress);
                }
                else
                {
                    TaskItem previosTaskItem = targetEmployeeSchedule.TaskItems[index - 1];
                    AdjustRouteDuration(previosTaskItem, nextTask, CurrentDate);
                    AdjustStartTime(previosTaskItem, nextTask);
                }

                for (int i = index + 1; i < count - 1; i++)
                {
                    TaskItem previous = targetEmployeeSchedule.TaskItems[i - 1];
                    TaskItem current = targetEmployeeSchedule.TaskItems[i];

                    AdjustStartTime(previous, current);
                }
            }

        }       

        /// <summary>
        /// Updates travelTime in a task, according to previous task.
        /// </summary>
        /// <param name="previousTask"></param>
        /// <param name="currentTask"></param>
        private void AdjustRouteDuration(TaskItem previousTask, TaskItem currentTask, DateTime date) 
        {
            currentTask.Route.TimePeriod.Duration = RouteCalculator.CalculateRouteDuration(previousTask.TaskDescription.Citizen.GetAddress(date).ToString(), currentTask.TaskDescription.Citizen.GetAddress(date).ToString());
        }

        /// <summary>
        /// Updates start time in task according to previous task.
        /// </summary>
        /// <param name="previousTask"></param>
        /// <param name="currentTask"></param>
        private void AdjustStartTime(TaskItem previousTask, TaskItem currentTask) 
        {
            if (currentTask.Locked)
            {
                if (currentTask.Route.TimePeriod.StartTime < previousTask.TimePeriod.EndTime)
                {
                    var temp = currentTask;

                    currentTask = previousTask;
                    previousTask = temp;

                    AdjustStartTime(previousTask, currentTask);
                }
            }
            else
            {
                currentTask.Route.TimePeriod.StartTime = previousTask.TimePeriod.EndTime;
                currentTask.TimePeriod.StartTime = currentTask.Route.TimePeriod.EndTime;
            }              
        }

        public void ToggleLockStatusTask(TaskItem task) //TODO
        {
            task.Locked = !task.Locked;
        }
    
        public List<ITaskdescritpionChange> GetRecentTaskChanges(TaskDescription task, DateTime fromDate)
        {
            return task.GetTaskChanges(t => t.DateApplied >= fromDate); 
        }

        /// <summary>
        /// Retuns the best task placements based on travel time and employee workhours
        /// </summary>
        /// <param name="task"></param>
        /// <param name="groupSchedule"></param>
        /// <returns></returns>
        public Dictionary<EmployeeSchedule, int> CalcTaskPlacement(TaskItem task, GroupSchedule groupSchedule)
        {
            Dictionary<EmployeeSchedule, int> result = new Dictionary<EmployeeSchedule, int>();
            //returnerer en dictionary med employeeschedules, og placering (int index) i employeeSchedule       

            // tjek hvilken emploeeSchedule har plads til task
            // tjek hvor der er mindst køretid
            return result;
        }

        public void CalcShortestRoute(EmployeeSchedule targetEmployeeSchedule)
        {
            //rearrange tasks in employeeschedule
        } 

        public string GetScheduleInfo(GroupSchedule groupSchedule)
        {
            return groupSchedule.ToString(); 
        }
        
        /// <summary>
        /// Creates a new daily schedule
        /// </summary>
        /// <param name="date"></param>
        /// <param name="groupschedule"></param>
        /// <param name="startTime"></param>
        public void CreateNewEmployeeSchedule(GroupSchedule groupschedule, TimeSpan startTime)
        {
            EmployeeSchedule employeeSchedule = new EmployeeSchedule(startTime);
            groupschedule.EmployeeSchedules.Add(employeeSchedule);
        }        
        
        /// <summary>
        /// Removes an employeeschedule from a template schedule
        /// </summary>
        /// <param name="scheduleName"></param>
        /// <param name="group"></param>
        /// <param name="employeeSchedule"></param>
        public void RemoveEmployeeSchedule(Group group, GroupSchedule groupSchedule, EmployeeSchedule employeeSchedule)  //from template
        {
            List<TaskItem> tasks = employeeSchedule.TaskItems.ToList();

            foreach (TaskItem task in tasks)
            {
                UnPlan(group, employeeSchedule, task);
            }
            groupSchedule.EmployeeSchedules.Remove(employeeSchedule);
        }

        public List<TaskItem> GetTaskClipBoard()
        {
            return _unplannedTaskClipBoard;
        }

        public void AddTasksToClipBoard(List<TaskItem> tasksToClipBoard) //fx når en ny taskDescription assignes til en gruppe. unplanned TaskItems lægges i clipboard.
        {
            foreach (TaskItem task in tasksToClipBoard)
            {
                _unplannedTaskClipBoard.Add(task);
            }
        }

        public void DeleteScheduleTemplate(GroupSchedule templateSchedule, Group group)
        {
            //unassigned taskDescriptions needs to be placed in clipboard in groupAdmin
        }

        /// <summary>
        /// Assigns an employee to the employee schedule
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeSchedule"></param>
        public void AssignEmployeeToEmployeeSchedule(Employee employee, EmployeeSchedule employeeSchedule)
        {
            //Employee skal være en del af den gruppe som har den employee schedule
            employeeSchedule.Employee = employee;            
        } 

        public TaskItem FindOptimalPlacement(Group group, DateTime selectedDate, TaskItem taskItem)
        {
            //List<TaskItem> tempList = new List<TaskItem>();
            Tuple<double, TaskItem> tempItem = new Tuple<double, TaskItem>(double.MaxValue , null);
            List<EmployeeSchedule> employeeSchedules = group.GetSchedule(selectedDate).EmployeeSchedules;
            List<TaskItem> taskItemList = new List<TaskItem>();
            double tempValue = 0;
            int length;

            foreach (EmployeeSchedule schedule in employeeSchedules)
            {
                taskItemList = schedule.TaskItems;
                length = taskItemList.Count();

                for (int i = 0; i < length; i++)
                {
                    if (taskItemList[i] != taskItem)
                    {
                        if (i != 0)
                        {
                            tempValue = CompareRoutes(taskItem, taskItemList[i - 1].TaskDescription.Citizen.GetAddress(selectedDate), taskItemList[i].TaskDescription.Citizen.GetAddress(selectedDate), selectedDate);
                        }
                        else
                        {
                            tempValue = CompareRoutes(taskItem, group.GroupAddress, taskItemList[i].TaskDescription.Citizen.GetAddress(selectedDate), selectedDate);
                        }

                        if (tempValue < tempItem.Item1)
                            tempItem = new Tuple<double, TaskItem>(tempValue, taskItemList[i]);
                    }
                }
            }

            return tempItem.Item2;
        }

        private double CompareRoutes(TaskItem taskItemClicked, Address startAddress, Address endAddress, DateTime selectedDate)
        {
            RouteItem AC = RouteCalculator.GetRouteItem(startAddress, taskItemClicked.TaskDescription.Citizen.GetAddress(selectedDate));
            RouteItem CB = RouteCalculator.GetRouteItem(taskItemClicked.TaskDescription.Citizen.GetAddress(selectedDate), endAddress);

            return AC.Duration.TotalMinutes + CB.Duration.TotalMinutes;
        }

        /// <summary>
        /// Makes a clone of the template and assigns it to a daily schedule
        /// </summary>
        /// <param name="template"></param>
        /// <param name="daily"></param>
        public GroupSchedule CopyTemplateScheduleToDailySchedule(GroupSchedule template)
        {
            return CloneSchedule(template);
        }

        /// <summary>
        /// Clones a schedule
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        private GroupSchedule CloneSchedule(GroupSchedule schedule)
        {
            return GroupSchedule.CloneSchedule(schedule);
        }

        public void LockTaskInEmployeeSchedule(TaskItem task, TimeSpan time, EmployeeSchedule employeeschedule)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a daily schedule
        /// </summary>
        /// <param name="name"></param>
        /// <param name="group"></param>
        public void CreateSchedule(string name, Group group)
        {
            GroupSchedule templateSchedule = new GroupSchedule(name);
            group.AddScheduleTemplate(templateSchedule);
        }

        /// <summary>
        /// Creates a schedule template
        /// </summary>
        /// <param name="date"></param>
        /// <param name="group"></param>
        public void CreateSchedule(DateTime date, Group group)
        {
            GroupSchedule dailySchedule = new GroupSchedule(date);
            group.AddDailySchedule(dailySchedule);
        }       

        /// <summary>
        /// Finds the employee schedule where a task is placed.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="groupSchedule"></param>
        /// <returns></returns>
        public EmployeeSchedule FindTask(TaskItem task, GroupSchedule groupSchedule)
        {
            foreach (EmployeeSchedule item in groupSchedule.EmployeeSchedules)
            {
                if (item.TaskItems.Contains(task))
                {
                    return item;
                }                
            }
            throw new ArgumentException("Task not found in the group schedule.");
        }

        /// <summary>
        /// Cancels a task, and moves it to the clipboard of unplanned tasks
        /// </summary>
        /// <param name="task"></param>
        /// <param name="employeeSchedule"></param>
        public void CancelTask(TaskItem task, EmployeeSchedule employeeSchedule)
        {
            task.State = TaskItem.Status.Cancelled;
            _cancelledTaskClipBoard.Add(task);
            employeeSchedule.TaskItems.Remove(task);
        }

    }


}
