using System;
using System.Collections.Generic;
using Planning.Model.Modules;
using Planning.Model.Schedules;
using Planning.Model.Employees;

namespace Planning.Model.Schedules
{
    public abstract class Schedule : ISchedule
    {
        public abstract string Name { get; }                                        // Name or title
        public abstract string Description { get; set; }                            // Might be a method to collect data from container element
       
        public virtual bool Approved { get; private set; }                          // Shows state of aproval
        public virtual bool IsSaved { get; private set; } = false;                  // Shows if saved or not

        public Dictionary<Employee, PersonalSchedule> EmployeeSchedules { get; set; } = new Dictionary<Employee, PersonalSchedule>();

        /// <summary>
        /// Initialises a schedule
        /// </summary>
        public Schedule()
        { }

        
        /// <summary>
        /// Adds an element to list
        /// </summary>
        /// <param name="module">Used to add to schedule</param>
        public void AddTaskItem(TaskItem taskItem, Employee targetEmployee)//TODO
        {
            if (EmployeeSchedules.Count != 0)
            {
                TaskItem previousTaskItem = (EmployeeSchedules[targetEmployee].GetTasks(t => t is TaskItem)).FindLast(t=>t is TaskItem);
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
            // raise event
        }

        /// <summary>
        /// Deletes an element
        /// </summary>
        /// <param name="module">Used to remove correct element</param>
        public void DeleteTaskItem(TaskItem taskItem) //TODO
        {
            int index = JobModules.IndexOf(job);   //TODO håndter index = 0 / = count
            JobModule previous = JobModules[index - 1];
            JobModule next = JobModules[index + 1];

            next.CalculateRoute(previous.Reciever.Address);

            JobModules.Remove(job);

            AdjustTime(index);

            IsSaved = false;
        }

        public void InsertTaskItem(int index, TaskItem taskItem)
        {
            JobModules.Insert(index, job);
            JobModule previous = JobModules[index - 1];
            JobModule next = JobModules[index + 1];

            job.CalculateRoute(previous.Reciever.Address);
            next.CalculateRoute(job.Reciever.Address);
            AdjustTime(index);

            //raise event
        }

        private void AdjustTime(int startIndex)
        {
            for (int i = startIndex; i < JobModules.Count; i++) //TODO, håndter startindex = 0
            {
                JobModules[i].Route.StartTime = JobModules[i - 1].EndTime;
                JobModules[i].StartTime = JobModules[i].Route.EndTime;

            }
        }

        /// <summary>
        /// Clears all data from schedule
        /// </summary>
        public abstract void DeleteSchedule();

        /// <summary>
        /// Saves data and updates
        /// </summary>
        public abstract void Save();

        /// <summary>
        /// Set state of Approved variable
        /// </summary>
        /// <param name="state">Indicate approve status</param>
        public abstract void Approve(bool state);
    }
}

