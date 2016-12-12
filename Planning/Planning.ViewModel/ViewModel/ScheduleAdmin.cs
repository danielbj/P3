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
        private List<TaskItem> _taskClipBoard;        
        
        public ScheduleAdmin()
        {
            _taskClipBoard = new List<TaskItem>();
        }

        /// <summary>
        /// Plans a task. Sets task status = planned, and adjusts rest of the tasks in the employee schedule
        /// </summary>
        /// <param name="targetGroup"></param>
        /// <param name="targetEmployeeSchedule"></param>
        /// <param name="taskToPlan"></param>
        /// <param name="index"></param>
        public void PlanTask(Group targetGroup, EmployeeSchedule targetEmployeeSchedule, TaskItem taskToPlan, int index) // locked? ret så der bruges GetAddress(date) når address er impl. Add methods.
        {
            if (taskToPlan.Locked)
            {
                taskToPlan.State = TaskItem.Status.Unplanned;
                //return false;
            }

            if (index == 0) //first
            {
                targetEmployeeSchedule.TaskItems.Insert(index, taskToPlan);
                taskToPlan.Route = RouteCalculator.GetRouteItem(new Address("Kærvej 2, 7752 Snedsted"), taskToPlan.TaskDescription.Citizen.GetAddress(DateTime.Today));
                taskToPlan.TimePeriod.StartTime = targetEmployeeSchedule.TimePeriod.StartTime;

                for (int i = index +1 ; i < targetEmployeeSchedule.TaskItems.Count; i++)
                {
                    AdjustTravelTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                    if (targetEmployeeSchedule.TaskItems[i].Locked)//ERRORS messes the list up (indexes and placement). TODO
                        break;
                    AdjustStartTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                }
            }
            else if (index == targetEmployeeSchedule.TaskItems.Count)  //last
            {
                targetEmployeeSchedule.TaskItems.Add(taskToPlan);
                AdjustTravelTime(targetEmployeeSchedule.TaskItems[index - 1], taskToPlan);
                AdjustStartTime(targetEmployeeSchedule.TaskItems[index - 1], taskToPlan);
            }

            else
            {
                targetEmployeeSchedule.TaskItems.Insert(index, taskToPlan); 

                for (int i = index; i < targetEmployeeSchedule.TaskItems.Count; i++)
                {
                    AdjustTravelTime(targetEmployeeSchedule.TaskItems[i], targetEmployeeSchedule.TaskItems[i + 1]);
                    if (targetEmployeeSchedule.TaskItems[i].Locked)//ERRORS messes the list up (indexes and placement). TODO
                        break;
                    AdjustStartTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                }

            }
            taskToPlan.State = TaskItem.Status.Planned;
            targetEmployeeSchedule.TimePeriod.EndTime = targetEmployeeSchedule.TaskItems.Last<TaskItem>().TimePeriod.EndTime;
            //return true;
        }

        /// <param name="targetTask"></param>
        /// <param name="targetEmployeeSchedule"></param>
        /// <param name="targetGroup"></param>
        /// </summary>
        /// Unplans a task. Sets task status = unplanned, and adjusts rest of the tasks in the employee schedule
        /// <summary>
        public bool UnPlan(Group targetGroup, EmployeeSchedule targetEmployeeSchedule, TaskItem taskToUnplan) // Add methods
        {
            if (taskToUnplan.Locked)
            {
                taskToUnplan.State = TaskItem.Status.Unplanned;
                return false;
            }
                     
            if (targetEmployeeSchedule.TaskItems.IndexOf(taskToUnplan) == 0) //first
            {
                targetEmployeeSchedule.TaskItems.Remove(taskToUnplan);
                //RouteCalculator routeCalc = new RouteCalculator(targetGroup.GroupAddress.ToString(), targetEmployeeSchedule.TaskItems[0].TaskDescription.Citizen.GetAddress(DateTime.Today).ToString());
                //routeCalc.CalculateRoute();
                targetEmployeeSchedule.TaskItems[0].TimePeriod.StartTime = targetEmployeeSchedule.TimePeriod.StartTime;

                for (int i = 1; i < targetEmployeeSchedule.TaskItems.Count; i++)   //adjusts rest of the list
                {
                    AdjustTravelTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                    if (targetEmployeeSchedule.TaskItems[i].Locked)//ERRORS messes the list up (indexes and placement). TODO
                        break;
                    AdjustStartTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                }
                
                taskToUnplan.State = TaskItem.Status.Unplanned;
            }
            else if (targetEmployeeSchedule.TaskItems.IndexOf(taskToUnplan) == targetEmployeeSchedule.TaskItems.Count) //sidste
            {
                targetEmployeeSchedule.TaskItems.Remove(taskToUnplan);
                taskToUnplan.State = TaskItem.Status.Unplanned;
            }
            else
            {
                int index = targetEmployeeSchedule.TaskItems.IndexOf(taskToUnplan);
                targetEmployeeSchedule.TaskItems.Remove(taskToUnplan);

                for (int i = index; i < targetEmployeeSchedule.TaskItems.Count; i++)   //adjusts rest of the list
                {
                    AdjustTravelTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                    if (targetEmployeeSchedule.TaskItems[i].Locked)//ERRORS messes the list up (indexes and placement). TODO
                        break;
                    AdjustStartTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                }

                taskToUnplan.State = TaskItem.Status.Unplanned;

            }

            targetEmployeeSchedule.TimePeriod.EndTime = targetEmployeeSchedule.TaskItems.Last<TaskItem>().TimePeriod.EndTime;
            return true;
        }

        /// <summary>
        /// Updates travelTime in a task, according to previous task.
        /// </summary>
        /// <param name="previousTask"></param>
        /// <param name="task"></param>
        private void AdjustTravelTime(TaskItem previousTask, TaskItem task) 
        {
            task.Route = RouteCalculator.GetRouteItem(previousTask.TaskDescription.Citizen.GetAddress(DateTime.Today), task.TaskDescription.Citizen.GetAddress(DateTime.Today)); // todo date på addresse
        }

        /// <summary>
        /// Updates start time in task according to previous task.
        /// </summary>
        /// <param name="previousTask"></param>
        /// <param name="task"></param>
        private void AdjustStartTime(TaskItem previousTask, TaskItem task) 
        {
            if (!task.Locked)
                task.TimePeriod.StartTime = previousTask.TimePeriod.EndTime + previousTask.Route.Duration;           
             
        }

        public void ToggleLockStatusTask(TaskItem task)
        {
            task.Locked = !task.Locked;
        }

        public List<TaskChange> GetRecentTaskChanges(TaskDescription task, DateTime fromDate)
        {
            return task.GetTaskChanges(t => t.Date >= fromDate); 
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
        
        public void CreateNewEmployeeSchedule(DateTime date, GroupSchedule groupschedule, TimeSpan startTime)
        {
            EmployeeSchedule employeeSchedule = new EmployeeSchedule(date,startTime);
            groupschedule.EmployeeSchedules.Add(employeeSchedule);
        }
        /// <summary>
        /// Removes an employeeschedule from a template schedule
        /// </summary>
        /// <param name="scheduleName"></param>
        /// <param name="group"></param>
        /// <param name="employeeSchedule"></param>
        public void RemoveEmployeeSchedule(string scheduleName, Group group, EmployeeSchedule employeeSchedule)  //from template
        {
            foreach (TaskItem task in employeeSchedule.TaskItems)
            {
                _taskClipBoard.Add(task);
                task.State = TaskItem.Status.Unplanned;
            }
            group.TemplateSchedules[scheduleName].EmployeeSchedules.Remove(employeeSchedule);
            //saved = false
        }
        /// <summary>
        /// Removes an employee schedule drom daily schedule
        /// </summary>
        /// <param name="date"></param>
        /// <param name="group"></param>
        /// <param name="employeeSchedule"></param>
        public void RemoveEmployeeSchedule(DateTime date, Group group, EmployeeSchedule employeeSchedule) //from daily plan
        {
            foreach (TaskItem task in employeeSchedule.TaskItems)
            {
                _taskClipBoard.Add(task);
                task.State = TaskItem.Status.Unplanned;               
            }
            group.DailySchedules[date].EmployeeSchedules.Remove(employeeSchedule);
            //saved = false
        }

        public List<TaskItem> GetTaskClipBoard()
        {
            return _taskClipBoard;
        }

        public void AddTasksToClipBoard(List<TaskItem> tasksToClipBoard) //fx når en ny taskDescription assignes til en gruppe. unplanned TaskItems lægges i clipboard.
        {
            foreach (TaskItem task in tasksToClipBoard)
            {
                _taskClipBoard.Add(task);
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
            Tuple<int, TaskItem> tempItem = new Tuple<int, TaskItem>(int.MaxValue , null);
            List<EmployeeSchedule> employeeSchedules = group.DailySchedules[selectedDate].EmployeeSchedules;
            List<TaskItem> taskItemList = new List<TaskItem>();
            int tempValue = 0;
            int length;

            foreach (EmployeeSchedule schedule in employeeSchedules)
            {
                taskItemList = schedule.TaskItems;
                length = taskItemList.Count();

                for (int i = 0; i < length; i++)
                {
                    tempValue = CompareRoutes(taskItem, taskItemList[i].Route.Waypoints[0], taskItemList[i].Route.Waypoints[1], selectedDate);

                    if (tempValue < tempItem.Item1)
                        tempItem = new Tuple<int, TaskItem>(tempValue, taskItemList[i]);
                }
            }

            return tempItem.Item2;
        }

        private int CompareRoutes(TaskItem taskItemClicked, string startAddress, string endAddress, DateTime selectedDate)
        {
            RouteItem AC = RouteCalculator.GetRouteItem((Address)startAddress, taskItemClicked.TaskDescription.Citizen.GetAddress(selectedDate));
            RouteItem CB = RouteCalculator.GetRouteItem(taskItemClicked.TaskDescription.Citizen.GetAddress(selectedDate), (Address)endAddress);

            return AC.Duration.Seconds + CB.Duration.Seconds;
        }

    }
}
