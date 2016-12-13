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
        public static CitizenContainer LoadCitizens()
        {
            var container = new CitizenContainer();

            var adrA = new Address("James Tobins Alle 24, 2. th,  9220 Aalborg Øst");
            adrA.StartDate = new DateTime(2016,12,1);
            var citizenA = new Citizen("1712920000", "Nicolai", "Gjøderum",adrA, new DateTime(2016,12,1));
            var taskA1 = new TaskDescription(15, "Bad", citizenA, new TimePeriod(TimeSpan.FromHours(14)), new DateTime(2016,12,1), "Personlig hygiejne");
            var taskA2 = new TaskDescription(20, "Indkøb", citizenA, new TimePeriod(TimeSpan.FromHours(7)), new DateTime(2016, 12, 1), "Andet");
            citizenA.AddTask(taskA1);
            citizenA.AddTask(taskA2);

            var adrB = new Address("Sigensvej 10, 9310 Vodskov");
            adrA.StartDate = new DateTime(2016, 12, 3);
            var citizenB = new Citizen("0202620000", "Leif", "Gjøderum", adrB, new DateTime(2016, 12, 3));
            var taskB1 = new TaskDescription(15, "Bad", citizenB, new TimePeriod(TimeSpan.FromHours(13)), new DateTime(2016, 12, 3), "Personlig hygiejne");
            var taskB2 = new TaskDescription(20, "Toilet", citizenB, new TimePeriod(TimeSpan.FromHours(8)), new DateTime(2016, 12, 3), "Personlig hygiejne");
            citizenB.AddTask(taskB1);
            citizenB.AddTask(taskB2);

            container.AddCitizen(citizenA);
            container.AddCitizen(citizenB);

            return container;
        }

        public static GroupContainer LoadGroups()
        {
            var container = new GroupContainer();

            var gr1 = new Group("Gruppe ds310e16","Selma Lagerløfsvej 300, 9220 Aalborg Øst");

            var emplA = new Employee("Nicolai", "Gjøderum", DateTime.Today, "Datalog", "26112935");
            var emplB = new Employee("Kamilla", "Fincke", DateTime.Today, "Datalog", "22434479");
            var emplC = new Employee("Christian", "Kloster", DateTime.Today, "Datalog", "38383138");

            gr1.AddEmployee(emplA);
            gr1.AddEmployee(emplB);
            gr1.AddEmployee(emplC);

            var adrA = new Address("James Tobins Alle 24,  9220 Aalborg Øst");
            var adrB = new Address("Egevej 14, 9620, Aalestrup");
            var adrC = new Address("Niels Bohrs Vej 36, 9220 Aalborg Øst");
            var adrD = new Address("Teglmarken 181, 8800 Viborg");
            

            adrA.StartDate = new DateTime(2016, 12, 1);
                                                        
            var citizenA = new Citizen("1712920000", "Nicolai", "Gjøderum", adrA, new DateTime(2016, 12, 1));
            var citizenB = new Citizen("1234567800", "Lucas", "AB", adrB, new DateTime(2016, 2, 4));
            var citizenC = new Citizen("9123578000", "Magnus", "Myg", adrC, new DateTime(2016, 11, 9));
            var citizenD = new Citizen("1719879700", "Optimus", "Prime", adrD, new DateTime(2016, 9, 11));

            var es1 = new EmployeeSchedule(DateTime.Today, new TimeSpan(5, 0, 0));
            var es2 = new EmployeeSchedule(DateTime.Today, new TimeSpan(5, 0, 0));


            es1.TaskItems.Add(new TaskItem(new TaskDescription(30, "bad", citizenA, new TimePeriod(TimeSpan.FromHours(8)), DateTime.Today, "bad", 1)));
            es1.TaskItems.Add(new TaskItem(new TaskDescription(15, "Skid", citizenB, new TimePeriod(TimeSpan.FromHours(12)), DateTime.Today, "Skid", 1)));
            es1.TaskItems.Add(new TaskItem(new TaskDescription(45, "Pis", citizenC, new TimePeriod(TimeSpan.FromHours(12)), DateTime.Today, "Skid",1)));
            es1.TaskItems.Add(new TaskItem(new TaskDescription(10, "Bræk mig", citizenD, new TimePeriod(TimeSpan.FromHours(12)), DateTime.Today, "Skid", 1)));

            es2.TaskItems.Add(new TaskItem(new TaskDescription(30, "E2BAD", citizenA, new TimePeriod(TimeSpan.FromHours(8)), DateTime.Today, "bad", 1)));
            es2.TaskItems.Add(new TaskItem(new TaskDescription(45, "E2SKID", citizenB, new TimePeriod(TimeSpan.FromHours(12)), DateTime.Today, "Skid", 1)));

            //add routes to es1
            for (int i = 1; i < es1.TaskItems.Count; i++)
            {
                es1.TaskItems[i].Route.Duration = RouteCalculator.CalculateRouteDuration(es1.TaskItems[i].TaskDescription.Citizen.GetAddress(DateTime.Today).ToString(), es1.TaskItems[i+1].TaskDescription.Citizen.GetAddress(DateTime.Today).ToString());               
            }

            //add routes to es2
            for (int i = 1; i < es2.TaskItems.Count; i++)
            {
                es2.TaskItems[i].Route.Duration = RouteCalculator.CalculateRouteDuration(es2.TaskItems[i].TaskDescription.Citizen.GetAddress(DateTime.Today).ToString(), es2.TaskItems[i + 1].TaskDescription.Citizen.GetAddress(DateTime.Today).ToString());
            }


            var gs1 = new GroupSchedule("Mandag");
            var gs2 = new GroupSchedule("Tirsdag");
            var gs3 = new GroupSchedule("Onsdag");
            var gs4 = new GroupSchedule("Torsdag");
            var gs5 = new GroupSchedule("Fredag");
            var gs6 = new GroupSchedule("Lørdag");
            var gs7 = new GroupSchedule("Søndag");

            gs1.EmployeeSchedules.Add(es1);
            gs1.EmployeeSchedules.Add(es2);

            gr1.TemplateSchedules.Add("Mandag", gs1);
            gr1.AddSchedule(DateTime.Today, gs1);

            var gr2 = new Group("Den magtfulde elite", "St. Helena, Atlanterhavet");
            
            var emplD = new Employee("Napoleon", "Bonaparte", DateTime.Today, "Kejser", "12354678");
            var emplE = new Employee("Lars", "Løkke", DateTime.Today, "Statsminister", "112");
            var emplF = new Employee("Mohsin", "Iqbal", DateTime.Today, "Vejleder", "300 2548 214569 51551 626262 0 G 65454");

            gr2.AddEmployee(emplD);
            gr2.AddEmployee(emplE);
            gr2.AddEmployee(emplF);

            container.AddGroup(gr1);
            container.AddGroup(gr2);


            return container;
        }
    }
}
