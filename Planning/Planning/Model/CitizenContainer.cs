using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class CitizenContainer
    {
        private List<Citizen> Citizens = new List<Citizen>();


        public bool AddCitizen(Citizen citizen) {
            Citizens.Add(citizen);

            return Citizens.Contains(citizen);
        }


        public bool DeleteCitizen(Citizen citizen) {
            return Citizens.Remove(citizen);
        }

        public List<Citizen> GetCitizens(Predicate<Citizen> Filter) {
            List<Citizen> result = new List<Citizen>();

            foreach (Citizen t in Citizens) {
                if (Filter(t))
                    result.Add(t);
            }
            return result;
        }
    }
}
