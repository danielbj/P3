using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class Group
    {
        // hej
        public int GroupId { get; set; }
        public List<Employee> Employees { get; set; }
        public List<GroupSchedule> DailySchedules { get; set; }
        public List<GroupSchedule> TemplateSchedules { get; set; }
        public Address GroupAddress{ get; set; } 
        public string Name{ get; set; }        
        public List<TaskDescription> TaskDescriptions { get; private set; }

        [Obsolete("Only needed for serialization and materialization in Entity Framework", true)]
        public Group() {    }

        public Group(string name, string address)
        {
            Employees = new List<Employee>();
            DailySchedules = new List<GroupSchedule>();
            TemplateSchedules = new List<GroupSchedule>();
            Name = name;
            GroupAddress = new Address(address);
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

        public void AddDailySchedule(GroupSchedule dailySchedule) 
        {
            DailySchedules.Add(dailySchedule);
            
        }
        public void AddScheduleTemplate(GroupSchedule scheduleTemplate)
        {
            TemplateSchedules.Add(scheduleTemplate);

        }

        public void RemoveDailySchedule(GroupSchedule dailySchedule)
        {
            DailySchedules.Remove(dailySchedule);
        }

        public void RemoveScheduleTmeplate(GroupSchedule templateSchedule)
        {
            TemplateSchedules.Remove(templateSchedule);
        }

        public GroupSchedule GetSchedule(DateTime date) //validering
        {
            return DailySchedules.Find(e => e.Date.Equals(date));
        }

        public GroupSchedule GetSchedule(string name) //validering
        {
            return TemplateSchedules.Find(e => e.Name == name);
        }

        public override string ToString()
        {
            return Name;
        }




    }
}
