using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model.Employees;
using Planning.Model.Schedules;
using Planning.Model.Modules;

namespace Planning
{
    public class Group
    {
       
        

        private List<Employee> _employees;
        private Dictionary<DateTime, GroupSchedule> _dailySchedules;
        private Dictionary<string, GroupSchedule> _templateSchedules;
        public  string GroupAddress{ get; set; } //evt som Address?
        public string Name{ get; set; }


        public Group(string name, string address)
        {
            _employees = new List<Employee>();
            _dailySchedules = new Dictionary<DateTime, GroupSchedule>();
            _templateSchedules = new Dictionary<string, GroupSchedule>();
            Name = name;
            address = GroupAddress;
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            _employees.Remove(employee);
        }

        public List<Employee> GetEmployees(Predicate<Employee> Filter)
        {
            List<Employee> result = new List<Employee>();

            foreach (Employee e in _employees)
            {
                if (Filter(e))
                    result.Add(e);
            }
            return result;
        }

        public void AddSchedule(DateTime date, GroupSchedule dailySchedule)
        {
            _dailySchedules.Add(date, dailySchedule);
        }

        public void AddSchedule(string name, GroupSchedule templateSchedule)
        {
            _templateSchedules.Add(name, templateSchedule);
        }

        public void RemoveSchedule(DateTime date)
        {
            _dailySchedules.Remove(date);
        }

        public void RemoveSchedule(string name)
        {
            _templateSchedules.Remove(name);
        }

        public GroupSchedule GetSchedule(DateTime date)
        {
            if (_dailySchedules.ContainsKey(date))
            {
                return _dailySchedules[date];
            }
            else
            {
                throw new ArgumentException("schedule not found.");
            }
            
        }

        public GroupSchedule GetSchedule(string name)
        {
            if (_templateSchedules.ContainsKey(name))
            {
                return _templateSchedules[name];
            }
            else
            {
                throw new ArgumentException("schedule not found.");
            }
        }


    }
}
