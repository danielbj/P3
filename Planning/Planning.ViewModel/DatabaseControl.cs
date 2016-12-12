using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Planning.Model;


namespace Planning.ViewModel
{
    public static class DatabaseControl
    {
        
        public static List<Citizen> CitizenQuery(string query) //Remember tablenames are dbo.[namefromDatabaseContextField]
        {
            List<Citizen> cList = new List<Citizen>();
            using (DatabaseContext ctx = new DatabaseContext())
            {
                cList = ctx.CitizenDB.SqlQuery(query).ToList();
            }

            return cList;
        }

        public static void AddCitizen(Citizen c)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.CitizenDB.Add(c);
                ctx.SaveChanges();
            }
        }

        public static List<Citizen> ReadCitizens()
        {
            List<Citizen> cList = new List<Citizen>();
            using (DatabaseContext ctx = new DatabaseContext())
            {
                if (ctx.CitizenDB != null)
                {
                    foreach (Citizen c in ctx.CitizenDB)
                    {
                        cList.Add(c);
                    }
                }
            }
            return cList;
        }

        public static void AddEmployee(Employee e)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.EmployeeDB.Add(e);
                ctx.SaveChanges();
            }
        }

        public static List<Employee> ReadEmployees()
        {
            List<Employee> eList = new List<Employee>();
            using (DatabaseContext ctx = new DatabaseContext())
            {
                if (ctx.EmployeeDB != null)
                {
                    foreach (Employee e in ctx.EmployeeDB)
                    {
                        eList.Add(e);
                    }
                }
            }
            return eList;
        }


        public static void AddEmployeeSchedule(EmployeeSchedule es)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.EScheduleDB.Add(es);
                ctx.SaveChanges();
            }
        }

        public static List<EmployeeSchedule> ReadEmployeeSchedules()
        {
            List<EmployeeSchedule> esList = new List<EmployeeSchedule>();
            using (DatabaseContext ctx = new DatabaseContext())
            {
                if (ctx.EScheduleDB != null)
                {
                    foreach (EmployeeSchedule es in ctx.EScheduleDB)
                    {
                        esList.Add(es);
                    }
                }
            }
            return esList;
        }


        public static void AddTaskDescription(TaskDescription td)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.TaskDescDB.Add(td);
                ctx.SaveChanges();
            }
        }

        public static List<TaskDescription> ReadTaskDescriptions()
        {
            List<TaskDescription> tdList = new List<TaskDescription>();
            using (DatabaseContext ctx = new DatabaseContext())
            {
                if (ctx.TaskDescDB != null)
                {
                    foreach (TaskDescription td in ctx.TaskDescDB)
                    {
                        tdList.Add(td);
                    }
                }
            }
            return tdList;
        }


        public static void AddGroup(Group g)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.GroupDB.Add(g);
                ctx.SaveChanges();
            }
        }

        public static List<Group> ReadGroups()
        {
            List<Group> gList = new List<Group>();
            using (DatabaseContext ctx = new DatabaseContext())
            {
                if (ctx.GroupDB != null)
                {
                    foreach (Group g in ctx.GroupDB)
                    {
                        gList.Add(g);
                    }
                }
            }
            return gList;
        }
    }
}
