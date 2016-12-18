using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{

    public delegate void CitizenContainerCitizenChangeHandler(Citizen citizen);

    public class CitizenContainer
    {
        public List<Citizen> AdmittedCitizens { get; set; }
        public List<Citizen> DischargedCitizens { get; set; }

        public CitizenContainer()
        {
            AdmittedCitizens = new List<Citizen>();
            DischargedCitizens = new List<Citizen>();
        }

        public void AddCitizen(Citizen citizen)
        {
            AdmittedCitizens.Add(citizen); // Check with lists
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

        public List<Citizen> GetCitizens()
        {
            return AdmittedCitizens;
        }
    }
}
