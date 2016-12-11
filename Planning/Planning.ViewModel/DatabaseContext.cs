using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Planning.Model;
using Planning.Model.Employees;
using Planning.Model.Schedules;
using Planning.Model.Modules;

namespace Planning.ViewModel
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Citizen> CitizenDB { get; set; }
        public DbSet<Employee> EmployeeDB { get; set; }
        public DbSet<EmployeeSchedule> EScheduleDB { get; set; }
        public DbSet<Group> GroupDB { get; set; }
        public DbSet<TaskDescription> TaskDescDB { get; set; }

    }
}
