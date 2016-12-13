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
        public  Address GroupAddress{ get; set; } 
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

        public void AddSchedule(GroupSchedule schedule)
        {
            if (schedule.Name == null)
                DailySchedules.Add(schedule);
            else
            TemplateSchedules.Add(schedule);
        }

        public void RemoveSchedule(DateTime date)
        {
            GroupSchedule tempGS = DailySchedules.Find(g => g.Date == date);
            if (tempGS != null) {
                DailySchedules.Remove(tempGS);
            }
        }

        public void RemoveSchedule(string name)
        {
            GroupSchedule tempGS = TemplateSchedules.Find(g => String.Equals(g.Name,name));//TODO Is it dangerous to compare strings?
            if (tempGS != null) {
                TemplateSchedules.Remove(tempGS);
            }
        }

        public GroupSchedule GetSchedule(DateTime date)
        {
            GroupSchedule tempGS = DailySchedules.Find(g => g.Date == date);
            if (tempGS != null)
            {
                return tempGS;
            }
            else
            {
                throw new ArgumentException("schedule not found.");
            }
            
        }

        public GroupSchedule GetSchedule(string name)
        {
            GroupSchedule tempGS = TemplateSchedules.Find(g => String.Equals(g.Name, name));
            if (tempGS != null)
            {
                return tempGS;
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
