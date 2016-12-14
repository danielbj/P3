using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Planning.Model;


namespace Planning.ViewModel
{
    public class DatabaseControl
    {
        public DatabaseControl() {

        }

        public bool EraseDatabaseContent() {
            bool succes;
            using (DatabaseContext ctx = new DatabaseContext()) {
                succes = ctx.Database.Delete();

            }
            return succes;
        }
        
        public void InputQuery(string query) {
            using (DatabaseContext ctx = new DatabaseContext()) {
                ctx.Database.ExecuteSqlCommand(query);
                ctx.SaveChanges();
            }
        }

        public List<Citizen> CitizenQuery(string query) //Remember tablenames are dbo.[namefromServerObjectExplorer]
        {
            List<Citizen> cList = new List<Citizen>();
            using (DatabaseContext ctx = new DatabaseContext())
            {
                cList = ctx.CitizenDB.SqlQuery(query).ToList();
            }

            return cList;
        }

        public void AddCitizen(Citizen c)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.CitizenDB.Add(c);
                ctx.SaveChanges();
            }
        }

        public List<Citizen> ReadCitizens()
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

        public void AddGroupSchedule(GroupSchedule gs) {
            using (DatabaseContext ctx = new DatabaseContext()) {
                ctx.GroupScheduleDB.Add(gs);
                ctx.SaveChanges();
            }
        }
        //Made for manually entering dictionary content.
        //public void AddGroupSchedule(KeyValuePair<string, GroupSchedule> KVgs) {
        //    using (DatabaseContext ctx = new DatabaseContext()) {
        //        ctx.GroupScheduleDB.Add(KVgs.Value);
        //        string query = $"UPDATE dbo.GroupSchedules SET Name = \'{KVgs.Key}\' WHERE GroupScheduleID={KVgs.Value.GroupScheduleID};";

        //        ctx.Database.ExecuteSqlCommand(query);

        //        ctx.SaveChanges();
        //    }
        //}

        public List<GroupSchedule> ReaGroupSchedules() {
            List<GroupSchedule> gsList = new List<GroupSchedule>();
            using (DatabaseContext ctx = new DatabaseContext()) {
                if (ctx.GroupScheduleDB != null) {
                    foreach (GroupSchedule g in ctx.GroupScheduleDB) {
                        gsList.Add(g);
                    }
                }
            }
            return gsList;
        }

        public void AddEmployee(Employee e)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.EmployeeDB.Add(e);
                ctx.SaveChanges();
            }
        }

        public List<Employee> ReadEmployees()
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


        public void AddEmployeeSchedule(EmployeeSchedule es)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.EScheduleDB.Add(es);
                ctx.SaveChanges();
            }
        }

        public List<EmployeeSchedule> ReadEmployeeSchedules()
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


        public void AddTaskDescription(TaskDescription td)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.TaskDescDB.Add(td);
                ctx.SaveChanges();
            }
        }

        public List<TaskDescription> ReadTaskDescriptions()
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

        public void AddTaskItem(TaskItem ti) {
            using (DatabaseContext ctx = new DatabaseContext()) {
                ctx.TaskItemDB.Add(ti);
                ctx.SaveChanges();
            }
        }

        public List<TaskItem> ReadTaskItems() {
            List<TaskItem> tdList = new List<TaskItem>();
            using (DatabaseContext ctx = new DatabaseContext()) {
                if (ctx.TaskItemDB != null) {
                    foreach (TaskItem ti in ctx.TaskItemDB) {
                        tdList.Add(ti);
                    }
                }
            }
            return tdList;
        }


        public void AddGroup(Group g)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.GroupDB.Add(g);
                ctx.SaveChanges();
            }
        }

        public List<Group> ReadGroups()
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

        //SEE https://msdn.microsoft.com/en-us/data/jj574232.aspx
        public GroupContainer ReadAll() {
            GroupContainer grC = new GroupContainer();
            List<Group> gList = new List<Group>();
            List<Group> gList2 = new List<Group>();
            using (DatabaseContext ctx = new DatabaseContext()) {
                gList = ctx.GroupDB.Include(g => g.DailySchedules.Select(gs => gs.EmployeeSchedules.Select(es => es.TaskItems.Select(ti => ti.TaskDescription).Select(td => td.Citizen)))).Include(g => g.Employees).Include(g => g.TaskDescriptions).ToList<Group>();
                gList2 = ctx.GroupDB.Include(g => g.TemplateSchedules.Select(gs => gs.EmployeeSchedules.Select(es => es.TaskItems.Select(ti => ti.TaskDescription).Select(td => td.Citizen)))).Include(g => g.TaskDescriptions).ToList<Group>();
            }

            foreach (Group g in gList) {
                grC.AddGroup(g);
            }

            foreach (Group g in gList2) {
                grC.AddGroup(g);
            }
            return grC;
            
        }
    }
}
