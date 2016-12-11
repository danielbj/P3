using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class Group
    {
        public int GroupId { get; set; }
        public List<Employee> Employees { get; set; }
        public Dictionary<DateTime, GroupSchedule> DailySchedules { get; set; }
        public Dictionary<string, GroupSchedule> TemplateSchedules { get; set; }
        public  Address GroupAddress{ get; set; } 
        public string Name{ get; set; }
        public List<TaskDescription> TaskDescriptions { get; set; }



        public Group(string name, string address)
        {
            Employees = new List<Employee>();
            DailySchedules = new Dictionary<DateTime, GroupSchedule>();
            TemplateSchedules = new Dictionary<string, GroupSchedule>();
            Name = name;
            //GroupAddress = address;
            TaskDescriptions = new List<TaskDescription>();

        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        public List<Employee> GetEmployees(Predicate<Employee> Filter)
        {
            List<Employee> result = new List<Employee>();

            foreach (Employee e in Employees)
            {
                if (Filter(e))
                    result.Add(e);
            }
            return result;
        }

        public List<Employee> GetEmployees()
        {
            return Employees;
        }

        public void AddSchedule(DateTime date, GroupSchedule dailySchedule)
        {
            DailySchedules.Add(date, dailySchedule);
        }

        public void AddSchedule(string name, GroupSchedule templateSchedule)
        {
            TemplateSchedules.Add(name, templateSchedule);
        }

        public void RemoveSchedule(DateTime date)
        {
            DailySchedules.Remove(date);
        }

        public void RemoveSchedule(string name)
        {
            TemplateSchedules.Remove(name);
        }

        public GroupSchedule GetSchedule(DateTime date)
        {
            if (DailySchedules.ContainsKey(date))
            {
                return DailySchedules[date];
            }
            else
            {
                throw new ArgumentException("schedule not found.");
            }
            
        }

        public GroupSchedule GetSchedule(string name)
        {
            if (TemplateSchedules.ContainsKey(name))
            {
                return TemplateSchedules[name];
            }
            else
            {
                throw new ArgumentException("schedule not found.");
            }
        }

        public override string ToString()
        {
            return Name;
        }




    }
}
