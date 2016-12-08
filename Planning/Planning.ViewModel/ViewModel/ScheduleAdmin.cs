using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;
using Planning.Model.Schedules;
using Planning.Model.Modules;

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

            if (index == 0) //first
            {
                targetEmployeeSchedule.TaskItems.Insert(index, taskToPlan); 
                RouteCalculator routeCalc = new RouteCalculator(targetGroup.GroupAddress.ToString(), taskToPlan.TaskDescription.Citizen.GetAddress(DateTime.Today).ToString());  // Todo med date på adresse
                routeCalc.CalculateRoute();
                taskToPlan.TimePeriod.StartTime = targetEmployeeSchedule.TimeFrame.StartTime;

                for (int i = index +1 ; i < targetEmployeeSchedule.TaskItems.Count; i++)
                {
                    AdjustTravelTime(targetEmployeeSchedule.TaskItems[i-1], targetEmployeeSchedule.TaskItems[i]);
                    AdjustStartTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                }

                taskToPlan.State = TaskItem.Status.Planned;
                
            }
            else if (index == targetEmployeeSchedule.TaskItems.Count)  //last
            {
                targetEmployeeSchedule.TaskItems.Add(taskToPlan);
                AdjustTravelTime(targetEmployeeSchedule.TaskItems[index - 1], taskToPlan);
                AdjustStartTime(targetEmployeeSchedule.TaskItems[index - 1], taskToPlan);
                taskToPlan.State = TaskItem.Status.Planned;
            }

            else
            {
                targetEmployeeSchedule.TaskItems.Insert(index, taskToPlan); 

                for (int i = index; i < targetEmployeeSchedule.TaskItems.Count; i++)
                {
                    AdjustTravelTime(targetEmployeeSchedule.TaskItems[i], targetEmployeeSchedule.TaskItems[i + 1]);
                    AdjustStartTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                }

                taskToPlan.State = TaskItem.Status.Planned;
            }
            targetEmployeeSchedule.TimeFrame.EndTime = targetEmployeeSchedule.TaskItems.Last<TaskItem>().TimePeriod.EndTime;
        }

        /// <summary>
        /// Unplans a task. Sets task status = unplanned, and adjusts rest of the tasks in the employee schedule
        /// </summary>
        /// <param name="targetGroup"></param>
        /// <param name="targetEmployeeSchedule"></param>
        /// <param name="targetTask"></param>
        public void UnPlan(Group targetGroup, EmployeeSchedule targetEmployeeSchedule, TaskItem targetTask) // Add methods
        {            
            if (targetEmployeeSchedule.TaskItems.IndexOf(targetTask) == 0) //first
            {
                targetEmployeeSchedule.TaskItems.Remove(targetTask);
                RouteCalculator routeCalc = new RouteCalculator(targetGroup.GroupAddress.ToString(), targetEmployeeSchedule.TaskItems[0].TaskDescription.Citizen.GetAddress(DateTime.Today).ToString());  // TODO date på address
                routeCalc.CalculateRoute();
                targetEmployeeSchedule.TaskItems[0].TimePeriod.StartTime = targetEmployeeSchedule.TimeFrame.StartTime;

                for (int i = 1; i < targetEmployeeSchedule.TaskItems.Count; i++)   //adjusts rest of the list
                {
                    AdjustTravelTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                    AdjustStartTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                }
                
                targetTask.State = TaskItem.Status.Unplanned;
            }
            else if (targetEmployeeSchedule.TaskItems.IndexOf(targetTask) == targetEmployeeSchedule.TaskItems.Count) //sidste
            {
                targetEmployeeSchedule.TaskItems.Remove(targetTask);
                targetTask.State = TaskItem.Status.Unplanned;
            }
            else
            {
                int index = targetEmployeeSchedule.TaskItems.IndexOf(targetTask);
                targetEmployeeSchedule.TaskItems.Remove(targetTask);

                for (int i = index; i < targetEmployeeSchedule.TaskItems.Count; i++)   //adjusts rest of the list
                {
                    AdjustTravelTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                    AdjustStartTime(targetEmployeeSchedule.TaskItems[i - 1], targetEmployeeSchedule.TaskItems[i]);
                }

                targetTask.State = TaskItem.Status.Unplanned;

            }

            targetEmployeeSchedule.TimeFrame.EndTime = targetEmployeeSchedule.TaskItems.Last<TaskItem>().TimePeriod.EndTime;
        }

        
        private void AdjustTravelTime(TaskItem previousTask, TaskItem task) //opdaterer travelTime i task
        {
            RouteCalculator routeCalc = new RouteCalculator(previousTask.TaskDescription.Citizen.GetAddress(DateTime.Today).ToString(), task.TaskDescription.Citizen.GetAddress(DateTime.Today).ToString()); // TODO date på addresse
            task.Route.Duration = routeCalc.Duration;
        }

        private void AdjustStartTime(TaskItem previousTask, TaskItem task)  //opdaterer start tid i task
        {
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

    }
}
