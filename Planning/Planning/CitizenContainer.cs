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

        public event CitizenContainerCitizenChangeHandler OnCitizenAdded;
        public event CitizenContainerCitizenChangeHandler OnCitizenRemoved;

        public CitizenContainer()
        {
            AdmittedCitizens = new List<Citizen>();
        }

        public void AddCitizen(Citizen citizen)
        {
            _citizens.Add(citizen); // Check with lists
            OnCitizenAdded?.Invoke(citizen);
        }

        public void DeleteCitizen(Citizen citizen, DateTime dateDischarged)
        {
            citizen.DateDischarged = dateDischarged;
            _citizens.Remove(citizen); // Check with lists
            OnCitizenRemoved?.Invoke(citizen);
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
