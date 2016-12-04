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
        private List<Citizen> _citizens;

        public event CitizenContainerCitizenChangeHandler OnCitizenAdded;
        public event CitizenContainerCitizenChangeHandler OnCitizenRemoved;

        public CitizenContainer()
        {
            _citizens = new List<Citizen>();
        }

        public void AddCitizen(Citizen citizen)
        {
            _citizens.Add(citizen);
            OnCitizenAdded?.Invoke(citizen);
        }

        public void DeleteCitizen(Citizen citizen, DateTime dateDischarged)
        {
            citizen.DateDischarged = dateDischarged;
            _citizens.Remove(citizen);
            OnCitizenRemoved?.Invoke(citizen);
        }

        public List<Citizen> GetCitizens(Predicate<Citizen> Filter) //hvornår skal vi egentlig det?
        {
            List<Citizen> result = new List<Citizen>();

            foreach (Citizen t in _citizens)
            {
                if (Filter(t))
                    result.Add(t);
            }
            return result;
        }

        public List<Citizen> GetCitizens()
        {
            return _citizens;
        }
    }
}
