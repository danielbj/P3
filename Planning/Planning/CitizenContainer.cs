using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class CitizenContainer
    {
        private List<Citizen> _citizens;

        public CitizenContainer()
        {
            _citizens = new List<Citizen>();
        }

        public void AddCitizen(Citizen citizen)
        {
            _citizens.Add(citizen); 
        }

        public void DeleteCitizen(Citizen citizen)
        {
            _citizens.Remove(citizen);
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

        public List<Citizen> GetCitizen()
        {
            return _citizens;
        }
    }
}
