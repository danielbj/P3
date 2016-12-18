using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;

namespace Planning.ViewModel
{
    public class CitizenAdmin
    {

        private CitizenContainer _citizenContainer;

        public CitizenAdmin()
        {
            // TODO rigtig database
            _citizenContainer = DataBaseMockUp.LoadCitizens();
        }

        public CitizenAdmin(CitizenContainer citizenContainer)
        {
            _citizenContainer = citizenContainer;
        }

        public List<Citizen> GetCitizens()
        {
            return _citizenContainer.GetCitizens();
        }        
        /// <summary>
        /// Deletes a citizen from the system. The citizen has to be discharged first.
        /// </summary>
        /// <param name="citizen"></param>
        public void DeleteCitizen(Citizen citizen)
        {
            if (_citizenContainer.AdmittedCitizens.Contains(citizen))
            {
                _citizenContainer.AdmittedCitizens.Remove(citizen);
            }
            else if (_citizenContainer.DischargedCitizens.Contains(citizen))
            {
                _citizenContainer.DischargedCitizens.Remove(citizen);
            }
            else
            {
                throw new ArgumentException("Citizen not found in the system.");
            }
        }          
    }
}
