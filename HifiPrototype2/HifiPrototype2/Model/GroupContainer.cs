using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2.Model
{
    public class GroupContainer
    {
        public List<Group> GroupList { get; set; } = new List<Group>();

        Random random;
        List<string> descriptions = new List<string> { "Bad", "Personlig Hygiejne", "Skift sengetøj", "Rengøring", "Medicin", "Indkøb", "Støvsugning" };

        public GroupContainer()
        {
            MakeGroup1();
            MakeGroup2();
        }

        private void MakeGroup1()
        {
            List<Employee> EmployeeList = new List<Employee>();
            EmployeeList.Add(new Employee("Anne Andersen", "85462159"));
            EmployeeList.Add(new Employee("Britt Bruun", "74693625"));
            EmployeeList.Add(new Employee("Clara Christensen", "14568763"));
            EmployeeList.Add(new Employee("Ditte Dinesen", "45862159"));
            EmployeeList.Add(new Employee("Else Eriksen", "85463241"));
            EmployeeList.Add(new Employee("Freja Friisgaard", "36421452"));
            EmployeeList.Add(new Employee("Gurli Gris", "78549654"));

            Group group = new Group();
            group.Name = "Snedsted Aften";
            group.EmployeeList = EmployeeList;

            group.Templates.Add(MakeGroupSchedule(5, "Mandag"));

            Assignment assigment = new Assignment();
            assigment.Description = "Bad";
            assigment.Duration = 25;
            assigment.Location = 20;
            var temp = MakeGroupSchedule(6, "Tirsdag");
            temp.UnplanAssignment(assigment);

            group.Templates.Add(temp);

            group.Templates.Add(MakeGroupSchedule(7, "Onsdag"));
            group.Templates.Add(MakeGroupSchedule(8, "Torsdag"));

            group.Shedules.Add(new DateTime?(new DateTime(2016,11,28)), MakeGroupSchedule(9, ""));
            group.Shedules.Add(new DateTime?(new DateTime(2016, 11, 30)), MakeGroupSchedule(11, ""));

            GroupList.Add(group);
        }

        private void MakeGroup2()
        {
            List<Employee> EmployeeList = new List<Employee>();
            EmployeeList.Add(new Employee("Helle Hansen", "15462159"));
            EmployeeList.Add(new Employee("Inge Iversen", "64693625"));
            EmployeeList.Add(new Employee("Jane Jensen", "14868763"));
            EmployeeList.Add(new Employee("Karen Kofoed", "45862959"));
            EmployeeList.Add(new Employee("Lene Larsen", "85433241"));


            Group group = new Group();
            group.Name = "Snedsted Morgen";
            group.EmployeeList = EmployeeList;

            group.Templates.Add(MakeGroupSchedule(1, "Mandag"));
            group.Templates.Add(MakeGroupSchedule(2, "Tirsdag"));
            group.Templates.Add(MakeGroupSchedule(3, "Onsdag"));
            group.Templates.Add(MakeGroupSchedule(4, "Torsdag"));

            group.Shedules.Add(new DateTime?(new DateTime(2016, 11, 28)), MakeGroupSchedule(12, ""));
            group.Shedules.Add(new DateTime?(new DateTime(2016, 11, 29)), MakeGroupSchedule(13, ""));
            group.Shedules.Add(new DateTime?(new DateTime(2016, 11, 30)), MakeGroupSchedule(14, ""));

            GroupList.Add(group);
        }

        public void AddGroup(string name)
        {
            Group group = new Group();
            group.Name = name;
        }

        private GroupSchedule MakeGroupSchedule(int seed, string name)
        {
            random = new Random(seed);
            GroupSchedule gs = new GroupSchedule();
            gs.Name = name;
            for (int i = 0; i < 7; i++)
            {
                EmployeeSchedule es = new EmployeeSchedule();
                es.GroupSchedule = gs;

                for (int j = 0; j < 15; j++)
                {
                    es.AddAssignment(MakeAssignment());
                }

                gs.EmployeeScheduleList.Add(es);
            }

            return gs;
        }

        private Assignment MakeAssignment()
        {
            string description = descriptions[random.Next(descriptions.Count)];
            int duration = random.Next(5, 40);
            int location = random.Next(51);

            return new Assignment(description, duration, location);
        }

    }
}
