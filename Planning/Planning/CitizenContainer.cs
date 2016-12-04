using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class CitizenContainer
    {
        public List<Citizen> AdmittedCitizens { get; set; }
        public List<Citizen> DischargedCitizens { get; set; }

        public CitizenContainer()
        {
            AdmittedCitizens = new List<Citizen>();
        }

        public void DeleteCitizen(Citizen citizen) //slet fra systemet
        {
            AdmittedCitizens.Remove(citizen);
        }

        public List<Citizen> GetCitizens(Predicate<Citizen> Filter) //hvornår skal vi egentlig det?
        {
            List<Citizen> result = new List<Citizen>();

            foreach (Citizen t in AdmittedCitizens)
            {
                if (Filter(t))
                    result.Add(t);
            }
            return result;
        }

        public List<Citizen> GetCitizen()
        {
            return AdmittedCitizens;
        }
    }
}
