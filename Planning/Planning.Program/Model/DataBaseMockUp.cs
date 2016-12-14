using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.Model
{
    public class DataBaseMockUp
    {
        static List<Citizen> Citizens = new List<Citizen>();

        public static CitizenContainer LoadCitizens()
        {
            CitizenContainer container = new CitizenContainer();

            foreach (Citizen citizen in Citizens)
            {
                container.AddCitizen(citizen);
            }

            return container;
        }

        

        //Til employee clipboard.
        public static List<Employee> LoadEmployees()
        {
            List<Employee> Employees = new List<Employee>();

            Employees.Add(new Employee("Hanne", "Hansen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Lars", "Larsen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Trine", "Trinesen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Grethe", "Grethesen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Kanokporn", "kanokpornsen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Sidse", "Sidsesen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Nico", "Nicosen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Theis", "Sorensen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Niels", "Nielsen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Bo", "Bosen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Morten", "Mortensen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Mohsin", "Mohsinsen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Spang", "Spangsen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Flot", "Flotsen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Mai", "Maisen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Helle", "Hellesen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Simon", "Simonsen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Søren", "Sørensen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Anne", "Annesen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Anna", "Annasen", DateTime.Today, "Hjemmeplejer", "11111111"));
            Employees.Add(new Employee("Kjær", "Kjærsen", DateTime.Today, "Hjemmeplejer", "11111111"));

            return Employees;
        }

        //til groupcontainer.
        public static GroupContainer LoadGroups()
        {
            var container = new GroupContainer();
            List<string> Opgaver = new List<string> { "Toilet", "Rengøring", "Medicin", "Stå op", "Mad", "Bad", "Vaskes" };
            List<int> Tider = new List<int> { 30, 10, 20, 5, 20, 10, 20, 10, 40, 30, 10, 20 };
            Random rnd = new Random();
            List<TaskItem> Tasks = new List<TaskItem>();

            //Addresses
            #region 
            //Snedsted
            Address SnedstedLunegårdsvej5 = new Address("Lunegårdsvej 5, 7752, Snedsted, Denmark");
            Address SnedstedKolonihavevej16 = new Address("Kolonihavevej 16, 7752, Snedsted, Denmark");
            Address SnedstedVandhøjvej9 = new Address("Vandhøjvej 9, 7752, Snedsted, Denmark");
            Address SnedstedRosenvænget22 = new Address("Rosenvænget 22, 7752, Snedsted, Denmark");
            Address Snedstedkærvej9 = new Address("Kærvej 9, 7752, Snedsted, Denmark");
            Address SnedstedVandhøjvej19 = new Address("Vandhøjvej 19, 7752, Snedsted, Denmark");
            Address SnedstedGartnervænget7 = new Address("Gartnervænget 7, 7752, Snedsted, Denmark");
            Address SnedstedIdrætsvej13 = new Address("Idrætsvej 13, 7752, Snedsted, Denmark");
            
            //Sundby
            Address SundbyILiljevej6 = new Address("Liljevej 6, 7752, Sundby, Denmark");
            Address SundbyILiljevej14 = new Address("Liljevej 14, 7752, Sundby, Denmark");
            Address SundbyElstedvej8 = new Address("Elstedvej 8, 7752, Sundby, Denmark");
            Address SundbyElstedvej17 = new Address("Elstedvej 17, 7752, Sundby, Denmark");
            Address SundbyMøgelvej9 = new Address("Møgelvej 9, 7752, Sundby, Denmark");
            Address SundbyMøgelvej13 = new Address("Møgelvej 13, 7752, Sundby, Denmark");

            //Hundborg
            Address HundborgMosevej2 = new Address("Mosevej 2, 7700, Hundborg, Denmark");
            Address HundborgLarsKjærsvej5 = new Address("Lars Kjærs Vej 5, 7700, Hundborg, Denmark");
            Address HundborgRødeAnesVej19 = new Address("Røde Anes Vej 19, 7700, Hundborg, Denmark");
            Address HundborgSolgårdsvej1 = new Address("Solgårdsvej 1, 7700, Hundborg, Denmark");
            Address HundborgMøllestien22 = new Address("Møllestien 22, 7700, Hundborg, Denmark");
            Address HundborgKirkevej16 = new Address("Kirkevej 16, 7700, Hundborg, Denmark");
            Address HundborgLarsKjærsVej6 = new Address("Lars Kjærs Vej 6, 7700, Hundborg, Denmark");
            Address HundborgThadetoftvej14 = new Address("Thadetoftvej 14, 7700, Hundborg, Denmark");

            //Stenbjerg
            Address StenbjergIstrupvej8 = new Address("Istrupvej 8, 7752, Stenbjerg, Denmark");
            Address StenbjergSømærkevej17 = new Address("Sømærkevej 17, 7752, Stenbjerg, Denmark");
            Address StenbjergStrandgårdsvej5 = new Address("Strandgårdsvej5, 7752, Stenbjerg, Denmark");
            Address StenbjergEbenezevej9= new Address("Ebenezevej 9, 7752, Stenbjerg, Denmark");
            Address StenbjergNielsJulesVej21 = new Address("Niels Jules Vej 21, 7752, Stenbjerg, Denmark");
            Address StenbjergStenbjergKirkevej7 = new Address("Stenbjerg Kirkevej 7, 7752, Stenbjerg, Denmark");
            Address StenbjergGråhavrevej12 = new Address("Gråhavrevej 12, 7752, Stenbjerg, Denmark");
            Address StenbjergSarasvej19= new Address("Sarasvej 19, 7752, Stenbjerg, Denmark");

            //Vangså
            Address VangsåTingbakken5 = new Address("Tingbakken 5, 7700, Vangså, Denmark");
            Address VangsåTingbakken16 = new Address("Tingbakken 16, 7700, Vangså, Denmark");
            Address VangsåTingbakken22 = new Address("Tingbakken 22, 7700, Vangså, Denmark");
            Address VangsåSkjærbakken2 = new Address("Skjærbakken 2, 7700, Vangså, Denmark");
            Address VangsåSkjærbakken13 = new Address("Skjærbakken 13, 7700, Vangså, Denmark");
            Address VangsåSkjærbakken17 = new Address("Skjærbakken 17, 7700, Vangså, Denmark");
            Address VangsåHvidbakken4 = new Address("Hvidbakken 4, 7700, Vangså, Denmark");
            Address VangsåHvidbakken7 = new Address("Hvidbakken 7, 7700, Vangså, Denmark");
            Address VangsåHvidbakken15 = new Address("Hvidbakken 15, 7700, Vangså, Denmark");

            //Koldby
            Address KoldbyBorgergade9 = new Address("Borgergade 9, 7752, Koldby, Denmark");
            Address KoldbyAlgade17 = new Address("Algade 17, 7752, Koldby, Denmark");
            Address KoldbyThorsevej27 = new Address("Thorsevej 27, 7752, Koldby, Denmark");
            Address KoldbyLavendelvej19 = new Address("Lavendelvej 19, 7752, Koldby, Denmark");
            Address KoldbyBiblioteksvej1 = new Address("Biblioteksvej 1, 7752, Koldby, Denmark");
            Address KoldbyKirsebærvænget6 = new Address("Kirsebærvænget 6, 7752, Koldby, Denmark");
            Address KoldbyDegnevej13 = new Address("Degnevej13, 7752, Koldby, Denmark");
            Address KoldbySvinget11 = new Address("Degnevej11, 7752, Koldby, Denmark");

            //Hørdum 
            Address HørdumIdylvej6= new Address("Idylvej 6, 7752, Hørdum, Denmark");
            Address HørdumMølbakkvej8 = new Address("Mølbakkevej 8, 7752, Hørdum, Denmark");
            Address HørdumSportsvej13 = new Address("Sportsvej 13, 7752, Hørdum, Denmark");
            Address HørdumBanevej22 = new Address("Banevej 22, 7752, Hørdum, Denmark");
            Address HørdumDamsgårdvej14 = new Address("Damsgårdvej 14, 7752, Hørdum, Denmark");
            Address HørdumTårnvej19 = new Address("Tårnvej 19, 7752, Hørdum, Denmark");
            Address HørdumGisselbækvej22 = new Address("Gisselbækvej 22, 7752, Hørdum, Denmark");
            Address HørdumLegindvej16 = new Address("Legindvej 16, 7752, Hørdum, Denmark");

            #endregion

            //Citizens
            #region
            Citizens.Add(new Citizen("1111111111", "Jose", "Gonzalez", SnedstedLunegårdsvej5, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Kathy", "Peterson", SnedstedKolonihavevej16, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Emily", "Simmons", SnedstedVandhøjvej9, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Scott", "Hill", Snedstedkærvej9, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Harry", "Morgan", SnedstedRosenvænget22, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Anthony", "Smith", SnedstedVandhøjvej19, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "John", "Morris", SnedstedGartnervænget7, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Judith", "Miller", SnedstedIdrætsvej13, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Arthur", "Prerez", SundbyILiljevej6, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Doris", "Edward", SundbyILiljevej14, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "David", "Bell", SundbyElstedvej8, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Daniel", "Scott", SundbyElstedvej17, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Willie", "Russell", SundbyMøgelvej9, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Gerald", "Diaz", SundbyMøgelvej13, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Kelly", "Phillips", HundborgMosevej2, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Maria", "Coleman", HundborgLarsKjærsvej5, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Diana", "Wood", HundborgRødeAnesVej19, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Henry", "Richardson", HundborgSolgårdsvej1, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Catherine", "Foster", HundborgMøllestien22, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Benjamin", "Ramirez", HundborgKirkevej16, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Lois", "Bailey", HundborgLarsKjærsVej6, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Sharon", "Sanchez", HundborgThadetoftvej14, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Michelle", "Robinson", VangsåTingbakken5, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Jeremy", "Brooks", VangsåTingbakken16, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Robert", "Powell", VangsåTingbakken22, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Rebecca", "Wilson", VangsåSkjærbakken2, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Victor", "Jackson", VangsåSkjærbakken13, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Johnny", "Johnson", VangsåHvidbakken4, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Lori", "Lee", StenbjergIstrupvej8, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Jason", "Henderson", VangsåSkjærbakken17, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Annie", "Gray", VangsåHvidbakken15, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Norma", "Martinez", VangsåHvidbakken7, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Rose", "Adams", StenbjergSømærkevej17, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Joseph", "White", StenbjergStrandgårdsvej5, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Denise", "Griffin", StenbjergEbenezevej9, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Douglas", "Murphy", StenbjergNielsJulesVej21, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Lisa", "Torres", StenbjergStenbjergKirkevej7, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Frank", "Green", StenbjergGråhavrevej12, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Roy", "Sanders", StenbjergSarasvej19, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Sean", "Butler", KoldbyBorgergade9, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Todd", "Mitchell", KoldbyAlgade17, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Peter", "Howard", KoldbyThorsevej27, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Ernest", "Baker", KoldbyLavendelvej19, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Margaret", "Lopez", KoldbyBiblioteksvej1, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Laura", "Roberts", KoldbyKirsebærvænget6, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Walter", "Davis", KoldbyDegnevej13, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Mildred", "Perry", KoldbySvinget11, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Joe", "Watson", HørdumIdylvej6, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Anna", "Ward", HørdumMølbakkvej8, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Joan", "Jones", HørdumSportsvej13, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Gary", "Bryant", HørdumBanevej22, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Joyce", "Young", HørdumDamsgårdvej14, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Terry", "Patterson", HørdumTårnvej19, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Carlos", "King", HørdumGisselbækvej22, DateTime.Today));
            Citizens.Add(new Citizen("1111111111", "Jessica", "Parker", HørdumLegindvej16, DateTime.Today));
            #endregion

            //Groups
            List<Group> Groups = new List<Group>();
            #region
            var GroupSnedsted = new Group("Snedsted", "Kærvej 3, 7752, Snedsted, Denmark");
            var GroupHørdum = new Group("Hørdum", "Kærvej 3, 7752, Snedsted, Denmark");
            var GroupKoldby = new Group("Koldby", "Kærvej 3, 7752, Snedsted, Denmark");
            var GroupHundborg = new Group("Hundborg", "Kærvej 3, 7752, Snedsted, Denmark");
            var GroupStenbjerg = new Group("Stenbjerg", "Kærvej 3, 7752, Snedsted, Denmark");
            var GroupVangså = new Group("Vangså", "Kærvej 3, 7752, Snedsted, Denmark");
            var GroupSundby = new Group("Sundby", "Kærvej 3, 7752, Snedsted, Denmark");

            Groups.Add(GroupSnedsted);
            Groups.Add(GroupHørdum);
            Groups.Add(GroupKoldby);
            Groups.Add(GroupHundborg);
            Groups.Add(GroupStenbjerg);
            Groups.Add(GroupVangså);
            Groups.Add(GroupSundby);
            #endregion

            //templates
            #region
            foreach (Group group in Groups)
            {
                group.TemplateSchedules.Add(new GroupSchedule("Mandag"));
                group.TemplateSchedules.Add(new GroupSchedule("Tirsdag"));
                group.TemplateSchedules.Add(new GroupSchedule("Onsdag"));
                group.TemplateSchedules.Add(new GroupSchedule("Torsdag"));
                group.TemplateSchedules.Add(new GroupSchedule("fredag"));
                group.TemplateSchedules.Add(new GroupSchedule("Lørdag"));
                group.TemplateSchedules.Add(new GroupSchedule("Søndag"));
                container.AddGroup(group);
            }
            #endregion

            //EmployeeSchedules
            #region
            foreach (Group group in Groups) {
                for (int i = 0; i < group.TemplateSchedules.Count; i++)
                {
                    group.TemplateSchedules[i].EmployeeSchedules.Add(new EmployeeSchedule(new DateTime(2016, 12, 14), new TimeSpan(8, 0, 0)));
                    group.TemplateSchedules[i].EmployeeSchedules.Add(new EmployeeSchedule(new DateTime(2016, 12, 14), new TimeSpan(8, 0, 0)));
                    group.TemplateSchedules[i].EmployeeSchedules.Add(new EmployeeSchedule(new DateTime(2016, 12, 14), new TimeSpan(8, 0, 0)));
                    group.TemplateSchedules[i].EmployeeSchedules.Add(new EmployeeSchedule(new DateTime(2016, 12, 14), new TimeSpan(8, 0, 0)));
                    group.TemplateSchedules[i].EmployeeSchedules.Add(new EmployeeSchedule(new DateTime(2016, 12, 14), new TimeSpan(8, 0, 0)));
                }
            }
            #endregion

            foreach (Citizen citizen in Citizens)
            {
                int opgave = rnd.Next(Opgaver.Count);
                int tid = rnd.Next(Tider.Count);

                TaskDescription tempTaskDesc = new TaskDescription(Tider[tid], "opgave", citizen, new TimePeriod(TimeSpan.FromHours(8)), DateTime.Today, Opgaver[opgave]);

                Tasks.Add(new TaskItem(tempTaskDesc));
                citizen.Tasks.Add(tempTaskDesc);
            }

            int ran = 0;
            foreach (Group group in Groups)
            {
                foreach (GroupSchedule template in group.TemplateSchedules)
                {
                    foreach (EmployeeSchedule schedule in template.EmployeeSchedules)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            ran = rnd.Next(Tasks.Count);
                            schedule.TaskItems.Add(Tasks[ran]);

                            if (i > 0)
                            {
                                schedule.TaskItems[i].Route.Duration = RouteCalculator.CalculateRouteDuration(schedule.TaskItems[i - 1].TaskDescription.Citizen.GetAddress(DateTime.Today).ToString(), schedule.TaskItems[i].TaskDescription.Citizen.GetAddress(DateTime.Today).ToString());
                            }

                            else if (i == 0)
                            {
                                schedule.TaskItems[i].Route.Duration = RouteCalculator.CalculateRouteDuration("Kærvej 3, 7752, Snedsted, Denmark", schedule.TaskItems[i].TaskDescription.Citizen.GetAddress(DateTime.Today).ToString());
                            }
                        }
                    }
                }
            }
            
            return container;
        }



    }
}
