using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2.Model
{
    class ProtoScheduleFactory
    {

        private Random MAGICNUMBER;
        List<string> descriptions = new List<string> { "Bad","Toiletbesøg","Skift sengetøj", "Rengøring", "Medicin", "Indkøb", "Støvsugning"};

        public ProtoScheduleFactory(int seed)
        {
            MAGICNUMBER = new Random(seed);
        }


        public List<Employee> MakeEmployees(int count)
        {

            List<Employee> EmployeeList = new List<Employee>();
            EmployeeList.Add(new Employee("Anne Andersen",      "85462159"));
            EmployeeList.Add(new Employee("Britt Bruun",        "74693625"));
            EmployeeList.Add(new Employee("Clara Christensen",  "14568763"));
            EmployeeList.Add(new Employee("Ditte Dinesen",      "45862159"));
            EmployeeList.Add(new Employee("Else Eriksen",       "85463241"));
            EmployeeList.Add(new Employee("Freja Friisgaard",   "36421452"));
            EmployeeList.Add(new Employee("Gurli Gris",         "78549654"));


            foreach (var empl in EmployeeList)
            {
                for (int i = 0; i < count; i++)
                {
                    empl.AddAssignment(MakeAssignment());
                }
            }


            return EmployeeList;
        }


        private Assignment MakeAssignment()
        {

            string description = descriptions[MAGICNUMBER.Next(descriptions.Count)];
            int duration = MAGICNUMBER.Next(5, 40);
            int location = MAGICNUMBER.Next(51);
            
            return new Assignment(description, duration, location);
        }


    }
}
