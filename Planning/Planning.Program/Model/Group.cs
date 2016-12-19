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
            GroupAddress = new Address(address, DateTime.Today);
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
            int index = DailySchedules.FindIndex(g => g.Date.Equals(dailySchedule.Date));
            if (index < 0)
            {
                DailySchedules.Add(dailySchedule);
            }
            else
            {
                DailySchedules[index] = dailySchedule;
            }           
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
            return DailySchedules.Find(g => g.Date.Equals(date));
        }

        public GroupSchedule GetSchedule(string name) //validering
        {
            return TemplateSchedules.Find(g => String.Equals(g.Name, name));
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj) {
            Group tempG = obj as Group;

            if (tempG != null)
                return String.Equals(this.Name, tempG.Name);

            return false;
        }

        public override int GetHashCode() {
            return this.Name.GetHashCode();
        }


    }
}
