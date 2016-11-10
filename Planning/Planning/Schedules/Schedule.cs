using Planning.Modules;
using System;
using System.Collections.Generic;

namespace Planning.Schedules
{

    public class Schedule
    {
        public Group EmployeeGroup { get; set; }
        public DateTime StartTime { get; set; }    //start på arbejdsdag
        public DateTime EndTime { get; set; }
        public string Name { get; set; }

        public List<JobModule> JobModules { get; set; } = new List<JobModule>();



        public Schedule(string name, DateTime startTime, DateTime endTime, Group employeeGroup)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            EmployeeGroup = employeeGroup;
        }

        public void AddJob(JobModule job)
        {
            if (JobModules.Count != 0)
            {
                JobModule previousJob = JobModules[JobModules.Count];
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

        public void RemoveJob(JobModule job)
        {
            int index = JobModules.IndexOf(job);   //TODO håndter index = 0 / = count
            JobModule previous = JobModules[index - 1];
            JobModule next = JobModules[index + 1];

            next.CalculateRoute(previous.Reciever.Address);

            JobModules.Remove(job);

            AdjustTime(index);

            //raise event
        }

        public void InsertJob(int index, JobModule job) 
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



    }

    
}

